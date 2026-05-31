using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
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
				Name = "Tier 11 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 10,
				AbsolutePosition = new Vector2Int(-9, 31),
				IconName = "Numerals_10",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "ascended_widget" },
				CostMultiplier = 3.5f,
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
				Name = "Tier 11 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 11 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11_tech",
				IconName = "Numerals_10",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedTier = 11,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t11u_frame_cost")
			{
				Name = "Absolute Dominion",
				StaticDescription = "Reduces the exponential cost increase of building frames.",
				Tier = 11,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t11_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" }
			});
			TechNode.Add(new TechNode("t11f_power")
			{
				Name = "Perpetual Motion Engine",
				StaticDescription = "Exploits a little-known bug in physics to generate infinite power.",
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
				Name = "Glitch in the System",
				StaticDescription = "Increases power generation speed by " + UIHelper.HighlightText("25%") + " for each adjacent unique frame type (except other Perpetual Motion Engines).",
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
				UpgradeMultiplier = 0.25f
			});
			TechNode.Add(new TechNode("t11u_power_prod_0")
			{
				Name = "Physics Engine Decoder",
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_power",
				IconName = "Items_47",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T11Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t11u_power_prod_1")
			{
				Name = "Omega Limit Break",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11u_power_prod_0",
				IconName = "Items_47",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t11f_sentient_core")
			{
				Name = "Sentience Facility",
				StaticDescription = "Unlocks the path towards true sentient technology.",
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
				Name = "Myriad Landscape",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("5%") + " for each unique adjacent terrain.",
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
				UpgradeMultiplier = 0.05f
			});
			TechNode.Add(new TechNode("t11u_sentient_core_speed_0")
			{
				Name = "Sentience Recombobulator",
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11f_sentient_core",
				IconName = "Items_34",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T11SentientCore",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t11u_sentient_core_prod_0")
			{
				Name = "Omega Thought Processor",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_sentient_core",
				IconName = "Items_34",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11SentientCore",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t11f_picoprocessor")
			{
				Name = "Picoscale Lab",
				StaticDescription = "The next step in miniaturized electronics, achieved by etching circuitry on individual atoms.",
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
				Name = "Generational Uplift",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("5%") + " for each adjacent Circuit Fab, Processor Lab or Nanoscale Lab.",
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
				UpgradeMultiplier = 0.05f
			});
			TechNode.Add(new TechNode("t11u_picoprocessor_speed_0")
			{
				Name = "Enhanced Production Algorithms",
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11f_picoprocessor",
				IconName = "Items_43",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T11Picoprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t11u_picoprocessor_prod_0")
			{
				Name = "Omega Yield Enhancer",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_picoprocessor",
				IconName = "Items_43",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11Picoprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t11f_sentient_widget")
			{
				Name = "Sentience Aggregator",
				StaticDescription = "A new beginning for all of widgetkind: The gift of sentience that had been denied them all along.",
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
				Name = "Stepping Stone To Greatness",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("10%") + " if placed adjacent to at least one Omega Project Assembler.",
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
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_speed_0")
			{
				Name = "Thought Enhancer Matrix",
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t11f_sentient_widget",
				IconName = "Items_58",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_speed_1")
			{
				Name = "Omega Sentience Circuitry",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11u_sentient_widget_speed_0",
				IconName = "Items_58",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_prod_0")
			{
				Name = "Processor Sharing System",
				Tier = 11,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t11f_sentient_widget",
				IconName = "Items_58",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
			TechNode.Add(new TechNode("t11u_sentient_widget_prod_1")
			{
				Name = "Omega Assembly Lab",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t11u_sentient_widget_prod_0",
				IconName = "Items_58",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T11SentientWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.05f
			});
		}
	}
}
