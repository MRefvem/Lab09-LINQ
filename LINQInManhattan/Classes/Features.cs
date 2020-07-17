﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LINQInManhattan.Classes
{ 
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }

    }

    public class Properties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }

    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }

    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }

    }


}
