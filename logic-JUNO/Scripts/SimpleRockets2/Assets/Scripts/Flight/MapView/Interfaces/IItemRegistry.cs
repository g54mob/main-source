using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits;
using ModApi.Craft;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IItemRegistry
	{
		IReadOnlyList<MapItem> Crafts { get; }

		IReadOnlyList<MapCraft> DynamicCrafts { get; }

		IReadOnlyList<MapItem> Items { get; }

		IReadOnlyList<MapOrbitLine> OrbitLines { get; }

		IReadOnlyList<MapOrbitNode> OrbitNodes { get; }

		IReadOnlyList<MapPlanet> Planets { get; }

		IReadOnlyList<MapPlayerCraft> PlayerCrafts { get; }

		MapPlanet RootPlanet { get; }

		event ItemRegistryHandler MapItemAdded;

		event ItemRegistryHandler MapItemRemoved;

		ITargetableItem FindTargetableItem(IOrbitNode orbitNode);

		MapCraft GetCraft(ICraftNode craftNode);

		MapItem GetItem(IOrbitNode node);

		MapOrbitLine GetOrbitLine(IOrbitNode orbitNode);

		MapOrbitNode GetOrbitNode(IOrbitNode node);

		MapPlanet GetPlanet(IPlanetNode planetNode);

		void PerformMapItemAction(Action<MapItem> action);

		void RegisterItem(MapItem mapItem);

		void UnregisterItem(MapItem mapItem);
	}
}
