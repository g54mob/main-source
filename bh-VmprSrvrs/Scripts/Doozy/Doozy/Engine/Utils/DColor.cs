using System;
using UnityEngine;

namespace Doozy.Engine.Utils
{
	[Serializable]
	public class DColor
	{
		private const string UNNAMED_COLOR = "Unnamed Color";

		public string ColorName;

		public Color Light;

		public Color Normal;

		public Color Dark;

		private static Color GetLightColor(Color normalColor)
		{
			return default(Color);
		}

		private static Color GetDarkColor(Color normalColor)
		{
			return default(Color);
		}

		public DColor(Color normal)
		{
		}

		public DColor(string colorName)
		{
		}

		public DColor(string colorName, Color normal)
		{
		}

		public DColor(Color light, Color normal, Color dark)
		{
		}

		public DColor(string colorName, Color light, Color normal, Color dark)
		{
		}

		public DColor(DColor dColor)
		{
		}
	}
}
