﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
