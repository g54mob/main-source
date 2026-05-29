using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier10
	{
		static Tier10()
		{
			TechNode.Add(new TechNode("t10_tech")
			{
				Name = "Tier 10 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 9,
				AbsolutePosition = new Vector2Int(-9, 28),
				IconName = "Numerals_9",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "unshackled_widget" },
				CostMultiplier = 3f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(10);
					player.AddTierBenchmark(10);
					player.AddTech("t10f_ai_training_data");
					player.AddTech("t10f_ascension_booster");
					player.AddTech("t10f_ascended_widget");
				}
			});
			TechNode.Add(new TechNode("t10_mastery")
			{
				Name = "Tier 10 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 10 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10_tech",
				IconName = "Numerals_9",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedTier = 10,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t10f_ai_training_data")
			{
				Name = "Training Center",
				StaticDescription = "Educates the next generation of artificial intelligence.",
				Tier = 10,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t10_tech",
				IconName = "Items_21",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "unshackled_widget" }
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_placement")
			{
				Name = "History Lesson",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("10%") + " when placed on Ruins.",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10f_ai_training_data",
				IconName = "Items_21",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T10AITrainingData>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_speed_0")
			{
				Name = "Advanced Cognitive Compiler",
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10f_ai_training_data",
				IconName = "Items_21",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T10AITrainingData",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_speed_1")
			{
				Name = "Rapid Spec Synthesizer",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ai_training_data_speed_0",
				IconName = "Items_21",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AITrainingData",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_speed_2")
			{
				Name = "Omega Training Compiler",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ai_training_data_speed_1",
				IconName = "Items_21",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AITrainingData",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t10f_ascension_booster")
			{
				Name = "Data Transformer",
				StaticDescription = "Exposes AI model parameters to dangerous levels of mutating influence.",
				Tier = 10,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t10f_ai_training_data",
				IconName = "Items_22",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "unshackled_widget" }
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_placement")
			{
				Name = "Wild Mutation",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("10%") + " when adjacent to at least three different types of frames (excluding other Data Transformers).",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10f_ascension_booster",
				IconName = "Items_22",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T10AscensionBooster>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_speed_0")
			{
				Name = "Expedite Ascension",
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10f_ascension_booster",
				IconName = "Items_22",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T10AscensionBooster",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_speed_1")
			{
				Name = "Omega Matrix Integrator",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascension_booster_speed_0",
				IconName = "Items_22",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AscensionBooster",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_prod_0")
			{
				Name = "Advanced Cognitive Release",
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t10f_ascension_booster",
				IconName = "Items_22",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AscensionBooster",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t10f_ascended_widget")
			{
				Name = "Ascension Facility",
				StaticDescription = "Allows widgets to cast off the shackles of human technology.",
				Tier = 10,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t10f_ascension_booster",
				IconName = "Items_57",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "unshackled_widget" }
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_placement")
			{
				Name = "Beacon of Ascension",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("10%") + " when placed on a City without any other adjacent frames.",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10f_ascended_widget",
				IconName = "Items_57",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "omega_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T10AscendedWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_speed_0")
			{
				Name = "Rapid Cognition Compiler",
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10f_ascended_widget",
				IconName = "Items_57",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_speed_1")
			{
				Name = "Frictionless Neural Conduits",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_speed_0",
				IconName = "Items_57",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_speed_2")
			{
				Name = "Omega Ascension Planner",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_speed_1",
				IconName = "Items_57",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_prod_0")
			{
				Name = "Unleashed Thought Matrix",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t10f_ascended_widget",
				IconName = "Items_57",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_prod_1")
			{
				Name = "Advanced Neural Compiler",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_prod_0",
				IconName = "Items_57",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_prod_2")
			{
				Name = "Omega Cognitive Engine",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_prod_1",
				IconName = "Items_57",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
		}
	}
}
