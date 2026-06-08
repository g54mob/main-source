using System;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet
{
	public sealed class UndefinedBindingResultCache
	{
		private static readonly Func<string, DeferredValue<string, UndefinedBindingResult>> ValueFactory = (string s) => new DeferredValue<string, UndefinedBindingResult>(s, (string v) => new UndefinedBindingResult(v));

		private readonly LookupSlim<string, DeferredValue<string, UndefinedBindingResult>, StringEqualityComparer> _cache = new LookupSlim<string, DeferredValue<string, UndefinedBindingResult>, StringEqualityComparer>(new StringEqualityComparer(StringComparison.Ordinal));

		public static UndefinedBindingResultCache Current => AmbientContext.Current?.UndefinedBindingResultCache;

		internal UndefinedBindingResultCache()
		{
		}

		public UndefinedBindingResult Create(string value)
		{
			return _cache.GetOrAdd(value, ValueFactory).Value;
		}
	}
}
