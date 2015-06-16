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
	/// Strongly-typed collection for the SysSystemParameter class.
	/// </summary>
    [Serializable]
	public partial class SysSystemParameterCollection : ActiveList<SysSystemParameter, SysSystemParameterCollection>
	{	   
		public SysSystemParameterCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysSystemParameterCollection</returns>
		public SysSystemParameterCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysSystemParameter o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_SystemParameters table.
	/// </summary>
	[Serializable]
	public partial class SysSystemParameter : ActiveRecord<SysSystemParameter>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysSystemParameter()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysSystemParameter(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysSystemParameter(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysSystemParameter(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_SystemParameters", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
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
				
				TableSchema.TableColumn colvarFpSBranchID = new TableSchema.TableColumn(schema);
				colvarFpSBranchID.ColumnName = "FP_sBranchID";
				colvarFpSBranchID.DataType = DbType.String;
				colvarFpSBranchID.MaxLength = 10;
				colvarFpSBranchID.AutoIncrement = false;
				colvarFpSBranchID.IsNullable = false;
				colvarFpSBranchID.IsPrimaryKey = false;
				colvarFpSBranchID.IsForeignKey = false;
				colvarFpSBranchID.IsReadOnly = false;
				colvarFpSBranchID.DefaultSetting = @"";
				colvarFpSBranchID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFpSBranchID);
				
				TableSchema.TableColumn colvarSName = new TableSchema.TableColumn(schema);
				colvarSName.ColumnName = "sName";
				colvarSName.DataType = DbType.String;
				colvarSName.MaxLength = 100;
				colvarSName.AutoIncrement = false;
				colvarSName.IsNullable = false;
				colvarSName.IsPrimaryKey = false;
				colvarSName.IsForeignKey = false;
				colvarSName.IsReadOnly = false;
				colvarSName.DefaultSetting = @"";
				colvarSName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSName);
				
				TableSchema.TableColumn colvarSDataType = new TableSchema.TableColumn(schema);
				colvarSDataType.ColumnName = "sDataType";
				colvarSDataType.DataType = DbType.String;
				colvarSDataType.MaxLength = 100;
				colvarSDataType.AutoIncrement = false;
				colvarSDataType.IsNullable = false;
				colvarSDataType.IsPrimaryKey = false;
				colvarSDataType.IsForeignKey = false;
				colvarSDataType.IsReadOnly = false;
				colvarSDataType.DefaultSetting = @"";
				colvarSDataType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSDataType);
				
				TableSchema.TableColumn colvarSValue = new TableSchema.TableColumn(schema);
				colvarSValue.ColumnName = "sValue";
				colvarSValue.DataType = DbType.String;
				colvarSValue.MaxLength = 100;
				colvarSValue.AutoIncrement = false;
				colvarSValue.IsNullable = false;
				colvarSValue.IsPrimaryKey = false;
				colvarSValue.IsForeignKey = false;
				colvarSValue.IsReadOnly = false;
				colvarSValue.DefaultSetting = @"";
				colvarSValue.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSValue);
				
				TableSchema.TableColumn colvarIMonth = new TableSchema.TableColumn(schema);
				colvarIMonth.ColumnName = "iMonth";
				colvarIMonth.DataType = DbType.Int32;
				colvarIMonth.MaxLength = 0;
				colvarIMonth.AutoIncrement = false;
				colvarIMonth.IsNullable = false;
				colvarIMonth.IsPrimaryKey = false;
				colvarIMonth.IsForeignKey = false;
				colvarIMonth.IsReadOnly = false;
				colvarIMonth.DefaultSetting = @"";
				colvarIMonth.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIMonth);
				
				TableSchema.TableColumn colvarIYear = new TableSchema.TableColumn(schema);
				colvarIYear.ColumnName = "iYear";
				colvarIYear.DataType = DbType.Int32;
				colvarIYear.MaxLength = 0;
				colvarIYear.AutoIncrement = false;
				colvarIYear.IsNullable = false;
				colvarIYear.IsPrimaryKey = false;
				colvarIYear.IsForeignKey = false;
				colvarIYear.IsReadOnly = false;
				colvarIYear.DefaultSetting = @"";
				colvarIYear.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIYear);
				
				TableSchema.TableColumn colvarIStatus = new TableSchema.TableColumn(schema);
				colvarIStatus.ColumnName = "iStatus";
				colvarIStatus.DataType = DbType.Int16;
				colvarIStatus.MaxLength = 0;
				colvarIStatus.AutoIncrement = false;
				colvarIStatus.IsNullable = false;
				colvarIStatus.IsPrimaryKey = false;
				colvarIStatus.IsForeignKey = false;
				colvarIStatus.IsReadOnly = false;
				colvarIStatus.DefaultSetting = @"";
				colvarIStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIStatus);
				
				TableSchema.TableColumn colvarSDesc = new TableSchema.TableColumn(schema);
				colvarSDesc.ColumnName = "sDesc";
				colvarSDesc.DataType = DbType.String;
				colvarSDesc.MaxLength = 255;
				colvarSDesc.AutoIncrement = false;
				colvarSDesc.IsNullable = true;
				colvarSDesc.IsPrimaryKey = false;
				colvarSDesc.IsForeignKey = false;
				colvarSDesc.IsReadOnly = false;
				colvarSDesc.DefaultSetting = @"";
				colvarSDesc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSDesc);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("Sys_SystemParameters",schema);
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
		  
		[XmlAttribute("FpSBranchID")]
		[Bindable(true)]
		public string FpSBranchID 
		{
			get { return GetColumnValue<string>(Columns.FpSBranchID); }
			set { SetColumnValue(Columns.FpSBranchID, value); }
		}
		  
		[XmlAttribute("SName")]
		[Bindable(true)]
		public string SName 
		{
			get { return GetColumnValue<string>(Columns.SName); }
			set { SetColumnValue(Columns.SName, value); }
		}
		  
		[XmlAttribute("SDataType")]
		[Bindable(true)]
		public string SDataType 
		{
			get { return GetColumnValue<string>(Columns.SDataType); }
			set { SetColumnValue(Columns.SDataType, value); }
		}
		  
		[XmlAttribute("SValue")]
		[Bindable(true)]
		public string SValue 
		{
			get { return GetColumnValue<string>(Columns.SValue); }
			set { SetColumnValue(Columns.SValue, value); }
		}
		  
		[XmlAttribute("IMonth")]
		[Bindable(true)]
		public int IMonth 
		{
			get { return GetColumnValue<int>(Columns.IMonth); }
			set { SetColumnValue(Columns.IMonth, value); }
		}
		  
		[XmlAttribute("IYear")]
		[Bindable(true)]
		public int IYear 
		{
			get { return GetColumnValue<int>(Columns.IYear); }
			set { SetColumnValue(Columns.IYear, value); }
		}
		  
		[XmlAttribute("IStatus")]
		[Bindable(true)]
		public short IStatus 
		{
			get { return GetColumnValue<short>(Columns.IStatus); }
			set { SetColumnValue(Columns.IStatus, value); }
		}
		  
		[XmlAttribute("SDesc")]
		[Bindable(true)]
		public string SDesc 
		{
			get { return GetColumnValue<string>(Columns.SDesc); }
			set { SetColumnValue(Columns.SDesc, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varFpSBranchID,string varSName,string varSDataType,string varSValue,int varIMonth,int varIYear,short varIStatus,string varSDesc)
		{
			SysSystemParameter item = new SysSystemParameter();
			
			item.FpSBranchID = varFpSBranchID;
			
			item.SName = varSName;
			
			item.SDataType = varSDataType;
			
			item.SValue = varSValue;
			
			item.IMonth = varIMonth;
			
			item.IYear = varIYear;
			
			item.IStatus = varIStatus;
			
			item.SDesc = varSDesc;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varId,string varFpSBranchID,string varSName,string varSDataType,string varSValue,int varIMonth,int varIYear,short varIStatus,string varSDesc)
		{
			SysSystemParameter item = new SysSystemParameter();
			
				item.Id = varId;
			
				item.FpSBranchID = varFpSBranchID;
			
				item.SName = varSName;
			
				item.SDataType = varSDataType;
			
				item.SValue = varSValue;
			
				item.IMonth = varIMonth;
			
				item.IYear = varIYear;
			
				item.IStatus = varIStatus;
			
				item.SDesc = varSDesc;
			
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
        
        
        
        public static TableSchema.TableColumn FpSBranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SDataTypeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SValueColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IMonthColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IYearColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IStatusColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn SDescColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string FpSBranchID = @"FP_sBranchID";
			 public static string SName = @"sName";
			 public static string SDataType = @"sDataType";
			 public static string SValue = @"sValue";
			 public static string IMonth = @"iMonth";
			 public static string IYear = @"iYear";
			 public static string IStatus = @"iStatus";
			 public static string SDesc = @"sDesc";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
