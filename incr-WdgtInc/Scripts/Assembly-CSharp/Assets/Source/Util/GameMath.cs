using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.Util
{
	public class GameMath
	{
		public const float TierScaleFactor = 2.3f;

		public static string FormatNumber(BigInteger number)
		{
			return FormatNumber((double)number);
		}

		public static string FormatNumber(double num, int decimals = -1)
		{
			if (num >= 1000.0)
			{
				decimals = 0;
			}
			if (decimals == -1)
			{
				decimals = ((num > 0.0 && num < 1.0) ? 1 : 0);
			}
			string text;
			if (num >= 10000.0)
			{
				int num2 = 0;
				do
				{
					num /= 1000.0;
					num2++;
				}
				while (num >= 1000.0);
				text = num2 switch
				{
					1 => "K", 
					2 => "M", 
					3 => "B", 
					4 => "T", 
					5 => "Qa", 
					6 => "Qi", 
					7 => "Sx", 
					8 => "Sp", 
					9 => "Oc", 
					_ => "Xx", 
				};
				decimals = ((num < 1.0) ? 3 : ((num < 10.0) ? 2 : ((num < 100.0) ? 1 : 0)));
			}
			else
			{
				text = "";
			}
			return num.ToString("N" + decimals, new CultureInfo(Translation.CurrentLocale)) + text;
		}

		public static Dictionary<ItemType, BigInteger> CreateItemCost(string seed, int tier, double multiplier, IList<ItemType> items)
		{
			Dictionary<ItemType, BigInteger> dictionary = new Dictionary<ItemType, BigInteger>();
			if (items.Count == 0)
			{
				return dictionary;
			}
			for (int i = 0; i < items.Count; i++)
			{
				dictionary[items[i]] = 0;
			}
			double num = multiplier * Math.Pow(2.299999952316284, tier);
			SeededRandom seededRandom = new SeedGenerator().Add("CreateItemCost").Add(seed).CreateRandom();
			num *= (double)seededRandom.RandomRange(0.9f, 1.1f);
			while (num > 0.0)
			{
				ItemType itemType = seededRandom.Choose(items);
				dictionary[itemType] += (BigInteger)1;
				num -= (double)itemType.Value;
			}
			for (int j = 0; j < items.Count; j++)
			{
				if (dictionary[items[j]] == 0L)
				{
					dictionary.Remove(items[j]);
				}
			}
			return dictionary;
		}

		public static string FormatItemCount(ItemType type, BigInteger count)
		{
			BigInteger inventoryCapacity = GamePlayer.Current.GetInventoryCapacity(type);
			if (count > inventoryCapacity)
			{
				return FormatNumber((double)inventoryCapacity) + "+";
			}
			return FormatNumber((double)count);
		}

		public static string FormatTime(int tSec)
		{
			int num = tSec % 60;
			int num2 = tSec % 3600 / 60;
			int num3 = tSec / 3600;
			return Translation.TranslateOnly((num3 > 0) ? "@TimeFormatHMS" : "@TimeFormatMS", num3, num2, num);
		}

		public static string FormatPercentage(double percentage, FormatPercentageMode mode = FormatPercentageMode.Default, int decimals = 0)
		{
			NumberFormatInfo instance = NumberFormatInfo.GetInstance(new CultureInfo(Translation.CurrentLocale));
			instance.PercentPositivePattern = 1;
			if (mode == FormatPercentageMode.Default)
			{
				return percentage.ToString("P" + decimals, instance);
			}
			percentage -= 1.0;
			return ((percentage < 0.0) ? "" : "+") + percentage.ToString("P" + decimals, instance);
		}

		public static bool LineIntersects(UnityEngine.Vector2 lineOneA, UnityEngine.Vector2 lineOneB, UnityEngine.Vector2 lineTwoA, UnityEngine.Vector2 lineTwoB)
		{
			if ((lineTwoB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) > (lineTwoA.y - lineOneA.y) * (lineTwoB.x - lineOneA.x) != (lineTwoB.y - lineOneB.y) * (lineTwoA.x - lineOneB.x) > (lineTwoA.y - lineOneB.y) * (lineTwoB.x - lineOneB.x))
			{
				return (lineTwoA.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) != (lineTwoB.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoB.x - lineOneA.x);
			}
			return false;
		}

		public static float Clamp01(BigInteger numerator, BigInteger denominator)
		{
			if (numerator <= 0L)
			{
				return 0f;
			}
			if (numerator >= denominator)
			{
				return 1f;
			}
			return (float)((double)numerator / (double)denominator);
		}

		public static BigInteger Multiply(BigInteger value, double mul)
		{
			return new BigInteger((double)value * mul);
		}

		public static double Divide(BigInteger value, double div)
		{
			return (double)value / div;
		}
	}
}
