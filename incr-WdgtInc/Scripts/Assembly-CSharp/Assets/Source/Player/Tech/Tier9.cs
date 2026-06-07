using System.Collections.Generic;
using Assets.Source.Item;
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
				Tier = 8,
				AbsolutePosition = new Vector2Int(-9, 25),
				IconName = "Numerals_8",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "quantum_widget" },
				CostMultiplier = 3.0,
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
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9_tech",
				IconName = "Numerals_8",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedTier = 9,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t9u_frame_cost")
			{
				Tier = 9,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t9_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" }
			});
			TechNode.Add(new TechNode("t9f_helium")
			{
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
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t9u_helium_prod_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_helium",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t9u_helium_prod_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_helium_prod_0",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t9u_helium_prod_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_helium_prod_1",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t9u_helium_prod_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9u_helium_prod_2",
				IconName = "Items_5",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9Helium",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t9f_superconductor")
			{
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
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t9u_superconductor_speed_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_superconductor",
				IconName = "Items_20",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t9u_superconductor_speed_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_superconductor_speed_0",
				IconName = "Items_20",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t9u_superconductor_prod_0")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9f_superconductor",
				IconName = "Items_20",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t9u_superconductor_prod_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_superconductor_prod_0",
				IconName = "Items_20",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9Superconductor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t9f_ai_core")
			{
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
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_ai_core",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_ai_core_speed_0",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_ai_core_speed_1",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9u_ai_core_speed_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9u_ai_core_speed_2",
				IconName = "Items_33",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9AICore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9f_unshackled_widget")
			{
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
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t9f_unshackled_widget",
				IconName = "Items_56",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_speed_0",
				IconName = "Items_56",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_speed_1",
				IconName = "Items_56",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t9f_unshackled_widget",
				IconName = "Items_56",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_prod_0",
				IconName = "Items_56",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
			TechNode.Add(new TechNode("t9u_unshackled_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t9u_unshackled_widget_prod_1",
				IconName = "Items_56",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T9UnshackledWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
		}
	}
}
