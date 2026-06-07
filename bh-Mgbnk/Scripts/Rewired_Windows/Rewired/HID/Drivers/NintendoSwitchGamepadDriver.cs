using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		protected enum TcyrPLPfzGgITAruLwqcettRbltv
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class lSlfWqNcBNTEzYnePjZAnPiaDhQG
		{
			private tudIoPOAEDmqsLLiFPEYXeUodAYW UnJtchmTktKOAWETiifKcXKyHylV;

			private jnLEXiChHTfgKGUsPaOnLAMMfUunA xQgCRjTxdWqLkecGYfYGwmMWgjlKA;

			private float dJRePPZbYeZIlzuCxVjcliLxKKWB;

			private double flUwJLlRIslaUXBglOKCgDZVaXIC;

			public jnLEXiChHTfgKGUsPaOnLAMMfUunA OgxlbfZqJsqLNIdeilvUHBZRvbff => default(jnLEXiChHTfgKGUsPaOnLAMMfUunA);

			public lSlfWqNcBNTEzYnePjZAnPiaDhQG(tudIoPOAEDmqsLLiFPEYXeUodAYW P_0)
			{
			}

			public void uBsVWEMcaZdHPSeGFgbmFJPOEbnu(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
			}

			public void yAkcoAkKeSRguJFNLIuZPonBioqnA(double P_0)
			{
			}

			public void niiLzjxGktRClZcxOvqMmmlYrjHB()
			{
			}

			public void bKcmXITbWcXVdzluNlFvfNJUTpIE()
			{
			}
		}

		protected struct jnLEXiChHTfgKGUsPaOnLAMMfUunA
		{
			public const int JiofQpJtFbjmxtQOwjbxjGUcTsoxB = 160;

			public const int mCrxiUpDdWfeBfMBFqCgEABjMGnf = 320;

			public float BMSdeNlBAjZDduKVtgnzARfwLyru;

			public float yxbPrSntYtBuEEcXipoVRZGhsmuo;

			public float aSppQvQoEkhMgdxVsHIgwgUAaEpW;

			public float XHlQuUiRCHxbUbBhHoxKplxEwCFi;

			internal jnLEXiChHTfgKGUsPaOnLAMMfUunA(float P_0, float P_1, float P_2, float P_3)
			{
				BMSdeNlBAjZDduKVtgnzARfwLyru = 0f;
				yxbPrSntYtBuEEcXipoVRZGhsmuo = 0f;
				aSppQvQoEkhMgdxVsHIgwgUAaEpW = 0f;
				XHlQuUiRCHxbUbBhHoxKplxEwCFi = 0f;
			}

			public static jnLEXiChHTfgKGUsPaOnLAMMfUunA tKnSQIuHUzQtBDPxmGOKNHYyQmrs()
			{
				return default(jnLEXiChHTfgKGUsPaOnLAMMfUunA);
			}

			public override string ToString()
			{
				return null;
			}
		}

		private struct IJCDGwaUnZjoCnuWhUPRMrwFNEXC
		{
			public byte PZrGxeUqFcfJSbZkFMsTMYbPCosdb;

			public byte[] IPofAKjOIemYyiafmUUYjgMIFtaAA;

			public int WIJvhwypuzxNzpHeQAvxCKBHcpSp;

			public IJCDGwaUnZjoCnuWhUPRMrwFNEXC(byte P_0, byte[] P_1, int P_2)
			{
				PZrGxeUqFcfJSbZkFMsTMYbPCosdb = 0;
				IPofAKjOIemYyiafmUUYjgMIFtaAA = null;
				WIJvhwypuzxNzpHeQAvxCKBHcpSp = 0;
			}
		}

		protected class IWHIwelovzjgYbNkzspktfxZGJUF
		{
			public ushort fFSsIaEqZxoAtshJONKAcOeCSGiG;

			public ushort nLZTkKiAhvJtezdnFSzLJSXnHqBL;

			public ushort IJRmMAfqTcjwPcBnZhOifPVMkWXx;

			public ushort vyZkqPeGrsJKcskaQlvcJXGcYxnK;

			public override string ToString()
			{
				return null;
			}
		}

		protected const byte INPUT_REPORT_ID = 33;

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

		protected readonly TcyrPLPfzGgITAruLwqcettRbltv _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice agdAUrOskycecJHYieJdannkwlTjb;

		private readonly HIDProperties cXetojNJCijVTfpMOfTwGFFBWEAL;

		private readonly bool fXDdrjUskIGypVdPQgMhiIVvCeZpA;

		private readonly NativeBuffer mlWZARlfUoYCMLkDaVlKXkxrVlYs;

		private readonly NativeBuffer qhzeVzBTSrDGcGTpeQeyciMBAuyz;

		private readonly NativeBuffer iFomqbBcoDLzLFihMCeVjkaxFpjn;

		private readonly byte[] ByRJeUoLumshLYxReMTOAhWeYGOL;

		private readonly NativeBuffer XXfVXtDscQeZYALbvBjzMHeWIyX;

		private readonly NativeBuffer OkPgmsTBqXHbrZMPQFtIdSstqZFt;

		private ndPzSZhFNVeBDFDFsrPPRfBbUpJt AbAdUSRKPDZpgpnDmPVvtToVeyk;

		private double vTXkqhdynadjbHorjAgDhQvmViVJ;

		private byte jjiAvWXoXNGlOxumlvTsCxBnkKGR;

		private double qLwEQxpbMfCKDKsoYWAbudHojCyGA;

		private bool RyvduUgDcJCKtVuNqaDTUFHyFrVr;

		private bool IEHeSyDCfDkAOlJEYwWzahfclqIiA;

		private lSlfWqNcBNTEzYnePjZAnPiaDhQG[] WGkBqYjiLemafvXZEDbfbpxuCtvGA;

		private IWHIwelovzjgYbNkzspktfxZGJUF[] NWrVVLBDUcAGcAigaTUlvYWEMyDA;

		private static readonly byte[] FKMAGstMGiOAVpxUiErqgasiFEOt;

		public int vibrationMotorCount => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

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

		private void BLwvAnLOGykuTMAUMGYabAAqAXNNA(int P_0)
		{
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, TcyrPLPfzGgITAruLwqcettRbltv P_1, int P_2, int P_3, int P_4)
		{
		}

		protected void Initialize()
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(GLNYbQuaOXeaSToXMWjUhtXAplaf[] elements, NativeBuffer inputReport, double timestamp);

		private bool yLHMsUuIihuDprnoMjEyDEYeZdTR(IJCDGwaUnZjoCnuWhUPRMrwFNEXC P_0, byte[] P_1)
		{
			return false;
		}

		private bool UKwfbwNbZEwZmjMGvdWglQQAmfSg(NativeBuffer P_0, byte P_1)
		{
			return false;
		}

		private void iHrNEMpLXQrlxMdKDDHBpjcPctCGA(byte P_0)
		{
		}

		private void WwneIQZBtJQaycWoXrPeejZivjJd(byte P_0, NativeBuffer P_1, int P_2, GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_3)
		{
		}

		private void kmfknKEtuJQiNNkIvWbtOHgtbyCR(NativeBuffer P_0)
		{
		}

		private void jKBsOlSPSVptlYpIKGCzDFNKbLYA(NativeBuffer P_0, int P_1)
		{
		}

		private static void LMuMotnkXZQHvvwEqUPnATYmbpRd(NativeBuffer P_0, int P_1, jnLEXiChHTfgKGUsPaOnLAMMfUunA P_2)
		{
		}

		private static byte LBBXIGLAvnpNTCSLjaltShyZSzWt(float P_0)
		{
			return 0;
		}

		private void wsvvUyLbsXxNgxZjTFACPsjrEMQeA(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
		}

		private bool tMDjasoTiSoGFVtCKUyWeqcoyQkg()
		{
			return false;
		}

		private bool vXeTbwpRCrElMNelOmXdcePtvWAE(bool P_0)
		{
			return false;
		}

		private bool NUvobLICjOdHXqxVnlcejkGCdYnS(byte P_0, byte P_1, byte P_2, byte[] P_3)
		{
			return false;
		}

		private bool DABoxZkCwcatwJyIrgukLCgwHVsMA(GCmaQhFpjWTiwKeLtoDuCusTJlUIb P_0)
		{
			return false;
		}

		private byte DsRPzbcaUIDfkDasQFpqcAKKPFjjb()
		{
			return 0;
		}

		private bool yoeGmlEgXMnkGNQHbzuaFfmhvUzY()
		{
			return false;
		}

		private static void dGqMHpsslQnTZfNTdSrtjVnJkrGk(byte[] P_0, IWHIwelovzjgYbNkzspktfxZGJUF P_1, IWHIwelovzjgYbNkzspktfxZGJUF P_2, bool P_3)
		{
		}

		private static void ZrhBjwjvoBXbBfGtuDmQheweFXREB(byte[] P_0, IWHIwelovzjgYbNkzspktfxZGJUF P_1, IWHIwelovzjgYbNkzspktfxZGJUF P_2)
		{
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, IWHIwelovzjgYbNkzspktfxZGJUF calX, IWHIwelovzjgYbNkzspktfxZGJUF calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = default(ushort);
			calibratedY = default(ushort);
			return false;
		}

		protected IWHIwelovzjgYbNkzspktfxZGJUF GetAxisCalibration(int index)
		{
			return null;
		}

		private void VkIzmSeLHIAkFrTkTNapmiBCaIMcA(bool P_0)
		{
		}

		~NintendoSwitchGamepadDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private static void WizFCMkpfqkHafZcDdMRrzcPHKJJ(NativeBuffer P_0, int P_1)
		{
		}

		private static void fnEkaDvpHwasnPaoYvqpqIVYasHk(byte[] P_0, int P_1)
		{
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
		}
	}
}
