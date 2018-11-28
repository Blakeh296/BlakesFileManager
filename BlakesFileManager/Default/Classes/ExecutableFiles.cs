using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Classes
{
    //ExecutableFiles "is a" is a relationship with FileObj
    class ExecutableFiles : FileObj
    {
        //Field
        private string _operatingSystem;

        //Default Constructor
        public string OperatingSystem
        {
            get { return _operatingSystem; }
            set { _operatingSystem = value; }
        }

        /* Executable Files
       .APK	Android Package File
       .APP	Mac OS X Application
       .BAT	DOS Batch File
       .CGI	Common Gateway Interface Script
       .COM	DOS Command File
       .EXE	Windows Executable File
       .GADGET	Windows Gadget
       .JAR	Java Archive File
       .WSF	Windows Script File */
    }
}
