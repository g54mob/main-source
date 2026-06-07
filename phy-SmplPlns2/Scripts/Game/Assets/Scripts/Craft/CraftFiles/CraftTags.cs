using System.Collections.Generic;

namespace Assets.Scripts.Craft.CraftFiles
{
	public static class CraftTags
	{
		public const string StockCraft = "Stock Craft";

		public static readonly IReadOnlyList<string> ExcludedWebsiteTags = new List<string>
		{
			"Ace Combat", "Batman", "Mass Effect", "Star Trek", "Star Wars", "YouTube", "YouTube - Camodo Gaming", "YouTube-Delosofy", "YouTube-Draegast", "YouTube-eNtaK",
			"YouTube-Frantic Matty", "YouTube-jacksepticeye", "YouTube-JacobHardy", "YouTube-Jelly", "YouTube-Kwebbelkop", "YouTube-oDDDReviews", "YouTube-Petard", "YouTube-Slogoman", "YouTube-The\u00a0Bearded\u00a0Beast", "YouTube-TheFSXPilot",
			"YouTube-Tyclone", "YouTube-Walvis", "YouTube-WeaselZone"
		};

		public static readonly IReadOnlyList<string> WebsiteTags = new List<string>
		{
			"19th Century", "2D Graphics", "Aerobatic", "Agricultural", "Air Defence", "Aircraft Carrier", "Airliner", "Airship", "Algerian War", "Amphibious",
			"Argentina", "Artillery", "Australia", "Austria", "Autogyro", "Biplane", "Bomber", "Brazil", "Britain", "Building",
			"Bush Plane", "Canada", "Cargo", "Challenge", "China", "Civilian", "Clock", "Cockpit", "Cold War", "Construction Equipment",
			"Decade-1900s", "Decade-1910s", "Decade-1920s", "Decade-1930s", "Decade-1940s", "Decade-1950s", "Decade-1960s", "Decade-1970s", "Decade-1980s", "Decade-1990s",
			"Decade-2000s", "Decade-2010s", "Decade-2020s", "Denmark", "Dieselpunk", "Drone", "Electric", "Electronic Warfare", "Experimental", "Fictional",
			"Fighter", "Finland", "Flying wing", "France", "Funky Trees", "Funny", "Futuristic", "General Aviation", "Germany", "Glider",
			"Guide", "Gun", "Heavy Bomber", "Helicopter", "Help", "Hungary", "Hypno", "India", "Indonesia", "Interceptor",
			"Iran", "Iraq", "Israel", "Italy", "Japan", "Jet", "Korean War", "Libya", "Malaysia", "Marine",
			"Mech", "Mechanical", "Mexico", "Micro", "Military", "Minigame", "Mobile Friendly", "Model", "Motorcycle", "Multirole",
			"Myanmar", "Nano", "Naval", "Netherlands", "Non-Airplane", "Norway", "Off-Road", "Painted", "Parts", "Philippines",
			"Poland", "Police", "Portugal", "Propeller", "Public Transport", "Racecar", "Racing", "Reconnaissance", "Recreational Vehicle", "Replica",
			"Rick", "Russia", "Scripted", "Seaplane", "Serbia", "Ship", "Singapore", "Single Engine", "South Africa", "South Korea",
			"Soviet Union", "Spacecraft", "Spain", "Stealth", "Steampunk", "STOL", "Submarine", "Sweden", "Switzerland", "Tank",
			"Toy", "Train", "Trainer", "Triplane", "Truck", "Turkey", "Ukraine", "Ultralight", "United Kingdom", "United States",
			"Vehicle", "Vietnam", "Vietnam War", "VR", "VTOL", "Walker", "Watercraft", "Weapon", "Work In Progress", "World War I",
			"World War II", "XML Modded", "Yugoslavia"
		};
	}
}
