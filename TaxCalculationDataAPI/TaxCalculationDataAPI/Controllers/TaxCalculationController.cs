using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxCalculationDataAPI.Context;

namespace TaxCalculationDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationController : ControllerBase
    {
        private readonly TaxDbContext _context;
        public TaxCalculationController(TaxDbContext taxDbContext)
        {
            _context = taxDbContext;
        }

        [HttpGet]
        public ActionResult<List<Tax>> Get()
        {
            return Ok(_context.Taxes.ToList());
        }

        [HttpGet("{MunicipalityName}/{Date}/Tax")]
        public ActionResult<double> GetTax(string MunicipalityName, DateTime Date)
        {
            double taxRate = 0.0;
            if (!(string.IsNullOrEmpty(MunicipalityName) && string.IsNullOrEmpty(Date.ToString())))
            {

                var taxDetails = _context.Taxes.ToList();
                foreach (var item in taxDetails)
                {
                    if(item.MunicipalityName == MunicipalityName)
                    {
                        if (Date.ToString("yyyy.MM.dd") == "2016.01.01" || Date.ToString("yyyy.MM.dd") == "2016.12.25")
                        {
                            taxRate = 0.1;
                            break;
                        }
                        else if (Date.Year == 2016 && Date.Month == 05)
                        {
                            taxRate = 0.4;
                            break;
                        }
                        else
                        {
                            taxRate = 0.2;
                            break;
                        }
                    }
                }
            }
            if (taxRate > 0)
                return Ok(taxRate);
            else
                return Ok("MunicipalityName is not available");
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
