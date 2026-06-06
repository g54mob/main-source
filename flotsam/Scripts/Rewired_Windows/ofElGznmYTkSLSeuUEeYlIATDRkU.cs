using System;
using Rewired.Utils.Classes.Data;

internal class ofElGznmYTkSLSeuUEeYlIATDRkU : OYzieseEeYXDrIqXsZAdwVmBBsCg
{
	public readonly float[] LWJBMyDpMAXWrlkvxBnTSFsUyyMq;

	public double LbHTlWjNFLMADCRJPHnMNcjnPMIx;

	public readonly int SdkQPDfSBwcaRnDuTdNBcCRmopjgA;

	private readonly byte[] wkExAoApVoEjdqHMqeJbSqZbgXjw;

	private readonly int qhlTsZLuFmULyqnfzbEPRyMNSQPN;

	private readonly int kQyqJDcRtefahGFyzhivtgnSwmqt;

	private readonly Action<byte[], float[]> EaOwTtJRilujlmOmWIpEdGjgDkBxA;

	public ofElGznmYTkSLSeuUEeYlIATDRkU(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		SdkQPDfSBwcaRnDuTdNBcCRmopjgA = P_2;
		EaOwTtJRilujlmOmWIpEdGjgDkBxA = P_3;
		qhlTsZLuFmULyqnfzbEPRyMNSQPN = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		kQyqJDcRtefahGFyzhivtgnSwmqt = P_1.dataIndex;
		wkExAoApVoEjdqHMqeJbSqZbgXjw = new byte[qhlTsZLuFmULyqnfzbEPRyMNSQPN];
		LWJBMyDpMAXWrlkvxBnTSFsUyyMq = new float[P_2];
	}

	public virtual void YvvjfSlBnUjAbAMtCezbEnLbjYAG(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == wVMsnOmodjAbsSEDwjTEwlMnMPQg)
		{
			LbHTlWjNFLMADCRJPHnMNcjnPMIx = P_1;
			for (int i = 0; i < qhlTsZLuFmULyqnfzbEPRyMNSQPN; i++)
			{
				wkExAoApVoEjdqHMqeJbSqZbgXjw[i] = P_0[kQyqJDcRtefahGFyzhivtgnSwmqt + i];
			}
			if (EaOwTtJRilujlmOmWIpEdGjgDkBxA != null)
			{
				EaOwTtJRilujlmOmWIpEdGjgDkBxA(wkExAoApVoEjdqHMqeJbSqZbgXjw, LWJBMyDpMAXWrlkvxBnTSFsUyyMq);
			}
		}
	}

	public void qNmcnsYhAceKcKJbuMISSbXQcFuKA(float[] P_0, double P_1)
	{
		LbHTlWjNFLMADCRJPHnMNcjnPMIx = P_1;
		for (int i = 0; i < SdkQPDfSBwcaRnDuTdNBcCRmopjgA; i++)
		{
			LWJBMyDpMAXWrlkvxBnTSFsUyyMq[i] = P_0[i];
		}
	}
}
