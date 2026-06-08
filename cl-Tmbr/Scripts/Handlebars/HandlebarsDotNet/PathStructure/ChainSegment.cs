using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet.PathStructure
{
	public sealed class ChainSegment : IEquatable<ChainSegment>
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct ChainSegmentEqualityComparer : IEqualityComparer<ChainSegment>
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerStepThrough]
			public bool Equals(ChainSegment x, ChainSegment y)
			{
				if ((object)x == y)
				{
					return true;
				}
				if ((object)x == null)
				{
					return false;
				}
				if ((object)y == null)
				{
					return false;
				}
				if (x._hashCode == y._hashCode && x.IsThis == y.IsThis)
				{
					return x.LowerInvariant == y.LowerInvariant;
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerStepThrough]
			public int GetHashCode(ChainSegment obj)
			{
				return obj._hashCode;
			}
		}

		private static readonly Dictionary<string, WellKnownVariable> WellKnownVariables = Enum.GetNames(typeof(WellKnownVariable)).ToDictionary((string o) => o, (string o) => (WellKnownVariable)Enum.Parse(typeof(WellKnownVariable), o), StringComparer.OrdinalIgnoreCase);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _hashCode;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly string _value;

		public readonly string TrimmedValue;

		public readonly bool IsThis;

		internal readonly string LowerInvariant;

		internal readonly bool IsValue;

		internal readonly WellKnownVariable WellKnownVariable;

		public static ChainSegmentEqualityComparer EqualityComparer { get; } = default(ChainSegmentEqualityComparer);

		public static ChainSegment Index { get; } = Create("Index", WellKnownVariable.Index);

		public static ChainSegment First { get; } = Create("First", WellKnownVariable.First);

		public static ChainSegment Last { get; } = Create("Last", WellKnownVariable.Last);

		public static ChainSegment Value { get; } = Create("Value", WellKnownVariable.Value);

		public static ChainSegment Key { get; } = Create("Key", WellKnownVariable.Key);

		public static ChainSegment Root { get; } = Create("Root", WellKnownVariable.Root);

		public static ChainSegment Parent { get; } = Create("Parent", WellKnownVariable.Parent);

		public static ChainSegment This { get; } = Create("This", WellKnownVariable.This);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ChainSegment Create(string value)
		{
			return ChainSegmentStore.Current?.Create(value) ?? new ChainSegment(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ChainSegment Create(object value)
		{
			if (value is ChainSegment result)
			{
				return result;
			}
			string value2 = (value as string) ?? value.ToString();
			return ChainSegmentStore.Current?.Create(value2) ?? new ChainSegment(value2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ChainSegment Create(string value, WellKnownVariable variable)
		{
			return ChainSegmentStore.Current?.Create(value, variable) ?? new ChainSegment(value, variable);
		}

		internal ChainSegment(string value, WellKnownVariable wellKnownVariable = WellKnownVariable.None)
		{
			WellKnownVariable = wellKnownVariable;
			bool flag = string.IsNullOrEmpty(value);
			Substring substring = TrimSquareBrackets(flag ? new Substring("this") : new Substring(value));
			_value = value;
			IsThis = flag || string.Equals(value, "this", StringComparison.OrdinalIgnoreCase);
			TrimmedValue = substring.ToString();
			LowerInvariant = TrimmedValue.ToLowerInvariant();
			IsValue = LowerInvariant == "value";
			_hashCode = GetHashCodeImpl();
			if (IsThis)
			{
				WellKnownVariable = WellKnownVariable.This;
			}
			if (IsValue)
			{
				WellKnownVariable = WellKnownVariable.Value;
			}
			if (WellKnownVariable == WellKnownVariable.None && WellKnownVariables.TryGetValue(LowerInvariant, out wellKnownVariable))
			{
				WellKnownVariable = wellKnownVariable;
			}
		}

		public override string ToString()
		{
			return _value;
		}

		public bool Equals(ChainSegment other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			return EqualsImpl(other);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (!(obj is ChainSegment other))
			{
				return false;
			}
			return EqualsImpl(other);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool EqualsImpl(ChainSegment other)
		{
			if (_hashCode == other._hashCode && IsThis == other.IsThis)
			{
				return LowerInvariant == other.LowerInvariant;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		private int GetHashCodeImpl()
		{
			return (IsThis.GetHashCode() * 397) ^ LowerInvariant.GetHashCode();
		}

		public static bool operator ==(ChainSegment a, ChainSegment b)
		{
			return object.Equals(a, b);
		}

		public static bool operator !=(ChainSegment a, ChainSegment b)
		{
			return !object.Equals(a, b);
		}

		public static implicit operator string(ChainSegment segment)
		{
			return segment._value;
		}

		public static implicit operator ChainSegment(string segment)
		{
			return Create(segment);
		}

		private static Substring TrimSquareBrackets(Substring key)
		{
			if (Substring.StartsWith(in key, '[') && Substring.EndsWith(in key, ']'))
			{
				return new Substring(in key, 1, key.Length - 2);
			}
			return key;
		}
	}
}
