using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class OtePkBPourhUvkDWmfXOEFfIPPx
{
	public IntPtr ARUiHxSNbXnIDJlQvGpptwkzODL;

	public OtePkBPourhUvkDWmfXOEFfIPPx(IntPtr pointer)
	{
		ARUiHxSNbXnIDJlQvGpptwkzODL = pointer;
	}

	public unsafe OtePkBPourhUvkDWmfXOEFfIPPx(void* pointer)
	{
		ARUiHxSNbXnIDJlQvGpptwkzODL = new IntPtr(pointer);
	}

	public static explicit operator IntPtr(OtePkBPourhUvkDWmfXOEFfIPPx value)
	{
		return value.ARUiHxSNbXnIDJlQvGpptwkzODL;
	}

	public static implicit operator OtePkBPourhUvkDWmfXOEFfIPPx(IntPtr value)
	{
		return new OtePkBPourhUvkDWmfXOEFfIPPx(value);
	}

	public unsafe static implicit operator void*(OtePkBPourhUvkDWmfXOEFfIPPx value)
	{
		return (void*)value.ARUiHxSNbXnIDJlQvGpptwkzODL;
	}

	public unsafe static explicit operator OtePkBPourhUvkDWmfXOEFfIPPx(void* value)
	{
		return new OtePkBPourhUvkDWmfXOEFfIPPx(value);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", ARUiHxSNbXnIDJlQvGpptwkzODL);
	}

	public string yRtDbyVDfwgkaXWMVmTyFkjlBxN(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", ARUiHxSNbXnIDJlQvGpptwkzODL.ToString(P_0));
	}

	public override int GetHashCode()
	{
		return ARUiHxSNbXnIDJlQvGpptwkzODL.ToInt32();
	}

	public bool toLtuUpVSfLorNAOBqtEBqxdEiK(OtePkBPourhUvkDWmfXOEFfIPPx P_0)
	{
		return ARUiHxSNbXnIDJlQvGpptwkzODL == P_0.ARUiHxSNbXnIDJlQvGpptwkzODL;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(OtePkBPourhUvkDWmfXOEFfIPPx)))
		{
			return false;
		}
		return toLtuUpVSfLorNAOBqtEBqxdEiK((OtePkBPourhUvkDWmfXOEFfIPPx)value);
	}
}
