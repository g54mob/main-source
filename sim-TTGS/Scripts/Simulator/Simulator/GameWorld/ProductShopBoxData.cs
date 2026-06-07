using UnityEngine;

namespace Simulator.GameWorld
{
	public class ProductShopBoxData : BaseShopBoxData
	{
		[SerializeField]
		protected ProductData m_product;

		public ProductData Product => m_product;
	}
}
