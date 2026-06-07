using System.Collections.Generic;
using Assets.Source.Item;
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
				Tier = 9,
				AbsolutePosition = new Vector2Int(-9, 28),
				IconName = "Numerals_9",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "unshackled_widget" },
				CostMultiplier = 3.0,
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
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10_tech",
				IconName = "Numerals_9",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedTier = 10,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t10f_ai_training_data")
			{
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
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_speed_0")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10f_ai_training_data",
				IconName = "Items_21",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T10AITrainingData",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_speed_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ai_training_data_speed_0",
				IconName = "Items_21",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AITrainingData",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t10u_ai_training_data_speed_2")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ai_training_data_speed_1",
				IconName = "Items_21",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AITrainingData",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t10f_ascension_booster")
			{
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
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_speed_0")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10f_ascension_booster",
				IconName = "Items_22",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T10AscensionBooster",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_speed_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascension_booster_speed_0",
				IconName = "Items_22",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AscensionBooster",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t10u_ascension_booster_prod_0")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t10f_ascension_booster",
				IconName = "Items_22",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AscensionBooster",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t10f_ascended_widget")
			{
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
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t10f_ascended_widget",
				IconName = "Items_57",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_speed_0",
				IconName = "Items_57",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_speed_1",
				IconName = "Items_57",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t10f_ascended_widget",
				IconName = "Items_57",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_prod_0",
				IconName = "Items_57",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
			TechNode.Add(new TechNode("t10u_ascended_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t10u_ascended_widget_prod_1",
				IconName = "Items_57",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T10AscendedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
			TechNode.Add(new TechNode("t10f_leveler")
			{
				Tier = 10,
				RelativePosition = new Vector2Int(3, 0),
				Previous = "t10f_ascended_widget",
				IconName = "Items2_2",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "ascended_widget" }
			});
		}
	}
}
