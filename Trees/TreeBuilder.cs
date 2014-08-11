using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginBridge;

namespace Trees
{
    public class TreeBuilder : Builder<TreeProperties>
    {
        public override string BuilderPath
        {
            get { return "Nature/Trees"; }
        }
    }
}
