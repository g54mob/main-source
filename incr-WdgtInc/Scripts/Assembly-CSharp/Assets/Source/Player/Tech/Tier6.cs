using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier6
	{
		static Tier6()
		{
			TechNode.Add(new TechNode("t6_tech")
			{
				Tier = 5,
				AbsolutePosition = new Vector2Int(-9, 16),
				IconName = "Numerals_5",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "integrated_widget" },
				CostMultiplier = 2.0,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(6);
					player.AddTierBenchmark(6);
					player.AddTech("t6f_silicon");
					player.AddTech("t6f_microprocessor");
					player.AddTech("t6f_mainframe_widget");
				}
			});
			TechNode.Add(new TechNode("t6_mastery")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6_tech",
				IconName = "Numerals_5",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "silicon", "mainframe_widget" },
				UpgradedTier = 6,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_frame_cost")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t6_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t6f_silicon")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t6_tech",
				IconName = "Items_16",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "integrated_widget" }
			});
			TechNode.Add(new TechNode("t6u_silicon_placement")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6f_silicon",
				IconName = "Items_16",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T6Silicon>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_0")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_silicon",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_silicon_speed_0",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_2")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_silicon_speed_1",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6u_silicon_speed_2",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6f_microprocessor")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(5, 0),
				Previous = "t6f_silicon",
				IconName = "Items_41",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "integrated_widget" }
			});
			TechNode.Add(new TechNode("t6u_microprocessor_placement")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6f_microprocessor",
				IconName = "Items_41",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T6Microprocessor>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_microprocessor_speed_0")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_microprocessor",
				IconName = "Items_41",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "silicon", "mainframe_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_microprocessor_speed_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_microprocessor_speed_0",
				IconName = "Items_41",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "unshackled_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_microprocessor_prod_0")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6f_microprocessor",
				IconName = "Items_41",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t6u_microprocessor_prod_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_microprocessor_prod_0",
				IconName = "Items_41",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t6f_mainframe_widget")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(5, 0),
				Previous = "t6f_microprocessor",
				IconName = "Items_53",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "integrated_widget" }
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_mainframe_widget",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_speed_0",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_speed_1",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6u_mainframe_widget_speed_2",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6f_mainframe_widget",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_placement")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6u_mainframe_widget_prod_0",
				IconName = "Items_53",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T6MainframeWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_prod_0",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6u_mainframe_widget_prod_1",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_prod_1",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t6u_indentured_servitude")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t6f_mainframe_widget",
				IconName = "Items2_8",
				NodeType = TechNodeType.Utility,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus();
				}
			});
			TechNode.Add(new TechNode("t6f_graveyard")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_indentured_servitude",
				IconName = "Items2_5",
				NodeType = TechNodeType.Frame,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t6u_graveyard_speed")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6f_graveyard",
				IconName = "Items2_5",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T6Graveyard",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t6f_incinerator")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6f_graveyard",
				IconName = "Items2_10",
				NodeType = TechNodeType.Frame,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" }
			});
			TechNode.Add(new TechNode("t6f_incinerator_flag")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_incinerator",
				IconName = "Items2_10",
				NodeType = TechNodeType.Frame,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				Hidden = true
			});
			TechNode.Add(new TechNode("t6u_incinerator_speed")
			{
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6f_incinerator",
				IconName = "Items2_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T6Incinerator",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t6u_indentured_servitude_2")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6u_indentured_servitude",
				IconName = "Items2_8",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				GenerateIconType = "Productivity",
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus();
				}
			});
			TechNode.Add(new TechNode("t6u_indentured_servitude_3")
			{
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_indentured_servitude_2",
				IconName = "Items2_8",
				NodeType = TechNodeType.Utility,
				GenerateIconType = "Custom",
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus();
				}
			});
		}
	}
}
