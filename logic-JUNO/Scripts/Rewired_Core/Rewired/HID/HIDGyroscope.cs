using System;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class vtzcSrpFfJyGOzeflTywQsXIQuML : FwfVunHdepBCPjnxolyzjMjQIqwcb
		{
			private int tbiqGYaOKZNsZBiGNCUiXbjhehqI;

			private int YwWnYYwlsbNLnJQkYeygzTHqlWiV;

			public float[] TcZnWnCDmcLpOyyruhgTYFYZtabR => (hduUspHviDUBuOOrZDjpiODZaJYRA as CjGDfzRurvwhJBBsMPxxQcBVRASw).horsXOsEHHSTLjtyxjaoDkVtzAXF;

			public RingBuffer<OhjuMudkxrxhcFUaaGLQSPzGFPF> xFVyGqYTcbAdmTikcZFUxWqTggpr => (hduUspHviDUBuOOrZDjpiODZaJYRA as CjGDfzRurvwhJBBsMPxxQcBVRASw).jhEABJxbRbVnEWHbnllZpDyXIdvO;

			public vtzcSrpFfJyGOzeflTywQsXIQuML(UpdateLoopSetting P_0, int P_1, int P_2)
			{
				tbiqGYaOKZNsZBiGNCUiXbjhehqI = P_1;
				YwWnYYwlsbNLnJQkYeygzTHqlWiV = P_2;
				sBTgxlWjumZDCwCaMMxUSfdrGQZW(P_0, qcGrWSXykJOJPXGMLtHSRcnxTCTp);
			}

			public virtual void NqFYrjPJloTtERIaSRTdiYSULmoO(UpdateLoopType P_0)
			{
				base.tHWUBQPxgtVgesSIHRaudMBBdKzfA(P_0);
				(hduUspHviDUBuOOrZDjpiODZaJYRA as CjGDfzRurvwhJBBsMPxxQcBVRASw).XQOmODtonFTXLQSKnqFSiLxtsSrJ();
			}

			public void uxERTBVNVAMswXItPePrIkOUZJOBA(float[] P_0, float P_1)
			{
				for (int i = 0; i < bPXpBLGvvGQnkOZdZAVqLPMAldAu.Length; i++)
				{
					(bPXpBLGvvGQnkOZdZAVqLPMAldAu[i] as CjGDfzRurvwhJBBsMPxxQcBVRASw).VPcOVfEkpZIMnGYJXDXBDMwqHltw(P_0, P_1);
				}
			}

			private vXlvtpgwbYXdIiFwJYmfVQDFFroL qcGrWSXykJOJPXGMLtHSRcnxTCTp(UpdateLoopType P_0)
			{
				return new CjGDfzRurvwhJBBsMPxxQcBVRASw(P_0, tbiqGYaOKZNsZBiGNCUiXbjhehqI, YwWnYYwlsbNLnJQkYeygzTHqlWiV);
			}
		}

		internal class CjGDfzRurvwhJBBsMPxxQcBVRASw : vXlvtpgwbYXdIiFwJYmfVQDFFroL
		{
			[Serializable]
			private sealed class UevUEKHfqxgReJFxSMrqYJsZnAeFA
			{
				public static readonly UevUEKHfqxgReJFxSMrqYJsZnAeFA _003C_003E9 = new UevUEKHfqxgReJFxSMrqYJsZnAeFA();

				public static Func<OhjuMudkxrxhcFUaaGLQSPzGFPF> _003C_003E9__5_0;

				internal OhjuMudkxrxhcFUaaGLQSPzGFPF wiQFiqwWbqfyXXoKsfXdPsurwPap()
				{
					return new OhjuMudkxrxhcFUaaGLQSPzGFPF();
				}
			}

			private float[] aeCArZTIwUxrRGzIiWVcheUynyPs;

			public float[] horsXOsEHHSTLjtyxjaoDkVtzAXF;

			public RingBuffer<OhjuMudkxrxhcFUaaGLQSPzGFPF> jhEABJxbRbVnEWHbnllZpDyXIdvO;

			private RingBuffer<OhjuMudkxrxhcFUaaGLQSPzGFPF> ypqeiNgGxuVlLMbHAPTwYAsYESdz;

			private ObjectPool<OhjuMudkxrxhcFUaaGLQSPzGFPF> uqwEYNOQGweqwtTKUstfnUOnhBQO;

			public CjGDfzRurvwhJBBsMPxxQcBVRASw(UpdateLoopType P_0, int P_1, int P_2)
				: base(P_0)
			{
				horsXOsEHHSTLjtyxjaoDkVtzAXF = new float[P_1];
				aeCArZTIwUxrRGzIiWVcheUynyPs = new float[P_1];
				jhEABJxbRbVnEWHbnllZpDyXIdvO = new RingBuffer<OhjuMudkxrxhcFUaaGLQSPzGFPF>(P_2);
				ypqeiNgGxuVlLMbHAPTwYAsYESdz = new RingBuffer<OhjuMudkxrxhcFUaaGLQSPzGFPF>(P_2);
				uqwEYNOQGweqwtTKUstfnUOnhBQO = new ObjectPool<OhjuMudkxrxhcFUaaGLQSPzGFPF>(P_2, UevUEKHfqxgReJFxSMrqYJsZnAeFA._003C_003E9.wiQFiqwWbqfyXXoKsfXdPsurwPap);
			}

			public void XQOmODtonFTXLQSKnqFSiLxtsSrJ()
			{
				for (int i = 0; i < aeCArZTIwUxrRGzIiWVcheUynyPs.Length; i++)
				{
					horsXOsEHHSTLjtyxjaoDkVtzAXF[i] = aeCArZTIwUxrRGzIiWVcheUynyPs[i];
					aeCArZTIwUxrRGzIiWVcheUynyPs[i] = 0f;
				}
				CollectionTools.Clear(uqwEYNOQGweqwtTKUstfnUOnhBQO, jhEABJxbRbVnEWHbnllZpDyXIdvO);
				int count = ypqeiNgGxuVlLMbHAPTwYAsYESdz.Count;
				for (int j = 0; j < count; j++)
				{
					OhjuMudkxrxhcFUaaGLQSPzGFPF ohjuMudkxrxhcFUaaGLQSPzGFPF = uqwEYNOQGweqwtTKUstfnUOnhBQO.Get();
					ohjuMudkxrxhcFUaaGLQSPzGFPF.IyEWJQtkcmDifqFLmnUdzuVybKEl(ypqeiNgGxuVlLMbHAPTwYAsYESdz[j]);
					CollectionTools.Enqueue(uqwEYNOQGweqwtTKUstfnUOnhBQO, jhEABJxbRbVnEWHbnllZpDyXIdvO, ohjuMudkxrxhcFUaaGLQSPzGFPF, out var _);
				}
				CollectionTools.Clear(uqwEYNOQGweqwtTKUstfnUOnhBQO, ypqeiNgGxuVlLMbHAPTwYAsYESdz);
			}

			public void VPcOVfEkpZIMnGYJXDXBDMwqHltw(float[] P_0, float P_1)
			{
				for (int i = 0; i < aeCArZTIwUxrRGzIiWVcheUynyPs.Length; i++)
				{
					aeCArZTIwUxrRGzIiWVcheUynyPs[i] += P_0[i];
				}
				OhjuMudkxrxhcFUaaGLQSPzGFPF ohjuMudkxrxhcFUaaGLQSPzGFPF = uqwEYNOQGweqwtTKUstfnUOnhBQO.Get();
				ohjuMudkxrxhcFUaaGLQSPzGFPF.aeGKdfmafiqUFzpaQJptRyyMhQbv(P_0, P_1);
				CollectionTools.Enqueue(uqwEYNOQGweqwtTKUstfnUOnhBQO, ypqeiNgGxuVlLMbHAPTwYAsYESdz, ohjuMudkxrxhcFUaaGLQSPzGFPF, out var _);
			}

			public virtual void UDUrQljEMbawxCydyPEysxXzVbTrA()
			{
				Array.Clear(horsXOsEHHSTLjtyxjaoDkVtzAXF, 0, horsXOsEHHSTLjtyxjaoDkVtzAXF.Length);
				CollectionTools.Clear(uqwEYNOQGweqwtTKUstfnUOnhBQO, ypqeiNgGxuVlLMbHAPTwYAsYESdz);
				CollectionTools.Clear(uqwEYNOQGweqwtTKUstfnUOnhBQO, jhEABJxbRbVnEWHbnllZpDyXIdvO);
			}
		}

		public class OhjuMudkxrxhcFUaaGLQSPzGFPF
		{
			public Vector3 stvAgpvMmtnJlkoKkQdWZaBKzoMT;

			public float QrPZYcYyTMgjTnwjmdfpJlOyqPXW;

			public OhjuMudkxrxhcFUaaGLQSPzGFPF()
			{
			}

			public OhjuMudkxrxhcFUaaGLQSPzGFPF(float[] P_0, float P_1)
			{
				aeGKdfmafiqUFzpaQJptRyyMhQbv(P_0, P_1);
			}

			public void aeGKdfmafiqUFzpaQJptRyyMhQbv(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				for (int i = 0; i < num; i++)
				{
					stvAgpvMmtnJlkoKkQdWZaBKzoMT[i] = P_0[i];
				}
				QrPZYcYyTMgjTnwjmdfpJlOyqPXW = P_1;
			}

			public void IyEWJQtkcmDifqFLmnUdzuVybKEl(OhjuMudkxrxhcFUaaGLQSPzGFPF P_0)
			{
				stvAgpvMmtnJlkoKkQdWZaBKzoMT = P_0.stvAgpvMmtnJlkoKkQdWZaBKzoMT;
				QrPZYcYyTMgjTnwjmdfpJlOyqPXW = P_0.QrPZYcYyTMgjTnwjmdfpJlOyqPXW;
			}

			public void ewcZtcYvxbcyuSeKfJtKHuqgivNg(OhjuMudkxrxhcFUaaGLQSPzGFPF P_0)
			{
				stvAgpvMmtnJlkoKkQdWZaBKzoMT = P_0.stvAgpvMmtnJlkoKkQdWZaBKzoMT;
				QrPZYcYyTMgjTnwjmdfpJlOyqPXW = P_0.QrPZYcYyTMgjTnwjmdfpJlOyqPXW;
			}

			public bool kbXgxhWiOXcFPAhpuLtbRBolduni(OhjuMudkxrxhcFUaaGLQSPzGFPF P_0)
			{
				if (QrPZYcYyTMgjTnwjmdfpJlOyqPXW == P_0.QrPZYcYyTMgjTnwjmdfpJlOyqPXW)
				{
					return stvAgpvMmtnJlkoKkQdWZaBKzoMT == P_0.stvAgpvMmtnJlkoKkQdWZaBKzoMT;
				}
				return false;
			}

			public void pdXTSvzzhiBXZhpRTvLwVleOEcBFA()
			{
				stvAgpvMmtnJlkoKkQdWZaBKzoMT.x = 0f;
				stvAgpvMmtnJlkoKkQdWZaBKzoMT.y = 0f;
				stvAgpvMmtnJlkoKkQdWZaBKzoMT.z = 0f;
				QrPZYcYyTMgjTnwjmdfpJlOyqPXW = 0f;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] yfGbblOKGlyaqzkrypTavyNZkawo;

		private readonly float[] DZIYzDHfLBGYpVCOhtjIPDiJwevU;

		private readonly int NBtLFCEdjPixWcJRiHDhAvnfzrvub;

		private readonly int JCHXipmRlWOtSpIqbwXbLSTtamet;

		private readonly Action<byte[], float[]> MnKDTfJaZkXTfFAuhqYpOMzmkcCd;

		private readonly Func<float> yJHCZJlJhxpCgkdIkvoFOYRWicII;

		public float[] rawValue => (dataSet as vtzcSrpFfJyGOzeflTywQsXIQuML).TcZnWnCDmcLpOyyruhgTYFYZtabR;

		public RingBuffer<OhjuMudkxrxhcFUaaGLQSPzGFPF> events => (dataSet as vtzcSrpFfJyGOzeflTywQsXIQuML).xFVyGqYTcbAdmTikcZFUxWqTggpr;

		public HIDGyroscope(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
			: base(new vtzcSrpFfJyGOzeflTywQsXIQuML(P_0, P_3, P_4), P_1, P_2)
		{
			valueLength = P_3;
			MnKDTfJaZkXTfFAuhqYpOMzmkcCd = P_5;
			yJHCZJlJhxpCgkdIkvoFOYRWicII = P_6;
			NBtLFCEdjPixWcJRiHDhAvnfzrvub = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
			JCHXipmRlWOtSpIqbwXbLSTtamet = P_2.dataIndex;
			yfGbblOKGlyaqzkrypTavyNZkawo = new byte[NBtLFCEdjPixWcJRiHDhAvnfzrvub];
			DZIYzDHfLBGYpVCOhtjIPDiJwevU = new float[P_3];
			lastRawValue = new float[P_3];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < NBtLFCEdjPixWcJRiHDhAvnfzrvub; i++)
				{
					yfGbblOKGlyaqzkrypTavyNZkawo[i] = inputReport[JCHXipmRlWOtSpIqbwXbLSTtamet + i];
				}
				if (MnKDTfJaZkXTfFAuhqYpOMzmkcCd != null)
				{
					MnKDTfJaZkXTfFAuhqYpOMzmkcCd(yfGbblOKGlyaqzkrypTavyNZkawo, DZIYzDHfLBGYpVCOhtjIPDiJwevU);
				}
				float num = ((yJHCZJlJhxpCgkdIkvoFOYRWicII != null) ? yJHCZJlJhxpCgkdIkvoFOYRWicII() : 0f);
				(dataSet as vtzcSrpFfJyGOzeflTywQsXIQuML).uxERTBVNVAMswXItPePrIkOUZJOBA(DZIYzDHfLBGYpVCOhtjIPDiJwevU, num);
				for (int j = 0; j < valueLength; j++)
				{
					lastRawValue[j] = DZIYzDHfLBGYpVCOhtjIPDiJwevU[j];
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			float num = ((yJHCZJlJhxpCgkdIkvoFOYRWicII != null) ? yJHCZJlJhxpCgkdIkvoFOYRWicII() : 0f);
			for (int i = 0; i < valueLength; i++)
			{
				DZIYzDHfLBGYpVCOhtjIPDiJwevU[i] = value[i];
			}
			(dataSet as vtzcSrpFfJyGOzeflTywQsXIQuML).uxERTBVNVAMswXItPePrIkOUZJOBA(DZIYzDHfLBGYpVCOhtjIPDiJwevU, num);
			for (int j = 0; j < valueLength; j++)
			{
				lastRawValue[j] = DZIYzDHfLBGYpVCOhtjIPDiJwevU[j];
			}
		}
	}
}
