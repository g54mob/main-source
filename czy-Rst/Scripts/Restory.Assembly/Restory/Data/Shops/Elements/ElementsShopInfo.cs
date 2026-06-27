using UnityEngine;

namespace Restory.Data.Shops.Elements
{
	[CreateAssetMenu(menuName = "Restory/Shops/ElementsShop", fileName = "Name - Shop")]
	public class ElementsShopInfo : ScriptableObject
	{
		[SerializeField]
		private ElementsShopItemData[] productsList = new ElementsShopItemData[0];

		[SerializeField]
		private LicenseShopItemData[] licenses = new LicenseShopItemData[0];

		public ElementsShopItemData[] ProductsList => productsList;

		public LicenseShopItemData[] Licenses => licenses;
	}
}
