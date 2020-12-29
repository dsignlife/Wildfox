using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reactfox.Interfaces;
using reactfox.Models;

namespace reactfox.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesServiceController : ControllerBase
    {
        private readonly IExchangeRatesService _exchangeRatesService;
        private readonly ILogger<ExchangeRatesServiceController> _logger;

        public ExchangeRatesServiceController(ILogger<ExchangeRatesServiceController> logger, IExchangeRatesService exchangeRatesService)
        {
            _logger = logger;
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet]
        public Task<Currencies> GetLastest()
        {
            return _exchangeRatesService.GetLastestCurrencyCodes();
        }
    }
}
