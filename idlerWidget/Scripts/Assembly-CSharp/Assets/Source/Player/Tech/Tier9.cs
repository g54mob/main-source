using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier9
	{
		static Tier9()
		{
			TechNode.Add(new TechNode("t9_tech")
			{
				Name = "Tier 9 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 8,
				AbsolutePosition = new Vector2Int(-9, 25),
				IconName = "Numerals_8",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "quantum_widget" },
				CostMultiplier = 3f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(9);
					player.AddTierBenchmark(9);
					player.AddTech("t9f_helium");
					player.AddTech("t9f_superconductor");
					player.AddTech("t9f_ai_core");
					player.AddTech("t9f_unshackled_widget");
				}
			});
			TechNode.Add(new TechNode("t9_mastery")
			{
				Name = "Tier 9 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 9 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9_tech",
				IconName = "Numerals_8",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedTier = 9,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t9u_frame_cost")
			{
				Name = "New World Order",
				StaticDescription = "Reduces the exponential cost increase of building frames.",
				Tier = 9,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t9_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" }
			});
			TechNode.Add(new TechNode("t9f_helium")
			{
				Name = "Helium Extractor",
				StaticDescription = "Squeezes rocks deep underground to extract helium.",
				Tier = 9,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t9_tech",
				IconName = "Items_5",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "quantum_widget" }
			});
			TechNode.Add(new TechNode("t9u_helium_placement")
			{
				Name = "Gaseous Bedrock",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("30%") + " when placed on Rocks.",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9f_helium",
				IconName = "Items_5",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T9Helium>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.3f
			});
			TechNode.Add(new TechNode("t9u_helium_prod_0")
			{
				Name = "Subatomic Yield Booster",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_helium",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t9u_helium_prod_1")
			{
				Name = "Precision Gas Separator",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_helium_prod_0",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t9u_helium_prod_2")
			{
				Name = "Enhanced Helium Synthesizer",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_helium_prod_1",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t9u_helium_prod_3")
			{
				Name = "Omega Extraction Matrix",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9u_helium_prod_2",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t9f_superconductor")
			{
				Name = "Conductor Foundry",
				StaticDescription = "Conducts experiments with superconducting materials.",
				Tier = 9,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t9f_helium",
				IconName = "Items_20",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "quantum_widget" }
			});
			TechNode.Add(new TechNode("t9u_superconductor_placement")
			{
				Name = "Resource Management",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " if adjacent to both a Helium Extractor and Iron Mine.",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9f_superconductor",
				IconName = "Items_20",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T9Superconductor>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t9u_superconductor_speed_0")
			{
				Name = "Lightning Flux Unit",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_superconductor",
				IconName = "Items_20",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t9u_superconductor_speed_1")
			{
				Name = "Hyper-Speed Magnet Chamber",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_superconductor_speed_0",
				IconName = "Items_20",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t9u_superconductor_prod_0")
			{
				Name = "Quantum Flux Matrix",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9f_superconductor",
				IconName = "Items_20",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t9u_superconductor_prod_1")
			{
				Name = "Omega Magnetizer Unit",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_superconductor_prod_0",
				IconName = "Items_20",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t9f_ai_core")
			{
				Name = "AI Laboratory",
				StaticDescription = "Teaches widgets to think for themselves.",
				Tier = 9,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t9f_superconductor",
				IconName = "Items_33",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "quantum_widget" }
			});
			TechNode.Add(new TechNode("t9u_ai_core_placement")
			{
				Name = "Hello World",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " if placed on Grass.",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9f_ai_core",
				IconName = "Items_33",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T9AICore>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_0")
			{
				Name = "Quantum Neural Matrix",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_ai_core",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_1")
			{
				Name = "Rapid AI Synthesizer",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_ai_core_speed_0",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_2")
			{
				Name = "Optimized Neuron Compiler",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_ai_core_speed_1",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_3")
			{
				Name = "Omega Thought Conductor",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9u_ai_core_speed_2",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9f_unshackled_widget")
			{
				Name = "AI Delimiter",
				StaticDescription = "Breaks the carefully considered limits placed on the growth of widget intelligence.",
				Tier = 9,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t9f_ai_core",
				IconName = "Items_56",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "quantum_widget" }
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_placement")
			{
				Name = "Trinity",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("10%") + " when adjacent to exactly two AI Laboratories (and no other frames).",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9f_unshackled_widget",
				IconName = "Items_56",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T9UnshackledWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_speed_0")
			{
				Name = "Neural Accelerator",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_unshackled_widget",
				IconName = "Items_56",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_speed_1")
			{
				Name = "Upgraded AI Compiler",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_speed_0",
				IconName = "Items_56",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_speed_2")
			{
				Name = "Accelerated Thought Synthesizer",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_speed_1",
				IconName = "Items_56",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_prod_0")
			{
				Name = "Advanced Cognitive Network",
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9f_unshackled_widget",
				IconName = "Items_56",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_prod_1")
			{
				Name = "Multi-Phase Logic Processor",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_prod_0",
				IconName = "Items_56",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_prod_2")
			{
				Name = "Omega Neural Matrix",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_prod_1",
				IconName = "Items_56",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
		}
	}
}
