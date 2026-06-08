using KitchenData;
using Unity.Entities;

namespace Kitchen.ShopBuilder
{
	public struct CShopBuilderOption : IComponentData
	{
		public readonly int Appliance;

		public readonly ShoppingTags Tags;

		public readonly int BasePrice;

		public readonly DecorationType DecorationRequired;

		public readonly bool SellAsUpgrade;

		public readonly ShopRequirementFilter Filter;

		public readonly bool StapleWhenMissing;

		public bool IsRemoved;

		public ShopStapleType Staple;

		public SystemReference FilteredBy;

		public bool TakesStapleSlot
		{
			get
			{
				if (!IsRemoved)
				{
					return Staple != ShopStapleType.NonStaple;
				}
				return false;
			}
		}

		public CShopBuilderOption(Appliance appliance)
		{
			this = default(CShopBuilderOption);
			Appliance = appliance.ID;
			Tags = appliance.ShoppingTags;
			DecorationRequired = appliance.ThemeRequired;
			BasePrice = appliance.PurchaseCost;
			SellAsUpgrade = appliance.IsPurchasableAsUpgrade;
			Filter = appliance.ShopRequirementFilter;
			StapleWhenMissing = appliance.StapleWhenMissing;
		}

		public bool IsSuitableForDesk()
		{
			if (IsRemoved)
			{
				return false;
			}
			if (SellAsUpgrade)
			{
				return false;
			}
			if ((Tags & ShoppingTags.Decoration) != ShoppingTags.None)
			{
				return false;
			}
			if ((Tags & ShoppingTags.SpecialEvent) != ShoppingTags.None)
			{
				return false;
			}
			if (DecorationRequired != DecorationType.Null)
			{
				return false;
			}
			return true;
		}

		public bool MatchesRequestTags(ShoppingTags tags)
		{
			if ((tags & ShoppingTags.Basic) != ShoppingTags.None)
			{
				return Staple != ShopStapleType.NonStaple;
			}
			if ((tags & Tags) != ShoppingTags.None)
			{
				return Staple == ShopStapleType.NonStaple;
			}
			return false;
		}
	}
}
