using UnityEngine;

public struct Substr
{
	private string str;

	private int start;

	private int count;

	public Substr(string str_ = null, int start_ = 0, int count_ = -1)
	{
		str = ((str_ != null) ? str_ : string.Empty);
		if (start_ < str.Length)
		{
			start = start_;
		}
		else
		{
			start = str.Length;
		}
		if (count_ < 0 || start + count_ > str.Length)
		{
			count = str.Length - start;
		}
		else
		{
			count = count_;
		}
	}

	public Substr Substring(int subStart, int subCount = -1)
	{
		return new Substr(str, start + subStart, subCount);
	}

	public int IndexOf(string other)
	{
		if (str.Length - start < other.Length)
		{
			return -1;
		}
		int num = str.IndexOf(other, start, count);
		if (num < 0)
		{
			return num;
		}
		return num - start;
	}

	public override string ToString()
	{
		return str.Substring(start, count);
	}

	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		Substr substr = (Substr)o;
		return this == substr;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static bool operator ==(Substr a, Substr b)
	{
		return a.count == b.count && string.Compare(a.str, a.start, b.str, b.start, b.count) == 0;
	}

	public static bool operator ==(Substr a, string b)
	{
		return a.count == b.Length && string.Compare(a.str, a.start, b, 0, b.Length) == 0;
	}

	public static bool operator ==(string a, Substr b)
	{
		return a.Length == b.count && string.Compare(a, 0, b.str, b.start, b.count) == 0;
	}

	public static bool operator !=(Substr a, Substr b)
	{
		return !(a == b);
	}

	public static bool operator !=(Substr a, string b)
	{
		return !(a == b);
	}

	public static bool operator !=(string a, Substr b)
	{
		return !(a == b);
	}

	private static void AssertEqual(Substr a, Substr b)
	{
		if (a == b && a.ToString() == b && a == b.ToString() && a.ToString() == b.ToString())
		{
			Debug.Log(string.Format("OK: \"{0}\" == \"{1}\"", a, b));
		}
		else
		{
			Debug.Log(string.Format("FAIL: \"{0}\" != \"{1}\"", a, b));
		}
	}

	private static void AssertEqual(Substr a, string b)
	{
		AssertEqual(a, new Substr(b));
	}

	private static void AssertEqual(string a, Substr b)
	{
		AssertEqual(new Substr(a), b);
	}

	public static void Test()
	{
		Substr a = new Substr("Hello World");
		AssertEqual(a, "Hello World");
		Substr a2 = a.Substring(0, 5);
		AssertEqual(a2, "Hello");
		Substr a3 = a.Substring(6, 5);
		AssertEqual(a3, "World");
		Substr a4 = a.Substring(2);
		AssertEqual(a4, "llo World");
		AssertEqual(a4.IndexOf(" ").ToString(), new Substr("3"));
	}
}
