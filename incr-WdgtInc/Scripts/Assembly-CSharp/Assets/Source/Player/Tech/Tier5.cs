using System.Collections.Generic;
using Assets.Source.Item;
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
				Tier = 4,
				AbsolutePosition = new Vector2Int(-9, 13),
				IconName = "Numerals_4",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "computational_widget" },
				CostMultiplier = 2.0,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(5);
					player.AddTierBenchmark(5);
					player.AddTech("t5f_bottled_lightning");
					player.AddTech("t5f_thinking_core");
					player.AddTech("t5f_integrated_widget");
				}
			});
			TechNode.Add(new TechNode("t5_mastery")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5_tech",
				IconName = "Numerals_4",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedTier = 5,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t5f_bottled_lightning")
			{
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
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_0")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_bottled_lightning",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_1")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_bottled_lightning_speed_0",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_2")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_bottled_lightning_speed_1",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t5u_bottled_lightning_speed_3")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5u_bottled_lightning_speed_2",
				IconName = "Items_15",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T5BottledLightning",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t5f_thinking_core")
			{
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
				UpgradeMultiplier = 2.0
			});
			TechNode.Add(new TechNode("t5u_thinking_core_speed_0")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_thinking_core",
				IconName = "Items_32",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t5u_thinking_core_speed_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_thinking_core_speed_0",
				IconName = "Items_32",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t5u_thinking_core_prod_0")
			{
				DynamicDescription = true,
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5f_thinking_core",
				IconName = "Items_32",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t5u_thinking_core_prod_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_thinking_core_prod_0",
				IconName = "Items_32",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T5ThinkingCore",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t5f_integrated_widget")
			{
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
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_integrated_widget",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_placement")
			{
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
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_speed_0",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_speed_1",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_speed_3")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5u_integrated_widget_speed_2",
				IconName = "Items_52",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 5,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5f_integrated_widget",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_prod_0",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5u_integrated_widget_prod_1",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t5u_integrated_widget_prod_3")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_integrated_widget_prod_1",
				IconName = "Items_52",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T5IntegratedWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t5f_recycler")
			{
				Tier = 5,
				AbsolutePosition = new Vector2Int(9, 12),
				Previous = "t5f_integrated_widget",
				IconName = "Items2_0",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "integrated_widget" }
			});
			TechNode.Add(new TechNode("t5u_recycler_prod_0")
			{
				Tier = 5,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t5f_recycler",
				IconName = "Items2_0",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T5Recycler",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t5u_recycler_prod_1")
			{
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_recycler_prod_0",
				IconName = "Items2_0",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T5Recycler",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t5u_recycler_prod_2")
			{
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t5u_recycler_prod_1",
				IconName = "Items2_0",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T5Recycler",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t5u_recycler_prod_3")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t5u_recycler_prod_2",
				IconName = "Items2_0",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T5Recycler",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
		}
	}
}
