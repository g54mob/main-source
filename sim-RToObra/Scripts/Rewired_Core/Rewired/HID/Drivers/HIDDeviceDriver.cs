using System;
using Rewired.Config;
using Rewired.Drivers.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDDeviceDriver : IDisposable, IControllerDriver
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

			public InitArgs(UpdateLoopSetting updateLoopSetting, DeviceConnectionType connectionType, int minAxisValue, int maxAxisValue, int hatZeroValue, int hatSpan, int inputReportLength, int outputReportLength, Func<OutputReport, bool> synchronousWriteOutputReportDelegate, Action<OutputReport> asynchronousWriteOutputReportDelegate)
			{
				this.updateLoopSetting = updateLoopSetting;
				this.connectionType = connectionType;
				this.minAxisValue = minAxisValue;
				this.maxAxisValue = maxAxisValue;
				this.hatZeroValue = hatZeroValue;
				this.hatSpan = hatSpan;
				this.inputReportLength = inputReportLength;
				this.outputReportLength = outputReportLength;
				this.synchronousWriteOutputReportDelegate = synchronousWriteOutputReportDelegate;
				this.asynchronousWriteOutputReportDelegate = asynchronousWriteOutputReportDelegate;
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

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public int AxisCount
		{
			get
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}
		}

		public int ButtonCount
		{
			get
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}
		}

		public int HatCount
		{
			get
			{
				if (hats == null)
				{
					return 0;
				}
				return hats.Length;
			}
		}

		public int AccelerometerCount
		{
			get
			{
				if (accelerometers == null)
				{
					return 0;
				}
				return accelerometers.Length;
			}
		}

		public int GyroscopeCount
		{
			get
			{
				if (gyroscopes == null)
				{
					return 0;
				}
				return gyroscopes.Length;
			}
		}

		public int TouchpadCount
		{
			get
			{
				if (touchpads == null)
				{
					return 0;
				}
				return touchpads.Length;
			}
		}

		public int LightCount
		{
			get
			{
				if (lights == null)
				{
					return 0;
				}
				return lights.Length;
			}
		}

		public int VibrationMotorCount
		{
			get
			{
				if (vibrationMotors == null)
				{
					return 0;
				}
				return vibrationMotors.Length;
			}
		}

		protected bool disposed
		{
			get
			{
				return vsurYtRlepcrpAzAENwjqjJEZPT;
			}
		}

		public HIDDeviceDriver()
		{
		}

		public abstract void Update(UpdateLoopType updateLoop);

		public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, float timestamp);

		public abstract Controller.Extension CreateControllerExtension();

		public static HIDDeviceDriver GetDriver(int driverId, InitArgs hidDriverInitArgs)
		{
			if (hidDriverInitArgs == null)
			{
				goto IL_0003;
			}
			switch (driverId)
			{
			case 0:
				goto IL_0047;
			case 1:
				return new RailDriverDriver(hidDriverInitArgs);
			}
			int num = 190343417;
			goto IL_0008;
			IL_0003:
			num = 190343418;
			goto IL_0008;
			IL_0047:
			if (UnityTools.effectivePlatform == Platform.OSX && hidDriverInitArgs.connectionType == DeviceConnectionType.qsDfuTzZaVPhIJLeNOadBBAjTAI)
			{
				return null;
			}
			return new DualShock4Driver(hidDriverInitArgs);
			IL_0008:
			switch (num ^ 0xB5868FB)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
				goto IL_0047;
			case 2:
				return null;
			}
			goto IL_0003;
		}

		public static int FindDriverId(int vendorId, int productId)
		{
			if (DualShock4Driver.Matches(vendorId, productId))
			{
				return 0;
			}
			if (RailDriverDriver.Matches(vendorId, productId))
			{
				return 1;
			}
			return -1;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~HIDDeviceDriver()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
			}
		}
	}
}
