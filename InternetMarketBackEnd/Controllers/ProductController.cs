﻿using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Controllers.Common;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseApiController
    {
        private readonly IProductAppService _appService;
        public ProductController(IProductAppService appService)
        {
            _appService = appService;
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            _appService.Add(new Product
            {
                Name = "пылесос",
                //Description = "Super pile",
                Price = 11
            });
            return Ok();
        }
        
        [HttpGet("/get/{id}")]
        public IActionResult Get(int id)
        {
            var data = _appService.GetById(id);
            return Ok(data);
        }
    }
}