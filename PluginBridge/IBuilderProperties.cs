using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginBridge
{
    public interface IBuilderProperties
    {
        bool SupportsSpecularMap { get; set; }
        bool SupportsNormalMap { get; set; }
    }
}
