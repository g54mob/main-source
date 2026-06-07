using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class eYgciNgYmxwbRDlsLLLmjhuDtfefB
{
	private readonly List<Delegate> cAOQGUdJmmnZfacErupAqmVzikIb;

	private readonly IntPtr LqvHtpdqLngVWHZkWvKmlHRFGOxLA;

	public IntPtr kWRTOHULzKpCRgNuSFABYNYVScy => LqvHtpdqLngVWHZkWvKmlHRFGOxLA;

	public eYgciNgYmxwbRDlsLLLmjhuDtfefB(int P_0)
	{
		LqvHtpdqLngVWHZkWvKmlHRFGOxLA = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		cAOQGUdJmmnZfacErupAqmVzikIb = new List<Delegate>();
	}

	public unsafe void IiWPvNFGHLgbtmOvNthNlljuAtrQ(Delegate P_0)
	{
		int count = cAOQGUdJmmnZfacErupAqmVzikIb.Count;
		cAOQGUdJmmnZfacErupAqmVzikIb.Add(P_0);
		((IntPtr*)(void*)LqvHtpdqLngVWHZkWvKmlHRFGOxLA)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
