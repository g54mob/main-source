using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class mRtJLwLPcsBXEDzYvMZYWrpxYETX
{
	private readonly List<Delegate> xKHXleaEmqVbOQcuKXWZhijTnmqw;

	private readonly IntPtr YjsJBoWVsVfoXpeNGogbcrmGFpiy;

	public IntPtr ryCaUIcsjYxMdTFaKTChGOJUUnhP => YjsJBoWVsVfoXpeNGogbcrmGFpiy;

	public mRtJLwLPcsBXEDzYvMZYWrpxYETX(int P_0)
	{
		YjsJBoWVsVfoXpeNGogbcrmGFpiy = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		xKHXleaEmqVbOQcuKXWZhijTnmqw = new List<Delegate>();
	}

	public unsafe void FapJlyTxiBhmGsbwraaWAWPjOADO(Delegate P_0)
	{
		int count = xKHXleaEmqVbOQcuKXWZhijTnmqw.Count;
		xKHXleaEmqVbOQcuKXWZhijTnmqw.Add(P_0);
		((IntPtr*)(void*)YjsJBoWVsVfoXpeNGogbcrmGFpiy)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
