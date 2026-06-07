using System;
using System.Collections.Generic;
using Rewired.Config;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDDeviceDriver : IControllerDriver, IDisposable
	{
		[CustomObfuscation(rename = false)]
		public enum DriverType
		{
			None = 0,
			DualShock4 = 1,
			DualSense = 2,
			RailDriver = 3,
			SwitchJoyConLeft = 4,
			SwitchJoyConRight = 5,
			SwitchProController = 6
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal struct HIDProperties
		{
			public ushort vendorId;

			public ushort productId;

			public string productName;

			public string manufacturer;

			public ushort usagePage;

			public ushort usage;

			public int maxInputReportLength;

			public int maxOutputReportLength;

			public int maxFeatureReportLength;

			public HIDProperties(ushort P_0, ushort P_1, string P_2, string P_3, ushort P_4, ushort P_5, int P_6, int P_7, int P_8)
			{
				vendorId = 0;
				productId = 0;
				productName = null;
				manufacturer = null;
				usagePage = 0;
				usage = 0;
				maxInputReportLength = 0;
				maxOutputReportLength = 0;
				maxFeatureReportLength = 0;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface IHIDDevice
		{
			HIDProperties properties { get; }

			bool WriteSync(MwEMUNdEdQpngdbXMtjwIdOvEFgfA outputReport, int timeoutMs);

			void WriteAsync(MwEMUNdEdQpngdbXMtjwIdOvEFgfA outputReport, int timeoutMs);

			bool ReadSync(IntPtr buffer, int bytesToRead, int timeoutMs);

			byte[] GetHidFeatureData(byte reportId, int reportLength, int timeoutMs, int retryCount);
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class InitArgs
		{
			public readonly UpdateLoopSetting updateLoopSetting;

			public readonly gQgddHFyNfVGfPIXZPBcuigOMkbz connectionType;

			public readonly int minAxisValue;

			public readonly int maxAxisValue;

			public readonly int hatZeroValue;

			public readonly int hatSpan;

			public readonly IHIDDevice hidDevice;

			public InitArgs(UpdateLoopSetting P_0, gQgddHFyNfVGfPIXZPBcuigOMkbz P_1, int P_2, int P_3, int P_4, int P_5, IHIDDevice P_6)
			{
			}
		}

		public OLAxjmdqJbHeCArvVCNIDgdBciXE[] axes;

		public jIFGialkYdAmDDAGsjKrXJoDparB[] buttons;

		public cqHyUHXvbVNypcmuagNrSpCNtoPi[] hats;

		public JIxBNLfOAPhdPBxkKRDEqbmYHLnib[] accelerometers;

		public XeuQUxbgIYfXehYWxYnOrZfhgALkA[] gyroscopes;

		public hwDBnDzZlOwqwaLOCXGWdEQuXFFf[] touchpads;

		public OuyedDeYgCfMJhRepxbdANVcvqtM[] vibrationMotors;

		public TlkpubcBJbLfvkJeODXKdsluGNyG[] lights;

		private bool pzeQwQBZZiqBFpNYKAOEBffVUPfWA;

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

		public static DriverType FindDriverId(int vendorId, int productId, IList<EnhancedDeviceSupportDeviceType> exclusions)
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
