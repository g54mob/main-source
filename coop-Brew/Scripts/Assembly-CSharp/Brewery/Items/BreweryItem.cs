using InventorySystem;
using UnityEngine;

namespace Brewery.Items
{
	public abstract class BreweryItem : Item
	{
		[Header("Brewery Properties")]
		[SerializeField]
		protected BreweryItemType breweryType;

		[Header("Shop Properties")]
		[Tooltip("Price of this item in shops. Set to 0 if not purchasable.")]
		[SerializeField]
		protected int shopPrice;

		[Tooltip("Is this item available for purchase in shops?")]
		[SerializeField]
		protected bool isPurchasable;

		[Tooltip("Shop category used for filtering (future feature)")]
		[SerializeField]
		protected ShopCategory shopCategory;

		[Tooltip("Can this item be sold at shops?")]
		[SerializeField]
		protected bool isSellable;

		[Tooltip("Custom sell price. Set to 0 to use default (ShopPrice / 2).")]
		[SerializeField]
		[Min(0f)]
		protected int sellPrice;

		public BreweryItemType BreweryType => default(BreweryItemType);

		public int ShopPrice => 0;

		public bool IsPurchasable => false;

		public ShopCategory ShopCategory => default(ShopCategory);

		public virtual bool IsSellable => false;

		public int SellPrice => 0;

		public virtual bool CanBeUsedInStation(StationType stationType)
		{
			return false;
		}

		public override bool RequiresMetadata()
		{
			return false;
		}

		public override ItemCarryType GetCarryType()
		{
			return default(ItemCarryType);
		}
	}
}
