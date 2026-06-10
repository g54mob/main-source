using System;
using System.Collections;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.View;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class BuildingsPool : MonoSingleton<BuildingsPool>, IObserver
	{
		[SerializeField]
		private Transform parent;

		private readonly Vector3 pooledObjectPosition = new Vector3(0f, 200f, 0f);

		[NonSerialized]
		private readonly Dictionary<BaseBuildingBlueprint, Transform> parents = new Dictionary<BaseBuildingBlueprint, Transform>();

		private Dictionary<string, Queue<BaseBuildingViewComponent>> poolDictionary;

		private Dictionary<string, int> maxPoolCount;

		private Dictionary<string, List<BaseBuildingViewComponent>> used;

		private PrefabRepository prefabRepository;

		private bool allPoolsCreated;

		public BaseBuildingViewComponent Take(string id)
		{
			if (!poolDictionary.ContainsKey(id))
			{
				Refill(GetBuildableBase(id));
			}
			if (poolDictionary[id].Count == 0)
			{
				Refill(GetBuildableBase(id));
			}
			BaseBuildingViewComponent baseBuildingViewComponent = poolDictionary[id].Dequeue();
			while (baseBuildingViewComponent == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Null spotted in BuildingPool '");
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral("'.");
				}
				Log.Warning(messageBuilder);
				if (poolDictionary[id].Count == 0)
				{
					Refill(GetBuildableBase(id));
				}
				baseBuildingViewComponent = poolDictionary[id].Dequeue();
			}
			baseBuildingViewComponent?.gameObject.SetActive(value: true);
			baseBuildingViewComponent.ExitPool();
			AddToUsed(id, baseBuildingViewComponent);
			return baseBuildingViewComponent;
		}

		public void Return(BaseBuildingViewComponent item, BaseBuildingBlueprint buildableBase)
		{
			if (item == null)
			{
				Log.Error(buildableBase.GetID() + " game object is null when returning to pool!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
				return;
			}
			GameObject gameObject = item.gameObject;
			string iD = buildableBase.GetID();
			if (!poolDictionary.ContainsKey(iD))
			{
				poolDictionary.Add(iD, new Queue<BaseBuildingViewComponent>());
			}
			if (poolDictionary[iD].Count >= buildableBase.MaxPoolCount)
			{
				RemoveFromUsed(iD, item);
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
			item.EnterPool();
			RemoveFromUsed(iD, item);
			gameObject.SetActive(value: false);
			gameObject.transform.position = pooledObjectPosition;
			poolDictionary[iD].Enqueue(item);
		}

		public void Refill(BaseBuildingBlueprint buildableBase)
		{
			if (!(buildableBase == null))
			{
				int num = 0;
				if (poolDictionary.ContainsKey(buildableBase.GetID()))
				{
					num = poolDictionary[buildableBase.GetID()].Count;
				}
				if (num <= buildableBase.RefillThreshold && num <= buildableBase.RefillThreshold)
				{
					StartCoroutine(Refill(buildableBase, buildableBase.MaxPoolCount - num));
				}
			}
		}

		public bool IsUsed(string poolId, BaseBuildingViewComponent view)
		{
			if (!used.TryGetValue(poolId, out var value))
			{
				return false;
			}
			return value.Contains(view);
		}

		private void AddToUsed(string poolId, BaseBuildingViewComponent poolObject)
		{
			if (!used.ContainsKey(poolId))
			{
				used.Add(poolId, new List<BaseBuildingViewComponent>());
			}
			used[poolId].Add(poolObject);
		}

		private void RemoveFromUsed(string poolId, BaseBuildingViewComponent poolObject)
		{
			if (used.TryGetValue(poolId, out var value))
			{
				value.Remove(poolObject);
			}
		}

		private void OnMainSceneLeaving()
		{
			StopAllCoroutines();
			foreach (string key in used.Keys)
			{
				List<BaseBuildingViewComponent> list = used[key];
				while (list.Count > 0)
				{
					BaseBuildingViewComponent baseBuildingViewComponent = list[0];
					list.RemoveAt(0);
					if (baseBuildingViewComponent == null)
					{
						Log.Trace("dPool object is null when returning to pool!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
					}
					else if (baseBuildingViewComponent.BaseBuildingInstance == null || baseBuildingViewComponent.BaseBuildingInstance.Blueprint == null)
					{
						bool isEnabled;
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("BaseBuildingInstance is null when returning to pool for GO ");
							messageBuilder.AppendFormatted(baseBuildingViewComponent.name);
							messageBuilder.AppendLiteral("!");
						}
						Log.Trace(messageBuilder);
						UnityEngine.Object.DestroyImmediate(baseBuildingViewComponent.gameObject);
					}
					else
					{
						Return(baseBuildingViewComponent, baseBuildingViewComponent.BaseBuildingInstance.Blueprint);
						baseBuildingViewComponent.OnLeavingMainScene();
					}
				}
			}
		}

		private IEnumerator Refill(BaseBuildingBlueprint buildableBase, int amount)
		{
			int increment = 50;
			int stepCounter = 0;
			for (int i = 0; i < amount; i++)
			{
				stepCounter++;
				if (stepCounter == increment)
				{
					stepCounter = 0;
					yield return new WaitForEndOfFrame();
				}
				if (poolDictionary.ContainsKey(buildableBase.GetID()) && poolDictionary[buildableBase.GetID()].Count >= buildableBase.MaxPoolCount)
				{
					break;
				}
				AddItem(buildableBase);
			}
			yield return null;
		}

		private IEnumerator AddItems(IEnumerable<BaseBuildingBlueprint> buildables)
		{
			DebugTimer.StartTimer("PoolAddItems");
			allPoolsCreated = false;
			int count = 0;
			int maxObjectsToAllocateInFrame = 15;
			foreach (BaseBuildingBlueprint item in buildables)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(6, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Found ");
					messageBuilder.AppendFormatted(item.GetID());
				}
				Log.Trace(messageBuilder);
				if (!poolDictionary.ContainsKey(item.GetID()))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("   - ");
						messageBuilder.AppendFormatted(item.GetID());
						messageBuilder.AppendLiteral(" added todictionary");
					}
					Log.Trace(messageBuilder);
					poolDictionary.Add(item.GetID(), new Queue<BaseBuildingViewComponent>());
				}
				maxPoolCount.Add(item.GetID(), item.MaxPoolCount);
				for (int i = 0; i < item.MaxPoolCount; i++)
				{
					AddItem(item);
					int num = count + 1;
					count = num;
					if (num % maxObjectsToAllocateInFrame == 0)
					{
						yield return new WaitForEndOfFrame();
					}
				}
			}
			allPoolsCreated = true;
			DebugTimer.EndTimer("PoolAddItems");
		}

		private Transform GetParent(BaseBuildingBlueprint blueprint)
		{
			if (parents.TryGetValue(blueprint, out var value))
			{
				return value;
			}
			GameObject obj = new GameObject();
			obj.transform.parent = parent;
			obj.name = blueprint.GetID();
			GameObject gameObject = obj;
			parents.Add(blueprint, gameObject.transform);
			return gameObject.transform;
		}

		private void AddItem(BaseBuildingBlueprint buildableBase)
		{
			GameObject byAddress = prefabRepository.GetByAddress(buildableBase.PrefabID);
			bool isEnabled;
			if (byAddress == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Prefab ");
					messageBuilder.AppendFormatted(buildableBase.PrefabID);
					messageBuilder.AppendLiteral(" not found ");
					messageBuilder.AppendFormatted(buildableBase.GetID());
					messageBuilder.AppendLiteral("!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(byAddress, GetParent(buildableBase), worldPositionStays: true);
			gameObject.transform.position = pooledObjectPosition;
			gameObject.transform.rotation = Quaternion.identity;
			HandleEventPropComponents(buildableBase, gameObject);
			BaseBuildingViewComponent component = gameObject.GetComponent<BaseBuildingViewComponent>();
			if (component == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Building prefab ");
					messageBuilder.AppendFormatted(buildableBase.GetID());
					messageBuilder.AppendLiteral(" not found in pool.");
				}
				Log.Warning(messageBuilder);
				return;
			}
			component.EnterPool();
			gameObject.SetActive(value: false);
			if (!poolDictionary.ContainsKey(buildableBase.GetID()))
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(97, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("BuildingsPool: Id ");
					messageBuilder.AppendFormatted(buildableBase.GetID());
					messageBuilder.AppendLiteral(" does not exist in poolDictionary while adding item, this should never happen. ");
				}
				Log.Warning(messageBuilder);
				poolDictionary.Add(buildableBase.GetID(), new Queue<BaseBuildingViewComponent>());
			}
			poolDictionary[buildableBase.GetID()].Enqueue(component);
		}

		private static void HandleEventPropComponents(BaseBuildingBlueprint buildableBase, GameObject poolPrefab)
		{
			if (string.IsNullOrEmpty(buildableBase.EventPropsId))
			{
				return;
			}
			BuildingEventProp byID = Repository<BuildingEventPropsRepository, BuildingEventProp>.Instance.GetByID(buildableBase.EventPropsId);
			if (byID == null)
			{
				return;
			}
			TransformSettings[] storagePositions = byID.StoragePositions;
			if (storagePositions != null && storagePositions.Length > 0)
			{
				GameObject defaultEmpty = GameObjectPool.GetDefaultEmpty(returnActive: true, "FurnitureEventStorageView");
				defaultEmpty.transform.SetParent(poolPrefab.transform, worldPositionStays: false);
				storagePositions = byID.StoragePositions;
				foreach (TransformSettings transformSettings in storagePositions)
				{
					GameObject defaultEmpty2 = GameObjectPool.GetDefaultEmpty(returnActive: true, transformSettings.GetID());
					defaultEmpty2.transform.SetParent(defaultEmpty.transform, worldPositionStays: false);
					transformSettings.ApplyToTransform(defaultEmpty2.transform);
				}
				defaultEmpty.AddComponent<ClickDetection>();
				defaultEmpty.AddComponent<FurnitureEventStorageView>();
			}
			if (!string.IsNullOrEmpty(byID.EventPropsPrefabId))
			{
				GameObject defaultEmpty3 = GameObjectPool.GetDefaultEmpty(returnActive: true, "FurnitureEventPropsView");
				defaultEmpty3.transform.SetParent(poolPrefab.transform, worldPositionStays: false);
				GameObjectPool.Get(byID.EventPropsPrefabId, returnActive: false, byID.EventPropsPrefabId).transform.SetParent(defaultEmpty3.transform, worldPositionStays: false);
				defaultEmpty3.AddComponent<FurnitureEventPropsView>();
			}
		}

		private void Start()
		{
			prefabRepository = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance;
			poolDictionary = new Dictionary<string, Queue<BaseBuildingViewComponent>>();
			maxPoolCount = new Dictionary<string, int>();
			used = new Dictionary<string, List<BaseBuildingViewComponent>>();
			InitializePool();
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
			}
			if (poolDictionary != null)
			{
				foreach (Queue<BaseBuildingViewComponent> value in poolDictionary.Values)
				{
					value.Clear();
				}
				poolDictionary.Clear();
			}
			if (used == null)
			{
				return;
			}
			foreach (List<BaseBuildingViewComponent> value2 in used.Values)
			{
				value2.Clear();
			}
			used.Clear();
		}

		private BaseBuildingBlueprint GetBuildableBase(string id)
		{
			return Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(id);
		}

		private void InitializePool()
		{
			Log.Debug("Initializing pool...", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingsPool.cs");
			StartCoroutine(AddItems(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetAllItems()));
		}

		public string GetDebugInfo(string filterString, bool onlyShowOutOfPool)
		{
			return string.Empty;
		}
	}
}
