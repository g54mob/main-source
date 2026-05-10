using UnityEngine;

namespace MyBox
{
	public class SeparatorAttribute : PropertyAttribute
	{
		public readonly string Title;

		public readonly bool WithOffset;

		public SeparatorAttribute()
		{
		}

		public SeparatorAttribute(string title, bool withOffset = false)
		{
		}
	}
}
