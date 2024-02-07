using homeSchool.core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.model.Response;
using Subsciber.CORE.interface_BL;
using Subscriber.Data.DTO;
using Subscriber.Data.Entities;

namespace Subscriber.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SubscriberCardController : Controller
    {
        ICardSubscriberService _css;
        public SubscriberCardController(ICardSubscriberService css)
        {
            _css = css;
        }
        [HttpPost]
        [Route("Subscriber")]
        public async Task<ActionResult<BaseResponseGeneral<bool>>> Register([FromBody]SubscriberDTO subscriberDTO)
        {
            BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();
            response = await _css.Register(subscriberDTO);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<BaseResponseGeneral<CardSubscriberResponse>>> GetSubscriberById(int id)
        {
            BaseResponseGeneral<CardSubscriberResponse> response = new BaseResponseGeneral<CardSubscriberResponse>();
            response = await _css.GetSubscriberById(id);
            if(response.Data==null)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<BaseResponseGeneral<int>>> Login(string email, string password)
        {
            BaseResponseGeneral<int> response = new BaseResponseGeneral<int>();
            response = await _css.Login(email, password);
            if (response.Success == false )
                return Unauthorized(response);
            return Ok(response);

        }
    }
}
