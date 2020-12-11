using Alexa.NET.Request;
using Alexa.NET.Request.Type;

namespace AlexaRestaurantDomain
{
    public static class HandleUserInput
    {
        public static string SwitchInput(SkillRequest data)
        {
            var requestType = data.GetRequestType().Name;
            
            switch (requestType.ToString())
            {
                case "IntentRequest":
                    var intentRequest = data.Request as IntentRequest;

                    if (intentRequest.Intent.Name == "menuitemdescription")
                    {
                        var itemName = intentRequest.Intent?.Slots["item"]?.Value;

                        if (itemName == null || string.IsNullOrEmpty(itemName))
                        {
                            return "please provide a valid food item";
                        }
                        return $"Ok searching for {itemName}. {MenuItemDescription.ItemDescription(itemName)}";
                    }

                    return "Sorry!!!, I dont understand";

                case "LaunchRequest":
                    return "Hello! Welcome to My Alex Restaurant. I can help you to order and to view the item description. Try asking: Tell me the description for the menu Kulcha Tub";

                case "SessionEndedRequest":
                    return "Good bye !! see you!";

                default:
                    return "Sorry!!!, I dont understand";
            }
        }
    }
}
