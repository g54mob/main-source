using UnityEngine;

namespace Simulator.GameWorld
{
	public class ExtensionShopBoxData : BaseShopBoxData
	{
		[Header("Content")]
		[SerializeField]
		protected bool m_shopExtension;

		[SerializeField]
		protected bool m_reserveExtension;

		public bool ShopExtension => m_shopExtension;

		public bool ReserveExtension => m_reserveExtension;
	}
}
