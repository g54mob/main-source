using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class ResourcePileHaulingManager : MonoSingleton<ResourcePileHaulingManager>
	{
		private enum HaulType
		{
			None = 0,
			CanBeStored = 1,
			CanBeReStored = 2
		}

		private const float QueueProcessInterval = 0.5f;

		private const int LazyReProcessAllInterval = 1666;

		private float processIntervalAccumulator;

		private bool isWorldReady;

		private HashSet<ResourcePileInstance> toProcessQueue = new HashSet<ResourcePileInstance>();

		private HashSet<ResourcePileInstance> toProcessQueueSwap = new HashSet<ResourcePileInstance>();

		private readonly object processQueueLock = new object();

		private bool isBackgroundTaskQueued;

		private ConcurrentHashSet<ResourcePileInstance> canBeStored = new ConcurrentHashSet<ResourcePileInstance>();

		private ConcurrentHashSet<ResourcePileInstance> pilesToReStore = new ConcurrentHashSet<ResourcePileInstance>();

		private Dictionary<Resource, HashSet<ResourcePileInstance>> pilesWithNoAvailableStorage = new Dictionary<Resource, HashSet<ResourcePileInstance>>();

		private readonly object canBeStoredLock = new object();

		private long lazyReProcessAllTime;

		private bool lazyReProcessOnlyUnStored;

		public int CanBeStoredCount => canBeStored.Count;

		public int CanBeReStoredCount => pilesToReStore.Count;

		public ConcurrentHashSet<ResourcePileInstance> CanBeStored => canBeStored;

		public ConcurrentHashSet<ResourcePileInstance> PilesToReStore => pilesToReStore;

		public bool IsMarkedForHauling(ResourcePileInstance pile)
		{
			if (!canBeStored.Contains(pile))
			{
				return pilesToReStore.Contains(pile);
			}
			return true;
		}

		public bool IsMarkedForReStoring(ResourcePileInstance pile)
		{
			return pilesToReStore.Contains(pile);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			canBeStored.Clear();
			pilesToReStore.Clear();
			toProcessQueue.Clear();
			toProcessQueueSwap.Clear();
			lock (canBeStoredLock)
			{
				foreach (HashSet<ResourcePileInstance> value in pilesWithNoAvailableStorage.Values)
				{
					value.Clear();
				}
				pilesWithNoAvailableStorage.Clear();
				canBeStored = null;
				pilesToReStore = null;
				toProcessQueue = null;
				toProcessQueueSwap = null;
				pilesWithNoAvailableStorage = null;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnWorldGenerated;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent -= TrackPileOnSpawn;
				MonoSingleton<ResourcePileController>.Instance.DestroyPileEvent -= OnPileDestroyed;
			}
		}

		public void TriggerLazyReProcessAll(bool quickCheck = false)
		{
			if (lazyReProcessAllTime > 0)
			{
				if (lazyReProcessOnlyUnStored && !quickCheck)
				{
					lazyReProcessOnlyUnStored = false;
				}
			}
			else
			{
				lazyReProcessAllTime = DateTime.Now.ToUnixTimeMilliseconds();
				lazyReProcessOnlyUnStored = quickCheck;
			}
		}

		public void QueueForReProcess(ResourcePileInstance pile)
		{
			lock (processQueueLock)
			{
				toProcessQueue.Add(pile);
			}
		}

		public void ResourceTakenFromStorage(ResourcePileInstance pile)
		{
			lock (canBeStoredLock)
			{
				pilesWithNoAvailableStorage.TryGetValue(pile.Blueprint, out var value);
				if (value == null)
				{
					return;
				}
				foreach (ResourcePileInstance item in value)
				{
					QueueForReProcess(item);
				}
			}
		}

		private void ReProcessAll()
		{
			if (!isWorldReady)
			{
				return;
			}
			lock (processQueueLock)
			{
				toProcessQueue.Clear();
				foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
				{
					ResourcePileInstance key = allPile.Key;
					toProcessQueue.Add(key);
				}
			}
		}

		private void ReProcessAllUnstoredAndAllowed()
		{
			if (!isWorldReady)
			{
				return;
			}
			lock (processQueueLock)
			{
				toProcessQueue.Clear();
				foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
				{
					ResourcePileInstance key = allPile.Key;
					if (!key.IsForbidden && !key.IsStoredOnStockpile())
					{
						toProcessQueue.Add(key);
					}
				}
			}
		}

		public void ForceProcessPileState(ResourcePileInstance pile)
		{
			if (pile != null)
			{
				lock (processQueueLock)
				{
					toProcessQueue.Remove(pile);
				}
				ProcessPileState(pile);
			}
		}

		private void TrackPileOnSpawn(ResourcePileInstance pile)
		{
			if (pile.IsForbidden)
			{
				return;
			}
			if ((pile.Blueprint.Category & ResourceCategory.CtgCarcass) != ResourceCategory.None)
			{
				ProcessPileState(pile);
				return;
			}
			lock (processQueueLock)
			{
				toProcessQueue.Add(pile);
			}
		}

		private void OnPileDestroyed(ResourcePileInstance pile)
		{
			if (pile.IsPlacedOnStorageBuilding || pile.IsPlacedOnStockpile() || pile.IsStoredOnStockpile())
			{
				TriggerLazyReProcessAll();
			}
			lock (processQueueLock)
			{
				toProcessQueue.Remove(pile);
			}
		}

		public void OnPileForbidStateChanged(IForbidable forbidable)
		{
			ResourcePileInstance resourcePileInstance = (ResourcePileInstance)forbidable;
			lock (processQueueLock)
			{
				if (!resourcePileInstance.IsForbidden)
				{
					toProcessQueue.Add(resourcePileInstance);
					return;
				}
				toProcessQueue.Remove(resourcePileInstance);
			}
			MarkPileForStorage(HaulType.None, resourcePileInstance);
		}

		private void Update()
		{
			if (isBackgroundTaskQueued)
			{
				return;
			}
			if (lazyReProcessAllTime > 0 && DateTime.Now.ToUnixTimeMilliseconds() - lazyReProcessAllTime >= 1666)
			{
				if (lazyReProcessOnlyUnStored)
				{
					ReProcessAllUnstoredAndAllowed();
				}
				else
				{
					ReProcessAll();
				}
				lazyReProcessAllTime = 0L;
			}
			processIntervalAccumulator += Time.deltaTime;
			if (!(processIntervalAccumulator <= 0.5f))
			{
				processIntervalAccumulator = 0f;
				isBackgroundTaskQueued = true;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(ProcessQueuedPilesWorkerCb, ProcessQueuedPilesWorkerCbDoneCallback);
			}
		}

		private bool ProcessQueuedPilesWorkerCb()
		{
			lock (processQueueLock)
			{
				HashSet<ResourcePileInstance> hashSet = toProcessQueue;
				HashSet<ResourcePileInstance> hashSet2 = toProcessQueueSwap;
				toProcessQueueSwap = hashSet;
				toProcessQueue = hashSet2;
				toProcessQueue.Clear();
			}
			ProcessQueuedPiles(toProcessQueueSwap);
			return true;
		}

		private void ProcessQueuedPilesWorkerCbDoneCallback(bool result)
		{
			isBackgroundTaskQueued = false;
		}

		private void ProcessQueuedPiles(HashSet<ResourcePileInstance> queue)
		{
			if (queue.Count == 0)
			{
				return;
			}
			foreach (ResourcePileInstance item in queue)
			{
				ProcessPileState(item);
			}
			queue.Clear();
		}

		private void ProcessPileState(ResourcePileInstance pile)
		{
			ProcessPileHaulType(pile);
		}

		private void ProcessPileHaulType(ResourcePileInstance pile)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Processing ");
				messageBuilder.AppendFormatted(pile);
			}
			Log.Trace(messageBuilder);
			if (pile.IsForbidden)
			{
				MarkPileForStorage(HaulType.None, pile);
				Log.Trace("Pile forbidden, can't be hauled", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManager.cs");
				return;
			}
			if (pile.IsStoredOnStockpile())
			{
				if (pile.PlacedOnAnimalFeeder)
				{
					MarkPileForStorage(HaulType.None, pile);
					Log.Trace("Pile placed on animal feeder, can't be hauled", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManager.cs");
					return;
				}
				if (GetHigherPriorityStorage(pile) != null)
				{
					MarkPileForStorage(HaulType.CanBeReStored, pile);
					Log.Trace("Pile can be re-stored, better storage found", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManager.cs");
					return;
				}
			}
			else if (MonoSingleton<StorageCommonManager>.Instance.CanStoreAnywhere(pile.GetStoredResource()))
			{
				MarkPileForStorage(HaulType.CanBeStored, pile);
				Log.Trace("Pile can be stored, found storage for it", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManager.cs");
				return;
			}
			MarkPileForStorage(HaulType.None, pile);
			Log.Trace("Pile can not be hauled", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManager.cs");
		}

		private void MarkPileForStorage(HaulType type, ResourcePileInstance pile)
		{
			lock (canBeStoredLock)
			{
				switch (type)
				{
				case HaulType.CanBeStored:
				{
					canBeStored.Add(pile);
					pilesToReStore.Remove(pile);
					pile.SetCanBeHauled(value: true);
					pilesWithNoAvailableStorage.TryGetValue(pile.Blueprint, out var value);
					value?.Remove(pile);
					return;
				}
				case HaulType.CanBeReStored:
				{
					canBeStored.Remove(pile);
					pilesToReStore.Add(pile);
					pile.SetCanBeHauled(value: true);
					pilesWithNoAvailableStorage.TryGetValue(pile.Blueprint, out var value2);
					value2?.Remove(pile);
					return;
				}
				}
				canBeStored.Remove(pile);
				pilesToReStore.Remove(pile);
				pile.SetCanBeHauled(value: false);
				if (!pilesWithNoAvailableStorage.ContainsKey(pile.Blueprint))
				{
					pilesWithNoAvailableStorage.Add(pile.Blueprint, new HashSet<ResourcePileInstance>());
				}
				pilesWithNoAvailableStorage[pile.Blueprint].Add(pile);
			}
		}

		private IStorage GetHigherPriorityStorage(ResourcePileInstance pile)
		{
			IStorage placedOnStorage = pile.PlacedOnStorage;
			if (placedOnStorage == null)
			{
				return null;
			}
			if (placedOnStorage.Priority == ZonePriority.VeryHigh)
			{
				return null;
			}
			return MonoSingleton<StorageCommonManager>.Instance.FindViableStorage(pile.GetStoredResource(), placedOnStorage.Priority, null);
		}

		private void OnWorldGenerated(bool afterLoad)
		{
			MonoSingleton<ResourcePileController>.Instance.SpawnPileEvent += TrackPileOnSpawn;
			MonoSingleton<ResourcePileController>.Instance.DestroyPileEvent += OnPileDestroyed;
			isWorldReady = true;
			ReProcessAll();
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnWorldGenerated;
		}
	}
}
