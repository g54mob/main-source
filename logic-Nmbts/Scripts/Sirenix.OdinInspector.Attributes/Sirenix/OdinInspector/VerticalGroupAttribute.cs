using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class VerticalGroupAttribute : PropertyGroupAttribute
	{
		public float PaddingTop;

		public float PaddingBottom;

		public VerticalGroupAttribute(string groupId, int order = 0)
			: base(groupId, order)
		{
		}

		public VerticalGroupAttribute(int order = 0)
			: this("_DefaultVerticalGroup", order)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			VerticalGroupAttribute verticalGroupAttribute = other as VerticalGroupAttribute;
			if (verticalGroupAttribute != null)
			{
				if (verticalGroupAttribute.PaddingTop != 0f)
				{
					PaddingTop = verticalGroupAttribute.PaddingTop;
				}
				if (verticalGroupAttribute.PaddingBottom != 0f)
				{
					PaddingBottom = verticalGroupAttribute.PaddingBottom;
				}
			}
		}
	}
}
