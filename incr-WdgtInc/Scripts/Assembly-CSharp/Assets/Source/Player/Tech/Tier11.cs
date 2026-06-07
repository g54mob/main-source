using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier11
	{
		static Tier11()
		{
			TechNode.Add(new TechNode("t11_tech")
			{
				Tier = 10,
				AbsolutePosition = new Vector2Int(-9, 31),
				IconName = "Numerals_10",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "ascended_widget" },
				CostMultiplier = 3.5,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(11);
					player.AddTierBenchmark(11);
					player.AddTech("t11f_power");
					player.AddTech("t11f_sentient_core");
					player.AddTech("t11f_picoprocessor");
					player.AddTech("t11f_sentient_widget");
				}
			});
			TechNode.Add(new TechNode("t11_mastery")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11_tech",
				IconName = "Numerals_10",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedTier = 11,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t11u_frame_cost")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t11_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" }
			});
			TechNode.Add(new TechNode("t11f_power")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t11_tech",
				IconName = "Items_47",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "ascended_widget" }
			});
			TechNode.Add(new TechNode("t11u_power_placement")
			{
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11f_power",
				IconName = "Items_47",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "omega_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T11Power>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 0.25
			});
			TechNode.Add(new TechNode("t11u_power_prod_0")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_power",
				IconName = "Items_47",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T11Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t11u_power_prod_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11u_power_prod_0",
				IconName = "Items_47",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t11f_sentient_core")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t11f_power",
				IconName = "Items_34",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "ascended_widget" }
			});
			TechNode.Add(new TechNode("t11u_sentient_core_placement")
			{
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11f_sentient_core",
				IconName = "Items_34",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "omega_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T11SentientCore>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 0.05000000074505806
			});
			TechNode.Add(new TechNode("t11u_sentient_core_speed_0")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11f_sentient_core",
				IconName = "Items_34",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T11SentientCore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t11u_sentient_core_prod_0")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_sentient_core",
				IconName = "Items_34",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11SentientCore",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t11f_picoprocessor")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t11f_sentient_core",
				IconName = "Items_43",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "ascended_widget" }
			});
			TechNode.Add(new TechNode("t11u_picoprocessor_placement")
			{
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11f_picoprocessor",
				IconName = "Items_43",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "omega_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T11Picoprocessor>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 0.05000000074505806
			});
			TechNode.Add(new TechNode("t11u_picoprocessor_speed_0")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11f_picoprocessor",
				IconName = "Items_43",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T11Picoprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t11u_picoprocessor_prod_0")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_picoprocessor",
				IconName = "Items_43",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11Picoprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t11f_sentient_widget")
			{
				Tier = 11,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t11f_picoprocessor",
				IconName = "Items_58",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "ascended_widget" }
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_placement")
			{
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11f_sentient_widget",
				IconName = "Items_58",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "omega_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T11SentientWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11f_sentient_widget",
				IconName = "Items_58",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11u_sentient_widget_speed_0",
				IconName = "Items_58",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_sentient_widget",
				IconName = "Items_58",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11u_sentient_widget_prod_0",
				IconName = "Items_58",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0499999523162842
			});
		}
	}
}
