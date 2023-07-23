using System.Data.Entity;

namespace Domain
{
    public class ShareGlobalAxas
    {
        public static void AutomaticMigration()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }
    }
}
