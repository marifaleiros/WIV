using System;
using System.Collections.Generic;
using WIV.Domain;

namespace WIV.Data.Repositories
{
    public class WorkItemRepository : IDisposable
    {
        private readonly WIVContext db = new WIVContext();

        public IEnumerable<WorkItem> GetAll()
        {
            return db.WorkItems;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
