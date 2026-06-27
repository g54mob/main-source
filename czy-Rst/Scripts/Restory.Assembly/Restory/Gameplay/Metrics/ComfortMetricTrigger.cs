using System;
using Restory.Data.Decors;
using Restory.Data.InteractiveObjects;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Recycle;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Shredders;
using Restory.Gameplay.Storages;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Metrics
{
	public class ComfortMetricTrigger : MetricTrigger, ITimeChangeReceiver, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private bool hasOverdueBillsPenaltyApplied;

		private RecycleService recycleService;

		private ShredderService shredderService;

		private InteractiveObjectContainersObserver objectContainersObserver;

		private DevicesFromNpcsService devicesFromNpcsService;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private DecorShippingService decorShippingService;

		private RegularPaymentObjectRegistry regularPaymentObjectRegistry;

		private GameCalendar gameCalendar;

		private ComfortPointsSettings comfortPointsSettings;

		[Inject]
		private void Construct(RecycleService recycleService, ShredderService shredderService, InteractiveObjectContainersObserver objectContainersObserver, DevicesFromNpcsService devicesFromNpcsService, InteractiveObjectRegistry interactiveObjectRegistry, DecorShippingService decorShippingService, RegularPaymentObjectRegistry regularPaymentObjectRegistry, GameCalendar gameCalendar, ComfortPointsSettings comfortPointsSettings)
		{
			this.recycleService = recycleService;
			this.shredderService = shredderService;
			this.objectContainersObserver = objectContainersObserver;
			this.devicesFromNpcsService = devicesFromNpcsService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.decorShippingService = decorShippingService;
			this.regularPaymentObjectRegistry = regularPaymentObjectRegistry;
			this.gameCalendar = gameCalendar;
			this.comfortPointsSettings = comfortPointsSettings;
		}

		public override void Initialize()
		{
			recycleService.OnInteractiveObjectRecycled += ResolveOnInteractiveObjectRecycled;
			shredderService.OnInteractiveObjectShredded += ResolveOnInteractiveObjectShredded;
			objectContainersObserver.OnInteractiveObjectTakenOutComplete += ResolveInteractiveObjectTakenOutComplete;
			devicesFromNpcsService.OnInteractiveObjectUnregisterFromSpawnPoint += ResolveOnInteractiveObjectUnregisterFromSpawnPoint;
			decorShippingService.OnPackedZenPointsChanged += ResolvePackedZenPointsChanged;
			gameCalendar.AddSubscriber(this);
		}

		public override void Dispose()
		{
			recycleService.OnInteractiveObjectRecycled -= ResolveOnInteractiveObjectRecycled;
			shredderService.OnInteractiveObjectShredded -= ResolveOnInteractiveObjectShredded;
			objectContainersObserver.OnInteractiveObjectTakenOutComplete -= ResolveInteractiveObjectTakenOutComplete;
			devicesFromNpcsService.OnInteractiveObjectUnregisterFromSpawnPoint -= ResolveOnInteractiveObjectUnregisterFromSpawnPoint;
			decorShippingService.OnPackedZenPointsChanged -= ResolvePackedZenPointsChanged;
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		public void ProcessTimeChanged()
		{
			bool flag = false;
			foreach (RegularPaymentObject item in regularPaymentObjectRegistry.All)
			{
				if ((bool)item && item.IsOverdue())
				{
					flag = true;
					break;
				}
			}
			if (flag != hasOverdueBillsPenaltyApplied)
			{
				hasOverdueBillsPenaltyApplied = flag;
				AddPoints(flag ? comfortPointsSettings.PointsForUnpaidBills : (-comfortPointsSettings.PointsForUnpaidBills));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new ComfortMetricTriggerSaveData
				{
					HasUnpaidBillsPenaltyApplied = hasOverdueBillsPenaltyApplied
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
				ComfortMetricTriggerSaveData comfortMetricTriggerSaveData = DataMigrationWizard.Migrate<ComfortMetricTriggerSaveData>(state, base.gameObject);
				hasOverdueBillsPenaltyApplied = comfortMetricTriggerSaveData.HasUnpaidBillsPenaltyApplied;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		private void ResolveOnInteractiveObjectRecycled(RecycleService service)
		{
			AddPoints(comfortPointsSettings.PointsPerRecycle);
		}

		private void ResolveOnInteractiveObjectShredded(ShredderService service)
		{
			AddPoints(comfortPointsSettings.PointsPerRecycle);
		}

		private void ResolveInteractiveObjectTakenOutComplete(InteractiveObjectInfo info)
		{
			if (info is DecorInfo decorInfo)
			{
				AddPoints(decorInfo.Zen);
			}
		}

		private void ResolveOnInteractiveObjectUnregisterFromSpawnPoint(InteractiveObject interactiveObject)
		{
			if (interactiveObjectRegistry.All.TryGetValue(interactiveObject, out var value) && value is DecorInfo decorInfo)
			{
				AddPoints(decorInfo.Zen);
			}
		}

		private void ResolvePackedZenPointsChanged(int packedZenDelta)
		{
			AddPoints(-packedZenDelta);
		}
	}
}
