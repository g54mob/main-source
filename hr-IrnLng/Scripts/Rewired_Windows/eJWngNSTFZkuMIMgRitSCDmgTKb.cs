using System;
using System.Runtime.InteropServices;

internal class eJWngNSTFZkuMIMgRitSCDmgTKb : IDisposable
{
	internal enum mqnblvULzJHugXeoWVmVrgHXsrC
	{
		xhYjcixNTtOgssbzJZzCuIsvzNJ = 0,
		cXEeBjOXiiTJnTtduUOyunqeJia = 1
	}

	private delegate IntPtr uagHltJFfIlayAQpjGHtRvXaBVF(int nCode, IntPtr wParam, IntPtr lParam);

	private const int NLJRNgAvTrrorOixyalDgRJgMPg = 4;

	private IntPtr BngitMecwaCrsFQiwZJlfiUxHEr = IntPtr.Zero;

	private uagHltJFfIlayAQpjGHtRvXaBVF SxciOqFFWxPqxoKaniMiiWqNQLb;

	private Action<IntPtr, IntPtr, uint, uint> yzgFjAAwsThDqPRedJjBqTBgVaQ;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public void xvbxOrqVqOrazQGxyaxNVVjBbvnD(Action<IntPtr, IntPtr, uint, uint> P_0, mqnblvULzJHugXeoWVmVrgHXsrC P_1)
	{
		yzgFjAAwsThDqPRedJjBqTBgVaQ = P_0;
		SxciOqFFWxPqxoKaniMiiWqNQLb = ssFcfVqirtAJodeRKXfbAFMclMJ;
		uint num = 0u;
		if (P_1 == mqnblvULzJHugXeoWVmVrgHXsrC.xhYjcixNTtOgssbzJZzCuIsvzNJ)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		BngitMecwaCrsFQiwZJlfiUxHEr = CRufyamCQuxfTZFAKxIvfOWlVUv(4, SxciOqFFWxPqxoKaniMiiWqNQLb, IntPtr.Zero, num);
		_ = BngitMecwaCrsFQiwZJlfiUxHEr == IntPtr.Zero;
	}

	public void geoIFBiFlApdDXXfKBCJdCpXhlk()
	{
		if (!(BngitMecwaCrsFQiwZJlfiUxHEr == IntPtr.Zero) && HsLdGZfQdZtPOlWcLmwTQtHCyCVf(BngitMecwaCrsFQiwZJlfiUxHEr))
		{
			BngitMecwaCrsFQiwZJlfiUxHEr = IntPtr.Zero;
		}
	}

	private IntPtr ssFcfVqirtAJodeRKXfbAFMclMJ(int P_0, IntPtr P_1, IntPtr P_2)
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
			yzgFjAAwsThDqPRedJjBqTBgVaQ(arg, arg2, arg3, arg4);
		}
		return qPiuAbAaNEfkuHVmCJWtwXbdMIoW(BngitMecwaCrsFQiwZJlfiUxHEr, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~eJWngNSTFZkuMIMgRitSCDmgTKb()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			geoIFBiFlApdDXXfKBCJdCpXhlk();
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr CRufyamCQuxfTZFAKxIvfOWlVUv(int P_0, uagHltJFfIlayAQpjGHtRvXaBVF P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool HsLdGZfQdZtPOlWcLmwTQtHCyCVf(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr qPiuAbAaNEfkuHVmCJWtwXbdMIoW(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
