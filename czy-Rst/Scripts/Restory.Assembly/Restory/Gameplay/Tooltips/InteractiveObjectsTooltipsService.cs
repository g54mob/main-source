using System.Collections.Generic;
using Restory.Data.Localization;
using Restory.Data.NPCs;
using Restory.Data.Tooltips;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.ObjectPools;
using Restory.UI.Views.Tooltips;
using Restory.UserInterface;
using UnityEngine;

namespace Restory.Gameplay.Tooltips
{
	public class InteractiveObjectsTooltipsService
	{
		private readonly TooltipContainer tooltipContainer;

		private readonly DeliveryBoxInitialTooltipViewPool deliveryBoxInitialTooltipViewPool;

		private readonly DeliveryBoxMainTooltipViewPool deliveryBoxMainTooltipViewPool;

		private readonly WarningTooltipViewPool warningTooltipViewPool;

		private readonly AnotherDeviceFromSameOrderInShipmentTooltipViewPool anotherDeviceFromSameOrderInShipmentTooltipViewPool;

		private readonly MoneyObjectTooltipViewPool moneyObjectTooltipViewPool;

		private readonly RegularPaymentObjectTooltipViewPool regularPaymentObjectTooltipViewPool;

		private readonly DeviceService deviceService;

		private readonly WorkOrdersService workOrdersService;

		private readonly EmailOrdersService emailOrdersService;

		private readonly LocalizationSystem localizationSystem;

		private readonly DeliveryPackTooltipsSettings deliveryPackTooltipsSettings;

		private readonly WorkOrdersPricesTableProvidingService workOrdersPricesTableProvider;

		private readonly DevicePriceEstimationService devicePriceEstimationService;

		private readonly CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker;

		private readonly WarningTooltipsSettings warningTooltipsSettings;

		private readonly RegularPaymentObjectTooltipsSettings regularPaymentObjectTooltipsSettings;

		private readonly ComfortPointsSettings comfortPointsSettings;

		private readonly GameCalendar gameCalendar;

		private readonly Dictionary<InteractiveObject, TooltipView> activeTooltips = new Dictionary<InteractiveObject, TooltipView>();

		public InteractiveObjectsTooltipsService(TooltipContainer tooltipContainer, DeliveryBoxInitialTooltipViewPool deliveryBoxInitialTooltipViewPool, DeliveryBoxMainTooltipViewPool deliveryBoxMainTooltipViewPool, AnotherDeviceFromSameOrderInShipmentTooltipViewPool anotherDeviceFromSameOrderInShipmentTooltipViewPool, MoneyObjectTooltipViewPool moneyObjectTooltipViewPool, RegularPaymentObjectTooltipViewPool regularPaymentObjectTooltipViewPool, WarningTooltipViewPool warningTooltipViewPool, DeviceService deviceService, WorkOrdersService workOrdersService, EmailOrdersService emailOrdersService, LocalizationSystem localizationSystem, DeliveryPackTooltipsSettings deliveryPackTooltipsSettings, WorkOrdersPricesTableProvidingService workOrdersPricesTableProvider, DevicePriceEstimationService devicePriceEstimationService, CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker, WarningTooltipsSettings warningTooltipsSettings, ComfortPointsSettings comfortPointsSettings, RegularPaymentObjectTooltipsSettings regularPaymentObjectTooltipsSettings, GameCalendar gameCalendar)
		{
			this.anotherDeviceFromSameOrderInShipmentTooltipViewPool = anotherDeviceFromSameOrderInShipmentTooltipViewPool;
			this.deliveryBoxMainTooltipViewPool = deliveryBoxMainTooltipViewPool;
			this.deliveryBoxInitialTooltipViewPool = deliveryBoxInitialTooltipViewPool;
			this.moneyObjectTooltipViewPool = moneyObjectTooltipViewPool;
			this.regularPaymentObjectTooltipViewPool = regularPaymentObjectTooltipViewPool;
			this.warningTooltipViewPool = warningTooltipViewPool;
			this.deliveryPackTooltipsSettings = deliveryPackTooltipsSettings;
			this.warningTooltipsSettings = warningTooltipsSettings;
			this.regularPaymentObjectTooltipsSettings = regularPaymentObjectTooltipsSettings;
			this.comfortPointsSettings = comfortPointsSettings;
			this.tooltipContainer = tooltipContainer;
			this.deviceService = deviceService;
			this.workOrdersService = workOrdersService;
			this.emailOrdersService = emailOrdersService;
			this.competitionsDeviceContainersTracker = competitionsDeviceContainersTracker;
			this.localizationSystem = localizationSystem;
			this.workOrdersPricesTableProvider = workOrdersPricesTableProvider;
			this.devicePriceEstimationService = devicePriceEstimationService;
			this.gameCalendar = gameCalendar;
		}

