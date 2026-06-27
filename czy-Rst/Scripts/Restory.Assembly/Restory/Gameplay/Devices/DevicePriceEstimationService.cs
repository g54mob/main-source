using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements.Condition;
using Restory.Data.Shops.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public class DevicePriceEstimationService
	{
		private readonly DevicePriceEstimationSettings settings;

		public DevicePriceEstimationService(DevicePriceEstimationSettings settings)
		{
			this.settings = settings;
		}

		public int EstimateDevicePrice(DeviceContainer deviceContainer)
		{
			if (!settings.QualityFactors.TryGetValue(deviceContainer.Quality, out var value))
			{
				Debug.LogError("QualityFactors not contains factor for " + deviceContainer.Quality.ID);
				return 0;
			}
			return (int)((float)deviceContainer.Device.Info.DefaultPrice * value);
		}

		public int EstimateDeviceLotPrice(DeviceShopLot lot)
		{
			if (!settings.QualityFactors.TryGetValue(lot.Quality, out var value))
			{
				Debug.LogError("QualityFactors not contains factor for " + lot.Quality.ID);
				return 0;
			}
			return (int)((float)lot.Device.DeviceInfo.DefaultPrice * value);
		}

		public int EstimateEmailOrderPayment(RandomlyGeneratedDeviceCondition generatedDeviceCondition, DeviceWorkType[] workTypes)
		{
			List<ElementData> elementsCondition = generatedDeviceCondition.GetElementsCondition();
			int num = 0;
			int num2 = 0;
			foreach (ElementData item in elementsCondition)
			{
				if (item.Condition is DirtyElementCondition)
				{
					num++;
				}
				else if (item.Condition is DamagedElementCondition)
				{
					num2++;
				}
			}
			float num3 = (float)num / (float)elementsCondition.Count * (float)generatedDeviceCondition.DeviceInfo.DefaultPrice * settings.GeneratedDeviceDirtyElementPaymentModifier + (float)(settings.GeneratedDeviceDirtyElementPaymentFixedPrice * num);
			float num4 = (float)num2 / (float)elementsCondition.Count * (float)generatedDeviceCondition.DeviceInfo.DefaultPrice;
			int num5 = workTypes.Count((DeviceWorkType t) => t is DeviceWorkTypePaintAnyColors);
			int num6 = settings.PaintPaymentFixedPrice * num5;
			int num7 = workTypes.Count((DeviceWorkType t) => t is DeviceWorkTypePaintConcretePalette);
			int num8 = settings.PaintPalettePaymentFixedPrice * num7;
			int num9 = workTypes.Count((DeviceWorkType t) => t is DeviceWorkTypeHacking);
			int num10 = settings.HackingPaymentFixedPrice * num9;
			int num11 = (int)(num3 + num4 + (float)num6 + (float)num8 + (float)num10);
			Debug.Log("[DevicePriceEstimationService] Created Device estimate for " + generatedDeviceCondition.DeviceInfo.name + ": " + $"Final Estimate: {num11}\n" + $"\n-DirtyElementsEstimate = {num3}, " + $"\n-BrokenElementsEstimate = {num4}, " + $"\n-AnyPaintTaskEstimate = {num6}, " + $"\n-ConcretePaletteTaskEstimate = {num8}, " + $"\n-HackingTaskEstimate = {num10}");
			return num11;
		}
	}
}
