using UnityEngine;

namespace App.Data
{
	public class ElementColor
	{
		public string Name;

		public string KeyName;

		public int r;

		public int g;

		public int b;

		public float a;

		public string hex;

		public Color AsNormalizedFloat()
		{
			return new Color((float)r * 0.003921569f, (float)g * 0.003921569f, (float)b * 0.003921569f, a);
		}
	}
}
