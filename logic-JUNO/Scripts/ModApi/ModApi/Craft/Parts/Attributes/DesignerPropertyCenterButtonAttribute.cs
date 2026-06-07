using System;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class DesignerPropertyCenterButtonAttribute : DesignerPropertyAttribute
	{
		public DesignerPropertyCenterButtonAttribute()
		{
			base.NeverSerialize = true;
		}
	}
}
