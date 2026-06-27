using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Restory.Data.RegularPayments;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.RegularPayments
{
	public class RegularPaymentsService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		private GameCalendar gameCalendar;

		private WindowShuttersStoreInteractiveItem windowShutters;

		private DeliveryPaymentsService deliveryPaymentsService;

		private readonly List<RegularPaymentRecord> activePayments = new List<RegularPaymentRecord>();

		[Inject]
		private void Construct(GameCalendar gameCalendar, WindowShuttersStoreInteractiveItem windowShutters, DeliveryPaymentsService deliveryPaymentsService)
		{
			this.gameCalendar = gameCalendar;
			this.windowShutters = windowShutters;
			this.deliveryPaymentsService = deliveryPaymentsService;
		}

		private void OnDisable()
		{
			if (windowShutters.MonoShellExists())
			{
				windowShutters.OnIsOpenStatusChanged -= ResolveWindowOpenStatusChanged;
			}
		}

		public void AddNewRegularPayment(RegularPaymentInfo paymentInfo, bool sendFirstBillImmediately = false)
		{
			if (!paymentInfo)
			{
				return;
			}
			foreach (RegularPaymentRecord activePayment in activePayments)
			{
				if (activePayment.PaymentInfo.ID == paymentInfo.ID)
				{
					return;
				}
			}
			activePayments.Add(new RegularPaymentRecord
			{
				PaymentInfo = paymentInfo,
				NextPaymentDayNumber = gameCalendar.CurrentDayNumber + paymentInfo.DaysBeforeNextPayment
			});
			if (sendFirstBillImmediately)
			{
				SendToDelivery(paymentInfo);
			}
		}

		public void RemoveExistingRegularPayment(RegularPaymentInfo paymentInfo)
		{
			if (!paymentInfo)
			{
				return;
			}
			for (int num = activePayments.Count - 1; num >= 0; num--)
			{
				if (activePayments[num].PaymentInfo.ID == paymentInfo.ID)
				{
					activePayments.RemoveAt(num);
					break;
				}
			}
		}

		public void SendBillsIfTimeIsDue()
		{
			if (!windowShutters.WasWindowOpenAtLeastOnce)
			{
				return;
			}
			foreach (RegularPaymentRecord activePayment in activePayments)
			{
				if (activePayment.NextPaymentDayNumber <= gameCalendar.CurrentDayNumber)
				{
					SendBillToDelivery(activePayment);
				}
			}
		}

		private void SendBillToDelivery(RegularPaymentRecord paymentRecord)
		{
			SendToDelivery(paymentRecord.PaymentInfo);
			paymentRecord.NextPaymentDayNumber = gameCalendar.CurrentDayNumber + paymentRecord.PaymentInfo.DaysBeforeNextPayment;
		}

		private void SendToDelivery(RegularPaymentInfo paymentInfo)
		{
			deliveryPaymentsService.SendToDelivery(paymentInfo);
		}

		private void ResolveWindowOpenStatusChanged()
		{
			if (windowShutters.IsWindowOpen)
			{
				windowShutters.OnIsOpenStatusChanged -= ResolveWindowOpenStatusChanged;
				ResetActivePaymentsSchedule();
			}
		}

		private void ResetActivePaymentsSchedule()
		{
			foreach (RegularPaymentRecord activePayment in activePayments)
			{
				activePayment.NextPaymentDayNumber = gameCalendar.CurrentDayNumber + activePayment.PaymentInfo.DaysBeforeNextPayment;
			}
		}

		[UsedImplicitly]
		private string GetRegularPaymentsStatus()
		{
			if (!windowShutters)
			{
				return string.Empty;
			}
			if (!windowShutters.WasWindowOpenAtLeastOnce)
			{
				return "Payments are inactive, because the store has never been opened.";
			}
			return "Payments are active.";
		}

		public object CaptureState()
		{
			try
			{
				return new RegularPaymentsServiceSaveData
				{
					Payments = activePayments.ToArray()
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
				activePayments.Clear();
				RegularPaymentsServiceSaveData regularPaymentsServiceSaveData = DataMigrationWizard.Migrate<RegularPaymentsServiceSaveData>(state, base.gameObject);
				activePayments.AddRange(regularPaymentsServiceSaveData.Payments);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (!windowShutters.WasWindowOpenAtLeastOnce)
			{
				windowShutters.OnIsOpenStatusChanged += ResolveWindowOpenStatusChanged;
			}
		}
	}
}
