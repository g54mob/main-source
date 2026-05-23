using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class zsAGZLCVFAEyMTEhaIBdjDurWeJG : TypeSpecificParameters
{
	[CompilerGenerated]
	private int eNuItBMEOBiKDHnpfOfNUszzmkME;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return eNuItBMEOBiKDHnpfOfNUszzmkME;
		}
		[CompilerGenerated]
		set
		{
			eNuItBMEOBiKDHnpfOfNUszzmkME = value;
		}
	}

	public override int Size
	{
		get
		{
			return WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<XyiECDOFeMGjsBdxiqMPoTXGPrx>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(XyiECDOFeMGjsBdxiqMPoTXGPrx))
		{
			return null;
		}
		Magnitude = ((XyiECDOFeMGjsBdxiqMPoTXGPrx*)(void*)P_1)->OCgbesCSWhwkQdhTQAQtmCwwNyiB;
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((XyiECDOFeMGjsBdxiqMPoTXGPrx*)(void*)intPtr)->OCgbesCSWhwkQdhTQAQtmCwwNyiB = Magnitude;
		return intPtr;
	}
}
