using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.Visits;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shipment
{
	public class DecorShippingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent, IShipmentClaimingVisitRequester, IInitializable, IDisposable
	{
		private CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private CashMoneyService cashMoneyService;

		private DecorPacker decorPacker;

		private GameStatisticsService gameStatistics;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private InteractiveObjectFactory interactiveObjectFactory;

		private ShipmentService shipmentService;

		private readonly List<DecorShipmentPack> trackedDecorPacks = new List<DecorShipmentPack>();

		private DecorShippingServiceSaveData restoredState;

		private int packedZenPointsCache;

		public event Action<int> OnPackedZenPointsChanged;

		[Inject]
		private void Construct(CurrentDayVisitsQueueService currentDayVisitsQueueService, CashMoneyService cashMoneyService, DecorPacker decorPacker, GameStatisticsService gameStatistics, InteractiveObjectRegistry interactiveObjectRegistry, InteractiveObjectFactory interactiveObjectFactory, ShipmentService shipmentService)
		{
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
			this.cashMoneyService = cashMoneyService;
			this.decorPacker = decorPacker;
			this.gameStatistics = gameStatistics;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.shipmentService = shipmentService;
		}

		public void Initialize()
		{
			currentDayVisitsQueueService.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
		}

		public void Dispose()
		{
			currentDayVisitsQueueService.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
		}

		public void ProcessShipmentStorageChanged(ICollection<DecorShipmentPack> decorsReadyForShipment)
		{
			UntrackPacksNotInShipmentStorage(decorsReadyForShipment);
			TrackNewPacksInStorage(decorsReadyForShipment);
			RefreshFreeSaleClaimingVisit();
			RecalculatePackedZenPoints();
		}

		private void UntrackPacksNotInShipmentStorage(ICollection<DecorShipmentPack> decorsReadyForShipment)
		{
			for (int i = 0; i < trackedDecorPacks.Count; i++)
			{
				bool flag = false;
				foreach (DecorShipmentPack item in decorsReadyForShipment)
				{
					if (item == trackedDecorPacks[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					trackedDecorPacks.RemoveAt(i);
					i--;
				}
			}
		}

		private void TrackNewPacksInStorage(ICollection<DecorShipmentPack> decorsReadyForShipment)
		{
			foreach (DecorShipmentPack item in decorsReadyForShipment)
			{
				bool flag = false;
				foreach (DecorShipmentPack trackedDecorPack in trackedDecorPacks)
				{
					if (trackedDecorPack == item)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					trackedDecorPacks.Add(item);
				}
			}
		}

		private void RefreshFreeSaleClaimingVisit()
		{
			if (trackedDecorPacks.Count > 0)
			{
				currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
			}
			else
			{
				currentDayVisitsQueueService.TryToRemoveFreeSaleClaimingVisits(this);
			}
		}

		private void RecalculatePackedZenPoints()
		{
			int num = 0;
			foreach (DecorShipmentPack trackedDecorPack in trackedDecorPacks)
			{
				num += trackedDecorPack.DecorObject.Info.Zen;
			}
			int num2 = num - packedZenPointsCache;
			if (num2 != 0)
			{
				packedZenPointsCache = num;
				this.OnPackedZenPointsChanged?.Invoke(num2);
			}
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (!(currentDayVisitsQueueService.VisitCurrentlyInProgress.Visit is FreeSaleClaimingNpcVisit) || !currentDayVisitsQueueService.VisitCurrentlyInProgress.DidInteractionHappen || trackedDecorPacks.Count == 0)
			{
				return;
			}
			int num = 0;
			foreach (DecorShipmentPack trackedDecorPack in trackedDecorPacks)
			{
				int defaultPrice = trackedDecorPack.DecorObject.Info.DefaultPrice;
				num += defaultPrice;
				gameStatistics.ProcessCompletedDecorSale(defaultPrice, trackedDecorPack.DecorObject);
				DestroyDecorPack(trackedDecorPack);
			}
			packedZenPointsCache = 0;
			trackedDecorPacks.Clear();
			shipmentService.UpdateShipmentStorageState();
			cashMoneyService.AddMoneyFromNpcToWindowSpace(num);
		}

		private void DestroyDecorPack(DecorShipmentPack decorPack)
		{
			DecorObject decorObject = decorPacker.UnpackDecor(decorPack);
			interactiveObjectRegistry.Unregister(decorObject.InteractiveObject);
			interactiveObjectFactory.DestroyInteractiveObject(decorObject.InteractiveObject);
		}

		public object CaptureState()
		{
			try
			{
				string[] array = new string[trackedDecorPacks.Count];
				for (int i = 0; i < trackedDecorPacks.Count; i++)
				{
					array[i] = trackedDecorPacks[i].DecorObject.InteractiveObject.UniqueId;
				}
				return new DecorShippingServiceSaveData
				{
					DecorIds = array
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<DecorShippingServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			trackedDecorPacks.Clear();
			if (restoredState == null)
			{
				return;
			}
			string[] decorIds = restoredState.DecorIds;
			foreach (string decorId in decorIds)
			{
				if (TryToGetDecorById(decorId, out var decorObject) && shipmentService.TryRestoreDecorPackInShipmentStorage(decorObject, out var decorPack))
				{
					trackedDecorPacks.Add(decorPack);
					packedZenPointsCache += decorPack.DecorObject.Info.Zen;
				}
			}
			if (trackedDecorPacks.Count > 0)
			{
				currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
			}
		}

		private bool TryToGetDecorById(string decorId, out DecorObject decorObject)
		{
			decorObject = null;
			foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
			{
				if (!(key.UniqueId != decorId))
				{
					if (!key.TryGetComponent<DecorObject>(out decorObject))
					{
						Debug.LogError("interactiveObject for id " + decorId + " is not a DecorObject");
						break;
					}
					return true;
				}
			}
			return false;
		}
	}
}
