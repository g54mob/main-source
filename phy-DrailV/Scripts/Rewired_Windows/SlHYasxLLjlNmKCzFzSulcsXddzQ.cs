using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class SlHYasxLLjlNmKCzFzSulcsXddzQ : OAsaOhivNnJJcaXGgqiIbGrVdCbmc
{
	[CompilerGenerated]
	private aHuKGfWxrjMPDOqWdNwWnCyHrOMU[] BYQHYmylNDfPJhyBBIlAkjbUAqyx;

	public aHuKGfWxrjMPDOqWdNwWnCyHrOMU[] JLXrakPiKQRUjsjdodNWgGvQRcvqA
	{
		[CompilerGenerated]
		get
		{
			return BYQHYmylNDfPJhyBBIlAkjbUAqyx;
		}
		[CompilerGenerated]
		set
		{
			BYQHYmylNDfPJhyBBIlAkjbUAqyx = bYQHYmylNDfPJhyBBIlAkjbUAqyx;
		}
	}

	unsafe int OAsaOhivNnJJcaXGgqiIbGrVdCbmc.woNJXLkWwUOBugYfuMGynSMoksFi
	{
		get
		{
			if (JLXrakPiKQRUjsjdodNWgGvQRcvqA == null)
			{
				return 0;
			}
			return JLXrakPiKQRUjsjdodNWgGvQRcvqA.Length * sizeof(aHuKGfWxrjMPDOqWdNwWnCyHrOMU);
		}
	}

	protected unsafe override OAsaOhivNnJJcaXGgqiIbGrVdCbmc PWrFUHxdERHkATtEfEdKOHdOSVib(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(aHuKGfWxrjMPDOqWdNwWnCyHrOMU) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(aHuKGfWxrjMPDOqWdNwWnCyHrOMU);
		JLXrakPiKQRUjsjdodNWgGvQRcvqA = new aHuKGfWxrjMPDOqWdNwWnCyHrOMU[num];
		fixed (aHuKGfWxrjMPDOqWdNwWnCyHrOMU* ptr = JLXrakPiKQRUjsjdodNWgGvQRcvqA)
		{
			egeTdzIGHudlgfKlEvWOdRMMLrIl.XzyKQtjTUtOkyLWLbIpJnkSlLGhP((IntPtr)ptr, P_1, egeTdzIGHudlgfKlEvWOdRMMLrIl.blFXvzDnixGZOIdMGTdsFamQEcuI<aHuKGfWxrjMPDOqWdNwWnCyHrOMU>() * JLXrakPiKQRUjsjdodNWgGvQRcvqA.Length);
		}
		return this;
	}

	internal unsafe override IntPtr MoFcJaajRNOlFTgfBbaVBVnkDofXA()
	{
		if (woNJXLkWwUOBugYfuMGynSMoksFi == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(woNJXLkWwUOBugYfuMGynSMoksFi);
		fixed (aHuKGfWxrjMPDOqWdNwWnCyHrOMU* ptr = JLXrakPiKQRUjsjdodNWgGvQRcvqA)
		{
			egeTdzIGHudlgfKlEvWOdRMMLrIl.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(intPtr, (IntPtr)ptr, egeTdzIGHudlgfKlEvWOdRMMLrIl.blFXvzDnixGZOIdMGTdsFamQEcuI<aHuKGfWxrjMPDOqWdNwWnCyHrOMU>() * JLXrakPiKQRUjsjdodNWgGvQRcvqA.Length);
		}
		return intPtr;
	}
}
