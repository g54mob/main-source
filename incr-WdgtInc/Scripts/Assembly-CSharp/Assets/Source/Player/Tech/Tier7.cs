using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier7
	{
		static Tier7()
		{
			TechNode.Add(new TechNode("t7_tech")
			{
				Tier = 6,
				AbsolutePosition = new Vector2Int(-9, 19),
				IconName = "Numerals_6",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "mainframe_widget" },
				CostMultiplier = 2.5,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(7);
					player.AddTierBenchmark(7);
					player.AddTech("t7f_uranium");
					player.AddTech("t7f_fuel_rod");
					player.AddTech("t7f_power");
					player.AddTech("t7f_cloud_widget");
				}
			});
			TechNode.Add(new TechNode("t8_auto_upgrade")
			{
				Tier = 7,
				Previous = "t7_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_36",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.DoAutoUpgrade = true;
				}
			});
			TechNode.Add(new TechNode("t8_auto_upgrade_2")
			{
				Tier = 8,
				Previous = "t8_auto_upgrade",
				RelativePosition = new Vector2Int(1, 0),
				GenerateIconType = "Utility",
				IconName = "Items_36",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" }
			});
			TechNode.Add(new TechNode("t8_auto_upgrade_3")
			{
				Tier = 10,
				Previous = "t8_auto_upgrade_2",
				RelativePosition = new Vector2Int(1, 0),
				GenerateIconType = "Utility",
				IconName = "Items_36",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" }
			});
			TechNode.Add(new TechNode("t7_mastery")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7_tech",
				IconName = "Numerals_6",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedTier = 7,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7f_uranium")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t7_tech",
				IconName = "Items_4",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_uranium_placement")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7f_uranium",
				IconName = "Items_4",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7Uranium>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_0")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_uranium",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_1")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_uranium_speed_0",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_2")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_uranium_speed_1",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_3")
			{
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_uranium_speed_2",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7f_fuel_rod")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t7f_uranium",
				IconName = "Items_17",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_placement")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7f_fuel_rod",
				IconName = "Items_17",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7FuelRod>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_speed_0")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_fuel_rod",
				IconName = "Items_17",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_speed_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_fuel_rod_speed_0",
				IconName = "Items_17",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_prod_0")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7f_fuel_rod",
				IconName = "Items_17",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_prod_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_fuel_rod_prod_0",
				IconName = "Items_17",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t7f_power")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t7f_fuel_rod",
				IconName = "Items_46",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_power_placement")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7f_power",
				IconName = "Items_46",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7Power>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 0.25
			});
			TechNode.Add(new TechNode("t7u_power_prod_0")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_power",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t7u_power_prod_1")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_power_prod_0",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t7u_power_prod_2")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_power_prod_1",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2999999523162842
			});
			TechNode.Add(new TechNode("t7u_power_prod_3")
			{
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_power_prod_2",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2999999523162842
			});
			TechNode.Add(new TechNode("t7f_cloud_widget")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(5, 0),
				Previous = "t7f_power",
				IconName = "Items_54",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_cloud_widget",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_speed_0",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_speed_1",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_cloud_widget_speed_2",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7f_cloud_widget",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_placement")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_cloud_widget_prod_0",
				IconName = "Items_54",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7CloudWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_prod_0",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7u_cloud_widget_prod_1",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_prod_1",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
		}
	}
}
