using System;

namespace PG
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ShowInInspectorIf : HideInInspectorIf
	{
		public ShowInInspectorIf(string propertyToCheck)
			: base(null, hideInInspector: false)
		{
		}
	}
}
