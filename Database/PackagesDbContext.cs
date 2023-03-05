using DeliveryManager.App.Model;
using SQLite;

namespace DeliveryManager.App.Database
{
    public class PackagesDbContext : SQLiteConnection
    {
        public PackagesDbContext(string databasePath) : base(databasePath)
        {
            CreateTable<Package>();
        }

        public TableQuery<Package> Packages => Table<Package>();
    }

}
