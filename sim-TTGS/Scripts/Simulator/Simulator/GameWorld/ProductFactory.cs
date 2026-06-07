using UnityEngine;

namespace Simulator.GameWorld
{
	public class ProductFactory : WorldManager
	{
		public virtual Product CreateProduct(BoughtProductInfo boughtProductInfo)
		{
			Product product = Object.Instantiate(boughtProductInfo.Data.Prefab);
			product.Init(boughtProductInfo.Data, boughtProductInfo.Price);
			return product;
		}
	}
}
