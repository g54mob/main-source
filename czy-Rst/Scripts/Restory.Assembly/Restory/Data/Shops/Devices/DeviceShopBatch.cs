using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Shops.Devices
{
	[CreateAssetMenu(menuName = "Restory/Shops/DevicesShop/DeviceShopBatch", fileName = "Name - DeviceShopBatch")]
	public class DeviceShopBatch : ScriptableObject
	{
		[SerializeField]
		private List<DeviceShopLot> lots;

		public IReadOnlyList<DeviceShopLot> Lots => lots;
	}
}
