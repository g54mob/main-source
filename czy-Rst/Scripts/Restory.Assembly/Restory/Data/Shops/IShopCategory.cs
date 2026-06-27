using UnityEngine;

namespace Restory.Data.Shops
{
	public interface IShopCategory
	{
		string ID { get; }

		Sprite BrowserIcon { get; }

		string NameLocalizationKey { get; }
	}
}
