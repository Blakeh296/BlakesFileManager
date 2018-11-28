using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Classes
{
    //Database "is a" relationship with FileObj 
    class DataBase : FileObj
    {
        private string _program;

        //Default Constructor
        public DataBase()
        {
            _program = "";
        }

        //Program Property
        public string AssociatedProgram
        {
            get { return _program; }
            set { _program = value; }
        }

        /* Database Files
       .ACCDB	Access 2007 Database File
       .DB	Database File
       .DBF	Database File
       .MDB	Microsoft Access Database
       .PDB	Program Database
       .SQL	Structured Query Language Data File */
    }
}
