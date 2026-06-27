using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/RandomLotsGeneration/DeviceShopRandomDevicesTextsGenerationServiceSettings", fileName = "DeviceShopRandomDevicesTextsGenerationServiceSettings")]
	public class DeviceShopRandomDevicesTextsGenerationServiceSettings : ScriptableObject
	{
		[SerializeField]
		private int emptyLotDescriptionChancePercentage = 50;

		[SerializeField]
		private int deviceSpecificLotDescriptionChancePercentage = 50;

		[SerializeField]
		private int deviceCategorySpecificLotDescriptionChancePercentage = 50;

		[SerializeField]
		private int lotDescriptionOptionalPartChancePercentage = 25;

		public int EmptyLotDescriptionChancePercentage => emptyLotDescriptionChancePercentage;

		public int DeviceSpecificLotDescriptionChancePercentage => deviceSpecificLotDescriptionChancePercentage;

		public int DeviceCategorySpecificLotDescriptionChancePercentage => deviceCategorySpecificLotDescriptionChancePercentage;

		public int LotDescriptionOptionalPartChancePercentage => lotDescriptionOptionalPartChancePercentage;
	}
}
