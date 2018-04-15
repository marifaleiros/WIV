using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WIV.Domain;
using System.Data.Entity.Migrations;

namespace WIV.Data
{
    public class WIVContextInitializer : CreateDatabaseIfNotExists<WIVContext>
    {
        protected override void Seed(WIVContext context)
        {
            if (context.WorkItems.Any())
                return;

            GenerateAndAddWorkItems(context);
            base.Seed(context);
        }

        private void GenerateAndAddWorkItems(WIVContext context)
        {
            var states = new[] { "New", "Executing", "Validating", "Done" };
            var workItems = new List<WorkItem>();
            for (int i = 1; i <= 1000; i++)
            {
                var wi = new WorkItem()
                {
                    Id = i,
                    AreaPath = $"AreaPath-{i}",
                    IterationPath = $"AreaPath-{i}",
                    State = states[i % states.Length],
                    Title = $"Work Item {i}"
                };
                workItems.Add(wi);
            }
            context.WorkItems.AddOrUpdate(workItems.ToArray());
            context.SaveChanges();
        }
    }
}
