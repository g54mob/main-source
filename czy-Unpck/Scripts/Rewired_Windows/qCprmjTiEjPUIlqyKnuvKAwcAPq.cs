using System;
using System.Runtime.InteropServices;

internal struct qCprmjTiEjPUIlqyKnuvKAwcAPq
{
	private IntPtr hzyeVDFBLkZdLzqaqBKjzkgvfPyI;

	private int IKKUHYOUguIpLdabiiOcUITLaST;

	private IntPtr kNraTFIFSKHligEKSSRPHaMdKqpd;

	private IntPtr yzEQgJDbnlOvQiYKOdyvntCIEEw;

	private IntPtr BiVbJQAPUMfXTVmOzCxOmqTBkAZ;

	public IntPtr HWnd
	{
		get
		{
			return hzyeVDFBLkZdLzqaqBKjzkgvfPyI;
		}
		set
		{
			hzyeVDFBLkZdLzqaqBKjzkgvfPyI = value;
		}
	}

	public int Msg
	{
		get
		{
			return IKKUHYOUguIpLdabiiOcUITLaST;
		}
		set
		{
			IKKUHYOUguIpLdabiiOcUITLaST = value;
		}
	}

	public IntPtr WParam
	{
		get
		{
			return kNraTFIFSKHligEKSSRPHaMdKqpd;
		}
		set
		{
			kNraTFIFSKHligEKSSRPHaMdKqpd = value;
		}
	}

	public IntPtr LParam
	{
		get
		{
			return yzEQgJDbnlOvQiYKOdyvntCIEEw;
		}
		set
		{
			yzEQgJDbnlOvQiYKOdyvntCIEEw = value;
		}
	}

	public IntPtr Result
	{
		get
		{
			return BiVbJQAPUMfXTVmOzCxOmqTBkAZ;
		}
		set
		{
			BiVbJQAPUMfXTVmOzCxOmqTBkAZ = value;
		}
	}

	public object xNMzZADiciehltoTKDeLGdLvJAQE(Type P_0)
	{
		return Marshal.PtrToStructure(yzEQgJDbnlOvQiYKOdyvntCIEEw, P_0);
	}

	public static qCprmjTiEjPUIlqyKnuvKAwcAPq ZyDMIRfUdtdyWWZsNvkwCISqzBR(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3)
	{
		return new qCprmjTiEjPUIlqyKnuvKAwcAPq
		{
			hzyeVDFBLkZdLzqaqBKjzkgvfPyI = P_0,
			IKKUHYOUguIpLdabiiOcUITLaST = P_1,
			kNraTFIFSKHligEKSSRPHaMdKqpd = P_2,
			yzEQgJDbnlOvQiYKOdyvntCIEEw = P_3,
			BiVbJQAPUMfXTVmOzCxOmqTBkAZ = IntPtr.Zero
		};
	}

	public override bool Equals(object o)
	{
		if (!(o is qCprmjTiEjPUIlqyKnuvKAwcAPq qCprmjTiEjPUIlqyKnuvKAwcAPq2))
		{
			return false;
		}
		if (hzyeVDFBLkZdLzqaqBKjzkgvfPyI == qCprmjTiEjPUIlqyKnuvKAwcAPq2.hzyeVDFBLkZdLzqaqBKjzkgvfPyI && IKKUHYOUguIpLdabiiOcUITLaST == qCprmjTiEjPUIlqyKnuvKAwcAPq2.IKKUHYOUguIpLdabiiOcUITLaST && kNraTFIFSKHligEKSSRPHaMdKqpd == qCprmjTiEjPUIlqyKnuvKAwcAPq2.kNraTFIFSKHligEKSSRPHaMdKqpd && yzEQgJDbnlOvQiYKOdyvntCIEEw == qCprmjTiEjPUIlqyKnuvKAwcAPq2.yzEQgJDbnlOvQiYKOdyvntCIEEw)
		{
			return BiVbJQAPUMfXTVmOzCxOmqTBkAZ == qCprmjTiEjPUIlqyKnuvKAwcAPq2.BiVbJQAPUMfXTVmOzCxOmqTBkAZ;
		}
		return false;
	}

	public static bool operator !=(qCprmjTiEjPUIlqyKnuvKAwcAPq a, qCprmjTiEjPUIlqyKnuvKAwcAPq b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(qCprmjTiEjPUIlqyKnuvKAwcAPq a, qCprmjTiEjPUIlqyKnuvKAwcAPq b)
	{
		return a.Equals(b);
	}

	public override int GetHashCode()
	{
		return ((int)hzyeVDFBLkZdLzqaqBKjzkgvfPyI << 4) | IKKUHYOUguIpLdabiiOcUITLaST;
	}

	public override string ToString()
	{
		return string.Empty;
	}
}
