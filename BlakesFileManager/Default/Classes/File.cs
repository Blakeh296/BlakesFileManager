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

class TextFiles : FileObj
{
    /*.doc, .docx, .log, .msg, .odt, .pages, .rtf, .tex, .txt, .wpd, .wps
     */

    File fileSort = new File();

    public Txt()
    {
        
    }

}

class DataFiles : File
{
    /* .CSV, .DAT, .GED, .KEY, .KEYCHAIN, .PPS, .PPT, .PPTX, .SDF, .TAR, .VCF, .XML*/
}

class Audio : FileObj
{
    /* .AIF , .IFF , .M3U , .M4A , .MID , .MP3 , .MPA , .WAV , .WMA */

    //Field
    private string _artist;
    private string _album;
    private int _year;
    private int _length;
    private int _bitRate;

    //Default Constructor
    public Audio()
    {
        _artist = "";
        _album = "";
        _year = 0;
        _length = 0;
        _bitRate = 0;
    }

    //Artist Property
    public string Artist
    {
        get { return _artist; }
        set { _artist = value; }
    }

    //Album Property
    public string Album
    {
        get { return _album; }
        set { _album = value; }
    }

    //Year Property
    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }

    //Length Property
    public int Length
    {
        get { return _length; }
        set { _length = value; }
    }

    //BitRate Property
    public int BitRate
    {
        get { return _bitRate; }
        set { _bitRate = value; }
    }
}

class Video : FileObj
{
    //Fields
    public int _length;
    public int _frameWidth;
    public int _frameHeight;
    public int _bitRate;
    public int _fps;

    //Default Constructor
    public Video()
    {
        _length = 0;
        _frameWidth = 0;
        _frameHeight = 0;
        _bitRate = 0;
        _fps = 0;
    }

    //Length Property
    public int Length
    {
        get { return _length; }
        set { _length = value; }
    }

    //FrameWidth Property
    public int FrameWidth
    {
        get { return _frameWidth; }
        set { _frameWidth = = value; ; }
    }

    //Frame Height Property
    public int FrameHeight
    {
        get { return _frameHeight; }
        set { _frameHeight = value; }
    }


    //BitRate Property
    public int BitRate
    {
        get { return _bitRate; }
        set { _bitRate = value; }
    }

    //FPS Property
    public int FramesPerSecond
    {
        get { return _fps; }
        set { _fps = value; }
    }

    /*
Video Files
.3G2	3GPP2 Multimedia File
.3GP	3GPP Multimedia File
.ASF	Advanced Systems Format File
.AVI	Audio Video Interleave File
.FLV	Animate Video File
.M4V	iTunes Video File
.MOV	Apple QuickTime Movie
.MP4	MPEG-4 Video File
.MPG	MPEG Video File
.RM	RealMedia File
.SRT	SubRip Subtitle File
.SWF	Shockwave Flash Movie
.VOB	DVD Video Object File
.WMV*/
}

class ThreeDImageFiles : File
{
        /*3D Image Files
        .3DM Rhino 3D Model
        .3DS	3D Studio Scene
        .MAX    3ds Max Scene File
        .OBJ Wavefront 3D Object File */
    }

class Image : FileObj
{
    //Field
    private int _width;
    private int _height;
    private int _horizontalResolution;
    private int _verticalResolution;

    //Default Constructor
    public Image()
    {
        _width = 0;
        _height = 0;
        _horizontalResolution = 0;
        _verticalResolution = 0;
    }

    //Width Property
    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    //Height Property
    public int Language
    {
        get { return _height; }
        set { _height = value; }
    }

    //HorizontalResolution Property
    public int HorizontalResolution
    {
        get { return _horizontalResolution; }
        set { _horizontalResolution = value; }
    }

    //VerticalResolution Property
    public int VerticalResolution
    {
        get { return _verticalResolution; }
        set { _verticalResolution = value; }
    }

         /*   Raster Image Files
        .BMP Bitmap Image File
        .DDS    DirectDraw Surface
        .GIF Graphical Interchange Format File
        .JPG JPEG Image
        .PNG Portable Network Graphic
        .PSD Adobe Photoshop Document
        .PSPIMAGE PaintShop Pro Image
        .TGA Targa Graphic
        .THM Thumbnail Image File
        .TIF Tagged Image File
        .TIFF Tagged Image File Format
        .YUV YUV Encoded Image File */
}

class VectorImageFiles : File
{
        /* Vector Image Files
        .AI	Adobe Illustrator File
        .EPS	Encapsulated PostScript File
        .PS	PostScript File
        .SVG	Scalable Vector Graphics File */
}

class PageLayoutFiles : File
{
         /* Page Layout Files
        .INDD	Adobe InDesign Document
        .PCT	Picture File
        .PDF	Portable Document Format File */
}

class SpreadSheet : FileObj
{
         /* Page Layout Files
        .INDD	Adobe InDesign Document
        .PCT	Picture File
        .PDF	Portable Document Format File */
}

class Database : FileObj
{
    private string _program;

    //Default Constructor
    public Database()
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

class GameFiles : File
{
            /* Game Files
        .B	Grand Theft Auto 3 Saved Game File
        .DEM	Video Game Demo File
        .GAM	Saved Game File
        .NES	Nintendo (NES) ROM File
        .ROM	N64 Game ROM File
        .SAV	Saved Game */
}

class WebFiles : File
{
                /* Web Files
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
            .XHTML	Extensible Hypertext Markup Language File */
}

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
            /* Font Files
        .FNT	Windows Font File
        .FON	Generic Font File
        .OTF	OpenType Font
        .TTF	TrueType Font */
}

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

class CompressedFiles : File
{
            /* Compressed Files
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
        .ZIPX	Extended Zip File */
}

class DiskImage : File
{
            /* Disk Image Files
        .BIN	Binary Disc Image
        .CUE	Cue Sheet File
        .DMG	Mac OS X Disk Image
        .ISO	Disc Image File
        .MDF	Media Disc Image File
        .TOAST	Toast Disc Image
        .VCD	Virtual CD */
}

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

class BackupFiles : File
{
            /* Backup Files
        .BAK	Backup File
        .TMP	Temporary File */
}