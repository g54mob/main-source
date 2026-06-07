using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	public static class EColorExtensions
	{
		public static Color GetColor(this EColor color)
		{
			switch (color)
			{
			case EColor.Aqua:
			case EColor.Cyan:
				return Color.cyan;
			case EColor.Black:
				return Color.black;
			case EColor.Blue:
				return Color.blue;
			case EColor.Brown:
				return Colors.GetColorByName("brown");
			case EColor.DarkBlue:
				return Colors.GetColorByName("darkblue");
			case EColor.Fuchsia:
				return Color.magenta;
			case EColor.Green:
				return Colors.GetColorByName("green");
			case EColor.Gray:
			case EColor.Grey:
				return Color.gray;
			case EColor.LightBlue:
				return Colors.GetColorByName("lightblue");
			case EColor.Lime:
				return Color.green;
			case EColor.Magenta:
				return Color.magenta;
			case EColor.Maroon:
				return Colors.GetColorByName("maroon");
			case EColor.Navy:
				return Colors.GetColorByName("navy");
			case EColor.Olive:
				return Colors.GetColorByName("olive");
			case EColor.Orange:
				return Colors.GetColorByName("orange");
			case EColor.Purple:
				return Colors.GetColorByName("purple");
			case EColor.Red:
				return Color.red;
			case EColor.Silver:
				return Colors.GetColorByName("silver");
			case EColor.Teal:
				return Colors.GetColorByName("teal");
			case EColor.White:
				return Color.white;
			case EColor.Yellow:
				return Color.yellow;
			case EColor.Clear:
				return Color.clear;
			case EColor.Pink:
				return Colors.GetColorByName("pink");
			case EColor.Indigo:
				return Colors.GetColorByName("indigo");
			case EColor.Violet:
				return Colors.GetColorByName("violet");
			case EColor.CharcoalGray:
				return Colors.GetColorByName("charcoalgray");
			case EColor.OceanicSlate:
				return Colors.GetColorByName("oceanicslate");
			case EColor.MidnightAsh:
				return Colors.GetColorByName("midnightash");
			default:
				return Color.white;
			}
		}
	}
}
