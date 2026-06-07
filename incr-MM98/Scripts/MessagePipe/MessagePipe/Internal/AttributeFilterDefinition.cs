using System;

namespace MessagePipe.Internal
{
	internal sealed class AttributeFilterDefinition : FilterDefinition
	{
		public AttributeFilterDefinition(Type filterType, int order)
			: base(filterType, order)
		{
		}
	}
}
