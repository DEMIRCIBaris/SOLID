using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    /// <summary>
    ///Bu konunun daha iyi anlaşılması için IOC yapısının araştırılması gereklidir.
    /// </summary>
    /// 


    //BAD EXAMPLE
    class BAD_DIExample
    {
        private Bad_DatabaseManager databaseManager = new Bad_DatabaseManager();

        public void Add()
        {
            databaseManager.Add();//Postgre Sql e eklemek yapacak.Bunu değiştirmek istediğimizde manager kodumuzu tekrar değiştirmemiz gerekecek
        }
    }

    class Bad_PostgreSql
    {
        public void Add()
        {
            Console.WriteLine("Postgre Sql'e eklendi");
        }
    }

    class Bad_DatabaseManager
    {
        private readonly Bad_PostgreSql postgreSql = new Bad_PostgreSql(); //Database sınıfımız postgre sql'e bağımlı oldu.Esnek bir kullanım söz konusu değil artık.

        public void Add()
        {
            postgreSql.Add();
        }
    }

    //GOOD EXAMPLE

    class GOOD_DIExample
    {
        private Good_DatabaseManager databaseManagerPostgre = new Good_DatabaseManager(new Good_PostgreSql());
        private Good_DatabaseManager databaseManagerMSSql = new Good_DatabaseManager(new Good_MsSql());

        public void AddPostreSql()
        {
            databaseManagerPostgre.Add();//Postgre Sql'e kaydedecek
        }

        public void AddMS_Sql()
        {
            databaseManagerMSSql.Add();//MS Sql'e kaydedecek
        }
    }

    class Good_DatabaseManager
    {
        private readonly IDatabase_Good_Example database_Good_Example;

        public Good_DatabaseManager(IDatabase_Good_Example database_Good_Example) //Yapıcı metodumuz sayesinde daha esnek bir yapımız var artık.Not:IOC yapısı ile new işlemi tek bir yerden yönetilebilir
        {
            this.database_Good_Example = database_Good_Example;
        }

        public void Add()
        {
            database_Good_Example.Add();
        }
    }

    interface IDatabase_Good_Example
    {
        void Add();
    }

    class Good_PostgreSql:IDatabase_Good_Example
    {
        public void Add()
        {
            Console.WriteLine("Postgre Sql'e eklendi");
        }
    }

    class Good_MsSql : IDatabase_Good_Example
    {
        public void Add()
        {
            Console.WriteLine("Microsoft Sql'e eklendi");
        }
    }

}
