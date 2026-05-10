using System;
using UnityEngine;

namespace ScheduleOne.Product
{
	[Serializable]
	public class WeedAppearanceSettings
	{
		public enum EWeedAppearanceType
		{
			Main = 0,
			Secondary = 1,
			Leaf = 2,
			Stem = 3
		}

		public Color32 MainColor;

		public Color32 SecondaryColor;

		public Color32 LeafColor;

		public Color32 StemColor;

		public WeedAppearanceSettings(Color32 mainColor, Color32 secondaryColor, Color32 leafColor, Color32 stemColor)
		{
		}

		public WeedAppearanceSettings()
		{
		}

		public bool IsUnintialized()
		{
			return false;
		}
	}
}
