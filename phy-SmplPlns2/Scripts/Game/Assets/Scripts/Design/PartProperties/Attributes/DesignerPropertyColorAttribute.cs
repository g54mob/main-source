using System;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyColorAttribute : DesignerPropertyAttribute
	{
		public bool AllowTransparency { get; set; }
	}
}
