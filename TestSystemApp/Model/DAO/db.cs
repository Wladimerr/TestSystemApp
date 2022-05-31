using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSystemApp.Model.DataSource;

namespace TestSystemApp.Model.DAO
{
    class db
    {
        private static TestSystemEntities testSystem;

        public static TestSystemEntities GetContext()
        {
            if (testSystem == null) testSystem = new TestSystemEntities();
            return testSystem;
        }
    }
}
