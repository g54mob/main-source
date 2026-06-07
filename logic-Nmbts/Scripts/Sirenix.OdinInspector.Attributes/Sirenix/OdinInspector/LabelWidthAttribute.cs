using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public class LabelWidthAttribute : Attribute
	{
		public float Width;

		public LabelWidthAttribute(float width)
		{
			Width = width;
		}
	}
}
