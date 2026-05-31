using System.Collections.Generic;
using System.Globalization;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.Util
{
	public class GameMath
	{
		public const float TierScaleFactor = 2.3f;

		public static string FormatNumber(float num, int decimals = 0)
		{
			return num.ToString("N" + decimals);
		}

		public static Dictionary<ItemType, int> CreateItemCost(string seed, int tier, float multiplier, IList<ItemType> items)
		{
			Dictionary<ItemType, int> dictionary = new Dictionary<ItemType, int>();
			if (items.Count == 0)
			{
				return dictionary;
			}
			for (int i = 0; i < items.Count; i++)
			{
				dictionary[items[i]] = 0;
			}
			float num = multiplier * Mathf.Pow(2.3f, tier);
			SeededRandom seededRandom = new SeedGenerator().Add("CreateItemCost").Add(seed).CreateRandom();
			num *= seededRandom.RandomRange(0.9f, 1.1f);
			while (num > 0f)
			{
				ItemType itemType = seededRandom.Choose(items);
				dictionary[itemType]++;
				num -= (float)itemType.Value;
			}
			for (int j = 0; j < items.Count; j++)
			{
				if (dictionary[items[j]] == 0)
				{
					dictionary.Remove(items[j]);
				}
			}
			return dictionary;
		}

		public static string FormatItemCount(ItemType type, int count)
		{
			int inventoryCapacity = GamePlayer.Current.GetInventoryCapacity(type);
			if (count > inventoryCapacity)
			{
				return FormatNumber(inventoryCapacity) + "+";
			}
			return FormatNumber(count);
		}

		public static string FormatTime(int tSec)
		{
			int num = tSec % 60;
			int num2 = tSec % 3600 / 60;
			int num3 = tSec / 3600;
			return ((num3 > 0) ? (num3 + " hours, ") : "") + num2 + " minutes and " + num + " seconds.";
		}

		public static string FormatPercentage(float percentage, FormatPercentageMode mode = FormatPercentageMode.Default, int decimals = 0)
		{
			NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
			numberFormatInfo.PercentPositivePattern = 1;
			if (mode == FormatPercentageMode.Default)
			{
				return percentage.ToString("P" + decimals, numberFormatInfo);
			}
			percentage -= 1f;
			return ((percentage < 0f) ? "" : "+") + percentage.ToString("P" + decimals, numberFormatInfo);
		}

		public static bool LineIntersects(Vector2 lineOneA, Vector2 lineOneB, Vector2 lineTwoA, Vector2 lineTwoB)
		{
			if ((lineTwoB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) > (lineTwoA.y - lineOneA.y) * (lineTwoB.x - lineOneA.x) != (lineTwoB.y - lineOneB.y) * (lineTwoA.x - lineOneB.x) > (lineTwoA.y - lineOneB.y) * (lineTwoB.x - lineOneB.x))
			{
				return (lineTwoA.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) != (lineTwoB.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoB.x - lineOneA.x);
			}
			return false;
		}
	}
}
