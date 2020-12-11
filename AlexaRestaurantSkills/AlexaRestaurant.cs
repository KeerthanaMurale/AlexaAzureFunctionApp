using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET;
using AlexaRestaurantDomain;
using System;

namespace AlexaRestaurantSkills
{
    public static class AlexaRestaurant
    {
        [FunctionName("AlexRestaurant")]
        public static async Task<SkillResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post","get",
            Route = "alexa/restaurant")]HttpRequest req)
        {

            var payload = await req.ReadAsStringAsync();
            var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(payload);

            var response = HandleUserInput.SwitchInput(skillRequest);
            ResponseBuilder.Ask("hi", new Reprompt("what can i help you to order today"));
            return ResponseBuilder.Ask(response, new Reprompt("what can i help you to order today"));

        }
    }
}
