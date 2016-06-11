﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAG.Model
{
    public class TickerQuote
    {
        [Key]
        public long Id { get; set; }
        public string Symbol { get; set; }
        public decimal Last { get; set; }
        public decimal Change { get; set; }

    }
}
