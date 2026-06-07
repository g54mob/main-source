using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class VzdDEQzWYAEPiDcEMhDDSBkBQPY
{
	public IntPtr DCRbVygoDgSzSNkcJFpisfviWYeA;

	public VzdDEQzWYAEPiDcEMhDDSBkBQPY(IntPtr pointer)
	{
		DCRbVygoDgSzSNkcJFpisfviWYeA = pointer;
	}

	public unsafe VzdDEQzWYAEPiDcEMhDDSBkBQPY(void* pointer)
	{
		DCRbVygoDgSzSNkcJFpisfviWYeA = new IntPtr(pointer);
	}

	public static explicit operator IntPtr(VzdDEQzWYAEPiDcEMhDDSBkBQPY value)
	{
		return value.DCRbVygoDgSzSNkcJFpisfviWYeA;
	}

	public static implicit operator VzdDEQzWYAEPiDcEMhDDSBkBQPY(IntPtr value)
	{
		return new VzdDEQzWYAEPiDcEMhDDSBkBQPY(value);
	}

	public unsafe static implicit operator void*(VzdDEQzWYAEPiDcEMhDDSBkBQPY value)
	{
		return (void*)value.DCRbVygoDgSzSNkcJFpisfviWYeA;
	}

	public unsafe static explicit operator VzdDEQzWYAEPiDcEMhDDSBkBQPY(void* value)
	{
		return new VzdDEQzWYAEPiDcEMhDDSBkBQPY(value);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { DCRbVygoDgSzSNkcJFpisfviWYeA });
	}

	public string jbeeBfpyRHgFdsemtguxfVuwPCaA(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { DCRbVygoDgSzSNkcJFpisfviWYeA.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return DCRbVygoDgSzSNkcJFpisfviWYeA.ToInt32();
	}

	public bool sDUAvZTXlEIwugPidIgHPcnkQFr(VzdDEQzWYAEPiDcEMhDDSBkBQPY P_0)
	{
		return DCRbVygoDgSzSNkcJFpisfviWYeA == P_0.DCRbVygoDgSzSNkcJFpisfviWYeA;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(VzdDEQzWYAEPiDcEMhDDSBkBQPY)))
		{
			return false;
		}
		return sDUAvZTXlEIwugPidIgHPcnkQFr((VzdDEQzWYAEPiDcEMhDDSBkBQPY)value);
	}
}
