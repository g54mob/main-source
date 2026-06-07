using System;
using Rewired.Config;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class LmZMsrqfMECLetRMxgyuRMbcHnQP : xmZuwrAGVqILrhjYoPclRrBmGJaQ
		{
			private int IMmIRjEywOmdkNlRaVsRfNmLIWmFA;

			private int UbZGNDWVGLTIrrlcIllKnhavaQrdA;

			public float[] KwkGJdCTWMjNlfHXodMLTqnUYWrpA => null;

			public ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> aHkzKihXeVOWsSZrFaHzBdYkssGU => null;

			public LmZMsrqfMECLetRMxgyuRMbcHnQP(UpdateLoopSetting P_0, int P_1, int P_2)
			{
			}

			public override void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
			}

			public void iGkxxHnjjyXtKixgEHtqEpoqePie(float[] P_0, float P_1)
			{
			}

			private VrVvhtnBXDKMgsvVTUrvWTjnyaqi FsaffhCFfumqEQwGDkNUTLtpEuUP(UpdateLoopType P_0)
			{
				return null;
			}
		}

		internal class kSqHtbYoCwfibbHLGXtvnXzzDxOkA : VrVvhtnBXDKMgsvVTUrvWTjnyaqi
		{
			private float[] pBOjGEXcjlHDvqXdFnAUbCYtNQJd;

			public float[] KwkGJdCTWMjNlfHXodMLTqnUYWrpA;

			public ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> aHkzKihXeVOWsSZrFaHzBdYkssGU;

			private ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> AcspxPzKYSIqJboERvPmPfChcpxk;

			public kSqHtbYoCwfibbHLGXtvnXzzDxOkA(UpdateLoopType P_0, int P_1, int P_2)
				: base(default(UpdateLoopType))
			{
			}

			public void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
			}

			public void xcGlzRmHdbNPfCxucDAifswIrXNL(float[] P_0, float P_1)
			{
			}

			public override void ooNidbhWzBcZZJydutNALDEuSswc()
			{
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
			}

			public void DNfbXjlUONZKgiGGpokWSKyQpSkC(float[] P_0, float P_1)
			{
			}

			public void Set(uSZnGClQbqaFyycJkqLkPwPrhXGb P_0)
			{
			}

			public bool Equals(uSZnGClQbqaFyycJkqLkPwPrhXGb P_0)
			{
				return false;
			}

			public void Clear()
			{
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

		public float[] rawValue => null;

		public ExpandableArray_DataContainer<uSZnGClQbqaFyycJkqLkPwPrhXGb> events => null;

		public HIDGyroscope(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
			: base(null, 0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
		}
	}
}
