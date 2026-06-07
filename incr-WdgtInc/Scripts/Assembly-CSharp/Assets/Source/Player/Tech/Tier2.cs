using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier2
	{
		static Tier2()
		{
			TechNode.Add(new TechNode("t2_tech")
			{
				Tier = 1,
				AbsolutePosition = new Vector2Int(-9, 4),
				IconName = "Numerals_1",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "widget" },
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(2);
					player.AddTierBenchmark(2);
					player.AddTech("t2f_sand");
					player.AddTech("t2f_glass");
					player.AddTech("t2f_gyroscope");
					player.AddTech("t2f_spinning_widget");
					if (player.Prestige == 0 && player.SessionStats.PlayTime < 1080)
					{
						SteamAchievement.Trigger("Speedrun0");
					}
				}
			});
			TechNode.Add(new TechNode("t1f_warehouse")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t2_tech",
				IconName = "Items_31",
				NodeType = TechNodeType.Frame,
				CostItems = new List<ItemType> { "iron_ingot", "spinning_widget" }
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_0")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1f_warehouse",
				IconName = "Items_31",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T1Warehouse",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_1")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1u_warehouse_storage_0",
				IconName = "Items_31",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "mainframe_widget" },
				UpgradedFrame = "T1Warehouse",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_2")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_warehouse_storage_1",
				IconName = "Items_31",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T1Warehouse",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_3")
			{
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1u_warehouse_storage_2",
				IconName = "Items_31",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T1Warehouse",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2_mastery")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2_tech",
				IconName = "Numerals_1",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "widget", "spinning_widget" },
				UpgradedTier = 2,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2f_sand")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(5, -1),
				Previous = "t2_tech",
				IconName = "Items_1",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "widget" }
			});
			TechNode.Add(new TechNode("t2u_sand_placement")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2f_sand",
				IconName = "Items_1",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T2Sand>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t2u_sand_speed_0")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_sand",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "widget", "spinning_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_sand_speed_1")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_sand_speed_0",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_sand_speed_2")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_sand_speed_1",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "mainframe_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_sand_speed_3")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2u_sand_speed_2",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "quantum_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2f_glass")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t2f_sand",
				IconName = "Items_9",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "widget" }
			});
			TechNode.Add(new TechNode("t2u_glass_temp")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2f_glass",
				IconName = "Items_9",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "glass", "spinning_widget" },
				CostMultiplier = 0.5,
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t2u_glass_placement")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_glass_temp",
				IconName = "Items_9",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T2Glass>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_glass_speed_0")
			{
				DynamicDescription = true,
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_glass",
				IconName = "Items_9",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_glass_speed_1")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_glass_speed_0",
				IconName = "Items_9",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_glass_prod_0")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2f_glass",
				IconName = "Items_9",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t2u_glass_prod_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_glass_prod_0",
				IconName = "Items_9",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t2f_gyroscope")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t2f_glass",
				IconName = "Items_10",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "widget" }
			});
			TechNode.Add(new TechNode("t2u_gyroscope_placement")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2f_gyroscope",
				IconName = "Items_10",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "capacitor_widget", "computational_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T2Gyroscope>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_0")
			{
				DynamicDescription = true,
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_gyroscope",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_1")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_gyroscope_speed_0",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_2")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2f_gyroscope",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_3")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_gyroscope_speed_2",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t2f_spinning_widget")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t2f_gyroscope",
				IconName = "Items_49",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "widget" }
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_spinning_widget",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_placement")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2u_spinning_widget_speed_0",
				IconName = "Items_49",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T2SpinningWidget>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.600000023841858
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_speed_0",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_speed_1",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2u_spinning_widget_speed_2",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 2,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2f_spinning_widget",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_prod_0",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2u_spinning_widget_prod_1",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_prod_1",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
		}
	}
}
