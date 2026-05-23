using System;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class mtYfxDYuHHPxAtRRwphKvfBUCHvHA : yUsCYQUTKXfAziQMWZaMRZpbFnDUA
{
	internal class HJsRPpPxwYhxDmHElPNqFLPHdedX : tNgftXjxdmdbYoAEmNllTxNXQMJd
	{
		private int VDvgbOjGNOPaCUMzDrjyOUhewUTHA;

		private int cMNBXUQpfsiauYcFSPLsqtBnRsLS;

		public float[] nISLIfaHlnkEDplYmnNZFeGMTWAn => (XpezbdWbKDqlToORBWfDHVIJbpJA as mXZuVzdbyeYMEMgZIQNdFPLSsKdF).JMihjSSoEQshUsjNnhIeAQamPBcjA;

		public RingBuffer<kHgxaIUQumRSmtlkwfNRJICwIywm> LXYTAooxlaYdzILjqcEEkewQISMd => (XpezbdWbKDqlToORBWfDHVIJbpJA as mXZuVzdbyeYMEMgZIQNdFPLSsKdF).NxPmUZPNUiMCLTrMvvWVeUuKdVGP;

		public HJsRPpPxwYhxDmHElPNqFLPHdedX(UpdateLoopSetting P_0, int P_1, int P_2)
		{
			VDvgbOjGNOPaCUMzDrjyOUhewUTHA = P_1;
			cMNBXUQpfsiauYcFSPLsqtBnRsLS = P_2;
			SEKhtnwRxfkjZpxPSpFWRxtyabsJ(P_0, SCXfVIlZxMEsQUXzLguEUBfiGuoP);
		}

		public virtual void buWadUzyQvYBbCPmIydDjYHNIDPd(UpdateLoopType P_0)
		{
			base.RLKbMjjwmVevrltZNUscDwIeiYD(P_0);
			(XpezbdWbKDqlToORBWfDHVIJbpJA as mXZuVzdbyeYMEMgZIQNdFPLSsKdF).rtHKzPLAaGfeALBdpQRUbrzyFAWN();
		}

		public void GFXdCRhBQJVDlYKQBBcxkdSPHfvY(float[] P_0, float P_1)
		{
			for (int i = 0; i < BMEQLBwXoVSBpTpQFaNqCyIZHFbI.Length; i++)
			{
				(BMEQLBwXoVSBpTpQFaNqCyIZHFbI[i] as mXZuVzdbyeYMEMgZIQNdFPLSsKdF).xmlAivmXcMremBOgXuiXCrozLwAi(P_0, P_1);
			}
		}

		private XkgccxJWbXIyJRpJHKhlwSDErzFCA SCXfVIlZxMEsQUXzLguEUBfiGuoP(UpdateLoopType P_0)
		{
			return new mXZuVzdbyeYMEMgZIQNdFPLSsKdF(P_0, VDvgbOjGNOPaCUMzDrjyOUhewUTHA, cMNBXUQpfsiauYcFSPLsqtBnRsLS);
		}
	}

	internal class mXZuVzdbyeYMEMgZIQNdFPLSsKdF : XkgccxJWbXIyJRpJHKhlwSDErzFCA
	{
		[Serializable]
		private sealed class gcFnMzhtaoBhUcEAEwiSByYgaJg
		{
			public static readonly gcFnMzhtaoBhUcEAEwiSByYgaJg _003C_003E9 = new gcFnMzhtaoBhUcEAEwiSByYgaJg();

			public static Func<kHgxaIUQumRSmtlkwfNRJICwIywm> _003C_003E9__5_0;

			internal kHgxaIUQumRSmtlkwfNRJICwIywm IUVploECwzHbUAtbkmwfSAyavyJF()
			{
				return new kHgxaIUQumRSmtlkwfNRJICwIywm();
			}
		}

		private float[] MeNmqTtanBxGSZidqYiccYYtAquk;

		public float[] JMihjSSoEQshUsjNnhIeAQamPBcjA;

		public RingBuffer<kHgxaIUQumRSmtlkwfNRJICwIywm> NxPmUZPNUiMCLTrMvvWVeUuKdVGP;

		private RingBuffer<kHgxaIUQumRSmtlkwfNRJICwIywm> WKvvgRSnqdWaYHdiQHmcVliDGaKEA;

		private ObjectPool<kHgxaIUQumRSmtlkwfNRJICwIywm> AknBrFmULpDBliYhOQyzeQPujAlF;

		public mXZuVzdbyeYMEMgZIQNdFPLSsKdF(UpdateLoopType P_0, int P_1, int P_2)
			: base(P_0)
		{
			JMihjSSoEQshUsjNnhIeAQamPBcjA = new float[P_1];
			MeNmqTtanBxGSZidqYiccYYtAquk = new float[P_1];
			NxPmUZPNUiMCLTrMvvWVeUuKdVGP = new RingBuffer<kHgxaIUQumRSmtlkwfNRJICwIywm>(P_2);
			WKvvgRSnqdWaYHdiQHmcVliDGaKEA = new RingBuffer<kHgxaIUQumRSmtlkwfNRJICwIywm>(P_2);
			AknBrFmULpDBliYhOQyzeQPujAlF = new ObjectPool<kHgxaIUQumRSmtlkwfNRJICwIywm>(P_2, gcFnMzhtaoBhUcEAEwiSByYgaJg._003C_003E9.IUVploECwzHbUAtbkmwfSAyavyJF);
		}

		public void rtHKzPLAaGfeALBdpQRUbrzyFAWN()
		{
			for (int i = 0; i < MeNmqTtanBxGSZidqYiccYYtAquk.Length; i++)
			{
				JMihjSSoEQshUsjNnhIeAQamPBcjA[i] = MeNmqTtanBxGSZidqYiccYYtAquk[i];
				MeNmqTtanBxGSZidqYiccYYtAquk[i] = 0f;
			}
			CollectionTools.Clear(AknBrFmULpDBliYhOQyzeQPujAlF, NxPmUZPNUiMCLTrMvvWVeUuKdVGP);
			int count = WKvvgRSnqdWaYHdiQHmcVliDGaKEA.Count;
			for (int j = 0; j < count; j++)
			{
				kHgxaIUQumRSmtlkwfNRJICwIywm kHgxaIUQumRSmtlkwfNRJICwIywm2 = AknBrFmULpDBliYhOQyzeQPujAlF.Get();
				kHgxaIUQumRSmtlkwfNRJICwIywm2.oFPYZAJVlzigwhXiwBYzglRbEDly(WKvvgRSnqdWaYHdiQHmcVliDGaKEA[j]);
				CollectionTools.Enqueue(AknBrFmULpDBliYhOQyzeQPujAlF, NxPmUZPNUiMCLTrMvvWVeUuKdVGP, kHgxaIUQumRSmtlkwfNRJICwIywm2, out var _);
			}
			CollectionTools.Clear(AknBrFmULpDBliYhOQyzeQPujAlF, WKvvgRSnqdWaYHdiQHmcVliDGaKEA);
		}

		public void xmlAivmXcMremBOgXuiXCrozLwAi(float[] P_0, float P_1)
		{
			for (int i = 0; i < MeNmqTtanBxGSZidqYiccYYtAquk.Length; i++)
			{
				MeNmqTtanBxGSZidqYiccYYtAquk[i] += P_0[i];
			}
			kHgxaIUQumRSmtlkwfNRJICwIywm kHgxaIUQumRSmtlkwfNRJICwIywm2 = AknBrFmULpDBliYhOQyzeQPujAlF.Get();
			kHgxaIUQumRSmtlkwfNRJICwIywm2.GZNoAxEBififEaRNUAIlMNiTtySt(P_0, P_1);
			CollectionTools.Enqueue(AknBrFmULpDBliYhOQyzeQPujAlF, WKvvgRSnqdWaYHdiQHmcVliDGaKEA, kHgxaIUQumRSmtlkwfNRJICwIywm2, out var _);
		}

		public virtual void uYNdRfNwTgFJkhHCgoxgqtLamTmo()
		{
			Array.Clear(JMihjSSoEQshUsjNnhIeAQamPBcjA, 0, JMihjSSoEQshUsjNnhIeAQamPBcjA.Length);
			CollectionTools.Clear(AknBrFmULpDBliYhOQyzeQPujAlF, WKvvgRSnqdWaYHdiQHmcVliDGaKEA);
			CollectionTools.Clear(AknBrFmULpDBliYhOQyzeQPujAlF, NxPmUZPNUiMCLTrMvvWVeUuKdVGP);
		}
	}

	public class kHgxaIUQumRSmtlkwfNRJICwIywm
	{
		public Vector3 CqaRbtXIhghqiCpvcMOWeYBPOEnjA;

		public float unCFBcqDYBEiWsYKeCdlMEUrtnuJ;

		public kHgxaIUQumRSmtlkwfNRJICwIywm()
		{
		}

		public kHgxaIUQumRSmtlkwfNRJICwIywm(float[] P_0, float P_1)
		{
			GZNoAxEBififEaRNUAIlMNiTtySt(P_0, P_1);
		}

		public void GZNoAxEBififEaRNUAIlMNiTtySt(float[] P_0, float P_1)
		{
			int num = MathTools.Min(P_0.Length, 3);
			for (int i = 0; i < num; i++)
			{
				CqaRbtXIhghqiCpvcMOWeYBPOEnjA[i] = P_0[i];
			}
			unCFBcqDYBEiWsYKeCdlMEUrtnuJ = P_1;
		}

		public void oFPYZAJVlzigwhXiwBYzglRbEDly(kHgxaIUQumRSmtlkwfNRJICwIywm P_0)
		{
			CqaRbtXIhghqiCpvcMOWeYBPOEnjA = P_0.CqaRbtXIhghqiCpvcMOWeYBPOEnjA;
			unCFBcqDYBEiWsYKeCdlMEUrtnuJ = P_0.unCFBcqDYBEiWsYKeCdlMEUrtnuJ;
		}

		public void SNjkYkeReiiTpVzdprmEKAejNIoy(kHgxaIUQumRSmtlkwfNRJICwIywm P_0)
		{
			CqaRbtXIhghqiCpvcMOWeYBPOEnjA = P_0.CqaRbtXIhghqiCpvcMOWeYBPOEnjA;
			unCFBcqDYBEiWsYKeCdlMEUrtnuJ = P_0.unCFBcqDYBEiWsYKeCdlMEUrtnuJ;
		}

		public bool UJUapzCgfWQZIZDSafotuCqktNIDA(kHgxaIUQumRSmtlkwfNRJICwIywm P_0)
		{
			if (unCFBcqDYBEiWsYKeCdlMEUrtnuJ == P_0.unCFBcqDYBEiWsYKeCdlMEUrtnuJ)
			{
				return CqaRbtXIhghqiCpvcMOWeYBPOEnjA == P_0.CqaRbtXIhghqiCpvcMOWeYBPOEnjA;
			}
			return false;
		}

		public void RZSAPxVHedekQhkoFGmstCoPeMkYA()
		{
			CqaRbtXIhghqiCpvcMOWeYBPOEnjA.x = 0f;
			CqaRbtXIhghqiCpvcMOWeYBPOEnjA.y = 0f;
			CqaRbtXIhghqiCpvcMOWeYBPOEnjA.z = 0f;
			unCFBcqDYBEiWsYKeCdlMEUrtnuJ = 0f;
		}
	}

	public double lNiKpFAaEJzvfgessIlIFOiOEqbB;

	public readonly float[] YYoVpcWXVNRRChGlABPzCEGREFYAA;

	public readonly int tfEKDzEReXNMloUDbgGNuvSyQnPK;

	private readonly byte[] MxBQgxqJXqTLpyUUqfeqqNVWqQFq;

	private readonly float[] feZiHVpMjSbtaAzZvSLUAkPGUFSC;

	private readonly int bZcKiEgwaCYbFAuoouvlyRfwFkWk;

	private readonly int vYWfdpUiPLUbHmDBzirpADFgUaRI;

	private readonly Action<byte[], float[]> ewXDMbGhGreeiXWnzBNjRVWtIQhZ;

	private readonly Func<float> CsEARXCZYqRSlcpbuJSNnJJVhQhGb;

	public float[] ZCKmYdzExBcrTEdbLYeNBVgDsXZH => (zxoDSUYMiiUxCVMjPQiWlaLfTiQX as HJsRPpPxwYhxDmHElPNqFLPHdedX).nISLIfaHlnkEDplYmnNZFeGMTWAn;

	public RingBuffer<kHgxaIUQumRSmtlkwfNRJICwIywm> bRYYalqPvoZZKKsccsFDDVGzVieM => (zxoDSUYMiiUxCVMjPQiWlaLfTiQX as HJsRPpPxwYhxDmHElPNqFLPHdedX).LXYTAooxlaYdzILjqcEEkewQISMd;

	public mtYfxDYuHHPxAtRRwphKvfBUCHvHA(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
		: base(new HJsRPpPxwYhxDmHElPNqFLPHdedX(P_0, P_3, P_4), P_1, P_2)
	{
		tfEKDzEReXNMloUDbgGNuvSyQnPK = P_3;
		ewXDMbGhGreeiXWnzBNjRVWtIQhZ = P_5;
		CsEARXCZYqRSlcpbuJSNnJJVhQhGb = P_6;
		bZcKiEgwaCYbFAuoouvlyRfwFkWk = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
		vYWfdpUiPLUbHmDBzirpADFgUaRI = P_2.dataIndex;
		MxBQgxqJXqTLpyUUqfeqqNVWqQFq = new byte[bZcKiEgwaCYbFAuoouvlyRfwFkWk];
		feZiHVpMjSbtaAzZvSLUAkPGUFSC = new float[P_3];
		YYoVpcWXVNRRChGlABPzCEGREFYAA = new float[P_3];
	}

	public virtual void swCRrhJhNdOhZOHkrkHMiCwMDrlS(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == ojLWWKRknmirMQCCbmKCWZUFqDzy)
		{
			lNiKpFAaEJzvfgessIlIFOiOEqbB = P_1;
			for (int i = 0; i < bZcKiEgwaCYbFAuoouvlyRfwFkWk; i++)
			{
				MxBQgxqJXqTLpyUUqfeqqNVWqQFq[i] = P_0[vYWfdpUiPLUbHmDBzirpADFgUaRI + i];
			}
			if (ewXDMbGhGreeiXWnzBNjRVWtIQhZ != null)
			{
				ewXDMbGhGreeiXWnzBNjRVWtIQhZ(MxBQgxqJXqTLpyUUqfeqqNVWqQFq, feZiHVpMjSbtaAzZvSLUAkPGUFSC);
			}
			float num = ((CsEARXCZYqRSlcpbuJSNnJJVhQhGb != null) ? CsEARXCZYqRSlcpbuJSNnJJVhQhGb() : 0f);
			(zxoDSUYMiiUxCVMjPQiWlaLfTiQX as HJsRPpPxwYhxDmHElPNqFLPHdedX).GFXdCRhBQJVDlYKQBBcxkdSPHfvY(feZiHVpMjSbtaAzZvSLUAkPGUFSC, num);
			for (int j = 0; j < tfEKDzEReXNMloUDbgGNuvSyQnPK; j++)
			{
				YYoVpcWXVNRRChGlABPzCEGREFYAA[j] = feZiHVpMjSbtaAzZvSLUAkPGUFSC[j];
			}
		}
	}

	public void CVEdQIAIrwirrtoXRyIzuRImenlzA(float[] P_0, double P_1)
	{
		lNiKpFAaEJzvfgessIlIFOiOEqbB = P_1;
		float num = ((CsEARXCZYqRSlcpbuJSNnJJVhQhGb != null) ? CsEARXCZYqRSlcpbuJSNnJJVhQhGb() : 0f);
		for (int i = 0; i < tfEKDzEReXNMloUDbgGNuvSyQnPK; i++)
		{
			feZiHVpMjSbtaAzZvSLUAkPGUFSC[i] = P_0[i];
		}
		(zxoDSUYMiiUxCVMjPQiWlaLfTiQX as HJsRPpPxwYhxDmHElPNqFLPHdedX).GFXdCRhBQJVDlYKQBBcxkdSPHfvY(feZiHVpMjSbtaAzZvSLUAkPGUFSC, num);
		for (int j = 0; j < tfEKDzEReXNMloUDbgGNuvSyQnPK; j++)
		{
			YYoVpcWXVNRRChGlABPzCEGREFYAA[j] = feZiHVpMjSbtaAzZvSLUAkPGUFSC[j];
		}
	}
}
