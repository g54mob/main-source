using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public abstract class ComponentBaseManager<TComponent, TComponentInstance> where TComponent : BaseComponent where TComponentInstance : BaseComponentInstance
	{
		protected ConcurrentDictionary<Vec3Int, TComponentInstance> PositionInstanceDictionary = new ConcurrentDictionary<Vec3Int, TComponentInstance>();

		protected ConcurrentDictionary<TComponentInstance, TComponent> InstanceComponentDictionary = new ConcurrentDictionary<TComponentInstance, TComponent>();

		protected ConcurrentDictionary<WorldObject, TComponentInstance> WorldObjectComponentInstanceDictionary = new ConcurrentDictionary<WorldObject, TComponentInstance>();

		protected readonly VillageMap Map;

		public int ComponentCount => InstanceComponentDictionary.Keys.Count;

		public ConcurrentDictionary<Vec3Int, TComponentInstance> PositionInstance => PositionInstanceDictionary;

		public ConcurrentDictionary<TComponentInstance, TComponent> InstanceComponent => InstanceComponentDictionary;

		public IEnumerable<TComponentInstance> ComponentInstances => InstanceComponentDictionary.Keys;

		public IEnumerable<WorldObject> WorldObjects => WorldObjectComponentInstanceDictionary.Keys;

		protected ComponentBaseManager(VillageMap map)
		{
			Map = map;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
		}

		public bool Exists(Vec3Int gridPos)
		{
			return PositionInstanceDictionary.ContainsKey(gridPos);
		}

		public virtual void Dispose()
		{
			PositionInstanceDictionary.Clear();
			PositionInstanceDictionary = null;
			InstanceComponentDictionary.Clear();
			InstanceComponentDictionary = null;
			WorldObjectComponentInstanceDictionary.Clear();
			WorldObjectComponentInstanceDictionary = null;
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnWorkerRemoved;
			}
		}

		public IEnumerable<WorldObject> IterateComponentWorldObjects(Predicate<TComponentInstance> condition = null)
		{
			foreach (var (worldObject2, val2) in WorldObjectComponentInstanceDictionary)
			{
				if (!worldObject2.HasDisposed && val2 != null && !val2.HasDisposed && (condition == null || condition(val2)))
				{
					yield return worldObject2;
				}
			}
		}

		public TComponent GetComponent(TComponentInstance componentInstance)
		{
			if (componentInstance == null)
			{
				return null;
			}
			InstanceComponentDictionary.TryGetValue(componentInstance, out var value);
			return value;
		}

		public TComponentInstance GetComponentInstance(WorldObject worldObject)
		{
			if (worldObject == null)
			{
				return null;
			}
			WorldObjectComponentInstanceDictionary.TryGetValue(worldObject, out var value);
			return value;
		}

		public TComponentInstance GetComponentInstance(Vec3Int pos)
		{
			PositionInstanceDictionary.TryGetValue(pos, out var value);
			return value;
		}

		public TComponentInstance GetComponentInstance(int id)
		{
			return InstanceComponent.Keys.FirstOrDefault((TComponentInstance component) => component.UniqueID == id);
		}

		public virtual void AddToCache(TComponent component, TComponentInstance componentInstance)
		{
			Map.VillageInstance.WorldObjectStorage.ComponentInstances.Add(componentInstance);
			InstanceComponentDictionary.TryAdd(componentInstance, component);
			WorldObjectComponentInstanceDictionary.TryAdd(componentInstance.OwnerBuilding, componentInstance);
			foreach (Vec3Int position in componentInstance.Positions)
			{
				PositionInstanceDictionary.TryAdd(position, componentInstance);
			}
		}

		public virtual void RemoveFromCache(TComponentInstance componentInstance)
		{
			InstanceComponentDictionary.Remove(componentInstance);
			WorldObjectComponentInstanceDictionary.Remove(componentInstance.OwnerBuilding);
			foreach (Vec3Int position in componentInstance.Positions)
			{
				PositionInstanceDictionary.Remove(position);
			}
			Map.VillageInstance.WorldObjectStorage.ComponentInstances.Remove(componentInstance);
		}

		protected virtual void OnGameLoaded(bool fromSave)
		{
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnWorkerRemoved;
		}

		protected virtual void OnWorkerRemoved(HumanoidInstance humanoidInstance)
		{
		}
	}
}
