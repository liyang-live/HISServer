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
	/// Strongly-typed collection for the QheThuoctuongduong class.
	/// </summary>
    [Serializable]
	public partial class QheThuoctuongduongCollection : ActiveList<QheThuoctuongduong, QheThuoctuongduongCollection>
	{	   
		public QheThuoctuongduongCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>QheThuoctuongduongCollection</returns>
		public QheThuoctuongduongCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                QheThuoctuongduong o = this[i];
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
	/// This is an ActiveRecord class which wraps the qhe_thuoctuongduong table.
	/// </summary>
	[Serializable]
	public partial class QheThuoctuongduong : ActiveRecord<QheThuoctuongduong>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public QheThuoctuongduong()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public QheThuoctuongduong(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public QheThuoctuongduong(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public QheThuoctuongduong(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("qhe_thuoctuongduong", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdThuoc = new TableSchema.TableColumn(schema);
				colvarIdThuoc.ColumnName = "id_thuoc";
				colvarIdThuoc.DataType = DbType.Int32;
				colvarIdThuoc.MaxLength = 0;
				colvarIdThuoc.AutoIncrement = false;
				colvarIdThuoc.IsNullable = false;
				colvarIdThuoc.IsPrimaryKey = true;
				colvarIdThuoc.IsForeignKey = false;
				colvarIdThuoc.IsReadOnly = false;
				colvarIdThuoc.DefaultSetting = @"";
				colvarIdThuoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdThuoc);
				
				TableSchema.TableColumn colvarIdThuoctuongduong = new TableSchema.TableColumn(schema);
				colvarIdThuoctuongduong.ColumnName = "id_thuoctuongduong";
				colvarIdThuoctuongduong.DataType = DbType.Int32;
				colvarIdThuoctuongduong.MaxLength = 0;
				colvarIdThuoctuongduong.AutoIncrement = false;
				colvarIdThuoctuongduong.IsNullable = false;
				colvarIdThuoctuongduong.IsPrimaryKey = true;
				colvarIdThuoctuongduong.IsForeignKey = false;
				colvarIdThuoctuongduong.IsReadOnly = false;
				colvarIdThuoctuongduong.DefaultSetting = @"";
				colvarIdThuoctuongduong.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdThuoctuongduong);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("qhe_thuoctuongduong",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdThuoc")]
		[Bindable(true)]
		public int IdThuoc 
		{
			get { return GetColumnValue<int>(Columns.IdThuoc); }
			set { SetColumnValue(Columns.IdThuoc, value); }
		}
		  
		[XmlAttribute("IdThuoctuongduong")]
		[Bindable(true)]
		public int IdThuoctuongduong 
		{
			get { return GetColumnValue<int>(Columns.IdThuoctuongduong); }
			set { SetColumnValue(Columns.IdThuoctuongduong, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdThuoc,int varIdThuoctuongduong)
		{
			QheThuoctuongduong item = new QheThuoctuongduong();
			
			item.IdThuoc = varIdThuoc;
			
			item.IdThuoctuongduong = varIdThuoctuongduong;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdThuoc,int varIdThuoctuongduong)
		{
			QheThuoctuongduong item = new QheThuoctuongduong();
			
				item.IdThuoc = varIdThuoc;
			
				item.IdThuoctuongduong = varIdThuoctuongduong;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdThuocColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdThuoctuongduongColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdThuoc = @"id_thuoc";
			 public static string IdThuoctuongduong = @"id_thuoctuongduong";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
