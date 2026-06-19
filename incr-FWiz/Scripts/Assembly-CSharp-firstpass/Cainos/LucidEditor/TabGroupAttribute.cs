using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class TabGroupAttribute : PropertyGroupAttribute
	{
		public readonly string tabName;

		public TabGroupAttribute(string groupName, string tabName)
			: base(null)
		{
		}
	}
}
