using System;
using System.Runtime.InteropServices;

internal class flBAaKhkxkiDVazAFntBYAdihBIJ : IDisposable
{
	internal enum CvXKGCZKKNfLNWESWJmDXeCGneJ
	{
		amDtsrBDpUJvvTWFfrTLqyXwJau = 0,
		xQWouGqblDuyKscTMUlBgNchQZH = 1
	}

	private delegate IntPtr pzHmJoFxctvGQTVDnIVscsyzlpj(int nCode, IntPtr wParam, IntPtr lParam);

	private const int EeSNjSeRNiAilbuOZspcwjAOVli = 4;

	private IntPtr KbtdsRWEOTnttqnQACTgBnNkOBUB = IntPtr.Zero;

	private pzHmJoFxctvGQTVDnIVscsyzlpj FshAathsoYmsmNJEDAszwEbUHBWA;

	private Action<IntPtr, IntPtr, uint, uint> dbvqhTEvKcUotwRODBfQBDIrhdha;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public void udkMCiMROhAJufzBMnlEZscMcyE(Action<IntPtr, IntPtr, uint, uint> P_0, CvXKGCZKKNfLNWESWJmDXeCGneJ P_1)
	{
		dbvqhTEvKcUotwRODBfQBDIrhdha = P_0;
		FshAathsoYmsmNJEDAszwEbUHBWA = juEkFkQHYIAhAMKOuGJqFOAxPuxp;
		uint num = 0u;
		if (P_1 == CvXKGCZKKNfLNWESWJmDXeCGneJ.amDtsrBDpUJvvTWFfrTLqyXwJau)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		KbtdsRWEOTnttqnQACTgBnNkOBUB = VZjhWrKosBUHwszjuxSJpQTsKvh(4, FshAathsoYmsmNJEDAszwEbUHBWA, IntPtr.Zero, num);
		bool flag = KbtdsRWEOTnttqnQACTgBnNkOBUB == IntPtr.Zero;
	}

	public void zphONIGhZdWSWuYBmNkAtbyYGiB()
	{
		if (!(KbtdsRWEOTnttqnQACTgBnNkOBUB == IntPtr.Zero) && UgALUUovBaPkVfUQjyRWneURLRi(KbtdsRWEOTnttqnQACTgBnNkOBUB))
		{
			KbtdsRWEOTnttqnQACTgBnNkOBUB = IntPtr.Zero;
		}
	}

	private IntPtr juEkFkQHYIAhAMKOuGJqFOAxPuxp(int P_0, IntPtr P_1, IntPtr P_2)
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
			dbvqhTEvKcUotwRODBfQBDIrhdha(arg, arg2, arg3, arg4);
		}
		return ncvhIucIdjEFxuoYawQqPmegBLH(KbtdsRWEOTnttqnQACTgBnNkOBUB, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~flBAaKhkxkiDVazAFntBYAdihBIJ()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			zphONIGhZdWSWuYBmNkAtbyYGiB();
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr VZjhWrKosBUHwszjuxSJpQTsKvh(int P_0, pzHmJoFxctvGQTVDnIVscsyzlpj P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool UgALUUovBaPkVfUQjyRWneURLRi(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr ncvhIucIdjEFxuoYawQqPmegBLH(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
