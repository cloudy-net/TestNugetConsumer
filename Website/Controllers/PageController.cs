﻿using Microsoft.AspNetCore.Mvc;
using Cloudy.CMS;
using Cloudy.CMS.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloudy.CMS.ContentSupport;
using Website.Models;

namespace Website.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index([FromContentRoute] Page page)
        {
            return View(page);
        }
    }
}
