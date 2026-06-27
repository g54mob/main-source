using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/RandomLotsGeneration/DeviceShopElementsBoxLotsUniqueTextsCollection", fileName = "DeviceShopElementsBoxLotsUniqueTextsCollection")]
	public class DeviceShopElementsBoxLotsUniqueTextsCollection : ScriptableObject
	{
		[SerializeField]
		private DeviceShopElementsBoxLotsUniqueTexts[] uniqueTexts = new DeviceShopElementsBoxLotsUniqueTexts[0];

		public IReadOnlyList<DeviceShopElementsBoxLotsUniqueTexts> UniqueTexts => uniqueTexts;
	}
}
