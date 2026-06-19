using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class HsYvOtByjTpCsLhlELiVqIUfAvLdA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr wYbWDeQvJmCVVcqGKlLSywIsmcRP(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct DhZLGQgPufaZWyubRZopGmPCdreeA
	{
		public uint ezTncsdjwPYfuuQWwOvtzjyomDCd;

		public IntPtr UOfKZzKPwPjEDdbJsXUoNEiCKTzl;

		public int UgWlEkJxqzpIokGmOcPqrStBCIeEA;

		public int KxlixWlOOYqfYpujrunXORILssEn;

		public IntPtr nYUhdBZPsPZQxGBidLkPqCctxPN;

		public IntPtr qaPaWYssPpBspFqfPdPldrgAqZGhc;

		public IntPtr CpRQVqanQUNxETrjGrmGxUhrNzsS;

		public IntPtr mGlugzXgTEeZKCHyjAiVemnAFLmQ;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string mVEqppXadeMuaiakzkYgkCAGbrKe;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string bZupcAxlvvkxWDeXbusqXHxmbIIkA;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct cJDDZWvGTcqPuDWNIaCCAxulMLeo
	{
		public IntPtr AIHkdNSTZcUFMFDHqaltDQZFQnHs;

		public IntPtr ZTsqjyMsBvSITMGfNzeDicVNDYdA;

		public IntPtr gXrilBrEFWeiOAnDxwXRkMekmFIk;

		public IntPtr QxHRGDCGyznMtZSaBSyzUcAvuPDn;

		public int LilUqhLtHwMZgQmQIFdsRuxqnSrQ;

		public int iLXmTPCJtXPPjTBMKvhCbEMOiyQl;

		public int VzXAetPapBkaUvLSHPciDvuRvHnJ;

		public int wHTyGPfyibdRzVhAREYyfYrgglTUA;

		public int ernIWtlMrZnnhkIRDWpgOYoYylzi;

		public IntPtr rINwijWYLjkQEGzVxRIquMXwsLwj;

		public IntPtr ozivoRKCjsWQeKgfyIkWhSZyeAsl;

		public uint dKPKyxXxnCygzcaUFzihYyiuiHRc;
	}

	private const int FQQMeTeezsyISRnzSGvMuganbXWK = 20;

	private const int BHeVdznoqBfpKWHqUOTOYIVkflYFA = 1410;

	private readonly ushort aWmgXbRCPXwxahfDScnrPSVLcaqcA;

	private readonly string jcVIFDAMGrQvjMcUIBltrYgePvpO;

	private bool LWpQsuDzjYGwjuUGgTjTwURQNkcP;

	private IntPtr opbpbzxcyOdCOapdhLUDrZkgXMwkA;

	private int HwVNFiYhKrJIoFWZJfbKTichTrBY;

	private uint DTcLOBcZCDDzTQdOhCWTREmFmNzs;

	private wYbWDeQvJmCVVcqGKlLSywIsmcRP SbzUDqFVUXgKTceKfZIszCorGXuL;

	private wYbWDeQvJmCVVcqGKlLSywIsmcRP ZVlbxtROjfCBJhkrjeLSBxeCpSIkB;

	public IntPtr OyfDnpdxyHeeEexAEYbLezStFebmc => opbpbzxcyOdCOapdhLUDrZkgXMwkA;

	public uint eqQAvnvWpvyjJPhtZWuvLJZodbDB => DTcLOBcZCDDzTQdOhCWTREmFmNzs;

	public bool khlrWYtsxnbUrsxFahUuqMHLvNyi
	{
		get
		{
			if (!(opbpbzxcyOdCOapdhLUDrZkgXMwkA != IntPtr.Zero))
			{
				return false;
			}
			return jUgagJHdcZKCtNPatcEIpZhzLbJQA(opbpbzxcyOdCOapdhLUDrZkgXMwkA);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort kdUTzZrihAJbyoAnyxfFPKljiAnr([In] ref DhZLGQgPufaZWyubRZopGmPCdreeA P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool KSxGpGEjbyhCqPcCbsCfnePVCqnLA([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr atxOquOBnbwJpYjYOxcmvwcrGphx(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr kiLtfxKQUQUChALPLbtsiOOEudrC(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool eSvfEKkOGhAsnaeYXXrdymruRJjpA(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool jUgagJHdcZKCtNPatcEIpZhzLbJQA(IntPtr P_0);

	public void Dispose()
	{
		EPnPoloysihBGBsDLJUpMWPgDgpO(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void vzrpNBgmlLxedInjHhFyieDvglSP()
	{
		try
		{
			EPnPoloysihBGBsDLJUpMWPgDgpO(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void EPnPoloysihBGBsDLJUpMWPgDgpO(bool P_0)
	{
		if (!LWpQsuDzjYGwjuUGgTjTwURQNkcP)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(DTcLOBcZCDDzTQdOhCWTREmFmNzs);
			}
			if (opbpbzxcyOdCOapdhLUDrZkgXMwkA != IntPtr.Zero)
			{
				eSvfEKkOGhAsnaeYXXrdymruRJjpA(opbpbzxcyOdCOapdhLUDrZkgXMwkA);
				opbpbzxcyOdCOapdhLUDrZkgXMwkA = IntPtr.Zero;
			}
			if (aWmgXbRCPXwxahfDScnrPSVLcaqcA != 0 && !string.IsNullOrEmpty(jcVIFDAMGrQvjMcUIBltrYgePvpO))
			{
				KSxGpGEjbyhCqPcCbsCfnePVCqnLA(jcVIFDAMGrQvjMcUIBltrYgePvpO, IntPtr.Zero);
			}
			LWpQsuDzjYGwjuUGgTjTwURQNkcP = true;
		}
	}

	public HsYvOtByjTpCsLhlELiVqIUfAvLdA(string P_0, bool P_1, wYbWDeQvJmCVVcqGKlLSywIsmcRP P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		DTcLOBcZCDDzTQdOhCWTREmFmNzs = ObjectInstanceTracker.Default.Register(this);
		jcVIFDAMGrQvjMcUIBltrYgePvpO = P_0;
		SbzUDqFVUXgKTceKfZIszCorGXuL = fpnQonvXoHRBlGXoOwDSYjijSJeC;
		ZVlbxtROjfCBJhkrjeLSBxeCpSIkB = P_2;
		HwVNFiYhKrJIoFWZJfbKTichTrBY = 0;
		DhZLGQgPufaZWyubRZopGmPCdreeA dhZLGQgPufaZWyubRZopGmPCdreeA = new DhZLGQgPufaZWyubRZopGmPCdreeA
		{
			UOfKZzKPwPjEDdbJsXUoNEiCKTzl = Marshal.GetFunctionPointerForDelegate(SbzUDqFVUXgKTceKfZIszCorGXuL)
		};
		while (aWmgXbRCPXwxahfDScnrPSVLcaqcA == 0 && HwVNFiYhKrJIoFWZJfbKTichTrBY < 20)
		{
			dhZLGQgPufaZWyubRZopGmPCdreeA.bZupcAxlvvkxWDeXbusqXHxmbIIkA = P_0;
			aWmgXbRCPXwxahfDScnrPSVLcaqcA = kdUTzZrihAJbyoAnyxfFPKljiAnr(ref dhZLGQgPufaZWyubRZopGmPCdreeA);
			if (aWmgXbRCPXwxahfDScnrPSVLcaqcA != 0)
			{
				break;
			}
			HwVNFiYhKrJIoFWZJfbKTichTrBY++;
			P_0 = jcVIFDAMGrQvjMcUIBltrYgePvpO + HwVNFiYhKrJIoFWZJfbKTichTrBY;
		}
		if (aWmgXbRCPXwxahfDScnrPSVLcaqcA == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (jcVIFDAMGrQvjMcUIBltrYgePvpO != P_0)
		{
			jcVIFDAMGrQvjMcUIBltrYgePvpO = P_0;
		}
		if (P_1)
		{
			opbpbzxcyOdCOapdhLUDrZkgXMwkA = cYZfoDGpjkGeRazsUqLjOwzqmEstA(P_0, new IntPtr((int)DTcLOBcZCDDzTQdOhCWTREmFmNzs));
		}
		else
		{
			opbpbzxcyOdCOapdhLUDrZkgXMwkA = jSkAsLzdFEWsEqCIHNmLHtdVOEaS(P_0, new IntPtr((int)DTcLOBcZCDDzTQdOhCWTREmFmNzs));
		}
	}

	private IntPtr jSkAsLzdFEWsEqCIHNmLHtdVOEaS(string P_0, IntPtr P_1)
	{
		return atxOquOBnbwJpYjYOxcmvwcrGphx(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr cYZfoDGpjkGeRazsUqLjOwzqmEstA(string P_0, IntPtr P_1)
	{
		return atxOquOBnbwJpYjYOxcmvwcrGphx(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, OZbSvqUUHiSzSuQfJGOouxVsZnLE.CValdITRDBomWTMBBbMdHFzJnqhgA, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(wYbWDeQvJmCVVcqGKlLSywIsmcRP))]
	private unsafe static IntPtr fpnQonvXoHRBlGXoOwDSYjijSJeC(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return kiLtfxKQUQUChALPLbtsiOOEudrC(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			cJDDZWvGTcqPuDWNIaCCAxulMLeo* ptr = (cJDDZWvGTcqPuDWNIaCCAxulMLeo*)(void*)P_3;
			if (ptr->AIHkdNSTZcUFMFDHqaltDQZFQnHs != IntPtr.Zero)
			{
				wfRybNWHWOpoyMQsxzdwHdiNgarj.YVOjPRbBZZNHElKwRkkPJlZDirJU(P_0, -21, ptr->AIHkdNSTZcUFMFDHqaltDQZFQnHs);
			}
		}
		else
		{
			instanceId = (uint)wfRybNWHWOpoyMQsxzdwHdiNgarj.RNTSeQytKTJGCLajzgACfVAgLGOX(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<HsYvOtByjTpCsLhlELiVqIUfAvLdA>(instanceId, out var instance))
		{
			instance.ZVlbxtROjfCBJhkrjeLSBxeCpSIkB(P_0, P_1, P_2, P_3);
		}
		return kiLtfxKQUQUChALPLbtsiOOEudrC(P_0, P_1, P_2, P_3);
	}

	public void yZRbLwZAXRDoNJqNzUXfmzSCYAId(wYbWDeQvJmCVVcqGKlLSywIsmcRP P_0)
	{
		ZVlbxtROjfCBJhkrjeLSBxeCpSIkB = P_0;
	}
}
