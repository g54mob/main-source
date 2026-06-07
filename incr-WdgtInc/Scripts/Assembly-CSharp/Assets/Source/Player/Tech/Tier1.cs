using System.Collections.Generic;
using Assets.Source.Ability;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier1
	{
		static Tier1()
		{
			TechNode.Add(new TechNode("t1_tech")
			{
				Tier = 1,
				AbsolutePosition = new Vector2Int(-9, 1),
				IconName = "Numerals_0",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "iron_ingot" },
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(1);
					player.AddTech("t1f_iron_ore");
					player.AddTech("t1f_iron_ingot");
					player.AddTech("t1f_widget");
				}
			});
			TechNode.Add(new TechNode("t1_deconstruct")
			{
				Tier = 1,
				Previous = "t1_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_39",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "iron_ingot", "widget" }
			});
			TechNode.Add(new TechNode("t3_move_frame")
			{
				Tier = 1,
				Previous = "t1_deconstruct",
				RelativePosition = new Vector2Int(1, 0),
				IconName = "Items_29",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "iron_ingot", "widget" }
			});
			TechNode.Add(new TechNode("t1_mastery")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1_tech",
				IconName = "Numerals_0",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedTier = 1,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t1f_iron_ore")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t1_tech",
				IconName = "Items_0",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "iron_ingot" }
			});
			TechNode.Add(new TechNode("t1u_iron_ore_placement")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1f_iron_ore",
				IconName = "Items_0",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T1IronOre>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_0")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1f_iron_ore",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_1")
			{
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ore_speed_0",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "power", "capacitor_widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_2")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ore_speed_1",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_3")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1u_iron_ore_speed_2",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t1f_iron_ingot")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t1f_iron_ore",
				IconName = "Items_8",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "iron_ingot" }
			});
			TechNode.Add(new TechNode("t1u_iron_smelter_auto")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1f_iron_ingot",
				IconName = "Items_8",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				CostMultiplier = 0.25,
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_speed_0")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1f_iron_ingot",
				IconName = "Items_8",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_speed_1")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ingot_speed_0",
				IconName = "Items_8",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5
			});
			TechNode.Add(new TechNode("t1u_iron_smelter_capacity")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_smelter_auto",
				IconName = "Items_8",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "capacitor_widget", "computational_widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 3,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_smeltspeed_0")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1f_iron_ingot",
				IconName = "Items_8",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t1u_iron_smelter_placement")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1u_iron_ingot_smeltspeed_0",
				IconName = "Items_8",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T1IronIngot>();
				},
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 0.25
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_smeltspeed_1")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ingot_smeltspeed_0",
				IconName = "Items_8",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t1f_widget")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(6, 0),
				Previous = "t1f_iron_ingot",
				IconName = "Items_48",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "iron_ingot" }
			});
			TechNode.Add(new TechNode("t1u_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1f_widget",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t1u_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_speed_0",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t1u_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_speed_1",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t1u_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1u_widget_speed_2",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t1u_widget_prod_0")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1f_widget",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t1u_widget_placement")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1u_widget_prod_0",
				IconName = "Items_48",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T1BasicWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t1u_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_prod_0",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t1u_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1u_widget_prod_1",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t1u_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_prod_1",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t1f_glitched_frame")
			{
				Tier = 1,
				RelativePosition = new Vector2Int(3, 0),
				RequiresGlitchedFrame = true,
				Previous = "t1f_widget",
				IconName = "Items_7",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "widget" },
				CostMultiplier = 13.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.AddActivatedAbility(ActivatedAbility.Get("HandcraftMultiplier"));
				}
			});
			TechNode.Add(new TechNode("t1a_speed_multiplier")
			{
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				RequiresGlitchedFrame = true,
				Previous = "t1f_glitched_frame",
				IconName = "Items_46",
				NodeType = TechNodeType.Ability,
				CostItems = new List<ItemType> { "spinning_widget" },
				CostMultiplier = 13.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.AddActivatedAbility(ActivatedAbility.Get("SpeedMultiplier"));
				}
			});
			TechNode.Add(new TechNode("t1a_production_multiplier")
			{
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				RequiresGlitchedFrame = true,
				Previous = "t1a_speed_multiplier",
				IconName = "Items2_7",
				NodeType = TechNodeType.Ability,
				CostItems = new List<ItemType> { "computational_widget" },
				CostMultiplier = 13.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.AddActivatedAbility(ActivatedAbility.Get("ProductionMultiplier"));
				}
			});
			TechNode.Add(new TechNode("t1a_mitosis")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				RequiresGlitchedFrame = true,
				Previous = "t1a_production_multiplier",
				IconName = "Items2_6",
				NodeType = TechNodeType.Ability,
				CostItems = new List<ItemType> { "quantum_widget" },
				CostMultiplier = 13.0,
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.AddActivatedAbility(ActivatedAbility.Get("Mitosis"));
				}
			});
		}
	}
}
