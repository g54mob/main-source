using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum faDBhnAXezgDdtOuoTrZDddzYjdL
		{
			None = 0,
			Success = 1,
			Fail = 2,
			Ready = 3
		}

		private class EGKkTPRfBwfPdHVJGDRIMKvYZroJA : Exception
		{
		}

		private enum LOHQAsYpxUkZTRbCjdSrPrGcBYWdA
		{
			GetUsbStatus = 1
		}

		private delegate bool exGwhRcbGJUpdnBMNjZoJgUHArjkA(uint responseTimeoutMs);

		protected enum JLQITNuLVoGPiJxXEWOqoebWxbLC
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class jcHpcOeSEdsBbHzgOtZgnSYldBqs
		{
			private zTLDRFpQqruuaEerYwtaLpPfDEmdA WDdjspGRYFiAGXTEfqNkewBrNcDcA;

			private jkfSzwlhbhalUBhdCwCZKMDRIdGj lGMUGxiXPetZcpKNXUwaogTLzhHs;

			private float rfzrdXoUXSLBIgjlkvvJnhlguCeU;

			private double pDqLrPIftMZnYKRracicixMIjqoS;

			public jkfSzwlhbhalUBhdCwCZKMDRIdGj MRXGcdCoxOpqBiZrpwByPNAAEjRYA => default(jkfSzwlhbhalUBhdCwCZKMDRIdGj);

			public bool IeOYHtQuidDDDnUCnqYfEDUKIdSd => false;

			public jcHpcOeSEdsBbHzgOtZgnSYldBqs(zTLDRFpQqruuaEerYwtaLpPfDEmdA P_0)
			{
			}

			public void gwCFWKxLSnafLDNFMrROfLMEPhHic(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
			}

			public bool wwEfmCdOAwcjeQKWWAAviboUalEK(double P_0)
			{
				return false;
			}

			public void rgIqSrOzeDaNQUVzVfJCyAtVGvLEA()
			{
			}

			public void bDIjrEiYXWcNdaDgOMTNzUMRbTcP()
			{
			}
		}

		protected struct jkfSzwlhbhalUBhdCwCZKMDRIdGj
		{
			public const int TIYHhxKPxNuklLxBjLYXYfHYqpOI = 160;

			public const int ksXniiIlzwOngeXTYPIGKPRuMKLq = 320;

			public float VKautTSVcLTPrnPIeELBABebveHr;

			public float oBicIaQcFDyYVJSDpOrlBLFwuEAD;

			public float qFZdkrJzoKEraJiSlLxOWcHVfGNPA;

			public float XMHKPGHwzvSzUuPcIvMstioDEazFA;

			internal jkfSzwlhbhalUBhdCwCZKMDRIdGj(float P_0, float P_1, float P_2, float P_3)
			{
				VKautTSVcLTPrnPIeELBABebveHr = 0f;
				oBicIaQcFDyYVJSDpOrlBLFwuEAD = 0f;
				qFZdkrJzoKEraJiSlLxOWcHVfGNPA = 0f;
				XMHKPGHwzvSzUuPcIvMstioDEazFA = 0f;
			}

			public static jkfSzwlhbhalUBhdCwCZKMDRIdGj zmJcZERKmThQNMiwfDyiVNLxniLo()
			{
				return default(jkfSzwlhbhalUBhdCwCZKMDRIdGj);
			}

			public override string ToString()
			{
				return null;
			}
		}

		private struct IKonOyBAuhqhCgIfmuwjIwmUsNxx
		{
			public byte TRDoeqnmdWBKUYEtESQzQekWwtSG;

			public byte[] IYCVtGWfaUGSolWuvkmcraXVxsWK;

			public int UilcqqXHIZQZneprNCJDAjQUErqhA;

			public IKonOyBAuhqhCgIfmuwjIwmUsNxx(byte P_0, byte[] P_1, int P_2)
			{
				TRDoeqnmdWBKUYEtESQzQekWwtSG = 0;
				IYCVtGWfaUGSolWuvkmcraXVxsWK = null;
				UilcqqXHIZQZneprNCJDAjQUErqhA = 0;
			}
		}

		protected class SvpADgkYLJKjYAahkoSQFdgMDSsRA
		{
			public ushort sywIOTxpYSVMoaXrLSHvNeQNgLLDA;

			public ushort tUAEGcJlyhlVrYGEPeBZisERLIvV;

			public ushort MqGNlgZqMBVJNeWkhMOerDQxUrnT;

			public ushort gdAiDJkYOfqjBExBVcTwgxzpaSVS;

			public override string ToString()
			{
				return null;
			}
		}

		private const uint KHdGmukTGWyHXfWZElpkhQICXhhNA = 40u;

		private const float gzbPAIdANJllJWGStxQuaygMYqWi = 0.025f;

		protected const byte INPUT_REPORT_ID_DEFAULT = 48;

		protected const byte INPUT_REPORT_ID_RESPONSE = 33;

		protected const byte OUTPUT_REPORT_COMMAND_GET_INPUT = 31;

		protected const byte OUTPUT_RUMBLE_AND_SUBCMD = 1;

		protected const byte OUTPUT_FW_UPDATE_PKT = 3;

		protected const byte OUTPUT_RUMBLE_ONLY = 16;

		protected const byte OUTPUT_MCU_DATA = 17;

		protected const byte OUTPUT_USB_CMD = 128;

		protected const byte SUBCMD_STATE = 0;

		protected const byte SUBCMD_MANUAL_BT_PAIRING = 1;

		protected const byte SUBCMD_REQ_DEV_INFO = 2;

		protected const byte SUBCMD_SET_REPORT_MODE = 3;

		protected const byte SUBCMD_TRIGGERS_ELAPSED = 4;

		protected const byte SUBCMD_GET_PAGE_LIST_STATE = 5;

		protected const byte SUBCMD_SET_HCI_STATE = 6;

		protected const byte SUBCMD_RESET_PAIRING_INFO = 7;

		protected const byte SUBCMD_LOW_POWER_MODE = 8;

		protected const byte SUBCMD_SPI_FLASH_READ = 16;

		protected const byte SUBCMD_SPI_FLASH_WRITE = 17;

		protected const byte SUBCMD_RESET_MCU = 32;

		protected const byte SUBCMD_SET_MCU_CONFIG = 33;

		protected const byte SUBCMD_SET_MCU_STATE = 34;

		protected const byte SUBCMD_SET_PLAYER_LIGHTS = 48;

		protected const byte SUBCMD_GET_PLAYER_LIGHTS = 49;

		protected const byte SUBCMD_SET_HOME_LIGHT = 56;

		protected const byte SUBCMD_ENABLE_IMU = 64;

		protected const byte SUBCMD_SET_IMU_SENSITIVITY = 65;

		protected const byte SUBCMD_WRITE_IMU_REG = 66;

		protected const byte SUBCMD_READ_IMU_REG = 67;

		protected const byte SUBCMD_ENABLE_VIBRATION = 72;

		protected const byte SUBCMD_GET_REGULATED_VOLTAGE = 80;

		protected const byte INPUT_BUTTON_EVENT = 63;

		protected const byte INPUT_SUBCMD_REPLY = 33;

		protected const byte INPUT_IMU_DATA = 48;

		protected const byte INPUT_MCU_DATA = 49;

		protected const byte INPUT_USB_RESPONSE = 129;

		protected const byte FEATURE_LAST_SUBCMD = 2;

		protected const byte FEATURE_OTA_FW_UPGRADE = 112;

		protected const byte FEATURE_SETUP_MEM_READ = 113;

		protected const byte FEATURE_MEM_READ = 114;

		protected const byte FEATURE_ERASE_MEM_SECTOR = 115;

		protected const byte FEATURE_MEM_WRITE = 116;

		protected const byte FEATURE_LAUNCH = 117;

		protected const byte USB_CMD_CONN_STATUS = 1;

		protected const byte USB_CMD_HANDSHAKE = 2;

		protected const byte USB_CMD_BAUDRATE_3M = 3;

		protected const byte USB_CMD_NO_TIMEOUT = 4;

		protected const byte USB_CMD_EN_TIMEOUT = 5;

		protected const byte USB_RESET = 6;

		protected const byte USB_PRE_HANDSHAKE = 145;

		protected const byte USB_SEND_UART = 146;

		protected const ushort CAL_DATA_START = 24637;

		protected const ushort CAL_DATA_END = 24654;

		protected const ushort CAL_DATA_SIZE = 18;

		protected const int MIN_INPUT_REPORT_SIZE = 49;

		protected const int SUBCOMMAND_INPUT_REPORT_SIZE = 49;

		protected const float VIBRATION_FREQUENCY_LOW_MIN = 40.875885f;

		protected const float VIBRATION_FREQUENCY_LOW_MAX = 626.28613f;

		protected const float VIBRATION_FREQUENCY_HIGH_MIN = 81.75177f;

		protected const float VIBRATION_FREQUENCY_HIGH_MAX = 1252.5723f;

		protected const float NOINPUTREPORT_REINIT_HACK_TIMEOUT_SEC = 1f;

		protected const int DEVICE_POLL_RATE_HZ = 66;

		protected const int HID_AXIS_MIN_VALUE = 0;

		protected const int HID_AXIS_MAX_VALUE = 65535;

		protected const int HID_AXIS_ZERO_VALUE = 32767;

		protected const int HID_AXIS_BITS = 16;

		protected const int HID_AXIS_BYTES = 2;

		private const int rZIFSdVJgwDenQCUhPeIvktGAFEw = 4;

		private const string yjMemSCBMIEhGXtARAMJidJLSsUc = "Failed to allocate memory.";

		protected readonly JLQITNuLVoGPiJxXEWOqoebWxbLC _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice qrNVSlnWWCwNoCkBzvAFnbkdexhP;

		private readonly HIDProperties arIDwtuHgQLpXafJHLFAYrKWAWmgA;

		private readonly bool bTlTihnyYcijnQbKXFeZApMcpclx;

		private readonly NativeBuffer kMsNwNSvmKUqEWuGnRswVKswzesk;

		private readonly NativeBuffer sNVIJnaJsVOMcFfelAEWoxHCawIJ;

		private readonly NativeBuffer ePWbGxwIErrlDIiKFIWphzekdRNE;

		private readonly byte[] DQvdSYZAgQvQFNSabaDyKEPdAKcl;

		private readonly NativeBuffer LorrETUhOYgRTBXOydwZfJKpCsAf;

		private readonly NativeBuffer CofZfgacCxrvfWuOFHRkdCvcoFxn;

		private bvbVwPMivxlHVYJUjAzbVqMqOlbN IsZRNUrmyvkBtdfqIUExboWzVXET;

		private byte jiCYeIocxlNzEwpjotvCCnOsMGqN;

		private bool RHIjUWWGiMjOEdaVnIxFYtAGUKIeA;

		private jcHpcOeSEdsBbHzgOtZgnSYldBqs[] EkCvhOGMtScelaeWVOHPYdythlXBb;

		private SvpADgkYLJKjYAahkoSQFdgMDSsRA[] HPuRcDoOryWOUpGhvLjkjHPByKON;

		private double msGHFZusXZifOzcUFWyyBndFjsSG;

		private ManualResetEvent rwuAtdEzMtcGllGjXNjPfeuEdCGhB;

		private faDBhnAXezgDdtOuoTrZDddzYjdL XRnrXSMKSEcBCrLaAptCtdoDzOIi;

		private const int khCDaCnFZbmVwwTspJGpHXhPHaWs = 100;

		private Dictionary<int, exGwhRcbGJUpdnBMNjZoJgUHArjkA> ttsYyYYBMqNQAqwtrmDuqUDrUIk;

		public int vibrationMotorCount => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		private Dictionary<int, exGwhRcbGJUpdnBMNjZoJgUHArjkA> initializationCommands => null;

		public void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			amplitudeLow = default(float);
			frequencyLow = default(float);
			amplitudeHigh = default(float);
			frequencyHigh = default(float);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
		}

		public void StopVibration(int motorIndex)
		{
		}

		public void StopVibration()
		{
		}

		private void StopVibration(ApGJLxYzFsobivPGgnsYkhrKhjyh asyncMode)
		{
		}

		private void VFQbZtyzoUCgDDiRFDmSJMPdyRjwA(int P_0)
		{
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, JLQITNuLVoGPiJxXEWOqoebWxbLC P_1, int P_2, int P_3, int P_4)
			: base(default(InitArgs))
		{
		}

		protected override void OnInitialize()
		{
		}

		private faDBhnAXezgDdtOuoTrZDddzYjdL xLxadxBezarBtGiahiyIcJRIlAyH()
		{
			return default(faDBhnAXezgDdtOuoTrZDddzYjdL);
		}

		private bool TXxwtivXNzoxUEkryhcxrggMDecEA(LOHQAsYpxUkZTRbCjdSrPrGcBYWdA P_0, uint P_1, uint P_2)
		{
			return false;
		}

		private bool LJeXdOedfiQbipJtngIidIypzOBMA(uint P_0)
		{
			return false;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(MdziBGNqephqKFAONQgipbAHplCzA[] elements, NativeBuffer inputReport, double timestamp);

		private bool PnZnmowqXACIrcQkfRLarfyvjSgP(IKonOyBAuhqhCgIfmuwjIwmUsNxx P_0, byte[] P_1, Action P_2)
		{
			return false;
		}

		private bool MDUIuaoMvgceiaoPesHCrpXJRugSA(NativeBuffer P_0, byte P_1)
		{
			return false;
		}

		private void wiNqWIrGEvcyJKVdoHeZAdnmcxqI(NativeBuffer P_0)
		{
		}

		private void zDrqlShqpjeltJJyNAakBpMWejzDA(NativeBuffer P_0, int P_1)
		{
		}

		private static void DBWlZfKRGrfUxeRrvWwLUDUhXbdr(NativeBuffer P_0, int P_1, jkfSzwlhbhalUBhdCwCZKMDRIdGj P_2)
		{
		}

		private static byte DWpHhIegZJHZFDNKqdJNMYrGltgK(float P_0)
		{
			return 0;
		}

		private void CyXIPwTJDfARjIMagOkPCVZWFBIKA(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
		}

		private bool MatqUSRfxGWcsXUlvgrtUeflmFLj(Action P_0)
		{
			return false;
		}

		private bool rQTkBMetmfmtUmkOudZFvRFxJoSS(bool P_0, Action P_1)
		{
			return false;
		}

		private bool hojOBNrySYUEjYOawEOAPAACvhlb(byte P_0, byte P_1, byte P_2, byte[] P_3, Action P_4)
		{
			return false;
		}

		private bool HUnsDOZEAIraDrHpcMWTMdgxROoB(ApGJLxYzFsobivPGgnsYkhrKhjyh P_0)
		{
			return false;
		}

		private byte FCbmzyDmNubabGvOZLKQMXbZTZXB()
		{
			return 0;
		}

		private bool uVNbONDAZPPZKJClAXaYptjSDnts(Action P_0)
		{
			return false;
		}

		private static void boUUfnRPioXDVkQugFbThcyQeYaj(byte[] P_0, SvpADgkYLJKjYAahkoSQFdgMDSsRA P_1, SvpADgkYLJKjYAahkoSQFdgMDSsRA P_2, bool P_3)
		{
		}

		private static void JaFyMeIcMvfrDXxebHWuuofYgDvr(byte[] P_0, SvpADgkYLJKjYAahkoSQFdgMDSsRA P_1, SvpADgkYLJKjYAahkoSQFdgMDSsRA P_2)
		{
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, SvpADgkYLJKjYAahkoSQFdgMDSsRA calX, SvpADgkYLJKjYAahkoSQFdgMDSsRA calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = default(ushort);
			calibratedY = default(ushort);
			return false;
		}

		protected SvpADgkYLJKjYAahkoSQFdgMDSsRA GetAxisCalibration(int index)
		{
			return null;
		}

		private void DHcadSPrbeuePiYhEmMLoJIRGEgy(bool P_0)
		{
		}

		~NintendoSwitchGamepadDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private static NativeBuffer WDhRrOzWTqqdHXVzICrtAnLsgqmK(int P_0)
		{
			return null;
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLogWarning(object msg)
		{
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLogError(object msg)
		{
		}

		[Conditional("DEBUG_THIS_DISPOSE")]
		protected static void DDisposeLog(object msg)
		{
		}

		[CompilerGenerated]
		private void mhvPtnvoEJmwPBRAvFPjHQKbEEvT()
		{
		}

		[CompilerGenerated]
		private void BBWjZFGzZKACPtnCAkSFnZIAeiUc()
		{
		}
	}
}
