using System;
using System.Runtime.CompilerServices;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.PathStructure
{
	public sealed class ChainSegmentStore
	{
		internal readonly struct CreationProperties
		{
			public readonly string String;

			public readonly WellKnownVariable KnownVariable;

			public CreationProperties(string @string, WellKnownVariable knownVariable = WellKnownVariable.None)
			{
				String = @string;
				KnownVariable = knownVariable;
			}
		}

		private static readonly Func<string, WellKnownVariable, DeferredValue<CreationProperties, ChainSegment>> ValueFactory = (string s, WellKnownVariable v) => new DeferredValue<CreationProperties, ChainSegment>(new CreationProperties(s, v), (CreationProperties properties) => new ChainSegment(properties.String, properties.KnownVariable));

		private readonly LookupSlim<string, DeferredValue<CreationProperties, ChainSegment>, StringEqualityComparer> _lookup = new LookupSlim<string, DeferredValue<CreationProperties, ChainSegment>, StringEqualityComparer>(new StringEqualityComparer(StringComparison.Ordinal));

		public static ChainSegmentStore Current => AmbientContext.Current?.ChainSegmentStore;

		internal ChainSegmentStore()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ChainSegment Create(string value)
		{
			return _lookup.GetOrAdd(value, ValueFactory, WellKnownVariable.None).Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ChainSegment Create(object value)
		{
			if (value is ChainSegment result)
			{
				return result;
			}
			return _lookup.GetOrAdd((value as string) ?? value.ToString(), ValueFactory, WellKnownVariable.None).Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ChainSegment Create(string value, WellKnownVariable variable)
		{
			return _lookup.GetOrAdd(value, ValueFactory, variable).Value;
		}
	}
}
