using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERM.Common;
using ERM.Common.EventBus.Abstractions;
using ERM.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ERM.Services.SYS.Controllers
{
    [AllowAnonymous]
    public class SampleController : LVController
    {
        public SampleController(IConfiguration config, IEventBus eventBus) : base(config, eventBus) { }
    }
}