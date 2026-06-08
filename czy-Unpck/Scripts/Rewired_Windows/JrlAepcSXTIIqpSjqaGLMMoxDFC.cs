using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class JrlAepcSXTIIqpSjqaGLMMoxDFC
{
	public IntPtr RvNTIOviRjzhsWOGyDalbuXVCRx;

	public JrlAepcSXTIIqpSjqaGLMMoxDFC(IntPtr pointer)
	{
		RvNTIOviRjzhsWOGyDalbuXVCRx = pointer;
	}

	public unsafe JrlAepcSXTIIqpSjqaGLMMoxDFC(void* pointer)
	{
		RvNTIOviRjzhsWOGyDalbuXVCRx = new IntPtr(pointer);
	}

	public static explicit operator IntPtr(JrlAepcSXTIIqpSjqaGLMMoxDFC value)
	{
		return value.RvNTIOviRjzhsWOGyDalbuXVCRx;
	}

	public static implicit operator JrlAepcSXTIIqpSjqaGLMMoxDFC(IntPtr value)
	{
		return new JrlAepcSXTIIqpSjqaGLMMoxDFC(value);
	}

	public unsafe static implicit operator void*(JrlAepcSXTIIqpSjqaGLMMoxDFC value)
	{
		return (void*)value.RvNTIOviRjzhsWOGyDalbuXVCRx;
	}

	public unsafe static explicit operator JrlAepcSXTIIqpSjqaGLMMoxDFC(void* value)
	{
		return new JrlAepcSXTIIqpSjqaGLMMoxDFC(value);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { RvNTIOviRjzhsWOGyDalbuXVCRx });
	}

	public string xTkYeHqBZWJlRSAWGtjqDfOHERd(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { RvNTIOviRjzhsWOGyDalbuXVCRx.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return RvNTIOviRjzhsWOGyDalbuXVCRx.ToInt32();
	}

	public bool uxGAirIytVqwSOxUUxSKDfDVCZe(JrlAepcSXTIIqpSjqaGLMMoxDFC P_0)
	{
		return RvNTIOviRjzhsWOGyDalbuXVCRx == P_0.RvNTIOviRjzhsWOGyDalbuXVCRx;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(JrlAepcSXTIIqpSjqaGLMMoxDFC)))
		{
			return false;
		}
		return uxGAirIytVqwSOxUUxSKDfDVCZe((JrlAepcSXTIIqpSjqaGLMMoxDFC)value);
	}
}
