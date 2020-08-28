using BH.oM.Base;
using BH.oM.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace BH.oM.Adapters.Filing
{
    [Description("A File. It can include the content of the File.")]
    public class File : BHoMObject, IFileSystemContainer, IFile
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Full path of parent Directory of the File. You can also specify a string path.")]
        public virtual Directory ParentDirectory { get; set; }

        [Description("Name of the file, INCLUDING Extension.")]
        public new string Name { get; set; }

        [Description("Gets a value indicating whether a file exists.")]
        public virtual bool? Exists { get; set; } = null;

        [Description("Gets or sets a value that determines if the current file is read only.")]
        public virtual bool? IsReadOnly { get; set; } = null;

        [Description("Gets the size, in bytes, of the current file.")]
        public virtual int Size { get; set; } = 0;

        [Description("Attributes indicating if ReadOnly, Hidden, System File, etc.")]
        public virtual FileAttributes Attributes { get; set; }

        public virtual DateTime CreationTimeUtc { get; set; }
        public virtual DateTime ModifiedTimeUtc { get; set; }

        [Description("User owning the file, if any, or the user who created the File.")]
        public virtual string Owner { get; set; }

        [Description("The content of the file.")]
        public virtual List<object> Content { get; set; } = new List<object>();


        /***************************************************/
        /**** Implicit cast                             ****/
        /***************************************************/

        public static implicit operator File(string fileFullPath)
        {
            if (String.IsNullOrWhiteSpace(fileFullPath))
                return null;

            File bhomfile = new File();
            FileInfo fi = new System.IO.FileInfo(fileFullPath);

            bhomfile.Name = fi.Name;
            bhomfile.ParentDirectory = fi.Directory.FullName;

            return bhomfile;
        }

        /***************************************************/
        /**** ToString                                  ****/
        /***************************************************/

        public override string ToString()
        {
            return Path.Combine(this.ParentDirectory?.ToString() ?? "", this.Name ?? "");
        }
    }
}
