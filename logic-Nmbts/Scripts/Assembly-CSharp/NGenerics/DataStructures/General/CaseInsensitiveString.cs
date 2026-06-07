using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	[ComVisible(true)]
	public sealed class CaseInsensitiveString : IComparable, IConvertible, IComparable<string>, IEquatable<string>, IEquatable<CaseInsensitiveString>, IXmlSerializable, IEnumerable<char>, IEnumerable, ICloneable, ISerializable
	{
		public string Value { get; set; }

		public char this[int index]
		{
			get
			{
				return Value[index];
			}
		}

		public int Length
		{
			get
			{
				return Value.Length;
			}
		}

		public CaseInsensitiveString()
		{
			Value = string.Empty;
		}

		public CaseInsensitiveString(string value)
		{
			Guard.ArgumentNotNull(value, "value");
			Value = value;
		}

		private CaseInsensitiveString(SerializationInfo info, StreamingContext context)
		{
			Guard.ArgumentNotNull(info, "info");
			Value = (string)info.GetValue("StringValue", typeof(string));
		}

		public CaseInsensitiveString GetLastAfter(string after)
		{
			Guard.ArgumentNotNullOrEmptyString(after, "after");
			if (Contains(after))
			{
				int num = LastIndexOf(after);
				return Substring(num + 1, Length - num - 1);
			}
			return Value;
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteValue(Value);
		}

		public void ReadXml(XmlReader reader)
		{
			Value = reader.ReadElementContentAsString();
		}

		public CharEnumerator GetEnumerator()
		{
			return Value.GetEnumerator();
		}

		private static bool EqualsHelper(CaseInsensitiveString left, CaseInsensitiveString right)
		{
			return left.Value.Equals(right.Value, StringComparison.InvariantCultureIgnoreCase);
		}

		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			Guard.ArgumentNotNull(info, "info");
			info.AddValue("StringValue", Value);
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public object Clone()
		{
			return Value.Clone();
		}

		public int CompareTo(object value)
		{
			return Value.CompareTo(value);
		}

		public int CompareTo(string strB)
		{
			return Value.CompareTo(strB);
		}

		public string ToString(IFormatProvider provider)
		{
			return Value.ToString(provider);
		}

		public TypeCode GetTypeCode()
		{
			return Value.GetTypeCode();
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToBoolean(provider);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToChar(provider);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToSByte(provider);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToByte(provider);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToInt16(provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToUInt16(provider);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToInt32(provider);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToUInt32(provider);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToInt64(provider);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToUInt64(provider);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToSingle(provider);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToDouble(provider);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToDecimal(provider);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return ((IConvertible)Value).ToDateTime(provider);
		}

		object IConvertible.ToType(Type type, IFormatProvider provider)
		{
			return ((IConvertible)Value).ToType(type, provider);
		}

		IEnumerator<char> IEnumerable<char>.GetEnumerator()
		{
			return ((IEnumerable<char>)Value).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)Value).GetEnumerator();
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public bool Equals(string value)
		{
			return this == (CaseInsensitiveString)value;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public bool Equals(CaseInsensitiveString value)
		{
			return this == value;
		}

		public static bool operator ==(CaseInsensitiveString a, CaseInsensitiveString b)
		{
			if ((object)a != b)
			{
				if ((object)a != null && (object)b != null)
				{
					return EqualsHelper(a, b);
				}
				return false;
			}
			return true;
		}

		public static bool operator !=(CaseInsensitiveString a, CaseInsensitiveString b)
		{
			return !(a == b);
		}

		public static implicit operator string(CaseInsensitiveString value)
		{
			if (value == null)
			{
				return null;
			}
			return value.Value;
		}

		public static implicit operator CaseInsensitiveString(string value)
		{
			if (value == null)
			{
				return null;
			}
			return new CaseInsensitiveString(value);
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public override bool Equals(object obj)
		{
			string text = obj as string;
			if (text == null)
			{
				return false;
			}
			return Equals(text);
		}

		public char[] ToCharArray()
		{
			return Value.ToCharArray();
		}

		public char[] ToCharArray(int startIndex, int length)
		{
			return Value.ToCharArray(startIndex, length);
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public override int GetHashCode()
		{
			return Value.ToUpper().GetHashCode();
		}

		public CaseInsensitiveString[] Split(params char[] separator)
		{
			return StringArrayTo(Value.Split(separator));
		}

		public CaseInsensitiveString[] Split(char[] separator, int count)
		{
			return StringArrayTo(Value.Split(separator, count));
		}

		[ComVisible(false)]
		public CaseInsensitiveString[] Split(char[] separator, StringSplitOptions options)
		{
			return StringArrayTo(Value.Split(separator, options));
		}

		[ComVisible(false)]
		public CaseInsensitiveString[] Split(char[] separator, int count, StringSplitOptions options)
		{
			return StringArrayTo(Value.Split(separator, count, options));
		}

		[ComVisible(false)]
		public CaseInsensitiveString[] Split(string[] separator, StringSplitOptions options)
		{
			return StringArrayTo(Value.Split(separator, options));
		}

		[ComVisible(false)]
		public CaseInsensitiveString[] Split(string[] separator, int count, StringSplitOptions options)
		{
			return StringArrayTo(Value.Split(separator, count, options));
		}

		private static CaseInsensitiveString[] StringArrayTo(string[] strings)
		{
			CaseInsensitiveString[] array = new CaseInsensitiveString[strings.Length];
			for (int i = 0; i < strings.Length; i++)
			{
				array[i] = strings[i];
			}
			return array;
		}

		public CaseInsensitiveString Substring(int startIndex)
		{
			return Value.Substring(startIndex);
		}

		public CaseInsensitiveString Substring(int startIndex, int length)
		{
			return Value.Substring(startIndex, length);
		}

		public CaseInsensitiveString Trim(params char[] trimChars)
		{
			return Value.Trim(trimChars);
		}

		public CaseInsensitiveString TrimStart(params char[] trimChars)
		{
			return Value.TrimStart(trimChars);
		}

		public CaseInsensitiveString TrimEnd(params char[] trimChars)
		{
			return Value.TrimEnd(trimChars);
		}

		public bool IsNormalized()
		{
			return Value.IsNormalized();
		}

		public bool IsNormalized(NormalizationForm normalizationForm)
		{
			return Value.IsNormalized(normalizationForm);
		}

		public CaseInsensitiveString Normalize()
		{
			return Value.Normalize();
		}

		public CaseInsensitiveString Normalize(NormalizationForm normalizationForm)
		{
			return Value.Normalize(normalizationForm);
		}

		public bool Contains(string value)
		{
			return Value.ToUpper(CultureInfo.InvariantCulture).Contains(value.ToUpper(CultureInfo.InvariantCulture));
		}

		public bool EndsWith(string value)
		{
			return Value.EndsWith(value, StringComparison.InvariantCultureIgnoreCase);
		}

		[ComVisible(false)]
		public bool EndsWith(string value, StringComparison comparisonType)
		{
			return Value.EndsWith(value, comparisonType);
		}

		public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
		{
			return Value.EndsWith(value, ignoreCase, culture);
		}

		public int IndexOf(char value)
		{
			return Value.IndexOf(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}

		public int IndexOf(char value, int startIndex)
		{
			return Value.IndexOf(value.ToString(), startIndex, StringComparison.InvariantCultureIgnoreCase);
		}

		public int IndexOf(char value, int startIndex, int count)
		{
			return Value.IndexOf(value.ToString(), startIndex, count, StringComparison.InvariantCultureIgnoreCase);
		}

		public int IndexOfAny(char[] anyOf)
		{
			return Value.IndexOfAny(anyOf);
		}

		public int IndexOfAny(char[] anyOf, int startIndex)
		{
			return Value.IndexOfAny(anyOf, startIndex);
		}

		public int IndexOfAny(char[] anyOf, int startIndex, int count)
		{
			return Value.IndexOfAny(anyOf, startIndex, count);
		}

		public int IndexOf(string value)
		{
			return Value.IndexOf(value, StringComparison.InvariantCultureIgnoreCase);
		}

		public int IndexOf(string value, int startIndex)
		{
			return Value.IndexOf(value, startIndex, StringComparison.InvariantCultureIgnoreCase);
		}

		public int IndexOf(string value, int startIndex, int count)
		{
			return Value.IndexOf(value, startIndex, count, StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOf(char value)
		{
			return Value.LastIndexOf(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOf(char value, int startIndex)
		{
			return Value.LastIndexOf(value.ToString(), startIndex, StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOf(char value, int startIndex, int count)
		{
			return Value.LastIndexOf(value.ToString(), startIndex, count, StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOfAny(char[] anyOf)
		{
			return Value.LastIndexOfAny(anyOf);
		}

		public int LastIndexOfAny(char[] anyOf, int startIndex)
		{
			return Value.LastIndexOfAny(anyOf, startIndex);
		}

		public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
		{
			return Value.LastIndexOfAny(anyOf, startIndex, count);
		}

		public int LastIndexOf(string value)
		{
			return Value.LastIndexOf(value, StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOf(string value, int startIndex)
		{
			return Value.LastIndexOf(value, startIndex, StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOf(string value, int startIndex, int count)
		{
			return Value.LastIndexOf(value, startIndex, count, StringComparison.InvariantCultureIgnoreCase);
		}

		public int LastIndexOf(string value, StringComparison comparisonType)
		{
			return Value.LastIndexOf(value, comparisonType);
		}

		public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
		{
			return Value.LastIndexOf(value, startIndex, comparisonType);
		}

		public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
		{
			return Value.LastIndexOf(value, startIndex, count, comparisonType);
		}

		public CaseInsensitiveString PadLeft(int totalWidth)
		{
			return Value.PadLeft(totalWidth);
		}

		public CaseInsensitiveString PadLeft(int totalWidth, char paddingChar)
		{
			return Value.PadLeft(totalWidth, paddingChar);
		}

		public CaseInsensitiveString PadRight(int totalWidth)
		{
			return Value.PadRight(totalWidth);
		}

		public CaseInsensitiveString PadRight(int totalWidth, char paddingChar)
		{
			return Value.PadRight(totalWidth, paddingChar);
		}

		public bool StartsWith(string value)
		{
			return Value.StartsWith(value, StringComparison.InvariantCultureIgnoreCase);
		}

		[ComVisible(false)]
		public bool StartsWith(string value, StringComparison comparisonType)
		{
			return Value.StartsWith(value, comparisonType);
		}

		public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
		{
			return Value.StartsWith(value, ignoreCase, culture);
		}

		public string ToLower()
		{
			return Value.ToLower();
		}

		public string ToLower(CultureInfo culture)
		{
			return Value.ToLower(culture);
		}

		public string ToLowerInvariant()
		{
			return Value.ToLowerInvariant();
		}

		public string ToUpperInvariant()
		{
			return Value.ToUpperInvariant();
		}

		public string ToUpper()
		{
			return Value.ToUpper();
		}

		public string ToUpper(CultureInfo culture)
		{
			return Value.ToUpper(culture);
		}

		public override string ToString()
		{
			return Value;
		}

		public CaseInsensitiveString Trim()
		{
			return Value.Trim();
		}

		public CaseInsensitiveString Insert(int startIndex, string value)
		{
			return Value.Insert(startIndex, value);
		}

		public CaseInsensitiveString Replace(char oldChar, char newChar)
		{
			return Replace(oldChar.ToString(), newChar.ToString());
		}

		public CaseInsensitiveString Replace(string pattern, string replacement)
		{
			if (string.IsNullOrEmpty(pattern))
			{
				return this;
			}
			int num = 0;
			int length = pattern.Length;
			int num2 = Value.IndexOf(pattern, StringComparison.InvariantCultureIgnoreCase);
			StringBuilder stringBuilder = new StringBuilder();
			while (num2 >= 0)
			{
				stringBuilder.Append(Value, num, num2 - num);
				stringBuilder.Append(replacement);
				num = num2 + length;
				num2 = Value.IndexOf(pattern, num, StringComparison.InvariantCultureIgnoreCase);
			}
			stringBuilder.Append(Value, num, Value.Length - num);
			return stringBuilder.ToString();
		}

		public CaseInsensitiveString Remove(int startIndex, int count)
		{
			return Value.Remove(startIndex, count);
		}

		public CaseInsensitiveString Remove(int startIndex)
		{
			return Value.Remove(startIndex);
		}

		public CaseInsensitiveString RemoveEnd(string toRemove)
		{
			Guard.ArgumentNotNullOrEmptyString(toRemove, "toRemove");
			if (EndsWith(toRemove))
			{
				return Substring(0, Length - toRemove.Length);
			}
			return this;
		}
	}
}
