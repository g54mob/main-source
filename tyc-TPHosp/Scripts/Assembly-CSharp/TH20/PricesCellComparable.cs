using System;
using UnityEngine;

namespace TH20
{
	[AddComponentMenu("UI/Prices Comparable", 104)]
	public class PricesCellComparable : MonoBehaviour, IComparable<PricesCellComparable>, IComparable
	{
		public PricesMenu2Row _row;

		public int CompareTo(PricesCellComparable other)
		{
			int result = 0;
			if (_row != null)
			{
				result = _row.DefaultCompare(other._row);
			}
			return result;
		}

		public int CompareTo(object other)
		{
			int result = 0;
			PricesCellComparable pricesCellComparable = other as PricesCellComparable;
			if (pricesCellComparable != null)
			{
				result = CompareTo(pricesCellComparable);
			}
			return result;
		}
	}
}
