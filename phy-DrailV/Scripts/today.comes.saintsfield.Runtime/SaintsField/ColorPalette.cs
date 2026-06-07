using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaintsField
{
	public class ColorPalette : ScriptableObject
	{
		[Serializable]
		public struct ColorEntry
		{
			public Color color;

			public string displayName;
		}

		public string displayName = "";

		public List<ColorEntry> colors = new List<ColorEntry>();
	}
}
