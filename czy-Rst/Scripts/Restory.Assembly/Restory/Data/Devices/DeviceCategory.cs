using Restory.Data.Base;
using Restory.Data.Shops;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/DeviceCategory", fileName = "Name - DeviceCategory")]
	public class DeviceCategory : RestoryEntityInfoBase, IDeviceCategory, IShopCategory
	{
		[SerializeField]
		private Sprite browserIcon;

		[SerializeField]
		private string nameLocalizationKey;

		public Sprite BrowserIcon => browserIcon;

		public string NameLocalizationKey => nameLocalizationKey;
	}
}
