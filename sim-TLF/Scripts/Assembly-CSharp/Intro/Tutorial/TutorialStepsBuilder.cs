using System.Collections.Generic;
using Services.Missions;

namespace Intro.Tutorial
{
	public static class TutorialStepsBuilder
	{
		public static List<MissionDefinition> Build(MissionFactory factory)
		{
			List<MissionDefinition> steps = new List<MissionDefinition>();
			Add("Find Table In The House", "You must build a table to put the computer on it so I can sync with your system.", "findTable", "Find Table");
			Add("Open Table Box", "Good! Now Open The Box", "openTableBox", "Open Box");
			Add("Pick Table Base Parts (Outlined)", "Look, you must pick up the base parts to start building it", "pickBaseParts", "Pick Base Parts");
			Add("Press On The Ready Blueprint", "The blueprint changed. Now switch to the interaction menu (Tab) and activate it", "pressBlueprint", "Press Ready Blueprint");
			Add("Build Table", "Find a suitable place for your table and build it (E)", "buildTable", "Build Table");
			Add("Place Table Top", "Well done! Now you need to put the last part on the table. Hold LMB to drag it and place it in the corresponding position", "placeTableTop", "Place Table Top");
			Add("Find Screwdriver In Garage", "Okay, somewhere here must be the screwdriver...", "findScrewdriver", "Find Screwdriver In Garage");
			Add("Tighten The Table Top", "Use your screwdriver to tighten the table top. But... don't overtighten it!", "tightenTableTop", "Tighten Table Top");
			Add("Build Computer", "Now it's time to build a computer on that table", "buildComputer", "Build Computer");
			Add("Use Computer", "This thing will keep you connected to the world as long as you have internet access...", "useComputer", "Use Computer");
			Add("Type \"help\" In Commander Prompt", "Once you finish setting up your PC, check the available commands in Commander", "checkCommands", "Type \"help\" In Commander Prompt");
			Add("Open ZeroPing App", "You can use ZeroPing to communicate with others", "checkMessages", "Open ZeroPing App");
			Add("Open sell.com Website Using C-Rust Browser", "I've found one useful site in your IP area. Check it out: sell.com", "openSellCom", "Open sell.com Using C-Rust");
			Add("Buy Yourself A Beer", "Here you can find lots of different stuff", "buyBeer", "Buy Beer");
			Add("Press Order Button In Cart Menu", "After you finish shopping, press the cart button to check your order", "orderCart", "Press Order Button");
			Add("Generate Delivery ID - Press Set Delivery Button", "In order to order an order you need to generate an Order ID. Press the button", "generateDeliveryId", "Press Set Delivery Button");
			Add("Open Delivery Website - Blue Hyperlink", "Open Delivery Website", "openDeliverySite", "Open Delivery Site");
			Add("Create New Order - Order Delivery Button", "Here you can create your airdrop order. Press the button", "createOrder", "Create Order");
			Add("Type Order ID from sell.com", "Remember your Order ID: type it here. And if it matches you will get a new order", "typeOrderId", "Type Order ID");
			Add("Set Destination", "It seems they want to know where to drop the goods. Maybe it's not safe to provide your current location... But whatever", "setDestination", "Set Destination");
			Add("Select Living Island On The Map", "Ah, it seems there is only one island connected to the star internet", "selectIsland", "Select Island");
			Add("Wait For The Delivery Complete", "Now you can head back to the delivery site and watch the progress of the delivery", "waitDelivery", "Wait Delivery");
			Add("Collect Your Goods", "When the parcel has landed you can collect your goods and enjoy your life on the island", "collectGoods", "Collect Goods");
			return steps;
			MissionDefinition Add(string title, string description, string interactKey, string interactDescription)
			{
				MissionBuilder missionBuilder = factory.Create($"tutorial_step_{steps.Count + 1}").WithTitle(title).WithDescription(description);
				if (steps.Count > 0)
				{
					missionBuilder.RequiresCompletion(steps[steps.Count - 1].MissionId);
				}
				MissionDefinition missionDefinition = missionBuilder.Interact(interactKey, 1, interactDescription).Build();
				steps.Add(missionDefinition);
				return missionDefinition;
			}
		}
	}
}
