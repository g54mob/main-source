using System;
using Rewired.Utils;

internal class jHRGOisWsUgSmOfjKIPdpeVWEWMP : IDisposable
{
	private readonly qTyfqlqnMbzFTCITUInZNJHufDpf uNphKrPQnPPpwHmtSBYUiFjqILtu;

	private readonly int pqvnFFmNqqRgQqFmdNXSdSDwARsd;

	private long rqzlkJmUzZIXOWsFCoEHGWDmpjnI;

	private long ufhmgrVdWVzBdCuAzMEJkEJWFwVM;

	private int dDLzCsOTGsiCRKEMwyRSBbvpPuqb;

	private bool UjZAjTiHCkAflhxnFUnwUHqSwhPIB;

	private uint AYvrHrRpDeAfLmSamxFnTfsTZGVS;

	private bool qfcvmvqFzulaByBmWDdgcHrKbfaFA;

	public jHRGOisWsUgSmOfjKIPdpeVWEWMP(int P_0)
	{
		pqvnFFmNqqRgQqFmdNXSdSDwARsd = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		uNphKrPQnPPpwHmtSBYUiFjqILtu = new qTyfqlqnMbzFTCITUInZNJHufDpf(P_0);
	}

	public unsafe int SkALvHgBunQqGRdvTSwlERkFYych(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)rqzlkJmUzZIXOWsFCoEHGWDmpjnI;
		P_4 = AYvrHrRpDeAfLmSamxFnTfsTZGVS;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = uNphKrPQnPPpwHmtSBYUiFjqILtu.xZcvHwNXPFVUyKJXFujZBYVPrnPd(P_0, P_1, P_2, (int)rqzlkJmUzZIXOWsFCoEHGWDmpjnI);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += uNphKrPQnPPpwHmtSBYUiFjqILtu.xZcvHwNXPFVUyKJXFujZBYVPrnPd(P_0 + num, P_1 - num, P_2 - num);
		}
		rFgHChQGHllhzqnfgjqSPuSyOQRv(num);
		return num;
	}

	public unsafe int PyVFDXHwvKfGlCRHumCLdcVFykKLA(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)rqzlkJmUzZIXOWsFCoEHGWDmpjnI;
			P_3 = AYvrHrRpDeAfLmSamxFnTfsTZGVS;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return SkALvHgBunQqGRdvTSwlERkFYych(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public int yMmBQZGWBVpqbrweHXhWBPBAOKUpA(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return PyVFDXHwvKfGlCRHumCLdcVFykKLA(P_0, P_1, out num, out num2);
	}

	public unsafe int nhfdHlbatnMalWybbaeImCFMhGIJA(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || dDLzCsOTGsiCRKEMwyRSBbvpPuqb == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > dDLzCsOTGsiCRKEMwyRSBbvpPuqb)
		{
			P_2 = dDLzCsOTGsiCRKEMwyRSBbvpPuqb;
		}
		int num = uNphKrPQnPPpwHmtSBYUiFjqILtu.jfleYHfGinHxEkIxAvtoFzXblqQN(P_0, P_1, P_2, (int)ufhmgrVdWVzBdCuAzMEJkEJWFwVM);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += uNphKrPQnPPpwHmtSBYUiFjqILtu.jfleYHfGinHxEkIxAvtoFzXblqQN(P_0 + num, P_1 - num, P_2 - num);
		}
		AVXRftHYPbWPrSfTueoXfiXuaajmA(num);
		return num;
	}

	public unsafe int NYfwANKHSSiTHXNlMjYpTnQKClfHA(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return nhfdHlbatnMalWybbaeImCFMhGIJA(ptr, P_0.Length, P_1);
		}
	}

	private void rFgHChQGHllhzqnfgjqSPuSyOQRv(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)rqzlkJmUzZIXOWsFCoEHGWDmpjnI;
		rqzlkJmUzZIXOWsFCoEHGWDmpjnI += P_0;
		bool flag = false;
		if (num < ufhmgrVdWVzBdCuAzMEJkEJWFwVM)
		{
			if (rqzlkJmUzZIXOWsFCoEHGWDmpjnI > ufhmgrVdWVzBdCuAzMEJkEJWFwVM)
			{
				flag = true;
			}
		}
		else if (num > ufhmgrVdWVzBdCuAzMEJkEJWFwVM)
		{
			if (rqzlkJmUzZIXOWsFCoEHGWDmpjnI - pqvnFFmNqqRgQqFmdNXSdSDwARsd > ufhmgrVdWVzBdCuAzMEJkEJWFwVM)
			{
				flag = true;
			}
		}
		else if (dDLzCsOTGsiCRKEMwyRSBbvpPuqb > 0)
		{
			flag = true;
		}
		if (flag)
		{
			UjZAjTiHCkAflhxnFUnwUHqSwhPIB = true;
			ufhmgrVdWVzBdCuAzMEJkEJWFwVM = rqzlkJmUzZIXOWsFCoEHGWDmpjnI;
			if (ufhmgrVdWVzBdCuAzMEJkEJWFwVM >= pqvnFFmNqqRgQqFmdNXSdSDwARsd)
			{
				ufhmgrVdWVzBdCuAzMEJkEJWFwVM -= pqvnFFmNqqRgQqFmdNXSdSDwARsd;
			}
		}
		if (rqzlkJmUzZIXOWsFCoEHGWDmpjnI >= pqvnFFmNqqRgQqFmdNXSdSDwARsd)
		{
			rqzlkJmUzZIXOWsFCoEHGWDmpjnI -= pqvnFFmNqqRgQqFmdNXSdSDwARsd;
			TyMwFtUtMhsSEYiKhoSzfneUGnIL();
		}
		dDLzCsOTGsiCRKEMwyRSBbvpPuqb = (int)MathTools.Clamp((long)dDLzCsOTGsiCRKEMwyRSBbvpPuqb + (long)P_0, 0L, pqvnFFmNqqRgQqFmdNXSdSDwARsd);
	}

	private void AVXRftHYPbWPrSfTueoXfiXuaajmA(int P_0)
	{
		if (P_0 > 0)
		{
			if (UjZAjTiHCkAflhxnFUnwUHqSwhPIB)
			{
				UjZAjTiHCkAflhxnFUnwUHqSwhPIB = false;
			}
			ufhmgrVdWVzBdCuAzMEJkEJWFwVM += P_0;
			if (ufhmgrVdWVzBdCuAzMEJkEJWFwVM >= pqvnFFmNqqRgQqFmdNXSdSDwARsd)
			{
				ufhmgrVdWVzBdCuAzMEJkEJWFwVM -= pqvnFFmNqqRgQqFmdNXSdSDwARsd;
			}
			long num = (long)dDLzCsOTGsiCRKEMwyRSBbvpPuqb - (long)P_0;
			dDLzCsOTGsiCRKEMwyRSBbvpPuqb = (int)((num >= 0) ? num : 0);
		}
	}

	private void TyMwFtUtMhsSEYiKhoSzfneUGnIL()
	{
		if (AYvrHrRpDeAfLmSamxFnTfsTZGVS == uint.MaxValue)
		{
			AYvrHrRpDeAfLmSamxFnTfsTZGVS = 0u;
		}
		else
		{
			AYvrHrRpDeAfLmSamxFnTfsTZGVS++;
		}
	}

	public void Dispose()
	{
		yQwaeTbIJdnCddflMFxTjVcEbWDU(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void TtDRKmlbGFiaxJCHiceWpoCIFSNI()
	{
		try
		{
			yQwaeTbIJdnCddflMFxTjVcEbWDU(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void yQwaeTbIJdnCddflMFxTjVcEbWDU(bool P_0)
	{
		if (!qfcvmvqFzulaByBmWDdgcHrKbfaFA)
		{
			if (P_0 && uNphKrPQnPPpwHmtSBYUiFjqILtu != null)
			{
				uNphKrPQnPPpwHmtSBYUiFjqILtu.Dispose();
			}
			qfcvmvqFzulaByBmWDdgcHrKbfaFA = true;
		}
	}
}
