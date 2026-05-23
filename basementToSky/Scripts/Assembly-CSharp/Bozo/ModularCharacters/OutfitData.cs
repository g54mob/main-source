using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bozo.ModularCharacters
{
	[Serializable]
	public class OutfitData
	{
		public string outfit;

		public List<Color> colors;

		public string decal;

		public List<Color> decalColors;

		public Vector4 decalScale;

		public string pattern;

		public List<Color> patternColors;

		public Vector4 patternScale;

		public bool[] partVisibility;

		public Color color = Color.white;

		public int swatch;
	}
}
