using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Plugins.DataStore.SQLLite
{
    internal class Constants
    {
        public const string DatabaseFileName = "ContactsSQLLite.db3";

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
