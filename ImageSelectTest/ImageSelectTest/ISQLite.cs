using System;
using System.Collections.Generic;
using System.Text;

namespace ImageSelectTest
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
