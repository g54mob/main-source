using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.Email;
using Restory.Data.SaveLoad;
using Restory.Gameplay.Elements;
using Restory.Gameplay.RandomBallsPoolSystems;
using Restory.Gameplay.RandomBallsPoolSystems.RandomNumbers;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopRandomElementsBoxesGenerationService : MonoBehaviour
	{
		private const string GENERATED_ELEMENTS_BOX_ID_PREFIX = "deviceShopGeneratedElementsBox_";

		private const int TOTAL_MINUTES_IN_ONE_DAY = 1440;

		[SerializeField]
		private DeviceShopRandomElementsBoxesGenerationSettings settings;

		[SerializeField]
		private EmailNamesCollection sellerNames;

		[SerializeField]
		private RandomBallsPoolSystemSprites backgroundSpritesSelector;

		[SerializeField]
		private DeviceShopRandomElementsBoxesUniqueTextsService uniqueTextsService;

		private AvailableDevicesListTrackingService availableDevicesListTracker;

		private RandomNumbersService randomNumbersService;

		private DefaultElementConditions defaultElementConditions;

		private ElementDirtMaskPresetSelectionService dirtMaskPresetSelectionService;

		private TextureMaskCreationService textureMaskCreationService;

		private IDService idService;

		private GameCalendar gameCalendar;

		[Inject]
		private void Construct(AvailableDevicesListTrackingService availableDevicesListTracker, RandomNumbersService randomNumbersService, DefaultElementConditions defaultElementConditions, ElementDirtMaskPresetSelectionService dirtMaskPresetSelectionService, TextureMaskCreationService textureMaskCreationService, IDService idService, GameCalendar gameCalendar)
		{
			this.availableDevicesListTracker = availableDevicesListTracker;
			this.randomNumbersService = randomNumbersService;
			this.defaultElementConditions = defaultElementConditions;
			this.dirtMaskPresetSelectionService = dirtMaskPresetSelectionService;
			this.textureMaskCreationService = textureMaskCreationService;
			this.idService = idService;
			this.gameCalendar = gameCalendar;
		}

		public bool TryGetBackgroundIconByID(int id, out Sprite foundIcon)
		{
			return backgroundSpritesSelector.TryGetObjectByBallSourceID(id, out foundIcon);
		}

		public void PickRandomBackgroundIcon(out int iconID, out Sprite icon)
		{
			RandomBallsPoolBall<Sprite> randomBall = backgroundSpritesSelector.GetRandomBall();
			icon = randomBall.TargetObject;
			iconID = randomBall.BallSourceID;
		}

		public IEnumerable<IElementsBoxLot> GetRandomlyGeneratedElementsBoxes()
		{
			randomNumbersService.TryGetRandomNumberInRange(settings.DailyBoxesCount.Min, settings.DailyBoxesCount.Max + 1, out var boxesToGenerateCount);
			List<ElementInfo> availableElements;
			using (CollectionPool<List<ElementInfo>, ElementInfo>.Get(out availableElements))
			{
				CollectAvailableElements(availableElements);
				if (availableElements.Count == 0)
				{
					yield break;
				}
				for (int i = 0; i < boxesToGenerateCount; i++)
				{
					if (!RandomGeneratorFromWeights.TryToGetRandomObject(settings.BoxPresets as ICollection<DeviceShopRandomElementsBoxPreset>, out var chosenObject))
					{
						yield break;
					}
					if (!(chosenObject.BoxInfo == null))
					{
						List<ElementData> list = GenerateElementsForBox(chosenObject, availableElements);
						if (list.Count != 0)
						{
							DateTime lotAddTime = GetLotAddTime();
							randomNumbersService.TryGetRandomNumberInRange(settings.LotLifetime.Min, settings.LotLifetime.Max + 1, out var result);
							RandomBallsPoolBall<Sprite> randomBall = backgroundSpritesSelector.GetRandomBall();
							ElementsBoxData elementsBoxData = new ElementsBoxData(chosenObject.BoxInfo, list);
							string descriptionKey = GetDescriptionKey(elementsBoxData.Info);
							string randomSellerNameKey = GetRandomSellerNameKey();
							RandomGeneratorFromWeights.TryToGetRandomObject(settings.SellerRatings as ICollection<DeviceShopSellerRating>, out var chosenObject2);
							int elementsBoxPrice = GetElementsBoxPrice(list.Count, chosenObject, chosenObject2);
							string id = "deviceShopGeneratedElementsBox_" + idService.GenerateNew();
							yield return new RandomlyGeneratedElementsBoxLot(id, elementsBoxData, descriptionKey, elementsBoxPrice, randomSellerNameKey, chosenObject2.Rating, gameCalendar.GetDayNumberByDateTime(lotAddTime), lotAddTime, result, randomBall.BallSourceID, randomBall.TargetObject);
						}
					}
				}
			}
		}

		private string GetDescriptionKey(ElementsBoxInfo boxInfo)
		{
			if (uniqueTextsService.TryGetRemainingLocalizationKeyForElementsBox(boxInfo, out var textLocalizationKey))
			{
				return textLocalizationKey;
			}
			return boxInfo.DescriptionLocalizationKey;
		}

		private string GetRandomSellerNameKey()
		{
			randomNumbersService.TryGetRandomNumberInRange(0, sellerNames.EmailContacts.Count, out var result);
			return sellerNames.EmailContacts[result].NameLocalizationKey;
		}

		private int GetElementsBoxPrice(int elementsCount, DeviceShopRandomElementsBoxPreset boxPreset, DeviceShopSellerRating sellerRating)
		{
			randomNumbersService.TryGetRandomNumberInRange(sellerRating.PriceModifierRange.Min, sellerRating.PriceModifierRange.Max, out var result);
			int num = Mathf.RoundToInt((float)(elementsCount * settings.BaseElementPrice) * boxPreset.PriceModifier * result);
			return num + 10 - num % 10 - (randomNumbersService.TryToFallWithinPercentProbability(settings.MinusOneYenPricePercentProbability) ? 1 : 0);
		}

		private List<ElementData> GenerateElementsForBox(DeviceShopRandomElementsBoxPreset boxPreset, IReadOnlyList<ElementInfo> availableElements)
		{
			randomNumbersService.TryGetRandomNumberInRange(boxPreset.ElementsCount.Min, boxPreset.ElementsCount.Max + 1, out var result);
			if (boxPreset.MustContainUniqueElements)
			{
				result = Mathf.Min(result, availableElements.Count);
			}
			if (result <= 0)
			{
				return new List<ElementData>();
			}
			List<ElementData> list = new List<ElementData>(result);
			List<int> value;
			using (CollectionPool<List<int>, int>.Get(out value))
			{
				while (value.Count < result)
				{
					randomNumbersService.TryGetRandomNumberInRange(0, availableElements.Count, out var result2);
					if (!boxPreset.MustContainUniqueElements || !value.Contains(result2))
					{
						value.Add(result2);
					}
				}
				int num = Mathf.RoundToInt(Mathf.Lerp(0f, result, Mathf.Clamp01((float)boxPreset.DirtyElementsPercent * 0.01f)));
				int num2 = Mathf.RoundToInt(Mathf.Lerp(0f, result, Mathf.Clamp01((float)boxPreset.BrokenElementsPercent * 0.01f)));
				List<int> value2;
				using (CollectionPool<List<int>, int>.Get(out value2))
				{
					List<int> value3;
					using (CollectionPool<List<int>, int>.Get(out value3))
					{
						while (value2.Count < num)
						{
							randomNumbersService.TryGetRandomNumberInRange(0, value.Count, out var result3);
							if (!value2.Contains(result3))
							{
								value2.Add(result3);
							}
						}
						while (value3.Count < num2)
						{
							randomNumbersService.TryGetRandomNumberInRange(0, value.Count, out var result4);
							if (!value3.Contains(result4))
							{
								value3.Add(result4);
							}
						}
						for (int i = 0; i < value.Count; i++)
						{
							ElementInfo elementInfo = availableElements[value[i]];
							bool shouldBeDirty = value2.Contains(i);
							bool shouldBeBroken = value3.Contains(i);
							list.Add(CreateElementDataForElementsBox(elementInfo, shouldBeDirty, shouldBeBroken));
						}
						return list;
					}
				}
			}
		}

		private ElementData CreateElementDataForElementsBox(ElementInfo elementInfo, bool shouldBeDirty, bool shouldBeBroken)
		{
			if (shouldBeBroken && elementInfo.CanBeBroken)
			{
				return new ElementData
				{
					Info = elementInfo,
					Condition = defaultElementConditions.DamagedElementCondition
				};
			}
			if (shouldBeDirty && elementInfo.CanBeDirty)
			{
				MaskPresetInfoBase preset;
				bool num = dirtMaskPresetSelectionService.TryToGetDirtMaskCreationPreset(elementInfo.ElementMaterialType, out preset);
				ElementData elementData = new ElementData
				{
					Info = elementInfo,
					Condition = defaultElementConditions.DirtyElementCondition,
					DirtMaskPresetOverride = preset
				};
				if (num && elementInfo.SourceDevice is DeviceInfo deviceInfo)
				{
					elementData.NoiseSeed = textureMaskCreationService.GetRandomOrDebugNoiseSeed(preset, elementInfo);
					elementData.DirtMaskTextureSize = deviceInfo.GeneratedDirtMaskTextureSize;
				}
				return elementData;
			}
			return new ElementData
			{
				Info = elementInfo,
				Condition = defaultElementConditions.PerfectElementCondition
			};
		}

		private void CollectAvailableElements(List<ElementInfo> result)
		{
			result.Clear();
			foreach (AvailableDevicesListEntry availableDevices in availableDevicesListTracker.GetAvailableDevicesList())
			{
				foreach (IElementInfo element in availableDevices.Device.Elements)
				{
					if (element is ElementInfo { Category: ElementCategory.Draggable } elementInfo)
					{
						result.Add(elementInfo);
					}
				}
			}
		}

		private DateTime GetLotAddTime()
		{
			randomNumbersService.TryGetRandomNumberInRange(0, 1440, out var result);
			return gameCalendar.CurrentDayStartTime + TimeSpan.FromMinutes(result);
		}
	}
}
