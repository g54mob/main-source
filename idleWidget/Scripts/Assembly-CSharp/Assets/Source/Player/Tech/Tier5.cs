using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier5
	{
		static Tier5()
		{
			TechNode.Add(new TechNode("t5_tech")
			{
				Name = "Tier 5 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 4,
				AbsolutePosition = new Vector2Int(-9, 13),
				IconName = "Numerals_4",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "computational_widget" },
				CostMultiplier = 2f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(5);
					player.AddTierBenchmark(5);
					player.AddTech("t5f_bottled_lightning");
					player.AddTech("t5f_thinking_core");
					player.AddTech("t5f_integrated_widget");
				}
			});
			TechNode.Add(new TechNode("t5_copy_paste")
			{
				Name = "Clone Layout",
				StaticDescription = "Allows you to copy-and-paste entire sections of your factory.",
				Tier = 5,
				Previous = "t5_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_38",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" }
			});
			TechNode.Add(new TechNode("t5_area_move")
			{
				Name = "Area Move",
				StaticDescription = "Adds cut-and-paste functionality to the Clone Layout tool. Select an area using the copy tool, then hold " + UIHelper.HighlightText("Control") + " to relocate the selected frames.",
				Tier = 5,
				Previous = "t5_copy_paste",
				RelativePosition = new Vector2Int(1, 0),
				IconName = "Items_38",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" }
			});
			TechNode.Add(new TechNode("t5_mastery")
			{
				Name = "Tier 5 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 5 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5_tech",
				IconName = "Numerals_4",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedTier = 5,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t5f_bottled_lightning")
			{
				Name = "Tesla Coil",
				StaticDescription = "Traps pure electrical energy inside glass vessels.",
				Tier = 5,
				AbsolutePosition = new Vector2Int(-5, 12),
				Previous = "t5_tech",
				IconName = "Items_15",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "computational_widget" }
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_placement")
			{
				Name = "Chain Lightning",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when adjacent to exactly two other Tesla Coils, but no other frames.",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5f_bottled_lightning",
				IconName = "Items_15",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T5BottledLightning>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_0")
			{
				Name = "Rapid Charge Collector",
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_bottled_lightning",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_1")
			{
				Name = "Multi-Bolt Capture Array",
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_bottled_lightning_speed_0",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_2")
			{
				Name = "Turbo Lightning Rods",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_bottled_lightning_speed_1",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_3")
			{
				Name = "High-Capacity Energy Condenser",
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5u_bottled_lightning_speed_2",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t5f_thinking_core")
			{
				Name = "Core Foundry",
				StaticDescription = "Forges the basis for all self-thinking machines.",
				Tier = 5,
				AbsolutePosition = new Vector2Int(0, 12),
				Previous = "t5f_bottled_lightning",
				IconName = "Items_32",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "computational_widget" }
			});
			TechNode.Add(new TechNode("t5u_thinking_core_placement")
			{
				Name = "Introvert",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("100%") + " when not adjacent to any other frames.",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5f_thinking_core",
				IconName = "Items_32",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T5ThinkingCore>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t5u_thinking_core_speed_0")
			{
				Name = "Rudimentary Synapse Connector",
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_thinking_core",
				IconName = "Items_32",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t5u_thinking_core_speed_1")
			{
				Name = "Rapid Cognitive Assembler",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_thinking_core_speed_0",
				IconName = "Items_32",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t5u_thinking_core_prod_0")
			{
				Name = "Efficient Neural Matrix",
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5f_thinking_core",
				IconName = "Items_32",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t5u_thinking_core_prod_1")
			{
				Name = "Thought Integration Unit",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_thinking_core_prod_0",
				IconName = "Items_32",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t5f_integrated_widget")
			{
				Name = "Integrator",
				StaticDescription = "Begins the process of grafting intelligence onto widget technology.",
				Tier = 5,
				AbsolutePosition = new Vector2Int(5, 12),
				Previous = "t5f_thinking_core",
				IconName = "Items_52",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "computational_widget" }
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_0")
			{
				Name = "Rapid Coupler",
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_integrated_widget",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_placement")
			{
				Name = "Extrovert",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("50%") + " when adjacent to at least one Core Foundry.",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5u_integrated_widget_speed_0",
				IconName = "Items_52",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T5IntegratedWidget>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_1")
			{
				Name = "Lightning Interface",
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_speed_0",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_2")
			{
				Name = "Ultra-Quick Integrator",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_speed_1",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_3")
			{
				Name = "Swift Logic Gate Fabricator",
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5u_integrated_widget_speed_2",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_0")
			{
				Name = "Synapse Fusion Unit",
				Tier = 5,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5f_integrated_widget",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_1")
			{
				Name = "Quantum Logic Synthesizer",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_prod_0",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_2")
			{
				Name = "Yield Maximization Protocol",
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5u_integrated_widget_prod_1",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_3")
			{
				Name = "Omega Assembly Core",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_prod_1",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
		}
	}
}
