using UnityEngine;

namespace Brewery.Map
{
	public static class HoverColorPalette
	{
		public static readonly Color STATUS_AVAILABLE;

		public static readonly Color STATUS_UNAVAILABLE;

		public static readonly Color STATUS_WARNING;

		public static readonly Color STATUS_INFO;

		public static readonly Color STATUS_BUSY;

		public static readonly Color MONEY_EARN;

		public static readonly Color MONEY_SPEND;

		public static readonly Color MONEY_BONUS;

		public static readonly Color MONEY_NEUTRAL;

		public static readonly Color DANGER_SAFE;

		public static readonly Color DANGER_CAUTION;

		public static readonly Color DANGER_HIGH;

		public static readonly Color DANGER_CRITICAL;

		public static readonly Color SPECIAL_PLAYER;

		public static readonly Color SPECIAL_LOCKED;

		public static readonly Color SPECIAL_DISTANCE;

		public static readonly Color SPECIAL_HINT;

		public static readonly Color STOCK_FULL;

		public static readonly Color STOCK_GOOD;

		public static readonly Color STOCK_LOW;

		public static readonly Color STOCK_EMPTY;

		public static Color GetStockGradient(float ratio)
		{
			return default(Color);
		}

		public static Color GetDangerGradient(float danger)
		{
			return default(Color);
		}

		public static Color GetMoneyColor(float amount)
		{
			return default(Color);
		}

		public static Color GetOccupancyColor(float ratio)
		{
			return default(Color);
		}

		public static Color GetTimeRemainingColor(float hours)
		{
			return default(Color);
		}

		public static Color GetAttractionColor(float percent)
		{
			return default(Color);
		}
	}
}
