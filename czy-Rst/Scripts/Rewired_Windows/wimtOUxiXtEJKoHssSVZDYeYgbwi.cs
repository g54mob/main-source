using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class wimtOUxiXtEJKoHssSVZDYeYgbwi : IDisposable
{
	private class wFylOMsDblldTyKzsudQknicnPvb
	{
		public int NpsuFJLipiVlcQIJugWNgtOmbtqOA;

		public int DcAAtBTccwjKWsHPdErrFDfdthQT;

		public uint yDSbSGbsgMSpFhgaKGFCxYlmtiWKA;

		public object aMmHhUyzDtrGDXjvjIFuIgEugoEu;

		public void jOWeGjktBcplXiRacmiaRqoLHJcVb(int P_0, int P_1, uint P_2, object P_3)
		{
			NpsuFJLipiVlcQIJugWNgtOmbtqOA = P_0;
			DcAAtBTccwjKWsHPdErrFDfdthQT = P_1;
			yDSbSGbsgMSpFhgaKGFCxYlmtiWKA = P_2;
			aMmHhUyzDtrGDXjvjIFuIgEugoEu = P_3;
		}

		public void eJFWVlpEKREPvNGnIwbDenSlJLwA()
		{
			aMmHhUyzDtrGDXjvjIFuIgEugoEu = null;
		}
	}

	[Serializable]
	private sealed class VCiSlPTiyWERvHkMjwpQExTIHnucA
	{
		public static readonly VCiSlPTiyWERvHkMjwpQExTIHnucA _003C_003E9 = new VCiSlPTiyWERvHkMjwpQExTIHnucA();

		public static Func<wFylOMsDblldTyKzsudQknicnPvb> _003C_003E9__6_0;

		public static Action<wFylOMsDblldTyKzsudQknicnPvb> _003C_003E9__6_1;

		internal wFylOMsDblldTyKzsudQknicnPvb riuSHZFmFLgfgfeELPnlThvcavoSA()
		{
			return new wFylOMsDblldTyKzsudQknicnPvb();
		}

		internal void pUKFapDdzmuRJrOANrLlVMPhftcoA(wFylOMsDblldTyKzsudQknicnPvb P_0)
		{
			P_0.eJFWVlpEKREPvNGnIwbDenSlJLwA();
		}
	}

	private AmYESGfNIwJpRvEsPUpxsahyQJMqA lGCdakajzFOycyeTvACqqpcCoCNAA;

	private ObjectPool<wFylOMsDblldTyKzsudQknicnPvb> PKicczqCrCaYqBpEwxcRNLChcChO;

	private Queue<wFylOMsDblldTyKzsudQknicnPvb> isLvCVohzFWdcDnhuaAiDDnPLBndA;

	private Action<object> QbUAhfIXiLeocZFrLmOaFOMuysurA;

	private bool nRzWWXOfqgiPAHhOCBecvZhqLihs;

	public bool oTqKpCjVmtxICBDUqatysAiyaKoY => vDYBogEpwIQjjXESKCIZOHjORXoe();

	public wimtOUxiXtEJKoHssSVZDYeYgbwi(int P_0, int P_1, Action<object> P_2 = null)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		lGCdakajzFOycyeTvACqqpcCoCNAA = new AmYESGfNIwJpRvEsPUpxsahyQJMqA(P_0);
		PKicczqCrCaYqBpEwxcRNLChcChO = new ObjectPool<wFylOMsDblldTyKzsudQknicnPvb>(P_1, VCiSlPTiyWERvHkMjwpQExTIHnucA._003C_003E9.riuSHZFmFLgfgfeELPnlThvcavoSA, VCiSlPTiyWERvHkMjwpQExTIHnucA._003C_003E9.pUKFapDdzmuRJrOANrLlVMPhftcoA);
		isLvCVohzFWdcDnhuaAiDDnPLBndA = new Queue<wFylOMsDblldTyKzsudQknicnPvb>(P_1);
		QbUAhfIXiLeocZFrLmOaFOMuysurA = P_2;
	}

	public unsafe bool pyzvrKOkuyGeHkjUedUCcFOClElAc(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		if (lGCdakajzFOycyeTvACqqpcCoCNAA.oCXdCWeYmMwkrvMGmtQihsOPTZDuA(P_0, P_1, P_1, out var num, out var num2) < P_1)
		{
			return false;
		}
		wFylOMsDblldTyKzsudQknicnPvb wFylOMsDblldTyKzsudQknicnPvb2 = PKicczqCrCaYqBpEwxcRNLChcChO.Get();
		wFylOMsDblldTyKzsudQknicnPvb2.jOWeGjktBcplXiRacmiaRqoLHJcVb(num, P_1, num2, P_2);
		isLvCVohzFWdcDnhuaAiDDnPLBndA.Enqueue(wFylOMsDblldTyKzsudQknicnPvb2);
		return true;
	}

	public unsafe bool CmVHmwyRGEQLYhCSmKhLVKwgPTbM(byte* P_0, int P_1)
	{
		return pyzvrKOkuyGeHkjUedUCcFOClElAc(P_0, P_1, null);
	}

	public unsafe bool uKbwnOCBObUMSgWPHddecHIzyAgX(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return pyzvrKOkuyGeHkjUedUCcFOClElAc((byte*)(void*)P_0, P_1, P_2);
	}

	public bool bQCxosGeZFZUygToGiGrIOpSxuOo(IntPtr P_0, int P_1)
	{
		return uKbwnOCBObUMSgWPHddecHIzyAgX(P_0, P_1, null);
	}

	public unsafe bool fqYESXGkbzhyDtkKlieMcwaVWiNKA(byte[] P_0, int P_1, object P_2, int P_3 = 0)
	{
		if (P_0 == null || P_1 > P_0.Length)
		{
			return false;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_3 + P_1 > P_0.Length)
		{
			return false;
		}
		fixed (byte* ptr = P_0)
		{
			byte* ptr2 = ptr + P_3;
			return pyzvrKOkuyGeHkjUedUCcFOClElAc(ptr2, P_1, P_2);
		}
	}

	public bool qfLOWqFBnyzFNOoAROqQeVaDKcAr(byte[] P_0, int P_1, int P_2 = 0)
	{
		return fqYESXGkbzhyDtkKlieMcwaVWiNKA(P_0, P_1, null, P_2);
	}

	public unsafe int DaRCOpcrFnoNjZgreirqkgJueXxbA(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		wFylOMsDblldTyKzsudQknicnPvb wFylOMsDblldTyKzsudQknicnPvb2 = rdSZorUadDlxgLrSWPpoNbnOKoig(false);
		if (wFylOMsDblldTyKzsudQknicnPvb2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < wFylOMsDblldTyKzsudQknicnPvb2.DcAAtBTccwjKWsHPdErrFDfdthQT)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = lGCdakajzFOycyeTvACqqpcCoCNAA.GOTaZQAjiKiPKNmKPAULysiQfnFX(P_0, P_1, wFylOMsDblldTyKzsudQknicnPvb2.DcAAtBTccwjKWsHPdErrFDfdthQT, wFylOMsDblldTyKzsudQknicnPvb2.NpsuFJLipiVlcQIJugWNgtOmbtqOA);
		if (num != wFylOMsDblldTyKzsudQknicnPvb2.DcAAtBTccwjKWsHPdErrFDfdthQT)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = wFylOMsDblldTyKzsudQknicnPvb2.aMmHhUyzDtrGDXjvjIFuIgEugoEu;
		return num;
	}

	public unsafe int TRCaCrFCoNistLoHaAUswNKTjflbb(byte* P_0, int P_1)
	{
		object obj;
		return DaRCOpcrFnoNjZgreirqkgJueXxbA(P_0, P_1, out obj);
	}

	public unsafe int NnIPRTadzIUgILPpEHkPjIEXjIqeA(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return DaRCOpcrFnoNjZgreirqkgJueXxbA((byte*)(void*)P_0, P_1, out P_2);
	}

	public int zsTLyxqdJgxGIsqxSzUTbkfzwHJQ(IntPtr P_0, int P_1)
	{
		object obj;
		return NnIPRTadzIUgILPpEHkPjIEXjIqeA(P_0, P_1, out obj);
	}

	public unsafe int XLYsuBAsiuxEibtlQsGleaCEyEPC(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return DaRCOpcrFnoNjZgreirqkgJueXxbA(ptr, P_0.Length, out P_1);
		}
	}

	public int bGNkTFCojRgebgARLmVmveYYdAVH(byte[] P_0)
	{
		object obj;
		return XLYsuBAsiuxEibtlQsGleaCEyEPC(P_0, out obj);
	}

	public int DTCaLLYGkLHulCiefGqafbdMwgKsA()
	{
		return rdSZorUadDlxgLrSWPpoNbnOKoig(false)?.DcAAtBTccwjKWsHPdErrFDfdthQT ?? (-1);
	}

	public unsafe int ZEvGBwpLrlQxUjRDGKIaRrruDrHr(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		wFylOMsDblldTyKzsudQknicnPvb wFylOMsDblldTyKzsudQknicnPvb2 = rdSZorUadDlxgLrSWPpoNbnOKoig(true);
		if (wFylOMsDblldTyKzsudQknicnPvb2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < wFylOMsDblldTyKzsudQknicnPvb2.DcAAtBTccwjKWsHPdErrFDfdthQT)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			bNLpZDzDrbOrhlfUjjvRIutwAiBu(wFylOMsDblldTyKzsudQknicnPvb2, true);
			return -1;
		}
		int num = lGCdakajzFOycyeTvACqqpcCoCNAA.GOTaZQAjiKiPKNmKPAULysiQfnFX(P_0, P_1, wFylOMsDblldTyKzsudQknicnPvb2.DcAAtBTccwjKWsHPdErrFDfdthQT, wFylOMsDblldTyKzsudQknicnPvb2.NpsuFJLipiVlcQIJugWNgtOmbtqOA);
		if (num != wFylOMsDblldTyKzsudQknicnPvb2.DcAAtBTccwjKWsHPdErrFDfdthQT)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			bNLpZDzDrbOrhlfUjjvRIutwAiBu(wFylOMsDblldTyKzsudQknicnPvb2, true);
			return -1;
		}
		P_2 = wFylOMsDblldTyKzsudQknicnPvb2.aMmHhUyzDtrGDXjvjIFuIgEugoEu;
		bNLpZDzDrbOrhlfUjjvRIutwAiBu(wFylOMsDblldTyKzsudQknicnPvb2, false);
		return num;
	}

	public unsafe int rGmwwDcwQAMXSKIkAbepJnQhbbwM(byte* P_0, int P_1)
	{
		object obj;
		return ZEvGBwpLrlQxUjRDGKIaRrruDrHr(P_0, P_1, out obj);
	}

	public unsafe int zzQVbEEHIXnyavrNVGywmBupEBsy(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return ZEvGBwpLrlQxUjRDGKIaRrruDrHr((byte*)(void*)P_0, P_1, out P_2);
	}

	public int WgPNOFbSLECeEURVuuwvWNtIjWQK(IntPtr P_0, int P_1)
	{
		object obj;
		return zzQVbEEHIXnyavrNVGywmBupEBsy(P_0, P_1, out obj);
	}

	public unsafe int dYjeRbDCxmARTOoeUVFVUJBGqDmYA(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return ZEvGBwpLrlQxUjRDGKIaRrruDrHr(ptr, P_0.Length, out P_1);
		}
	}

	public int faRQMKMVgmjjVLeRCJKOZjZzEEhT(byte[] P_0)
	{
		object obj;
		return dYjeRbDCxmARTOoeUVFVUJBGqDmYA(P_0, out obj);
	}

	public void TJgJvpabXHnhrSXAebpngLuBgvEGA()
	{
		lGCdakajzFOycyeTvACqqpcCoCNAA.KnfJVCpXKyvWxPtCUqFHQRpSQozD();
		while (isLvCVohzFWdcDnhuaAiDDnPLBndA.Count > 0)
		{
			bNLpZDzDrbOrhlfUjjvRIutwAiBu(isLvCVohzFWdcDnhuaAiDDnPLBndA.Dequeue(), true);
		}
	}

	private wFylOMsDblldTyKzsudQknicnPvb rdSZorUadDlxgLrSWPpoNbnOKoig(bool P_0)
	{
		while (isLvCVohzFWdcDnhuaAiDDnPLBndA.Count > 0)
		{
			wFylOMsDblldTyKzsudQknicnPvb wFylOMsDblldTyKzsudQknicnPvb2 = (P_0 ? isLvCVohzFWdcDnhuaAiDDnPLBndA.Dequeue() : isLvCVohzFWdcDnhuaAiDDnPLBndA.Peek());
			if (lGCdakajzFOycyeTvACqqpcCoCNAA.xZEUScjOvpTfAfFzOlrzWRMdyOeC(wFylOMsDblldTyKzsudQknicnPvb2.NpsuFJLipiVlcQIJugWNgtOmbtqOA, wFylOMsDblldTyKzsudQknicnPvb2.yDSbSGbsgMSpFhgaKGFCxYlmtiWKA))
			{
				return wFylOMsDblldTyKzsudQknicnPvb2;
			}
			if (!P_0)
			{
				wFylOMsDblldTyKzsudQknicnPvb2 = isLvCVohzFWdcDnhuaAiDDnPLBndA.Dequeue();
			}
			bNLpZDzDrbOrhlfUjjvRIutwAiBu(wFylOMsDblldTyKzsudQknicnPvb2, true);
		}
		return null;
	}

	private bool vDYBogEpwIQjjXESKCIZOHjORXoe()
	{
		return rdSZorUadDlxgLrSWPpoNbnOKoig(false) != null;
	}

	private void bNLpZDzDrbOrhlfUjjvRIutwAiBu(wFylOMsDblldTyKzsudQknicnPvb P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && QbUAhfIXiLeocZFrLmOaFOMuysurA != null && P_0.aMmHhUyzDtrGDXjvjIFuIgEugoEu != null)
			{
				QbUAhfIXiLeocZFrLmOaFOMuysurA(P_0.aMmHhUyzDtrGDXjvjIFuIgEugoEu);
			}
			PKicczqCrCaYqBpEwxcRNLChcChO.Return(P_0);
		}
	}

	public void Dispose()
	{
		WyXYAXWvAhOfmUovexqALLkDCuEFA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void xjYNafpmrjUPpwVcZQFpmNhArkII()
	{
		try
		{
			WyXYAXWvAhOfmUovexqALLkDCuEFA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void WyXYAXWvAhOfmUovexqALLkDCuEFA(bool P_0)
	{
		if (nRzWWXOfqgiPAHhOCBecvZhqLihs)
		{
			return;
		}
		if (P_0)
		{
			TJgJvpabXHnhrSXAebpngLuBgvEGA();
			if (lGCdakajzFOycyeTvACqqpcCoCNAA != null)
			{
				lGCdakajzFOycyeTvACqqpcCoCNAA.Dispose();
			}
		}
		nRzWWXOfqgiPAHhOCBecvZhqLihs = true;
	}

	public static bool XkouKriEeOgWLyButsqUvmHzlxYM(wimtOUxiXtEJKoHssSVZDYeYgbwi P_0, wimtOUxiXtEJKoHssSVZDYeYgbwi P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.lGCdakajzFOycyeTvACqqpcCoCNAA, ref P_1.lGCdakajzFOycyeTvACqqpcCoCNAA);
		MiscTools.Swap(ref P_0.PKicczqCrCaYqBpEwxcRNLChcChO, ref P_1.PKicczqCrCaYqBpEwxcRNLChcChO);
		MiscTools.Swap(ref P_0.isLvCVohzFWdcDnhuaAiDDnPLBndA, ref P_1.isLvCVohzFWdcDnhuaAiDDnPLBndA);
		return true;
	}
}
