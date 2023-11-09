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
        internal bool isHappy;
        internal Cell(char texture, string tag = "", bool isHappy = false)
        {
            this.texture = texture;
            this.tag = tag;
            this.isHappy = isHappy;
        }
    }
}
