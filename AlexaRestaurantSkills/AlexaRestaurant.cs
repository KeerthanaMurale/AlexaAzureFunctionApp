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



//            // handle launchrequest
//            if (requestType == typeof(LaunchRequest))
//            {
//                var res = ResponseBuilder
//                  .Ask("Hello! Welcome to My Alex Restaurant. I can help you to order and to view the item description.",
//                       new Reprompt("what can i help you to order today"));

//res.Response.ShouldEndSession = false;
//                return res;
//            }


//return ResponseBuilder.TellWithCard("Oops, something went wrong here.Unable to find your search", "sorry", "Oops, something went wrong here.");
