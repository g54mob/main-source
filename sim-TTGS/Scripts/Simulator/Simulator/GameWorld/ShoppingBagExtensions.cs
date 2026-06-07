using System.Collections.Generic;

namespace Simulator.GameWorld
{
	public static class ShoppingBagExtensions
	{
		public static void Fill(this ShoppingBag bag, List<BoughtProductInfo> productInfos, bool show = true)
		{
			if (show)
			{
				bag.Show();
			}
			foreach (BoughtProductInfo productInfo in productInfos)
			{
				if (productInfo.Data != null)
				{
					Product product = World.ProductFactory.CreateProduct(productInfo);
					if (product != null)
					{
						bag.AddProduct(product);
					}
				}
			}
		}
	}
}
