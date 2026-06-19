using System;
using System.Runtime.InteropServices;

internal class tWrUeIFRpAgBnaEsaeLzjyVbLKv : IDisposable
{
	internal enum igQUcsYpQdlnyshfeDGUkTCdHkvb
	{
		sAxVZlqahmmYJWcnenznRIheKdX = 0,
		lKcDIMfHrbBBgTzhXBojeBKdnPsp = 1
	}

	private delegate IntPtr pzXGGvsmNVmFUEjdBpHXdiNIcABE(int nCode, IntPtr wParam, IntPtr lParam);

	private const int OIcBfWGLZUNhJAggJWIGaZwzEGFr = 4;

	private IntPtr ObNAIZDnCrqKLAtqkHtUcQtSiSni = IntPtr.Zero;

	private pzXGGvsmNVmFUEjdBpHXdiNIcABE HQByIzQqoguPEGSeApCZNBVGIEf;

	private Action<IntPtr, IntPtr, uint, uint> fJLFhPzOSMBwFvcJKHckewApynC;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public void sASeLylCSRoEAmHpJVCokmAOxVh(Action<IntPtr, IntPtr, uint, uint> P_0, igQUcsYpQdlnyshfeDGUkTCdHkvb P_1)
	{
		fJLFhPzOSMBwFvcJKHckewApynC = P_0;
		HQByIzQqoguPEGSeApCZNBVGIEf = nioFIkbhSsSCqcVenAbUAfsGbpIl;
		uint num = 0u;
		if (P_1 == igQUcsYpQdlnyshfeDGUkTCdHkvb.sAxVZlqahmmYJWcnenznRIheKdX)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		ObNAIZDnCrqKLAtqkHtUcQtSiSni = BHRgBdCdafkzKipZjQZdqGhsVHGc(4, HQByIzQqoguPEGSeApCZNBVGIEf, IntPtr.Zero, num);
		_ = ObNAIZDnCrqKLAtqkHtUcQtSiSni == IntPtr.Zero;
	}

	public void frBvaUxHJJKnyhFnbqhmIdSCXli()
	{
		if (!(ObNAIZDnCrqKLAtqkHtUcQtSiSni == IntPtr.Zero) && UdouKTZHkQZvDmqywYswSykNUPa(ObNAIZDnCrqKLAtqkHtUcQtSiSni))
		{
			ObNAIZDnCrqKLAtqkHtUcQtSiSni = IntPtr.Zero;
		}
	}

	private IntPtr nioFIkbhSsSCqcVenAbUAfsGbpIl(int P_0, IntPtr P_1, IntPtr P_2)
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
			fJLFhPzOSMBwFvcJKHckewApynC(arg, arg2, arg3, arg4);
		}
		return hCDsMoDhPTuAXtuTbmjQajCuKza(ObNAIZDnCrqKLAtqkHtUcQtSiSni, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~tWrUeIFRpAgBnaEsaeLzjyVbLKv()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			frBvaUxHJJKnyhFnbqhmIdSCXli();
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr BHRgBdCdafkzKipZjQZdqGhsVHGc(int P_0, pzXGGvsmNVmFUEjdBpHXdiNIcABE P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool UdouKTZHkQZvDmqywYswSykNUPa(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr hCDsMoDhPTuAXtuTbmjQajCuKza(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
