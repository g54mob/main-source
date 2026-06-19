using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public class FoldoutGroupAttribute : PropertyGroupAttribute
	{
		public FoldoutGroupAttribute(string groupName)
			: base(null)
		{
		}
	}
}
