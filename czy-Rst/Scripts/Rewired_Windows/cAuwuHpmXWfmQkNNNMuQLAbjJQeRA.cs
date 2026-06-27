using System;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class cAuwuHpmXWfmQkNNNMuQLAbjJQeRA : kbKSDIvuMQdJtiYApSbKaAFKfgWJA
{
	internal class XOQgUvcesRUaTmAQSWQstupaUpwWA : dAQmXhGphruPEKaQJAKzcuDaTHWH
	{
		private int PsXRkUrOBPbpUhorePgeEhJeVXCDc;

		private int sFjCJIffwdzawuHFrGGeROhAplIh;

		public float[] bGmGZpXdUyXNERMXTWDlakBfPbBd => (PhJajzYQjRlnbdFWgdJjwyplducY as wblvlmQmjBZQWaJfOThqstzlbefb).NECSkYjvOXaoGItLAvXgxZGNLUvW;

		public RingBuffer<arYEtUbayhJFeNamRRUDkYiZuhbN> LQeKMuZPnbJcdgrBHbNIZhUngZJk => (PhJajzYQjRlnbdFWgdJjwyplducY as wblvlmQmjBZQWaJfOThqstzlbefb).BdxeBFgeOjnHJMvGAfDXfTEbfYXJb;

		public XOQgUvcesRUaTmAQSWQstupaUpwWA(UpdateLoopSetting P_0, int P_1, int P_2)
		{
			PsXRkUrOBPbpUhorePgeEhJeVXCDc = P_1;
			sFjCJIffwdzawuHFrGGeROhAplIh = P_2;
			UreSkxRMtwEvPNjPdvkMaYZDErrs(P_0, AsxWCEGkdJxrCgCxqrlGbbVHdafk);
		}

		public virtual void vusdZhOTgoNqPiALrfbbYHwoLTIM(UpdateLoopType P_0)
		{
			base.RmlNIIYUllWUfZtfmWPwZidldnJJ(P_0);
			(PhJajzYQjRlnbdFWgdJjwyplducY as wblvlmQmjBZQWaJfOThqstzlbefb).jgzywXmRgLItKfTbCEOUWjNDfNLAA();
		}

		public void SHnFOLECWAOIhyaAyjnrCqumobwi(float[] P_0, float P_1)
		{
			for (int i = 0; i < PakJHFHhqUNsnlMUilMsvasgKvuJ.Length; i++)
			{
				(PakJHFHhqUNsnlMUilMsvasgKvuJ[i] as wblvlmQmjBZQWaJfOThqstzlbefb).taLVblHDePixkxKcshkPlVCUGKRk(P_0, P_1);
			}
		}

		private BIUOnbtijWevVHVJqjwlzzrpSgSdA AsxWCEGkdJxrCgCxqrlGbbVHdafk(UpdateLoopType P_0)
		{
			return new wblvlmQmjBZQWaJfOThqstzlbefb(P_0, PsXRkUrOBPbpUhorePgeEhJeVXCDc, sFjCJIffwdzawuHFrGGeROhAplIh);
		}
	}

	internal class wblvlmQmjBZQWaJfOThqstzlbefb : BIUOnbtijWevVHVJqjwlzzrpSgSdA
	{
		[Serializable]
		private sealed class ynIOIUQQthlTtsnIxTvgtCuxncMh
		{
			public static readonly ynIOIUQQthlTtsnIxTvgtCuxncMh _003C_003E9 = new ynIOIUQQthlTtsnIxTvgtCuxncMh();

			public static Func<arYEtUbayhJFeNamRRUDkYiZuhbN> _003C_003E9__5_0;

			internal arYEtUbayhJFeNamRRUDkYiZuhbN QXbqWchImeIKUsbtPlvthjYPwuUM()
			{
				return new arYEtUbayhJFeNamRRUDkYiZuhbN();
			}
		}

		private float[] GOvexDdKfCkJGCrpgHlyzXujYBfub;

		public float[] NECSkYjvOXaoGItLAvXgxZGNLUvW;

		public RingBuffer<arYEtUbayhJFeNamRRUDkYiZuhbN> BdxeBFgeOjnHJMvGAfDXfTEbfYXJb;

		private RingBuffer<arYEtUbayhJFeNamRRUDkYiZuhbN> HKeXErauxXYkhgjSzictWsEnJbA;

		private ObjectPool<arYEtUbayhJFeNamRRUDkYiZuhbN> IHGHFJNriWxwArHtHdtRifLwSoC;

		public wblvlmQmjBZQWaJfOThqstzlbefb(UpdateLoopType P_0, int P_1, int P_2)
			: base(P_0)
		{
			NECSkYjvOXaoGItLAvXgxZGNLUvW = new float[P_1];
			GOvexDdKfCkJGCrpgHlyzXujYBfub = new float[P_1];
			BdxeBFgeOjnHJMvGAfDXfTEbfYXJb = new RingBuffer<arYEtUbayhJFeNamRRUDkYiZuhbN>(P_2);
			HKeXErauxXYkhgjSzictWsEnJbA = new RingBuffer<arYEtUbayhJFeNamRRUDkYiZuhbN>(P_2);
			IHGHFJNriWxwArHtHdtRifLwSoC = new ObjectPool<arYEtUbayhJFeNamRRUDkYiZuhbN>(P_2, ynIOIUQQthlTtsnIxTvgtCuxncMh._003C_003E9.QXbqWchImeIKUsbtPlvthjYPwuUM);
		}

		public void jgzywXmRgLItKfTbCEOUWjNDfNLAA()
		{
			for (int i = 0; i < GOvexDdKfCkJGCrpgHlyzXujYBfub.Length; i++)
			{
				NECSkYjvOXaoGItLAvXgxZGNLUvW[i] = GOvexDdKfCkJGCrpgHlyzXujYBfub[i];
				GOvexDdKfCkJGCrpgHlyzXujYBfub[i] = 0f;
			}
			CollectionTools.Clear(IHGHFJNriWxwArHtHdtRifLwSoC, BdxeBFgeOjnHJMvGAfDXfTEbfYXJb);
			int count = HKeXErauxXYkhgjSzictWsEnJbA.Count;
			for (int j = 0; j < count; j++)
			{
				arYEtUbayhJFeNamRRUDkYiZuhbN arYEtUbayhJFeNamRRUDkYiZuhbN2 = IHGHFJNriWxwArHtHdtRifLwSoC.Get();
				arYEtUbayhJFeNamRRUDkYiZuhbN2.kTrkAIaofsfvuBLeTBHxFglQISckA(HKeXErauxXYkhgjSzictWsEnJbA[j]);
				CollectionTools.Enqueue(IHGHFJNriWxwArHtHdtRifLwSoC, BdxeBFgeOjnHJMvGAfDXfTEbfYXJb, arYEtUbayhJFeNamRRUDkYiZuhbN2, out var _);
			}
			CollectionTools.Clear(IHGHFJNriWxwArHtHdtRifLwSoC, HKeXErauxXYkhgjSzictWsEnJbA);
		}

		public void taLVblHDePixkxKcshkPlVCUGKRk(float[] P_0, float P_1)
		{
			for (int i = 0; i < GOvexDdKfCkJGCrpgHlyzXujYBfub.Length; i++)
			{
				GOvexDdKfCkJGCrpgHlyzXujYBfub[i] += P_0[i];
			}
			arYEtUbayhJFeNamRRUDkYiZuhbN arYEtUbayhJFeNamRRUDkYiZuhbN2 = IHGHFJNriWxwArHtHdtRifLwSoC.Get();
			arYEtUbayhJFeNamRRUDkYiZuhbN2.OOrntbnuhuccQUTUfVwrdCzkfuHe(P_0, P_1);
			CollectionTools.Enqueue(IHGHFJNriWxwArHtHdtRifLwSoC, HKeXErauxXYkhgjSzictWsEnJbA, arYEtUbayhJFeNamRRUDkYiZuhbN2, out var _);
		}

		public virtual void iOfIdxmDZrAakTfKXeWyZEhRUAjj()
		{
			Array.Clear(NECSkYjvOXaoGItLAvXgxZGNLUvW, 0, NECSkYjvOXaoGItLAvXgxZGNLUvW.Length);
			CollectionTools.Clear(IHGHFJNriWxwArHtHdtRifLwSoC, HKeXErauxXYkhgjSzictWsEnJbA);
			CollectionTools.Clear(IHGHFJNriWxwArHtHdtRifLwSoC, BdxeBFgeOjnHJMvGAfDXfTEbfYXJb);
		}
	}

	public class arYEtUbayhJFeNamRRUDkYiZuhbN
	{
		public Vector3 IDEGgrKerbltszPxPYPGbtdsLRqgA;

		public float kGcGjoXESWeZAMcMRhPtzqsCrots;

		public arYEtUbayhJFeNamRRUDkYiZuhbN()
		{
		}

		public arYEtUbayhJFeNamRRUDkYiZuhbN(float[] P_0, float P_1)
		{
			OOrntbnuhuccQUTUfVwrdCzkfuHe(P_0, P_1);
		}

		public void OOrntbnuhuccQUTUfVwrdCzkfuHe(float[] P_0, float P_1)
		{
			int num = MathTools.Min(P_0.Length, 3);
			for (int i = 0; i < num; i++)
			{
				IDEGgrKerbltszPxPYPGbtdsLRqgA[i] = P_0[i];
			}
			kGcGjoXESWeZAMcMRhPtzqsCrots = P_1;
		}

		public void kTrkAIaofsfvuBLeTBHxFglQISckA(arYEtUbayhJFeNamRRUDkYiZuhbN P_0)
		{
			IDEGgrKerbltszPxPYPGbtdsLRqgA = P_0.IDEGgrKerbltszPxPYPGbtdsLRqgA;
			kGcGjoXESWeZAMcMRhPtzqsCrots = P_0.kGcGjoXESWeZAMcMRhPtzqsCrots;
		}

		public void GLNzByJnybKxznFbCfnSvHQUMRtv(arYEtUbayhJFeNamRRUDkYiZuhbN P_0)
		{
			IDEGgrKerbltszPxPYPGbtdsLRqgA = P_0.IDEGgrKerbltszPxPYPGbtdsLRqgA;
			kGcGjoXESWeZAMcMRhPtzqsCrots = P_0.kGcGjoXESWeZAMcMRhPtzqsCrots;
		}

		public bool WqoNyxXavVOSEjpWLHhjjOIFGGVU(arYEtUbayhJFeNamRRUDkYiZuhbN P_0)
		{
			if (kGcGjoXESWeZAMcMRhPtzqsCrots == P_0.kGcGjoXESWeZAMcMRhPtzqsCrots)
			{
				return IDEGgrKerbltszPxPYPGbtdsLRqgA == P_0.IDEGgrKerbltszPxPYPGbtdsLRqgA;
			}
			return false;
		}

		public void NNgQqlijiyboMQKeglmwvaOgFUhJ()
		{
			IDEGgrKerbltszPxPYPGbtdsLRqgA.x = 0f;
			IDEGgrKerbltszPxPYPGbtdsLRqgA.y = 0f;
			IDEGgrKerbltszPxPYPGbtdsLRqgA.z = 0f;
			kGcGjoXESWeZAMcMRhPtzqsCrots = 0f;
		}
	}

	public double bBzXhlxNkByrjMTqZDmjoImrEHvu;

	public readonly float[] IVCIwqzCZCRIMBSpxbQzdmcskYFN;

	public readonly int pneJdEjqeOMHpSHlCbWHFwyXNOGC;

	private readonly byte[] QbzEhxdTTziMfmYEFbveELzdnTGLc;

	private readonly float[] rkxvANOxINcJwchxKRUYhAGhkZDU;

	private readonly int bMCFBQZwcXNlVeeDTzYzDHDJUAJF;

	private readonly int dsqsHhxpcAZvZETjEdjxrbOJFEGh;

	private readonly Action<byte[], float[]> ycvuRdYoUkpdcoKpYQQzkDuUoFcM;

	private readonly Func<float> QFyNAXkKAbsDxBJhXaJPeohebJakA;

	public float[] NKyhjzEpAZtHNcjqwLDpmKcEdGoA => (tTYtBEpDoxXoEnilidxSDCnYOlNGb as XOQgUvcesRUaTmAQSWQstupaUpwWA).bGmGZpXdUyXNERMXTWDlakBfPbBd;

	public RingBuffer<arYEtUbayhJFeNamRRUDkYiZuhbN> jAaKjjHKnrIKIhusFAEDraeMOtzLA => (tTYtBEpDoxXoEnilidxSDCnYOlNGb as XOQgUvcesRUaTmAQSWQstupaUpwWA).LQeKMuZPnbJcdgrBHbNIZhUngZJk;

	public cAuwuHpmXWfmQkNNNMuQLAbjJQeRA(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
		: base(new XOQgUvcesRUaTmAQSWQstupaUpwWA(P_0, P_3, P_4), P_1, P_2)
	{
		pneJdEjqeOMHpSHlCbWHFwyXNOGC = P_3;
		ycvuRdYoUkpdcoKpYQQzkDuUoFcM = P_5;
		QFyNAXkKAbsDxBJhXaJPeohebJakA = P_6;
		bMCFBQZwcXNlVeeDTzYzDHDJUAJF = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
		dsqsHhxpcAZvZETjEdjxrbOJFEGh = P_2.dataIndex;
		QbzEhxdTTziMfmYEFbveELzdnTGLc = new byte[bMCFBQZwcXNlVeeDTzYzDHDJUAJF];
		rkxvANOxINcJwchxKRUYhAGhkZDU = new float[P_3];
		IVCIwqzCZCRIMBSpxbQzdmcskYFN = new float[P_3];
	}

	public virtual void uSuWFnmbrwBJVcpcAVlGNcMzIcmiA(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == gijfZOkdrxcTAgIIOZwUzEqukUux)
		{
			bBzXhlxNkByrjMTqZDmjoImrEHvu = P_1;
			for (int i = 0; i < bMCFBQZwcXNlVeeDTzYzDHDJUAJF; i++)
			{
				QbzEhxdTTziMfmYEFbveELzdnTGLc[i] = P_0[dsqsHhxpcAZvZETjEdjxrbOJFEGh + i];
			}
			if (ycvuRdYoUkpdcoKpYQQzkDuUoFcM != null)
			{
				ycvuRdYoUkpdcoKpYQQzkDuUoFcM(QbzEhxdTTziMfmYEFbveELzdnTGLc, rkxvANOxINcJwchxKRUYhAGhkZDU);
			}
			float num = ((QFyNAXkKAbsDxBJhXaJPeohebJakA != null) ? QFyNAXkKAbsDxBJhXaJPeohebJakA() : 0f);
			(tTYtBEpDoxXoEnilidxSDCnYOlNGb as XOQgUvcesRUaTmAQSWQstupaUpwWA).SHnFOLECWAOIhyaAyjnrCqumobwi(rkxvANOxINcJwchxKRUYhAGhkZDU, num);
			for (int j = 0; j < pneJdEjqeOMHpSHlCbWHFwyXNOGC; j++)
			{
				IVCIwqzCZCRIMBSpxbQzdmcskYFN[j] = rkxvANOxINcJwchxKRUYhAGhkZDU[j];
			}
		}
	}

	public void AdqsLQhMddHatWTLqrBbiRaLSego(float[] P_0, double P_1)
	{
		bBzXhlxNkByrjMTqZDmjoImrEHvu = P_1;
		float num = ((QFyNAXkKAbsDxBJhXaJPeohebJakA != null) ? QFyNAXkKAbsDxBJhXaJPeohebJakA() : 0f);
		for (int i = 0; i < pneJdEjqeOMHpSHlCbWHFwyXNOGC; i++)
		{
			rkxvANOxINcJwchxKRUYhAGhkZDU[i] = P_0[i];
		}
		(tTYtBEpDoxXoEnilidxSDCnYOlNGb as XOQgUvcesRUaTmAQSWQstupaUpwWA).SHnFOLECWAOIhyaAyjnrCqumobwi(rkxvANOxINcJwchxKRUYhAGhkZDU, num);
		for (int j = 0; j < pneJdEjqeOMHpSHlCbWHFwyXNOGC; j++)
		{
			IVCIwqzCZCRIMBSpxbQzdmcskYFN[j] = rkxvANOxINcJwchxKRUYhAGhkZDU[j];
		}
	}
}
