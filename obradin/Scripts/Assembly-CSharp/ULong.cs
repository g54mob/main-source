using System;
using UnityEngine;

[Serializable]
public class ULong
{
	[SerializeField]
	private uint first;

	[SerializeField]
	private uint second;

	public ulong value
	{
		get
		{
			ulong num = second;
			num <<= 32;
			return num | first;
		}
		set
		{
			first = (uint)(value & 0xFFFFFFFFu);
			second = (uint)(value >> 32);
		}
	}

	public uint firstHalf
	{
		get
		{
			return first;
		}
		set
		{
			first = value;
		}
	}

	public uint secondHalf
	{
		get
		{
			return second;
		}
		set
		{
			second = value;
		}
	}

	public ULong(ulong newValue)
	{
		value = newValue;
	}

	public ULong(uint newFirst, uint newSecond)
	{
		first = newFirst;
		second = newSecond;
	}

	public ULong()
	{
		value = 0uL;
	}

	public override string ToString()
	{
		return string.Format("[ULong: value={0}, firstHalf={1}, secondHalf={2}]", value, firstHalf, secondHalf);
	}

	public static ULong operator +(ULong a, ulong b)
	{
		return new ULong(a.value + b);
	}

	public static ULong operator +(ulong a, ULong b)
	{
		return new ULong(a + b.value);
	}

	public static ULong operator +(ULong a, int b)
	{
		return new ULong(a.value + (ulong)b);
	}

	public static ULong operator +(int a, ULong b)
	{
		return new ULong((ulong)a + b.value);
	}

	public static ULong operator -(ULong a, ulong b)
	{
		return new ULong(a.value - b);
	}

	public static ULong operator -(ulong a, ULong b)
	{
		return new ULong(a - b.value);
	}

	public static ULong operator -(ULong a, int b)
	{
		return new ULong(a.value - (ulong)b);
	}

	public static ULong operator -(int a, ULong b)
	{
		return new ULong((ulong)a - b.value);
	}

	public static ULong operator &(ULong a, ULong b)
	{
		return new ULong(a.value & b.value);
	}

	public static ulong operator &(ULong a, ulong b)
	{
		return a.value & b;
	}

	public static ULong operator &(ulong a, ULong b)
	{
		return new ULong(a & b.value);
	}

	public static ULong operator |(ULong a, ULong b)
	{
		return new ULong(a.value | b.value);
	}

	public static ULong operator |(ULong a, ulong b)
	{
		return new ULong(a.value | b);
	}

	public static ULong operator |(ulong a, ULong b)
	{
		return new ULong(a | b.value);
	}

	public static ULong operator ~(ULong n)
	{
		return new ULong(~n.value);
	}

	public static bool operator >(ULong a, ulong b)
	{
		return a.value > b;
	}

	public static bool operator >(ulong a, ULong b)
	{
		return a > b.value;
	}

	public static bool operator <(ULong a, ulong b)
	{
		return a.value < b;
	}

	public static bool operator <(ulong a, ULong b)
	{
		return a < b.value;
	}
}
