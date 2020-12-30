using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Interfaces
{

    public interface IExchangeRatesService
    {
        Task<Currencies> GetCurrencyCodes();

        Task<Currencies> GetLastestCurrencyCodes();


    }

}
