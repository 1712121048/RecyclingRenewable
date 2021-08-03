//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
//     author MEIAM
// </auto-generated>
//------------------------------------------------------------------------------

using Meiam.System.Common;
using Meiam.System.Model;
using System.Diagnostics;
using System.Linq;
using SqlSugar;
using System;

namespace Meiam.System.Core
{
        /// <summary>
        /// 数据库上下文
        /// </summary>
    public class DbContext
    {

        public SqlSugarClient Db;   //用来处理事务多表查询和复杂的操作

        public static SqlSugarClient Current
        {
            get
            {
                return new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = AppSettings.Configuration["DbConnection:ConnectionString"],
                    DbType = (DbType)Convert.ToInt32(AppSettings.Configuration["DbConnection:DbType"]),
                    IsAutoCloseConnection = false,
#pragma warning disable CS0618 // 类型或成员已过时
                    IsShardSameThread = true,
#pragma warning restore CS0618 // 类型或成员已过时
                    InitKeyType = InitKeyType.Attribute,
                    ConfigureExternalServices = new ConfigureExternalServices()
                    {
                        DataInfoCacheService = new RedisCache()
                    },
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true
                    }
                });
            }
        }

        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = AppSettings.Configuration["DbConnection:ConnectionString"],
                DbType = (DbType)Convert.ToInt32(AppSettings.Configuration["DbConnection:DbType"]),
                IsAutoCloseConnection = true,
#pragma warning disable CS0618 // 类型或成员已过时
                IsShardSameThread = true,
#pragma warning restore CS0618 // 类型或成员已过时
                InitKeyType = InitKeyType.Attribute,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    DataInfoCacheService = new RedisCache()
                },
                MoreSettings = new ConnMoreSettings()
                {
                    IsAutoRemoveDataCache = true
                }
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Debug.WriteLine(sql);
            };
        }

        public DbSet<T> DbTable<T>() where T : class, new()
        {
            return new DbSet<T>(Db);
        }

        public DbSet<Base_Company> BaseCompanyDb => new DbSet<Base_Company>(Db);
        public DbSet<Base_Equipment> BaseEquipmentDb => new DbSet<Base_Equipment>(Db);
        public DbSet<Base_Factory> BaseFactoryDb => new DbSet<Base_Factory>(Db);
        public DbSet<Base_ProductLine> BaseProductLineDb => new DbSet<Base_ProductLine>(Db);
        public DbSet<Base_ProductProcess> BaseProductProcessDb => new DbSet<Base_ProductProcess>(Db);
        public DbSet<Base_WorkShop> BaseWorkShopDb => new DbSet<Base_WorkShop>(Db);
        public DbSet<Sys_DataRelation> SysDataRelationDb => new DbSet<Sys_DataRelation>(Db);
        public DbSet<Sys_Logs> SysLogsDb => new DbSet<Sys_Logs>(Db);
        public DbSet<Sys_Menu> SysMenuDb => new DbSet<Sys_Menu>(Db);
        public DbSet<Sys_Online> SysOnlineDb => new DbSet<Sys_Online>(Db);
        public DbSet<Sys_Options> SysOptionsDb => new DbSet<Sys_Options>(Db);
        public DbSet<Sys_Power> SysPowerDb => new DbSet<Sys_Power>(Db);
        public DbSet<Sys_Role> SysRoleDb => new DbSet<Sys_Role>(Db);
        public DbSet<Sys_RolePower> SysRolePowerDb => new DbSet<Sys_RolePower>(Db);
        public DbSet<Sys_TasksQz> SysTasksQzDb => new DbSet<Sys_TasksQz>(Db);
        public DbSet<Sys_UserRelation> SysUserRelationDb => new DbSet<Sys_UserRelation>(Db);
        public DbSet<Sys_UserRole> SysUserRoleDb => new DbSet<Sys_UserRole>(Db);
        public DbSet<Sys_Users> SysUsersDb => new DbSet<Sys_Users>(Db);
        public DbSet<Test_Cap01> TestCap01Db => new DbSet<Test_Cap01>(Db);
        public DbSet<Test_Cap02> TestCap02Db => new DbSet<Test_Cap02>(Db);

    }

    /// <summary>
    /// 扩展ORM
    /// </summary>
    public class DbSet<T> : SimpleClient<T> where T : class, new()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {

        }
    }

}
