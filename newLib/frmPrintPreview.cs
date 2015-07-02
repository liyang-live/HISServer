﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using NLog;
using SubSonic;
using VNS.Libs;
using Microsoft.VisualBasic;
using VNS.HIS.DAL;
using VNS.Properties;
namespace VNS.Libs
{
    public partial class frmPrintPreview : Form
    {
        public string mv_sReportFileName { get; set; }
        public string mv_sReportCode { get; set; }
        CrystalDecisions.CrystalReports.Engine.ReportDocument RptDoc;
        string errTrinhky = "";
        private bool MustCreate;
        public DataSet dsXML = new DataSet();
        public string RType;
        public bool OE;
        public bool bSetMargin = false;
        public string m_strPropertyFolder = Application.StartupPath + @"\Properties";
        public int TopMargin;
        public int LeftMargin;
        public int BottomMargin;
        public int RightMargin;
        public DataRow ORow;
        public DataRow ERow;
        public int vPageCopy = 1;
        public DateTime NGAY = globalVariables.SysDate;
        public CrystalDecisions.Shared.PageMargins margins;
        public bool bCanhLe = false;
        public string mv_sNgayQT = string.Empty;
        //bien nay dung de hien thi thong tin trinh ky
        //XuanDT them vao
        cls_SignInfor mv_oNguoiKy;
        CrystalDecisions.CrystalReports.Engine.TextObject mv_oRptText;
        CrystalDecisions.Shared.ParameterField mv_oRptFieldObj;
        CrystalDecisions.CrystalReports.Engine.ReportDocument mv_oRptDoc;
        CrystalDecisions.Windows.Forms.CrystalReportViewer mv_oViewDoc;
        CrystalDecisions.Shared.ParameterFields mv_oRptPara;
        bool mv_bNgayQToan = false;
        bool mv_bSetContent = true;
        private NLog.Logger log;
        public bool PrintCopy = true;
        bool mv_bAdded = false;
        // private Logger log;
        public frmPrintPreview(string FormTitle, CrystalDecisions.CrystalReports.Engine.ReportDocument RptDoc, bool pv_bSetContent, bool pv_bDisplayPrintButton)
            : base()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();
            log = LogManager.GetCurrentClassLogger();
            
            //Add any initialization after the InitializeComponent() call
            this.Text = FormTitle;
            this.RptDoc = RptDoc;
            //
            this.crptViewer.ReportSource = this.RptDoc;
            cmdTrinhKy.Visible = pv_bSetContent;
            mv_bSetContent = pv_bSetContent;
            this.crptViewer.ShowRefreshButton = false;
            this.crptViewer.ShowPrintButton = pv_bDisplayPrintButton;
           
            txtCopyPage.LostFocus += new EventHandler(txtSoCopyPage_LostFocus);
            InitializeEvents();

            CauHinh();
        }
        public int getPrintNumber
        {
            get { return Utility.Int32Dbnull(txtCopyPage.Text, 1); }
        }
        int printype = 0;//0: Máy in biên lai,phiếu CLS, Đơn thuốc;1=Máy in hóa đơn;2=Máy in phiếu KCB
        public void SetDefaultPrinter(string printerName,int printype)
        {
            this.printype = printype;
            bool _found = false;
            try
            {
                for (int i = 0; i <= cboPrinter.Items.Count - 1; i++)
                    if (Utility.DoTrim(cboPrinter.Items[i].Text).ToUpper() == Utility.DoTrim(printerName).ToUpper())
                    {
                        _found = true;
                        cboPrinter.SelectedIndex = i;
                        return;
                    }
                if (!_found)
                {
                    cboPrinter.Text = "Chọn máy in";
                    cboPrinter.SelectedIndex = -1;
                }
            }
            catch
            {
            }
        }
        public void SetDefaultPrinter(string printerName, int printype,int numofcopies)
        {
            this.printype = printype;
            txtCopyPage.Text = numofcopies.ToString();
            bool _found = false;
            try
            {
                for (int i = 0; i <= cboPrinter.Items.Count - 1; i++)
                    if (Utility.DoTrim(cboPrinter.Items[i].Text).ToUpper() == Utility.DoTrim(printerName).ToUpper())
                    {
                        _found = true;
                        cboPrinter.SelectedIndex = i;
                        return;
                    }
                if (!_found)
                {
                    cboPrinter.Text = "Chọn máy in";
                    cboPrinter.SelectedIndex = -1;
                }
            }
            catch
            {
            }
        }
        private void CauHinh()
        {
            LoadLaserPrinters();
            v_Hasloaded = true;
        }

