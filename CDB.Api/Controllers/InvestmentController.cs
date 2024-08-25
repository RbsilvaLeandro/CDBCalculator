using CDB.Application.Dto;
using CDB.Application.Statment;
using CDB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CDB.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public InvestmentController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpGet("CalculateCdb")]
        public ActionResult<InvestmentResponse> CalculateCDB([FromQuery] InvestmentRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }
            try
            {
                var result = _calculationService.Calculate(request);

                if (result == null)
                {
                    return NotFound("Calculation result not found.");
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }
}