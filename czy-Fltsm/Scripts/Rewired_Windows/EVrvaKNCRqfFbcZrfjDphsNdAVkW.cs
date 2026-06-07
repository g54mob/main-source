using System;
using Rewired.Utils;

internal class EVrvaKNCRqfFbcZrfjDphsNdAVkW : IDisposable
{
	private readonly GhZlVkTHikiQVkHTKPgKHUKBJNyUb wmyDpdFxGwmQiHHbGOMtCcHkLBZzb;

	private readonly int RCpVzTcOsyNqBipFpPnjMMcdZSTD;

	private long pTrgzriUUKozQcOOmJKtqiHGnGUGA;

	private long TJiCYxYeEmAiyenKtmCQoVbCKQJY;

	private int TFOrkIIsLjmkfEdxjCXxbamQqDXib;

	private bool GVqqmbzvcWsuHclvhqfAreXLCCqaA;

	private uint hQDinCEgfZGuxhKjurJslpNDvoCD;

	private bool UMNvHYycxIeyfqlerjGfDUmLMTql;

	public int dJqyZyVKnNtlGBihYHpVDXEpzCKb => RCpVzTcOsyNqBipFpPnjMMcdZSTD;

	public int sFJitxDeZfWyQiSxfycuMxWgNAwy => TFOrkIIsLjmkfEdxjCXxbamQqDXib;

	public bool aDGETeNZQHbHfDzQiucBRDIaGine => GVqqmbzvcWsuHclvhqfAreXLCCqaA;

	public EVrvaKNCRqfFbcZrfjDphsNdAVkW(int P_0)
	{
		RCpVzTcOsyNqBipFpPnjMMcdZSTD = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		wmyDpdFxGwmQiHHbGOMtCcHkLBZzb = new GhZlVkTHikiQVkHTKPgKHUKBJNyUb(P_0);
	}