        //private string FileName = Application.StartupPath + "/PageCopy.txt";
        private void txtSoCopyPage_LostFocus(object sender, EventArgs eventArgs)
        {


        }
        public frmPrintPreview()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();
            //Add any initialization after the InitializeComponent() call
            cmdTrinhKy.Visible = false;
            this.crptViewer.ShowRefreshButton = true;
            InitializeEvents();
            
        }
        private void InitializeEvents()
        {
            cmdTrinhKy.Click += new EventHandler(cmdTrinhKy_Click);
            cmdExcel.Click += new EventHandler(cmdExcel_Click);
            this.Load += new EventHandler(frmPrintPreview_Load);
            this.KeyDown += new KeyEventHandler(frmPrintPreview_KeyDown);

        }
        private void frmPrintPreview_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();

            if (e.KeyCode == Keys.P || (e.Modifiers == Keys.Control && e.KeyCode == Keys.P))
            {
                if (PrintCopy)
                    cmdPrint.PerformClick();
                else
                    crptViewer.PrintReport();
                return;
            }
            if (e.Control && (e.KeyCode == Keys.E || e.KeyCode == Keys.S))
            {
                cmdExcel.PerformClick();
                return;
            }
        }

        private void frmPrintPreview_Load(object sender, System.EventArgs e)
        {

            try
            {
                reportTitle1.Init(mv_sReportCode);
                //SetLanguage(globalVariables.DisplayLanguage, this, "GOLFMAN", globalVariables.SqlConn);
                addTrinhKy_OnFormLoad();
               

                cmdPrint.Focus();
            }
            catch (Exception ex)
            {
                //SetLanguage(globalVariables.DisplayLanguage, this, "GOLFMAN", globalVariables.SqlConn);
            }
            
              
            //CleanTemporaryFolders();

        }
        void LoadPrintNumberByReportCode()
        {
            try
            {
                SysReport objReport = new Select().From(SysReport.Schema).Where(SysReport.Columns.MaBaocao).IsEqualTo(mv_sReportCode).ExecuteSingle<SysReport>();
                if (objReport != null)
                    txtCopyPage.Text = Utility.Int16Dbnull(objReport.PrintNumber, 1).ToString();
                else
                {
                    DataTable dtReports = SPs.SysGetReport(mv_sReportFileName).GetDataSet().Tables[0];
                    if (dtReports != null && dtReports.Rows.Count > 0)
                        txtCopyPage.Text = Utility.Int16Dbnull(dtReports.Rows[0][SysReport.Columns.PrintNumber], 1).ToString();
                    else
                        txtCopyPage.Text = "1";
                }
            }
            catch (Exception ex)
            {
                
                
            }
        }
        
        public void Hide_Control()
        {
            cmdTrinhKy.Visible = false;
        }
        private void cmdTrinhKy_Click(object sender, System.EventArgs e)
        {
            //XuanDT Them ham nay vao
            addTrinhKy_OnButtonClick();
        }

        public void addTrinhKy_OnFormLoad()
        {
            //Ham nay XuanDT them vao
            try
            {
                LoadPrintNumberByReportCode();
                //doan gan cac bien: doan nay co the phai thay doi ten bien cho phu hop
                mv_oRptDoc = RptDoc;
                mv_oViewDoc = this.crptViewer;
                //ket thuc doan gan bien

                mv_oRptFieldObj = GetTrinhky(RptDoc.ParameterFields);
                if (mv_oRptFieldObj == null) return;
                mv_oNguoiKy = new cls_SignInfor(string.IsNullOrEmpty(mv_sReportFileName) ? mv_oRptDoc.ToString() : mv_sReportFileName, "");
                //chkPrint_CheckedChanged(chkPrint, New System.EventArgs)
                if (mv_oNguoiKy._TonTai)
                {
                    SetParamAgain(RptDoc.ParameterFields);
                    //if (mv_bSetContent)
                    //{
                        
                    //    mv_oRptDoc.ReportDefinition.ReportObjects["txtTrinhky"]..Text = mv_oNguoiKy.mv_NOI_DUNG.Replace("&NHANVIEN", globalVariables.gv_strTenNhanvien);
                       
                    //}
                    //else
                    //{
                    //    mv_oRptDoc.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    //}
                   
                }
                else
                {
                    SetParamAgain(RptDoc.ParameterFields);
                    if (string.IsNullOrEmpty(mv_sReportFileName))
                        mv_oNguoiKy = new cls_SignInfor(mv_oRptFieldObj, "", RptDoc.ToString(), "");
                    else
                    {
                        mv_oNguoiKy = new cls_SignInfor(mv_oRptFieldObj, "", mv_sReportFileName, "");
                    }

                }
                mv_oViewDoc.ReportSource = RptDoc;
            }
            catch (Exception ex)
            {
                mv_oRptText = null;
                //an nut tuy chon di
                log.Error("Loi trong qua trinh load thong tin trình ky={0}", ex);
                this.cmdTrinhKy.Visible = false;
            }
        }
       
        public void addTrinhKy_OnButtonClick()
        {
            if (mv_oRptFieldObj == null) return;

            try
            {
                //Hien form de thay doi tuy chon ky
                frm_SignInfor sv_fTuyChonKy = new frm_SignInfor();
                sv_fTuyChonKy.txtBaoCao.Text = this.mv_oNguoiKy.mv_TEN_BIEUBC;
                //sv_fTuyChonKy.txtCoChu.Text = Me.mv_oNguoiKy.mv_CO_CHU.ToString()

                //sv_fTuyChonKy.txtKieuFont.Text = Me.mv_oNguoiKy.mv_KIEU_CHU
                //#$X$# cua XuanDT, khong duoc doi
                sv_fTuyChonKy.txtTrinhky.Rtf = this.mv_oNguoiKy.mv_NOI_DUNG;
                
                //sv_fTuyChonKy.txtTenFont.Text = Me.mv_oNguoiKy.mv_FONT_CHU
                sv_fTuyChonKy.mv_sFontName = this.mv_oNguoiKy.mv_FONT_CHU;
                sv_fTuyChonKy.mv_sFontSize = this.mv_oNguoiKy.mv_CO_CHU.ToString();
                sv_fTuyChonKy.mv_sFontStyle = this.mv_oNguoiKy.mv_KIEU_CHU;
                //sv_fTuyChonKy.mv_sSoLuongCanIn=this.mv_oNguoiKy.mv
                sv_fTuyChonKy.ShowDialog();
                if (sv_fTuyChonKy.mv_bChapNhan)
                {
                    this.mv_oNguoiKy.mv_TEN_BIEUBC = sv_fTuyChonKy.txtBaoCao.Text.Trim();
                    if (!mv_bAdded)
                    {
                        this.mv_oNguoiKy.mv_NOI_DUNG = sv_fTuyChonKy.txtTrinhky.Rtf;
                    }
                    else
                    {
                        this.mv_oNguoiKy.mv_NOI_DUNG = sv_fTuyChonKy.txtTrinhky.Rtf;
                    }
                    if (sv_fTuyChonKy.chkGhiLai.Checked == true)
                    {
                        this.mv_oNguoiKy.updateRPTtoDB();
                    }
                    SetParamAgain(RptDoc.ParameterFields);
                    //if (mv_bSetContent)
                    //{
                    //    mv_oRptDoc.DataDefinition.FormulaFields["Formula_1"].Text =  mv_oNguoiKy.mv_NOI_DUNG.Replace("&NHANVIEN", globalVariables.gv_strTenNhanvien);
                    //}
                    //else
                    //{
                    //    mv_oRptDoc.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    //}
                    //mv_oViewDoc.ReportSource = Nothing
                    mv_oViewDoc.ReportSource = RptDoc;
                }
            }
            catch (Exception ex)
            {

            }
        }
        void SetTrinhky(CrystalDecisions.Shared.ParameterFields p)
        {
            try
            {
                CrystalDecisions.Shared.ParameterFields p0 = new CrystalDecisions.Shared.ParameterFields();
                for (int i = 0; i <= p.Count - 1; i++)
                {
                    if (p[i].ParameterFieldName.ToUpper() == "txtTrinhky".ToUpper())
                    {
                        if (mv_bSetContent)
                        {
                            string sPvalue=mv_oNguoiKy.mv_NOI_DUNG.Replace("&NHANVIEN", globalVariables.gv_strTenNhanvien);
                            sPvalue = sPvalue.Replace("&NGAYIN", GetRtfUnicodeEscapedString(Utility.FormatDateTimeWithLocation(globalVariables.SysDate, globalVariables.gv_strDiadiem)));
                            sPvalue = sPvalue.Replace("&NGUOIIN", GetRtfUnicodeEscapedString(globalVariables.gv_strTenNhanvien));
                            RptDoc.SetParameterValue(p[i].ParameterFieldName, sPvalue);
                        }
                        else
                        {
                            RptDoc.SetParameterValue(p[i].ParameterFieldName,"");
                        }
                        break;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        static string GetRtfUnicodeEscapedString(string s)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (var c in s)
                {
                    if (c == '\\' || c == '{' || c == '}')
                        sb.Append(@"\" + c);
                    else if (c <= 0x7f)
                        sb.Append(c);
                    else
                        sb.Append("\\u" + Convert.ToUInt32(c) + "?");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Utility.CatchException("GetRtfUnicodeEscapedString.Exception", ex);
                return s;
                
            }
            
        }
        CrystalDecisions.Shared.ParameterField GetTrinhky(CrystalDecisions.Shared.ParameterFields p)
        {
            try
            {
                CrystalDecisions.Shared.ParameterFields p0 = new CrystalDecisions.Shared.ParameterFields();
                for (int i = 0; i <= p.Count - 1; i++)
                {
                    if (p[i].ParameterFieldName.ToUpper() == "txtTrinhky".ToUpper())
                    {
                        return p[i];
                    }

                }
                return null;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return null;
            }
        }
        private void SetParamAgain(CrystalDecisions.Shared.ParameterFields p)
        {
            try
            {
                errTrinhky = "";
                for (int i = 0; i <= p.Count - 1; i++)
                {
                    if (p[i].ParameterFieldName.ToUpper() == "txtTrinhky".ToUpper())
                    {
                        if (mv_bSetContent)
                        {
                            string sPvalue = mv_oNguoiKy.mv_NOI_DUNG.Replace("&NHANVIEN", GetRtfUnicodeEscapedString(globalVariables.gv_strTenNhanvien));
                            sPvalue = sPvalue.Replace("&NGAYIN", GetRtfUnicodeEscapedString(Utility.FormatDateTimeWithLocation(globalVariables.SysDate, globalVariables.gv_strDiadiem)));
                            sPvalue = sPvalue.Replace("&NGUOIIN", GetRtfUnicodeEscapedString(globalVariables.gv_strTenNhanvien));
                            RptDoc.SetParameterValue(p[i].ParameterFieldName, sPvalue);
                        }
                        else
                        {
                            RptDoc.SetParameterValue(p[i].ParameterFieldName, "");
                        }
                    }
                    else if (p[i].ParameterFieldName.ToUpper() == "TXTNGAYQT")
                    {
                    }
                    else
                    {
                        if (p[i].CurrentValues.Count > 0)
                            RptDoc.SetParameterValue(p[i].ParameterFieldName, ((CrystalDecisions.Shared.ParameterDiscreteValue)p[i].CurrentValues[0]).Value);
                        else
                            RptDoc.SetParameterValue(p[i].ParameterFieldName, getDefaultValue(p[i].ParameterValueType));
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        object getDefaultValue(ParameterValueKind kind)
        {
            if (kind == ParameterValueKind.StringParameter)
                return "";
            else if (kind == ParameterValueKind.BooleanParameter)
                return false;
            else if (kind == ParameterValueKind.CurrencyParameter)
                return 0;
            else if (kind == ParameterValueKind.DateParameter)
                return DateTime.Now;
            else if (kind == ParameterValueKind.DateTimeParameter)
                return DateTime.Now;
            else if (kind == ParameterValueKind.NumberParameter)
                return 0;
           
            else 
                return "";
        }

        private void crptViewer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }

        private void cmdExcel_Click(object sender, System.EventArgs e)
        {
            string sFileName = "";
            try
            {
                SaveFileDialog SaveFileDlg = new SaveFileDialog();
                SaveFileDlg.Title = "VietBaJC-->Save to Excel file";
                SaveFileDlg.Filter = "Excel files|*.XLS";
                if (SaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    sFileName = SaveFileDlg.FileName;
                    if (sFileName.Contains(".XLS"))
                    {
                    }
                    else
                    {
                        sFileName += ".XLS";
                    }
                    this.Text = "Đang lưu dữ liệu ra file: " + sFileName;
                    RptDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, sFileName);
                    this.Text = "In dữ liệu";
                    if (Utility.AcceptQuestion("Đã xuất dữ liệu thành công ra file Excel ở đường dẫn: " + sFileName + Constants.vbCrLf + "Bạn có muốn mở file Excel ra xem không?", "Thông báo", true))
                    {
                        System.Diagnostics.Process.Start(sFileName);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        void LoadLaserPrinters()
        {
            try
            {
                //khoi tao may in
                String pkInstalledPrinters;
                cboPrinter.Items.Clear();
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                    cboPrinter.Items.Add(pkInstalledPrinters);
                }
            }
            catch
            {
            }
            finally
            {
                if (cboPrinter.Items.Count <= 0)
                    Utility.ShowMsg("no printers found on your computer", "warning");
                cboPrinter.Text = PropertyLib._MayInProperties.Tenmayincuoicung;
            }
        }
        private void cmdTrinhKy_Click_1(object sender, EventArgs e)
        {

        }

        private void frmPrintPreview_Load_1(object sender, EventArgs e)
        {

        }

        private void cmdTrinhKy_Click_2(object sender, EventArgs e)
        {

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utility.Int32Dbnull(txtCopyPage.Text) <= 0)
                {
                    //Utility.ShowMsg("Số lượng bản in phải>=1", "Thông báo", MessageBoxIcon.Warning);
                    txtCopyPage.Focus();
                    txtCopyPage.SelectAll();
                    txtCopyPage.Text = "1";
                    return;
                }
                new Update(SysReport.Schema).Set(SysReport.Columns.PrintNumber).EqualTo(Utility.Int32Dbnull(txtCopyPage.Text,1))
                    .Where(SysReport.Columns.MaBaocao).IsEqualTo(mv_sReportCode).Execute();
                if (cboPrinter.SelectedIndex > -1)
                {
                    RptDoc.PrintOptions.PrinterName = cboPrinter.Text;
                    RptDoc.PrintToPrinter(Utility.Int32Dbnull(txtCopyPage.Text, 1), true, 0, 0);
                    switch (printype)
                    {
                        case 0:
                            PropertyLib._MayInProperties.TenMayInBienlai = cboPrinter.Text;
                            break;
                        case 1:
                            PropertyLib._MayInProperties.TenMayInHoadon = cboPrinter.Text;
                            break;
                        case 2:
                            PropertyLib._MayInProperties.TenMayInPhieuKCB = cboPrinter.Text;
                            break;
                        default:
                            PropertyLib._MayInProperties.TenMayInBienlai = cboPrinter.Text;
                            break;
                    }
                    PropertyLib.SaveProperty(PropertyLib._MayInProperties);
                    this.Close();
                }
                else
                {
                    Utility.ShowMsg("Bạn cần chọn máy in", "Thông báo");
                }
            }
            catch (Exception)
            {


            }

        }
        /// <summary>
        /// hàm thực hiện việc 
        /// </summary>
        private void CleanTemporaryFolders()
        {
            try
            {
                String tempFolder = Environment.ExpandEnvironmentVariables("%TEMP%");
                // String recent = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + "\\Recent";
                // String prefetch = Environment.ExpandEnvironmentVariables("%SYSTEMROOT%") + "\\Prefetch";
                EmptyFolderContents(tempFolder);
                //  EmptyFolderContents(recent);
                //  EmptyFolderContents(prefetch);
            }
            catch (Exception)
            {


            }

        }
        /// <summary>
        /// hàm thực hiện rỗng thư mục của dữ liệu trong Folder
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        private void EmptyFolderContents(string folderName)
        {
            try
            {
                foreach (var folder in Directory.GetDirectories(folderName))
                {
                    try
                    {
                        Directory.Delete(folder, true);
                    }
                    catch (Exception excep)
                    {
                        System.Diagnostics.Debug.WriteLine(excep);
                    }
                }
                foreach (var file in Directory.GetFiles(folderName))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception excep)
                    {
                        System.Diagnostics.Debug.WriteLine(excep);
                    }
                }
            }
            catch (Exception)
            {


            }

        }
        private void txtCopyPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmdPrint.Focus();
        }

        private void txtCopyPage_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (Utility.Int32Dbnull(txtCopyPage.Text) <= 0)
            //    {
            //        Utility.ShowMsg("Số lượng bản in không được <=0\n Mời bạn xem lại", "Thông báo", MessageBoxIcon.Warning);
            //        txtCopyPage.Text = "1";
            //        txtCopyPage.Focus();
            //        txtCopyPage.SelectAll();

            //        e.Cancel = true;
            //    }
            //}
            //catch (Exception)
            //{

            //    txtCopyPage.Text = "1";
            //}

        }

        private void frmPrintPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //RptDoc.Close();
                //RptDoc.Dispose();
                //CleanTemporaryFolders();
            }
            catch (Exception)
            {


            }

        }

        private bool v_Hasloaded = false;
        /// <summary>
        /// hàm thực hiện việc lấy thông tin cấu hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetConfig_Click(object sender, EventArgs e)
        {
            CauHinh();
        }
        void SaveDefaultPrinter()
        {
            try
            {
                PropertyLib._MayInProperties.Tenmayincuoicung = Utility.sDbnull(cboPrinter.Text);
                PropertyLib.SaveProperty(PropertyLib._MayInProperties);

            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi lưu trạng thái-->" + ex.Message);
            }
        }

        private void cboPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!v_Hasloaded) return;
                SaveDefaultPrinter();
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void cmdCalculator_Click(object sender, EventArgs e)
        {
            Utility.OpenProcess("Calc");
        }


    }
}
