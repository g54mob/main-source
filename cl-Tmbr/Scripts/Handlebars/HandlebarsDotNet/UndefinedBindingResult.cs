using System;
using System.Diagnostics;

namespace HandlebarsDotNet
{
	[DebuggerDisplay("undefined")]
	public sealed class UndefinedBindingResult : IEquatable<UndefinedBindingResult>
	{
		public readonly string Value;

		public static UndefinedBindingResult Create(string value)
		{
			return UndefinedBindingResultCache.Current?.Create(value) ?? new UndefinedBindingResult(value);
		}

		internal UndefinedBindingResult(string value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value;
		}

		public bool Equals(UndefinedBindingResult other)
		{
			return Value == other?.Value;
		}

		public override bool Equals(object obj)
		{
			if (obj is UndefinedBindingResult other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (Value == null)
			{
				return 0;
			}
			return Value.GetHashCode();
		}
	}
}
