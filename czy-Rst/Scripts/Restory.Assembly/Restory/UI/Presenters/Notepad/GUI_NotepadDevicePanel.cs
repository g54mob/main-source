using Restory.Data.Devices;
using Restory.Data.Localization;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.UI.Views.Notepad;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notepad
{
	public sealed class GUI_NotepadDevicePanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_NotepadDevicePanelView view;

		private WorkOrdersService workOrdersService;

		private WorkOrdersPricesTableProvidingService workOrdersPricesTable;

		private EmailOrdersService emailOrdersService;

		private LocalizationSystem localizationSystem;

		private GameCalendar gameCalendar;

		[Inject]
		private void Construct(WorkOrdersService workOrdersService, WorkOrdersPricesTableProvidingService workOrdersPricesTable, EmailOrdersService emailOrdersService, LocalizationSystem localizationSystem, GameCalendar gameCalendar)
		{
			this.workOrdersService = workOrdersService;
			this.workOrdersPricesTable = workOrdersPricesTable;
			this.emailOrdersService = emailOrdersService;
			this.localizationSystem = localizationSystem;
			this.gameCalendar = gameCalendar;
		}

		public void SetCurrentDeviceInfo(DeviceContainer deviceContainer)
		{
			TrackedEmailOrder trackedOrder;
			if (workOrdersService.TryToGetWorkOrderForDeviceContainer(deviceContainer, out var workOrder))
			{
				workOrdersPricesTable.TryGetWorkOrderPaymentAmount(workOrder.RewardID, out var moneyAmount);
				int daysInWork = (gameCalendar.CurrentDateTime - workOrder.AssignedDateTime).Days + 1;
				view.SetNpcOrderInfo(workOrder.NpcOriginalCustomer.Icon, localizationSystem.GetTranslation(workOrder.NpcOriginalCustomer.NameLocalizationKey), localizationSystem.GetTranslation(deviceContainer.Device.Info.NameLocalizationKey), localizationSystem.GetTranslation(deviceContainer.Quality.LocalizationKey), GetWorkTypesText(deviceContainer, workOrder), moneyAmount, daysInWork);
			}
			else if (emailOrdersService.TryToGetOrderForDeviceContainer(deviceContainer, out trackedOrder))
			{
				IPriceOverride foundProperty;
				int reward = ((!deviceContainer.AdditionalProperties.TryToGetProperty<IPriceOverride>(out foundProperty)) ? deviceContainer.Device.Info.DefaultPrice : foundProperty.PriceOverride);
				int daysInWork2 = (gameCalendar.CurrentDateTime - trackedOrder.Order.DeviceDeliveredToStoreDateTime).Days + 1;
				view.SetEmailOrderInfo(localizationSystem.GetTranslation(deviceContainer.Device.Info.NameLocalizationKey), trackedOrder.Order.SenderContactInfo.EmailAddress, localizationSystem.GetTranslation(deviceContainer.Quality.LocalizationKey), trackedOrder.Order.WorkTypes.GetTranslationForWholeCollection(localizationSystem), reward, daysInWork2, trackedOrder.Order.NumberDaysToComplete);
			}
			else
			{
				view.SetDeviceInfo(localizationSystem.GetTranslation(deviceContainer.Device.Info.NameLocalizationKey), localizationSystem.GetTranslation(deviceContainer.Quality.LocalizationKey), deviceContainer.Device.Info.DefaultPrice);
			}
		}

		public void SetVisibility(bool shouldBeVisible)
		{
			view.SetVisibility(shouldBeVisible);
		}

		public void Clear()
		{
			view.Clear();
		}

		private string GetWorkTypesText(DeviceContainer deviceContainer, WorkOrderBase workOrder)
		{
			if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
			{
				if (workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder)
				{
					foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
					{
						if (device.DeviceContainer == deviceContainer)
						{
							return device.WorkTypes.GetTranslationForWholeCollection(localizationSystem);
						}
					}
					return string.Empty;
				}
				return string.Empty;
			}
			return cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes.GetTranslationForWholeCollection(localizationSystem);
		}
	}
}
