using System;
using Restory.Data.Elements;
using UnityEngine;

namespace Restory.Data.Shops.Elements
{
	[Serializable]
	public class ElementsShopItemData
	{
		public ElementInfo Element;

		public int Price;

		[Min(1f)]
		public int MinCount = 1;

		[SerializeField]
		private bool isInStock = true;

		public bool IsInStock
		{
			get
			{
				return isInStock;
			}
			set
			{
				if (isInStock != value)
				{
					isInStock = value;
					this.OnIsInStockChanged?.Invoke(this);
				}
			}
		}

		public event Action<ElementsShopItemData> OnIsInStockChanged;

		public ElementsShopItemData Clone()
		{
			return MemberwiseClone() as ElementsShopItemData;
		}
	}
}
