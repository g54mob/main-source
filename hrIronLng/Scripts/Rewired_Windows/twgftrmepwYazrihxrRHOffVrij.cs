using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Platforms;

internal class twgftrmepwYazrihxrRHOffVrij : IDisposable, rzdZlgCDIcckwebfCyfgjlclULZT
{
	private static class ExcjhUhNxiGWkeVYyjAbuJGhIxdC
	{
		private struct byhTZAnJCllugOgLAQTmYtwlCYI
		{
			internal int LFmyulvhyawdMpwOAdWQXdZXmuB;

			internal int lcIlSUWIziePGHqObTcFLqGjPO;

			internal int golfAhyPZhuWoQFbknDEmDBxNl;

			internal Guid ZZihBPariuDxXHHnKSIzsWhgLba;

			internal short eSyoLcYBIxjmWMHxuXBSshckPNq;
		}

		private const int fCAHIJWibGxWplrRjBrEJHTxPgo = 5;

		private const int XnUMaxhLWcixmRUPAOpTYuxTBlm = 0;

		private static readonly Guid GjmtdgdxHqhQTKciXLamZKoDJQX = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");

		private static IntPtr fFwrykgAviamtSDFoujrFiVRczhD;

		private static bool XqXIYlFxKVpNcmyoPOMjnjBcgawh;

		public static void hBYsUDSzdlymCRiOdnfaXSlsQLW(IntPtr P_0)
		{
			byhTZAnJCllugOgLAQTmYtwlCYI byhTZAnJCllugOgLAQTmYtwlCYI2 = new byhTZAnJCllugOgLAQTmYtwlCYI
			{
				lcIlSUWIziePGHqObTcFLqGjPO = 5,
				golfAhyPZhuWoQFbknDEmDBxNl = 0,
				ZZihBPariuDxXHHnKSIzsWhgLba = GjmtdgdxHqhQTKciXLamZKoDJQX,
				eSyoLcYBIxjmWMHxuXBSshckPNq = 0
			};
			byhTZAnJCllugOgLAQTmYtwlCYI2.LFmyulvhyawdMpwOAdWQXdZXmuB = Marshal.SizeOf((object)byhTZAnJCllugOgLAQTmYtwlCYI2);
			IntPtr intPtr = Marshal.AllocHGlobal(byhTZAnJCllugOgLAQTmYtwlCYI2.LFmyulvhyawdMpwOAdWQXdZXmuB);
			Marshal.StructureToPtr((object)byhTZAnJCllugOgLAQTmYtwlCYI2, intPtr, true);
			fFwrykgAviamtSDFoujrFiVRczhD = xXCVEWZPdJMRhIneVMqACexAPCY(P_0, intPtr, 0);
			XqXIYlFxKVpNcmyoPOMjnjBcgawh = true;
		}

