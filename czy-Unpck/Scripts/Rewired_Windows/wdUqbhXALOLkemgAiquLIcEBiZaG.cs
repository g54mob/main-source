using System;
using System.Runtime.InteropServices;

internal class wdUqbhXALOLkemgAiquLIcEBiZaG : IDisposable
{
	internal enum HdjBxFhkBYVOaeFMelOaHFmjuysn
	{
		pbMsOWkcNeEMKKVTaAFBqEySsXS = 0,
		ePJfrrDTvzTxHjRlLDJUwDDFEdY = 1
	}

	private delegate IntPtr mOuNaCxgLqOVmpBqyIDMIlZhURg(int nCode, IntPtr wParam, IntPtr lParam);

	private const int ZTTUAzBhYWzAAkAlCjKkyzrqLQS = 4;

	private IntPtr PFglRqbsMvCbCpSJNIdujwlIFYk = IntPtr.Zero;

	private mOuNaCxgLqOVmpBqyIDMIlZhURg WqkvSGAYruHaTUEEYbadyICkjRc;

	private Action<IntPtr, IntPtr, uint, uint> cSaAusaniKcLOypQOOaYxTpXQrBG;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public void vBrWVLrJkJNkFadFTFyMERBupmyB(Action<IntPtr, IntPtr, uint, uint> P_0, HdjBxFhkBYVOaeFMelOaHFmjuysn P_1)
	{
		cSaAusaniKcLOypQOOaYxTpXQrBG = P_0;
		WqkvSGAYruHaTUEEYbadyICkjRc = qDszRUlukUExWBUbNYaKthHCyNE;
		uint num = 0u;
		if (P_1 == HdjBxFhkBYVOaeFMelOaHFmjuysn.pbMsOWkcNeEMKKVTaAFBqEySsXS)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		PFglRqbsMvCbCpSJNIdujwlIFYk = KeMcCDfQhlnBKbpZxsTDfixSCJb(4, WqkvSGAYruHaTUEEYbadyICkjRc, IntPtr.Zero, num);
		_ = PFglRqbsMvCbCpSJNIdujwlIFYk == IntPtr.Zero;
	}

	public void yXkNHxfnRTfZnnLjvYkKhVkearp()
	{
		if (!(PFglRqbsMvCbCpSJNIdujwlIFYk == IntPtr.Zero) && JLVfNtCHjGUFgpiCqMtIytvbTLQh(PFglRqbsMvCbCpSJNIdujwlIFYk))
		{
			PFglRqbsMvCbCpSJNIdujwlIFYk = IntPtr.Zero;
		}
	}

	private IntPtr qDszRUlukUExWBUbNYaKthHCyNE(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (P_0 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(P_2, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(P_2, num);
			cSaAusaniKcLOypQOOaYxTpXQrBG(arg, arg2, arg3, arg4);
		}
		return cxiZPHXSXNkcYbiExGXkfXVWKLvm(PFglRqbsMvCbCpSJNIdujwlIFYk, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~wdUqbhXALOLkemgAiquLIcEBiZaG()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			yXkNHxfnRTfZnnLjvYkKhVkearp();
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr KeMcCDfQhlnBKbpZxsTDfixSCJb(int P_0, mOuNaCxgLqOVmpBqyIDMIlZhURg P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool JLVfNtCHjGUFgpiCqMtIytvbTLQh(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr cxiZPHXSXNkcYbiExGXkfXVWKLvm(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