		public void ShowDeviceForShipmentInitialTooltip(DeviceContainer deviceContainer)
		{
			if (activeTooltips.TryGetValue(deviceContainer, out var value))
			{
				if (value is GUI_DeliveryBoxInitialTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(deviceContainer);
			}
			GUI_DeliveryBoxInitialTooltip gUI_DeliveryBoxInitialTooltip = deliveryBoxInitialTooltipViewPool.Get<GUI_DeliveryBoxInitialTooltip>();
			INpcInfo customerNpc;
			string text = (workOrdersService.TryToGetOriginalCustomerNpcByDeviceContainer(deviceContainer, out customerNpc) ? localizationSystem.GetTranslation(customerNpc.NameLocalizationKey) : string.Empty);
			if (string.IsNullOrEmpty(text))
			{
				text = (emailOrdersService.TryToGetEmailAddressByDeviceContainer(deviceContainer, out var emailAddress) ? emailAddress : string.Empty);
			}
			if (string.IsNullOrEmpty(text))
			{
				IPriceOverride foundProperty;
				int num = ((!deviceContainer.AdditionalProperties.TryToGetProperty<IPriceOverride>(out foundProperty) || foundProperty.PriceOverride < 0) ? devicePriceEstimationService.EstimateDevicePrice(deviceContainer) : foundProperty.PriceOverride);
				if (deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty2) && foundProperty2.DeviceCondition.IsPartOfCompetition)
				{
					num = (competitionsDeviceContainersTracker.WasPreviousTimeBeaten(deviceContainer) ? num : 0);
				}
				gUI_DeliveryBoxInitialTooltip.SetUp(localizationSystem.GetTranslation(deliveryPackTooltipsSettings.SellForLocalizationKey), num, deviceContainer.TooltipTargetTransform);
			}
			else
			{
				gUI_DeliveryBoxInitialTooltip.SetUpTextOnly(localizationSystem.GetTranslation(deliveryPackTooltipsSettings.GiveToLocalizationKey) + " " + text, deviceContainer.TooltipTargetTransform);
			}
			tooltipContainer.AddTooltip(gUI_DeliveryBoxInitialTooltip);
			activeTooltips.Add(deviceContainer, gUI_DeliveryBoxInitialTooltip);
		}

