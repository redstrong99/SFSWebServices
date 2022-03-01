using SFSWebServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFSWebServices.Services
{
    public interface ICreditReportService
    {
        Task<List<Credit>> GetData();
    }
}