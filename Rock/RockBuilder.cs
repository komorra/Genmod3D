using PluginBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rock
{
    public class RockBuilder : Builder<RockProperties>
    {
        public override string BuilderPath
        {
            get { return "Nature/Rock"; }
        }
    }
}
