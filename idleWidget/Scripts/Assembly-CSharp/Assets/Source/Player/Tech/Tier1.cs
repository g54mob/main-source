using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
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
				Name = "Tier 1 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
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
				Name = "Deconstruct",
				StaticDescription = "Allows you to remove frames from the world for a partial refund.",
				Tier = 1,
				Previous = "t1_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_39",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "iron_ingot", "widget" }
			});
			TechNode.Add(new TechNode("t3_move_frame")
			{
				Name = "Frame Relocation",
				StaticDescription = "Allows you to move frames on the world map without penalty.\n\n" + UIHelper.HighlightText("Drag-and-drop") + " a frame to move it.",
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
				Name = "Tier 1 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 1 items crafted by hand.",
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1_tech",
				IconName = "Numerals_0",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedTier = 1,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t1f_iron_ore")
			{
				Name = "Iron Mine",
				StaticDescription = "Harvests raw iron ore from surface deposits.",
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
				Name = "Iron-rich Rocks",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("40%") + " when placed on Rocks.",
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
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_0")
			{
				Name = "Efficient Extraction",
				StaticDescription = "Increases iron mining speed by " + UIHelper.HighlightText("40%") + ".",
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1f_iron_ore",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_1")
			{
				Name = "Core Drilling",
				StaticDescription = "Increases iron mining speed by " + UIHelper.HighlightText("40%") + ".",
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ore_speed_0",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "power", "capacitor_widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_2")
			{
				Name = "Dig Deeper",
				StaticDescription = "Increases iron mining speed by " + UIHelper.HighlightText("40%") + ".",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ore_speed_1",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t1u_iron_ore_speed_3")
			{
				Name = "Uranium-powered Drills",
				StaticDescription = "Increases iron mining speed by " + UIHelper.HighlightText("40%") + ".",
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1u_iron_ore_speed_2",
				IconName = "Items_0",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T1IronOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t1f_iron_ingot")
			{
				Name = "Iron Smelter",
				StaticDescription = "Forges raw iron ore into ingots.",
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
				Name = "Furnace Optimizer",
				StaticDescription = "Automatically starts the Iron Smelter when full.",
				Tier = 1,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1f_iron_ingot",
				IconName = "Items_8",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				CostMultiplier = 0.25f,
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_speed_0")
			{
				Name = "Efficient Loader Arms",
				StaticDescription = "Increases furnace loading speed by " + UIHelper.HighlightText("150%") + ".",
				Tier = 2,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1f_iron_ingot",
				IconName = "Items_8",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5f
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_speed_1")
			{
				Name = "Double-stacked Conveyors",
				StaticDescription = "Increases furnace loading speed by " + UIHelper.HighlightText("150%") + ".",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_iron_ingot_speed_0",
				IconName = "Items_8",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T1IronIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5f
			});
			TechNode.Add(new TechNode("t1u_iron_smelter_capacity")
			{
				Name = "Industrial Capacity",
				StaticDescription = UIHelper.HighlightText("Doubles") + " smelter capacity.",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_smeltspeed_0")
			{
				Name = "Superheated Crucible",
				StaticDescription = "Increases smelting speed by " + UIHelper.HighlightText("100%") + ".",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t1u_iron_smelter_placement")
			{
				Name = "High Heat Density",
				StaticDescription = "Increases smelting speed by " + UIHelper.HighlightText("25%") + " for each adjacent Iron Smelter.",
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
				UpgradeMultiplier = 0.25f
			});
			TechNode.Add(new TechNode("t1u_iron_ingot_smeltspeed_1")
			{
				Name = "Turbo Blast Furnace",
				StaticDescription = "Increases smelting speed by " + UIHelper.HighlightText("100%") + ".",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t1f_widget")
			{
				Name = "Widget Factory",
				StaticDescription = "Creates basic widgets.",
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
				Name = "Rapid Assembly",
				Tier = 1,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1f_widget",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t1u_widget_speed_1")
			{
				Name = "Ultra-Fast Widget Synthesizer",
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_speed_0",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t1u_widget_speed_2")
			{
				Name = "Omni-Assembler Core",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_speed_1",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t1u_widget_speed_3")
			{
				Name = "Infinite Widget Matrix",
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1u_widget_speed_2",
				IconName = "Items_48",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t1u_widget_prod_0")
			{
				Name = "Optimized Materials",
				StaticDescription = "Increases basic widget productivity by " + UIHelper.HighlightText("15%") + ".\n\nProductivity upgrades grant a percentage chance to craft additional items for free.",
				Tier = 1,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t1f_widget",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "iron_ingot", "widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t1u_widget_placement")
			{
				Name = "Widget Twins",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("40%") + " if placed adjacent to exactly one other Widget Factory.",
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
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t1u_widget_prod_1")
			{
				Name = "Precision Widgeteering",
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_prod_0",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t1u_widget_prod_2")
			{
				Name = "Productivity Optimization Node",
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t1u_widget_prod_1",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t1u_widget_prod_3")
			{
				Name = "Hyper-Production Matrix",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t1u_widget_prod_1",
				IconName = "Items_48",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T1BasicWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
		}
	}
}
