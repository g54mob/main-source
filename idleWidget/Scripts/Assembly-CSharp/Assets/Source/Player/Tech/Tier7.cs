using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier7
	{
		static Tier7()
		{
			TechNode.Add(new TechNode("t7_tech")
			{
				Name = "Tier 7 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 6,
				AbsolutePosition = new Vector2Int(-9, 19),
				IconName = "Numerals_6",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "mainframe_widget" },
				CostMultiplier = 2.5f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(7);
					player.AddTierBenchmark(7);
					player.AddTech("t7f_uranium");
					player.AddTech("t7f_fuel_rod");
					player.AddTech("t7f_power");
					player.AddTech("t7f_cloud_widget");
				}
			});
			TechNode.Add(new TechNode("t7_mastery")
			{
				Name = "Tier 7 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 7 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7_tech",
				IconName = "Numerals_6",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedTier = 7,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7f_uranium")
			{
				Name = "Uranium Mine",
				StaticDescription = "Drills deep into the earth in search of Uranium Ore.",
				Tier = 7,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t7_tech",
				IconName = "Items_4",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_uranium_placement")
			{
				Name = "Fallout",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when placed on Sand.",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7f_uranium",
				IconName = "Items_4",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7Uranium>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_0")
			{
				Name = "Rapid Extraction Module",
				StaticDescription = "Increases uranium mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_uranium",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_1")
			{
				Name = "Nuclear Bore Engine",
				StaticDescription = "Increases uranium mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_uranium_speed_0",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_2")
			{
				Name = "Radiometric Ore Separator",
				StaticDescription = "Increases uranium mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_uranium_speed_1",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_uranium_speed_3")
			{
				Name = "Omega Mining Protocol",
				StaticDescription = "Increases uranium mining speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_uranium_speed_2",
				IconName = "Items_4",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T7Uranium",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7f_fuel_rod")
			{
				Name = "Fuel Rod Assembler",
				StaticDescription = "Separates uranium isotopes and converts them to usable fuel.",
				Tier = 7,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t7f_uranium",
				IconName = "Items_17",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_placement")
			{
				Name = "Green Energy",
				StaticDescription = "Increases production speed by " + UIHelper.HighlightText("50%") + " when placed in a Forest.",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7f_fuel_rod",
				IconName = "Items_17",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7FuelRod>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_speed_0")
			{
				Name = "Accelerated Molding Unit",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_fuel_rod",
				IconName = "Items_17",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_speed_1")
			{
				Name = "Rapid Rod Fabricator",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_fuel_rod_speed_0",
				IconName = "Items_17",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_prod_0")
			{
				Name = "Multi-Stage Refinement",
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7f_fuel_rod",
				IconName = "Items_17",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t7u_fuel_rod_prod_1")
			{
				Name = "Isotope Yield Booster",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_fuel_rod_prod_0",
				IconName = "Items_17",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "sentient_core", "sentient_widget" },
				UpgradedFrame = "T7FuelRod",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t7f_power")
			{
				Name = "Nuclear Power Plant",
				StaticDescription = "Burns fuel rods to produce usable power. Requires a massive amount of energy to get started.",
				Tier = 7,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t7f_fuel_rod",
				IconName = "Items_46",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_power_placement")
			{
				Name = "Direct Core Cooling",
				StaticDescription = "Increases power generation speed by " + UIHelper.HighlightText("25%") + " for each adjacent Water tile.",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7f_power",
				IconName = "Items_46",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7Power>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 0.25f
			});
			TechNode.Add(new TechNode("t7u_power_prod_0")
			{
				Name = "Advanced Heat Exchanger",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("30%") + ".",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_power",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.3f
			});
			TechNode.Add(new TechNode("t7u_power_prod_1")
			{
				Name = "Precision Control Rods",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("30%") + ".",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_power_prod_0",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.3f
			});
			TechNode.Add(new TechNode("t7u_power_prod_2")
			{
				Name = "Superconducting Fuel Chamber",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("30%") + ".",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_power_prod_1",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.3f
			});
			TechNode.Add(new TechNode("t7u_power_prod_3")
			{
				Name = "Quantum Efficiency Reactor",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("30%") + ".",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_power_prod_2",
				IconName = "Items_46",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T7Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.3f
			});
			TechNode.Add(new TechNode("t7f_cloud_widget")
			{
				Name = "Cloud Digitizer",
				StaticDescription = "Converts physical computer widgets into an ethereal cloud form.",
				Tier = 7,
				RelativePosition = new Vector2Int(5, 0),
				Previous = "t7f_power",
				IconName = "Items_54",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "mainframe_widget" }
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_0")
			{
				Name = "Swift Transfer Protocol",
				Tier = 7,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7f_cloud_widget",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_1")
			{
				Name = "Rapid Cloud Integrator",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_speed_0",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_2")
			{
				Name = "Hyper-Speed Data Link",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_speed_1",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_speed_3")
			{
				Name = "Omega Accelerated Digitizer",
				Tier = 12,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_cloud_widget_speed_2",
				IconName = "Items_54",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_0")
			{
				Name = "Multi-Core Upload System",
				Tier = 7,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7f_cloud_widget",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_placement")
			{
				Name = "Datacenter Access",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " when placed on a City.",
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t7u_cloud_widget_prod_0",
				IconName = "Items_54",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T7CloudWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_1")
			{
				Name = "Quantum Integration Matrix",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_prod_0",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_2")
			{
				Name = "Data Yield Optimizer",
				Tier = 11,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t7u_cloud_widget_prod_1",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t7u_cloud_widget_prod_3")
			{
				Name = "Omega Cloud Synthesizer",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t7u_cloud_widget_prod_1",
				IconName = "Items_54",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T7CloudWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
		}
	}
}
