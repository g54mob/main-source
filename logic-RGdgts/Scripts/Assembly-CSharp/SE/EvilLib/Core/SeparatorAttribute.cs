using UnityEngine;

namespace SE.EvilLib.Core
{
	public class SeparatorAttribute : PropertyAttribute
	{
		public readonly string title;

		public readonly Color textCol;

		private Color debugColor;

		public SeparatorAttribute()
		{
		}

		public SeparatorAttribute(string _title)
		{
		}

		public SeparatorAttribute(string _title, int colorR, int colorG, int colorB, int colorA)
		{
		}
	}
}
