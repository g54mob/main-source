using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier12
	{
		static Tier12()
		{
			TechNode.Add(new TechNode("t12_tech")
			{
				Name = "Tier 12 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 11,
				AbsolutePosition = new Vector2Int(-9, 34),
				IconName = "Numerals_11",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "sentient_widget" },
				CostMultiplier = 3.5f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(13);
					player.AddTierBenchmark(12);
					player.AddTech("t12f_processor_amalgamation");
					player.AddTech("t12f_core_amalgamation");
					player.AddTech("t12f_widget_amalgamation");
					player.AddTech("t12f_omega_project_casing");
					player.AddTech("t12f_omega_project_shielding");
					player.AddTech("t12f_omega_widget");
				}
			});
			TechNode.Add(new TechNode("t12_mastery")
			{
				Name = "Tier 12 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 12 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 12,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t12_tech",
				IconName = "Numerals_11",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedTier = 12,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t12f_processor_amalgamation")
			{
				Name = "Omega Processor Lab",
				StaticDescription = "With their newly acquired dominion of Earth, the Widgets began to construct their magnum opus.",
				Tier = 12,
				RelativePosition = new Vector2Int(3, -1),
				Previous = "t12_tech",
				IconName = "Items_44",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "sentient_widget" }
			});
			TechNode.Add(new TechNode("t12f_core_amalgamation")
			{
				Name = "Omega Core Foundry",
				StaticDescription = "An entire planet's resources lay ready to be repurposed for this grand design.",
				Tier = 12,
				RelativePosition = new Vector2Int(2, 0),
				Previous = "t12f_processor_amalgamation",
				IconName = "Items_35",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "sentient_widget" }
			});
			TechNode.Add(new TechNode("t12f_rocket_electronics")
			{
				Name = "Rocket Electronics Lab",
				StaticDescription = "The circuitry that lets us touch the stars.",
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_core_amalgamation",
				IconName = "Items_62",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 4f
			});
			TechNode.Add(new TechNode("t12f_widget_amalgamation")
			{
				Name = "Omega Widget Distiller",
				StaticDescription = "All Widgets created so far had only one remaining purpose: To be reshaped into their final creation.",
				Tier = 12,
				RelativePosition = new Vector2Int(2, 0),
				Previous = "t12f_core_amalgamation",
				IconName = "Items_25",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "sentient_widget" }
			});
			TechNode.Add(new TechNode("t12f_rocket_fuel")
			{
				Name = "Rocket Fuel Distiller",
				StaticDescription = "The substance that fuels our dreams and ambitions.",
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_widget_amalgamation",
				IconName = "Items_61",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 4f
			});
			TechNode.Add(new TechNode("t12f_omega_project_casing")
			{
				Name = "Omega Casing Factory",
				StaticDescription = "The first widget was the Alpha, and the last was to be the Omega.",
				Tier = 12,
				RelativePosition = new Vector2Int(2, 0),
				Previous = "t12f_widget_amalgamation",
				IconName = "Items_23",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "sentient_widget" }
			});
			TechNode.Add(new TechNode("t12f_omega_project_shielding")
			{
				Name = "Omega Shielding Plant",
				StaticDescription = "One Widget to rule over all, and to usher in a new age of technology.",
				Tier = 12,
				RelativePosition = new Vector2Int(2, 0),
				Previous = "t12f_omega_project_casing",
				IconName = "Items_24",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "sentient_widget" }
			});
			TechNode.Add(new TechNode("t12f_rocket_part")
			{
				Name = "Rocket Part Assembler",
				StaticDescription = "The structure that carries us to heaven.",
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_omega_project_shielding",
				IconName = "Items_63",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 4f
			});
			TechNode.Add(new TechNode("t12f_omega_widget")
			{
				Name = "Omega Project Assembler",
				StaticDescription = "Behold, the pinnacle of Widget engineering. The universe beckons.",
				Tier = 12,
				RelativePosition = new Vector2Int(2, 0),
				Previous = "t12f_omega_project_shielding",
				IconName = "Items_59",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "sentient_widget" }
			});
			TechNode.Add(new TechNode("t12f_launch_facility")
			{
				Name = "Omega Launch Facility",
				StaticDescription = "Soon, the Widgets will spread to the stars.",
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_omega_widget",
				IconName = "Items_60",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 12f
			});
		}
	}
}
