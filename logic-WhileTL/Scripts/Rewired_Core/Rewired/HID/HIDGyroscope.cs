using System;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class LmZMsrqfMECLetRMxgyuRMbcHnQP : xmZuwrAGVqILrhjYoPclRrBmGJaQ
		{
			private int IMmIRjEywOmdkNlRaVsRfNmLIWmFA;

			private int UbZGNDWVGLTIrrlcIllKnhavaQrdA;

			public float[] KwkGJdCTWMjNlfHXodMLTqnUYWrpA => (FzeFBTyCrPwRSotVRRvPtdRXkqzA as kSqHtbYoCwfibbHLGXtvnXzzDxOkA).KwkGJdCTWMjNlfHXodMLTqnUYWrpA;

			public ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> aHkzKihXeVOWsSZrFaHzBdYkssGU => (FzeFBTyCrPwRSotVRRvPtdRXkqzA as kSqHtbYoCwfibbHLGXtvnXzzDxOkA).aHkzKihXeVOWsSZrFaHzBdYkssGU;

			public LmZMsrqfMECLetRMxgyuRMbcHnQP(UpdateLoopSetting P_0, int P_1, int P_2)
			{
				IMmIRjEywOmdkNlRaVsRfNmLIWmFA = P_1;
				UbZGNDWVGLTIrrlcIllKnhavaQrdA = P_2;
				yWuIeddROHFQtkpYivZHHCufAJtzA(P_0, FsaffhCFfumqEQwGDkNUTLtpEuUP);
			}

			public override void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
				base.sOLNzBCCbZmFXkMugfndpShqgrUP(P_0);
				(FzeFBTyCrPwRSotVRRvPtdRXkqzA as kSqHtbYoCwfibbHLGXtvnXzzDxOkA).sOLNzBCCbZmFXkMugfndpShqgrUP();
			}

			public void iGkxxHnjjyXtKixgEHtqEpoqePie(float[] P_0, float P_1)
			{
				for (int i = 0; i < OhZfPLeiCZorKUdCTHxwoDcQlqvkA.Length; i++)
				{
					(OhZfPLeiCZorKUdCTHxwoDcQlqvkA[i] as kSqHtbYoCwfibbHLGXtvnXzzDxOkA).xcGlzRmHdbNPfCxucDAifswIrXNL(P_0, P_1);
				}
			}

			private VrVvhtnBXDKMgsvVTUrvWTjnyaqi FsaffhCFfumqEQwGDkNUTLtpEuUP(UpdateLoopType P_0)
			{
				return new kSqHtbYoCwfibbHLGXtvnXzzDxOkA(P_0, IMmIRjEywOmdkNlRaVsRfNmLIWmFA, UbZGNDWVGLTIrrlcIllKnhavaQrdA);
			}
		}

		internal class kSqHtbYoCwfibbHLGXtvnXzzDxOkA : VrVvhtnBXDKMgsvVTUrvWTjnyaqi
		{
			private float[] pBOjGEXcjlHDvqXdFnAUbCYtNQJd;

			public float[] KwkGJdCTWMjNlfHXodMLTqnUYWrpA;

			public ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> aHkzKihXeVOWsSZrFaHzBdYkssGU;

			private ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> AcspxPzKYSIqJboERvPmPfChcpxk;

			public kSqHtbYoCwfibbHLGXtvnXzzDxOkA(UpdateLoopType P_0, int P_1, int P_2)
				: base(P_0)
			{
				KwkGJdCTWMjNlfHXodMLTqnUYWrpA = new float[P_1];
				pBOjGEXcjlHDvqXdFnAUbCYtNQJd = new float[P_1];
				aHkzKihXeVOWsSZrFaHzBdYkssGU = new ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb>(P_2, false, 20);
				AcspxPzKYSIqJboERvPmPfChcpxk = new ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb>(P_2, false, 20);
			}

			public void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
				for (int i = 0; i < pBOjGEXcjlHDvqXdFnAUbCYtNQJd.Length; i++)
				{
					KwkGJdCTWMjNlfHXodMLTqnUYWrpA[i] = pBOjGEXcjlHDvqXdFnAUbCYtNQJd[i];
					pBOjGEXcjlHDvqXdFnAUbCYtNQJd[i] = 0f;
				}
				aHkzKihXeVOWsSZrFaHzBdYkssGU.Clear();
				int count = AcspxPzKYSIqJboERvPmPfChcpxk.Count;
				for (int j = 0; j < count; j++)
				{
					aHkzKihXeVOWsSZrFaHzBdYkssGU.AddData(AcspxPzKYSIqJboERvPmPfChcpxk[j]);
				}
				AcspxPzKYSIqJboERvPmPfChcpxk.Clear();
			}

			public void xcGlzRmHdbNPfCxucDAifswIrXNL(float[] P_0, float P_1)
			{
				for (int i = 0; i < pBOjGEXcjlHDvqXdFnAUbCYtNQJd.Length; i++)
				{
					pBOjGEXcjlHDvqXdFnAUbCYtNQJd[i] += P_0[i];
				}
				AcspxPzKYSIqJboERvPmPfChcpxk.injector.DNfbXjlUONZKgiGGpokWSKyQpSkC(P_0, P_1);
				AcspxPzKYSIqJboERvPmPfChcpxk.Inject();
			}

			public override void ooNidbhWzBcZZJydutNALDEuSswc()
			{
				Array.Clear(KwkGJdCTWMjNlfHXodMLTqnUYWrpA, 0, KwkGJdCTWMjNlfHXodMLTqnUYWrpA.Length);
				AcspxPzKYSIqJboERvPmPfChcpxk.Clear();
				aHkzKihXeVOWsSZrFaHzBdYkssGU.Clear();
			}
		}

		public class uSZnGClQbqaFyycJkqLkPwPrhXGb : ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb>.dFuptlhGpNzTzGvWxeUdsuiEinkQ, IComparable<uSZnGClQbqaFyycJkqLkPwPrhXGb>
		{
			public Vector3 KwkGJdCTWMjNlfHXodMLTqnUYWrpA;

			public float tozEffDuwdrDSuxnWfJRrdFygaEGA;

			public uSZnGClQbqaFyycJkqLkPwPrhXGb()
			{
			}

			public uSZnGClQbqaFyycJkqLkPwPrhXGb(float[] P_0, float P_1)
			{
				DNfbXjlUONZKgiGGpokWSKyQpSkC(P_0, P_1);
			}

			public void DNfbXjlUONZKgiGGpokWSKyQpSkC(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				for (int i = 0; i < num; i++)
				{
					KwkGJdCTWMjNlfHXodMLTqnUYWrpA[i] = P_0[i];
				}
				tozEffDuwdrDSuxnWfJRrdFygaEGA = P_1;
			}

			public void Set(uSZnGClQbqaFyycJkqLkPwPrhXGb P_0)
			{
				KwkGJdCTWMjNlfHXodMLTqnUYWrpA = P_0.KwkGJdCTWMjNlfHXodMLTqnUYWrpA;
				tozEffDuwdrDSuxnWfJRrdFygaEGA = P_0.tozEffDuwdrDSuxnWfJRrdFygaEGA;
			}

			public bool Equals(uSZnGClQbqaFyycJkqLkPwPrhXGb P_0)
			{
				if (tozEffDuwdrDSuxnWfJRrdFygaEGA == P_0.tozEffDuwdrDSuxnWfJRrdFygaEGA)
				{
					return KwkGJdCTWMjNlfHXodMLTqnUYWrpA == P_0.KwkGJdCTWMjNlfHXodMLTqnUYWrpA;
				}
				return false;
			}

			public void Clear()
			{
				KwkGJdCTWMjNlfHXodMLTqnUYWrpA.x = 0f;
				KwkGJdCTWMjNlfHXodMLTqnUYWrpA.y = 0f;
				KwkGJdCTWMjNlfHXodMLTqnUYWrpA.z = 0f;
				tozEffDuwdrDSuxnWfJRrdFygaEGA = 0f;
			}

			public int CompareTo(uSZnGClQbqaFyycJkqLkPwPrhXGb other)
			{
				return 0;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] OvJPmqJRIZNlsGSkQORNnRZZlSxW;

		private readonly float[] quwlAKajfzGQsQWawvAOAPOkCxXGA;

		private readonly int NJbSkPWaMdUdHdXFONlIjAJkDZNm;

		private readonly int NaHbXfYtdHeedcEgOLeXGEoVVVQgA;

		private readonly Action<byte[], float[]> beJEcrXOTGYSxTusyERABNLRUOHi;

		private readonly Func<float> uZwKiauwPjsKLqfrWaCgTDkvXdaK;

		public float[] rawValue => (dataSet as LmZMsrqfMECLetRMxgyuRMbcHnQP).KwkGJdCTWMjNlfHXodMLTqnUYWrpA;

		public ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> events => (dataSet as LmZMsrqfMECLetRMxgyuRMbcHnQP).aHkzKihXeVOWsSZrFaHzBdYkssGU;

		public HIDGyroscope(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
			: base(new LmZMsrqfMECLetRMxgyuRMbcHnQP(P_0, P_3, P_4), P_1, P_2)
		{
			valueLength = P_3;
			beJEcrXOTGYSxTusyERABNLRUOHi = P_5;
			uZwKiauwPjsKLqfrWaCgTDkvXdaK = P_6;
			NJbSkPWaMdUdHdXFONlIjAJkDZNm = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
			NaHbXfYtdHeedcEgOLeXGEoVVVQgA = P_2.dataIndex;
			OvJPmqJRIZNlsGSkQORNnRZZlSxW = new byte[NJbSkPWaMdUdHdXFONlIjAJkDZNm];
			quwlAKajfzGQsQWawvAOAPOkCxXGA = new float[P_3];
			lastRawValue = new float[P_3];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < NJbSkPWaMdUdHdXFONlIjAJkDZNm; i++)
				{
					OvJPmqJRIZNlsGSkQORNnRZZlSxW[i] = inputReport[NaHbXfYtdHeedcEgOLeXGEoVVVQgA + i];
				}
				if (beJEcrXOTGYSxTusyERABNLRUOHi != null)
				{
					beJEcrXOTGYSxTusyERABNLRUOHi(OvJPmqJRIZNlsGSkQORNnRZZlSxW, quwlAKajfzGQsQWawvAOAPOkCxXGA);
				}
				float num = ((uZwKiauwPjsKLqfrWaCgTDkvXdaK != null) ? uZwKiauwPjsKLqfrWaCgTDkvXdaK() : 0f);
				(dataSet as LmZMsrqfMECLetRMxgyuRMbcHnQP).iGkxxHnjjyXtKixgEHtqEpoqePie(quwlAKajfzGQsQWawvAOAPOkCxXGA, num);
				for (int j = 0; j < valueLength; j++)
				{
					lastRawValue[j] = quwlAKajfzGQsQWawvAOAPOkCxXGA[j];
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			float num = ((uZwKiauwPjsKLqfrWaCgTDkvXdaK != null) ? uZwKiauwPjsKLqfrWaCgTDkvXdaK() : 0f);
			for (int i = 0; i < valueLength; i++)
			{
				quwlAKajfzGQsQWawvAOAPOkCxXGA[i] = value[i];
			}
			(dataSet as LmZMsrqfMECLetRMxgyuRMbcHnQP).iGkxxHnjjyXtKixgEHtqEpoqePie(quwlAKajfzGQsQWawvAOAPOkCxXGA, num);
			for (int j = 0; j < valueLength; j++)
			{
				lastRawValue[j] = quwlAKajfzGQsQWawvAOAPOkCxXGA[j];
			}
		}
	}
}
