using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers.Selection.EventData;
using NSEipix.Base;
using NSMedieval.Layers;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Manager
{
	public abstract class MapResourceManager<T, TMapResourceInstance, TKMapResourceView> : MonoSingleton<T>, IObserver where T : MonoBehaviour where TMapResourceInstance : MapResourceInstance where TKMapResourceView : MapResourceView<TMapResourceInstance>
	{
		protected Dictionary<string, HashSet<TMapResourceInstance>> InstancesByBlueprintId = new Dictionary<string, HashSet<TMapResourceInstance>>();

		protected Dictionary<TMapResourceInstance, TKMapResourceView> ResourcesInstanceViewDictionary { get; } = new Dictionary<TMapResourceInstance, TKMapResourceView>();

		protected Dictionary<Vec3Int, TMapResourceInstance> PositionInstanceDictionary { get; } = new Dictionary<Vec3Int, TMapResourceInstance>();

		public Dictionary<TMapResourceInstance, TKMapResourceView> InstanceView => ResourcesInstanceViewDictionary;

		protected abstract TMapResourceInstance CreateInstance(string modelId, string prefabId, Vector3 position);

		protected abstract GridDataType GetGridTypeData();

		protected abstract void OnResourceDestroyed(TMapResourceInstance resourceInstace);

		protected abstract void ResourceInstantiated(TMapResourceInstance resourceInstace);

		protected abstract void ResourceInstantiated(TMapResourceInstance resourceInstace, TKMapResourceView resourceView);

		protected void OnCreateResource(string modelId, Vector3 position, string prefabId)
		{
			Log.Trace("Creating Dig Marker", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\MapResourceManager.cs");
			TMapResourceInstance resourceInstace = CreateInstance(modelId, prefabId, position);
			InstantiateResource(resourceInstace);
		}

		protected void OnCreateResourceList(List<TMapResourceInstance> staticResourceList)
		{
			foreach (TMapResourceInstance staticResource in staticResourceList)
			{
				InstantiateResource(staticResource);
			}
		}

		protected void OnDestroyResource(TMapResourceInstance resourceInstace)
		{
			if (ResourcesInstanceViewDictionary.TryGetValue(resourceInstace, out var value))
			{
				value.Dispose();
				ResourcesInstanceViewDictionary.Remove(resourceInstace);
				PositionInstanceDictionary.Remove(resourceInstace.GridDataPosition);
				RemoveFromInstancesByBlueprint(resourceInstace);
				resourceInstace.Map.RemoveFromWorld(resourceInstace);
				OnResourceDestroyed(resourceInstace);
			}
		}

		protected void OnReinstanceResource(TMapResourceInstance resourceInstace)
		{
			resourceInstace.ReInstantiate();
			InstantiateResource(resourceInstace);
		}

		protected void InstantiateResource(TMapResourceInstance resourceInstace)
		{
			if (resourceInstace == null)
			{
				return;
			}
			if (!resourceInstace.Prefab && resourceInstace.BlueprintExists)
			{
				resourceInstace.SetPrefabId(resourceInstace.GetBlueprint().PrefabIDs.FirstOrDefault());
			}
			TKMapResourceView component = Object.Instantiate(resourceInstace.Prefab, resourceInstace.GetPosition(), Quaternion.identity, base.transform).GetComponent<TKMapResourceView>();
			component.Setup(resourceInstace);
			if (!ResourcesInstanceViewDictionary.ContainsKey(resourceInstace))
			{
				ResourcesInstanceViewDictionary.Add(resourceInstace, component);
			}
			else
			{
				ResourcesInstanceViewDictionary[resourceInstace] = component;
			}
			AddToInstancesByBlueprint(resourceInstace);
			if (!PositionInstanceDictionary.ContainsKey(resourceInstace.GridDataPosition))
			{
				PositionInstanceDictionary.Add(resourceInstace.GridDataPosition, resourceInstace);
			}
			else
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(40, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\MapResourceManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("InstantiateResource: Replacing ");
					messageBuilder.AppendFormatted(PositionInstanceDictionary[resourceInstace.GridDataPosition].BlueprintId);
					messageBuilder.AppendLiteral(" @ ");
					messageBuilder.AppendFormatted(resourceInstace.GridDataPosition);
					messageBuilder.AppendLiteral(" with ");
					messageBuilder.AppendFormatted(resourceInstace.BlueprintId);
				}
				Log.Info(messageBuilder);
				PositionInstanceDictionary[resourceInstace.GridDataPosition] = resourceInstace;
			}
			resourceInstace.Map.AddToTheWorld(resourceInstace);
			ResourceInstantiated(resourceInstace);
			ResourceInstantiated(resourceInstace, component);
		}

		private void AddToInstancesByBlueprint(TMapResourceInstance resourceInstance)
		{
			string blueprintId = resourceInstance.BlueprintId;
			if (InstancesByBlueprintId.TryGetValue(blueprintId, out var value))
			{
				value.Add(resourceInstance);
				return;
			}
			InstancesByBlueprintId.Add(blueprintId, new HashSet<TMapResourceInstance>());
			InstancesByBlueprintId[blueprintId].Add(resourceInstance);
		}

		private void RemoveFromInstancesByBlueprint(TMapResourceInstance resourceInstance)
		{
			string blueprintId = resourceInstance.BlueprintId;
			if (InstancesByBlueprintId.TryGetValue(blueprintId, out var value))
			{
				value.Remove(resourceInstance);
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent -= OnSelectionHighlight;
				MonoSingleton<SelectionManager>.Instance.ForceOrderOnResourceEvent -= OnForceOrderOnResource;
				MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent -= OnOrderResourceCollectionEvent;
			}
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnOrderChangedEvent -= OnResourceOrderChanged;
			}
			if (MonoSingleton<LayerHidingManager>.IsInstantiated())
			{
				MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent -= OnLayerObjectHide;
				MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent -= OnLayerObjectShow;
			}
			ResourcesInstanceViewDictionary.Clear();
			PositionInstanceDictionary.Clear();
			foreach (HashSet<TMapResourceInstance> value in InstancesByBlueprintId.Values)
			{
				value.Clear();
			}
			InstancesByBlueprintId.Clear();
			base.OnDestroy();
		}

		protected override void Awake()
		{
			base.Awake();
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		private void OnMapLoaded(bool fromSave)
		{
			MonoSingleton<SelectionManager>.Instance.SelectionHighlightEvent += OnSelectionHighlight;
			MonoSingleton<SelectionManager>.Instance.SelectionChopEvent += OnSelectionHighlight;
			MonoSingleton<SelectionManager>.Instance.ForceOrderOnResourceEvent += OnForceOrderOnResource;
			MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent += OnOrderResourceCollectionEvent;
			MonoSingleton<SelectionManager>.Instance.OrderChopEvent += OnOrderChopEvent;
			MonoSingleton<ResourceCommonController>.Instance.OnOrderChangedEvent += OnResourceOrderChanged;
			MonoSingleton<LayerHidingManager>.Instance.LayerDownConstructablesEvent += OnLayerObjectHide;
			MonoSingleton<LayerHidingManager>.Instance.LayerUpConstructablesEvent += OnLayerObjectShow;
		}

		private void OnLayerObjectHide(float level)
		{
			foreach (KeyValuePair<TMapResourceInstance, TKMapResourceView> item in InstanceView)
			{
				item.Value.LayerObjectHide.RefreshVisibility(level);
			}
		}

		private void OnLayerObjectShow(float level)
		{
			foreach (KeyValuePair<TMapResourceInstance, TKMapResourceView> item in InstanceView)
			{
				item.Value.LayerObjectHide.RefreshVisibility(level);
			}
		}

		private void OnSelectionHighlight(OrderEventData eventData)
		{
			if (eventData.OrderType == OrderType.Chopping)
			{
				return;
			}
			foreach (KeyValuePair<TMapResourceInstance, TKMapResourceView> item in InstanceView)
			{
				TMapResourceInstance key = item.Key;
				TKMapResourceView value = item.Value;
				if (!key.HasDisposed && (int)(value.transform.position.y / (float)World.MapBlockHeight) <= MonoSingleton<World>.Instance.ElevationLevel)
				{
					if (!SelectionManager.IsWithinSelectionBounds(value.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
					{
						value.HideHighlight();
					}
					else if (!key.OrderShouldHighlightMe(eventData))
					{
						value.HideHighlight();
					}
					else if (!eventData.AffectOnlyOneLayer || (int)value.transform.position.y == (int)eventData.Y)
					{
						value.ShowHighlight();
					}
				}
			}
		}

		private void OnSelectionHighlight(PlantOrderEventData eventData)
		{
			foreach (KeyValuePair<TMapResourceInstance, TKMapResourceView> item in InstanceView)
			{
				TMapResourceInstance key = item.Key;
				TKMapResourceView value = item.Value;
				if (!key.HasDisposed && (int)(value.transform.position.y / (float)World.MapBlockHeight) <= MonoSingleton<World>.Instance.ElevationLevel)
				{
					if (!SelectionManager.IsWithinSelectionBounds(value.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
					{
						value.HideHighlight();
					}
					else if (!key.OrderShouldHighlightMe(eventData))
					{
						value.HideHighlight();
					}
					else if ((!eventData.AffectOnlyOneLayer || (int)value.transform.position.y == (int)eventData.Y) && (eventData.PlantLifePhase == PlantLifePhaseType.None || !(key is PlantMapResourceInstance plantMapResourceInstance) || plantMapResourceInstance.CurrentPhaseType == eventData.PlantLifePhase))
					{
						value.ShowHighlight();
					}
				}
			}
		}

		protected virtual void OnForceOrderOnResource(Vec3Int position)
		{
		}

		protected virtual void OnOrderResourceCollectionEvent(OrderEventData eventData)
		{
			using PooledList<TKMapResourceView> pooledList = ListPool<TKMapResourceView>.GetJanitor();
			using PooledList<PlantMapResourceInstance> pooledList2 = ListPool<PlantMapResourceInstance>.GetJanitor();
			bool flag = eventData.OrderType.Equals(OrderType.CutAllVegetation) && MonoSingleton<PlantResourceManager>.Instance.InstantCut;
			foreach (KeyValuePair<TMapResourceInstance, TKMapResourceView> item2 in InstanceView)
			{
				TMapResourceInstance key = item2.Key;
				TKMapResourceView value = item2.Value;
				if (!key.HasDisposed && (int)(value.transform.position.y / (float)World.MapBlockHeight) <= MonoSingleton<World>.Instance.ElevationLevel && SelectionManager.IsWithinSelectionBounds(value.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y) && (!eventData.AffectOnlyOneLayer || (int)value.transform.position.y == (int)eventData.Y))
				{
					if (eventData.OrderType.Equals(OrderType.Cancel))
					{
						pooledList.Add(value);
					}
					else if (flag && key is PlantMapResourceInstance item)
					{
						pooledList2.Add(item);
					}
					else
					{
						value.SelectItem(eventData.OrderType);
					}
				}
			}
			foreach (PlantMapResourceInstance item3 in pooledList2)
			{
				item3.SetLastPhase();
			}
			foreach (TKMapResourceView item4 in pooledList)
			{
				item4.CancelOrder(eventData.OrderType);
			}
		}

		protected void OnOrderChopEvent(PlantOrderEventData eventData)
		{
			using PooledList<TKMapResourceView> pooledList = ListPool<TKMapResourceView>.GetJanitor();
			using PooledList<PlantMapResourceInstance> pooledList2 = ListPool<PlantMapResourceInstance>.GetJanitor();
			bool flag = eventData.OrderType.Equals(OrderType.Chopping) && MonoSingleton<PlantResourceManager>.Instance.InstantCut;
			foreach (KeyValuePair<TMapResourceInstance, TKMapResourceView> item2 in InstanceView)
			{
				TMapResourceInstance key = item2.Key;
				TKMapResourceView value = item2.Value;
				if (key.HasDisposed || (int)(value.transform.position.y / (float)World.MapBlockHeight) > MonoSingleton<World>.Instance.ElevationLevel || !SelectionManager.IsWithinSelectionBounds(value.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y) || (eventData.AffectOnlyOneLayer && (int)value.transform.position.y != (int)eventData.Y))
				{
					continue;
				}
				if (eventData.OrderType.Equals(OrderType.Cancel))
				{
					pooledList.Add(value);
				}
				else if (eventData.PlantLifePhase == PlantLifePhaseType.None || !(key is PlantMapResourceInstance plantMapResourceInstance) || plantMapResourceInstance.CurrentPhaseType == eventData.PlantLifePhase)
				{
					if (flag && key is PlantMapResourceInstance item)
					{
						pooledList2.Add(item);
					}
					else
					{
						value.SelectItem(eventData.OrderType);
					}
				}
			}
			foreach (PlantMapResourceInstance item3 in pooledList2)
			{
				item3.SetLastPhase();
			}
			foreach (TKMapResourceView item4 in pooledList)
			{
				item4.CancelOrder(eventData.OrderType);
			}
		}

		private void OnResourceOrderChanged(MapResourceInstance instance)
		{
			if (instance is TMapResourceInstance key && InstanceView.TryGetValue(key, out var value))
			{
				value.OnOrderRefreshed();
			}
		}
	}
}
