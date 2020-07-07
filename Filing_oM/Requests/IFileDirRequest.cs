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
using BH.oM.Data.Requests;

namespace BH.oM.Filing
{
    public interface IFileDirRequest : IRequest
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Files or directories included in this Directory will be pulled. You can also specify a string path.")]
        Directory Directory { get; set; }

        [Description("Sets the maximum number of files and/or directories to retrieve." +
          "\n-1 corresponds to no limit.")]
        int MaxItems { get; set; }

        [Description("If enabled, look also in subdirectories.")]
        bool IncludeSubdirectories { get; set; }

        [Description("If IncludeSubdirectories is true, this sets the maximum subdirectiory nesting level to look in." +
            "\nDefaults to -1 which corresponds to infinite.")]
        int MaxNesting { get; set; }
    }
}
