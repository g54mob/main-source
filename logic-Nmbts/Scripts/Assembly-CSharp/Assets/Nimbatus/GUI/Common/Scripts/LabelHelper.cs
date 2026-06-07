using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public static class LabelHelper
	{
		public static string Red = "[FF1818FF]";

		public static string Black = "[000000FF]";

		public static string Orange = "[FE9800FF]";

		public static string DarkOrange = "[FC5400FF]";

		public static string Purple = "[AE00FFFF]";

		public static string White = "[FFFFFF]";

		public static string Green = "[72FF00]";

		public static string Blue = "[37A0C9FF]";

		public static string Grey = "[2C2833FF]";

		public static string LightGrey = "[727777FF]";

		public static string KickstarterGreen = "[295211FF]";

		public static string NewLine = "[-]\n";

		public static string GetColorEncoding(EMissionDifficulty difficulty)
		{
			switch (difficulty)
			{
			case EMissionDifficulty.Low:
				return "[72FF00]";
			case EMissionDifficulty.Medium:
				return "[007CFF]";
			case EMissionDifficulty.Hard:
				return "[FF1818FF]";
			default:
				return "[72FF00]";
			}
		}

		public static string GetRarityColor(EWeaponRarity rarity)
		{
			if (SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance == null)
			{
				return White;
			}
			return string.Concat("[" + ColorUtility.ToHtmlStringRGB(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.RarityColors[rarity]), "]");
		}
	}
}
