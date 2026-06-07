using System;
using System.Runtime.InteropServices;

internal class tBTFvJTvJuZgSxCMXgMbbcFXUSpB : IDisposable
{
	internal enum ToktlIrVHRoTMCQHmYkunJOMcRObA
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr OiUaSiNeVdQDAjfVnagZLBKBQoTD(int nCode, IntPtr wParam, IntPtr lParam);

	private const int sTqyItkBYvffQqkMwxnaKqOuhinN = 4;

	private IntPtr NNCwbOItTIIXhbPgpqPYYXmvLgLm = IntPtr.Zero;

	private OiUaSiNeVdQDAjfVnagZLBKBQoTD gxdbBGFGWRTTgMOSajEqlNZlytck;

	private Action<IntPtr, IntPtr, uint, uint> OZnwiEqiuxGQvjQEltToMnrVrFSr;

	private bool UpnnaiQCKSEKhenqqJeNmpDwniqvA;

	public void OLjHCKywsAMKPCuzMTPYbeGihIYaA(Action<IntPtr, IntPtr, uint, uint> P_0, ToktlIrVHRoTMCQHmYkunJOMcRObA P_1)
	{
		OZnwiEqiuxGQvjQEltToMnrVrFSr = P_0;
		gxdbBGFGWRTTgMOSajEqlNZlytck = lUYEZuTjVcvQtREMIZqmgcHqAbnQ;
		uint num = 0u;
		if (P_1 == ToktlIrVHRoTMCQHmYkunJOMcRObA.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		NNCwbOItTIIXhbPgpqPYYXmvLgLm = MSMgatAlZmYKdWWYpgbkApemQyfE(4, gxdbBGFGWRTTgMOSajEqlNZlytck, IntPtr.Zero, num);
		_ = NNCwbOItTIIXhbPgpqPYYXmvLgLm == IntPtr.Zero;
	}

	public void AMXXLRcPsiOQInIwHEMpVPczHtOi()
	{
		if (!(NNCwbOItTIIXhbPgpqPYYXmvLgLm == IntPtr.Zero) && zdUkGPpLlDnJEAkAUAeykdmwGkLFA(NNCwbOItTIIXhbPgpqPYYXmvLgLm))
		{
			NNCwbOItTIIXhbPgpqPYYXmvLgLm = IntPtr.Zero;
		}
	}

	private IntPtr lUYEZuTjVcvQtREMIZqmgcHqAbnQ(int P_0, IntPtr P_1, IntPtr P_2)
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
			OZnwiEqiuxGQvjQEltToMnrVrFSr(arg, arg2, arg3, arg4);
		}
		return rUkfYnbpZFAxiurClNOGCNhBAzgT(NNCwbOItTIIXhbPgpqPYYXmvLgLm, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		XfIDsNzJnxZShmLhHpOLgtRgWang(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void okkGVKXEWeDEZaXuSnWuTBXJNOrv()
	{
		try
		{
			XfIDsNzJnxZShmLhHpOLgtRgWang(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void XfIDsNzJnxZShmLhHpOLgtRgWang(bool P_0)
	{
		if (!UpnnaiQCKSEKhenqqJeNmpDwniqvA)
		{
			AMXXLRcPsiOQInIwHEMpVPczHtOi();
			UpnnaiQCKSEKhenqqJeNmpDwniqvA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr MSMgatAlZmYKdWWYpgbkApemQyfE(int P_0, OiUaSiNeVdQDAjfVnagZLBKBQoTD P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool zdUkGPpLlDnJEAkAUAeykdmwGkLFA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr rUkfYnbpZFAxiurClNOGCNhBAzgT(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
