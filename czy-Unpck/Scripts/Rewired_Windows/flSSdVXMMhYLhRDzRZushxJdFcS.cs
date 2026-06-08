using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class flSSdVXMMhYLhRDzRZushxJdFcS : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr BtLhgktFYffkNSkGjcOkblikrXUG(int nCode, IntPtr wParam, IntPtr lParam);

	private struct SHqJQkZjkMnhausxGIApTuHURGg
	{
		public IntPtr PZNvZmZsDjcowQxIiBNFIwRAiFf;

		public IntPtr GsWTHrjEqqvsViTvaYkmGROusKo;

		public uint QZMHeJSOAdqitJKbwBrjAYJSeFl;

		public IntPtr yhydmHrtDKhlpWxphvFmatnICFk;
	}

	private const int ZTTUAzBhYWzAAkAlCjKkyzrqLQS = 4;

	private static flSSdVXMMhYLhRDzRZushxJdFcS tILAyeFDXpivtsEWqbVPwvnLigJ;

	private IntPtr PFglRqbsMvCbCpSJNIdujwlIFYk = IntPtr.Zero;

	private BtLhgktFYffkNSkGjcOkblikrXUG WqkvSGAYruHaTUEEYbadyICkjRc;

	private Action<ugMxbuNAmUDbwiBtuSJRPbQUgIiT, FalmQVTJKnCRzOnsKpwWBjXTJHN, uint, IntPtr> cSaAusaniKcLOypQOOaYxTpXQrBG;

	private byte[] dDkMmdSJtTxlnGajePmZUPJtBoL;

	private readonly bool KnrDKmSJKMVrlCkefBRCskKtpQT;

	private SHqJQkZjkMnhausxGIApTuHURGg hNmIuSRRaInEAzFEAfLiTmouHJl;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public flSSdVXMMhYLhRDzRZushxJdFcS()
	{
		if (tILAyeFDXpivtsEWqbVPwvnLigJ != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		tILAyeFDXpivtsEWqbVPwvnLigJ = this;
		KnrDKmSJKMVrlCkefBRCskKtpQT = IntPtr.Size == 8;
		dDkMmdSJtTxlnGajePmZUPJtBoL = new byte[IntPtr.Size * 3 + 4];
	}

	public void vBrWVLrJkJNkFadFTFyMERBupmyB(Action<ugMxbuNAmUDbwiBtuSJRPbQUgIiT, FalmQVTJKnCRzOnsKpwWBjXTJHN, uint, IntPtr> P_0, bool P_1)
	{
		cSaAusaniKcLOypQOOaYxTpXQrBG = P_0;
		WqkvSGAYruHaTUEEYbadyICkjRc = qDszRUlukUExWBUbNYaKthHCyNE;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
			goto IL_0024;
		}
		goto IL_0046;
		IL_0046:
		PFglRqbsMvCbCpSJNIdujwlIFYk = KeMcCDfQhlnBKbpZxsTDfixSCJb(4, WqkvSGAYruHaTUEEYbadyICkjRc, IntPtr.Zero, num);
		int num2;
		int num3;
		if (PFglRqbsMvCbCpSJNIdujwlIFYk == IntPtr.Zero)
		{
			num2 = -2026178892;
			num3 = num2;
		}
		else
		{
			num2 = -2026178889;
			num3 = num2;
		}
		goto IL_0029;
		IL_0024:
		num2 = -2026178891;
		goto IL_0029;
		IL_0029:
		while (true)
		{
			switch (num2 ^ -2026178890)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0046;
			case 2:
				Logger.LogError("SetWindowsHookEx Failed");
				num2 = -2026178889;
				continue;
			case 1:
				return;
			}
			break;
		}
		goto IL_0024;
	}

	public void yXkNHxfnRTfZnnLjvYkKhVkearp()
	{
		if (PFglRqbsMvCbCpSJNIdujwlIFYk == IntPtr.Zero)
		{
			return;
		}
		while (true)
		{
			bool flag = JLVfNtCHjGUFgpiCqMtIytvbTLQh(PFglRqbsMvCbCpSJNIdujwlIFYk);
			int num = -1074906406;
			while (true)
			{
				switch (num ^ -1074906408)
				{
				case 0:
					goto IL_0013;
				case 3:
					break;
				case 2:
					if (!flag)
					{
						Logger.LogError("UnhookWindowsHookEx Failed");
						return;
					}
					goto default;
				default:
					PFglRqbsMvCbCpSJNIdujwlIFYk = IntPtr.Zero;
					return;
				}
				break;
				IL_0013:
				num = -1074906405;
			}
		}
	}

	[MonoPInvokeCallback(typeof(BtLhgktFYffkNSkGjcOkblikrXUG))]
	private static IntPtr qDszRUlukUExWBUbNYaKthHCyNE(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL, 0, tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL.Length);
		int num = 0;
		while (true)
		{
			int num2 = -1747743896;
			while (true)
			{
				switch (num2 ^ -1747743894)
				{
				case 5:
					break;
				case 0:
					num += FalmQVTJKnCRzOnsKpwWBjXTJHN.kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;
					tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.QZMHeJSOAdqitJKbwBrjAYJSeFl = BitConverter.ToUInt32(tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL, num);
					num2 = -1747743892;
					continue;
				case 6:
					num += 4;
					if (tILAyeFDXpivtsEWqbVPwvnLigJ.KnrDKmSJKMVrlCkefBRCskKtpQT)
					{
						tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.yhydmHrtDKhlpWxphvFmatnICFk = new IntPtr(BitConverter.ToInt32(tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL, num + 4));
						num2 = -1747743895;
						continue;
					}
					goto case 4;
				case 3:
					if (P_0 >= 0)
					{
						tILAyeFDXpivtsEWqbVPwvnLigJ.cSaAusaniKcLOypQOOaYxTpXQrBG(tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.PZNvZmZsDjcowQxIiBNFIwRAiFf, tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.GsWTHrjEqqvsViTvaYkmGROusKo, tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.QZMHeJSOAdqitJKbwBrjAYJSeFl, tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.yhydmHrtDKhlpWxphvFmatnICFk);
						num2 = -1747743902;
						continue;
					}
					goto default;
				case 7:
					tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.GsWTHrjEqqvsViTvaYkmGROusKo = FalmQVTJKnCRzOnsKpwWBjXTJHN.KzYVtPsQfzeDlvcDIxbFIktRwxL(tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL, num);
					num2 = -1747743894;
					continue;
				case 4:
					tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.yhydmHrtDKhlpWxphvFmatnICFk = new IntPtr(BitConverter.ToInt32(tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL, num));
					num2 = -1747743895;
					continue;
				case 1:
					num += ugMxbuNAmUDbwiBtuSJRPbQUgIiT.kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;
					num2 = -1747743891;
					continue;
				case 2:
					tILAyeFDXpivtsEWqbVPwvnLigJ.hNmIuSRRaInEAzFEAfLiTmouHJl.PZNvZmZsDjcowQxIiBNFIwRAiFf = ugMxbuNAmUDbwiBtuSJRPbQUgIiT.KzYVtPsQfzeDlvcDIxbFIktRwxL(tILAyeFDXpivtsEWqbVPwvnLigJ.dDkMmdSJtTxlnGajePmZUPJtBoL, num);
					num2 = -1747743893;
					continue;
				default:
					return cxiZPHXSXNkcYbiExGXkfXVWKLvm(tILAyeFDXpivtsEWqbVPwvnLigJ.PFglRqbsMvCbCpSJNIdujwlIFYk, P_0, P_1, P_2);
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~flSSdVXMMhYLhRDzRZushxJdFcS()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		while (true)
		{
			yXkNHxfnRTfZnnLjvYkKhVkearp();
			int num = -650466104;
			while (true)
			{
				switch (num ^ -650466101)
				{
				case 0:
					num = -650466103;
					continue;
				case 2:
					break;
				case 3:
					if (tILAyeFDXpivtsEWqbVPwvnLigJ == this)
					{
						tILAyeFDXpivtsEWqbVPwvnLigJ = null;
						num = -650466102;
						continue;
					}
					goto default;
				default:
					inweGjIgYacXYohFlYRlpMFkgKMi = true;
					return;
				}
				break;
			}
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr KeMcCDfQhlnBKbpZxsTDfixSCJb(int P_0, BtLhgktFYffkNSkGjcOkblikrXUG P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool JLVfNtCHjGUFgpiCqMtIytvbTLQh(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr cxiZPHXSXNkcYbiExGXkfXVWKLvm(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
