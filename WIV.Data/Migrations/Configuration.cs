namespace WIV.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WIV.Data.WIVContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
       
    }
}
