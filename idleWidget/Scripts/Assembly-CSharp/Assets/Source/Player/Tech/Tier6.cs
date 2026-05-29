using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
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
				Name = "Tier 6 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 5,
				AbsolutePosition = new Vector2Int(-9, 16),
				IconName = "Numerals_5",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "integrated_widget" },
				CostMultiplier = 2f,
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
				Name = "Tier 6 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 6 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6_tech",
				IconName = "Numerals_5",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "silicon", "mainframe_widget" },
				UpgradedTier = 6,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_frame_cost")
			{
				Name = "The Factory Must Grow",
				StaticDescription = "Reduces the exponential cost increase of building frames.",
				Tier = 6,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t6_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t6f_silicon")
			{
				Name = "Silicon Extruder",
				StaticDescription = "Withdraws sand from your storage and refines it into pure silicon crystals.",
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
				Name = "Monocrystalline Structure",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("20%") + " when adjacent to at least one Sand Pit.",
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
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_0")
			{
				Name = "Swift Wafer Synthesizer",
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_silicon",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_1")
			{
				Name = "Rapid Crystal Formation Chamber",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_silicon_speed_0",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_2")
			{
				Name = "Yield Maximization Reactor",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_silicon_speed_1",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_silicon_speed_3")
			{
				Name = "Omega Crystal Stabilizer",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6u_silicon_speed_2",
				IconName = "Items_16",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T6Silicon",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6f_microprocessor")
			{
				Name = "Processor Lab",
				StaticDescription = "Turns crude circuit boards into proper computing chips.",
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
				Name = "Suburban Development",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("50%") + " when adjacent to (but not on top of) a City.",
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
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_microprocessor_speed_0")
			{
				Name = "Rudimentary Synapse Connector",
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_microprocessor",
				IconName = "Items_41",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_microprocessor_speed_1")
			{
				Name = "Rapid Cognitive Assembler",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_microprocessor_speed_0",
				IconName = "Items_41",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_microprocessor_prod_0")
			{
				Name = "Efficient Neural Matrix",
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6f_microprocessor",
				IconName = "Items_41",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t6u_microprocessor_prod_1")
			{
				Name = "Thought Integration Unit",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_microprocessor_prod_0",
				IconName = "Items_41",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T6Microprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t6f_mainframe_widget")
			{
				Name = "Mainframe Assembler",
				StaticDescription = "Grafts additional parallel processing capacity onto existing widgets.",
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
				Name = "Rapid Circuit Integrator",
				Tier = 6,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6f_mainframe_widget",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_1")
			{
				Name = "Hyper-Speed Compiler",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_speed_0",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_2")
			{
				Name = "Lightning Data Bus",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_speed_1",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_speed_3")
			{
				Name = "Omega Circuit Weaver",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6u_mainframe_widget_speed_2",
				IconName = "Items_53",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_0")
			{
				Name = "Enhanced Data Synthesizer",
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t6f_mainframe_widget",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_placement")
			{
				Name = "Binary Pairs",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " when adjacent to exactly one other frame.",
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
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_1")
			{
				Name = "Multi-Core Processor",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_prod_0",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_2")
			{
				Name = "Data Stream Optimizer",
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t6u_mainframe_widget_prod_1",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t6u_mainframe_widget_prod_3")
			{
				Name = "Omega Logic Amplifier",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t6u_mainframe_widget_prod_1",
				IconName = "Items_53",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T6MainframeWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
		}
	}
}
