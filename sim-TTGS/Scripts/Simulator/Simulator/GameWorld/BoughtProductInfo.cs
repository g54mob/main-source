using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct BoughtProductInfo
	{
		private ProductData m_productData;

		[SerializeField]
		private int m_productUID;

		[SerializeField]
		private float m_price;

		[SerializeField]
		private bool m_painted;

		public ProductData Data
		{
			get
			{
				if (m_productData == null)
				{
					m_productData = ProductDatabase.Get(m_productUID);
				}
				return m_productData;
			}
		}

		public float Price => m_price;

		public bool Painted => m_painted;

		public BoughtProductInfo(ProductData data, float price, bool painted = false)
		{
			m_productData = data;
			m_productUID = data.UID;
			m_price = price;
			m_painted = painted;
		}
	}
}
