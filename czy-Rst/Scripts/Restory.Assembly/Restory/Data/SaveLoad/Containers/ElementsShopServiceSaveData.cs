using System;
using System.Collections.Generic;
using Restory.Data.Shops.Elements;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class ElementsShopServiceSaveData
	{
		public List<ElementsShopItemData> ElementItems { get; set; }
	}
}
