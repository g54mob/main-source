using System.Collections.Generic;
using DV.Shops;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public class CashRegisterReceiptItemsTest : ABookletTest
	{
		public GlobalShopController globalShopController;

		private GameObject CreateBookletFromShopData(List<ShopItemData> shopItemData)
		{
			List<CashRegisterModule.CashRegisterModuleData> list = new List<CashRegisterModule.CashRegisterModuleData>();
			foreach (ShopItemData shopItemDatum in shopItemData)
			{
				list.Add(new CashRegisterModule.CashRegisterModuleData
				{
					resourceName = shopItemDatum.item.LocalizedName,
					resourceIcon = shopItemDatum.item.ItemIconSprite,
					pricePerUnit = shopItemDatum.basePrice,
					unitsToBuy = 1f
				});
			}
			return BookletCreator_CashRegisterReceipt.Create(list, base.transform.position, base.transform.rotation, base.transform);
		}

		protected override GameObject CreateBooklet()
		{
			return CreateBookletFromShopData(globalShopController.shopItemsData);
		}
	}
}
