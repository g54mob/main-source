using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Config;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
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

			bool WriteSync(bvbVwPMivxlHVYJUjAzbVqMqOlbN outputReport, int timeoutMs);

			void WriteAsync(bvbVwPMivxlHVYJUjAzbVqMqOlbN outputReport, int timeoutMs);

			bool ReadSync(IntPtr buffer, int bytesToRead, int timeoutMs);

			byte[] GetHidFeatureData(byte reportId, int reportLength, int timeoutMs, int retryCount);
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal struct InitArgs
		{
			public readonly UpdateLoopSetting updateLoopSetting;

			public readonly DNNJRJXIFKOeGnMWgZMdzIqFiIcT connectionType;

			public readonly int minAxisValue;

			public readonly int maxAxisValue;

			public readonly int hatZeroValue;

			public readonly int hatSpan;

			public readonly IHIDDevice hidDevice;

			public readonly Action initializedCallback;

			public InitArgs(UpdateLoopSetting P_0, DNNJRJXIFKOeGnMWgZMdzIqFiIcT P_1, int P_2, int P_3, int P_4, int P_5, IHIDDevice P_6, Action P_7)
			{
				updateLoopSetting = default(UpdateLoopSetting);
				connectionType = default(DNNJRJXIFKOeGnMWgZMdzIqFiIcT);
				minAxisValue = 0;
				maxAxisValue = 0;
				hatZeroValue = 0;
				hatSpan = 0;
				hidDevice = null;
				initializedCallback = null;
			}
		}

		public enum DhhHsScUZzvwSgOzQUNhajtmDBWf
		{
			None = 0,
			AsyncInitialization = 1
		}

		private enum zaucRsHnkFNzGdURcSsjocHAJgKtE
		{
			None = 0,
			Initializing = 1,
			Initialized = 2,
			Error = 3
		}

		public tOjFUeCIyWcjxtFkwuCXUdeWLAUo[] axes;

		public CxzqXiKayteaZsUXTgjFWsLAhJhGA[] buttons;

		public XhqEGLaAzwtYSBQdLsisLlGSBGGl[] hats;

		public qWvLJUYSyDPoUwthRMHgbgDnFul[] accelerometers;

		public omJTadSTUfHtFlRTSobFSDlwxmMU[] gyroscopes;

		public EWahEPKvarCbHRiElXgHuZAhtMQj[] touchpads;

		public zTLDRFpQqruuaEerYwtaLpPfDEmdA[] vibrationMotors;

		public uMZPhrBuBYlxGLHljPeZqSphwTbH[] lights;

		private zaucRsHnkFNzGdURcSsjocHAJgKtE tgcIpAHfhedFHngqDVKyJvwCFGWR;

		private DhhHsScUZzvwSgOzQUNhajtmDBWf ABpjjXqOdgYEhtOfyEmDhmMBbRDU;

		private InitArgs BbvVFEhcyXiAaplcPAcNsQmHKLBu;

		[CompilerGenerated]
		private Action<DhhHsScUZzvwSgOzQUNhajtmDBWf> cMhDStRjRqPTRKLqZSTPPYZIFznG;

		[CompilerGenerated]
		private Action UmMrhhOcBgTbKYEUxYCYFBeFaIHX;

		private bool GhXwYKsnZHiveUkPzRELoLjUTxks;

		public int AxisCount => 0;

		public int ButtonCount => 0;

		public int HatCount => 0;

		public int AccelerometerCount => 0;

		public int GyroscopeCount => 0;

		public int TouchpadCount => 0;

		public int LightCount => 0;

		public int VibrationMotorCount => 0;

		public bool IsInitialized => false;

		public DhhHsScUZzvwSgOzQUNhajtmDBWf Errors => default(DhhHsScUZzvwSgOzQUNhajtmDBWf);

		protected InitArgs initArgs => default(InitArgs);

		protected bool disposed => false;

		public event Action<DhhHsScUZzvwSgOzQUNhajtmDBWf> ErrorEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action InitializedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected HIDDeviceDriver(InitArgs P_0)
		{
		}

		public abstract void Update(UpdateLoopType updateLoop);

		public abstract bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp);

		public abstract Controller.Extension CreateControllerExtension();

		private void JNDoBLcyhkmaGIdSkBZPSafzuTmG()
		{
		}

		protected abstract void OnInitialize();

		protected void InitializationFinished(bool initialized)
		{
		}

		protected void Error(DhhHsScUZzvwSgOzQUNhajtmDBWf error)
		{
		}

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

		public static bool IsCriticalError(DhhHsScUZzvwSgOzQUNhajtmDBWf errors)
		{
			return false;
		}
	}
}
