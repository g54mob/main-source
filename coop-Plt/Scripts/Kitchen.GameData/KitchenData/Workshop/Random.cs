using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace KitchenData.Workshop
{
	public class Random : IWorkshopProduct
	{
		public bool OnlyPurchasable;

		public bool MatchTags;

		public bool RefuseDecorations = true;

		public bool GetResult(List<Appliance> inputs, out Appliance result)
		{
			result = null;
			if (inputs.IsNullOrEmpty())
			{
				return false;
			}
			ShoppingTags tag = inputs[0].ShoppingTags;
			if (MatchTags)
			{
				foreach (Appliance input in inputs)
				{
					tag &= input.ShoppingTags;
				}
			}
			List<Appliance> list = (from a in GameData.Main.Get<Appliance>()
				where !inputs.Contains(a) && (!MatchTags || (a.ShoppingTags & tag) != ShoppingTags.None) && (!RefuseDecorations || !a.ShoppingTags.HasFlag(ShoppingTags.Decoration)) && !a.ShoppingTags.HasFlag(ShoppingTags.SpecialEvent) && !a.SellOnlyAsDuplicate && !a.SellOnlyAsUnique && a.RequiresForShop.IsNullOrEmpty() && a.RequiresProcessForShop.IsNullOrEmpty() && (!OnlyPurchasable || a.IsPurchasable)
				select a).ToList();
			if (list.Count == 0)
			{
				return false;
			}
			result = list.Random();
			return true;
		}
	}
}
