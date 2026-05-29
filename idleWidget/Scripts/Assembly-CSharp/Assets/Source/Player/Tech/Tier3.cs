using System.Collections.Generic;
using Assets.Behaviour.UI.Construction;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier3
	{
		static Tier3()
		{
			TechNode.Add(new TechNode("t3_tech")
			{
				Name = "Tier 3 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 2,
				AbsolutePosition = new Vector2Int(-9, 7),
				IconName = "Numerals_2",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "spinning_widget" },
				CostMultiplier = 1.5f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(3);
					player.AddTierBenchmark(3);
					player.AddTech("t3f_oil");
					player.AddTech("t3f_power");
					player.AddTech("t3f_battery");
					player.AddTech("t3f_capacitor_widget");
				}
			});
			TechNode.Add(new TechNode("t3_mastery")
			{
				Name = "Tier 3 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 3 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 3,
				AbsolutePosition = new Vector2Int(-8, 7),
				Previous = "t3_tech",
				IconName = "Numerals_2",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "power", "capacitor_widget" },
				UpgradedTier = 3,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_construction_progress")
			{
				Name = "Construction Overview",
				StaticDescription = "Adds a window that shows the progress of active construction projects in your game.",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 1),
				Previous = "t3_tech",
				IconName = "Items_27",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate
				{
					GameUI.Instance.UpdateConstructionButton();
				}
			});
			TechNode.Add(new TechNode("t3u_construction_pause")
			{
				Name = "Pause Construction",
				StaticDescription = "Enhances the Construction Overview, allowing you to pause and resume all construction globally.",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3u_construction_progress",
				IconName = "Items_27",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate
				{
					ConstructionUI.Instance?.UpdateButtonAvailability();
				}
			});
			TechNode.Add(new TechNode("t3u_construction_cancelall")
			{
				Name = "Cancel All Construction",
				StaticDescription = "Enhances the Construction Overview, allowing you to cancel all active construction projects.",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3u_construction_pause",
				IconName = "Items_27",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				OnUnlock = delegate
				{
					ConstructionUI.Instance?.UpdateButtonAvailability();
				}
			});
			TechNode.Add(new TechNode("t3u_frame_cost")
			{
				Name = "Eminent Domain",
				StaticDescription = "Reduces the exponential cost increase of building frames.",
				Tier = 3,
				RelativePosition = new Vector2Int(1, -1),
				Previous = "t3_tech",
				IconName = "Items_29",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" }
			});
			TechNode.Add(new TechNode("t3f_oil")
			{
				Name = "Oil Field",
				StaticDescription = "Pumps up oil from deep within the earth.",
				Tier = 3,
				AbsolutePosition = new Vector2Int(-4, 6),
				Previous = "t3_tech",
				IconName = "Items_2",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_oil_pressure")
			{
				Name = "Autopressurizer",
				StaticDescription = "Automatically maintains optimal oil pressure.",
				Tier = 3,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_oil",
				IconName = "Items_2",
				GenerateIconType = "Other",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				CostMultiplier = 0.5f,
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Custom,
				UpgradeFlag = 1
			});
			TechNode.Add(new TechNode("t3u_oil_placement")
			{
				Name = "Peat Oil Processing",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when placed on a Swamp tile.",
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_oil_pressure",
				IconName = "Items_2",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3Oil>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t3u_oil_speed_0")
			{
				Name = "Black Gold",
				StaticDescription = "Increases oil pump speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_oil",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_oil_speed_1")
			{
				Name = "Auxiliary Pump Stack",
				StaticDescription = "Increases oil pump speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_oil_speed_0",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_oil_speed_2")
			{
				Name = "Pipe Repressurizer",
				StaticDescription = "Increases oil pump speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_oil_speed_1",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "cloud_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_oil_speed_3")
			{
				Name = "Pressurized Storage Vats",
				StaticDescription = "Increases oil pump speed by " + UIHelper.HighlightText("50%") + ".",
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_oil_speed_2",
				IconName = "Items_2",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T3Oil",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3f_power")
			{
				Name = "Oil Power Plant",
				StaticDescription = "Burns raw oil to generate electrical power.",
				Tier = 3,
				RelativePosition = new Vector2Int(3, 0),
				Previous = "t3f_oil",
				IconName = "Items_11",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_power_placement")
			{
				Name = "Power Plant Logistics",
				StaticDescription = "Increases power generation speed by " + UIHelper.HighlightText("100%") + " when placed adjacent to at least one Oil Field and one other Oil Power Plant.",
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_power",
				IconName = "Items_11",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3Power>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 2f
			});
			TechNode.Add(new TechNode("t3u_power_prod_0")
			{
				Name = "Flame Stack",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("25%") + ".",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_power",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t3u_power_prod_1")
			{
				Name = "High Yield Compressor",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("25%") + ".",
				Tier = 4,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_power_prod_0",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t3u_power_prod_2")
			{
				Name = "Heat Recirculator",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("25%") + ".",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_power_prod_1",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "thinking_core", "integrated_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t3u_power_prod_3")
			{
				Name = "Exhaust Vent Recycler",
				StaticDescription = "Increases power generation productivity by " + UIHelper.HighlightText("25%") + ".",
				Tier = 6,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_power_prod_2",
				IconName = "Items_11",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T3Power",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t3f_battery")
			{
				Name = "Battery Assembler",
				StaticDescription = "Builds and charges batteries, enabling portable energy.",
				Tier = 3,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t3f_power",
				IconName = "Items_12",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_battery_placement")
			{
				Name = "Hydrophobia",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("25%") + " when not placed adjacent to, or on top of, Water or Swamp.",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3f_battery",
				IconName = "Items_12",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3Battery>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.25f
			});
			TechNode.Add(new TechNode("t3u_battery_speed_0")
			{
				Name = "Superjuiced Upcharger",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_battery",
				IconName = "Items_12",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_battery_speed_1")
			{
				Name = "Rapid Heat Exchanger",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_battery_speed_0",
				IconName = "Items_12",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_battery_prod_0")
			{
				Name = "Depletion Recycler",
				Tier = 4,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3f_battery",
				IconName = "Items_12",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "circuit_board", "computational_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t3u_battery_prod_1")
			{
				Name = "Monopole Battery Tech",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_battery_prod_0",
				IconName = "Items_12",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T3Battery",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t3f_capacitor_widget")
			{
				Name = "Capacitor Bank",
				StaticDescription = "Merges widget technology with a portable power source, causing them to auto-rotate.",
				Tier = 3,
				AbsolutePosition = new Vector2Int(7, 6),
				Previous = "t3f_battery",
				IconName = "Items_50",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "spinning_widget" }
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_0")
			{
				Name = "Supercharged Array",
				Tier = 3,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3f_capacitor_widget",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_1")
			{
				Name = "Rapid Discharge Fabricator",
				Tier = 5,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_speed_0",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_2")
			{
				Name = "Instantaneous Charge Module",
				Tier = 7,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_speed_1",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "fuel_rod", "cloud_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_speed_3")
			{
				Name = "Ultra-Fast Circuit Integrator",
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_capacitor_widget_speed_2",
				IconName = "Items_50",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_0")
			{
				Name = "Substable Wiring",
				Tier = 3,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3f_capacitor_widget",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "battery", "capacitor_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_placement")
			{
				Name = "Dedicated Battery Inserters",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " when adjacent to at least two Battery Assemblers, but no other Capacitor Banks.",
				Tier = 5,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t3u_capacitor_widget_prod_0",
				IconName = "Items_50",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "bottled_lightning", "integrated_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T3CapacitorWidget>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_1")
			{
				Name = "Energy Optimization Core",
				Tier = 6,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_prod_0",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "microprocessor", "mainframe_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_2")
			{
				Name = "Nano-Capacitor Synthesizer",
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t3u_capacitor_widget_prod_1",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t3u_capacitor_widget_prod_3")
			{
				Name = "High-Efficiency Capacitor Matrix",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t3u_capacitor_widget_prod_1",
				IconName = "Items_50",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T3CapacitorWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
		}
	}
}
