using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class BoxGroupAttribute : PropertyGroupAttribute
	{
		public BoxGroupAttribute(string groupName)
			: base(null)
		{
		}
	}
}
