using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class SeAGUniomhRcypKqLPpGBMfcfTx
{
	public IntPtr YByAqXfOhZFBSUwqKpZfgvoDPrD;

	public SeAGUniomhRcypKqLPpGBMfcfTx(IntPtr pointer)
	{
		YByAqXfOhZFBSUwqKpZfgvoDPrD = pointer;
	}

	public unsafe SeAGUniomhRcypKqLPpGBMfcfTx(void* pointer)
	{
		YByAqXfOhZFBSUwqKpZfgvoDPrD = new IntPtr(pointer);
	}

	public static explicit operator IntPtr(SeAGUniomhRcypKqLPpGBMfcfTx value)
	{
		return value.YByAqXfOhZFBSUwqKpZfgvoDPrD;
	}

	public static implicit operator SeAGUniomhRcypKqLPpGBMfcfTx(IntPtr value)
	{
		return new SeAGUniomhRcypKqLPpGBMfcfTx(value);
	}

	public unsafe static implicit operator void*(SeAGUniomhRcypKqLPpGBMfcfTx value)
	{
		return (void*)value.YByAqXfOhZFBSUwqKpZfgvoDPrD;
	}

	public unsafe static explicit operator SeAGUniomhRcypKqLPpGBMfcfTx(void* value)
	{
		return new SeAGUniomhRcypKqLPpGBMfcfTx(value);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { YByAqXfOhZFBSUwqKpZfgvoDPrD });
	}

	public string shRdQKhcpqQbzCGymNimzIjVeDZm(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { YByAqXfOhZFBSUwqKpZfgvoDPrD.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return YByAqXfOhZFBSUwqKpZfgvoDPrD.ToInt32();
	}

	public bool bEnIwmDQBptAwhYgeoqMwSwXPKCG(SeAGUniomhRcypKqLPpGBMfcfTx P_0)
	{
		return YByAqXfOhZFBSUwqKpZfgvoDPrD == P_0.YByAqXfOhZFBSUwqKpZfgvoDPrD;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(SeAGUniomhRcypKqLPpGBMfcfTx)))
		{
			return false;
		}
		return bEnIwmDQBptAwhYgeoqMwSwXPKCG((SeAGUniomhRcypKqLPpGBMfcfTx)value);
	}
}
