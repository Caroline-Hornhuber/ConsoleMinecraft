using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private World _used;

        public Player (World used )
        {
            _used = used;
        }

        public void Spwanplayer()
        {
            _used.SpawnPlayer(this);
            _used.cursor.Item1 = this.X;
            _used.cursor.Item2 = this.Y;
        }

    }
}
