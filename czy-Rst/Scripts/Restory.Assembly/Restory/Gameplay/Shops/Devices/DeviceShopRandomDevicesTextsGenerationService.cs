using Restory.Data.Devices;
using Restory.Gameplay.RandomBallsPoolSystems;
using Restory.Gameplay.RandomBallsPoolSystems.RandomNumbers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopRandomDevicesTextsGenerationService : MonoBehaviour
	{
		[SerializeField]
		private DeviceShopRandomDevicesUniqueTextsService uniqueTextsService;

		[SerializeField]
		private RandomBallsPoolSystemDeviceShopLotIntroTexts introPartTexts;

		[SerializeField]
		private RandomBallsPoolSystemDeviceShopLotMainTexts mainPartTexts;

		[SerializeField]
		private RandomBallsPoolSystemDeviceShopLotOptionalTexts optionalPartTexts;

		[SerializeField]
		private DeviceShopRandomDevicesTextsGenerationServiceSettings settings;

		private RandomNumbersService randomNumbersService;

		[Inject]
		private void Construct(RandomNumbersService randomNumbersService)
		{
			this.randomNumbersService = randomNumbersService;
		}

		public RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys GetDescriptionLocalizationKeysForDevice(DeviceInfo deviceInfo)
		{
			if (randomNumbersService.TryToFallWithinPercentProbability(settings.EmptyLotDescriptionChancePercentage))
			{
				return default(RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys);
			}
			if (randomNumbersService.TryToFallWithinPercentProbability(settings.DeviceSpecificLotDescriptionChancePercentage) && uniqueTextsService.TryGetRemainingLocalizationKeyForDevice(deviceInfo, out var textLocalizationKey))
			{
				return new RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys
				{
					UniqueDescriptionKey = textLocalizationKey
				};
			}
			if (randomNumbersService.TryToFallWithinPercentProbability(settings.DeviceCategorySpecificLotDescriptionChancePercentage) && uniqueTextsService.TryGetRemainingLocalizationKeyForDeviceCategory(deviceInfo.Category as DeviceCategory, out var textLocalizationKey2))
			{
				return new RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys
				{
					UniqueDescriptionKey = textLocalizationKey2
				};
			}
			return new RandomlyGeneratedDeviceShopLotDescriptionLocalizationKeys
			{
				CommonDescriptionIntroPartKey = introPartTexts.GetObjectFromRandomBall(),
				CommonDescriptionMainPartKey = mainPartTexts.GetObjectFromRandomBall(),
				CommonDescriptionOptionalPartKey = (randomNumbersService.TryToFallWithinPercentProbability(settings.LotDescriptionOptionalPartChancePercentage) ? optionalPartTexts.GetObjectFromRandomBall() : string.Empty)
			};
		}
	}
}
