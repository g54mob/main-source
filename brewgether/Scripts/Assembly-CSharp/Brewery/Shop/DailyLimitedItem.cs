using System;
using Brewery.Items;
using UnityEngine;

namespace Brewery.Shop
{
	[Serializable]
	public class DailyLimitedItem
	{
		[Tooltip("The item with a daily purchase limit")]
		public BreweryItem item;

		[Tooltip("Maximum quantity available per day (resets when shop opens)")]
		[Min(1f)]
		public int dailyLimit;
	}
}
