using System;
using Rewired.Config;
using Rewired.Drivers.Interfaces;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal abstract class HIDDeviceDriver : IDisposable, IControllerDriver
	{
		[CustomObfuscation]
		public enum DriverType
		{
			kWwOvXSVQftLstpRDMaKvWdpfrv = 0,
			pByxIObLCzCaZBrljlZsdcJBQxZ = 1,
			bUexuizwyghnfZOqCkdwtNbGlqU = 2,
			aRuqjxJVsvTlrDSzPFOpDpsYoJc = 3
		}

		[CustomObfuscation]
		internal delegate byte[] GetHidFeatureData(byte reportId);

		[CustomObfuscation]
		[CustomClassObfuscation]
		internal class InitArgs
		{
			public UpdateLoopSetting updateLoopSetting;

			public DeviceConnectionType connectionType;

			public int minAxisValue;

			public int maxAxisValue;

			public int hatZeroValue;

			public int hatSpan;

			public int inputReportLength;

			public int outputReportLength;

			public Func<OutputReport, bool> synchronousWriteOutputReportDelegate;

			public Action<OutputReport> asynchronousWriteOutputReportDelegate;

			public GetHidFeatureData getFeatureReportDelegate;

			public InitArgs(UpdateLoopSetting updateLoopSetting, DeviceConnectionType connectionType, int minAxisValue, int maxAxisValue, int hatZeroValue, int hatSpan, int inputReportLength, int outputReportLength, Func<OutputReport, bool> synchronousWriteOutputReportDelegate, Action<OutputReport> asynchronousWriteOutputReportDelegate, GetHidFeatureData getFeatureReportDelegate)
			{
			}
		}

		public HIDAxis[] axes;

		public HIDButton[] buttons;

		public HIDHat[] hats;

		public HIDAccelerometer[] accelerometers;

		public HIDGyroscope[] gyroscopes;

		public HIDTouchpad[] touchpads;

		public HIDVibrationMotor[] vibrationMotors;

		public HIDLight[] lights;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

		public int AxisCount => 0;

		public int ButtonCount => 0;

		public int HatCount => 0;

		public int AccelerometerCount => 0;

		public int GyroscopeCount => 0;

		public int TouchpadCount => 0;

		public int LightCount => 0;

		public int VibrationMotorCount => 0;

		protected bool disposed => false;

		public HIDDeviceDriver()
		{
		}

		public abstract void Update(UpdateLoopType updateLoop);

		public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp);

		public abstract Controller.Extension CreateControllerExtension();

		public static HIDDeviceDriver GetDriver(DriverType driverId, InitArgs hidDriverInitArgs)
		{
			return null;
		}

		public static DriverType FindDriverId(int vendorId, int productId)
		{
			return default(DriverType);
		}

		public void Dispose()
		{
		}

		~HIDDeviceDriver()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
