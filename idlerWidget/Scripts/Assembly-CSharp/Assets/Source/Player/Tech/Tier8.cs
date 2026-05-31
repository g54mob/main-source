using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Player.Tech
{
	public class Tier8
	{
		static Tier8()
		{
			TechNode.Add(new TechNode("t8_tech")
			{
				Name = "Tier 8 Technology",
				StaticDescription = "Unlocks all technology in this tier.",
				Tier = 7,
				AbsolutePosition = new Vector2Int(-9, 22),
				IconName = "Numerals_7",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "cloud_widget" },
				CostMultiplier = 2.5f,
				OnUnlock = delegate(GamePlayer player)
				{
					player.SetTechTier(8);
					player.AddTierBenchmark(8);
					player.AddTech("t8f_widget_particle");
					player.AddTech("t8f_nanoprocessor");
					player.AddTech("t8f_portable_reactor");
					player.AddTech("t8f_quantum_widget");
				}
			});
			TechNode.Add(new TechNode("t8_auto_upgrade")
			{
				Name = "Auto Upgrade",
				StaticDescription = "Unlocks an optional feature that automatically purchases a missing upgrade for one of your frames every 2 seconds.",
				Tier = 8,
				Previous = "t8_tech",
				RelativePosition = new Vector2Int(1, -1),
				IconName = "Items_36",
				NodeType = TechNodeType.Utility,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.DoAutoUpgrade = true;
				}
			});
			TechNode.Add(new TechNode("t8_mastery")
			{
				Name = "Tier 8 Mastery",
				StaticDescription = UIHelper.HighlightText("Doubles") + " the number of Tier 8 items crafted by hand. Also improves production of lower tiers to a lesser degree.",
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8_tech",
				IconName = "Numerals_7",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedTier = 8,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2f,
				LowerTierMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t8f_widget_particle")
			{
				Name = "Widget Minitizers",
				StaticDescription = "Shrinks down basic widgets into elementary particles.",
				Tier = 8,
				RelativePosition = new Vector2Int(4, -1),
				Previous = "t8_tech",
				IconName = "Items_18",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "cloud_widget" }
			});
			TechNode.Add(new TechNode("t8u_widget_particle_placement")
			{
				Name = "Direct Widget Insertion",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("10%") + " for each adjacent Widget Factory.",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8f_widget_particle",
				IconName = "Items_18",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T8WidgetParticle>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 0.1f
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_0")
			{
				Name = "Enhanced Particle Compressor",
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_widget_particle",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_1")
			{
				Name = "Quantum Shrink Matrix",
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_widget_particle_prod_0",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_2")
			{
				Name = "Superconducting Collider Matrix",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_widget_particle_prod_1",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_3")
			{
				Name = "Subatomic Yield Booster",
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8u_widget_particle_prod_2",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2f
			});
			TechNode.Add(new TechNode("t8f_nanoprocessor")
			{
				Name = "Nanoscale Lab",
				StaticDescription = "Scales down existing processors into the realm of nanotechnology.",
				Tier = 8,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t8f_widget_particle",
				IconName = "Items_42",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "cloud_widget" }
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_placement")
			{
				Name = "Relics of the Past",
				StaticDescription = "Increases productivity by " + UIHelper.HighlightText("15%") + " when placed on Ruins.",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8f_nanoprocessor",
				IconName = "Items_42",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T8Nanoprocessor>();
				},
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.15f
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_speed_0")
			{
				Name = "Quantum Lithography Unit",
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_nanoprocessor",
				IconName = "Items_42",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_speed_1")
			{
				Name = "Hyper-Accelerated Fabricator",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_nanoprocessor_speed_0",
				IconName = "Items_42",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_prod_0")
			{
				Name = "Precision Atom Placement",
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8f_nanoprocessor",
				IconName = "Items_42",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_prod_1")
			{
				Name = "Omega Etching System",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_nanoprocessor_prod_0",
				IconName = "Items_42",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t8f_portable_reactor")
			{
				Name = "Reactor Foundry",
				StaticDescription = "Creates compact nuclear reactors that can be integrated into other tech.",
				Tier = 8,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t8f_nanoprocessor",
				IconName = "Items_19",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "cloud_widget" }
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_placement")
			{
				Name = "Industrial Espionage",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("50%") + " when placed adjacent to a Nuclear Power Plant.",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8f_portable_reactor",
				IconName = "Items_19",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T8PortableReactor>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_speed_0")
			{
				Name = "Rapid Core Integrator",
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_portable_reactor",
				IconName = "Items_19",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_speed_1")
			{
				Name = "Omega Containment Field",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_portable_reactor_speed_0",
				IconName = "Items_19",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_prod_0")
			{
				Name = "Subatomic Power Booster",
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8f_portable_reactor",
				IconName = "Items_19",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_prod_1")
			{
				Name = "Multi-Fuel Synthesizer",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_portable_reactor_prod_0",
				IconName = "Items_19",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.1f
			});
			TechNode.Add(new TechNode("t8f_quantum_widget")
			{
				Name = "Quantum Tunneler",
				StaticDescription = "Connects all widgets through a network of linked nanoscale particles.",
				Tier = 8,
				RelativePosition = new Vector2Int(4, 0),
				Previous = "t8f_portable_reactor",
				IconName = "Items_55",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "cloud_widget" }
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_placement")
			{
				Name = "Cowboy Coding",
				StaticDescription = "Increases crafting speed by " + UIHelper.HighlightText("50%") + " when placed on a Prairie.",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8f_quantum_widget",
				IconName = "Items_55",
				GenerateIconType = "Custom",
				NodeType = TechNodeType.Placement,
				CostItems = new List<ItemType> { "ascension_booster", "ascended_widget" },
				OnUnlock = delegate(GamePlayer ply)
				{
					ply.Map.UpdatePlacementBonus<T8QuantumWidget>();
				},
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5f
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_speed_0")
			{
				Name = "Rapid Particle Integrator",
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_quantum_widget",
				IconName = "Items_55",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_speed_1")
			{
				Name = "Accelerated Entanglement",
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_speed_0",
				IconName = "Items_55",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_speed_2")
			{
				Name = "Stellar Quantum Weaver",
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_speed_1",
				IconName = "Items_55",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.4f
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_prod_0")
			{
				Name = "High-Efficiency Particle Matrix",
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8f_quantum_widget",
				IconName = "Items_55",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_prod_1")
			{
				Name = "Subatomic Yield Optimizer",
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_prod_0",
				IconName = "Items_55",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_prod_2")
			{
				Name = "Omega Entanglement Field",
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_prod_1",
				IconName = "Items_55",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.07f
			});
		}
	}
}
