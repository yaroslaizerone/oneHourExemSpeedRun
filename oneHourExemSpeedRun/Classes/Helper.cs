using oneHourExemSpeedRun.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneHourExemSpeedRun.Classes
{
    public class Helper
    {
        public static TestRunEntities db = new TestRunEntities();

        public static TestRunEntities GetContext() {
            if (db == null)
            {
                db = new TestRunEntities();
            }
            return db;
        }
    }
}
