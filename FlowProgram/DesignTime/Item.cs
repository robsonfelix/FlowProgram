﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowProgram.DesignTime
{
    class Item : VisibleEntity
    {
        public List<NodeContainer> Containers;

        public Item()
        {
            Containers = new List<NodeContainer>();
        }
    }
}
