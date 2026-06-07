using System;
using UnityEngine;

namespace Brewery.Map
{
	[Serializable]
	public class HoverInfoLine
	{
		public string label;

		public string value;

		public Color? color;

		public Sprite icon;

		public HoverInfoLine(string label, string value, Color? color = null, Sprite icon = null)
		{
		}

		public Color GetColor()
		{
			return default(Color);
		}
	}
}
