using System.Collections.Generic;
using Assets.Source.Item;
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
				Tier = 11,
				AbsolutePosition = new Vector2Int(-9, 34),
				IconName = "Numerals_11",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "sentient_widget" },
				CostMultiplier = 3.5,
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
				Tier = 12,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t12_tech",
				IconName = "Numerals_11",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedTier = 12,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t12f_processor_amalgamation")
			{
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
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_core_amalgamation",
				IconName = "Items_62",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 4.0
			});
			TechNode.Add(new TechNode("t12f_widget_amalgamation")
			{
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
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_widget_amalgamation",
				IconName = "Items_61",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 4.0
			});
			TechNode.Add(new TechNode("t12f_omega_project_casing")
			{
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
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_omega_project_shielding",
				IconName = "Items_63",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 4.0
			});
			TechNode.Add(new TechNode("t12f_omega_widget")
			{
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
				Tier = 13,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t12f_omega_widget",
				IconName = "Items_60",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "omega_widget" },
				CostMultiplier = 12.0
			});
			TechNode.Add(new TechNode("t12f_glitched_frame")
			{
				Hidden = true,
				Tier = 12,
				CostMultiplier = 4.0,
				RelativePosition = new Vector2Int(3, -1),
				Previous = "t12_tech",
				IconName = "Items_7",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
		}
	}
}
