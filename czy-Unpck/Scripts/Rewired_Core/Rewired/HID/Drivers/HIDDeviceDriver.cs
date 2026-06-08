using System;
using Rewired.Config;
using Rewired.Drivers.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class HIDDeviceDriver : IDisposable, IControllerDriver
	{
		[CustomObfuscation(rename = false)]
		public enum DriverType
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			QfKlfFhpHsYjyYTVbEwVHkeNbhh = 1,
			YQWEZfrNrroYKSUaURKTNIoKxPk = 2,
			NCSvGyHppoRcKYVJDazMfVZKqPQ = 3
		}

		[CustomObfuscation(rename = false)]
		internal delegate byte[] GetHidFeatureData(byte reportId);

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

			public GetHidFeatureData getFeatureReportDelegate;

			public InitArgs(UpdateLoopSetting updateLoopSetting, DeviceConnectionType connectionType, int minAxisValue, int maxAxisValue, int hatZeroValue, int hatSpan, int inputReportLength, int outputReportLength, Func<OutputReport, bool> synchronousWriteOutputReportDelegate, Action<OutputReport> asynchronousWriteOutputReportDelegate, GetHidFeatureData getFeatureReportDelegate)
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
				this.getFeatureReportDelegate = getFeatureReportDelegate;
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

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

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

		protected bool disposed => xRygqjRmTtURDPiwlgMmFcdNBrr;

		public HIDDeviceDriver()
		{
		}

		public abstract void Update(UpdateLoopType updateLoop);

		public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp);

		public abstract Controller.Extension CreateControllerExtension();

		public static HIDDeviceDriver GetDriver(DriverType driverId, InitArgs hidDriverInitArgs)
		{
			if (hidDriverInitArgs == null)
			{
				return null;
			}
			while (true)
			{
				int num = 795907302;
				while (true)
				{
					switch (num ^ 0x2F7094E7)
					{
					case 2:
						break;
					case 1:
						switch (driverId)
						{
						default:
							num = 795907303;
							continue;
						case DriverType.QfKlfFhpHsYjyYTVbEwVHkeNbhh:
							break;
						case DriverType.YQWEZfrNrroYKSUaURKTNIoKxPk:
							return new DualSenseDriver(hidDriverInitArgs);
						case DriverType.NCSvGyHppoRcKYVJDazMfVZKqPQ:
							return new RailDriverDriver(hidDriverInitArgs);
						}
						goto case 3;
					case 3:
						if (UnityTools.effectivePlatform == Platform.OSX)
						{
							num = 795907299;
							continue;
						}
						goto IL_006b;
					default:
						if (hidDriverInitArgs.connectionType == DeviceConnectionType.sFJAQBfZHNpXaWTCudNqcxaaCMg)
						{
							return null;
						}
						goto IL_006b;
					case 0:
						{
							return null;
						}
						IL_006b:
						return new DualShock4Driver(hidDriverInitArgs);
					}
					break;
				}
			}
		}

		public static DriverType FindDriverId(int vendorId, int productId)
		{
			if (DualShock4Driver.Matches(vendorId, productId))
			{
				return DriverType.QfKlfFhpHsYjyYTVbEwVHkeNbhh;
			}
			if (DualSenseDriver.Matches(vendorId, productId))
			{
				return DriverType.YQWEZfrNrroYKSUaURKTNIoKxPk;
			}
			if (RailDriverDriver.Matches(vendorId, productId))
			{
				return DriverType.NCSvGyHppoRcKYVJDazMfVZKqPQ;
			}
			return DriverType.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~HIDDeviceDriver()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (true)
			{
				int num = 1801373062;
				while (true)
				{
					switch (num ^ 0x6B5EC586)
					{
					case 3:
						num = 1801373063;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						xRygqjRmTtURDPiwlgMmFcdNBrr = true;
						num = 1801373060;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}
	}
}
