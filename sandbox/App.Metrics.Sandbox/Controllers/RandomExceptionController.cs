﻿using System;
using System.Threading.Tasks;
using App.Metrics.Sandbox.JustForTesting;
using Microsoft.AspNetCore.Mvc;

namespace App.Metrics.Sandbox.Controllers
{
    [Route("api/[controller]")]
    public class RandomExceptionController : Controller
    {
        private readonly IMetrics _metrics;
        private readonly RandomValuesForTesting _randomValuesForTesting;

        public RandomExceptionController(IMetrics metrics, RandomValuesForTesting randomValuesForTesting)
        {
            _randomValuesForTesting = randomValuesForTesting;
            _metrics = metrics ?? throw new ArgumentNullException(nameof(metrics));
        }

        [HttpGet]
        public void Get()
        {
            throw _randomValuesForTesting.NextException();
        }
    }
}