		public void ShowDecorForShipmentInitialTooltip(DecorObject decorObject)
		{
			if (activeTooltips.TryGetValue(decorObject.InteractiveObject, out var value))
			{
				if (value is GUI_DeliveryBoxInitialTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(decorObject.InteractiveObject);
			}
			GUI_DeliveryBoxInitialTooltip gUI_DeliveryBoxInitialTooltip = deliveryBoxInitialTooltipViewPool.Get<GUI_DeliveryBoxInitialTooltip>();
			gUI_DeliveryBoxInitialTooltip.SetUp(localizationSystem.GetTranslation(deliveryPackTooltipsSettings.SellForLocalizationKey) + " ", decorObject.Info.DefaultPrice, decorObject.InteractiveObject.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_DeliveryBoxInitialTooltip);
			activeTooltips.Add(decorObject.InteractiveObject, gUI_DeliveryBoxInitialTooltip);
		}

		public void ShowTooltip(CashMoneyObject targetMoneyObject)
		{
			if ((bool)targetMoneyObject && (!activeTooltips.TryGetValue(targetMoneyObject.InteractiveObject, out var value) || !(value is GUI_CashMoneyObjectTooltip)))
			{
				GUI_CashMoneyObjectTooltip gUI_CashMoneyObjectTooltip = moneyObjectTooltipViewPool.Get<GUI_CashMoneyObjectTooltip>();
				gUI_CashMoneyObjectTooltip.SetUp(targetMoneyObject.MoneyAmountHeld, targetMoneyObject.InteractiveObject.TooltipTargetTransform);
				tooltipContainer.AddTooltip(gUI_CashMoneyObjectTooltip);
				activeTooltips.Add(targetMoneyObject.InteractiveObject, gUI_CashMoneyObjectTooltip);
			}
		}

		public void ShowTooltip(DecorObject decorObject)
		{
			if (activeTooltips.TryGetValue(decorObject.InteractiveObject, out var value))
			{
				if (value is GUI_DeliveryBoxMainTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(decorObject.InteractiveObject);
			}
			GUI_DeliveryBoxMainTooltip gUI_DeliveryBoxMainTooltip = deliveryBoxMainTooltipViewPool.Get<GUI_DeliveryBoxMainTooltip>();
			gUI_DeliveryBoxMainTooltip.SetUp(localizationSystem.GetTranslation(deliveryPackTooltipsSettings.SellForLocalizationKey) + " ", decorObject.Info.DefaultPrice, decorObject.InteractiveObject.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_DeliveryBoxMainTooltip);
			activeTooltips.Add(decorObject.InteractiveObject, gUI_DeliveryBoxMainTooltip);
		}

		public void ShowTooltip(ShipmentDevicePack deliveryPack)
		{
			switch (deviceService.CheckDeviceReadyForShipment(deliveryPack.DeviceContainer))
			{
			case CheckDeviceReadyForShipmentResult.Fail_DeviceIsUniqueAndNotForSale:
				ShowUniqueDeviceTooltip(deliveryPack);
				break;
			case CheckDeviceReadyForShipmentResult.Fail_DeviceIsPartOfAWorkOrderWithAnotherDeviceAlreadyInShipment:
				ShowDeviceFromSameOrderIsAlreadyPackedForShipmentTooltip(deliveryPack);
				break;
			default:
				ShowDeliveryPackTooltip(deliveryPack);
				break;
			}
		}

		public void ShowTooltip(DecorShipmentPack decorPack)
		{
			if (activeTooltips.TryGetValue(decorPack, out var value))
			{
				if (value is GUI_DeliveryBoxMainTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(decorPack);
			}
			GUI_DeliveryBoxMainTooltip gUI_DeliveryBoxMainTooltip = deliveryBoxMainTooltipViewPool.Get<GUI_DeliveryBoxMainTooltip>();
			gUI_DeliveryBoxMainTooltip.SetUp(localizationSystem.GetTranslation(decorPack.DecorObject.Info.NameLocalizationKey) + " ", decorPack.DecorObject.Info.DefaultPrice, decorPack.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_DeliveryBoxMainTooltip);
			activeTooltips.Add(decorPack, gUI_DeliveryBoxMainTooltip);
		}

		public void ShowTooltip(DevicePack devicePack)
		{
			if (activeTooltips.TryGetValue(devicePack, out var value))
			{
				if (value is GUI_DeliveryBoxMainTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(devicePack);
			}
			GUI_DeliveryBoxMainTooltip gUI_DeliveryBoxMainTooltip = CreateTooltip(devicePack.DeviceContainer, devicePack.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_DeliveryBoxMainTooltip);
			activeTooltips.Add(devicePack, gUI_DeliveryBoxMainTooltip);
		}

		public void ShowTooltip(DeviceContainer deviceContainer)
		{
			if (activeTooltips.TryGetValue(deviceContainer, out var value))
			{
				if (value is GUI_DeliveryBoxMainTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(deviceContainer);
			}
			GUI_DeliveryBoxMainTooltip gUI_DeliveryBoxMainTooltip = CreateTooltip(deviceContainer, deviceContainer.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_DeliveryBoxMainTooltip);
			activeTooltips.Add(deviceContainer, gUI_DeliveryBoxMainTooltip);
		}

		public void ShowOverdueBillTooltip(RegularPaymentObject regularPaymentObject)
		{
			if (!regularPaymentObject.InteractiveObject || !regularPaymentObject.IsOverdue())
			{
				return;
			}
			if (activeTooltips.TryGetValue(regularPaymentObject.InteractiveObject, out var value))
			{
				if (value is GUI_RegularPaymentObjectTooltip { IsOverdue: not false })
				{
					return;
				}
				HideTooltipsForTargetObject(regularPaymentObject.InteractiveObject);
			}
			GUI_RegularPaymentObjectTooltip gUI_RegularPaymentObjectTooltip2 = regularPaymentObjectTooltipViewPool.Get<GUI_RegularPaymentObjectTooltip>();
			gUI_RegularPaymentObjectTooltip2.SetUpOverdueBill(localizationSystem.GetTranslation(regularPaymentObjectTooltipsSettings.PaymentIsOverdueLocalizationId), localizationSystem.GetTranslation(regularPaymentObjectTooltipsSettings.MetricAffectedByOverduePayment.NameLocalizationKey), comfortPointsSettings.PointsForUnpaidBills, regularPaymentObject.InteractiveObject.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_RegularPaymentObjectTooltip2);
			activeTooltips.Add(regularPaymentObject.InteractiveObject, gUI_RegularPaymentObjectTooltip2);
		}

		public void ShowUniqueDeviceTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.UniqueDeviceTooltipKey);
		}

		public void ShowNotIdealDeviceWarningTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.NotIdealDeviceWarningTooltipKey);
		}

		public void ShowNotIdealDeviceOfWorkOrderWarningTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.NotIdealDeviceOfWorkOrderWarningTooltipKey);
		}

