using System;
using System.Collections.Generic;

internal static class Tuple
{
	public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
	{
		return null;
	}
}
public class Tuple<T1, T2> : IFormattable
{
	private static readonly IEqualityComparer<T1> Item1Comparer;

	private static readonly IEqualityComparer<T2> Item2Comparer;

	public T1 Item1 { get; private set; }

	public T2 Item2 { get; private set; }

	public T1 x => default(T1);

	public T2 y => default(T2);

	public Tuple(T1 item1, T2 item2)
	{
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override string ToString()
	{
		return null;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		return null;
	}
}
public sealed class Tuple<T1, T2, T3>
{
	private readonly T1 item1;

	private readonly T2 item2;

	private readonly T3 item3;

	public T1 Item1 => default(T1);

	public T2 Item2 => default(T2);

	public T3 Item3 => default(T3);

	public Tuple(T1 item1, T2 item2, T3 item3)
	{
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object o)
	{
		return false;
	}

	public static bool operator ==(Tuple<T1, T2, T3> a, Tuple<T1, T2, T3> b)
	{
		return false;
	}

	public static bool operator !=(Tuple<T1, T2, T3> a, Tuple<T1, T2, T3> b)
	{
		return false;
	}

	public void Unpack(Action<T1, T2, T3> unpackerDelegate)
	{
	}
}
public sealed class Tuple<T1, T2, T3, T4>
{
	private readonly T1 item1;

	private readonly T2 item2;

	private readonly T3 item3;

	private readonly T4 item4;

	public T1 Item1 => default(T1);

	public T2 Item2 => default(T2);

	public T3 Item3 => default(T3);

	public T4 Item4 => default(T4);

	public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
	{
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object o)
	{
		return false;
	}

	public static bool operator ==(Tuple<T1, T2, T3, T4> a, Tuple<T1, T2, T3, T4> b)
	{
		return false;
	}

	public static bool operator !=(Tuple<T1, T2, T3, T4> a, Tuple<T1, T2, T3, T4> b)
	{
		return false;
	}

	public void Unpack(Action<T1, T2, T3, T4> unpackerDelegate)
	{
	}
}