		public static void FbufhfxBBqhtuHvHdvXDuiuNfxR()
		{
			if (!(fFwrykgAviamtSDFoujrFiVRczhD == IntPtr.Zero))
			{
				TNCgWdGdZqLZeQHMpplJtzjhWgBc(fFwrykgAviamtSDFoujrFiVRczhD);
				XqXIYlFxKVpNcmyoPOMjnjBcgawh = false;
			}
		}

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "RegisterDeviceNotification", SetLastError = true)]
		private static extern IntPtr xXCVEWZPdJMRhIneVMqACexAPCY(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnregisterDeviceNotification")]
		private static extern bool TNCgWdGdZqLZeQHMpplJtzjhWgBc(IntPtr P_0);
	}

	private const int qIbFXFCYyBDkhIydBMSYPKXMgvVD = 32771;

	private const int OenWaKPFVrmjWydkrqmyDHFAmRz = 32772;

	private const int UWwmelmQjmvSxcZayPgPPWsAkvO = 32768;

	private const int fkjEhMAcsYiipgNFfWfabktdckJc = 7;

	private const int tuYpKAAfMREhYrquFRFxZHSoIrV = 537;

	private const int FyHWECruWQfcIoEwJTThkkAuLqG = 255;

	private Action<EventArgs> nxnjufwpGFZBqFceVfJdwktpuUK;

	private Action<EventArgs> JYfTcYzUbDNVNEEoTMooSdmEiuUA;

	private Action<EventArgs> ZsIyPRmltCNDFkAyQGzmXAgWtUV;

	private Action<TSrfFdAmQuDNBoHUlddNXTpuyKU, QMQeCqPHCzDkbwgNXAhQBqgQGsWB> cTRdiUDYZXAgzPgVYdqsYJFPzpm;

	private IntPtr ZsqbhXuTHbKFJKFrTgjmCFmrKOV;

	private jERYfIVMkEOBjblcIKnxjVQObB SnthASdzcUfQsTTPVRjxxkcUdYr;

	private readonly bool GgcxdJMndFQaXoamiKBfmlMxEvw;

	private static fIwdfzxbbCPDQCFdxJoWFgqoGVGe RqpNxwcHFWbijnaTYgvCKbVhAxf;

	private jERYfIVMkEOBjblcIKnxjVQObB NHloVxUTtpZxCrEnxJPOxpoacrTf;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public IntPtr windowHandle => ZsqbhXuTHbKFJKFrTgjmCFmrKOV;

	public event Action<EventArgs> DeviceConnectedEvent
	{
		add
		{
			nxnjufwpGFZBqFceVfJdwktpuUK = (Action<EventArgs>)Delegate.Combine(nxnjufwpGFZBqFceVfJdwktpuUK, value);
		}
		remove
		{
			nxnjufwpGFZBqFceVfJdwktpuUK = (Action<EventArgs>)Delegate.Remove(nxnjufwpGFZBqFceVfJdwktpuUK, value);
		}
	}

	public event Action<EventArgs> DeviceDisconnectedEvent
	{
		add
		{
			JYfTcYzUbDNVNEEoTMooSdmEiuUA = (Action<EventArgs>)Delegate.Combine(JYfTcYzUbDNVNEEoTMooSdmEiuUA, value);
		}
		remove
		{
			JYfTcYzUbDNVNEEoTMooSdmEiuUA = (Action<EventArgs>)Delegate.Remove(JYfTcYzUbDNVNEEoTMooSdmEiuUA, value);
		}
	}

	public event Action<EventArgs> DeviceDisconnectPendingEvent
	{
		add
		{
			ZsIyPRmltCNDFkAyQGzmXAgWtUV = (Action<EventArgs>)Delegate.Combine(ZsIyPRmltCNDFkAyQGzmXAgWtUV, value);
		}
		remove
		{
			ZsIyPRmltCNDFkAyQGzmXAgWtUV = (Action<EventArgs>)Delegate.Remove(ZsIyPRmltCNDFkAyQGzmXAgWtUV, value);
		}
	}

	public event Action<TSrfFdAmQuDNBoHUlddNXTpuyKU, QMQeCqPHCzDkbwgNXAhQBqgQGsWB> WindowFocusEvent
	{
		add
		{
			cTRdiUDYZXAgzPgVYdqsYJFPzpm = (Action<TSrfFdAmQuDNBoHUlddNXTpuyKU, QMQeCqPHCzDkbwgNXAhQBqgQGsWB>)Delegate.Combine(cTRdiUDYZXAgzPgVYdqsYJFPzpm, value);
		}
		remove
		{
			cTRdiUDYZXAgzPgVYdqsYJFPzpm = (Action<TSrfFdAmQuDNBoHUlddNXTpuyKU, QMQeCqPHCzDkbwgNXAhQBqgQGsWB>)Delegate.Remove(cTRdiUDYZXAgzPgVYdqsYJFPzpm, value);
		}
	}

	public twgftrmepwYazrihxrRHOffVrij()
	{
		GgcxdJMndFQaXoamiKBfmlMxEvw = ReInput.editorPlatform != EditorPlatform.None;
		try
		{
			BVmTKMsAVVqdkfwNjSwlgNFzTsh();
		}
		catch
		{
			vfuiOJRwWxFrKDItVySXuycYJSq();
			throw;
		}
	}

	public void vfuiOJRwWxFrKDItVySXuycYJSq()
	{
		Dispose();
	}

	void rzdZlgCDIcckwebfCyfgjlclULZT.vfuiOJRwWxFrKDItVySXuycYJSq()
	{
		//ILSpy generated this explicit interface implementation from .override directive in vfuiOJRwWxFrKDItVySXuycYJSq
		this.vfuiOJRwWxFrKDItVySXuycYJSq();
	}

	private void BVmTKMsAVVqdkfwNjSwlgNFzTsh()
	{
		saRnrGGdMOYUbQGEKQmLhxDCIdS();
		hBYsUDSzdlymCRiOdnfaXSlsQLW();
		if (GgcxdJMndFQaXoamiKBfmlMxEvw)
		{
			NHloVxUTtpZxCrEnxJPOxpoacrTf = new jERYfIVMkEOBjblcIKnxjVQObB();
			NHloVxUTtpZxCrEnxJPOxpoacrTf.xvbxOrqVqOrazQGxyaxNVVjBbvnD(QaizCEAQicYoztawAgYTFRTHFpq, true);
		}
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~twgftrmepwYazrihxrRHOffVrij()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	private void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return;
		}
		if (GgcxdJMndFQaXoamiKBfmlMxEvw)
		{
			FbufhfxBBqhtuHvHdvXDuiuNfxR();
			if (NHloVxUTtpZxCrEnxJPOxpoacrTf != null)
			{
				NHloVxUTtpZxCrEnxJPOxpoacrTf.Dispose();
			}
			if (RqpNxwcHFWbijnaTYgvCKbVhAxf != null)
			{
				RqpNxwcHFWbijnaTYgvCKbVhAxf.Dispose();
				RqpNxwcHFWbijnaTYgvCKbVhAxf = null;
			}
		}
		else
		{
			FbufhfxBBqhtuHvHdvXDuiuNfxR();
			if (SnthASdzcUfQsTTPVRjxxkcUdYr != null)
			{
				SnthASdzcUfQsTTPVRjxxkcUdYr.Dispose();
			}
		}
		euujVPFzGztViWDbYvUutBvFQFP = true;
	}

	private void hBYsUDSzdlymCRiOdnfaXSlsQLW()
	{
		ExcjhUhNxiGWkeVYyjAbuJGhIxdC.hBYsUDSzdlymCRiOdnfaXSlsQLW(ZsqbhXuTHbKFJKFrTgjmCFmrKOV);
	}

	private void FbufhfxBBqhtuHvHdvXDuiuNfxR()
	{
		ExcjhUhNxiGWkeVYyjAbuJGhIxdC.FbufhfxBBqhtuHvHdvXDuiuNfxR();
	}

	private void caaDQebjukbOKMiUpWImSnAmvavD(cMSvoEKriZNtMdzXJTSCtfipYFh P_0, TSrfFdAmQuDNBoHUlddNXTpuyKU P_1, uint P_2, IntPtr P_3)
	{
		switch (P_2)
		{
		case 537u:
		{
			int num = P_1.VzFdrrrBHTiSjrJDNAldwssKOYa();
			if (P_3 == ZsqbhXuTHbKFJKFrTgjmCFmrKOV)
			{
				switch (num)
				{
				case 32768:
					nxnjufwpGFZBqFceVfJdwktpuUK?.Invoke(null);
					break;
				case 32772:
					JYfTcYzUbDNVNEEoTMooSdmEiuUA?.Invoke(null);
					break;
				case 32771:
					ZsIyPRmltCNDFkAyQGzmXAgWtUV?.Invoke(null);
					break;
				}
			}
			break;
		}
		case 7u:
		case 8u:
			if (cTRdiUDYZXAgzPgVYdqsYJFPzpm != null)
			{
				cTRdiUDYZXAgzPgVYdqsYJFPzpm(P_1, rAvDGaRacvzwvLKmICojipXmaqJA.WyxCFohprbBMADGZkjUWgbPPaRG(P_2));
			}
			break;
		}
	}

	private void QaizCEAQicYoztawAgYTFRTHFpq(cMSvoEKriZNtMdzXJTSCtfipYFh P_0, TSrfFdAmQuDNBoHUlddNXTpuyKU P_1, uint P_2, IntPtr P_3)
	{
		if (P_2 == 8 && cTRdiUDYZXAgzPgVYdqsYJFPzpm != null)
		{
			cTRdiUDYZXAgzPgVYdqsYJFPzpm(P_1, rAvDGaRacvzwvLKmICojipXmaqJA.WyxCFohprbBMADGZkjUWgbPPaRG(P_2));
		}
	}

	private void saRnrGGdMOYUbQGEKQmLhxDCIdS()
	{
		if (RqpNxwcHFWbijnaTYgvCKbVhAxf == null)
		{
			RqpNxwcHFWbijnaTYgvCKbVhAxf = new fIwdfzxbbCPDQCFdxJoWFgqoGVGe("RewiredWDMWindow", createMessageOnlyWindow: true, MBIqSvfDFVLvIfIFQxGtLzeBOKK);
			if (RqpNxwcHFWbijnaTYgvCKbVhAxf.Handle == IntPtr.Zero)
			{
				throw new Exception("Error creating window.");
			}
		}
		else
		{
			if (RqpNxwcHFWbijnaTYgvCKbVhAxf.Handle == IntPtr.Zero)
			{
				throw new Exception("Message window has invalid handle.");
			}
			RqpNxwcHFWbijnaTYgvCKbVhAxf.EjghPAITHKgbgXucFpSllyFoUZn(MBIqSvfDFVLvIfIFQxGtLzeBOKK);
		}
		ZsqbhXuTHbKFJKFrTgjmCFmrKOV = RqpNxwcHFWbijnaTYgvCKbVhAxf.Handle;
	}

	private IntPtr MBIqSvfDFVLvIfIFQxGtLzeBOKK(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		caaDQebjukbOKMiUpWImSnAmvavD(P_3, P_2, P_1, P_0);
		return IntPtr.Zero;
	}
}
