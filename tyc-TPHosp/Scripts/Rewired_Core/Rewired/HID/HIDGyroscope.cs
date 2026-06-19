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
		internal class jcBfBhBOGdrnXFFyDUztvpAQZle : VyZzBpiHJLkhAHpaGkbcnAcCPHA
		{
			private int yuxOjwAufSHBlHjWZvMHUHzKGQ;

			private int qYZKTXmSjygCHXSCksVEFTwJWVM;

			public float[] rawValue => (bAihUPOaQoqOwOHZvtGkVuGzqqW as IHimxxeMoTAIblbekwaUdIEFhKs).oSkMqvraGdJlEtuhSBPKAEKedMXe;

			public ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn> events => (bAihUPOaQoqOwOHZvtGkVuGzqqW as IHimxxeMoTAIblbekwaUdIEFhKs).KCeTPoJqaqsuTimLlIQmbLhGgYo;

			public jcBfBhBOGdrnXFFyDUztvpAQZle(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
				yuxOjwAufSHBlHjWZvMHUHzKGQ = valueLength;
				qYZKTXmSjygCHXSCksVEFTwJWVM = eventCapacity;
				EmrltXEvsiAKZaBKIKCsFzXVHJ(updateLoopSetting, tpseFzovQBCAvwgunUIFdEVRkmg);
			}

			public override void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
			{
				base.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0);
				(bAihUPOaQoqOwOHZvtGkVuGzqqW as IHimxxeMoTAIblbekwaUdIEFhKs).QTPiZFmnRsxmyQYmMuIoBQkOtfg();
			}

			public void UvoNkFZNhDQjpUgDojUrbqOMCuQI(float[] P_0, float P_1)
			{
				for (int i = 0; i < cXZAhDQESebRdBDchpsjrHPyUmL.Length; i++)
				{
					(cXZAhDQESebRdBDchpsjrHPyUmL[i] as IHimxxeMoTAIblbekwaUdIEFhKs).RSkQPUIfAHtGqXSMLZhJNZsHdf(P_0, P_1);
				}
			}

			private luZKkhRZZopiVCbznmPqyHYFeyA tpseFzovQBCAvwgunUIFdEVRkmg(UpdateLoopType P_0)
			{
				return new IHimxxeMoTAIblbekwaUdIEFhKs(P_0, yuxOjwAufSHBlHjWZvMHUHzKGQ, qYZKTXmSjygCHXSCksVEFTwJWVM);
			}
		}

		internal class IHimxxeMoTAIblbekwaUdIEFhKs : luZKkhRZZopiVCbznmPqyHYFeyA
		{
			private float[] PyAFyEpfkEYdcIbpvXmDZkdLaLhi;

			public float[] oSkMqvraGdJlEtuhSBPKAEKedMXe;

			public ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn> KCeTPoJqaqsuTimLlIQmbLhGgYo;

			private ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn> aYwtiRVCYxawigVslCyhqvrPWkHH;

			public IHimxxeMoTAIblbekwaUdIEFhKs(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(updateLoop)
			{
				oSkMqvraGdJlEtuhSBPKAEKedMXe = new float[valueLength];
				PyAFyEpfkEYdcIbpvXmDZkdLaLhi = new float[valueLength];
				KCeTPoJqaqsuTimLlIQmbLhGgYo = new ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn>(eventCapacity, clearData: false, 20);
				aYwtiRVCYxawigVslCyhqvrPWkHH = new ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn>(eventCapacity, clearData: false, 20);
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				for (int i = 0; i < PyAFyEpfkEYdcIbpvXmDZkdLaLhi.Length; i++)
				{
					oSkMqvraGdJlEtuhSBPKAEKedMXe[i] = PyAFyEpfkEYdcIbpvXmDZkdLaLhi[i];
					PyAFyEpfkEYdcIbpvXmDZkdLaLhi[i] = 0f;
				}
				KCeTPoJqaqsuTimLlIQmbLhGgYo.Clear();
				int count = aYwtiRVCYxawigVslCyhqvrPWkHH.Count;
				for (int j = 0; j < count; j++)
				{
					KCeTPoJqaqsuTimLlIQmbLhGgYo.AddData(aYwtiRVCYxawigVslCyhqvrPWkHH[j]);
				}
				aYwtiRVCYxawigVslCyhqvrPWkHH.Clear();
			}

			public void RSkQPUIfAHtGqXSMLZhJNZsHdf(float[] P_0, float P_1)
			{
				for (int i = 0; i < PyAFyEpfkEYdcIbpvXmDZkdLaLhi.Length; i++)
				{
					PyAFyEpfkEYdcIbpvXmDZkdLaLhi[i] += P_0[i];
				}
				IpHgaKZrMNjSmSUYCtbQntPnitn injector = aYwtiRVCYxawigVslCyhqvrPWkHH.injector;
				injector.vJjhoRLlAcrjzWycVrrFomtsobA(P_0, P_1);
				aYwtiRVCYxawigVslCyhqvrPWkHH.Inject();
			}

			public override void QjNHfjHnCmaQyvCGKbwODraSxUWC()
			{
				Array.Clear(oSkMqvraGdJlEtuhSBPKAEKedMXe, 0, oSkMqvraGdJlEtuhSBPKAEKedMXe.Length);
				aYwtiRVCYxawigVslCyhqvrPWkHH.Clear();
				KCeTPoJqaqsuTimLlIQmbLhGgYo.Clear();
			}
		}

		public class IpHgaKZrMNjSmSUYCtbQntPnitn : ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn>.ZCwyRnXJtqxwKqOyVThgMfPudaO, IComparable<IpHgaKZrMNjSmSUYCtbQntPnitn>
		{
			public Vector3 oSkMqvraGdJlEtuhSBPKAEKedMXe;

			public float DLvkFzjqfKhkjYXKoErIBgzYkBe;

			public IpHgaKZrMNjSmSUYCtbQntPnitn()
			{
			}

			public IpHgaKZrMNjSmSUYCtbQntPnitn(float[] rawValues, float deltaTime)
			{
				vJjhoRLlAcrjzWycVrrFomtsobA(rawValues, deltaTime);
			}

			public void vJjhoRLlAcrjzWycVrrFomtsobA(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				for (int i = 0; i < num; i++)
				{
					oSkMqvraGdJlEtuhSBPKAEKedMXe[i] = P_0[i];
				}
				DLvkFzjqfKhkjYXKoErIBgzYkBe = P_1;
			}

			public void vJjhoRLlAcrjzWycVrrFomtsobA(IpHgaKZrMNjSmSUYCtbQntPnitn P_0)
			{
				oSkMqvraGdJlEtuhSBPKAEKedMXe = P_0.oSkMqvraGdJlEtuhSBPKAEKedMXe;
				DLvkFzjqfKhkjYXKoErIBgzYkBe = P_0.DLvkFzjqfKhkjYXKoErIBgzYkBe;
			}

			void ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn>.ZCwyRnXJtqxwKqOyVThgMfPudaO.vJjhoRLlAcrjzWycVrrFomtsobA(IpHgaKZrMNjSmSUYCtbQntPnitn P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in vJjhoRLlAcrjzWycVrrFomtsobA
				this.vJjhoRLlAcrjzWycVrrFomtsobA(P_0);
			}

			public bool hFRtBMPFLguJtUgBhljKTKfqOwO(IpHgaKZrMNjSmSUYCtbQntPnitn P_0)
			{
				if (DLvkFzjqfKhkjYXKoErIBgzYkBe == P_0.DLvkFzjqfKhkjYXKoErIBgzYkBe)
				{
					return oSkMqvraGdJlEtuhSBPKAEKedMXe == P_0.oSkMqvraGdJlEtuhSBPKAEKedMXe;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn>.ZCwyRnXJtqxwKqOyVThgMfPudaO.hFRtBMPFLguJtUgBhljKTKfqOwO(IpHgaKZrMNjSmSUYCtbQntPnitn P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in hFRtBMPFLguJtUgBhljKTKfqOwO
				return this.hFRtBMPFLguJtUgBhljKTKfqOwO(P_0);
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				oSkMqvraGdJlEtuhSBPKAEKedMXe.x = 0f;
				oSkMqvraGdJlEtuhSBPKAEKedMXe.y = 0f;
				oSkMqvraGdJlEtuhSBPKAEKedMXe.z = 0f;
				DLvkFzjqfKhkjYXKoErIBgzYkBe = 0f;
			}

			void ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn>.ZCwyRnXJtqxwKqOyVThgMfPudaO.dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dLvQQBBPNcDLyfQfBHFGJrYJbsBD
				this.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}

			public int CompareTo(IpHgaKZrMNjSmSUYCtbQntPnitn other)
			{
				return 0;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] ygBnhstaMsNZJqoUaYPAJacvJML;

		private readonly float[] SieumQGIfWdmRwvCKDJTgHzGbxzA;

		private readonly int vrjlRLuDGYauaDVzaaERkJgMYFrV;

		private readonly int ldNQcpwSvgIMMslOcdrMkwBpFme;

		private readonly Action<byte[], float[]> LwNYNnvqFdEqEdoUCzJLnqopZQt;

		private readonly Func<float> MbwvTgAkRCuKkAMVsFjdnVNPBFO;

		public float[] rawValue => (dataSet as jcBfBhBOGdrnXFFyDUztvpAQZle).rawValue;

		public ExpandableArray_DataContainer<IpHgaKZrMNjSmSUYCtbQntPnitn> events => (dataSet as jcBfBhBOGdrnXFFyDUztvpAQZle).events;

		public HIDGyroscope(UpdateLoopSetting updateLoopSetting, byte reportId, HIDInfo hidInfo, int valueLength, int startingEventCapacity, Action<byte[], float[]> calcValueDelegate, Func<float> getSensorDeltaTimeDelegate)
			: base(new jcBfBhBOGdrnXFFyDUztvpAQZle(updateLoopSetting, valueLength, startingEventCapacity), reportId, hidInfo)
		{
			this.valueLength = valueLength;
			LwNYNnvqFdEqEdoUCzJLnqopZQt = calcValueDelegate;
			MbwvTgAkRCuKkAMVsFjdnVNPBFO = getSensorDeltaTimeDelegate;
			vrjlRLuDGYauaDVzaaERkJgMYFrV = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			ldNQcpwSvgIMMslOcdrMkwBpFme = hidInfo.dataIndex;
			ygBnhstaMsNZJqoUaYPAJacvJML = new byte[vrjlRLuDGYauaDVzaaERkJgMYFrV];
			SieumQGIfWdmRwvCKDJTgHzGbxzA = new float[valueLength];
			lastRawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < vrjlRLuDGYauaDVzaaERkJgMYFrV; i++)
				{
					ygBnhstaMsNZJqoUaYPAJacvJML[i] = inputReport[ldNQcpwSvgIMMslOcdrMkwBpFme + i];
				}
				if (LwNYNnvqFdEqEdoUCzJLnqopZQt != null)
				{
					LwNYNnvqFdEqEdoUCzJLnqopZQt(ygBnhstaMsNZJqoUaYPAJacvJML, SieumQGIfWdmRwvCKDJTgHzGbxzA);
				}
				float num = ((MbwvTgAkRCuKkAMVsFjdnVNPBFO != null) ? MbwvTgAkRCuKkAMVsFjdnVNPBFO() : 0f);
				(dataSet as jcBfBhBOGdrnXFFyDUztvpAQZle).UvoNkFZNhDQjpUgDojUrbqOMCuQI(SieumQGIfWdmRwvCKDJTgHzGbxzA, num);
				for (int j = 0; j < valueLength; j++)
				{
					lastRawValue[j] = SieumQGIfWdmRwvCKDJTgHzGbxzA[j];
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			float num = ((MbwvTgAkRCuKkAMVsFjdnVNPBFO != null) ? MbwvTgAkRCuKkAMVsFjdnVNPBFO() : 0f);
			for (int i = 0; i < valueLength; i++)
			{
				SieumQGIfWdmRwvCKDJTgHzGbxzA[i] = value[i];
			}
			(dataSet as jcBfBhBOGdrnXFFyDUztvpAQZle).UvoNkFZNhDQjpUgDojUrbqOMCuQI(SieumQGIfWdmRwvCKDJTgHzGbxzA, num);
			for (int j = 0; j < valueLength; j++)
			{
				lastRawValue[j] = SieumQGIfWdmRwvCKDJTgHzGbxzA[j];
			}
		}
	}
}
