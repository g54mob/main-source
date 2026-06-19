using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class HorizontalGroupAttribute : PropertyGroupAttribute
	{
		public HorizontalGroupAttribute(string groupName)
			: base(null)
		{
		}
	}
}
