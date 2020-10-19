﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColossalGame.Models
{
    public class PlayerModel : GameObjectModel
    {
        public double YPos { get; set; }
        public double XPos { get; set; }
        public string Username { get; set; }
    }
}
