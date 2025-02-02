/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace BH.oM.Adapters.File
{
    [Description("A File. It can include the content of the File.")]
    public class File : BHoMObject, IFile, ILocatableResource, IContainableResource
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Full path of parent location of the File. You can also specify a string path.")]
        public virtual string Location { get; set; }

        [Description("Name of the file, INCLUDING Extension.")]
        public override string Name { get; set; }

        [Description("The content of the file.")]
        public virtual List<object> Content { get; set; } = new List<object>();

        public override string ToString()
        {
            return Path.Combine(this.Location ?? "", this.Name ?? "");
        }
    }
}


