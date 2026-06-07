using System.Collections.Generic;
using Assets.Behaviour.UI.Construction;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier3
	{
		static Tier3()
		{
			TechNode.Add(new TechNode("t3_tech")
			{
				Tier = 2,
				AbsolutePosition = new Vector2Int(-9, 7),
				IconName = "Numerals_2",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "spinning_widget" },
				CostMultiplier = 1.5,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(3);
					player.AddTierBenchmark(3);
					player.AddTech("t3f_oil");
					player.AddTech("t3f_power");
					player.AddTech("t3f_battery");
					player.AddTech("t3f_capacitor_widget");
				}
			});
			TechNode.Add(new TechNode("t3_mastery")
			{
				Tier = 3,
				AbsolutePosition = new Vector2Int(-8, 7),
				Previous = "t3_tech",
				IconName = "Numerals_2",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "power", "capacitor_widget" },
				UpgradedTier = 3,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_construction_progress")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, 1),
				Previous = "t3_tech",
				IconName = "Items_27",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate
				{
					GameUI.Instance.UpdateConstructionButton();
				}
			});
			TechNode.Add(new TechNode("t3u_construction_pause")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3u_construction_progress",
				IconName = "Items_27",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate
				{
					ConstructionUI.Instance?.UpdateButtonAvailability();
				}
			});
			TechNode.Add(new TechNode("t3u_construction_cancelall")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3u_construction_pause",
				IconName = "Items_27",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate
				{
					ConstructionUI.Instance?.UpdateButtonAvailability();
				}
			});
			TechNode.Add(new TechNode("t3u_frame_cost")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t3_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t5_copy_paste")
			{
				Tier = 3,
				Previous = "t3u_frame_cost",
				RelativePosition = new Vector2Int(1, 0),
				IconName = "Items_38",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "power", "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t5_area_move")
			{
				Tier = 3,
				Previous = "t5_copy_paste",
				RelativePosition = new Vector2Int(1, 0),
				IconName = "Items_38",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t3f_oil")
			{
				Tier = 3,
				AbsolutePosition = new Vector2Int(-4, 6),
				Previous = "t3_tech",
				IconName = "Items_2",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_oil_pressure")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_oil",
				IconName = "Items_2",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				CostMultiplier = 0.5,
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t3u_oil_placement")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_oil_pressure",
				IconName = "Items_2",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3Oil>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t3u_oil_speed_0")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_oil",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_oil_speed_1")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_oil_speed_0",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_oil_speed_2")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_oil_speed_1",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_oil_speed_3")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_oil_speed_2",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3f_power")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(3, 0),
				Previous = "t3f_oil",
				IconName = "Items_11",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_power_placement")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_power",
				IconName = "Items_11",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3Power>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t3u_power_prod_0")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_power",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t3u_power_prod_1")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_power_prod_0",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t3u_power_prod_2")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_power_prod_1",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t3u_power_prod_3")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_power_prod_2",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t3f_battery")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t3f_power",
				IconName = "Items_12",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_battery_placement")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_battery",
				IconName = "Items_12",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3Battery>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t3u_battery_speed_0")
			{
				DynamicDescription = true,
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_battery",
				IconName = "Items_12",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_battery_speed_1")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_battery_speed_0",
				IconName = "Items_12",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_battery_prod_0")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3f_battery",
				IconName = "Items_12",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t3u_battery_prod_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_battery_prod_0",
				IconName = "Items_12",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t3f_capacitor_widget")
			{
				Tier = 3,
				AbsolutePosition = new Vector2Int(7, 6),
				Previous = "t3f_battery",
				IconName = "Items_50",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_capacitor_widget",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_speed_0",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_speed_1",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_capacitor_widget_speed_2",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 3,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3f_capacitor_widget",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_placement")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_capacitor_widget_prod_0",
				IconName = "Items_50",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3CapacitorWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_prod_0",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3u_capacitor_widget_prod_1",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_prod_1",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t3f_logistics_hub")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(3, 0),
				Previous = "t3f_capacitor_widget",
				IconName = "Items2_11",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t3u_logistics_hub_0")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_logistics_hub",
				IconName = "Items2_11",
				GenerateIconType = "Custom",
				CostItems = new List<ItemType> { "capacitor_widget" },
				CostMultiplier = 3.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus();
				}
			});
			TechNode.Add(new TechNode("t3u_logistics_hub_1")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_logistics_hub",
				IconName = "Items2_11",
				GenerateIconType = "Custom",
				CostItems = new List<ItemType> { "integrated_widget" },
				CostMultiplier = 3.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus();
				}
			});
			TechNode.Add(new TechNode("t3u_logistics_hub_2")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_logistics_hub_1",
				IconName = "Items2_11",
				GenerateIconType = "Productivity",
				CostItems = new List<ItemType> { "quantum_widget" },
				CostMultiplier = 3.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus();
				}
			});
		}
	}
}
