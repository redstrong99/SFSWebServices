using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SFSWebServices.Models;
using SFSWebServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFSWebServices.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class ReportController : ControllerBase
    {
        private readonly ICreditReportService _creditReportService;

        public ReportController(ICreditReportService creditReportService)
        {
            _creditReportService = creditReportService;
        }

        [HttpGet]
        [Route("credit")]
        public async Task<IEnumerable<Credit>> CreditReport(int? applicationId, string source, string bureau)
        {
            var credits = await _creditReportService.GetData();
            var credit = credits.Where(c => 
                ( (applicationId > 0) ? c.ApplicationId == applicationId : true ) && 
                ( !String.IsNullOrEmpty(source) ? c.Source == source : true) && 
                ( !String.IsNullOrEmpty(bureau) ? c.Bureau == bureau : true));

            return credit;
        }
        //public async Task<IActionResult> CreditReport(int? applicationId, string source, string bureau)
        //{
        //    var credits = await _creditReportService.GetData();
        //    var credit = credits.Where(c =>
        //        ((applicationId > 0) ? c.ApplicationId == applicationId : true) &&
        //        (!String.IsNullOrEmpty(source) ? c.Source == source : true) &&
        //        (!String.IsNullOrEmpty(bureau) ? c.Bureau == bureau : true));

        //    if (!credit.Any())
        //        return NotFound();

        //    return Ok(credit);
        //}

        [HttpGet]
        [Route("dti")]
        public async Task<IActionResult> DebtToIncome(int applicationId, int annualIncome)
        {
            var source = "ABC";
            var bureau = "EFX";
            
            var credit = await CreditReport(applicationId, source, bureau);
            if (credit.Any())
            {
                var unsecuredTradelines = credit.FirstOrDefault().Tradelines.Where(t => t.Type == "UNSECURED").Count();
                var unsecuredDebtBalance = credit.FirstOrDefault().Tradelines.Where(t => t.Type == "UNSECURED").Sum(t => t.Balance);
                double dti = (double) (credit.FirstOrDefault().Tradelines.Where(t => t.IsMortgage == false).Sum(t => t.MonthlyPayment)) / annualIncome * 12;

                var response = new { UnsecuredTradelines = unsecuredTradelines, UnsecuredDebtBalance = unsecuredDebtBalance, DTI = dti};
                var result = JsonConvert.SerializeObject(response);

                return Ok(result);
            }

            return BadRequest();
        }
    }
}
