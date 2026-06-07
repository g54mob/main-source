using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Shop", Scope.Project)]
	public class ShopSettings : CustomSettings<ShopSettings>
	{
		[Header("Name")]
		[SerializeField]
		private string m_shopName = "Shop";

		[Header("Clients")]
		[SerializeField]
		private int m_maxClientsInside = 10;

		[SerializeField]
		private int m_clientBonusByExtension = 1;

		[Header("Recycling")]
		[SerializeField]
		private float m_binMoney = 1f;

		[SerializeField]
		private float m_trashBinMoney = 1f;

		public static string ShopName => CustomSettings<ShopSettings>.I.m_shopName;

		public static int MaxClientsInside => CustomSettings<ShopSettings>.I.m_maxClientsInside;

		public static int ClientBonusByExtension => CustomSettings<ShopSettings>.I.m_clientBonusByExtension;

		public static float BinMoney => CustomSettings<ShopSettings>.I.m_binMoney;

		public static float TrashBinMoney => CustomSettings<ShopSettings>.I.m_trashBinMoney;
	}
}
