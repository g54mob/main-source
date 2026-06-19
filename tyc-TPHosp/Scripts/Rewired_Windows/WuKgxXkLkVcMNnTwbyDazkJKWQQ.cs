using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class WuKgxXkLkVcMNnTwbyDazkJKWQQ
{
	public IntPtr KoyfNhlbhxnTnMUyqRjDYuKtUck;

	public WuKgxXkLkVcMNnTwbyDazkJKWQQ(IntPtr pointer)
	{
		KoyfNhlbhxnTnMUyqRjDYuKtUck = pointer;
	}

	public unsafe WuKgxXkLkVcMNnTwbyDazkJKWQQ(void* pointer)
	{
		KoyfNhlbhxnTnMUyqRjDYuKtUck = new IntPtr(pointer);
	}

	public static explicit operator IntPtr(WuKgxXkLkVcMNnTwbyDazkJKWQQ value)
	{
		return value.KoyfNhlbhxnTnMUyqRjDYuKtUck;
	}

	public static implicit operator WuKgxXkLkVcMNnTwbyDazkJKWQQ(IntPtr value)
	{
		return new WuKgxXkLkVcMNnTwbyDazkJKWQQ(value);
	}

	public unsafe static implicit operator void*(WuKgxXkLkVcMNnTwbyDazkJKWQQ value)
	{
		return (void*)value.KoyfNhlbhxnTnMUyqRjDYuKtUck;
	}

	public unsafe static explicit operator WuKgxXkLkVcMNnTwbyDazkJKWQQ(void* value)
	{
		return new WuKgxXkLkVcMNnTwbyDazkJKWQQ(value);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { KoyfNhlbhxnTnMUyqRjDYuKtUck });
	}

	public string iSLKngyzvSeBOWhcUVCKwoJrNEm(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { KoyfNhlbhxnTnMUyqRjDYuKtUck.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return KoyfNhlbhxnTnMUyqRjDYuKtUck.ToInt32();
	}

	public bool lpfGDOSkHRGqZKIqCGEaicWfABrw(WuKgxXkLkVcMNnTwbyDazkJKWQQ P_0)
	{
		return KoyfNhlbhxnTnMUyqRjDYuKtUck == P_0.KoyfNhlbhxnTnMUyqRjDYuKtUck;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(WuKgxXkLkVcMNnTwbyDazkJKWQQ)))
		{
			return false;
		}
		return lpfGDOSkHRGqZKIqCGEaicWfABrw((WuKgxXkLkVcMNnTwbyDazkJKWQQ)value);
	}
}
