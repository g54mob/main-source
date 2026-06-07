using System;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class wiBPGDvFUUBIavEWhuSIVMNwIKCkA : qxdcWgtTGIdIFQJOLHcSnfzTeCoD
{
	internal class NXrhJxaqtBAIbuiTwJaydQBrjlCT : jBzjDzGEyzPSeuWRzXabxxblkXgR
	{
		private int VooZMvtSKDTgzYktQSshupbSXEae;

		private int cyEkvGvIgtCJCkMEJpawFKVFJngFB;

		public float[] xSHfbbFqqcgddjxLrriZhzWsJRnk => (NvmbBthWcFYNBnJRYEjtrnHiskOFA as emYOUtCAhbZlmCaMJZpvzfTeRbYw).VcdaJOzuTJRWimpImczieasCIMHs;

		public RingBuffer<omfOYSthvfxFOzvrfcgXtYNKrtBD> RRJGpsaLyfdnTxGKrzZSNAiaWFbeA => (NvmbBthWcFYNBnJRYEjtrnHiskOFA as emYOUtCAhbZlmCaMJZpvzfTeRbYw).DjKizNeANvhIpJiFidxTGEiwShvk;

		public NXrhJxaqtBAIbuiTwJaydQBrjlCT(UpdateLoopSetting P_0, int P_1, int P_2)
		{
			VooZMvtSKDTgzYktQSshupbSXEae = P_1;
			cyEkvGvIgtCJCkMEJpawFKVFJngFB = P_2;
			QOBaJdBLmgYVdtMEPcKQhndUNrFx(P_0, ERSIhGCceZgPceOeUNBURkfKIxRxA);
		}

		public virtual void xiXEKzJOlgotpbKQXXPtIVOloHkab(UpdateLoopType P_0)
		{
			base.LqABoUHGobSkNRnkWEeiWGNaplzFA(P_0);
			(NvmbBthWcFYNBnJRYEjtrnHiskOFA as emYOUtCAhbZlmCaMJZpvzfTeRbYw).xbIDXDeGlXZTeJNsuscUVVnKVwpL();
		}

		public void QWMgoJUIVOGaDOXTIGRrGBEtqiOcA(float[] P_0, float P_1)
		{
			for (int i = 0; i < BfLEqZVYfCqbZTVBQPDqmaOhFAKgA.Length; i++)
			{
				(BfLEqZVYfCqbZTVBQPDqmaOhFAKgA[i] as emYOUtCAhbZlmCaMJZpvzfTeRbYw).vfeFkxZcfBmAARxtGSZVqycVYflH(P_0, P_1);
			}
		}

		private XvdCdlnqQLDnfbKIpIlhoHeUqiZA ERSIhGCceZgPceOeUNBURkfKIxRxA(UpdateLoopType P_0)
		{
			return new emYOUtCAhbZlmCaMJZpvzfTeRbYw(P_0, VooZMvtSKDTgzYktQSshupbSXEae, cyEkvGvIgtCJCkMEJpawFKVFJngFB);
		}
	}

	internal class emYOUtCAhbZlmCaMJZpvzfTeRbYw : XvdCdlnqQLDnfbKIpIlhoHeUqiZA
	{
		[Serializable]
		private sealed class gunbnMHEejjXXvABLRtqWsaidzcPA
		{
			public static readonly gunbnMHEejjXXvABLRtqWsaidzcPA _003C_003E9 = new gunbnMHEejjXXvABLRtqWsaidzcPA();

			public static Func<omfOYSthvfxFOzvrfcgXtYNKrtBD> _003C_003E9__5_0;

			internal omfOYSthvfxFOzvrfcgXtYNKrtBD MqMzHkpPhaNqoSokrCVxmXeWImaBA()
			{
				return new omfOYSthvfxFOzvrfcgXtYNKrtBD();
			}
		}

		private float[] OnMMZHMjeYnhaZBybFNkWdITQZFs;

		public float[] VcdaJOzuTJRWimpImczieasCIMHs;

		public RingBuffer<omfOYSthvfxFOzvrfcgXtYNKrtBD> DjKizNeANvhIpJiFidxTGEiwShvk;

		private RingBuffer<omfOYSthvfxFOzvrfcgXtYNKrtBD> QDqPNBlQhmvpoXZvBKRcxqwvXvdM;

		private ObjectPool<omfOYSthvfxFOzvrfcgXtYNKrtBD> MEyNpHBxWoDwLylmZilrSqSOAaMp;

		public emYOUtCAhbZlmCaMJZpvzfTeRbYw(UpdateLoopType P_0, int P_1, int P_2)
			: base(P_0)
		{
			VcdaJOzuTJRWimpImczieasCIMHs = new float[P_1];
			OnMMZHMjeYnhaZBybFNkWdITQZFs = new float[P_1];
			DjKizNeANvhIpJiFidxTGEiwShvk = new RingBuffer<omfOYSthvfxFOzvrfcgXtYNKrtBD>(P_2);
			QDqPNBlQhmvpoXZvBKRcxqwvXvdM = new RingBuffer<omfOYSthvfxFOzvrfcgXtYNKrtBD>(P_2);
			MEyNpHBxWoDwLylmZilrSqSOAaMp = new ObjectPool<omfOYSthvfxFOzvrfcgXtYNKrtBD>(P_2, gunbnMHEejjXXvABLRtqWsaidzcPA._003C_003E9.MqMzHkpPhaNqoSokrCVxmXeWImaBA);
		}

		public void xbIDXDeGlXZTeJNsuscUVVnKVwpL()
		{
			for (int i = 0; i < OnMMZHMjeYnhaZBybFNkWdITQZFs.Length; i++)
			{
				VcdaJOzuTJRWimpImczieasCIMHs[i] = OnMMZHMjeYnhaZBybFNkWdITQZFs[i];
				OnMMZHMjeYnhaZBybFNkWdITQZFs[i] = 0f;
			}
			CollectionTools.Clear(MEyNpHBxWoDwLylmZilrSqSOAaMp, DjKizNeANvhIpJiFidxTGEiwShvk);
			int count = QDqPNBlQhmvpoXZvBKRcxqwvXvdM.Count;
			for (int j = 0; j < count; j++)
			{
				omfOYSthvfxFOzvrfcgXtYNKrtBD omfOYSthvfxFOzvrfcgXtYNKrtBD2 = MEyNpHBxWoDwLylmZilrSqSOAaMp.Get();
				omfOYSthvfxFOzvrfcgXtYNKrtBD2.mREfcAcEsaPdCvBrxIvxCSFTAMYS(QDqPNBlQhmvpoXZvBKRcxqwvXvdM[j]);
				CollectionTools.Enqueue(MEyNpHBxWoDwLylmZilrSqSOAaMp, DjKizNeANvhIpJiFidxTGEiwShvk, omfOYSthvfxFOzvrfcgXtYNKrtBD2, out var _);
			}
			CollectionTools.Clear(MEyNpHBxWoDwLylmZilrSqSOAaMp, QDqPNBlQhmvpoXZvBKRcxqwvXvdM);
		}

		public void vfeFkxZcfBmAARxtGSZVqycVYflH(float[] P_0, float P_1)
		{
			for (int i = 0; i < OnMMZHMjeYnhaZBybFNkWdITQZFs.Length; i++)
			{
				OnMMZHMjeYnhaZBybFNkWdITQZFs[i] += P_0[i];
			}
			omfOYSthvfxFOzvrfcgXtYNKrtBD omfOYSthvfxFOzvrfcgXtYNKrtBD2 = MEyNpHBxWoDwLylmZilrSqSOAaMp.Get();
			omfOYSthvfxFOzvrfcgXtYNKrtBD2.UPEQSztDvqQEugMOXdvfbiqbyprHA(P_0, P_1);
			CollectionTools.Enqueue(MEyNpHBxWoDwLylmZilrSqSOAaMp, QDqPNBlQhmvpoXZvBKRcxqwvXvdM, omfOYSthvfxFOzvrfcgXtYNKrtBD2, out var _);
		}

		public virtual void gQEIvzmOKptwCxtLhvKiULXOsETS()
		{
			Array.Clear(VcdaJOzuTJRWimpImczieasCIMHs, 0, VcdaJOzuTJRWimpImczieasCIMHs.Length);
			CollectionTools.Clear(MEyNpHBxWoDwLylmZilrSqSOAaMp, QDqPNBlQhmvpoXZvBKRcxqwvXvdM);
			CollectionTools.Clear(MEyNpHBxWoDwLylmZilrSqSOAaMp, DjKizNeANvhIpJiFidxTGEiwShvk);
		}
	}

	public class omfOYSthvfxFOzvrfcgXtYNKrtBD
	{
		public Vector3 OZrLUbmVszNAYtdqpGvGeqRxwPIu;

		public float eGTwdyVsRArxyevZfnHlkMWJcZXd;

		public omfOYSthvfxFOzvrfcgXtYNKrtBD()
		{
		}

		public omfOYSthvfxFOzvrfcgXtYNKrtBD(float[] P_0, float P_1)
		{
			UPEQSztDvqQEugMOXdvfbiqbyprHA(P_0, P_1);
		}

		public void UPEQSztDvqQEugMOXdvfbiqbyprHA(float[] P_0, float P_1)
		{
			int num = MathTools.Min(P_0.Length, 3);
			for (int i = 0; i < num; i++)
			{
				OZrLUbmVszNAYtdqpGvGeqRxwPIu[i] = P_0[i];
			}
			eGTwdyVsRArxyevZfnHlkMWJcZXd = P_1;
		}

		public void mREfcAcEsaPdCvBrxIvxCSFTAMYS(omfOYSthvfxFOzvrfcgXtYNKrtBD P_0)
		{
			OZrLUbmVszNAYtdqpGvGeqRxwPIu = P_0.OZrLUbmVszNAYtdqpGvGeqRxwPIu;
			eGTwdyVsRArxyevZfnHlkMWJcZXd = P_0.eGTwdyVsRArxyevZfnHlkMWJcZXd;
		}

		public void MWyBswHIhddgNaTmiFFSpqeDPHXgb(omfOYSthvfxFOzvrfcgXtYNKrtBD P_0)
		{
			OZrLUbmVszNAYtdqpGvGeqRxwPIu = P_0.OZrLUbmVszNAYtdqpGvGeqRxwPIu;
			eGTwdyVsRArxyevZfnHlkMWJcZXd = P_0.eGTwdyVsRArxyevZfnHlkMWJcZXd;
		}

		public bool SHlTreXqNEoisVRraBbVaeWMYdhA(omfOYSthvfxFOzvrfcgXtYNKrtBD P_0)
		{
			if (eGTwdyVsRArxyevZfnHlkMWJcZXd == P_0.eGTwdyVsRArxyevZfnHlkMWJcZXd)
			{
				return OZrLUbmVszNAYtdqpGvGeqRxwPIu == P_0.OZrLUbmVszNAYtdqpGvGeqRxwPIu;
			}
			return false;
		}

		public void PSDgdjcFbytZcuCfQSDamskpADXFA()
		{
			OZrLUbmVszNAYtdqpGvGeqRxwPIu.x = 0f;
			OZrLUbmVszNAYtdqpGvGeqRxwPIu.y = 0f;
			OZrLUbmVszNAYtdqpGvGeqRxwPIu.z = 0f;
			eGTwdyVsRArxyevZfnHlkMWJcZXd = 0f;
		}
	}

	public double hFGbgpclrXJYTpovfWhnvbMazXJtA;

	public readonly float[] YdfXPmxeKAeSmthiRajhqEYfaKlq;

	public readonly int frLLuhnhnCBcDbsEacDVQKWOYPyiA;

	private readonly byte[] SnQGbzBfSpIyTeiRxMBqOIJgMBcO;

	private readonly float[] dyKCSFbODBySARAygkbUDacDoPvmc;

	private readonly int pStpuOBxdZlxdQRzpjHvKHpYnAln;

	private readonly int tVVFLffWfQGtjciYecVrkoBKqHaEb;

	private readonly Action<byte[], float[]> wbMicbEBWkNuOSyJgcarhUKXNGVc;

	private readonly Func<float> UVpAJubTjijTzYaxutRnoJzHTWS;

	public float[] TOPmGrQoeSxFlEKkKDvFEfkvXbyBA => (xhzAsCpGpdQIgBasAlNWJfZBlnjV as NXrhJxaqtBAIbuiTwJaydQBrjlCT).xSHfbbFqqcgddjxLrriZhzWsJRnk;

	public RingBuffer<omfOYSthvfxFOzvrfcgXtYNKrtBD> ryJMmdZbgbmdaGLxdebJrFWVdjZP => (xhzAsCpGpdQIgBasAlNWJfZBlnjV as NXrhJxaqtBAIbuiTwJaydQBrjlCT).RRJGpsaLyfdnTxGKrzZSNAiaWFbeA;

	public wiBPGDvFUUBIavEWhuSIVMNwIKCkA(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
		: base(new NXrhJxaqtBAIbuiTwJaydQBrjlCT(P_0, P_3, P_4), P_1, P_2)
	{
		frLLuhnhnCBcDbsEacDVQKWOYPyiA = P_3;
		wbMicbEBWkNuOSyJgcarhUKXNGVc = P_5;
		UVpAJubTjijTzYaxutRnoJzHTWS = P_6;
		pStpuOBxdZlxdQRzpjHvKHpYnAln = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
		tVVFLffWfQGtjciYecVrkoBKqHaEb = P_2.dataIndex;
		SnQGbzBfSpIyTeiRxMBqOIJgMBcO = new byte[pStpuOBxdZlxdQRzpjHvKHpYnAln];
		dyKCSFbODBySARAygkbUDacDoPvmc = new float[P_3];
		YdfXPmxeKAeSmthiRajhqEYfaKlq = new float[P_3];
	}

	public virtual void cILwpvcYeqjtpCengaFGDAcqxwUiA(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == wVMsnOmodjAbsSEDwjTEwlMnMPQg)
		{
			hFGbgpclrXJYTpovfWhnvbMazXJtA = P_1;
			for (int i = 0; i < pStpuOBxdZlxdQRzpjHvKHpYnAln; i++)
			{
				SnQGbzBfSpIyTeiRxMBqOIJgMBcO[i] = P_0[tVVFLffWfQGtjciYecVrkoBKqHaEb + i];
			}
			if (wbMicbEBWkNuOSyJgcarhUKXNGVc != null)
			{
				wbMicbEBWkNuOSyJgcarhUKXNGVc(SnQGbzBfSpIyTeiRxMBqOIJgMBcO, dyKCSFbODBySARAygkbUDacDoPvmc);
			}
			float num = ((UVpAJubTjijTzYaxutRnoJzHTWS != null) ? UVpAJubTjijTzYaxutRnoJzHTWS() : 0f);
			(xhzAsCpGpdQIgBasAlNWJfZBlnjV as NXrhJxaqtBAIbuiTwJaydQBrjlCT).QWMgoJUIVOGaDOXTIGRrGBEtqiOcA(dyKCSFbODBySARAygkbUDacDoPvmc, num);
			for (int j = 0; j < frLLuhnhnCBcDbsEacDVQKWOYPyiA; j++)
			{
				YdfXPmxeKAeSmthiRajhqEYfaKlq[j] = dyKCSFbODBySARAygkbUDacDoPvmc[j];
			}
		}
	}

	public void IBPmFEjuFxEqXwMDOrwhlOqAyQGe(float[] P_0, double P_1)
	{
		hFGbgpclrXJYTpovfWhnvbMazXJtA = P_1;
		float num = ((UVpAJubTjijTzYaxutRnoJzHTWS != null) ? UVpAJubTjijTzYaxutRnoJzHTWS() : 0f);
		for (int i = 0; i < frLLuhnhnCBcDbsEacDVQKWOYPyiA; i++)
		{
			dyKCSFbODBySARAygkbUDacDoPvmc[i] = P_0[i];
		}
		(xhzAsCpGpdQIgBasAlNWJfZBlnjV as NXrhJxaqtBAIbuiTwJaydQBrjlCT).QWMgoJUIVOGaDOXTIGRrGBEtqiOcA(dyKCSFbODBySARAygkbUDacDoPvmc, num);
		for (int j = 0; j < frLLuhnhnCBcDbsEacDVQKWOYPyiA; j++)
		{
			YdfXPmxeKAeSmthiRajhqEYfaKlq[j] = dyKCSFbODBySARAygkbUDacDoPvmc[j];
		}
	}
}
