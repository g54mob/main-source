using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Platforms;

internal class xAAARHJpGeNEmXXisDcrWtIrxcCb : czgJqnWAYNszYaRJoqKfeNAgdBDQ, IDisposable
{
	private static class dXkLmbRedZuwiNgDNudcZteZtSeU
	{
		private struct vhoyrXeskXGKocDJBkwqqAonxEGo
		{
			internal int mQHcTNeFKVJuNaVmCJVpqyGqsDgtB;

			internal int TlleqoyEfyeilkZWkdVjDvTOqpMHA;

			internal int YlseWKsUUaEADHeOwqGLnVuRJwEOA;

			internal Guid cVILKKJpaJDHdHBoFoADPNuTFuwzA;

			internal short TFBNUlQBzLoUsAAQwLnWGToAuUQs;
		}

		private const int QAJlEevyjRJELSQMCJePgliWkOMU = 5;

		private const int mXJZWRMPWMlcFcsGvblcdkLAEwaN = 0;

		private static readonly Guid utaIAaegJRBGhgPQZlHMKgBaFCdGA = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");

		private static IntPtr exuPIzCBdmQwJgyfKOSVtCndvDjM;

		private static bool MJAPorpWThsqfJvHYMAjRKzQxqmI;

		public static void GlxTVooJtngitUWdgAwUDVzvXCAs(IntPtr P_0)
		{
			vhoyrXeskXGKocDJBkwqqAonxEGo structure = new vhoyrXeskXGKocDJBkwqqAonxEGo
			{
				TlleqoyEfyeilkZWkdVjDvTOqpMHA = 5,
				YlseWKsUUaEADHeOwqGLnVuRJwEOA = 0,
				cVILKKJpaJDHdHBoFoADPNuTFuwzA = utaIAaegJRBGhgPQZlHMKgBaFCdGA,
				TFBNUlQBzLoUsAAQwLnWGToAuUQs = 0
			};
			structure.mQHcTNeFKVJuNaVmCJVpqyGqsDgtB = Marshal.SizeOf(structure);
			IntPtr intPtr = Marshal.AllocHGlobal(structure.mQHcTNeFKVJuNaVmCJVpqyGqsDgtB);
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: true);
			exuPIzCBdmQwJgyfKOSVtCndvDjM = ATiqfGhHnbdJUbTEYfUMolICgLJMA(P_0, intPtr, 0);
			MJAPorpWThsqfJvHYMAjRKzQxqmI = true;
		}

