using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class OwPutDSGWNXWjCxOKAtQJukLUWsQ : SPkxDMGgABHgjHnpxyaycxftuvyT
{
	[CompilerGenerated]
	private uSybUDloPNuEJAteTikZTyRnhNjA[] GiTNUbMfNTFYBvTRlUdggtbWdqZE;

	public uSybUDloPNuEJAteTikZTyRnhNjA[] VZWflLOVIDxDIotRfnhhjPHMwjxn
	{
		[CompilerGenerated]
		get
		{
			return GiTNUbMfNTFYBvTRlUdggtbWdqZE;
		}
		[CompilerGenerated]
		set
		{
			GiTNUbMfNTFYBvTRlUdggtbWdqZE = giTNUbMfNTFYBvTRlUdggtbWdqZE;
		}
	}

	unsafe int SPkxDMGgABHgjHnpxyaycxftuvyT.cXxbOJdOwEpnKwCHzgLxJnCfVGSx
	{
		get
		{
			if (VZWflLOVIDxDIotRfnhhjPHMwjxn == null)
			{
				return 0;
			}
			return VZWflLOVIDxDIotRfnhhjPHMwjxn.Length * sizeof(uSybUDloPNuEJAteTikZTyRnhNjA);
		}
	}

	protected unsafe virtual SPkxDMGgABHgjHnpxyaycxftuvyT rNBtPGTKnDuGNXmlZETivwRJIMFP(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(uSybUDloPNuEJAteTikZTyRnhNjA) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(uSybUDloPNuEJAteTikZTyRnhNjA);
		VZWflLOVIDxDIotRfnhhjPHMwjxn = new uSybUDloPNuEJAteTikZTyRnhNjA[num];
		fixed (uSybUDloPNuEJAteTikZTyRnhNjA* ptr = VZWflLOVIDxDIotRfnhhjPHMwjxn)
		{
			qxcVmGprUKQYlnqWDgYoPbSYiwBQ.SLqTOazZKJnjvIMWFgYbNIplONWs((IntPtr)ptr, P_1, qxcVmGprUKQYlnqWDgYoPbSYiwBQ.pPOQOWVFBwzWqtWRDdWyKPxFBEfO<uSybUDloPNuEJAteTikZTyRnhNjA>() * VZWflLOVIDxDIotRfnhhjPHMwjxn.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr iUCGuABituLMUXvzVziMNPnWmHgdb()
	{
		if (cXxbOJdOwEpnKwCHzgLxJnCfVGSx == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(cXxbOJdOwEpnKwCHzgLxJnCfVGSx);
		fixed (uSybUDloPNuEJAteTikZTyRnhNjA* ptr = VZWflLOVIDxDIotRfnhhjPHMwjxn)
		{
			qxcVmGprUKQYlnqWDgYoPbSYiwBQ.SLqTOazZKJnjvIMWFgYbNIplONWs(intPtr, (IntPtr)ptr, qxcVmGprUKQYlnqWDgYoPbSYiwBQ.pPOQOWVFBwzWqtWRDdWyKPxFBEfO<uSybUDloPNuEJAteTikZTyRnhNjA>() * VZWflLOVIDxDIotRfnhhjPHMwjxn.Length);
		}
		return intPtr;
	}
}
