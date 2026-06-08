using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX;

internal struct oAEDXrvvcKPxxNzmMhHOiHFnkWH : IEquatable<oAEDXrvvcKPxxNzmMhHOiHFnkWH>
{
	private int cUhshRboukPpKOuPyYDzCAxodJU;

	public static readonly oAEDXrvvcKPxxNzmMhHOiHFnkWH RDGxlxZiaMwWhuFlumYUYtWgHJJ = new oAEDXrvvcKPxxNzmMhHOiHFnkWH(0);

	public static readonly oAEDXrvvcKPxxNzmMhHOiHFnkWH NmfeLPbsqhkaeDcsEntOsrsEjXhl = new oAEDXrvvcKPxxNzmMhHOiHFnkWH(1);

	public static readonly ResultDescriptor sbuehAuvnQItzQYYlYkwwLnCRTX = new ResultDescriptor(-2147467260, "General", "E_ABORT", "Operation aborted");

	public static readonly ResultDescriptor tCLjrfbZRJnpYquyVEVpgGUDymw = new ResultDescriptor(-2147024891, "General", "E_ACCESSDENIED", "General access denied error");

	public static readonly ResultDescriptor vWgFbujGWXDgBTeePBkfdYVhafYL = new ResultDescriptor(-2147467259, "General", "E_FAIL", "Unspecified error");

	public static readonly ResultDescriptor BRmQPCwEtGfYOorOoHoLnrnmEpDC = new ResultDescriptor(-2147024890, "General", "E_HANDLE", "Invalid handle");

	public static readonly ResultDescriptor tnwaeLTSiwXSVDCvFoXDfBTrCrj = new ResultDescriptor(-2147024809, "General", "E_INVALIDARG", "Invalid Arguments");

	public static readonly ResultDescriptor tuLqLfyFLLDagfCyDYZzEDVWxvSJ = new ResultDescriptor(-2147467262, "General", "E_NOINTERFACE", "No such interface supported");

	public static readonly ResultDescriptor mQRgqOSMhxfWcFTnAgyQamwzQfu = new ResultDescriptor(-2147467263, "General", "E_NOTIMPL", "Not implemented");

	public static readonly ResultDescriptor oHkRzOvOcYCTpPQLHDdDuiGQjOWA = new ResultDescriptor(-2147024882, "General", "E_OUTOFMEMORY", "Out of memory");

	public static readonly ResultDescriptor gLNGbVjVDlvvAvcnDzKTAvDbFrw = new ResultDescriptor(-2147467261, "General", "E_POINTER", "Invalid pointer");

	public static readonly ResultDescriptor jeMDKYhlHvKgjENNVDFueHZPVYO = new ResultDescriptor(-2147418113, "General", "E_UNEXPECTED", "Catastrophic failure");

	public static readonly ResultDescriptor DJSCOUHtTllhIZBPSQaUKlKYhHh = new ResultDescriptor(128, "General", "WAIT_ABANDONED", "WaitAbandoned");

	public static readonly ResultDescriptor EBoetvsXMGMIrWdyvgIpzKxhXFM = new ResultDescriptor(258, "General", "WAIT_TIMEOUT", "WaitTimeout");

	public int Code => cUhshRboukPpKOuPyYDzCAxodJU;

	public bool Success => Code >= 0;

	public bool Failure => Code < 0;

	public oAEDXrvvcKPxxNzmMhHOiHFnkWH(int code)
	{
		cUhshRboukPpKOuPyYDzCAxodJU = code;
	}

	public oAEDXrvvcKPxxNzmMhHOiHFnkWH(uint code)
	{
		cUhshRboukPpKOuPyYDzCAxodJU = (int)code;
	}

	public static explicit operator int(oAEDXrvvcKPxxNzmMhHOiHFnkWH result)
	{
		return result.Code;
	}

	public static explicit operator uint(oAEDXrvvcKPxxNzmMhHOiHFnkWH result)
	{
		return (uint)result.Code;
	}

	public static implicit operator oAEDXrvvcKPxxNzmMhHOiHFnkWH(int result)
	{
		return new oAEDXrvvcKPxxNzmMhHOiHFnkWH(result);
	}

	public static implicit operator oAEDXrvvcKPxxNzmMhHOiHFnkWH(uint result)
	{
		return new oAEDXrvvcKPxxNzmMhHOiHFnkWH(result);
	}

	public bool Equals(oAEDXrvvcKPxxNzmMhHOiHFnkWH other)
	{
		return Code == other.Code;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is oAEDXrvvcKPxxNzmMhHOiHFnkWH))
		{
			return false;
		}
		return Equals((oAEDXrvvcKPxxNzmMhHOiHFnkWH)obj);
	}

	public override int GetHashCode()
	{
		return Code;
	}

	public static bool operator ==(oAEDXrvvcKPxxNzmMhHOiHFnkWH left, oAEDXrvvcKPxxNzmMhHOiHFnkWH right)
	{
		return left.Code == right.Code;
	}

	public static bool operator !=(oAEDXrvvcKPxxNzmMhHOiHFnkWH left, oAEDXrvvcKPxxNzmMhHOiHFnkWH right)
	{
		return left.Code != right.Code;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "HRESULT = 0x{0:X}", new object[1] { cUhshRboukPpKOuPyYDzCAxodJU });
	}

	public void rBjEEuvDwijxDKhOHvBTwwhsJGG()
	{
		if (cUhshRboukPpKOuPyYDzCAxodJU < 0)
		{
			throw new UZoVbIaOogHmZeqpNxyDpZtVVpuI(this);
		}
	}

	public static oAEDXrvvcKPxxNzmMhHOiHFnkWH qPAojOgBLAUdKDfEWufcjqfPCbg(Exception P_0)
	{
		return new oAEDXrvvcKPxxNzmMhHOiHFnkWH(Marshal.GetHRForException(P_0));
	}

	public static oAEDXrvvcKPxxNzmMhHOiHFnkWH RZBFacrMydnJRaJURbxJfITElSr(int P_0)
	{
		return (int)((P_0 <= 0) ? P_0 : ((P_0 & 0xFFFF) | 0x70000 | 0x80000000u));
	}
}
