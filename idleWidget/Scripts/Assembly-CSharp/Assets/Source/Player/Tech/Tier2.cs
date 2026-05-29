using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
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
				Name = "Tier 2 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
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
				}
			});
			TechNode.Add(new TechNode("t1f_warehouse")
			{
				Name = "Warehouse",
				StaticDescription = "Expands item storage capacity.",
				Tier = 2,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t2_tech",
				IconName = "Items_31",
				NodeType = TechNodeType.Frame,
				CostItems = new List<ItemType> { "iron_ingot", "spinning_widget" }
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_0")
			{
				Name = "Expanded Shelf Storage",
				StaticDescription = UIHelper.HighlightText("Doubles") + " warehouse storage capacity.",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_1")
			{
				Name = "Warehouse Shelf Stacker",
				StaticDescription = UIHelper.HighlightText("Doubles") + " warehouse storage capacity.",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_2")
			{
				Name = "Extradimensional Storage Lockers",
				StaticDescription = "Increases warehouse storage capacity by " + UIHelper.HighlightText("50%") + ".",
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
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t1u_warehouse_storage_3")
			{
				Name = "Infinite Storage Glitch",
				StaticDescription = "Increases warehouse storage capacity by " + UIHelper.HighlightText("50%") + ".",
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
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2_mastery")
			{
				Name = "Tier 2 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 2 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2_tech",
				IconName = "Numerals_1",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "widget", "spinning_widget" },
				UpgradedTier = 2,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2f_sand")
			{
				Name = "Sand Pit",
				StaticDescription = "Harvests and refines pure sand.",
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
				Name = "Beach Harvest",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when placed on a Sand tile.",
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
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t2u_sand_speed_0")
			{
				Name = "Mechanized Shovels",
				StaticDescription = "Increases sand harvesting speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_sand",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "widget", "spinning_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_sand_speed_1")
			{
				Name = "Bucket Excavator",
				StaticDescription = "Increases sand harvesting speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_sand_speed_0",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_sand_speed_2")
			{
				Name = "Grain Matrix Duplicator",
				StaticDescription = "Increases sand harvesting speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_sand_speed_1",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "mainframe_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_sand_speed_3")
			{
				Name = "Unified Theory of Sand",
				StaticDescription = "Increases sand harvesting speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2u_sand_speed_2",
				IconName = "Items_1",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "quantum_widget" },
				UpgradedFrame = "T2Sand",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2f_glass")
			{
				Name = "Glass Kiln",
				StaticDescription = "Melts down pure sand into clear glass.",
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
				Name = "Kiln Governor",
				StaticDescription = "Automatically adjusts the kiln's temperature.",
				Tier = 2,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2f_glass",
				IconName = "Items_9",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "glass", "spinning_widget" },
				CostMultiplier = 0.5f,
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t2u_glass_placement")
			{
				Name = "Molten Conveyor System",
				StaticDescription = "Increases smelt speed by " + UIHelper.HighlightText("50%") + " when adjacent to exactly two other Glass Kilns.",
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
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_glass_speed_0")
			{
				Name = "Superheated Crucible",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_glass",
				IconName = "Items_9",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_glass_speed_1")
			{
				Name = "Rapid Heat Exchanger",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_glass_speed_0",
				IconName = "Items_9",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_glass_prod_0")
			{
				Name = "Glass Shard Recombinator",
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2f_glass",
				IconName = "Items_9",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t2u_glass_prod_1")
			{
				Name = "Hyperfine Glass Distributor",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_glass_prod_0",
				IconName = "Items_9",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T2Glass",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t2f_gyroscope")
			{
				Name = "Gyroscope Fabricator",
				StaticDescription = "Combines widgets and a delicate glass frame into precision spinners.",
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
				Name = "Direct Glass Insertion",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when adjacent to at least one Glass Kiln.",
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
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_0")
			{
				Name = "Glass Ball Bearings",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_gyroscope",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_1")
			{
				Name = "Perfectly Balanced Spinners",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_gyroscope_speed_0",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_2")
			{
				Name = "Lightspeed Rotation",
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2f_gyroscope",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2u_gyroscope_speed_3")
			{
				Name = "Gyroscope Hyperprocessor",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_gyroscope_speed_2",
				IconName = "Items_10",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T2Gyroscope",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t2f_spinning_widget")
			{
				Name = "Widget Spinner",
				StaticDescription = "Accelerates widget rotation to several thousand revolutions per minute.",
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
				Name = "Gyroscopic Array",
				Tier = 2,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2f_spinning_widget",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_placement")
			{
				Name = "Glass Grinding Wheel",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("60%") + " when built adjacent to (but not on top of) Rocks.",
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
				UpgradeMultiplier = 1.6f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_1")
			{
				Name = "Tuned Spinners",
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_speed_0",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_2")
			{
				Name = "Counterspin Anchors",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_speed_1",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_speed_3")
			{
				Name = "Spacetime Spin Matrix",
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2u_spinning_widget_speed_2",
				IconName = "Items_49",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_0")
			{
				Name = "Spin Stabilizer",
				Tier = 2,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t2f_spinning_widget",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "gyroscope", "spinning_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_1")
			{
				Name = "Gyroscope Sharing Plan",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_prod_0",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_2")
			{
				Name = "Calculated Material Distribution",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t2u_spinning_widget_prod_1",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t2u_spinning_widget_prod_3")
			{
				Name = "Excess Spin Utilizer",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t2u_spinning_widget_prod_1",
				IconName = "Items_49",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T2SpinningWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
		}
	}
}
