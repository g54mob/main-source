using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class qEnIACTEaVowTZHrdOWusBSvvTe : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr LgvixIdzBMBPUSFcHeXGiuLpJqD(int nCode, IntPtr wParam, IntPtr lParam);

	private struct DrwjlsCXdArnguGiQAiiDZOQtcq
	{
		public IntPtr MAuXIdLidZiAUSBiWiGHeHgSCDXQ;

		public IntPtr FszoNcfrOEOFnwjNUYFcRNtkaoGC;

		public uint PNtJJpQTiTWANZtqKDOtZuvECaP;

		public IntPtr zFNUfMfCdiNXJQPJHjaujDGUMOY;
	}

	private const int GToGAwRxNiGZwsDoiyxudwCcNkq = 4;

	private static qEnIACTEaVowTZHrdOWusBSvvTe eIobyjHFvPbQBmkoIrGJNjCFGcxc;

	private IntPtr ANRPjvfIQHGcwfqwnFRqooBAfRAc = IntPtr.Zero;

	private LgvixIdzBMBPUSFcHeXGiuLpJqD TCNplHYomUEbzIIagJyzdbhcaBSy;

	private Action<nMvdyvLQEkLRQHBHYCdBihdKBYQ, WsSYQoLcjDhJJICQctaOSeWVJfl, uint, IntPtr> vYDyIrldKuBzitCmacbGbKCTAfjl;

	private byte[] kwTmcVQZrjBXrMLnOnDXNaIrqba;

	private readonly bool LSXKhNWqaYXRhGEFFUMCjrDtClE;

	private DrwjlsCXdArnguGiQAiiDZOQtcq yHVyYDJrGicDobEmafQmhODqRTTg;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public qEnIACTEaVowTZHrdOWusBSvvTe()
	{
		while (true)
		{
			int num = 846573069;
			while (true)
			{
				switch (num ^ 0x3275AE0F)
				{
				case 0:
					break;
				case 2:
				{
					int num2;
					if (eIobyjHFvPbQBmkoIrGJNjCFGcxc == null)
					{
						num = 846573070;
						num2 = num;
					}
					else
					{
						num = 846573068;
						num2 = num;
					}
					continue;
				}
				case 3:
					throw new Exception("Singleton instance already exists!");
				default:
					eIobyjHFvPbQBmkoIrGJNjCFGcxc = this;
					LSXKhNWqaYXRhGEFFUMCjrDtClE = IntPtr.Size == 8;
					kwTmcVQZrjBXrMLnOnDXNaIrqba = new byte[IntPtr.Size * 3 + 4];
					return;
				}
				break;
			}
		}
	}

	public void sNUVbIfmUnCXtcPdpvKSKByqonA(Action<nMvdyvLQEkLRQHBHYCdBihdKBYQ, WsSYQoLcjDhJJICQctaOSeWVJfl, uint, IntPtr> P_0, bool P_1)
	{
		vYDyIrldKuBzitCmacbGbKCTAfjl = P_0;
		TCNplHYomUEbzIIagJyzdbhcaBSy = pSoFdClHUGFeNFUqDfHgFuQJfare;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
			goto IL_0024;
		}
		goto IL_0046;
		IL_0046:
		ANRPjvfIQHGcwfqwnFRqooBAfRAc = XrTDeBbdcLYNfpkHTurDykDWfMhb(4, TCNplHYomUEbzIIagJyzdbhcaBSy, IntPtr.Zero, num);
		int num2;
		int num3;
		if (ANRPjvfIQHGcwfqwnFRqooBAfRAc == IntPtr.Zero)
		{
			num2 = -1091568875;
			num3 = num2;
		}
		else
		{
			num2 = -1091568873;
			num3 = num2;
		}
		goto IL_0029;
		IL_0024:
		num2 = -1091568876;
		goto IL_0029;
		IL_0029:
		while (true)
		{
			switch (num2 ^ -1091568874)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0046;
			case 3:
				Logger.LogError("SetWindowsHookEx Failed");
				num2 = -1091568873;
				continue;
			case 1:
				return;
			}
			break;
		}
		goto IL_0024;
	}

	public void zdHTTidIHxvZLvYzVRBSuCyiEeR()
	{
		if (ANRPjvfIQHGcwfqwnFRqooBAfRAc == IntPtr.Zero)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (!SSaBLiNoDmtpUktqQMkAapEhbZs(ANRPjvfIQHGcwfqwnFRqooBAfRAc))
			{
				num = -2135907823;
				num2 = num;
			}
			else
			{
				num = -2135907822;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -2135907824)
				{
				case 0:
					goto IL_0013;
				case 3:
					break;
				case 1:
					Logger.LogError("UnhookWindowsHookEx Failed");
					return;
				default:
					ANRPjvfIQHGcwfqwnFRqooBAfRAc = IntPtr.Zero;
					return;
				}
				break;
				IL_0013:
				num = -2135907821;
			}
		}
	}

	[MonoPInvokeCallback(typeof(LgvixIdzBMBPUSFcHeXGiuLpJqD))]
	private static IntPtr pSoFdClHUGFeNFUqDfHgFuQJfare(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba, 0, eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba.Length);
		int num = 0;
		eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.MAuXIdLidZiAUSBiWiGHeHgSCDXQ = nMvdyvLQEkLRQHBHYCdBihdKBYQ.TYlxuGmSJRngTlXtymyHFDIVxCx(eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba, num);
		num += nMvdyvLQEkLRQHBHYCdBihdKBYQ.jCrESXpCSpMEOgJbFAsGAKUQCWML;
		eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.FszoNcfrOEOFnwjNUYFcRNtkaoGC = WsSYQoLcjDhJJICQctaOSeWVJfl.TYlxuGmSJRngTlXtymyHFDIVxCx(eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba, num);
		num += WsSYQoLcjDhJJICQctaOSeWVJfl.jCrESXpCSpMEOgJbFAsGAKUQCWML;
		eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.PNtJJpQTiTWANZtqKDOtZuvECaP = BitConverter.ToUInt32(eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba, num);
		num += 4;
		while (true)
		{
			int num2 = 1757816698;
			while (true)
			{
				switch (num2 ^ 0x68C62779)
				{
				case 2:
					break;
				case 3:
				{
					int num3;
					if (!eIobyjHFvPbQBmkoIrGJNjCFGcxc.LSXKhNWqaYXRhGEFFUMCjrDtClE)
					{
						num2 = 1757816700;
						num3 = num2;
					}
					else
					{
						num2 = 1757816697;
						num3 = num2;
					}
					continue;
				}
				case 5:
					eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.zFNUfMfCdiNXJQPJHjaujDGUMOY = new IntPtr(BitConverter.ToInt32(eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba, num));
					num2 = 1757816696;
					continue;
				case 0:
					eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.zFNUfMfCdiNXJQPJHjaujDGUMOY = new IntPtr(BitConverter.ToInt32(eIobyjHFvPbQBmkoIrGJNjCFGcxc.kwTmcVQZrjBXrMLnOnDXNaIrqba, num + 4));
					num2 = 1757816701;
					continue;
				case 1:
					if (P_0 >= 0)
					{
						eIobyjHFvPbQBmkoIrGJNjCFGcxc.vYDyIrldKuBzitCmacbGbKCTAfjl(eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.MAuXIdLidZiAUSBiWiGHeHgSCDXQ, eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.FszoNcfrOEOFnwjNUYFcRNtkaoGC, eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.PNtJJpQTiTWANZtqKDOtZuvECaP, eIobyjHFvPbQBmkoIrGJNjCFGcxc.yHVyYDJrGicDobEmafQmhODqRTTg.zFNUfMfCdiNXJQPJHjaujDGUMOY);
						num2 = 1757816703;
						continue;
					}
					goto default;
				case 4:
					num2 = 1757816696;
					continue;
				default:
					return jrZBLWDuxjYPmbvcXMlgWiwKTLJ(eIobyjHFvPbQBmkoIrGJNjCFGcxc.ANRPjvfIQHGcwfqwnFRqooBAfRAc, P_0, P_1, P_2);
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~qEnIACTEaVowTZHrdOWusBSvvTe()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		while (true)
		{
			zdHTTidIHxvZLvYzVRBSuCyiEeR();
			int num = -825528231;
			while (true)
			{
				switch (num ^ -825528229)
				{
				case 0:
					num = -825528232;
					continue;
				case 3:
					break;
				case 2:
					if (eIobyjHFvPbQBmkoIrGJNjCFGcxc == this)
					{
						eIobyjHFvPbQBmkoIrGJNjCFGcxc = null;
						num = -825528230;
						continue;
					}
					goto default;
				default:
					nNxUslIcGUpqKgpPZYhuimcvWyC = true;
					return;
				}
				break;
			}
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr XrTDeBbdcLYNfpkHTurDykDWfMhb(int P_0, LgvixIdzBMBPUSFcHeXGiuLpJqD P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool SSaBLiNoDmtpUktqQMkAapEhbZs(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr jrZBLWDuxjYPmbvcXMlgWiwKTLJ(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
