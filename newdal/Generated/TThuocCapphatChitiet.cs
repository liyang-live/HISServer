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
	/// Strongly-typed collection for the TThuocCapphatChitiet class.
	/// </summary>
    [Serializable]
	public partial class TThuocCapphatChitietCollection : ActiveList<TThuocCapphatChitiet, TThuocCapphatChitietCollection>
	{	   
		public TThuocCapphatChitietCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TThuocCapphatChitietCollection</returns>
		public TThuocCapphatChitietCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TThuocCapphatChitiet o = this[i];
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
	/// This is an ActiveRecord class which wraps the t_thuoc_capphat_chitiet table.
	/// </summary>
	[Serializable]
	public partial class TThuocCapphatChitiet : ActiveRecord<TThuocCapphatChitiet>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TThuocCapphatChitiet()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TThuocCapphatChitiet(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TThuocCapphatChitiet(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TThuocCapphatChitiet(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("t_thuoc_capphat_chitiet", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdCtiet = new TableSchema.TableColumn(schema);
				colvarIdCtiet.ColumnName = "id_ctiet";
				colvarIdCtiet.DataType = DbType.Int32;
				colvarIdCtiet.MaxLength = 0;
				colvarIdCtiet.AutoIncrement = true;
				colvarIdCtiet.IsNullable = false;
				colvarIdCtiet.IsPrimaryKey = true;
				colvarIdCtiet.IsForeignKey = false;
				colvarIdCtiet.IsReadOnly = false;
				colvarIdCtiet.DefaultSetting = @"";
				colvarIdCtiet.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCtiet);
				
				TableSchema.TableColumn colvarIdCapphat = new TableSchema.TableColumn(schema);
				colvarIdCapphat.ColumnName = "id_capphat";
				colvarIdCapphat.DataType = DbType.Int32;
				colvarIdCapphat.MaxLength = 0;
				colvarIdCapphat.AutoIncrement = false;
				colvarIdCapphat.IsNullable = false;
				colvarIdCapphat.IsPrimaryKey = false;
				colvarIdCapphat.IsForeignKey = false;
				colvarIdCapphat.IsReadOnly = false;
				colvarIdCapphat.DefaultSetting = @"";
				colvarIdCapphat.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdCapphat);
				
				TableSchema.TableColumn colvarIdThuoc = new TableSchema.TableColumn(schema);
				colvarIdThuoc.ColumnName = "id_thuoc";
				colvarIdThuoc.DataType = DbType.Int32;
				colvarIdThuoc.MaxLength = 0;
				colvarIdThuoc.AutoIncrement = false;
				colvarIdThuoc.IsNullable = false;
				colvarIdThuoc.IsPrimaryKey = false;
				colvarIdThuoc.IsForeignKey = false;
				colvarIdThuoc.IsReadOnly = false;
				colvarIdThuoc.DefaultSetting = @"";
				colvarIdThuoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdThuoc);
				
				TableSchema.TableColumn colvarSoLuong = new TableSchema.TableColumn(schema);
				colvarSoLuong.ColumnName = "so_luong";
				colvarSoLuong.DataType = DbType.Int32;
				colvarSoLuong.MaxLength = 0;
				colvarSoLuong.AutoIncrement = false;
				colvarSoLuong.IsNullable = false;
				colvarSoLuong.IsPrimaryKey = false;
				colvarSoLuong.IsForeignKey = false;
				colvarSoLuong.IsReadOnly = false;
				colvarSoLuong.DefaultSetting = @"";
				colvarSoLuong.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSoLuong);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("t_thuoc_capphat_chitiet",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdCtiet")]
		[Bindable(true)]
		public int IdCtiet 
		{
			get { return GetColumnValue<int>(Columns.IdCtiet); }
			set { SetColumnValue(Columns.IdCtiet, value); }
		}
		  
		[XmlAttribute("IdCapphat")]
		[Bindable(true)]
		public int IdCapphat 
		{
			get { return GetColumnValue<int>(Columns.IdCapphat); }
			set { SetColumnValue(Columns.IdCapphat, value); }
		}
		  
		[XmlAttribute("IdThuoc")]
		[Bindable(true)]
		public int IdThuoc 
		{
			get { return GetColumnValue<int>(Columns.IdThuoc); }
			set { SetColumnValue(Columns.IdThuoc, value); }
		}
		  
		[XmlAttribute("SoLuong")]
		[Bindable(true)]
		public int SoLuong 
		{
			get { return GetColumnValue<int>(Columns.SoLuong); }
			set { SetColumnValue(Columns.SoLuong, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdCapphat,int varIdThuoc,int varSoLuong)
		{
			TThuocCapphatChitiet item = new TThuocCapphatChitiet();
			
			item.IdCapphat = varIdCapphat;
			
			item.IdThuoc = varIdThuoc;
			
			item.SoLuong = varSoLuong;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdCtiet,int varIdCapphat,int varIdThuoc,int varSoLuong)
		{
			TThuocCapphatChitiet item = new TThuocCapphatChitiet();
			
				item.IdCtiet = varIdCtiet;
			
				item.IdCapphat = varIdCapphat;
			
				item.IdThuoc = varIdThuoc;
			
				item.SoLuong = varSoLuong;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdCtietColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCapphatColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdThuocColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SoLuongColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdCtiet = @"id_ctiet";
			 public static string IdCapphat = @"id_capphat";
			 public static string IdThuoc = @"id_thuoc";
			 public static string SoLuong = @"so_luong";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
