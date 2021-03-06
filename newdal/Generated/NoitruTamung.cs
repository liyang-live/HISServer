using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace VNS.HIS.DAL
{
	/// <summary>
	/// Strongly-typed collection for the NoitruTamung class.
	/// </summary>
    [Serializable]
	public partial class NoitruTamungCollection : ActiveList<NoitruTamung, NoitruTamungCollection>
	{	   
		public NoitruTamungCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>NoitruTamungCollection</returns>
		public NoitruTamungCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                NoitruTamung o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the noitru_tamung table.
	/// </summary>
	[Serializable]
	public partial class NoitruTamung : ActiveRecord<NoitruTamung>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public NoitruTamung()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public NoitruTamung(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public NoitruTamung(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public NoitruTamung(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("noitru_tamung", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int64;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdBenhnhan = new TableSchema.TableColumn(schema);
				colvarIdBenhnhan.ColumnName = "id_benhnhan";
				colvarIdBenhnhan.DataType = DbType.Int64;
				colvarIdBenhnhan.MaxLength = 0;
				colvarIdBenhnhan.AutoIncrement = false;
				colvarIdBenhnhan.IsNullable = false;
				colvarIdBenhnhan.IsPrimaryKey = false;
				colvarIdBenhnhan.IsForeignKey = false;
				colvarIdBenhnhan.IsReadOnly = false;
				colvarIdBenhnhan.DefaultSetting = @"";
				colvarIdBenhnhan.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBenhnhan);
				
				TableSchema.TableColumn colvarMaLuotkham = new TableSchema.TableColumn(schema);
				colvarMaLuotkham.ColumnName = "ma_luotkham";
				colvarMaLuotkham.DataType = DbType.AnsiString;
				colvarMaLuotkham.MaxLength = 20;
				colvarMaLuotkham.AutoIncrement = false;
				colvarMaLuotkham.IsNullable = false;
				colvarMaLuotkham.IsPrimaryKey = false;
				colvarMaLuotkham.IsForeignKey = false;
				colvarMaLuotkham.IsReadOnly = false;
				colvarMaLuotkham.DefaultSetting = @"";
				colvarMaLuotkham.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaLuotkham);
				
				TableSchema.TableColumn colvarSoTien = new TableSchema.TableColumn(schema);
				colvarSoTien.ColumnName = "so_tien";
				colvarSoTien.DataType = DbType.Decimal;
				colvarSoTien.MaxLength = 0;
				colvarSoTien.AutoIncrement = false;
				colvarSoTien.IsNullable = true;
				colvarSoTien.IsPrimaryKey = false;
				colvarSoTien.IsForeignKey = false;
				colvarSoTien.IsReadOnly = false;
				colvarSoTien.DefaultSetting = @"";
				colvarSoTien.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSoTien);
				
				TableSchema.TableColumn colvarTrangThai = new TableSchema.TableColumn(schema);
				colvarTrangThai.ColumnName = "trang_thai";
				colvarTrangThai.DataType = DbType.Byte;
				colvarTrangThai.MaxLength = 0;
				colvarTrangThai.AutoIncrement = false;
				colvarTrangThai.IsNullable = false;
				colvarTrangThai.IsPrimaryKey = false;
				colvarTrangThai.IsForeignKey = false;
				colvarTrangThai.IsReadOnly = false;
				
						colvarTrangThai.DefaultSetting = @"((0))";
				colvarTrangThai.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrangThai);
				
				TableSchema.TableColumn colvarNgayTamung = new TableSchema.TableColumn(schema);
				colvarNgayTamung.ColumnName = "ngay_tamung";
				colvarNgayTamung.DataType = DbType.DateTime;
				colvarNgayTamung.MaxLength = 0;
				colvarNgayTamung.AutoIncrement = false;
				colvarNgayTamung.IsNullable = true;
				colvarNgayTamung.IsPrimaryKey = false;
				colvarNgayTamung.IsForeignKey = false;
				colvarNgayTamung.IsReadOnly = false;
				colvarNgayTamung.DefaultSetting = @"";
				colvarNgayTamung.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgayTamung);
				
				TableSchema.TableColumn colvarKieuTamung = new TableSchema.TableColumn(schema);
				colvarKieuTamung.ColumnName = "kieu_tamung";
				colvarKieuTamung.DataType = DbType.Byte;
				colvarKieuTamung.MaxLength = 0;
				colvarKieuTamung.AutoIncrement = false;
				colvarKieuTamung.IsNullable = true;
				colvarKieuTamung.IsPrimaryKey = false;
				colvarKieuTamung.IsForeignKey = false;
				colvarKieuTamung.IsReadOnly = false;
				
						colvarKieuTamung.DefaultSetting = @"((0))";
				colvarKieuTamung.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKieuTamung);
				
				TableSchema.TableColumn colvarMotaThem = new TableSchema.TableColumn(schema);
				colvarMotaThem.ColumnName = "mota_them";
				colvarMotaThem.DataType = DbType.String;
				colvarMotaThem.MaxLength = 255;
				colvarMotaThem.AutoIncrement = false;
				colvarMotaThem.IsNullable = true;
				colvarMotaThem.IsPrimaryKey = false;
				colvarMotaThem.IsForeignKey = false;
				colvarMotaThem.IsReadOnly = false;
				colvarMotaThem.DefaultSetting = @"";
				colvarMotaThem.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMotaThem);
				
				TableSchema.TableColumn colvarIdTnv = new TableSchema.TableColumn(schema);
				colvarIdTnv.ColumnName = "id_tnv";
				colvarIdTnv.DataType = DbType.Int32;
				colvarIdTnv.MaxLength = 0;
				colvarIdTnv.AutoIncrement = false;
				colvarIdTnv.IsNullable = true;
				colvarIdTnv.IsPrimaryKey = false;
				colvarIdTnv.IsForeignKey = false;
				colvarIdTnv.IsReadOnly = false;
				colvarIdTnv.DefaultSetting = @"";
				colvarIdTnv.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdTnv);
				
				TableSchema.TableColumn colvarNguoiSua = new TableSchema.TableColumn(schema);
				colvarNguoiSua.ColumnName = "nguoi_sua";
				colvarNguoiSua.DataType = DbType.String;
				colvarNguoiSua.MaxLength = 20;
				colvarNguoiSua.AutoIncrement = false;
				colvarNguoiSua.IsNullable = true;
				colvarNguoiSua.IsPrimaryKey = false;
				colvarNguoiSua.IsForeignKey = false;
				colvarNguoiSua.IsReadOnly = false;
				colvarNguoiSua.DefaultSetting = @"";
				colvarNguoiSua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNguoiSua);
				
				TableSchema.TableColumn colvarNgaySua = new TableSchema.TableColumn(schema);
				colvarNgaySua.ColumnName = "ngay_sua";
				colvarNgaySua.DataType = DbType.DateTime;
				colvarNgaySua.MaxLength = 0;
				colvarNgaySua.AutoIncrement = false;
				colvarNgaySua.IsNullable = true;
				colvarNgaySua.IsPrimaryKey = false;
				colvarNgaySua.IsForeignKey = false;
				colvarNgaySua.IsReadOnly = false;
				colvarNgaySua.DefaultSetting = @"";
				colvarNgaySua.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgaySua);
				
				TableSchema.TableColumn colvarNguoiTao = new TableSchema.TableColumn(schema);
				colvarNguoiTao.ColumnName = "nguoi_tao";
				colvarNguoiTao.DataType = DbType.String;
				colvarNguoiTao.MaxLength = 20;
				colvarNguoiTao.AutoIncrement = false;
				colvarNguoiTao.IsNullable = true;
				colvarNguoiTao.IsPrimaryKey = false;
				colvarNguoiTao.IsForeignKey = false;
				colvarNguoiTao.IsReadOnly = false;
				colvarNguoiTao.DefaultSetting = @"";
				colvarNguoiTao.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNguoiTao);
				
				TableSchema.TableColumn colvarNgayTao = new TableSchema.TableColumn(schema);
				colvarNgayTao.ColumnName = "ngay_tao";
				colvarNgayTao.DataType = DbType.DateTime;
				colvarNgayTao.MaxLength = 0;
				colvarNgayTao.AutoIncrement = false;
				colvarNgayTao.IsNullable = true;
				colvarNgayTao.IsPrimaryKey = false;
				colvarNgayTao.IsForeignKey = false;
				colvarNgayTao.IsReadOnly = false;
				
						colvarNgayTao.DefaultSetting = @"(getdate())";
				colvarNgayTao.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNgayTao);
				
				TableSchema.TableColumn colvarIdKhoanoitru = new TableSchema.TableColumn(schema);
				colvarIdKhoanoitru.ColumnName = "id_khoanoitru";
				colvarIdKhoanoitru.DataType = DbType.Int16;
				colvarIdKhoanoitru.MaxLength = 0;
				colvarIdKhoanoitru.AutoIncrement = false;
				colvarIdKhoanoitru.IsNullable = true;
				colvarIdKhoanoitru.IsPrimaryKey = false;
				colvarIdKhoanoitru.IsForeignKey = false;
				colvarIdKhoanoitru.IsReadOnly = false;
				colvarIdKhoanoitru.DefaultSetting = @"";
				colvarIdKhoanoitru.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdKhoanoitru);
				
				TableSchema.TableColumn colvarIdBuonggiuong = new TableSchema.TableColumn(schema);
				colvarIdBuonggiuong.ColumnName = "id_buonggiuong";
				colvarIdBuonggiuong.DataType = DbType.Int32;
				colvarIdBuonggiuong.MaxLength = 0;
				colvarIdBuonggiuong.AutoIncrement = false;
				colvarIdBuonggiuong.IsNullable = true;
				colvarIdBuonggiuong.IsPrimaryKey = false;
				colvarIdBuonggiuong.IsForeignKey = false;
				colvarIdBuonggiuong.IsReadOnly = false;
				colvarIdBuonggiuong.DefaultSetting = @"";
				colvarIdBuonggiuong.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBuonggiuong);
				
				TableSchema.TableColumn colvarIdBuong = new TableSchema.TableColumn(schema);
				colvarIdBuong.ColumnName = "id_buong";
				colvarIdBuong.DataType = DbType.Int32;
				colvarIdBuong.MaxLength = 0;
				colvarIdBuong.AutoIncrement = false;
				colvarIdBuong.IsNullable = true;
				colvarIdBuong.IsPrimaryKey = false;
				colvarIdBuong.IsForeignKey = false;
				colvarIdBuong.IsReadOnly = false;
				colvarIdBuong.DefaultSetting = @"";
				colvarIdBuong.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdBuong);
				
				TableSchema.TableColumn colvarIdGiuong = new TableSchema.TableColumn(schema);
				colvarIdGiuong.ColumnName = "id_giuong";
				colvarIdGiuong.DataType = DbType.Int32;
				colvarIdGiuong.MaxLength = 0;
				colvarIdGiuong.AutoIncrement = false;
				colvarIdGiuong.IsNullable = true;
				colvarIdGiuong.IsPrimaryKey = false;
				colvarIdGiuong.IsForeignKey = false;
				colvarIdGiuong.IsReadOnly = false;
				colvarIdGiuong.DefaultSetting = @"";
				colvarIdGiuong.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdGiuong);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("noitru_tamung",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public long Id 
		{
			get { return GetColumnValue<long>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdBenhnhan")]
		[Bindable(true)]
		public long IdBenhnhan 
		{
			get { return GetColumnValue<long>(Columns.IdBenhnhan); }
			set { SetColumnValue(Columns.IdBenhnhan, value); }
		}
		  
		[XmlAttribute("MaLuotkham")]
		[Bindable(true)]
		public string MaLuotkham 
		{
			get { return GetColumnValue<string>(Columns.MaLuotkham); }
			set { SetColumnValue(Columns.MaLuotkham, value); }
		}
		  
		[XmlAttribute("SoTien")]
		[Bindable(true)]
		public decimal? SoTien 
		{
			get { return GetColumnValue<decimal?>(Columns.SoTien); }
			set { SetColumnValue(Columns.SoTien, value); }
		}
		  
		[XmlAttribute("TrangThai")]
		[Bindable(true)]
		public byte TrangThai 
		{
			get { return GetColumnValue<byte>(Columns.TrangThai); }
			set { SetColumnValue(Columns.TrangThai, value); }
		}
		  
		[XmlAttribute("NgayTamung")]
		[Bindable(true)]
		public DateTime? NgayTamung 
		{
			get { return GetColumnValue<DateTime?>(Columns.NgayTamung); }
			set { SetColumnValue(Columns.NgayTamung, value); }
		}
		  
		[XmlAttribute("KieuTamung")]
		[Bindable(true)]
		public byte? KieuTamung 
		{
			get { return GetColumnValue<byte?>(Columns.KieuTamung); }
			set { SetColumnValue(Columns.KieuTamung, value); }
		}
		  
		[XmlAttribute("MotaThem")]
		[Bindable(true)]
		public string MotaThem 
		{
			get { return GetColumnValue<string>(Columns.MotaThem); }
			set { SetColumnValue(Columns.MotaThem, value); }
		}
		  
		[XmlAttribute("IdTnv")]
		[Bindable(true)]
		public int? IdTnv 
		{
			get { return GetColumnValue<int?>(Columns.IdTnv); }
			set { SetColumnValue(Columns.IdTnv, value); }
		}
		  
		[XmlAttribute("NguoiSua")]
		[Bindable(true)]
		public string NguoiSua 
		{
			get { return GetColumnValue<string>(Columns.NguoiSua); }
			set { SetColumnValue(Columns.NguoiSua, value); }
		}
		  
		[XmlAttribute("NgaySua")]
		[Bindable(true)]
		public DateTime? NgaySua 
		{
			get { return GetColumnValue<DateTime?>(Columns.NgaySua); }
			set { SetColumnValue(Columns.NgaySua, value); }
		}
		  
		[XmlAttribute("NguoiTao")]
		[Bindable(true)]
		public string NguoiTao 
		{
			get { return GetColumnValue<string>(Columns.NguoiTao); }
			set { SetColumnValue(Columns.NguoiTao, value); }
		}
		  
		[XmlAttribute("NgayTao")]
		[Bindable(true)]
		public DateTime? NgayTao 
		{
			get { return GetColumnValue<DateTime?>(Columns.NgayTao); }
			set { SetColumnValue(Columns.NgayTao, value); }
		}
		  
		[XmlAttribute("IdKhoanoitru")]
		[Bindable(true)]
		public short? IdKhoanoitru 
		{
			get { return GetColumnValue<short?>(Columns.IdKhoanoitru); }
			set { SetColumnValue(Columns.IdKhoanoitru, value); }
		}
		  
		[XmlAttribute("IdBuonggiuong")]
		[Bindable(true)]
		public int? IdBuonggiuong 
		{
			get { return GetColumnValue<int?>(Columns.IdBuonggiuong); }
			set { SetColumnValue(Columns.IdBuonggiuong, value); }
		}
		  
		[XmlAttribute("IdBuong")]
		[Bindable(true)]
		public int? IdBuong 
		{
			get { return GetColumnValue<int?>(Columns.IdBuong); }
			set { SetColumnValue(Columns.IdBuong, value); }
		}
		  
		[XmlAttribute("IdGiuong")]
		[Bindable(true)]
		public int? IdGiuong 
		{
			get { return GetColumnValue<int?>(Columns.IdGiuong); }
			set { SetColumnValue(Columns.IdGiuong, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(long varIdBenhnhan,string varMaLuotkham,decimal? varSoTien,byte varTrangThai,DateTime? varNgayTamung,byte? varKieuTamung,string varMotaThem,int? varIdTnv,string varNguoiSua,DateTime? varNgaySua,string varNguoiTao,DateTime? varNgayTao,short? varIdKhoanoitru,int? varIdBuonggiuong,int? varIdBuong,int? varIdGiuong)
		{
			NoitruTamung item = new NoitruTamung();
			
			item.IdBenhnhan = varIdBenhnhan;
			
			item.MaLuotkham = varMaLuotkham;
			
			item.SoTien = varSoTien;
			
			item.TrangThai = varTrangThai;
			
			item.NgayTamung = varNgayTamung;
			
			item.KieuTamung = varKieuTamung;
			
			item.MotaThem = varMotaThem;
			
			item.IdTnv = varIdTnv;
			
			item.NguoiSua = varNguoiSua;
			
			item.NgaySua = varNgaySua;
			
			item.NguoiTao = varNguoiTao;
			
			item.NgayTao = varNgayTao;
			
			item.IdKhoanoitru = varIdKhoanoitru;
			
			item.IdBuonggiuong = varIdBuonggiuong;
			
			item.IdBuong = varIdBuong;
			
			item.IdGiuong = varIdGiuong;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varId,long varIdBenhnhan,string varMaLuotkham,decimal? varSoTien,byte varTrangThai,DateTime? varNgayTamung,byte? varKieuTamung,string varMotaThem,int? varIdTnv,string varNguoiSua,DateTime? varNgaySua,string varNguoiTao,DateTime? varNgayTao,short? varIdKhoanoitru,int? varIdBuonggiuong,int? varIdBuong,int? varIdGiuong)
		{
			NoitruTamung item = new NoitruTamung();
			
				item.Id = varId;
			
				item.IdBenhnhan = varIdBenhnhan;
			
				item.MaLuotkham = varMaLuotkham;
			
				item.SoTien = varSoTien;
			
				item.TrangThai = varTrangThai;
			
				item.NgayTamung = varNgayTamung;
			
				item.KieuTamung = varKieuTamung;
			
				item.MotaThem = varMotaThem;
			
				item.IdTnv = varIdTnv;
			
				item.NguoiSua = varNguoiSua;
			
				item.NgaySua = varNgaySua;
			
				item.NguoiTao = varNguoiTao;
			
				item.NgayTao = varNgayTao;
			
				item.IdKhoanoitru = varIdKhoanoitru;
			
				item.IdBuonggiuong = varIdBuonggiuong;
			
				item.IdBuong = varIdBuong;
			
				item.IdGiuong = varIdGiuong;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBenhnhanColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn MaLuotkhamColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SoTienColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TrangThaiColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NgayTamungColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn KieuTamungColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn MotaThemColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTnvColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn NguoiSuaColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NgaySuaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NguoiTaoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn NgayTaoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdKhoanoitruColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBuonggiuongColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn IdBuongColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn IdGiuongColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string IdBenhnhan = @"id_benhnhan";
			 public static string MaLuotkham = @"ma_luotkham";
			 public static string SoTien = @"so_tien";
			 public static string TrangThai = @"trang_thai";
			 public static string NgayTamung = @"ngay_tamung";
			 public static string KieuTamung = @"kieu_tamung";
			 public static string MotaThem = @"mota_them";
			 public static string IdTnv = @"id_tnv";
			 public static string NguoiSua = @"nguoi_sua";
			 public static string NgaySua = @"ngay_sua";
			 public static string NguoiTao = @"nguoi_tao";
			 public static string NgayTao = @"ngay_tao";
			 public static string IdKhoanoitru = @"id_khoanoitru";
			 public static string IdBuonggiuong = @"id_buonggiuong";
			 public static string IdBuong = @"id_buong";
			 public static string IdGiuong = @"id_giuong";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
