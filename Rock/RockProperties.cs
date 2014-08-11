using PluginBridge;
using SharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Rock
{
    public class RockProperties : IBuilderProperties
    {
        public bool SupportsSpecularMap { get; set; }

        public bool SupportsNormalMap { get; set; }

        public int Seed { get; set; }

        public float MinFaceSize { get; set; }

        public float MaxFaceSize { get; set; }
                
        public float DimensionX { get; set; }
        public float DimensionY { get; set; }
        public float DimensionZ { get; set; }

        public float BaseFlatness { get; set; }

        public List<Color> Colors { get; set; }

        public RockProperties()
        {
            MinFaceSize = 0.5f;
            MaxFaceSize = 0.9f;
            DimensionX = 1;
            DimensionY = 1;
            DimensionZ = 2;
            BaseFlatness = 1;
            Colors = new List<Color>();
            Colors.Add(Color.Brown);
        }
    }
}
