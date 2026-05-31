using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
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
				Name = "Tier 4 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 3,
				AbsolutePosition = new Vector2Int(-9, 10),
				IconName = "Numerals_3",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "capacitor_widget" },
				CostMultiplier = 1.5f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.AddTierBenchmark(4);
				}
			});
			TechNode.Add(new TechNode("t4u_eagle_eye")
			{
				Name = "Eagle Eye",
				StaticDescription = "Expands the build menu by showing the total number of frames built for each type.",
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
				Name = "Discerning Vision",
				StaticDescription = "Allows you to highlight all frames of a given type (accessed through the build menu).",
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
				Name = "Long Distance Upgrades",
				StaticDescription = "Allows you to purchase auto workers and upgrades from the world map.",
				Tier = 3,
				Previous = "t4_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_29",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "gyroscope", "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4_overview_upgrade_status")
			{
				Name = "Upgrade Status",
				StaticDescription = "Highlights frames that are not fully upgraded in the world map.",
				Tier = 3,
				Previous = "t4_overview_upgrade",
				RelativePosition = new Vector2Int(1, 0),
				IconName = "Items_45",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "gyroscope", "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4_mastery")
			{
				Name = "Tier 4 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 4 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 4,
				AbsolutePosition = new Vector2Int(-8, 10),
				Previous = "t4_tech",
				IconName = "Numerals_3",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				UpgradedTier = 4,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4f_demo_turtle")
			{
				Name = "Leaping Turtle Statue",
				StaticDescription = "Construct a fitting end to this demo.",
				Tier = 3,
				CostMultiplier = 4f,
				RelativePosition = new Vector2Int(3, -1),
				Previous = "t4_tech",
				IconName = "Items_7",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t4f_copper_ore")
			{
				Name = "Copper Mine",
				StaticDescription = "Harvests copper ore from near the planet's core.",
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
				Name = "Giant Rock Crusher",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when placed on Rocks.",
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
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_0")
			{
				Name = "Turbo Drill Motors",
				StaticDescription = "Increases copper mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_copper_ore",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "plastic", "computational_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_1")
			{
				Name = "Hyper-Speed Conveyor System",
				StaticDescription = "Increases copper mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ore_speed_0",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_2")
			{
				Name = "High-Yield Extraction System",
				StaticDescription = "Increases copper mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ore_speed_1",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_copper_ore_speed_3")
			{
				Name = "Advanced Mining Protocol",
				StaticDescription = "Increases copper mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_copper_ore_speed_2",
				IconName = "Items_3",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T4CopperOre",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4f_copper_ingot")
			{
				Name = "Copper Forge",
				StaticDescription = "Melts raw copper ore into refined ingots.",
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
				Name = "Forge Attendant",
				StaticDescription = "Automatically starts the Copper Forge when full.",
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4f_copper_ingot",
				IconName = "Items_13",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				CostMultiplier = 0.5f,
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_speed_0")
			{
				Name = "Advanced Alloy Mixer",
				StaticDescription = "Increases furnace loading speed by " + UIHelper.HighlightText("150%") + ".",
				Tier = 5,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4f_copper_ingot",
				IconName = "Items_13",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5f
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_speed_1")
			{
				Name = "Ore-to-Ingot Optimization System",
				StaticDescription = "Increases furnace loading speed by " + UIHelper.HighlightText("150%") + ".",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ingot_speed_0",
				IconName = "Items_13",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T4CopperIngot",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2.5f
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_capacity")
			{
				Name = "Dense Packing Grid",
				StaticDescription = "Doubles smelter capacity.",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_smeltspeed_0")
			{
				Name = "Rapid Heat Induction Coils",
				StaticDescription = "Increases smelting speed by " + UIHelper.HighlightText("100%") + ".",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_placement")
			{
				Name = "Slash And Burn",
				StaticDescription = "Increases smelting speed by " + UIHelper.HighlightText("100%") + " when placed on a Forest.",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_copper_ingot_smeltspeed_0",
				IconName = "Items_3",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T4CopperIngot>();
				},
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 2,
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t4u_copper_ingot_smeltspeed_1")
			{
				Name = "Quantum Heat Exchanger",
				StaticDescription = "Increases smelting speed by " + UIHelper.HighlightText("100%") + ".",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t4f_plastic")
			{
				Name = "Plastic Extractor",
				StaticDescription = "Turns raw, unfiltered oil into shiny white plastic.",
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
				Name = "Shortened Transfer Tube",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when placed adjacent to an Oil Field.",
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
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_0")
			{
				Name = "Enhanced Chemical Mixer",
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_plastic",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_1")
			{
				Name = "Advanced Refining Chamber",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_plastic_speed_0",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_2")
			{
				Name = "Yield Optimization Catalyst",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_plastic_speed_1",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_plastic_speed_3")
			{
				Name = "Rapid Refinement Module",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_plastic_speed_2",
				IconName = "Items_14",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T4Plastic",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4f_circuit_board")
			{
				Name = "Circuit Fab",
				StaticDescription = "Creates circuit boards for basic electronics.",
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
				Name = "Agoraphobia",
				StaticDescription = "Increases speed by " + UIHelper.HighlightText("100%") + " when surrounded on all sides by frames or impassable terrain.",
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
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t4u_circuit_board_speed_0")
			{
				Name = "Hyper-Speed Assembly Line",
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_circuit_board",
				IconName = "Items_40",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t4u_circuit_board_speed_1")
			{
				Name = "Turbo Soldering Station",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_circuit_board_speed_0",
				IconName = "Items_40",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t4u_circuit_board_prod_0")
			{
				Name = "Precision Assembly Matrix",
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4f_circuit_board",
				IconName = "Items_40",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t4u_circuit_board_prod_1")
			{
				Name = "Quantum Circuitry Optimizer",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_circuit_board_prod_0",
				IconName = "Items_40",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T4CircuitBoard",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t4f_computational_widget")
			{
				Name = "Computational Engine",
				StaticDescription = "Adds a rudimentary calculation module to widgets.",
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
				Name = "Rapid Component Feeder",
				Tier = 4,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4f_computational_widget",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_1")
			{
				Name = "Accelerated Component Placement",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_speed_0",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_2")
			{
				Name = "Hyper-Speed Arithmetic Processor",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_speed_1",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_speed_3")
			{
				Name = "Ultra-Quick Logic Compiler",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4u_computational_widget_speed_2",
				IconName = "Items_51",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_0")
			{
				Name = "Enhanced Logic Synthesizer",
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t4f_computational_widget",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_placement")
			{
				Name = "Standalone",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " when not adjacent to another Computational Engine.",
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
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_1")
			{
				Name = "Advanced Circuit Optimization",
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_prod_0",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_2")
			{
				Name = "Multi-Tasking Calculation Node",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t4u_computational_widget_prod_1",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t4u_computational_widget_prod_3")
			{
				Name = "Advanced Arithmetic Processor",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t4u_computational_widget_prod_1",
				IconName = "Items_51",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T4ComputationalWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
		}
	}
}
