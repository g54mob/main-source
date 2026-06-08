using System;
using System.Collections.Generic;
using Networking.Formatters;
using Platforms;
using Unity.Collections;

namespace Networking.Resolver
{
	internal static class SampleCustomResolverGetFormatterHelper
	{
		private static readonly Dictionary<Type, object> formatterMap = new Dictionary<Type, object>
		{
			{
				typeof(FixedListInt64),
				new FixedListInt64Formatter()
			},
			{
				typeof(FixedString64),
				new FixedString64Formatter()
			},
			{
				typeof(PlatformUser),
				new PlatformUserFormatter()
			}
		};

		internal static object GetFormatter(Type t)
		{
			if (formatterMap.TryGetValue(t, out var value))
			{
				return value;
			}
			return null;
		}
	}
}
