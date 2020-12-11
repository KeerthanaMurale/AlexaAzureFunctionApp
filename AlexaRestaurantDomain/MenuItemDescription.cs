namespace AlexaRestaurantDomain
{
    public static class MenuItemDescription
    {
        public static string ItemDescription(string menuItem)
        {
            switch (menuItem.ToLower())
            {
                case "kulcha tub":
                    return "A north Indian speciality, Kulcha is a popular soft leavened bread that melts in your mouth";
                case "dal makhani bowl":
                    return "Authentic Dal Makhni, creamy & rich at its core, will fill you with a feeling of contentment and delight.";
                case "chatpate chole bowl":
                    return "Chole cooked in thick masala gravy gives the perfect spicy smack on the tongue!.";
                case "chocolate truffle pastry":
                    return "Our simple yet elegant, Chocolate Truffle Pastry cake is the perfect feast for the season. Layers of soft chocolate sponge" +
                        " and dense but silky-smooth chocolate ganache makes this cake a celebration and it comes in a pack of One (Eggless).";
                default:
                    return "Dish is not currently available";

            }
        }

        public static string DishOfTheDay()
        {
            return "Chatpate Chole Bowl is today's special dish in alex restaurant. Would you like to order? ";
        }
    }
}
