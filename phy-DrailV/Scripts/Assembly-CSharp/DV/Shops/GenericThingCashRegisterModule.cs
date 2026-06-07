using System;
using DV.Localization;

namespace DV.Shops
{
	public class GenericThingCashRegisterModule : CashRegisterModule
	{
		public string localizationKey = "";

		public float price = 10000f;

		public event Action ThingBought;

		public event Action ThingAddedToCart;

		protected override void InitializeData()
		{
			Data.pricePerUnit = price;
			Data.resourceName = LocalizationAPI.L(localizationKey);
			Data.resourceIcon = null;
		}

		public override void GetBoughtResource()
		{
			if (!(Data.unitsToBuy < 1f))
			{
				SetUnitsToBuy(0f);
				this.ThingBought?.Invoke();
			}
		}

		public void AddThingToCart()
		{
			SetUnitsToBuy(1f);
			this.ThingAddedToCart?.Invoke();
		}

		public override void ResetData()
		{
		}
	}
}
