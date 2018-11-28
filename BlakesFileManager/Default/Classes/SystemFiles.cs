using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Classes
{
    //SystemFiles "is a" with FileObj
    class SystemFiles : FileObj
    {
        //Field
        public string _fileType;

        //Default Constructor
        public SystemFiles()
        {
            _fileType = "";
        }

        //FileType Property
        public string FileTypee
        {
            get { return _fileType; }
            set { _fileType = value; }
        }


        /*System Files
    .CAB	Windows Cabinet File
    .CPL	Windows Control Panel Item
    .CUR	Windows Cursor
    .DESKTHEMEPACK	Windows 8 Desktop Theme Pack File
    .DLL	Dynamic Link Library
    .DMP	Windows Memory Dump
    .DRV	Device Driver
    .ICNS	Mac OS X Icon Resource File
    .ICO	Icon File
    .LNK	Windows File Shortcut
    .SYS	Windows System File  */
    }
}
