﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netCore.Entities;

public class Post
{
    public int userId { get; set; }
    public int Id { get; set; }
    public string? title { get; set; }
    public string? body { get; set; }
}
