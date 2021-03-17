using Microsoft.AspNetCore.Mvc;
using WebShop.Web.Models;
using WebShop.Web.Services;

namespace WebShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {

        readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public void Post([FromBody] Transfer transfer)
        {
            _transferService.Transfer(transfer);
        }
    }
}
