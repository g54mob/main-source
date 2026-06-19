using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class GroupAttribute : PropertyGroupAttribute
	{
		public GroupAttribute(string groupName)
			: base(null)
		{
		}
	}
}
