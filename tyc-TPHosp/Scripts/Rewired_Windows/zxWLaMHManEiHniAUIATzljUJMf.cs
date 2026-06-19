using System;
using System.Runtime.InteropServices;

internal struct zxWLaMHManEiHniAUIATzljUJMf
{
	private IntPtr ibXcoaLNpquhAfEYaFtHeOpHmYl;

	private int XBzMztIIOiEMSfkTezJYdbKjxTQ;

	private IntPtr vYEqHaXwPQrDdEuPYeunNBoThYa;

	private IntPtr nFrRAsHRTdrYBiniCBfLWCDugHx;

	private IntPtr MUapWlEykKphWFHezfxmVlnvcbKi;

	public IntPtr HWnd
	{
		get
		{
			return ibXcoaLNpquhAfEYaFtHeOpHmYl;
		}
		set
		{
			ibXcoaLNpquhAfEYaFtHeOpHmYl = value;
		}
	}

	public int Msg
	{
		get
		{
			return XBzMztIIOiEMSfkTezJYdbKjxTQ;
		}
		set
		{
			XBzMztIIOiEMSfkTezJYdbKjxTQ = value;
		}
	}

	public IntPtr WParam
	{
		get
		{
			return vYEqHaXwPQrDdEuPYeunNBoThYa;
		}
		set
		{
			vYEqHaXwPQrDdEuPYeunNBoThYa = value;
		}
	}

	public IntPtr LParam
	{
		get
		{
			return nFrRAsHRTdrYBiniCBfLWCDugHx;
		}
		set
		{
			nFrRAsHRTdrYBiniCBfLWCDugHx = value;
		}
	}

	public IntPtr Result
	{
		get
		{
			return MUapWlEykKphWFHezfxmVlnvcbKi;
		}
		set
		{
			MUapWlEykKphWFHezfxmVlnvcbKi = value;
		}
	}

	public object smzcLlBUqmrCifijWFpjCMQRDlL(Type P_0)
	{
		return Marshal.PtrToStructure(nFrRAsHRTdrYBiniCBfLWCDugHx, P_0);
	}

	public static zxWLaMHManEiHniAUIATzljUJMf KbsenlehkfKhrEUvGoQEltREagOX(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3)
	{
		return new zxWLaMHManEiHniAUIATzljUJMf
		{
			ibXcoaLNpquhAfEYaFtHeOpHmYl = P_0,
			XBzMztIIOiEMSfkTezJYdbKjxTQ = P_1,
			vYEqHaXwPQrDdEuPYeunNBoThYa = P_2,
			nFrRAsHRTdrYBiniCBfLWCDugHx = P_3,
			MUapWlEykKphWFHezfxmVlnvcbKi = IntPtr.Zero
		};
	}

	public override bool Equals(object o)
	{
		if (!(o is zxWLaMHManEiHniAUIATzljUJMf zxWLaMHManEiHniAUIATzljUJMf2))
		{
			return false;
		}
		if (ibXcoaLNpquhAfEYaFtHeOpHmYl == zxWLaMHManEiHniAUIATzljUJMf2.ibXcoaLNpquhAfEYaFtHeOpHmYl && XBzMztIIOiEMSfkTezJYdbKjxTQ == zxWLaMHManEiHniAUIATzljUJMf2.XBzMztIIOiEMSfkTezJYdbKjxTQ && vYEqHaXwPQrDdEuPYeunNBoThYa == zxWLaMHManEiHniAUIATzljUJMf2.vYEqHaXwPQrDdEuPYeunNBoThYa && nFrRAsHRTdrYBiniCBfLWCDugHx == zxWLaMHManEiHniAUIATzljUJMf2.nFrRAsHRTdrYBiniCBfLWCDugHx)
		{
			return MUapWlEykKphWFHezfxmVlnvcbKi == zxWLaMHManEiHniAUIATzljUJMf2.MUapWlEykKphWFHezfxmVlnvcbKi;
		}
		return false;
	}

	public static bool operator !=(zxWLaMHManEiHniAUIATzljUJMf a, zxWLaMHManEiHniAUIATzljUJMf b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(zxWLaMHManEiHniAUIATzljUJMf a, zxWLaMHManEiHniAUIATzljUJMf b)
	{
		return a.Equals(b);
	}

	public override int GetHashCode()
	{
		return ((int)ibXcoaLNpquhAfEYaFtHeOpHmYl << 4) | XBzMztIIOiEMSfkTezJYdbKjxTQ;
	}

	public override string ToString()
	{
		return string.Empty;
	}
}
