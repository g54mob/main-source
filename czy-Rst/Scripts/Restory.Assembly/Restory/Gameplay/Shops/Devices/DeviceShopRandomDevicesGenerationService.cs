using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Devices.Quality;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.Email;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Elements;
using Restory.Gameplay.RandomBallsPoolSystems;
using Restory.Gameplay.RandomBallsPoolSystems.RandomNumbers;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopRandomDevicesGenerationService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private const string GENERATED_DEVICE_ID_PREFIX = "deviceShopGeneratedDevice_";

		private const int TOTAL_MINUTES_IN_ONE_DAY = 1440;

		[SerializeField]
		private DeviceShopRandomDevicesGenerationSettings settings;

		[SerializeField]
		private DeviceShopRandomDevicesTextsGenerationService textsGenerationService;

		[SerializeField]
		private EmailNamesCollection sellerNames;

		[SerializeField]
		private RandomBallsPoolSystemSprites backgroundSpritesSelector;

		[SerializeField]
		private RandomBallsPoolSystemSprites backgroundBigDevicesSpritesSelector;

		private AvailableDevicesListTrackingService availableDevicesListTracker;

		private RandomNumbersService randomNumbersService;

		private DefaultElementConditions defaultElementConditions;

		private DeviceQualityDatabase deviceQualityDatabase;

		private ElementDirtMaskPresetSelectionService dirtMaskPresetSelectionService;

		private IDService idService;

		private GameCalendar gameCalendar;

		private readonly List<DeviceInfo> weightedSelectableDevicesList = new List<DeviceInfo>();

		[Inject]
		private void Construct(AvailableDevicesListTrackingService availableDevicesListTracker, RandomNumbersService randomNumbersService, DefaultElementConditions defaultElementConditions, DeviceQualityDatabase deviceQualityDatabase, ElementDirtMaskPresetSelectionService dirtMaskPresetSelectionService, IDService idService, GameCalendar gameCalendar)
		{
			this.deviceQualityDatabase = deviceQualityDatabase;
			this.gameCalendar = gameCalendar;
			this.idService = idService;
			this.dirtMaskPresetSelectionService = dirtMaskPresetSelectionService;
			this.defaultElementConditions = defaultElementConditions;
			this.randomNumbersService = randomNumbersService;
			this.availableDevicesListTracker = availableDevicesListTracker;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)availableDevicesListTracker)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (availableDevicesListTracker.MonoShellExists())
			{
				availableDevicesListTracker.OnDeviceMadeAvailable -= ResolveDeviceMadeAvailable;
			}
		}

		private void Init()
		{
			availableDevicesListTracker.OnDeviceMadeAvailable += ResolveDeviceMadeAvailable;
		}

		private RandomBallsPoolSystemSprites GetRandomBallsPoolSystemSpritesSelectorForDevice(DeviceInfo deviceInfo)
		{
			if (!deviceInfo.UseBigBackgroundForGeneratedShopLots)
			{
				return backgroundSpritesSelector;
			}
			return backgroundBigDevicesSpritesSelector;
		}

		public IEnumerable<IDeviceShopLot> GetRandomlyGeneratedDeviceShopLots()
		{
			randomNumbersService.TryGetRandomNumberInRange(settings.DailyLotsCount.Min, settings.DailyLotsCount.Max + 1, out var result);
			List<DeviceInfo> randomDevicesList = GetRandomDevicesList(result, settings.MaxOneTypeDeviceLotsCountPerDay);
			randomNumbersService.TryGetRandomNumberInRange(settings.BrokenDevicesPercent.Min, settings.BrokenDevicesPercent.Max, out var result2);
			float f = Mathf.Lerp(0f, randomDevicesList.Count, (float)result2 * 0.01f);
			int brokenDevicesCount = Mathf.RoundToInt(f);
			foreach (DeviceInfo item in randomDevicesList)
			{
				DateTime lotAddTime = GetLotAddTime();
				randomNumbersService.TryGetRandomNumberInRange(settings.LotLifetime.Min, settings.LotLifetime.Max + 1, out var result3);
				RandomBallsPoolBall<Sprite> randomBall = GetRandomBallsPoolSystemSpritesSelectorForDevice(item).GetRandomBall();
				RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys descriptionLocalizationKeysForDevice = textsGenerationService.GetDescriptionLocalizationKeysForDevice(item);
				string randomSellerNameKey = GetRandomSellerNameKey();
				if (brokenDevicesCount > 0)
				{
					RandomlyGeneratedDeviceCondition device = GenerateBrokenDeviceCondition(item);
					RandomGeneratorFromWeights.TryToGetRandomObject(settings.SellerRatings as ICollection<DeviceShopSellerRating>, out var chosenObject);
					bool flag = randomNumbersService.TryToFallWithinPercentProbability(chosenObject.LieChancePercent);
					float deviceQualityPriceModifier = (flag ? settings.DirtyDevicePriceModifier : settings.BrokenDevicePriceModifier);
					int lotPrice = GetLotPrice(item.DefaultPrice, chosenObject, deviceQualityPriceModifier);
					yield return new RandomlyGeneratedDeviceShopLot(device, flag ? ((DeviceQualityBase)deviceQualityDatabase.WorkingQuality) : ((DeviceQualityBase)deviceQualityDatabase.BrokenQuality), lotPrice, descriptionLocalizationKeysForDevice, randomSellerNameKey, chosenObject.Rating, gameCalendar.GetDayNumberByDateTime(lotAddTime), lotAddTime, result3, randomBall.BallSourceID, randomBall.TargetObject);
					brokenDevicesCount--;
				}
				else
				{
					RandomlyGeneratedDeviceCondition device2 = GenerateDirtyDeviceCondition(item);
					RandomGeneratorFromWeights.TryToGetRandomObject(settings.SellerRatings as ICollection<DeviceShopSellerRating>, out var chosenObject2);
					int lotPrice2 = GetLotPrice(item.DefaultPrice, chosenObject2, settings.DirtyDevicePriceModifier);
					yield return new RandomlyGeneratedDeviceShopLot(device2, deviceQualityDatabase.WorkingQuality, lotPrice2, descriptionLocalizationKeysForDevice, randomSellerNameKey, chosenObject2.Rating, gameCalendar.GetDayNumberByDateTime(lotAddTime), lotAddTime, result3, randomBall.BallSourceID, randomBall.TargetObject);
				}
			}
		}

		private string GetRandomSellerNameKey()
		{
			randomNumbersService.TryGetRandomNumberInRange(0, sellerNames.EmailContacts.Count, out var result);
			return sellerNames.EmailContacts[result].NameLocalizationKey;
		}

		public bool TryGetBackgroundIconByID(DeviceInfo deviceInfo, int id, out Sprite foundIcon)
		{
			return GetRandomBallsPoolSystemSpritesSelectorForDevice(deviceInfo).TryGetObjectByBallSourceID(id, out foundIcon);
		}

		public void PickRandomBackgroundIcon(DeviceInfo deviceInfo, out int iconID, out Sprite icon)
		{
			RandomBallsPoolBall<Sprite> randomBall = GetRandomBallsPoolSystemSpritesSelectorForDevice(deviceInfo).GetRandomBall();
			icon = randomBall.TargetObject;
			iconID = randomBall.BallSourceID;
		}

		private RandomlyGeneratedDeviceCondition GenerateBrokenDeviceCondition(DeviceInfo deviceInfo)
		{
			List<ElementInfo> list = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementInfo> list2 = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementInfo> list3 = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementInfo> list4 = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementData> list5 = CollectionPool<List<ElementData>, ElementData>.Get();
			foreach (IElementInfo element in deviceInfo.Elements)
			{
				if (element is ElementInfo { CanBeBroken: not false } elementInfo)
				{
					list.Add(elementInfo);
				}
			}
			foreach (IElementInfo element2 in deviceInfo.Elements)
			{
				if (element2 is ElementInfo { CanBeDirty: not false } elementInfo2)
				{
					list3.Add(elementInfo2);
				}
			}
			UpdateListsWithGeneratedBrokenElements(list, list2, list3, list5);
			UpdateListsWithGeneratedDirtyElements(list3, list4, list5, FloatToIntRoundingMode.HighestOfSmallerOrEqualInteger);
			List<ElementData> sortedElementDataList = GetSortedElementDataList(deviceInfo, list5);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list2);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list3);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list4);
			CollectionPool<List<ElementData>, ElementData>.Release(list5);
			return new RandomlyGeneratedDeviceCondition("deviceShopGeneratedDevice_" + idService.GenerateNew(), deviceInfo, null, sortedElementDataList);
		}

		private RandomlyGeneratedDeviceCondition GenerateDirtyDeviceCondition(DeviceInfo deviceInfo)
		{
			List<ElementInfo> list = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementInfo> list2 = CollectionPool<List<ElementInfo>, ElementInfo>.Get();
			List<ElementData> list3 = CollectionPool<List<ElementData>, ElementData>.Get();
			foreach (IElementInfo element in deviceInfo.Elements)
			{
				if (element is ElementInfo { CanBeDirty: not false } elementInfo)
				{
					list.Add(elementInfo);
				}
			}
			UpdateListsWithGeneratedDirtyElements(list, list2, list3, FloatToIntRoundingMode.SmallestOfHigherOrEqualInteger);
			List<ElementData> sortedElementDataList = GetSortedElementDataList(deviceInfo, list3);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list);
			CollectionPool<List<ElementInfo>, ElementInfo>.Release(list2);
			CollectionPool<List<ElementData>, ElementData>.Release(list3);
			return new RandomlyGeneratedDeviceCondition("deviceShopGeneratedDevice_" + idService.GenerateNew(), deviceInfo, null, sortedElementDataList);
		}

		private void UpdateListsWithGeneratedDirtyElements(List<ElementInfo> dirtiableElements, List<ElementInfo> dirtyElements, List<ElementData> elementsDataList, FloatToIntRoundingMode dirtyElementsCountRoundingMode)
		{
			randomNumbersService.TryGetRandomNumberInRange(settings.DirtyElementsPercent.Min, settings.DirtyElementsPercent.Max, out var result);
			float f = Mathf.Lerp(0f, dirtiableElements.Count, (float)result * 0.01f);
			int num = dirtyElementsCountRoundingMode switch
			{
				FloatToIntRoundingMode.HighestOfSmallerOrEqualInteger => Mathf.FloorToInt(f), 
				FloatToIntRoundingMode.NearestInteger => Mathf.RoundToInt(f), 
				FloatToIntRoundingMode.SmallestOfHigherOrEqualInteger => Mathf.CeilToInt(f), 
				_ => throw new NotImplementedException(), 
			};
			while (dirtyElements.Count < num)
			{
				randomNumbersService.TryGetRandomNumberInRange(0, dirtiableElements.Count, out var result2);
				ElementInfo elementInfo = dirtiableElements[result2];
				dirtyElements.Add(elementInfo);
				dirtiableElements.RemoveAt(result2);
				dirtMaskPresetSelectionService.TryToGetDirtMaskCreationPreset(elementInfo.ElementMaterialType, out var preset);
				elementsDataList.Add(new ElementData
				{
					Info = elementInfo,
					Condition = defaultElementConditions.DirtyElementCondition,
					DirtMaskPresetOverride = preset
				});
			}
		}

		private void UpdateListsWithGeneratedBrokenElements(List<ElementInfo> breakableElements, List<ElementInfo> brokenElements, List<ElementInfo> dirtiableElements, List<ElementData> elementsDataList)
		{
			randomNumbersService.TryGetRandomNumberInRange(settings.BrokenElementsPercent.Min, settings.BrokenElementsPercent.Max, out var result);
			int num = Mathf.RoundToInt(Mathf.Lerp(0f, breakableElements.Count, (float)result * 0.01f));
			while (brokenElements.Count < num)
			{
				randomNumbersService.TryGetRandomNumberInRange(0, breakableElements.Count, out var result2);
				ElementInfo elementInfo = breakableElements[result2];
				brokenElements.Add(elementInfo);
				dirtiableElements.Remove(elementInfo);
				breakableElements.RemoveAt(result2);
				elementsDataList.Add(new ElementData
				{
					Info = elementInfo,
					Condition = defaultElementConditions.DamagedElementCondition
				});
			}
		}

		private List<ElementData> GetSortedElementDataList(DeviceInfo deviceInfo, List<ElementData> processedElementsDataList)
		{
			List<ElementData> list = new List<ElementData>();
			foreach (IElementInfo element in deviceInfo.Elements)
			{
				if (!(element is ElementInfo elementInfo))
				{
					continue;
				}
				bool flag = false;
				foreach (ElementData processedElementsData in processedElementsDataList)
				{
					if (!list.Contains(processedElementsData) && processedElementsData.Info == elementInfo)
					{
						list.Add(processedElementsData);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(new ElementData
					{
						Info = elementInfo,
						Condition = defaultElementConditions.PerfectElementCondition
					});
				}
			}
			return list;
		}

		private int GetLotPrice(int defaultDevicePrice, DeviceShopSellerRating sellerRating, float deviceQualityPriceModifier)
		{
			randomNumbersService.TryGetRandomNumberInRange(sellerRating.PriceModifierRange.Min, sellerRating.PriceModifierRange.Max, out var result);
			int num = Mathf.RoundToInt((float)defaultDevicePrice * deviceQualityPriceModifier * result);
			return num + 10 - num % 10 - (randomNumbersService.TryToFallWithinPercentProbability(settings.MinusOneYenPricePercentProbability) ? 1 : 0);
		}

		private DateTime GetLotAddTime()
		{
			randomNumbersService.TryGetRandomNumberInRange(0, 1440, out var result);
			return gameCalendar.CurrentDayStartTime + TimeSpan.FromMinutes(result);
		}

		private List<DeviceInfo> GetRandomDevicesList(int devicesToGetCount, int maxOneTypeDevicesCount)
		{
			if (devicesToGetCount > weightedSelectableDevicesList.Count)
			{
				RefillDevices();
			}
			if (devicesToGetCount > weightedSelectableDevicesList.Count)
			{
				Debug.LogWarning(string.Format("[{0}] tried to generate {1} devices, ", "DeviceShopRandomDevicesGenerationService", devicesToGetCount) + $"but only {weightedSelectableDevicesList.Count} devices are available for generation, even after refilling the devices pool. " + "Using that number instead.");
				devicesToGetCount = weightedSelectableDevicesList.Count;
			}
			List<DeviceInfo> list = new List<DeviceInfo>();
			List<DeviceInfo> value;
			using (CollectionPool<List<DeviceInfo>, DeviceInfo>.Get(out value))
			{
				List<DeviceInfo> value2;
				using (CollectionPool<List<DeviceInfo>, DeviceInfo>.Get(out value2))
				{
					FillUniqueDevicesList(value);
					FillTempWeightedDevicesList(maxOneTypeDevicesCount, value, value2);
					if (value2.Count < devicesToGetCount)
					{
						RefillDevices();
						FillUniqueDevicesList(value);
						FillTempWeightedDevicesList(maxOneTypeDevicesCount, value, value2);
						if (value2.Count < devicesToGetCount)
						{
							Debug.LogWarning(string.Format("[{0}] tried to generate {1} devices, ", "DeviceShopRandomDevicesGenerationService", devicesToGetCount) + $"but only {value2.Count} devices are available for generation, even after refilling the devices pool. " + "Using that number instead.");
							devicesToGetCount = value2.Count;
						}
					}
					for (int i = 0; i < devicesToGetCount; i++)
					{
						int index = UnityEngine.Random.Range(0, value2.Count);
						DeviceInfo deviceInfo = value2[index];
						value2.RemoveAt(index);
						for (int num = weightedSelectableDevicesList.Count - 1; num >= 0; num--)
						{
							if (weightedSelectableDevicesList[num] == deviceInfo)
							{
								weightedSelectableDevicesList.RemoveAt(num);
								break;
							}
						}
						list.Add(deviceInfo);
					}
					return list;
				}
			}
		}

		private void FillUniqueDevicesList(List<DeviceInfo> uniqueSelectableDevicesList)
		{
			uniqueSelectableDevicesList.Clear();
			foreach (DeviceInfo weightedSelectableDevices in weightedSelectableDevicesList)
			{
				if (!uniqueSelectableDevicesList.Contains(weightedSelectableDevices))
				{
					uniqueSelectableDevicesList.Add(weightedSelectableDevices);
				}
			}
		}

		private void FillTempWeightedDevicesList(int maxOneTypeDevicesCount, List<DeviceInfo> uniqueSelectableDevicesList, List<DeviceInfo> weightedDevicesListTemp)
		{
			weightedDevicesListTemp.Clear();
			foreach (DeviceInfo uniqueSelectableDevices in uniqueSelectableDevicesList)
			{
				int num = 0;
				foreach (DeviceInfo weightedSelectableDevices in weightedSelectableDevicesList)
				{
					if (weightedSelectableDevices == uniqueSelectableDevices)
					{
						weightedDevicesListTemp.Add(uniqueSelectableDevices);
						num++;
						if (num >= maxOneTypeDevicesCount)
						{
							break;
						}
					}
				}
			}
		}

		private void RefillDevices()
		{
			weightedSelectableDevicesList.Clear();
			foreach (AvailableDevicesListEntry availableDevices in availableDevicesListTracker.GetAvailableDevicesList())
			{
				for (int i = 0; i < availableDevices.RandomnessWeight; i++)
				{
					weightedSelectableDevicesList.Add(availableDevices.Device);
				}
			}
		}

		private void ResolveDeviceMadeAvailable(AvailableDevicesListEntry newDeviceEntry)
		{
			for (int i = 0; i < newDeviceEntry.RandomnessWeight; i++)
			{
				weightedSelectableDevicesList.Add(newDeviceEntry.Device);
			}
		}

		public object CaptureState()
		{
			try
			{
				return new DeviceShopRandomDevicesGenerationServiceSaveData
				{
					Devices = weightedSelectableDevicesList.ToArray()
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
				DeviceShopRandomDevicesGenerationServiceSaveData deviceShopRandomDevicesGenerationServiceSaveData = DataMigrationWizard.Migrate<DeviceShopRandomDevicesGenerationServiceSaveData>(state, base.gameObject);
				weightedSelectableDevicesList.Clear();
				weightedSelectableDevicesList.AddRange(deviceShopRandomDevicesGenerationServiceSaveData.Devices);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
