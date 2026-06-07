using System;
using System.Reflection;
using System.Runtime.InteropServices;

[DefaultMember("Item")]
internal class qTyfqlqnMbzFTCITUInZNJHufDpf : IDisposable
{
	private unsafe byte* qpkeAixeLzEtvgvXHwCPreLoibeDA;

	private int bufLZrNUWfRPPExWVqDSVJtjtqpL;

	private bool NKuXtLmcqsquNsrSnjLcHSAKbbRd;

	public unsafe IntPtr mmCXvwJuSTBuyTpDDTiQaPFnAZZDA => (IntPtr)qpkeAixeLzEtvgvXHwCPreLoibeDA;

	public qTyfqlqnMbzFTCITUInZNJHufDpf(int P_0)
	{
		CgdWqmoJZcsnvrHLYlRDOTqnNqHf(P_0);
	}

	public unsafe byte oixWgCJpFPQyAQUQDlNNIGkJEEEN(int P_0)
	{
		if (1 + P_0 > bufLZrNUWfRPPExWVqDSVJtjtqpL || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return qpkeAixeLzEtvgvXHwCPreLoibeDA[P_0];
	}

	public unsafe int jfleYHfGinHxEkIxAvtoFzXblqQN(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= bufLZrNUWfRPPExWVqDSVJtjtqpL)
		{
			return 0;
		}
		if (P_4 >= P_1)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 + P_2 > bufLZrNUWfRPPExWVqDSVJtjtqpL)
		{
			P_2 = bufLZrNUWfRPPExWVqDSVJtjtqpL - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		ESmSCjJeswEbcynDGoFspIzknNDp.QgiSmnFTATPmbtLZOHYSsjyFldqg(qpkeAixeLzEtvgvXHwCPreLoibeDA, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int xZcvHwNXPFVUyKJXFujZBYVPrnPd(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= bufLZrNUWfRPPExWVqDSVJtjtqpL)
		{
			return 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		if (P_2 + P_3 > bufLZrNUWfRPPExWVqDSVJtjtqpL)
		{
			P_2 = bufLZrNUWfRPPExWVqDSVJtjtqpL - P_3;
		}
		ESmSCjJeswEbcynDGoFspIzknNDp.QgiSmnFTATPmbtLZOHYSsjyFldqg(P_0, qpkeAixeLzEtvgvXHwCPreLoibeDA, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe bool CgdWqmoJZcsnvrHLYlRDOTqnNqHf(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (bufLZrNUWfRPPExWVqDSVJtjtqpL == P_0)
		{
			return true;
		}
		mKGNGCSETHwHMKhIAFUhimnOqxcWA();
		if (P_0 == 0)
		{
			return true;
		}
		bufLZrNUWfRPPExWVqDSVJtjtqpL = P_0;
		qpkeAixeLzEtvgvXHwCPreLoibeDA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		YUgVrSkdxcTEfpxVRLQQPuMwyuPD();
		return true;
	}

	public unsafe void YUgVrSkdxcTEfpxVRLQQPuMwyuPD()
	{
		if (bufLZrNUWfRPPExWVqDSVJtjtqpL != 0)
		{
			ESmSCjJeswEbcynDGoFspIzknNDp.fWlIXbwvMDwNiIciRdtBcDcnXauu(qpkeAixeLzEtvgvXHwCPreLoibeDA, bufLZrNUWfRPPExWVqDSVJtjtqpL);
		}
	}

	public unsafe void mKGNGCSETHwHMKhIAFUhimnOqxcWA()
	{
		if (bufLZrNUWfRPPExWVqDSVJtjtqpL == 0)
		{
			return;
		}
		try
		{
			if (qpkeAixeLzEtvgvXHwCPreLoibeDA != null)
			{
				Marshal.FreeHGlobal(mmCXvwJuSTBuyTpDDTiQaPFnAZZDA);
			}
		}
		catch
		{
		}
		qpkeAixeLzEtvgvXHwCPreLoibeDA = null;
		bufLZrNUWfRPPExWVqDSVJtjtqpL = 0;
	}

	public virtual string hudafFAHTdiuupJBSwhWeAIoDhYbA()
	{
		string text = "";
		for (int i = 0; i < bufLZrNUWfRPPExWVqDSVJtjtqpL; i++)
		{
			text = text + oixWgCJpFPQyAQUQDlNNIGkJEEEN(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		GJenOpLjlyVnKFYoKBqaIlVruxtn(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void CmUAqueKQdWlHrQIhmjEkcjdFrwqA()
	{
		try
		{
			GJenOpLjlyVnKFYoKBqaIlVruxtn(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void GJenOpLjlyVnKFYoKBqaIlVruxtn(bool P_0)
	{
		if (!NKuXtLmcqsquNsrSnjLcHSAKbbRd)
		{
			mKGNGCSETHwHMKhIAFUhimnOqxcWA();
			NKuXtLmcqsquNsrSnjLcHSAKbbRd = true;
		}
	}
}