		public static void yyBnMVpTsIcBvubjWPMMtbgJHNLbA()
		{
			if (!(exuPIzCBdmQwJgyfKOSVtCndvDjM == IntPtr.Zero))
			{
				KaJxoTYxWGusRctKImjauwQdgPSs(exuPIzCBdmQwJgyfKOSVtCndvDjM);
				MJAPorpWThsqfJvHYMAjRKzQxqmI = false;
			}
		}

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "RegisterDeviceNotification", SetLastError = true)]
		private static extern IntPtr ATiqfGhHnbdJUbTEYfUMolICgLJMA(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnregisterDeviceNotification")]
		private static extern bool KaJxoTYxWGusRctKImjauwQdgPSs(IntPtr P_0);
	}

	private const int vyqslcQyqYKzwDQbVJqAeEVpdgNz = 32771;

	private const int GYHzilzJjBaHADdOruLyddcNlsdE = 32772;

	private const int lkxBaPjoNJSdCNlbROtbSqiVPycn = 32768;

	private const int ZLGKodHybvizooAqmjlehctqmCYR = 7;

	private const int iharGiWQMfhMYYMCVApcAFVUiwFDA = 537;

	private Action<EventArgs> EvPOZMAcpRyhYMSqvTRKutiyPFYb;

	private Action<EventArgs> KFzGmXcJnuHPzAhSIZtwXZxUXuDX;

	private Action<EventArgs> DzZIMbkHefeVwVXUNFQFjAjhItIx;

	private Action<OyupQaMYRgpbewATwEdBKrofApgMA, mAHtYnpeNVBamKjhUllLQFoAJljP> uEHTbnbnyZksdkpHxfHLiPngNPfp;

	private IntPtr vVXWWUVGIXECdsXsdxIadaKhZGqD;

	private BrIeclecewcOjyuYbdxoiKjMLOzEA YMbZasrpFeHWMsvuPRaItAqaDBQY;

	private readonly bool uhJOjkezjzuYBSexWCniAhkzqXJu;

	private static gLMOoHNGsFznEIfqattDdCOlttwo rUQcAfcRPmzDCKQtypkuESXcksHVA;

	private BrIeclecewcOjyuYbdxoiKjMLOzEA JoDQyiyXdkNrrRLZHTCjmaTwBUHCA;

	private bool DGKwEziETBhsIaLjZZBNwwvVSqiQ;

	public IntPtr ykTgahhfnIxXLAbmqJgupRCMpTchb => vVXWWUVGIXECdsXsdxIadaKhZGqD;

	event Action<EventArgs> czgJqnWAYNszYaRJoqKfeNAgdBDQ.gmaCsfinnSNSgcZzFLRAQovMBbNtb
	{
		add
		{
			EvPOZMAcpRyhYMSqvTRKutiyPFYb = (Action<EventArgs>)Delegate.Combine(EvPOZMAcpRyhYMSqvTRKutiyPFYb, b);
		}
		remove
		{
			EvPOZMAcpRyhYMSqvTRKutiyPFYb = (Action<EventArgs>)Delegate.Remove(EvPOZMAcpRyhYMSqvTRKutiyPFYb, value2);
		}
	}

	event Action<EventArgs> czgJqnWAYNszYaRJoqKfeNAgdBDQ.iHxpwMdqSdZfYYWFXCRoDBdBxDbk
	{
		add
		{
			KFzGmXcJnuHPzAhSIZtwXZxUXuDX = (Action<EventArgs>)Delegate.Combine(KFzGmXcJnuHPzAhSIZtwXZxUXuDX, b);
		}
		remove
		{
			KFzGmXcJnuHPzAhSIZtwXZxUXuDX = (Action<EventArgs>)Delegate.Remove(KFzGmXcJnuHPzAhSIZtwXZxUXuDX, value2);
		}
	}

	event Action<EventArgs> czgJqnWAYNszYaRJoqKfeNAgdBDQ.KNNykBaJOqZQNkJYijdKVbdlAgzHA
	{
		add
		{
			DzZIMbkHefeVwVXUNFQFjAjhItIx = (Action<EventArgs>)Delegate.Combine(DzZIMbkHefeVwVXUNFQFjAjhItIx, b);
		}
		remove
		{
			DzZIMbkHefeVwVXUNFQFjAjhItIx = (Action<EventArgs>)Delegate.Remove(DzZIMbkHefeVwVXUNFQFjAjhItIx, value2);
		}
	}

	public event Action<OyupQaMYRgpbewATwEdBKrofApgMA, mAHtYnpeNVBamKjhUllLQFoAJljP> JsuSTXPviYcNryTOjrkSPuoRfrde
	{
		add
		{
			uEHTbnbnyZksdkpHxfHLiPngNPfp = (Action<OyupQaMYRgpbewATwEdBKrofApgMA, mAHtYnpeNVBamKjhUllLQFoAJljP>)Delegate.Combine(uEHTbnbnyZksdkpHxfHLiPngNPfp, b);
		}
		remove
		{
			uEHTbnbnyZksdkpHxfHLiPngNPfp = (Action<OyupQaMYRgpbewATwEdBKrofApgMA, mAHtYnpeNVBamKjhUllLQFoAJljP>)Delegate.Remove(uEHTbnbnyZksdkpHxfHLiPngNPfp, value2);
		}
	}

	public xAAARHJpGeNEmXXisDcrWtIrxcCb()
	{
		uhJOjkezjzuYBSexWCniAhkzqXJu = ReInput.editorPlatform != EditorPlatform.None;
		try
		{
			uQyyJFyHZdKewtPIcojOwuJCIEdP();
		}
		catch
		{
			yaicBpTCGUcpCeIqquduijbUPYhQA();
			throw;
		}
	}

	public void yaicBpTCGUcpCeIqquduijbUPYhQA()
	{
		Dispose();
	}

	void czgJqnWAYNszYaRJoqKfeNAgdBDQ.UognTUzPmiXcjpGJjYhpYkMODRCH()
	{
		//ILSpy generated this explicit interface implementation from .override directive in yaicBpTCGUcpCeIqquduijbUPYhQA
		this.yaicBpTCGUcpCeIqquduijbUPYhQA();
	}

	private void uQyyJFyHZdKewtPIcojOwuJCIEdP()
	{
		HtJllRSOyavDtTMdEBdqUTbVkyPm();
		VmGSBdZdMVfIRbUsvDkrzJJIxHrX();
		if (uhJOjkezjzuYBSexWCniAhkzqXJu)
		{
			JoDQyiyXdkNrrRLZHTCjmaTwBUHCA = new BrIeclecewcOjyuYbdxoiKjMLOzEA();
			JoDQyiyXdkNrrRLZHTCjmaTwBUHCA.AlnfUMestYPkBhNwHqnljpYcdWiwB(pslDHtcAulHZMlafninCwcfSNnkCb, true);
		}
	}

	public void Dispose()
	{
		XOQbsPupAVmtDrhTtSiLRRaeGzqd(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void WPpdptnRgFrchNVQpRaAjiUqMDqH()
	{
		try
		{
			XOQbsPupAVmtDrhTtSiLRRaeGzqd(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void XOQbsPupAVmtDrhTtSiLRRaeGzqd(bool P_0)
	{
		if (DGKwEziETBhsIaLjZZBNwwvVSqiQ)
		{
			return;
		}
		if (uhJOjkezjzuYBSexWCniAhkzqXJu)
		{
			ilfmjwEIwXpRBTUTlDZhCsGMuhSr();
			if (JoDQyiyXdkNrrRLZHTCjmaTwBUHCA != null)
			{
				JoDQyiyXdkNrrRLZHTCjmaTwBUHCA.Dispose();
			}
			if (rUQcAfcRPmzDCKQtypkuESXcksHVA != null)
			{
				rUQcAfcRPmzDCKQtypkuESXcksHVA.Dispose();
				rUQcAfcRPmzDCKQtypkuESXcksHVA = null;
			}
		}
		else
		{
			ilfmjwEIwXpRBTUTlDZhCsGMuhSr();
			if (YMbZasrpFeHWMsvuPRaItAqaDBQY != null)
			{
				YMbZasrpFeHWMsvuPRaItAqaDBQY.Dispose();
			}
		}
		DGKwEziETBhsIaLjZZBNwwvVSqiQ = true;
	}

	private void VmGSBdZdMVfIRbUsvDkrzJJIxHrX()
	{
		dXkLmbRedZuwiNgDNudcZteZtSeU.GlxTVooJtngitUWdgAwUDVzvXCAs(vVXWWUVGIXECdsXsdxIadaKhZGqD);
	}

	private void ilfmjwEIwXpRBTUTlDZhCsGMuhSr()
	{
		dXkLmbRedZuwiNgDNudcZteZtSeU.yyBnMVpTsIcBvubjWPMMtbgJHNLbA();
	}

	private void LwNiEaKTlUJQtJqOrWuSdXySIVHA(LEuvDhxKvWdNgdGKNNakDiKtAuJK P_0, OyupQaMYRgpbewATwEdBKrofApgMA P_1, uint P_2, IntPtr P_3)
	{
		if (P_2 != 537)
		{
			return;
		}
		int num = P_1.BcgcvavcJyVTOLDzvcBpomyaAhlN();
		if (P_3 == vVXWWUVGIXECdsXsdxIadaKhZGqD)
		{
			switch (num)
			{
			case 32768:
				EvPOZMAcpRyhYMSqvTRKutiyPFYb?.Invoke(null);
				break;
			case 32772:
				KFzGmXcJnuHPzAhSIZtwXZxUXuDX?.Invoke(null);
				break;
			case 32771:
				DzZIMbkHefeVwVXUNFQFjAjhItIx?.Invoke(null);
				break;
			}
		}
	}

	private void pslDHtcAulHZMlafninCwcfSNnkCb(LEuvDhxKvWdNgdGKNNakDiKtAuJK P_0, OyupQaMYRgpbewATwEdBKrofApgMA P_1, uint P_2, IntPtr P_3)
	{
		if (uhJOjkezjzuYBSexWCniAhkzqXJu && (P_2 == 6 || P_2 == 28))
		{
			mAHtYnpeNVBamKjhUllLQFoAJljP mAHtYnpeNVBamKjhUllLQFoAJljP2 = xUPCxrzhBiksftNMbGxZgbEwrnkFA.TPkcbDHmgXjotoWemYazUtXABBhw(P_1.BcgcvavcJyVTOLDzvcBpomyaAhlN());
			if (mAHtYnpeNVBamKjhUllLQFoAJljP2 != mAHtYnpeNVBamKjhUllLQFoAJljP.None && uEHTbnbnyZksdkpHxfHLiPngNPfp != null)
			{
				uEHTbnbnyZksdkpHxfHLiPngNPfp(P_1, mAHtYnpeNVBamKjhUllLQFoAJljP2);
			}
		}
	}

	private void HtJllRSOyavDtTMdEBdqUTbVkyPm()
	{
		if (rUQcAfcRPmzDCKQtypkuESXcksHVA == null)
		{
			rUQcAfcRPmzDCKQtypkuESXcksHVA = new gLMOoHNGsFznEIfqattDdCOlttwo("RewiredWDMWindow", true, qAKyPvCIhruKlKPblDDJTfYcFhejA);
			if (rUQcAfcRPmzDCKQtypkuESXcksHVA.rppGPLxYnLFBssYNqQeZkqQHicYw == IntPtr.Zero)
			{
				throw new Exception("Error creating window.");
			}
		}
		else
		{
			if (rUQcAfcRPmzDCKQtypkuESXcksHVA.rppGPLxYnLFBssYNqQeZkqQHicYw == IntPtr.Zero)
			{
				throw new Exception("Message window has invalid handle.");
			}
			rUQcAfcRPmzDCKQtypkuESXcksHVA.ZhXXcCPZRRozrAdzDXorfHjSYhfi(qAKyPvCIhruKlKPblDDJTfYcFhejA);
		}
		vVXWWUVGIXECdsXsdxIadaKhZGqD = rUQcAfcRPmzDCKQtypkuESXcksHVA.rppGPLxYnLFBssYNqQeZkqQHicYw;
	}

	private IntPtr qAKyPvCIhruKlKPblDDJTfYcFhejA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		LwNiEaKTlUJQtJqOrWuSdXySIVHA(LEuvDhxKvWdNgdGKNNakDiKtAuJK.textmLTcqVwANsHtDDZcjbwEGxLO(P_3), OyupQaMYRgpbewATwEdBKrofApgMA.TtPyHegXoNSjezueuvsQIWYTljSQ(P_2), P_1, P_0);
		return IntPtr.Zero;
	}
}
