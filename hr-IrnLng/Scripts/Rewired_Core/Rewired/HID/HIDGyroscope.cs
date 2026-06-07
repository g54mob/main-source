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
		internal class PFzquFhchaRWVMGQWpnofwpaLxE : tHlQeLJqCEWKUMOmVnJppXPuLSy
		{
			private int GHWvyNXaNyaoRsfNTafVFqaTqUg;

			private int SvnpGrPovrLdYYSwtqCYJBsdiCp;

			public float[] rawValue => (TrWUdtjebjTxiTudwuGvXSlDJgg as ceQBqJDsxMpZKgCLvgBfjbxfdxS).EcKfTFWnqsKEYsThPRHDCjhWUGd;

			public ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF> events => (TrWUdtjebjTxiTudwuGvXSlDJgg as ceQBqJDsxMpZKgCLvgBfjbxfdxS).ygEuMxmTrhVXDbzGsAdvtKEsobE;

			public PFzquFhchaRWVMGQWpnofwpaLxE(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
				GHWvyNXaNyaoRsfNTafVFqaTqUg = valueLength;
				SvnpGrPovrLdYYSwtqCYJBsdiCp = eventCapacity;
				arYCwNeHnjJnYWBURQvFgVcxTDp(updateLoopSetting, VVGHFHJCOGHdzrJUgySQnKhllyK);
			}

			public override void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
			{
				base.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
				(TrWUdtjebjTxiTudwuGvXSlDJgg as ceQBqJDsxMpZKgCLvgBfjbxfdxS).iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
			}

			public void qlMfDdjoYWNKpjPtJjSefylPuwkJ(float[] P_0, float P_1)
			{
				for (int i = 0; i < KKxvXzhbFzmenMQwioAojqUOeaj.Length; i++)
				{
					(KKxvXzhbFzmenMQwioAojqUOeaj[i] as ceQBqJDsxMpZKgCLvgBfjbxfdxS).dLsHzjnbSRKkKxQgJBhmHrmAjFB(P_0, P_1);
				}
			}

			private VGnAJRIkyhjNBoXBsmJfCojhFgas VVGHFHJCOGHdzrJUgySQnKhllyK(UpdateLoopType P_0)
			{
				return new ceQBqJDsxMpZKgCLvgBfjbxfdxS(P_0, GHWvyNXaNyaoRsfNTafVFqaTqUg, SvnpGrPovrLdYYSwtqCYJBsdiCp);
			}
		}

		internal class ceQBqJDsxMpZKgCLvgBfjbxfdxS : VGnAJRIkyhjNBoXBsmJfCojhFgas
		{
			private float[] jOswRwEkHTlKiTyNgPmCVcMzKDL;

			public float[] EcKfTFWnqsKEYsThPRHDCjhWUGd;

			public ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF> ygEuMxmTrhVXDbzGsAdvtKEsobE;

			private ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF> YLOgNleldyBPuiKOkegqMjEfzavC;

			public ceQBqJDsxMpZKgCLvgBfjbxfdxS(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(updateLoop)
			{
				EcKfTFWnqsKEYsThPRHDCjhWUGd = new float[valueLength];
				jOswRwEkHTlKiTyNgPmCVcMzKDL = new float[valueLength];
				ygEuMxmTrhVXDbzGsAdvtKEsobE = new ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF>(eventCapacity, clearData: false, 20);
				YLOgNleldyBPuiKOkegqMjEfzavC = new ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF>(eventCapacity, clearData: false, 20);
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				for (int i = 0; i < jOswRwEkHTlKiTyNgPmCVcMzKDL.Length; i++)
				{
					EcKfTFWnqsKEYsThPRHDCjhWUGd[i] = jOswRwEkHTlKiTyNgPmCVcMzKDL[i];
					jOswRwEkHTlKiTyNgPmCVcMzKDL[i] = 0f;
				}
				ygEuMxmTrhVXDbzGsAdvtKEsobE.Clear();
				int count = YLOgNleldyBPuiKOkegqMjEfzavC.Count;
				for (int j = 0; j < count; j++)
				{
					ygEuMxmTrhVXDbzGsAdvtKEsobE.AddData(YLOgNleldyBPuiKOkegqMjEfzavC[j]);
				}
				YLOgNleldyBPuiKOkegqMjEfzavC.Clear();
			}

			public void dLsHzjnbSRKkKxQgJBhmHrmAjFB(float[] P_0, float P_1)
			{
				for (int i = 0; i < jOswRwEkHTlKiTyNgPmCVcMzKDL.Length; i++)
				{
					jOswRwEkHTlKiTyNgPmCVcMzKDL[i] += P_0[i];
				}
				ubnVRumZvQibiLoaPGlFgdqPNxLF injector = YLOgNleldyBPuiKOkegqMjEfzavC.injector;
				injector.NGXUBbcPdrBYfEJQGstImmQAGjsO(P_0, P_1);
				YLOgNleldyBPuiKOkegqMjEfzavC.Inject();
			}

			public override void agvWMBoHtblzmgSmVloJbsDkfGk()
			{
				Array.Clear(EcKfTFWnqsKEYsThPRHDCjhWUGd, 0, EcKfTFWnqsKEYsThPRHDCjhWUGd.Length);
				YLOgNleldyBPuiKOkegqMjEfzavC.Clear();
				ygEuMxmTrhVXDbzGsAdvtKEsobE.Clear();
			}
		}

		public class ubnVRumZvQibiLoaPGlFgdqPNxLF : ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF>.pqSaXXckQhKEYznYQYBpSAuUXxa, IComparable<ubnVRumZvQibiLoaPGlFgdqPNxLF>
		{
			public Vector3 EcKfTFWnqsKEYsThPRHDCjhWUGd;

			public float fcZZPDOEDPeOhDbjpaAZcXRmWqQH;

			public ubnVRumZvQibiLoaPGlFgdqPNxLF()
			{
			}

			public ubnVRumZvQibiLoaPGlFgdqPNxLF(float[] rawValues, float deltaTime)
			{
				NGXUBbcPdrBYfEJQGstImmQAGjsO(rawValues, deltaTime);
			}

			public void NGXUBbcPdrBYfEJQGstImmQAGjsO(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				for (int i = 0; i < num; i++)
				{
					EcKfTFWnqsKEYsThPRHDCjhWUGd[i] = P_0[i];
				}
				fcZZPDOEDPeOhDbjpaAZcXRmWqQH = P_1;
			}

			public void NGXUBbcPdrBYfEJQGstImmQAGjsO(ubnVRumZvQibiLoaPGlFgdqPNxLF P_0)
			{
				EcKfTFWnqsKEYsThPRHDCjhWUGd = P_0.EcKfTFWnqsKEYsThPRHDCjhWUGd;
				fcZZPDOEDPeOhDbjpaAZcXRmWqQH = P_0.fcZZPDOEDPeOhDbjpaAZcXRmWqQH;
			}

			void ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF>.pqSaXXckQhKEYznYQYBpSAuUXxa.NGXUBbcPdrBYfEJQGstImmQAGjsO(ubnVRumZvQibiLoaPGlFgdqPNxLF P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in NGXUBbcPdrBYfEJQGstImmQAGjsO
				this.NGXUBbcPdrBYfEJQGstImmQAGjsO(P_0);
			}

			public bool HSdDwaaSirDaxBQdgRrBRcKQYko(ubnVRumZvQibiLoaPGlFgdqPNxLF P_0)
			{
				if (fcZZPDOEDPeOhDbjpaAZcXRmWqQH == P_0.fcZZPDOEDPeOhDbjpaAZcXRmWqQH)
				{
					return EcKfTFWnqsKEYsThPRHDCjhWUGd == P_0.EcKfTFWnqsKEYsThPRHDCjhWUGd;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF>.pqSaXXckQhKEYznYQYBpSAuUXxa.HSdDwaaSirDaxBQdgRrBRcKQYko(ubnVRumZvQibiLoaPGlFgdqPNxLF P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in HSdDwaaSirDaxBQdgRrBRcKQYko
				return this.HSdDwaaSirDaxBQdgRrBRcKQYko(P_0);
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				EcKfTFWnqsKEYsThPRHDCjhWUGd.x = 0f;
				EcKfTFWnqsKEYsThPRHDCjhWUGd.y = 0f;
				EcKfTFWnqsKEYsThPRHDCjhWUGd.z = 0f;
				fcZZPDOEDPeOhDbjpaAZcXRmWqQH = 0f;
			}

			void ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF>.pqSaXXckQhKEYznYQYBpSAuUXxa.VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				//ILSpy generated this explicit interface implementation from .override directive in VcHhfbFqwxAmqhwBHKVJpDjlfufe
				this.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}

			public int CompareTo(ubnVRumZvQibiLoaPGlFgdqPNxLF other)
			{
				return 0;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] AdxOwSUcljDyFjRmfEYTVcHFHWn;

		private readonly float[] gwCFFyvACJQFDfiuPkRIsBGaMjT;

		private readonly int DOPAwzeHpXMLiMURxiQQbXTchRDO;

		private readonly int LfdrVVNOhonEGxepQjJXoyTABIg;

		private readonly Action<byte[], float[]> pqrKeHQWeadJSqleTZRUlVDJKvR;

		private readonly Func<float> eoWgwIxakPhbsaLfpudygfkxHNaG;

		public float[] rawValue => (dataSet as PFzquFhchaRWVMGQWpnofwpaLxE).rawValue;

		public ExpandableArray_DataContainer<ubnVRumZvQibiLoaPGlFgdqPNxLF> events => (dataSet as PFzquFhchaRWVMGQWpnofwpaLxE).events;

		public HIDGyroscope(UpdateLoopSetting updateLoopSetting, byte reportId, HIDInfo hidInfo, int valueLength, int startingEventCapacity, Action<byte[], float[]> calcValueDelegate, Func<float> getSensorDeltaTimeDelegate)
			: base(new PFzquFhchaRWVMGQWpnofwpaLxE(updateLoopSetting, valueLength, startingEventCapacity), reportId, hidInfo)
		{
			this.valueLength = valueLength;
			pqrKeHQWeadJSqleTZRUlVDJKvR = calcValueDelegate;
			eoWgwIxakPhbsaLfpudygfkxHNaG = getSensorDeltaTimeDelegate;
			DOPAwzeHpXMLiMURxiQQbXTchRDO = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			LfdrVVNOhonEGxepQjJXoyTABIg = hidInfo.dataIndex;
			AdxOwSUcljDyFjRmfEYTVcHFHWn = new byte[DOPAwzeHpXMLiMURxiQQbXTchRDO];
			gwCFFyvACJQFDfiuPkRIsBGaMjT = new float[valueLength];
			lastRawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < DOPAwzeHpXMLiMURxiQQbXTchRDO; i++)
				{
					AdxOwSUcljDyFjRmfEYTVcHFHWn[i] = inputReport[LfdrVVNOhonEGxepQjJXoyTABIg + i];
				}
				if (pqrKeHQWeadJSqleTZRUlVDJKvR != null)
				{
					pqrKeHQWeadJSqleTZRUlVDJKvR(AdxOwSUcljDyFjRmfEYTVcHFHWn, gwCFFyvACJQFDfiuPkRIsBGaMjT);
				}
				float num = ((eoWgwIxakPhbsaLfpudygfkxHNaG != null) ? eoWgwIxakPhbsaLfpudygfkxHNaG() : 0f);
				(dataSet as PFzquFhchaRWVMGQWpnofwpaLxE).qlMfDdjoYWNKpjPtJjSefylPuwkJ(gwCFFyvACJQFDfiuPkRIsBGaMjT, num);
				for (int j = 0; j < valueLength; j++)
				{
					lastRawValue[j] = gwCFFyvACJQFDfiuPkRIsBGaMjT[j];
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			float num = ((eoWgwIxakPhbsaLfpudygfkxHNaG != null) ? eoWgwIxakPhbsaLfpudygfkxHNaG() : 0f);
			for (int i = 0; i < valueLength; i++)
			{
				gwCFFyvACJQFDfiuPkRIsBGaMjT[i] = value[i];
			}
			(dataSet as PFzquFhchaRWVMGQWpnofwpaLxE).qlMfDdjoYWNKpjPtJjSefylPuwkJ(gwCFFyvACJQFDfiuPkRIsBGaMjT, num);
			for (int j = 0; j < valueLength; j++)
			{
				lastRawValue[j] = gwCFFyvACJQFDfiuPkRIsBGaMjT[j];
			}
		}
	}
}
