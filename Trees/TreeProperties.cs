using PluginBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees
{
    public class TreeProperties : IBuilderProperties
    {
        public bool SupportsSpecularMap { get; set; }

        public bool SupportsNormalMap { get; set; }
    }
}
