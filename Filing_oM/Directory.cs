using BH.oM.Base;
using BH.oM.Humans;
using System.IO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace BH.oM.Filing
{
    [Description("A Directory. It can include the content of the Directory.")]
    public class Directory : IContent 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Full path of parent Directory. You can also specify a string path.")]
        public virtual Info ParentDirectory { get; set; }

        [Description("Name of the directory.")]
        public virtual string Name { get; set; }

        [Description("Gets a value indicating whether a file exists.")]
        public virtual bool Exists { get; set; } = false;

        [Description("Attributes indicating if ReadOnly, Hidden, System File, etc.")]
        public virtual FileAttributes Attributes { get; set; }

        public virtual DateTime CreationTime { get; set; }
        public virtual DateTime CreationTimeUtc { get; set; }
        public virtual DateTime LastAccessTime { get; set; }
        public virtual DateTime LastAccessTimeUtc { get; set; }
        public virtual DateTime LastWriteTime { get; set; }
        public virtual DateTime LastWriteTimeUtc { get; set; }

        [Description("User owning the file, if any, or the user who created the object File.")]
        public virtual Human Owner { get; set; }

        [Description("The content of the file.")]
        public virtual List<object> Content { get; set; }


        /***************************************************/
        /**** Explicit cast                             ****/
        /***************************************************/

        public static explicit operator Directory(Info bi)
        {
            return bi != null ? new Directory()
            {
                ParentDirectory = bi.ParentDirectory,

                Name = bi.Name,

                Exists = bi.Exists,

                Attributes = bi.Attributes,
                CreationTime = bi.CreationTime,
                CreationTimeUtc = bi.CreationTimeUtc,
                LastAccessTime = bi.LastAccessTime,
                LastAccessTimeUtc = bi.LastAccessTimeUtc,
                LastWriteTime = bi.LastWriteTime,
                LastWriteTimeUtc = bi.LastWriteTimeUtc,
            } : null;
        }

        public static explicit operator Directory(System.IO.DirectoryInfo di)
        {
            return di != null ? new Directory()
            {
                ParentDirectory = (Info)System.IO.Directory.GetParent(di.FullName),

                Name = di.Name,

                Exists = di.Exists,

                Attributes = di.Attributes,
                CreationTime = di.CreationTime,
                CreationTimeUtc = di.CreationTimeUtc,
                LastAccessTime = di.LastAccessTime,
                LastAccessTimeUtc = di.LastAccessTimeUtc,
                LastWriteTime = di.LastWriteTime,
                LastWriteTimeUtc = di.LastWriteTimeUtc,
            } : null;
        }

        /***************************************************/
        /**** Implicit cast                             ****/
        /***************************************************/

        public static implicit operator Directory(string fileFullPath)
        {
            if (!String.IsNullOrWhiteSpace(fileFullPath))
                return (Directory)new System.IO.DirectoryInfo(fileFullPath);
            else
                return null;
        }
    }
}
