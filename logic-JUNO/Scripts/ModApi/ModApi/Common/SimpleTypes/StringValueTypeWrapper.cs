using System;
using System.Collections;
using System.Collections.Generic;

namespace ModApi.Common.SimpleTypes
{
	public struct StringValueTypeWrapper : IComparable, ICloneable, IConvertible, IEnumerable, IComparable<string>, IEnumerable<char>, IEquatable<string>, IComparable<StringValueTypeWrapper>, IEquatable<StringValueTypeWrapper>
	{
		public readonly string Value;

		public StringValueTypeWrapper(string value)
		{
			Value = value;
		}

		public static implicit operator string(StringValueTypeWrapper value)
		{
			return value.Value;
		}

		public static implicit operator StringValueTypeWrapper(string value)
		{
			return new StringValueTypeWrapper(value);
		}

		public static bool operator !=(StringValueTypeWrapper lhs, StringValueTypeWrapper rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static bool operator ==(StringValueTypeWrapper lhs, StringValueTypeWrapper rhs)
		{
			return lhs.Equals(rhs);
		}

		public object Clone()
		{
			return this;
		}

		public int CompareTo(object other)
		{
			if (other is string)
			{
				return Value.CompareTo(other);
			}
			return CompareTo((StringValueTypeWrapper)other);
		}

		public int CompareTo(string other)
		{
			return Value.CompareTo(other);
		}

		public int CompareTo(StringValueTypeWrapper other)
		{
			return Value.CompareTo(other.Value);
		}

		public bool Equals(string other)
		{
			return Value.Equals(other);
		}

		public override bool Equals(object obj)
		{
			if (obj is StringValueTypeWrapper)
			{
				return Equals((StringValueTypeWrapper)obj);
			}
			if (obj is string)
			{
				return Equals((string)obj);
			}
			return false;
		}

		public bool Equals(StringValueTypeWrapper value)
		{
			if (Value == null)
			{
				return value.Value == null;
			}
			return Value.Equals(value.Value);
		}

		public IEnumerator GetEnumerator()
		{
			return Value.GetEnumerator();
		}

		IEnumerator<char> IEnumerable<char>.GetEnumerator()
		{
			return Value.GetEnumerator();
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return Value.GetTypeCode();
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToBoolean(provider);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToByte(provider);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToChar(provider);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToDateTime(provider);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToDecimal(provider);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToDouble(provider);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToInt16(provider);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToInt32(provider);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToInt64(provider);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToSByte(provider);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToSingle(provider);
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToString(provider);
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible)Value).ToType(conversionType, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToUInt16(provider);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToUInt32(provider);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToUInt64(provider);
		}
	}
}
