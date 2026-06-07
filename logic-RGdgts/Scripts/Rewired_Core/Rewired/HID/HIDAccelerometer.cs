using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class HIDAccelerometer : HIDControllerElement
	{
		public readonly float[] rawValue;

		public double timestamp;

		public readonly int valueLength;

		private readonly byte[] OvJPmqJRIZNlsGSkQORNnRZZlSxW;

		private readonly int NJbSkPWaMdUdHdXFONlIjAJkDZNm;

		private readonly int NaHbXfYtdHeedcEgOLeXGEoVVVQgA;

		private readonly Action<byte[], float[]> beJEcrXOTGYSxTusyERABNLRUOHi;

		public HIDAccelerometer(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
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
