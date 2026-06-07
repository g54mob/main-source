using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class PropertyTooltipAttribute : Attribute
	{
		public string Tooltip;

		public PropertyTooltipAttribute(string tooltip)
		{
			Tooltip = tooltip;
		}
	}
}