	public unsafe int gjslUCCEnAMqHuNZMmckdimSLPxl(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)pTrgzriUUKozQcOOmJKtqiHGnGUGA;
		P_4 = hQDinCEgfZGuxhKjurJslpNDvoCD;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.rVnRAFsWehqlFQbNihQwfOFZQBsiA(P_0, P_1, P_2, (int)pTrgzriUUKozQcOOmJKtqiHGnGUGA);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.rVnRAFsWehqlFQbNihQwfOFZQBsiA(P_0 + num, P_1 - num, P_2 - num);
		}
		mfBrtwvgNJjKuhReahCGcupGEQdPb(num);
		return num;
	}

	public unsafe int wUpwgOobDYKqPCgGCDYVRLMjDVtp(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)pTrgzriUUKozQcOOmJKtqiHGnGUGA;
			P_4 = hQDinCEgfZGuxhKjurJslpNDvoCD;
			return 0;
		}
		return gjslUCCEnAMqHuNZMmckdimSLPxl((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int MjtZbEFSOBZlDrxXrUUGSWHzSFci(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)pTrgzriUUKozQcOOmJKtqiHGnGUGA;
			P_3 = hQDinCEgfZGuxhKjurJslpNDvoCD;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return gjslUCCEnAMqHuNZMmckdimSLPxl(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int qXYtlWwIdZPGzYEaIYsAtrEQdhShA(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return gjslUCCEnAMqHuNZMmckdimSLPxl(P_0, P_1, P_2, out num, out num2);
	}

	public int IwznJhWgMdgiqbmsHLUiuqsVLcjK(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return wUpwgOobDYKqPCgGCDYVRLMjDVtp(P_0, P_1, P_2, out num, out num2);
	}

	public int uRzjPkMqaceheDwJkIzkTVBCZCCCA(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return MjtZbEFSOBZlDrxXrUUGSWHzSFci(P_0, P_1, out num, out num2);
	}

	public unsafe int uRpbkCBHDJkIxhFmgvpLuQTlaVZRb(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || TFOrkIIsLjmkfEdxjCXxbamQqDXib == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > TFOrkIIsLjmkfEdxjCXxbamQqDXib)
		{
			P_2 = TFOrkIIsLjmkfEdxjCXxbamQqDXib;
		}
		int num = wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.dYEOgYKtkAECkwwmJQRJpztnrJSU(P_0, P_1, P_2, (int)TJiCYxYeEmAiyenKtmCQoVbCKQJY);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.dYEOgYKtkAECkwwmJQRJpztnrJSU(P_0 + num, P_1 - num, P_2 - num);
		}
		lEQgUthSaODxLVYdPzhbhFIovuQQ(num);
		return num;
	}

	public unsafe int fExKLKYjIkNlOrFwJbpHibkZnRRYA(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return uRpbkCBHDJkIxhFmgvpLuQTlaVZRb(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int tUtlqmAFuRMsWiTGQKelxXUPajAd(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return uRpbkCBHDJkIxhFmgvpLuQTlaVZRb((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int YQsSuECVzIKxghIXfrgLbgQVBtrEA(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || TFOrkIIsLjmkfEdxjCXxbamQqDXib == 0 || P_3 < 0 || P_3 >= RCpVzTcOsyNqBipFpPnjMMcdZSTD)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > TFOrkIIsLjmkfEdxjCXxbamQqDXib)
		{
			P_2 = TFOrkIIsLjmkfEdxjCXxbamQqDXib;
		}
		int num = wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.dYEOgYKtkAECkwwmJQRJpztnrJSU(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.dYEOgYKtkAECkwwmJQRJpztnrJSU(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int ZhtPSiGsWGenGGBemIlXvjGpYXQN(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return YQsSuECVzIKxghIXfrgLbgQVBtrEA(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int YSUBLbGpmRgAWpjqVmPaXsgrlYEN(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return YQsSuECVzIKxghIXfrgLbgQVBtrEA((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool nEheralvDlrbsDsQudFjTzxuwgGk(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= RCpVzTcOsyNqBipFpPnjMMcdZSTD)
		{
			return false;
		}
		if (P_0 < pTrgzriUUKozQcOOmJKtqiHGnGUGA)
		{
			if (P_1 == hQDinCEgfZGuxhKjurJslpNDvoCD)
			{
				return true;
			}
		}
		else if (P_0 >= pTrgzriUUKozQcOOmJKtqiHGnGUGA)
		{
			if (hQDinCEgfZGuxhKjurJslpNDvoCD == 0)
			{
				return false;
			}
			if (hQDinCEgfZGuxhKjurJslpNDvoCD - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void YpAhaApVQylDyfCmixOFJSdJQtLl()
	{
		pTrgzriUUKozQcOOmJKtqiHGnGUGA = 0L;
		TJiCYxYeEmAiyenKtmCQoVbCKQJY = 0L;
		TFOrkIIsLjmkfEdxjCXxbamQqDXib = 0;
		GVqqmbzvcWsuHclvhqfAreXLCCqaA = false;
		hQDinCEgfZGuxhKjurJslpNDvoCD = 0u;
	}

	private void mfBrtwvgNJjKuhReahCGcupGEQdPb(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)pTrgzriUUKozQcOOmJKtqiHGnGUGA;
		pTrgzriUUKozQcOOmJKtqiHGnGUGA += P_0;
		bool flag = false;
		if (num < TJiCYxYeEmAiyenKtmCQoVbCKQJY)
		{
			if (pTrgzriUUKozQcOOmJKtqiHGnGUGA > TJiCYxYeEmAiyenKtmCQoVbCKQJY)
			{
				flag = true;
			}
		}
		else if (num > TJiCYxYeEmAiyenKtmCQoVbCKQJY)
		{
			if (pTrgzriUUKozQcOOmJKtqiHGnGUGA - RCpVzTcOsyNqBipFpPnjMMcdZSTD > TJiCYxYeEmAiyenKtmCQoVbCKQJY)
			{
				flag = true;
			}
		}
		else if (TFOrkIIsLjmkfEdxjCXxbamQqDXib > 0)
		{
			flag = true;
		}
		if (flag)
		{
			GVqqmbzvcWsuHclvhqfAreXLCCqaA = true;
			TJiCYxYeEmAiyenKtmCQoVbCKQJY = pTrgzriUUKozQcOOmJKtqiHGnGUGA;
			if (TJiCYxYeEmAiyenKtmCQoVbCKQJY >= RCpVzTcOsyNqBipFpPnjMMcdZSTD)
			{
				TJiCYxYeEmAiyenKtmCQoVbCKQJY -= RCpVzTcOsyNqBipFpPnjMMcdZSTD;
			}
		}
		if (pTrgzriUUKozQcOOmJKtqiHGnGUGA >= RCpVzTcOsyNqBipFpPnjMMcdZSTD)
		{
			pTrgzriUUKozQcOOmJKtqiHGnGUGA -= RCpVzTcOsyNqBipFpPnjMMcdZSTD;
			pKFtQGJBUuqGRjCEiIsjUBkkeoId();
		}
		TFOrkIIsLjmkfEdxjCXxbamQqDXib = (int)MathTools.Clamp((long)TFOrkIIsLjmkfEdxjCXxbamQqDXib + (long)P_0, 0L, RCpVzTcOsyNqBipFpPnjMMcdZSTD);
	}

	private void lEQgUthSaODxLVYdPzhbhFIovuQQ(int P_0)
	{
		if (P_0 > 0)
		{
			if (GVqqmbzvcWsuHclvhqfAreXLCCqaA)
			{
				GVqqmbzvcWsuHclvhqfAreXLCCqaA = false;
			}
			TJiCYxYeEmAiyenKtmCQoVbCKQJY += P_0;
			if (TJiCYxYeEmAiyenKtmCQoVbCKQJY >= RCpVzTcOsyNqBipFpPnjMMcdZSTD)
			{
				TJiCYxYeEmAiyenKtmCQoVbCKQJY -= RCpVzTcOsyNqBipFpPnjMMcdZSTD;
			}
			long num = (long)TFOrkIIsLjmkfEdxjCXxbamQqDXib - (long)P_0;
			TFOrkIIsLjmkfEdxjCXxbamQqDXib = (int)((num >= 0) ? num : 0);
		}
	}

	private void pKFtQGJBUuqGRjCEiIsjUBkkeoId()
	{
		if (hQDinCEgfZGuxhKjurJslpNDvoCD == uint.MaxValue)
		{
			hQDinCEgfZGuxhKjurJslpNDvoCD = 0u;
		}
		else
		{
			hQDinCEgfZGuxhKjurJslpNDvoCD++;
		}
	}

	public void Dispose()
	{
		vQJBLJiSHJKCTMdIMpIGHdIQkJdEA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void CqgQyzQhVWYgbOBvespXToHxSLpe()
	{
		try
		{
			vQJBLJiSHJKCTMdIMpIGHdIQkJdEA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void vQJBLJiSHJKCTMdIMpIGHdIQkJdEA(bool P_0)
	{
		if (!UMNvHYycxIeyfqlerjGfDUmLMTql)
		{
			if (P_0 && wmyDpdFxGwmQiHHbGOMtCcHkLBZzb != null)
			{
				wmyDpdFxGwmQiHHbGOMtCcHkLBZzb.Dispose();
			}
			UMNvHYycxIeyfqlerjGfDUmLMTql = true;
		}
	}
}
