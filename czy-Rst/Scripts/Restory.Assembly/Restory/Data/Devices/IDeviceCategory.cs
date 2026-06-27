using Restory.Data.Shops;
using UnityEngine;

namespace Restory.Data.Devices
{
	public interface IDeviceCategory : IShopCategory
	{
		new string ID { get; }

		Sprite Icon { get; }

		new Sprite BrowserIcon { get; }

		new string NameLocalizationKey { get; }
	}
}
