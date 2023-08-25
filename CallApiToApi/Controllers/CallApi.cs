using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace CallApiToApi.Controllers
{
    [Route("api/callApi")]
    [ApiController]
    public class CallApiController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("result")]
        public async Task<ActionResult> callapitoapi()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.zarbit.ir/api/Publicapi/");
                using (HttpResponseMessage response = await client.GetAsync("GetPairs"))
                {
                    var responsecontect = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(responsecontect);
                }
            }
        }

    }
}
