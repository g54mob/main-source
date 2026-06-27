using System;
using System.Collections.Generic;
using Restory.Data.RegularPayments;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Storages;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Visits;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.RegularPayments
{
	public class DeliveryPaymentsService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private CurrentDayVisitsQueueService currentDayVisitsService;

		private DevicesFromNpcsService deliveryService;

		private GameCalendar gameCalendar;

		private readonly Queue<RegularPaymentInfo> payments = new Queue<RegularPaymentInfo>();

		[Inject]
		private void Construct(CurrentDayVisitsQueueService currentDayVisitsService, DevicesFromNpcsService deliveryService, GameCalendar gameCalendar)
		{
			this.currentDayVisitsService = currentDayVisitsService;
			this.deliveryService = deliveryService;
			this.gameCalendar = gameCalendar;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)currentDayVisitsService)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (currentDayVisitsService.MonoShellExists())
			{
				currentDayVisitsService.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
			}
		}

		private void Init()
		{
			currentDayVisitsService.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
		}

		public void SendToDelivery(RegularPaymentInfo paymentInfo)
		{
			if ((bool)paymentInfo)
			{
				payments.Enqueue(paymentInfo);
				currentDayVisitsService.TryToAddDeliveryPaymentVisitToClosestTimePossible(paymentInfo.NpcWhoDeliversPayment);
			}
		}

		public void DeliverPaymentObject(RegularPaymentInfo paymentInfo)
		{
			deliveryService.AddInteractiveObject(paymentInfo, new RegularPaymentDeliveryDateInteractiveObjectProperty(gameCalendar.CurrentDateTime));
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (currentDayVisitsService.VisitCurrentlyInProgress.Visit is DeliveryPaymentNpcVisit && payments.TryDequeue(out var result))
			{
				deliveryService.AddInteractiveObject(result, new RegularPaymentDeliveryDateInteractiveObjectProperty(gameCalendar.CurrentDateTime));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new DeliveryPaymentsServiceSaveData
				{
					PaymentInfos = payments.ToArray()
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
				DeliveryPaymentsServiceSaveData deliveryPaymentsServiceSaveData = DataMigrationWizard.Migrate<DeliveryPaymentsServiceSaveData>(state, base.gameObject);
				payments.Clear();
				RegularPaymentInfo[] paymentInfos = deliveryPaymentsServiceSaveData.PaymentInfos;
				foreach (RegularPaymentInfo item in paymentInfos)
				{
					payments.Enqueue(item);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
