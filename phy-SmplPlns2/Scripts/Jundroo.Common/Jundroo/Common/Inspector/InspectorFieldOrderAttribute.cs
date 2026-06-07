using System;

namespace Jundroo.Common.Inspector
{
	public class InspectorFieldOrderAttribute : Attribute
	{
		public int Order { get; set; }

		public InspectorFieldOrderAttribute()
		{
		}

		public InspectorFieldOrderAttribute(int order)
		{
			Order = order;
		}
	}
}
