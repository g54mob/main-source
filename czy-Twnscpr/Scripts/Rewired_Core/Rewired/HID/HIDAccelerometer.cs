using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class HIDAccelerometer : HIDControllerElement
	{
		public readonly float[] rawValue;

		public double timestamp;

		public readonly int valueLength;

		private readonly byte[] DMcLTMlksXgRWSBKBIFqBSZllPe;

		private readonly int CSCNppsgkxERdcxlNRYpeVDSOcCQ;

		private readonly int QCeoAFsXBNrlLUIrPnGemfcxaCP;

		private readonly Action<byte[], float[]> aBkwvBxNjKIXVZOKpRDdtzLzPtG;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(0, null)
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
