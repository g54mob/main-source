using System;
using Rewired.Config;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class MwaadRAOmMKGQkdqkndVodtYzODn : cDwHqLaLhgMQDbOytveAtWHUqcv
		{
			private int DQLoNMeMGukWcLpdbdqOVmnzdvH;

			private int HgkxbmnwPJyZrjCTalnZakXfDm;

			public float[] rawValue => null;

			public ExpandableArray_DataContainer<jqaIYcFksubflmsUxNhitaolnQQ> events => null;

			public MwaadRAOmMKGQkdqkndVodtYzODn(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
			}

			public override void jSmUMfkZCZCZfiMnleEGJnwKIqT(UpdateLoopType P_0)
			{
			}

			public void zpNlIzTvDylOmukLPOQNiPdYfZn(float[] P_0, float P_1)
			{
			}

			private OayPMXFIdBWRKuOpYFJGkCzLzXn OjZWPRsVQgrwNKsnMOzKvzJTDXl(UpdateLoopType P_0)
			{
				return null;
			}
		}

		internal class jILUGLskIerGJTfdNqKGtmnTSpZ : OayPMXFIdBWRKuOpYFJGkCzLzXn
		{
			private float[] uXtkGanHEdhSnHonCNcruDMTZmQn;

			public float[] TYNAkTrmyKZEPTqphvJaSZtsojy;

			public ExpandableArray_DataContainer<jqaIYcFksubflmsUxNhitaolnQQ> vxHbcEBaURBxWYwXEWrCngGENYV;

			private ExpandableArray_DataContainer<jqaIYcFksubflmsUxNhitaolnQQ> PyXyKnNGeSvPfnveMMiDtmSFFPy;

			public jILUGLskIerGJTfdNqKGtmnTSpZ(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(default(UpdateLoopType))
			{
			}

			public void jSmUMfkZCZCZfiMnleEGJnwKIqT()
			{
			}

			public void wEfIvtILflEkRQCZnNHXJmCqWhE(float[] P_0, float P_1)
			{
			}

			public override void rkokDDVBuXRhnNCArjcuJjDYtpzW()
			{
			}
		}

		public class jqaIYcFksubflmsUxNhitaolnQQ : ExpandableArray_DataContainer<jqaIYcFksubflmsUxNhitaolnQQ>.oiXKtVPPpVIaBQsoeNQOEaNwEaf, IComparable<jqaIYcFksubflmsUxNhitaolnQQ>
		{
			public Vector3 TYNAkTrmyKZEPTqphvJaSZtsojy;

			public float gFSMJRlUuzEkqeLTJAcqTBBWLdR;

			public jqaIYcFksubflmsUxNhitaolnQQ()
			{
			}

			public jqaIYcFksubflmsUxNhitaolnQQ(float[] rawValues, float deltaTime)
			{
			}

			public void ClCJMtZZeVUEysnoiGvdioEaoEbp(float[] P_0, float P_1)
			{
			}

			public void ClCJMtZZeVUEysnoiGvdioEaoEbp(jqaIYcFksubflmsUxNhitaolnQQ P_0)
			{
			}

			public bool MfiytuRdrVMgqkKNWGdaPgWmrHx(jqaIYcFksubflmsUxNhitaolnQQ P_0)
			{
				return false;
			}

			public void CKSoitBPjLqWpFGpwBNgDbvTrVm()
			{
			}

			public int CompareTo(jqaIYcFksubflmsUxNhitaolnQQ other)
			{
				return 0;
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] DMcLTMlksXgRWSBKBIFqBSZllPe;

		private readonly float[] ldXYUwYsZphDSCyQzGDfcdSCDCAi;

		private readonly int CSCNppsgkxERdcxlNRYpeVDSOcCQ;

		private readonly int QCeoAFsXBNrlLUIrPnGemfcxaCP;

		private readonly Action<byte[], float[]> aBkwvBxNjKIXVZOKpRDdtzLzPtG;

		private readonly Func<float> fwZXbCIglfBdbEaLRKnDczaFCyzG;

		public float[] rawValue => null;

		public ExpandableArray_DataContainer<jqaIYcFksubflmsUxNhitaolnQQ> events => null;

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
