using System;
using System.Collections;
using System.Collections.Generic;

public struct FormatColorString : IFormatColorObject, IComparer<FormatColorString>, IComparer, IComparable<FormatColorString>, IComparable
{
	public readonly string Value;

	public FormatColorString(string value)
	{
		Value = value;
	}

	public bool Equals(string obj)
	{
		return Value.Equals(obj);
	}

	public int Compare(FormatColorString x, FormatColorString y)
	{
		return string.Compare(x.Value, y.Value);
	}

	public int CompareTo(FormatColorString other)
	{
		if (Value == null)
		{
			if (other.Value == null)
			{
				return 0;
			}
			return -1;
		}
		if (other.Value == null)
		{
			return 1;
		}
		return Value.CompareTo(other.Value);
	}

	public override bool Equals(object obj)
	{
		if (obj is string)
		{
			return Value.Equals(obj);
		}
		if (!(obj is FormatColorString))
		{
			return false;
		}
		FormatColorString formatColorString = (FormatColorString)obj;
		return Value.Equals(formatColorString.Value);
	}

	public override int GetHashCode()
	{
		if (Value != null)
		{
			return Value.GetHashCode();
		}
		return 0;
	}

	public override string ToString()
	{
		return Value;
	}

	public int CompareTo(object obj)
	{
		FormatColorString formatColorString = ((obj is FormatColorString) ? ((FormatColorString)obj) : ((FormatColorString)null));
		if (Value == null)
		{
			if (formatColorString.Value == null)
			{
				return 0;
			}
			return -1;
		}
		if (formatColorString.Value == null)
		{
			return 1;
		}
		return Value.CompareTo(formatColorString.Value);
	}

	public int Compare(object x, object y)
	{
		return Compare((FormatColorString)x, (FormatColorString)y);
	}

	public string GetActualString()
	{
		return Value;
	}

	public static FormatColorString operator +(FormatColorString a, FormatColorString b)
	{
		return new FormatColorString(a.Value + b.Value);
	}

	public static string operator +(FormatColorString a, string b)
	{
		return a.Value + b;
	}

	public static string operator +(string a, FormatColorString b)
	{
		return a + b.Value;
	}

	public static implicit operator FormatColorString(string v)
	{
		return new FormatColorString(v);
	}

	public static implicit operator string(FormatColorString v)
	{
		return v.Value;
	}
}
