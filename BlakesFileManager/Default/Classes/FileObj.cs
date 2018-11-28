using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class FileObj
{
    // File Fields
    private string _name;
    private string _typeofFile;
    private string _path;
    private FileInfo _fileInfoObj;
    private bool _markForDelete;

    //Default Constructor
    public FileObj()
    {
        _name = "";
        _typeofFile = "";
        _path = "";
    }

    //Overload Constructor
    public FileObj(string FilePath)
    {
        _path = FilePath;
        _fileInfoObj = new FileInfo(FilePath);
    }

    //FilePathOnly Property Get the File Path Only
    public string FilePathOnly
    {
        //get the full file path
        get { return (_fileInfoObj != null) ? _fileInfoObj.DirectoryName : ""; }
    }

    //FileNameOnly property, get the File Name only
    public string FileNameOnly
    {
        //Get the physical name of the file only
        get { return (_fileInfoObj != null) ? _fileInfoObj.Name : ""; }

    }

    //Marked for Deletion Property
    public bool MarkedForDeletion
    {
        //Enables the file to be marked for deletion by the program
        get { return _markForDelete; }
        set { _markForDelete = value; }
    }

    // Size Property
    private long size
    {
        //Get the physical file size
        get { return (_fileInfoObj != null) ? _fileInfoObj.Length : 0; }
    }

    //File Exists Property, Boolean to decide if the file exists or not
    public bool FileExists
    {
        //Check if the file actually exists
        get { return File.Exists(_path); }
    }

    //File Location Property, Find the file location
    public string FileLocation
    {
        set
        {
            _path = value;

            //If the file path actually exists, populate the file info
            if (File.Exists(value))
            {
                _fileInfoObj = new FileInfo(value);
            }
        }
    }

    //ReadOnly Property, determine if a file is read only
    public bool ReadOnly
    {
        //Return a boolean based on the ReadOnly attribute
        get { return (_fileInfoObj != null) ? _fileInfoObj.Attributes.HasFlag(FileAttributes.ReadOnly) : false; }
    }

    //HiddenFile Property, Determine if a file is hidden based on the hidden attribute
    public bool Hidden
    {
        //Return a boolean based on the hidden attribute.
        get { return (_fileInfoObj != null) ? _fileInfoObj.Attributes.HasFlag(FileAttributes.Hidden) : false; }
    }

    //System File property, Determine if the file is a system file or not
    public bool SystemFile
    {
        //Return a boolean based on the system attribute
        get { return (_fileInfoObj != null) ? _fileInfoObj.Attributes.HasFlag(FileAttributes.System) : false; }
    }

    //CreateDate Property
    public DateTime CreateDate
    {
        //Time the file was physically created.
        get { return (_fileInfoObj != null) ? _fileInfoObj.CreationTime : DateTime.MinValue; }
    }

    //ModifiedDate Property
    public DateTime ModifiedDate
    {
        //Time the file was last modified
        get { return (_fileInfoObj != null) ? _fileInfoObj.LastWriteTime : DateTime.MinValue; }
    }
}
/*
class TextFiles : FileObj
{
    .doc, .docx, .log, .msg, .odt, .pages, .rtf, .tex, .txt, .wpd, .wps
     

    File fileSort = new File();

    public Txt()
    {
        
    }

}*/
/*
class DataFiles : File
{
     .CSV, .DAT, .GED, .KEY, .KEYCHAIN, .PPS, .PPT, .PPTX, .SDF, .TAR, .VCF, .XML
}*/

    /*
class Font : FileObj
{
    //Fields
    private string _language;

    //Default Constructor
    public string Language
    {
        get { return _language; }
        set { _language = value; }
    }
     Font Files
.FNT	Windows Font File
.FON	Generic Font File
.OTF	OpenType Font
.TTF	TrueType Font 
}*/

/*
class VectorImageFiles : File
{
         Vector Image Files
        .AI	Adobe Illustrator File
        .EPS	Encapsulated PostScript File
        .PS	PostScript File
        .SVG	Scalable Vector Graphics File 
} */
/*
class PageLayoutFiles : File
{
          Page Layout Files
        .INDD	Adobe InDesign Document
        .PCT	Picture File
        .PDF	Portable Document Format File 
}*/
/*
class SpreadSheet : FileObj
{
          Page Layout Files
        .INDD	Adobe InDesign Document
        .PCT	Picture File
        .PDF	Portable Document Format File 
}*/
/*
class GameFiles : File
{
             Game Files
        .B	Grand Theft Auto 3 Saved Game File
        .DEM	Video Game Demo File
        .GAM	Saved Game File
        .NES	Nintendo (NES) ROM File
        .ROM	N64 Game ROM File
        .SAV	Saved Game 
}*/
/*
class WebFiles : File
{
                Web Files
            .ASP	Active Server Page
            .ASPX	Active Server Page Extended File
            .CER	Internet Security Certificate
            .CFM	ColdFusion Markup File
            .CSR	Certificate Signing Request File
            .CSS	Cascading Style Sheet
            .DCR	Shockwave Media File
            .HTM	Hypertext Markup Language File
            .HTML	Hypertext Markup Language File
            .JS	JavaScript File
            .JSP	Java Server Page
            .PHP	PHP Source Code File
            .RSS	Rich Site Summary
            .XHTML	Extensible Hypertext Markup Language File 
}*/

    /*
class CompressedFiles : File
{
             Compressed Files
        .7Z	7-Zip Compressed File
        .CBR	Comic Book RAR Archive
        .DEB	Debian Software Package
        .GZ	Gnu Zipped Archive
        .PKG	Mac OS X Installer Package
        .RAR	WinRAR Compressed Archive
        .RPM	Red Hat Package Manager File
        .SITX	StuffIt X Archive
        .TAR.GZ	Compressed Tarball File
        .ZIP	Zipped File
        .ZIPX	Extended Zip File 
}*/
/*
class DiskImage : File
{
             Disk Image Files
        .BIN	Binary Disc Image
        .CUE	Cue Sheet File
        .DMG	Mac OS X Disk Image
        .ISO	Disc Image File
        .MDF	Media Disc Image File
        .TOAST	Toast Disc Image
        .VCD	Virtual CD 
} */

class DeveloperFiles : FileObj
{
    //Field
    private string _programmingLanguage;

    //Default Constructor
    public DeveloperFiles()
    {
        _programmingLanguage = "";
    }

    //ProgramingLanguage Property
    public string Language
    {
        get { return _programmingLanguage; }
        set { _programmingLanguage = value; }
    }

            /* Developer Files
        .C	C/C++ Source Code File
        .CLASS	Java Class File
        .CPP	C++ Source Code File
        .CS	C# Source Code File
        .DTD	Document Type Definition File
        .FLA	Adobe Animate Animation
        .H	C/C++/Objective-C Header File
        .JAVA	Java Source Code File
        .LUA	Lua Source File
        .M	Objective-C Implementation File
        .PL	Perl Script
        .PY	Python Script
        .SH	Bash Shell Script
        .SLN	Visual Studio Solution File
        .SWIFT	Swift Source Code File
        .VB	Visual Basic Project Item File
        .VCXPROJ	Visual C++ Project
        .XCODEPROJ	Xcode Project */
}
 /*
class BackupFiles : File
{
             Backup Files
        .BAK	Backup File
        .TMP	Temporary File 
} */