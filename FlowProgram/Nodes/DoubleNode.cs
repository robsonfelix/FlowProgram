﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowProgram.Nodes
{
    class DoubleNode : FlowNode
    {
        public double Value;

        public DoubleNode()
        {
            Name = "Double";
        }
    }
}
