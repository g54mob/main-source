using System.Collections.Concurrent;
using System.Collections.Generic;
using NSEipix;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class ShelfComponentManager : ComponentBaseManager<ShelfComponent, ShelfComponentInstance>
	{
		private readonly ConcurrentDictionary<ShelfComponentInstance, ShelfComponent> barrelInstanceComponent = new ConcurrentDictionary<ShelfComponentInstance, ShelfComponent>();

		private readonly ConcurrentDictionary<WorldObject, ShelfComponentInstance> worldObjectBarrelComponentInstance = new ConcurrentDictionary<WorldObject, ShelfComponentInstance>();

		private HashSet<ShelfComponentInstance> hasShelvesWithOrders = new HashSet<ShelfComponentInstance>();

		public ConcurrentDictionary<ShelfComponentInstance, ShelfComponent> BarrelInstanceComponent => barrelInstanceComponent;

		public HashSet<ShelfComponentInstance> HasShelvesWithOrders => hasShelvesWithOrders;

		public ShelfComponentManager(VillageMap map)
			: base(map)
		{
		}

		public override void AddToCache(ShelfComponent component, ShelfComponentInstance componentInstance)
		{
			base.AddToCache(component, componentInstance);
			if (componentInstance.Blueprint.Barrel)
			{
				barrelInstanceComponent.TryAdd(componentInstance, component);
				worldObjectBarrelComponentInstance.TryAdd(componentInstance.OwnerBuilding, componentInstance);
			}
		}

		public override void RemoveFromCache(ShelfComponentInstance componentInstance)
		{
			base.RemoveFromCache(componentInstance);
			if (componentInstance.Blueprint.Barrel)
			{
				barrelInstanceComponent.Remove(componentInstance);
				worldObjectBarrelComponentInstance.Remove(componentInstance.OwnerBuilding);
			}
		}

		public ShelfComponentInstance GetBarrelInstance(WorldObject worldObject)
		{
			if (worldObject == null)
			{
				return null;
			}
			worldObjectBarrelComponentInstance.TryGetValue(worldObject, out var value);
			return value;
		}
	}
}
