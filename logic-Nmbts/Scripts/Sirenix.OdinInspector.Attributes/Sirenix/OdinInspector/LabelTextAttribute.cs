using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class LabelTextAttribute : Attribute
	{
		public string Text;

		public LabelTextAttribute(string text)
		{
			Text = text;
		}
	}
}
