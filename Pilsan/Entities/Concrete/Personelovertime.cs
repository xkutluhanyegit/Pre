﻿using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Personelovertime
    {
        public int Id { get; set; }
        public string? Sicilno { get; set; }
        public string? Overtimeday { get; set; }
        public string? Createdat { get; set; }
        public int? WeekOfYear { get; set; }
        public bool? Relaesed { get; set; }
        public int? Overtimeid { get; set; }
    }
}
