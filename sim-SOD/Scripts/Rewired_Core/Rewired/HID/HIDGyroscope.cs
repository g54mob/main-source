using System;
using Rewired.Config;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class NXJJgwyYUqDkYraqyQtpXOozKTK : rZZopsCONEjDBzXsfIOkTAibxer
		{
			private int ScaDEaFQmitvGGTnblWEEhJkEtpO;

			private int GQZGWAENAdcORGpIZNFHFfNuSpga;

			public float[] rawValue => null;

			public ExpandableArray_DataContainer<oiDemRpcICkkdwKOtjWObBRIoKCe> events => null;

			public NXJJgwyYUqDkYraqyQtpXOozKTK(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
			}

			public override void oDVbwUgIfbSDvfmIInVcyfSKnKRm(UpdateLoopType P_0)
			{
			}

			public void cuwcbShFvSfVkcXNZSdxESWbADp(float[] P_0, float P_1)
			{
			}

			private ReLcOqdSZnQWUohlKcliSEYkNGb NikEqyjGvOecghMcEMvVWXGiqLLN(UpdateLoopType P_0)
			{
				return null;
			}
		}

		internal class ihgacecISGIyZRJbLvZuNTAsGYP : ReLcOqdSZnQWUohlKcliSEYkNGb
		{
			private float[] xPWkjXXCaNcPzsPzIKLLlodsvuG;

			public float[] MFkGQgVHOsiXXZXvbcwUfgAPHhqZ;

			public ExpandableArray_DataContainer<oiDemRpcICkkdwKOtjWObBRIoKCe> uSqLFphrkviCYAhXKdjoAVzhCNJI;

			private ExpandableArray_DataContainer<oiDemRpcICkkdwKOtjWObBRIoKCe> EngowKfILiMUfhmtURpdFfnsHAq;

			public ihgacecISGIyZRJbLvZuNTAsGYP(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(default(UpdateLoopType))
			{
			}

			public void oDVbwUgIfbSDvfmIInVcyfSKnKRm()
			{
			}

			public void vQWdoIaozFoHRUSUtumpOrZNaUQs(float[] P_0, float P_1)
			{
			}

			public override void wcDfhuvvIloonVFErZkAXwihlbn()
			{
			}
		}

		public class oiDemRpcICkkdwKOtjWObBRIoKCe : ExpandableArray_DataContainer<oiDemRpcICkkdwKOtjWObBRIoKCe>.ntsXewxcbbWHHUGasYcakqRZVAt, IComparable<oiDemRpcICkkdwKOtjWObBRIoKCe>
		{
			public Vector3 MFkGQgVHOsiXXZXvbcwUfgAPHhqZ;

			public float bEjEuuGPaTKHeqkTDHlQJngpfRDE;

			public oiDemRpcICkkdwKOtjWObBRIoKCe()
			{
			}

			public oiDemRpcICkkdwKOtjWObBRIoKCe(float[] rawValues, float deltaTime)
			{
			}

			public void XCtmPOrxAdFOcqUsoCVXUexNCxb(float[] P_0, float P_1)
			{
			}

			public void XCtmPOrxAdFOcqUsoCVXUexNCxb(oiDemRpcICkkdwKOtjWObBRIoKCe P_0)
			{
			}

			public bool ZHLLHRjBDvnvuupTCErYrFhJXNt(oiDemRpcICkkdwKOtjWObBRIoKCe P_0)
			{
				return false;
			}

			public void DcbUeIfyTfvTrRQxceAMfGCsJNs()
			{
			}

			public int CompareTo(oiDemRpcICkkdwKOtjWObBRIoKCe other)
			{
				return 0;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] WjBTdtDZYvedQWLAVjzWrYaSrtg;

		private readonly float[] kFkkXTkjBVIJUAEzhqhRUlpvGsC;

		private readonly int JWdDdMAsITCbxvmnBhcXhjuxyZY;

		private readonly int HLXnQkKonzrsPAIAVEMWIUZSZmJK;

		private readonly Action<byte[], float[]> vrTNvuHNfsMeNBJMfsKFDavSbwO;

		private readonly Func<float> yKyHufeBuBuNbwFCJCOvRBJccCl;

		public float[] rawValue => null;

		public ExpandableArray_DataContainer<oiDemRpcICkkdwKOtjWObBRIoKCe> events => null;

		public HIDGyroscope(UpdateLoopSetting updateLoopSetting, byte reportId, HIDInfo hidInfo, int valueLength, int startingEventCapacity, Action<byte[], float[]> calcValueDelegate, Func<float> getSensorDeltaTimeDelegate)
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
