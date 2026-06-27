using System;
using Rewired.Utils.Classes.Data;

internal class ghshtHzRELMvoutgmAIqgcgGRfGD : QAOlVgyStIKpRmoWAGbpIzIYHZwjA
{
	public readonly float[] JLwYhuHtTQDoTLjyTSPTHSWTgggN;

	public double RxaAWPlIfNalDsOZdJCMIVDcWhgD;

	public readonly int AxZgiZxWGmEqfZhchlYBXtthfuZc;

	private readonly byte[] gBlcKeJGWikgZcWPQwrhZSvkzHVr;

	private readonly int mEUJrTHyEmxUCIasTmHDSFoKWwjl;

	private readonly int qRZgLTBcyunNXkepLAEruoXPVsUkA;

	private readonly Action<byte[], float[]> IHrsflDizdDpVScfgCVUBGLdmohT;

	public ghshtHzRELMvoutgmAIqgcgGRfGD(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		AxZgiZxWGmEqfZhchlYBXtthfuZc = P_2;
		IHrsflDizdDpVScfgCVUBGLdmohT = P_3;
		mEUJrTHyEmxUCIasTmHDSFoKWwjl = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		qRZgLTBcyunNXkepLAEruoXPVsUkA = P_1.dataIndex;
		gBlcKeJGWikgZcWPQwrhZSvkzHVr = new byte[mEUJrTHyEmxUCIasTmHDSFoKWwjl];
		JLwYhuHtTQDoTLjyTSPTHSWTgggN = new float[P_2];
	}

	public virtual void KlQjSUtWiUVLXiZeeeUpNtdigtaQ(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == gijfZOkdrxcTAgIIOZwUzEqukUux)
		{
			RxaAWPlIfNalDsOZdJCMIVDcWhgD = P_1;
			for (int i = 0; i < mEUJrTHyEmxUCIasTmHDSFoKWwjl; i++)
			{
				gBlcKeJGWikgZcWPQwrhZSvkzHVr[i] = P_0[qRZgLTBcyunNXkepLAEruoXPVsUkA + i];
			}
			if (IHrsflDizdDpVScfgCVUBGLdmohT != null)
			{
				IHrsflDizdDpVScfgCVUBGLdmohT(gBlcKeJGWikgZcWPQwrhZSvkzHVr, JLwYhuHtTQDoTLjyTSPTHSWTgggN);
			}
		}
	}

	public void maFZGeIiRgfyWuucOggEEFpBHRWeb(float[] P_0, double P_1)
	{
		RxaAWPlIfNalDsOZdJCMIVDcWhgD = P_1;
		for (int i = 0; i < AxZgiZxWGmEqfZhchlYBXtthfuZc; i++)
		{
			JLwYhuHtTQDoTLjyTSPTHSWTgggN[i] = P_0[i];
		}
	}
}
