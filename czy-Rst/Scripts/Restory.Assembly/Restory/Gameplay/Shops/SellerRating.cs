using System;
using UnityEngine;

namespace Restory.Gameplay.Shops
{
	[Serializable]
	public class SellerRating
	{
		[SerializeField]
		[Range(1f, 5f)]
		private int rating;

		public int Rating => rating;

		public SellerRating(int rating)
		{
			this.rating = rating;
		}
	}
}
