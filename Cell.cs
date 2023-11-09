using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTaskAI
{
    internal class Cell
    {
        internal string tag;
        internal char texture;
        internal ConsoleColor color;
        internal Cell(char texture, ConsoleColor color, string tag = "")
        {
            this.texture = texture;
            this.tag = tag;
            this.color = color;
        }
    }
}
