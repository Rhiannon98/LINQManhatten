using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LINQManhatten.Classes
{
    /// <summary>
    /// features contains geometry and properties
    /// </summary>
    public class Features
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }
}
