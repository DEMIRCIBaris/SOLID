using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
     class Bad_OCPExample_AddDatabase
    {
        private PostgreSqlContext PostgreSqlContext;
        private MSSqlContext MSSqlContext;

        public Bad_OCPExample_AddDatabase(PostgreSqlContext postgreSqlContext,MSSqlContext mSSqlContext)
        {
            this.PostgreSqlContext = postgreSqlContext;
            this.MSSqlContext = mSSqlContext;
        }

        public void Add(Databases databases,string name) //Her yeni database eklediğimizde sürekli add metodunu güncelleyeceğiz.Hem metot karmaşık bir hal alacak hem de esnek kullanım ihtimali düşecek
        {
            if (databases==Databases.MS_SQL)
            {
                MSSqlContext.Add(name);
            }
            else if (databases==Databases.PostgreSql)
            {
                PostgreSqlContext.Add(name);
            }
        }

    }

    class Good_OCPExample_AddDatabase
    {
        private IDatabase database;

        public Good_OCPExample_AddDatabase(IDatabase database)//Yapıcı metotta verdiğimiz database classımıza göre ekleme işlemi yapacak.Artık Add metodumuzu sürekli güncellememiz gerekmeyecek
        {
            this.database = database;
        }

        public void Add(string name)
        {
            database.Add(name);
        }

    }

    public class PostgreSqlContext:IDatabase
    {
        public void Add(string name)
        {
            Console.WriteLine($"{name} Postgre SQL'e kaydedildi");
        }
    }

    public class MSSqlContext:IDatabase
    {
        public void Add(string name)
        {
            Console.WriteLine($"{name} Microsoft SQL'e kaydedildi");
        }
    }

    interface IDatabase
    {
        void Add(string name);
    }

    enum Databases
    {
        PostgreSql,
        MS_SQL
    }

}
