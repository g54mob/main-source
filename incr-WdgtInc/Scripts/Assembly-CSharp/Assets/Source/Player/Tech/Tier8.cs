using System.Collections.Generic;
using Assets.Source.Item;
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
				Tier = 7,
				AbsolutePosition = new Vector2Int(-9, 22),
				IconName = "Numerals_7",
				NodeType = TechNodeType.Tier,
				CostItems = new List<ItemType> { "cloud_widget" },
				CostMultiplier = 2.5,
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
			TechNode.Add(new TechNode("t8_mastery")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8_tech",
				IconName = "Numerals_7",
				GenerateIconType = "Parallel",
				NodeType = TechNodeType.Manual,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedTier = 8,
				UpgradeType = FrameUpgradeType.HandcraftingParallel,
				UpgradeMultiplier = 2.0,
				LowerTierMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t8f_widget_particle")
			{
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
				UpgradeMultiplier = 0.10000000149011612
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_0")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_widget_particle",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_1")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_widget_particle_prod_0",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_2")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_widget_particle_prod_1",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t8u_widget_particle_prod_3")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8u_widget_particle_prod_2",
				IconName = "Items_18",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T8WidgetParticle",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.2000000476837158
			});
			TechNode.Add(new TechNode("t8f_nanoprocessor")
			{
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
				UpgradeMultiplier = 1.149999976158142
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_speed_0")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_nanoprocessor",
				IconName = "Items_42",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_speed_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_nanoprocessor_speed_0",
				IconName = "Items_42",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_prod_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8f_nanoprocessor",
				IconName = "Items_42",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t8u_nanoprocessor_prod_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_nanoprocessor_prod_0",
				IconName = "Items_42",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T8Nanoprocessor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t8f_portable_reactor")
			{
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
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_speed_0")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_portable_reactor",
				IconName = "Items_19",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_core", "unshackled_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_speed_1")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_portable_reactor_speed_0",
				IconName = "Items_19",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_prod_0")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8f_portable_reactor",
				IconName = "Items_19",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "portable_reactor", "quantum_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t8u_portable_reactor_prod_1")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_portable_reactor_prod_0",
				IconName = "Items_19",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T8PortableReactor",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.100000023841858
			});
			TechNode.Add(new TechNode("t8f_quantum_widget")
			{
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
				UpgradeMultiplier = 1.5
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_speed_0")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(1, 0),
				Previous = "t8f_quantum_widget",
				IconName = "Items_55",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_speed_1")
			{
				DynamicDescription = true,
				Tier = 9,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_speed_0",
				IconName = "Items_55",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "superconductor", "unshackled_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_speed_2")
			{
				DynamicDescription = true,
				Tier = 11,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_speed_1",
				IconName = "Items_55",
				GenerateIconType = "Speed",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "picoprocessor", "sentient_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Speed,
				UpgradeMultiplier = 1.399999976158142
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_prod_0")
			{
				DynamicDescription = true,
				Tier = 8,
				RelativePosition = new Vector2Int(-1, 0),
				Previous = "t8f_quantum_widget",
				IconName = "Items_55",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "nanoprocessor", "quantum_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_prod_1")
			{
				DynamicDescription = true,
				Tier = 10,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_prod_0",
				IconName = "Items_55",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "ai_training_data", "ascended_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t8u_quantum_widget_prod_2")
			{
				DynamicDescription = true,
				Tier = 12,
				RelativePosition = new Vector2Int(0, 1),
				Previous = "t8u_quantum_widget_prod_1",
				IconName = "Items_55",
				GenerateIconType = "Productivity",
				NodeType = TechNodeType.Upgrade,
				CostItems = new List<ItemType> { "omega_widget" },
				UpgradedFrame = "T8QuantumWidget",
				UpgradeType = FrameUpgradeType.Productivity,
				UpgradeMultiplier = 1.0700000524520874
			});
			TechNode.Add(new TechNode("t8f_city_builder")
			{
				Tier = 8,
				RelativePosition = new Vector2Int(3, 0),
				Previous = "t8f_quantum_widget",
				IconName = "Items2_1",
				NodeType = TechNodeType.Frame,
				ConnectionType = TechConnectionType.Root,
				CostItems = new List<ItemType> { "quantum_widget" }
			});
		}
	}
}
