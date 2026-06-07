using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier4
	{
		static Tier4()
		{
			TechNode.Add(new TechNode("t4_tech")
			{
				Tier = 3,
				AbsolutePosition = new Vector2Int(-9, 10),
				IconName = "Numerals_3",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "capacitor_widget" },
				CostMultiplier = 1.5,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(4);
					player.AddTierBenchmark(4);
					player.AddTech("t4f_copper_ore");
					player.AddTech("t4f_copper_ingot");
					player.AddTech("t4f_plastic");
					player.AddTech("t4f_circuit_board");
					player.AddTech("t4f_computational_widget");
				}
			});
			TechNode.Add(new TechNode("t4u_eagle_eye")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(1, 1),
				Previous = "t4_tech",
				IconName = "Items_30",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				OnUnlock = delegate
				{
				}
			});
			TechNode.Add(new TechNode("t4u_highlight_frames")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4u_eagle_eye",
				IconName = "Items_30",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				OnUnlock = delegate
				{
				}
			});
			TechNode.Add(new TechNode("t4_overview_upgrade")
			{
				Tier = 4,
				Previous = "t4_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_29",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "plastic", "computational_widget" }
			});
			TechNode.Add(new TechNode("t4_overview_upgrade_status")
			{
				Tier = 4,
				Previous = "t4_overview_upgrade",
				RelativePosition = new Vector2Int(1, 0),
				IconName = "Items_45",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "plastic", "computational_widget" }
			});
			TechNode.Add(new TechNode("t4_mastery")
			{
				Tier = 4,
				AbsolutePosition = new Vector2Int(-8, 10),
				Previous = "t4_tech",
				IconName = "Numerals_3",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				UpgradedTier = 4,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4f_demo_turtle")
			{
				Hidden = true,
				Tier = 3,
				CostMultiplier = 4.0,
				RelativePosition = new Vector2Int(3, -1),
				Previous = "t4_tech",
				IconName = "Items_7",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4f_copper_ore")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t4_tech",
				IconName = "Items_3",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4u_copper_ore_placement")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4f_copper_ore",
				IconName = "Items_3",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T4CopperOre>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_0")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_copper_ore",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_1")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ore_speed_0",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_2")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ore_speed_1",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_3")
			{
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_copper_ore_speed_2",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4f_copper_ingot")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t4f_copper_ore",
				IconName = "Items_13",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_auto")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4f_copper_ingot",
				IconName = "Items_13",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				CostMultiplier = 0.5,
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_speed_0")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4f_copper_ingot",
				IconName = "Items_13",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_speed_1")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ingot_speed_0",
				IconName = "Items_13",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_capacity")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ingot_auto",
				IconName = "Items_13",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 3,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_smeltspeed_0")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_copper_ingot",
				IconName = "Items_13",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_placement")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ingot_smeltspeed_0",
				IconName = "Items_13",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T4CopperIngot>();
				},
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_smeltspeed_1")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ingot_placement",
				IconName = "Items_13",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t4f_plastic")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(3, 0),
				Previous = "t4f_copper_ingot",
				IconName = "Items_14",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4u_plastic_placement")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4f_plastic",
				IconName = "Items_14",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T4Plastic>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_0")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_plastic",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_1")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_plastic_speed_0",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_2")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_plastic_speed_1",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_3")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_plastic_speed_2",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4f_circuit_board")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t4f_plastic",
				IconName = "Items_40",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4u_circuit_board_placement")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4f_circuit_board",
				IconName = "Items_40",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T4CircuitBoard>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t4u_circuit_board_speed_0")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_circuit_board",
				IconName = "Items_40",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t4u_circuit_board_speed_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_circuit_board_speed_0",
				IconName = "Items_40",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t4u_circuit_board_prod_0")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4f_circuit_board",
				IconName = "Items_40",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t4u_circuit_board_prod_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_circuit_board_prod_0",
				IconName = "Items_40",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t4f_computational_widget")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t4f_circuit_board",
				IconName = "Items_51",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_computational_widget",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_speed_0",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_speed_1",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_computational_widget_speed_2",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4f_computational_widget",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t4u_computational_widget_placement")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_computational_widget_prod_0",
				IconName = "Items_51",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T4ComputationalWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_prod_0",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4u_computational_widget_prod_1",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_prod_1",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
		}
	}
}
