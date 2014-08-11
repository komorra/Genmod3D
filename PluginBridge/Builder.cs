using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginBridge
{
    public abstract class Builder<T> : BuilderBase where T : IBuilderProperties
    {        

        public IBuilderProperties Properties { get; private set; }

        public Builder()
        {
            Properties = Activator.CreateInstance<T>();
        }
    }
}
