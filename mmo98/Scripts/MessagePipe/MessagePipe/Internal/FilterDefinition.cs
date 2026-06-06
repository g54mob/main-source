using System;

namespace MessagePipe.Internal
{
	internal abstract class FilterDefinition
	{
		public Type FilterType { get; }

		public int Order { get; }

		public FilterDefinition(Type filterType, int order)
		{
			FilterType = filterType;
			Order = order;
		}
	}
}
