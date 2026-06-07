using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct ShopExtensionList
	{
		[Serializable]
		private struct ShopExtension
		{
			public float price;

			public int shopLevel;
		}

		[SerializeField]
		private int m_count;

		[SerializeField]
		private ShopExtension[] m_extensions;

		public int Count => m_count;

		public float GetExtensionPrice(int level)
		{
			if (level < 0)
			{
				return 0f;
			}
			if (level >= m_count)
			{
				return 0f;
			}
			return m_extensions[level].price;
		}

		public int GetExtensionShopLevel(int level)
		{
			if (level < 0)
			{
				return 0;
			}
			if (level >= m_count)
			{
				return int.MaxValue;
			}
			return m_extensions[level].shopLevel;
		}
	}
}
