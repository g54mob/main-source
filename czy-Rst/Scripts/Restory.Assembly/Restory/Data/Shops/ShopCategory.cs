using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Shops
{
	[CreateAssetMenu(menuName = "Restory/Shops/ShopCategory", fileName = "Name - ShopCategory")]
	public class ShopCategory : RestoryEntityInfoBase, IShopCategory
	{
		[SerializeField]
		private Sprite browserIcon;

		[SerializeField]
		private string nameLocalizationKey;

		public Sprite BrowserIcon => browserIcon;

		public string NameLocalizationKey => nameLocalizationKey;
	}
}
