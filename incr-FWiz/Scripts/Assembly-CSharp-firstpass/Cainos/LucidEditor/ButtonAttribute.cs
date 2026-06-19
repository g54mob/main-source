using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ButtonAttribute : Attribute
	{
		public readonly string label;

		public readonly InspectorButtonSize size;

		public ButtonAttribute()
		{
		}

		public ButtonAttribute(string label)
		{
		}

		public ButtonAttribute(InspectorButtonSize size)
		{
		}

		public ButtonAttribute(string label, InspectorButtonSize size)
		{
		}
	}
}
