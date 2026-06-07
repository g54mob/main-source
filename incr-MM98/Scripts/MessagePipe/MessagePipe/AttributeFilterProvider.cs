using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class AttributeFilterProvider<TAttribute> where TAttribute : IMessagePipeFilterAttribute
	{
		private readonly ConcurrentDictionary<Type, AttributeFilterDefinition[]> cache = new ConcurrentDictionary<Type, AttributeFilterDefinition[]>();

		[Preserve]
		public AttributeFilterProvider()
		{
		}

		public (int, IEnumerable<IMessagePipeFilter>) GetAttributeFilters(Type handlerType, IServiceProvider provider)
		{
			if (cache.TryGetValue(handlerType, out var value))
			{
				if (value.Length == 0)
				{
					return (0, Array.Empty<IMessagePipeFilter>());
				}
				return (value.Length, CreateFilters(value, provider));
			}
			TAttribute[] array = handlerType.GetCustomAttributes(typeof(IMessagePipeFilterAttribute), inherit: true).OfType<TAttribute>().ToArray();
			if (array.Length == 0)
			{
				cache[handlerType] = Array.Empty<AttributeFilterDefinition>();
				return (0, Array.Empty<IMessagePipeFilter>());
			}
			AttributeFilterDefinition[] value2 = (from TAttribute x in array
				select new AttributeFilterDefinition(x.Type, x.Order)).ToArray();
			AttributeFilterDefinition[] orAdd = cache.GetOrAdd(handlerType, value2);
			return (orAdd.Length, CreateFilters(orAdd, provider));
		}

		private static IEnumerable<IMessagePipeFilter> CreateFilters(AttributeFilterDefinition[] filterDefinitions, IServiceProvider provider)
		{
			foreach (AttributeFilterDefinition attributeFilterDefinition in filterDefinitions)
			{
				IMessagePipeFilter messagePipeFilter = (IMessagePipeFilter)provider.GetRequiredService(attributeFilterDefinition.FilterType);
				messagePipeFilter.Order = attributeFilterDefinition.Order;
				yield return messagePipeFilter;
			}
		}
	}
}