		public void ShowNotIdealDeviceInBoxWarningTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.NotIdealDeviceInBoxWarningTooltipKey);
		}

		public void ShowNotIdealDeviceInBoxFleamarketWarningTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.NotIdealDeviceInBoxFleamarketWarningTooltipKey);
		}

		public void ShowUnfinishedCompetitionWarningTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.UnfinishedCompetitionBoxWarningTooltipKey);
		}

		public void ShowNotAllDeviceWorkTypesCompletedWarningTooltip(InteractiveObject targetObject)
		{
			ShowWarningTooltip(targetObject, warningTooltipsSettings.NotAllDeviceWorkTypesCompletedWarningTooltipKey);
		}

		public void ShowWarningTooltip(InteractiveObject targetObject, string textLocalizationKey)
		{
			if (!targetObject)
			{
				return;
			}
			if (activeTooltips.TryGetValue(targetObject, out var value))
			{
				if (value is GUI_WarningTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(targetObject);
			}
			GUI_WarningTooltip gUI_WarningTooltip = CreateWarningTooltip(textLocalizationKey, targetObject.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_WarningTooltip);
			activeTooltips.Add(targetObject, gUI_WarningTooltip);
		}

		public void ShowDeviceFromSameOrderIsAlreadyPackedForShipmentTooltip(InteractiveObject targetObject)
		{
			if (!targetObject)
			{
				return;
			}
			if (activeTooltips.TryGetValue(targetObject, out var value))
			{
				if (value is GUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(targetObject);
			}
			GUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip gUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip = anotherDeviceFromSameOrderInShipmentTooltipViewPool.Get<GUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip>();
			gUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip.SetUp(targetObject.TooltipTargetTransform);
			tooltipContainer.AddTooltip(gUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip);
			activeTooltips.Add(targetObject, gUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip);
		}

		private void ShowDeliveryPackTooltip(ShipmentDevicePack deliveryPack)
		{
			if (activeTooltips.TryGetValue(deliveryPack, out var value))
			{
				if (value is GUI_DeliveryBoxMainTooltip)
				{
					return;
				}
				HideTooltipsForTargetObject(deliveryPack);
			}
			GUI_DeliveryBoxMainTooltip gUI_DeliveryBoxMainTooltip = deliveryBoxMainTooltipViewPool.Get<GUI_DeliveryBoxMainTooltip>();
			if (workOrdersService.TryToGetWorkOrderForDeviceContainer(deliveryPack.DeviceContainer, out var workOrder))
			{
				workOrdersPricesTableProvider.TryGetWorkOrderPaymentAmount(workOrder.RewardID, out var moneyAmount);
				gUI_DeliveryBoxMainTooltip.SetUp((workOrder.NpcOriginalCustomer == null) ? string.Empty : localizationSystem.GetTranslation(workOrder.NpcOriginalCustomer.NameLocalizationKey), moneyAmount, deliveryPack.TooltipTargetTransform);
			}
			else
			{
				string emailAddress;
				string clientName = (emailOrdersService.TryToGetEmailAddressByDeviceContainer(deliveryPack.DeviceContainer, out emailAddress) ? emailAddress : string.Empty);
				gUI_DeliveryBoxMainTooltip.SetUp(clientName, deliveryPack.DevicePrice, deliveryPack.TooltipTargetTransform);
			}
			tooltipContainer.AddTooltip(gUI_DeliveryBoxMainTooltip);
			activeTooltips.Add(deliveryPack, gUI_DeliveryBoxMainTooltip);
		}

		public void HideTooltipsForTargetObject(InteractiveObject targetObject)
		{
			if (activeTooltips.TryGetValue(targetObject, out var value))
			{
				if (value.TryGetComponent<GUI_ScreenObjectModelFollower>(out var component))
				{
					component.Clean();
				}
				tooltipContainer.RemoveTooltip(value);
				ReleaseTooltipInstance(value);
				activeTooltips.Remove(targetObject);
			}
		}

		public void HideAllTooltips()
		{
			foreach (TooltipView value in activeTooltips.Values)
			{
				if (value.TryGetComponent<GUI_ScreenObjectModelFollower>(out var component))
				{
					component.Clean();
				}
				tooltipContainer.RemoveTooltip(value);
				ReleaseTooltipInstance(value);
			}
			activeTooltips.Clear();
		}

		private GUI_DeliveryBoxMainTooltip CreateTooltip(DeviceContainer deviceContainer, Transform tooltipTargetTransform)
		{
			GUI_DeliveryBoxMainTooltip gUI_DeliveryBoxMainTooltip = deliveryBoxMainTooltipViewPool.Get<GUI_DeliveryBoxMainTooltip>();
			WorkOrderBase workOrder;
			TrackedEmailOrder trackedOrder;
			if (deviceContainer.Package is UnlicensedDevicePackage unlicensedDevicePackage)
			{
				gUI_DeliveryBoxMainTooltip.SetUp(localizationSystem.GetTranslation(warningTooltipsSettings.LicenseRequiredWarningTooltipKey), unlicensedDevicePackage.TooltipTargetTransform);
			}
			else if (workOrdersService.TryToGetWorkOrderForDeviceContainer(deviceContainer, out workOrder))
			{
				workOrdersPricesTableProvider.TryGetWorkOrderPaymentAmount(workOrder.RewardID, out var moneyAmount);
				gUI_DeliveryBoxMainTooltip.SetUp((workOrder.NpcOriginalCustomer == null) ? string.Empty : localizationSystem.GetTranslation(workOrder.NpcOriginalCustomer.NameLocalizationKey), moneyAmount, tooltipTargetTransform);
			}
			else if (emailOrdersService.TryToGetOrderForDeviceContainer(deviceContainer, out trackedOrder))
			{
				IPriceOverride foundProperty;
				int num = (deviceContainer.AdditionalProperties.TryToGetProperty<IPriceOverride>(out foundProperty) ? foundProperty.PriceOverride : deviceContainer.Device.Info.DefaultPrice);
				if (deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty2) && foundProperty2.DeviceCondition.IsPartOfCompetition)
				{
					num = (competitionsDeviceContainersTracker.WasPreviousTimeBeaten(deviceContainer) ? num : 0);
				}
				string emailAddress;
				string clientName = (emailOrdersService.TryToGetEmailAddressByDeviceContainer(deviceContainer, out emailAddress) ? emailAddress : localizationSystem.GetTranslation(deliveryPackTooltipsSettings.CanBeSoldLocalizationKey));
				int num2 = (gameCalendar.CurrentDateTime - trackedOrder.Order.DeviceDeliveredToStoreDateTime).Days + 1;
				if (num2 > trackedOrder.Order.NumberDaysToComplete)
				{
					gUI_DeliveryBoxMainTooltip.SetUp(clientName, num, localizationSystem.GetTranslation(deliveryPackTooltipsSettings.OverdueOrderTooltipLocalizationKey), tooltipTargetTransform);
				}
				else if (num2 == trackedOrder.Order.NumberDaysToComplete)
				{
					gUI_DeliveryBoxMainTooltip.SetUp(clientName, num, localizationSystem.GetTranslation(deliveryPackTooltipsSettings.LastDayTooltipLocalizationKey), tooltipTargetTransform);
				}
				else
				{
					gUI_DeliveryBoxMainTooltip.SetUp(clientName, num, tooltipTargetTransform);
				}
			}
			else
			{
				IPriceOverride foundProperty3;
				int num3 = (deviceContainer.AdditionalProperties.TryToGetProperty<IPriceOverride>(out foundProperty3) ? foundProperty3.PriceOverride : deviceContainer.Device.Info.DefaultPrice);
				if (deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty4) && foundProperty4.DeviceCondition.IsPartOfCompetition)
				{
					num3 = (competitionsDeviceContainersTracker.WasPreviousTimeBeaten(deviceContainer) ? num3 : 0);
				}
				gUI_DeliveryBoxMainTooltip.SetUp(emailOrdersService.TryToGetEmailAddressByDeviceContainer(deviceContainer, out var emailAddress2) ? emailAddress2 : localizationSystem.GetTranslation(deliveryPackTooltipsSettings.CanBeSoldLocalizationKey), num3, tooltipTargetTransform);
			}
			return gUI_DeliveryBoxMainTooltip;
		}

		private GUI_WarningTooltip CreateWarningTooltip(string textLocalizationKey, Transform tooltipTargetTransform)
		{
			GUI_WarningTooltip gUI_WarningTooltip = warningTooltipViewPool.Get<GUI_WarningTooltip>();
			gUI_WarningTooltip.SetUp(localizationSystem.GetTranslation(textLocalizationKey), tooltipTargetTransform);
			return gUI_WarningTooltip;
		}

		private void ReleaseTooltipInstance(TooltipView tooltip)
		{
			if (!(tooltip is GUI_DeliveryBoxInitialTooltip instance))
			{
				if (!(tooltip is GUI_DeliveryBoxMainTooltip instance2))
				{
					if (!(tooltip is GUI_WarningTooltip instance3))
					{
						if (!(tooltip is GUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip instance4))
						{
							if (!(tooltip is GUI_CashMoneyObjectTooltip instance5))
							{
								if (tooltip is GUI_RegularPaymentObjectTooltip instance6)
								{
									regularPaymentObjectTooltipViewPool.Release(instance6);
								}
							}
							else
							{
								moneyObjectTooltipViewPool.Release(instance5);
							}
						}
						else
						{
							anotherDeviceFromSameOrderInShipmentTooltipViewPool.Release(instance4);
						}
					}
					else
					{
						warningTooltipViewPool.Release(instance3);
					}
				}
				else
				{
					deliveryBoxMainTooltipViewPool.Release(instance2);
				}
			}
			else
			{
				deliveryBoxInitialTooltipViewPool.Release(instance);
			}
		}
	}
}
