using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Rewired.ControllerExtensions;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDisposable, IHIDControllerExtension, IControllerDriver, IDriver_NintendoSwitchController
	{
		protected enum RBOSFYcFMxSplZbDyfFnHXSWynIJ
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class vhRhmVkWVokXJJBKkYsZKyyhbUdq
		{
			private pmTlTYxlhgTeYOMZqBSNaIrfQJzO JetMiyaZCSrbRsSaNFNevlZjCehE;

			private dRjQknpDekEqiNfBoFNyfpnXHLLHb AYJvKiFBKRIuBquKoAftKouPBTFu;

			private float kmAWUGANIFvwLFVjpRXInXZWaxeR;

			private double XSNaaIBnNtpZRWtVwaFfsUaJBUaAb;

			public dRjQknpDekEqiNfBoFNyfpnXHLLHb vLlHrmnGGJSZXlWTFWaAmxkRefQH => AYJvKiFBKRIuBquKoAftKouPBTFu;

			public vhRhmVkWVokXJJBKkYsZKyyhbUdq(pmTlTYxlhgTeYOMZqBSNaIrfQJzO P_0)
			{
				JetMiyaZCSrbRsSaNFNevlZjCehE = P_0;
				sbvNiOKcscCGRBGGcMbdhHrjtptuB();
			}

			public void TBPPzgWuguKbGbwgzGoaAckRXMzv(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
				if (P_4 < 0f)
				{
					P_4 = 0f;
				}
				kmAWUGANIFvwLFVjpRXInXZWaxeR = P_4;
				AYJvKiFBKRIuBquKoAftKouPBTFu.JbOxirejHUdfXpuOcWyppaDJhnUAA = MathTools.Clamp01(P_0);
				AYJvKiFBKRIuBquKoAftKouPBTFu.cHvqTfeaNRHDrEdgZAXCKhoTMnEPA = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
				AYJvKiFBKRIuBquKoAftKouPBTFu.uislqOBWcEwkbYJVFNqYflOFfmbJA = MathTools.Clamp01(P_2);
				AYJvKiFBKRIuBquKoAftKouPBTFu.EWbmrShCneesPQBuwwgDPhTNoFWy = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
				JetMiyaZCSrbRsSaNFNevlZjCehE.EFmUVEpUcrIwRWHZCDJnLnIbiwvAA = Math.Max(AYJvKiFBKRIuBquKoAftKouPBTFu.JbOxirejHUdfXpuOcWyppaDJhnUAA, AYJvKiFBKRIuBquKoAftKouPBTFu.uislqOBWcEwkbYJVFNqYflOFfmbJA);
				XSNaaIBnNtpZRWtVwaFfsUaJBUaAb = ReInput.realTime;
			}

			public void mefhGqvTkcrETnFSidhNngFjAYNV(double P_0)
			{
				if ((AYJvKiFBKRIuBquKoAftKouPBTFu.JbOxirejHUdfXpuOcWyppaDJhnUAA > 0f || AYJvKiFBKRIuBquKoAftKouPBTFu.uislqOBWcEwkbYJVFNqYflOFfmbJA > 0f) && kmAWUGANIFvwLFVjpRXInXZWaxeR > 0f && P_0 >= XSNaaIBnNtpZRWtVwaFfsUaJBUaAb + (double)kmAWUGANIFvwLFVjpRXInXZWaxeR)
				{
					gyoMWQMegzAgtBmlxsywuLqQdxfs();
				}
			}

			public void gyoMWQMegzAgtBmlxsywuLqQdxfs()
			{
				AYJvKiFBKRIuBquKoAftKouPBTFu.uislqOBWcEwkbYJVFNqYflOFfmbJA = 0f;
				AYJvKiFBKRIuBquKoAftKouPBTFu.JbOxirejHUdfXpuOcWyppaDJhnUAA = 0f;
				JetMiyaZCSrbRsSaNFNevlZjCehE.WPYNyFAdjBraRLgEqCcHbcfbsIkf = 0;
				kmAWUGANIFvwLFVjpRXInXZWaxeR = 0f;
				XSNaaIBnNtpZRWtVwaFfsUaJBUaAb = ReInput.realTime;
			}

			public void sbvNiOKcscCGRBGGcMbdhHrjtptuB()
			{
				AYJvKiFBKRIuBquKoAftKouPBTFu = dRjQknpDekEqiNfBoFNyfpnXHLLHb.slaemGzHKYWMylDIxBuXEinKYiIkA();
				JetMiyaZCSrbRsSaNFNevlZjCehE.WPYNyFAdjBraRLgEqCcHbcfbsIkf = 0;
				kmAWUGANIFvwLFVjpRXInXZWaxeR = 0f;
				XSNaaIBnNtpZRWtVwaFfsUaJBUaAb = 0.0;
			}
		}

		protected struct dRjQknpDekEqiNfBoFNyfpnXHLLHb
		{
			public const int HBXprrqXOykKCCMZRmsZjQQhFwOg = 160;

			public const int lFgVYxECGyozSQSpMbfHIdXrWDuE = 320;

			public float JbOxirejHUdfXpuOcWyppaDJhnUAA;

			public float cHvqTfeaNRHDrEdgZAXCKhoTMnEPA;

			public float uislqOBWcEwkbYJVFNqYflOFfmbJA;

			public float EWbmrShCneesPQBuwwgDPhTNoFWy;

			internal dRjQknpDekEqiNfBoFNyfpnXHLLHb(float P_0, float P_1, float P_2, float P_3)
			{
				if (P_0 < 0f)
				{
					P_0 = 0f;
				}
				if (P_0 > 1f)
				{
					P_0 = 1f;
				}
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				if (P_2 < 0f)
				{
					P_2 = 0f;
				}
				if (P_2 > 1f)
				{
					P_2 = 1f;
				}
				if (P_3 < 0f)
				{
					P_3 = 0f;
				}
				JbOxirejHUdfXpuOcWyppaDJhnUAA = P_0;
				cHvqTfeaNRHDrEdgZAXCKhoTMnEPA = P_1;
				uislqOBWcEwkbYJVFNqYflOFfmbJA = P_2;
				EWbmrShCneesPQBuwwgDPhTNoFWy = P_3;
			}

			public static dRjQknpDekEqiNfBoFNyfpnXHLLHb slaemGzHKYWMylDIxBuXEinKYiIkA()
			{
				return new dRjQknpDekEqiNfBoFNyfpnXHLLHb(0f, 160f, 0f, 320f);
			}

			public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
			{
				return "amplitudeLow: " + JbOxirejHUdfXpuOcWyppaDJhnUAA + ", frequencyLow: " + cHvqTfeaNRHDrEdgZAXCKhoTMnEPA + ", amplitudeHigh: " + uislqOBWcEwkbYJVFNqYflOFfmbJA + ", frequencyHigh: " + EWbmrShCneesPQBuwwgDPhTNoFWy;
			}
		}

		private struct WvyfItRwfgjjewTNGJUMbhOAiGmx
		{
			public byte pCjknWwlaIJLHwjePFchOZkzQHZb;

			public byte[] EFpHrsFLouNlEgYqRjLITLMXDVui;

			public int PcWZZSNcuQUTGXVZgHeVmiaFKODg;

			public WvyfItRwfgjjewTNGJUMbhOAiGmx(byte P_0, byte[] P_1, int P_2)
			{
				pCjknWwlaIJLHwjePFchOZkzQHZb = P_0;
				EFpHrsFLouNlEgYqRjLITLMXDVui = P_1;
				PcWZZSNcuQUTGXVZgHeVmiaFKODg = P_2;
			}
		}

		protected class YNdtRzAeIGadeeeLIrtlIEEQRRlqA
		{
			public ushort mrSAzxsQiDtfXLIluTRYiLWfvhLF;

			public ushort NEvCnncHbQKszkADGizKaJUbnsKiB;

			public ushort IUUzTmjCPEKDPkZEmDQDohahvfoi;

			public ushort jxgXMQCEnQBUXcakUkMlAeOGxhXqb;

			public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
			{
				return "min: " + mrSAzxsQiDtfXLIluTRYiLWfvhLF + ", max: " + NEvCnncHbQKszkADGizKaJUbnsKiB + ", zero: " + IUUzTmjCPEKDPkZEmDQDohahvfoi + ", deadzone: " + jxgXMQCEnQBUXcakUkMlAeOGxhXqb;
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

		protected readonly RBOSFYcFMxSplZbDyfFnHXSWynIJ _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice ZdGAobiSJtgKVSSufZEKkbWOqrot;

		private readonly HIDProperties wZOmWuPOIaODgUnRVvZwyhfFATbk;

		private readonly bool urBDemPOotqBqeojOrfYeWijKhII;

		private readonly NativeBuffer WynDIcPUQZuoNwMFNYtngVTThDLT;

		private readonly NativeBuffer HuOJQfTacspCpPwKDklzixhSDESC;

		private readonly NativeBuffer kHjZihffHiYcXtMQEhbkVLnNlNIF;

		private readonly byte[] rCQeOCMEIryWeHkoprZEHDAZGbTo;

		private readonly NativeBuffer seQHPoApwTevktEYhtyRqoYViUINA;

		private readonly NativeBuffer oZFqElwImDICfrfemnqkDVkLqlAj;

		private xDlFkKEEsqHDzeOiaTIGueyqTccYA OdRhINdCygWtgcGOteXZfFdHmxobc;

		private double iAHdCJjEeWlkazTKRxRaHgBLEEnB;

		private byte rFrLcvOzLyXnQernkfSYqWfbePHb;

		private double EnjrZOCsbGPvcYSaFtRkMhiNpjIt;

		private bool jTgDGWADqAcTFEcrCvwAGnNcUXhmd;

		private bool vzsCKgEyOZYnMHSYbeEpEieJXjoE;

		private vhRhmVkWVokXJJBKkYsZKyyhbUdq[] XUzITuLNarqLEmJSnNmiuuhgeLoK;

		private YNdtRzAeIGadeeeLIrtlIEEQRRlqA[] hnwrbTfsutlfAaoyZbMzVnONIjycA;

		private static readonly byte[] gbmNIRngXQpRFksxABGGqAGyblAf = new byte[8] { 0, 1, 64, 64, 0, 1, 64, 64 };

		public int vibrationMotorCount => _vibrationMotorCount;

		ushort IHIDControllerExtension.vendorId => wZOmWuPOIaODgUnRVvZwyhfFATbk.vendorId;

		ushort IHIDControllerExtension.productId => wZOmWuPOIaODgUnRVvZwyhfFATbk.productId;

		string IHIDControllerExtension.productName => wZOmWuPOIaODgUnRVvZwyhfFATbk.productName;

		string IHIDControllerExtension.manufacturer => wZOmWuPOIaODgUnRVvZwyhfFATbk.manufacturer;

		ushort IHIDControllerExtension.usagePage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usagePage;

		ushort IHIDControllerExtension.usage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usage;

		public void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			if (motorIndex < 0 || motorIndex >= _vibrationMotorCount)
			{
				amplitudeLow = 0f;
				frequencyLow = 0f;
				amplitudeHigh = 0f;
				frequencyHigh = 0f;
			}
			else
			{
				dRjQknpDekEqiNfBoFNyfpnXHLLHb dRjQknpDekEqiNfBoFNyfpnXHLLHb2 = XUzITuLNarqLEmJSnNmiuuhgeLoK[motorIndex].vLlHrmnGGJSZXlWTFWaAmxkRefQH;
				amplitudeLow = dRjQknpDekEqiNfBoFNyfpnXHLLHb2.JbOxirejHUdfXpuOcWyppaDJhnUAA;
				frequencyLow = dRjQknpDekEqiNfBoFNyfpnXHLLHb2.cHvqTfeaNRHDrEdgZAXCKhoTMnEPA;
				amplitudeHigh = dRjQknpDekEqiNfBoFNyfpnXHLLHb2.uislqOBWcEwkbYJVFNqYflOFfmbJA;
				frequencyHigh = dRjQknpDekEqiNfBoFNyfpnXHLLHb2.EWbmrShCneesPQBuwwgDPhTNoFWy;
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
			{
				if (stopOtherMotors)
				{
					QbqjJLisnRMflhdLfmqglWCqEAHlc(motorIndex);
				}
				XUzITuLNarqLEmJSnNmiuuhgeLoK[motorIndex].TBPPzgWuguKbGbwgzGoaAckRXMzv(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
			}
		}

		public void StopVibration(int motorIndex)
		{
			if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
			{
				XUzITuLNarqLEmJSnNmiuuhgeLoK[motorIndex].gyoMWQMegzAgtBmlxsywuLqQdxfs();
			}
		}

		public void StopVibration()
		{
			for (int i = 0; i < _vibrationMotorCount; i++)
			{
				XUzITuLNarqLEmJSnNmiuuhgeLoK[i].gyoMWQMegzAgtBmlxsywuLqQdxfs();
			}
		}

		private void QbqjJLisnRMflhdLfmqglWCqEAHlc(int P_0)
		{
			for (int i = 0; i < XUzITuLNarqLEmJSnNmiuuhgeLoK.Length; i++)
			{
				if (i != P_0)
				{
					XUzITuLNarqLEmJSnNmiuuhgeLoK[i].gyoMWQMegzAgtBmlxsywuLqQdxfs();
				}
			}
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, RBOSFYcFMxSplZbDyfFnHXSWynIJ P_1, int P_2, int P_3, int P_4)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			_controllerType = P_1;
			_buttonCount = P_2;
			_axisCount = P_3;
			_vibrationMotorCount = P_4;
			ZdGAobiSJtgKVSSufZEKkbWOqrot = P_0.hidDevice;
			wZOmWuPOIaODgUnRVvZwyhfFATbk = P_0.hidDevice.properties;
			urBDemPOotqBqeojOrfYeWijKhII = P_0.connectionType == PWHRTOVLUXMumxboQQmQIFMHEBfDA.Bluetooth;
			WynDIcPUQZuoNwMFNYtngVTThDLT = new NativeBuffer(wZOmWuPOIaODgUnRVvZwyhfFATbk.maxInputReportLength);
			HuOJQfTacspCpPwKDklzixhSDESC = new NativeBuffer(wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength);
			kHjZihffHiYcXtMQEhbkVLnNlNIF = new NativeBuffer(32);
			rCQeOCMEIryWeHkoprZEHDAZGbTo = new byte[wZOmWuPOIaODgUnRVvZwyhfFATbk.maxInputReportLength];
			seQHPoApwTevktEYhtyRqoYViUINA = new NativeBuffer(wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength);
			oZFqElwImDICfrfemnqkDVkLqlAj = new NativeBuffer(49);
			if (wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			OdRhINdCygWtgcGOteXZfFdHmxobc = new xDlFkKEEsqHDzeOiaTIGueyqTccYA(HuOJQfTacspCpPwKDklzixhSDESC.Pointer, HuOJQfTacspCpPwKDklzixhSDESC.Length, HuOJQfTacspCpPwKDklzixhSDESC.Length);
			jTgDGWADqAcTFEcrCvwAGnNcUXhmd = !urBDemPOotqBqeojOrfYeWijKhII && UnityTools.effectivePlatform == Platform.Windows;
			ReInput.ApplicationPauseChangedEvent += TNcWPrbERDuIJOeRurmdoMrAbUeN;
			buttons = new UGvkBdUzfogfxagdjdQqdinGSMwv[P_2];
			for (int i = 0; i < P_2; i++)
			{
				buttons[i] = new UGvkBdUzfogfxagdjdQqdinGSMwv(33, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			hnwrbTfsutlfAaoyZbMzVnONIjycA = new YNdtRzAeIGadeeeLIrtlIEEQRRlqA[_axisCount];
			vibrationMotors = new pmTlTYxlhgTeYOMZqBSNaIrfQJzO[P_4];
			for (int j = 0; j < vibrationMotors.Length; j++)
			{
				vibrationMotors[j] = new pmTlTYxlhgTeYOMZqBSNaIrfQJzO(0, 255);
			}
			XUzITuLNarqLEmJSnNmiuuhgeLoK = new vhRhmVkWVokXJJBKkYsZKyyhbUdq[P_4];
			for (int k = 0; k < XUzITuLNarqLEmJSnNmiuuhgeLoK.Length; k++)
			{
				XUzITuLNarqLEmJSnNmiuuhgeLoK[k] = new vhRhmVkWVokXJJBKkYsZKyyhbUdq(vibrationMotors[k]);
			}
		}

		protected void Initialize()
		{
			vzsCKgEyOZYnMHSYbeEpEieJXjoE = false;
			HuOJQfTacspCpPwKDklzixhSDESC.Clear();
			if (!urBDemPOotqBqeojOrfYeWijKhII)
			{
				NativeBuffer huOJQfTacspCpPwKDklzixhSDESC = HuOJQfTacspCpPwKDklzixhSDESC;
				huOJQfTacspCpPwKDklzixhSDESC[0] = 128;
				huOJQfTacspCpPwKDklzixhSDESC[1] = 1;
				if (!aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB connection status.", requiredThreadSafety: true);
					throw new Exception();
				}
				huOJQfTacspCpPwKDklzixhSDESC[0] = 128;
				huOJQfTacspCpPwKDklzixhSDESC[1] = 2;
				if (!aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 1.", requiredThreadSafety: true);
					throw new Exception();
				}
				huOJQfTacspCpPwKDklzixhSDESC[0] = 128;
				huOJQfTacspCpPwKDklzixhSDESC[1] = 3;
				if (!aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB set baudrate.", requiredThreadSafety: true);
					throw new Exception();
				}
				huOJQfTacspCpPwKDklzixhSDESC[0] = 128;
				huOJQfTacspCpPwKDklzixhSDESC[1] = 2;
				if (!aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 2.", requiredThreadSafety: true);
					throw new Exception();
				}
				huOJQfTacspCpPwKDklzixhSDESC[0] = 128;
				huOJQfTacspCpPwKDklzixhSDESC[1] = 4;
				if (!aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB prevent hid timeout.", requiredThreadSafety: true);
					throw new Exception();
				}
			}
			if (!wWEguSFtyAihEbahfITdWcSGHPxDb(new WvyfItRwfgjjewTNGJUMbhOAiGmx(72, new byte[1] { 1 }, 1), rCQeOCMEIryWeHkoprZEHDAZGbTo))
			{
				throw new Exception();
			}
			if (!wWEguSFtyAihEbahfITdWcSGHPxDb(new WvyfItRwfgjjewTNGJUMbhOAiGmx(3, new byte[1] { 48 }, 1), rCQeOCMEIryWeHkoprZEHDAZGbTo))
			{
				throw new Exception();
			}
			FbWgaTMYBkslaYBXqivMsYpqLkgo();
			if (!DwvKwrLVHoiiaQjxxcdZhhpdBoyyA())
			{
				throw new Exception();
			}
			if (jTgDGWADqAcTFEcrCvwAGnNcUXhmd)
			{
				EnjrZOCsbGPvcYSaFtRkMhiNpjIt = ReInput.realTime;
			}
			vzsCKgEyOZYnMHSYbeEpEieJXjoE = true;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			double realTime = ReInput.realTime;
			if (jTgDGWADqAcTFEcrCvwAGnNcUXhmd && realTime >= EnjrZOCsbGPvcYSaFtRkMhiNpjIt + 1.0)
			{
				try
				{
					Initialize();
				}
				catch
				{
					Logger.LogWarning("Error re-initializing Nintendo Switch Pro Controller. Will retry.");
					EnjrZOCsbGPvcYSaFtRkMhiNpjIt = realTime;
				}
			}
			for (int i = 0; i < XUzITuLNarqLEmJSnNmiuuhgeLoK.Length; i++)
			{
				XUzITuLNarqLEmJSnNmiuuhgeLoK[i].mefhGqvTkcrETnFSidhNngFjAYNV(realTime);
			}
			if (realTime >= iAHdCJjEeWlkazTKRxRaHgBLEEnB + 0.01515151560306549)
			{
				iAHdCJjEeWlkazTKRxRaHgBLEEnB = realTime;
				oAkRkKZiDfPztTnFgGLspgqKjlHi(HuOJQfTacspCpPwKDklzixhSDESC);
				aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous);
			}
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (!vzsCKgEyOZYnMHSYbeEpEieJXjoE)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (WynDIcPUQZuoNwMFNYtngVTThDLT.Length < 49)
			{
				return false;
			}
			if (Marshal.ReadByte(inputReportPtr, 0) != 33)
			{
				return false;
			}
			if (jTgDGWADqAcTFEcrCvwAGnNcUXhmd)
			{
				EnjrZOCsbGPvcYSaFtRkMhiNpjIt = ReInput.realTime;
			}
			int numBytesToWrite = Math.Min(inputReportLength, WynDIcPUQZuoNwMFNYtngVTThDLT.Length);
			WynDIcPUQZuoNwMFNYtngVTThDLT.Write(inputReportPtr, inputReportLength, numBytesToWrite);
			UpdateButtons(WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			YszNVDBZreQueMHaxAPTEUkXgqRz[] elements = axes;
			UpdateElements(elements, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			return true;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(YszNVDBZreQueMHaxAPTEUkXgqRz[] elements, NativeBuffer inputReport, double timestamp);

		private bool wWEguSFtyAihEbahfITdWcSGHPxDb(WvyfItRwfgjjewTNGJUMbhOAiGmx P_0, byte[] P_1)
		{
			try
			{
				if (P_0.EFpHrsFLouNlEgYqRjLITLMXDVui.Length + 11 > seQHPoApwTevktEYhtyRqoYViUINA.Length)
				{
					return false;
				}
				oAkRkKZiDfPztTnFgGLspgqKjlHi(seQHPoApwTevktEYhtyRqoYViUINA);
				seQHPoApwTevktEYhtyRqoYViUINA[10] = P_0.pCjknWwlaIJLHwjePFchOZkzQHZb;
				seQHPoApwTevktEYhtyRqoYViUINA.TryWriteBytes(P_0.EFpHrsFLouNlEgYqRjLITLMXDVui, P_0.PcWZZSNcuQUTGXVZgHeVmiaFKODg, 11);
				int num = 2;
				bool flag = false;
				int num2 = 0;
				double num3 = 0.0;
				while (ZdGAobiSJtgKVSSufZEKkbWOqrot.ReadSync(oZFqElwImDICfrfemnqkDVkLqlAj, oZFqElwImDICfrfemnqkDVkLqlAj.Length, 1))
				{
				}
				for (int i = 0; i < num; i++)
				{
					Array.Clear(P_1, 0, P_1.Length);
					oZFqElwImDICfrfemnqkDVkLqlAj.Clear();
					qHNDDiUaWCEcGENoMxaFTeOSxYvA(seQHPoApwTevktEYhtyRqoYViUINA, P_0.pCjknWwlaIJLHwjePFchOZkzQHZb);
					num3 = ReInput.realTime;
					if (i == 0)
					{
						_ = ReInput.realTime;
					}
					int num4 = 0;
					while (!(ReInput.realTime >= num3 + 0.5))
					{
						if (ZdGAobiSJtgKVSSufZEKkbWOqrot.ReadSync(oZFqElwImDICfrfemnqkDVkLqlAj, oZFqElwImDICfrfemnqkDVkLqlAj.Length, 200) && oZFqElwImDICfrfemnqkDVkLqlAj[0] == 33)
						{
							if (oZFqElwImDICfrfemnqkDVkLqlAj[14] == P_0.pCjknWwlaIJLHwjePFchOZkzQHZb)
							{
								flag = true;
								_ = ReInput.realTime;
								break;
							}
							num4++;
							num2++;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					oZFqElwImDICfrfemnqkDVkLqlAj.Read(P_1, oZFqElwImDICfrfemnqkDVkLqlAj.Length);
				}
				return flag;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool qHNDDiUaWCEcGENoMxaFTeOSxYvA(NativeBuffer P_0, byte P_1)
		{
			if (!ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(new xDlFkKEEsqHDzeOiaTIGueyqTccYA(P_0, P_0.Length, P_0.Length), 1000))
			{
				return false;
			}
			return true;
		}

		private void JQzKvsVPKZimiebQvvgESEqZQJUUA(byte P_0)
		{
			HuOJQfTacspCpPwKDklzixhSDESC.Clear();
			HuOJQfTacspCpPwKDklzixhSDESC[0] = 128;
			HuOJQfTacspCpPwKDklzixhSDESC[1] = 146;
			HuOJQfTacspCpPwKDklzixhSDESC[2] = 0;
			HuOJQfTacspCpPwKDklzixhSDESC[3] = 49;
			HuOJQfTacspCpPwKDklzixhSDESC[8] = P_0;
		}

		private void UpjDLCHnAxhrrCTTqBOYBuezPZoUA(byte P_0, NativeBuffer P_1, int P_2, AdGZaeWqClcGEbNkSQklXlRYcQrJ P_3)
		{
			JQzKvsVPKZimiebQvvgESEqZQJUUA(P_0);
			if (P_2 > 0)
			{
				HuOJQfTacspCpPwKDklzixhSDESC.Write(P_1, P_2, 9);
			}
		}

		private void oAkRkKZiDfPztTnFgGLspgqKjlHi(NativeBuffer P_0)
		{
			P_0.Clear();
			P_0[0] = 1;
			P_0[1] = quZQluGKSYfEbjcQoMzTBjUgLVFF();
			rLBfLXJeoRwXElauqikrHqACBLQdA(P_0, 2);
		}

		private void rLBfLXJeoRwXElauqikrHqACBLQdA(NativeBuffer P_0, int P_1)
		{
			if (_controllerType == RBOSFYcFMxSplZbDyfFnHXSWynIJ.JoyConRight)
			{
				P_1 += 4;
			}
			for (int i = 0; i < XUzITuLNarqLEmJSnNmiuuhgeLoK.Length; i++)
			{
				tRlTfccBmUBRwLbdLgqpQxkMlNIo(P_0, P_1, XUzITuLNarqLEmJSnNmiuuhgeLoK[i].vLlHrmnGGJSZXlWTFWaAmxkRefQH);
				P_1 += 4;
			}
		}

		private static void tRlTfccBmUBRwLbdLgqpQxkMlNIo(NativeBuffer P_0, int P_1, dRjQknpDekEqiNfBoFNyfpnXHLLHb P_2)
		{
			if (P_2.JbOxirejHUdfXpuOcWyppaDJhnUAA == 0f && P_2.uislqOBWcEwkbYJVFNqYflOFfmbJA == 0f)
			{
				P_0[P_1] = 0;
				P_0[1 + P_1] = 1;
				P_0[2 + P_1] = 64;
				P_0[3 + P_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.EWbmrShCneesPQBuwwgDPhTNoFWy * 0.1f, 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.cHvqTfeaNRHDrEdgZAXCKhoTMnEPA * 0.1f, 2.0)) - 64.0);
			byte b2 = dMmjSjykHipvLXPWHYQYthMOHkqr(P_2.uislqOBWcEwkbYJVFNqYflOFfmbJA);
			ushort num2 = (ushort)(Math.Round((double)(int)dMmjSjykHipvLXPWHYQYthMOHkqr(P_2.JbOxirejHUdfXpuOcWyppaDJhnUAA)) * 0.5);
			byte num3 = (byte)(num2 % 2);
			if (num3 > 0)
			{
				num2--;
			}
			num2 >>= 1;
			num2 += 64;
			if (num3 > 0)
			{
				num2 |= 0x8000;
			}
			b2 = (byte)(b2 - b2 % 2);
			P_0[P_1] = (byte)(num & 0xFF);
			P_0[1 + P_1] = (byte)(((num >> 8) & 0xFF) + b2);
			P_0[2 + P_1] = (byte)(((num2 >> 8) & 0xFF) + b);
			P_0[3 + P_1] = (byte)(num2 & 0xFF);
		}

		private static byte dMmjSjykHipvLXPWHYQYthMOHkqr(float P_0)
		{
			if (P_0 < 0.01f)
			{
				return 0;
			}
			if ((double)P_0 < 0.117)
			{
				return (byte)((Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0) / (5.0 - Math.Pow(P_0, 2.0)) - 1.0);
			}
			if ((double)P_0 < 0.23)
			{
				return (byte)(Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0 - 92.0);
			}
			return (byte)((Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0) * 2.0 - 246.0);
		}

		private void dCAqzZanretwxcOwZbJfYJOElGjj(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			NativeBuffer nativeBuffer = kHjZihffHiYcXtMQEhbkVLnNlNIF;
			nativeBuffer[0] = quZQluGKSYfEbjcQoMzTBjUgLVFF();
			rLBfLXJeoRwXElauqikrHqACBLQdA(nativeBuffer, 1);
			UpjDLCHnAxhrrCTTqBOYBuezPZoUA(16, nativeBuffer, 9, P_0);
			aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0);
		}

		private bool FbWgaTMYBkslaYBXqivMsYpqLkgo()
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return wWEguSFtyAihEbahfITdWcSGHPxDb(new WvyfItRwfgjjewTNGJUMbhOAiGmx(56, array, 25), rCQeOCMEIryWeHkoprZEHDAZGbTo);
		}

		private bool oHJBHTIFsDELmcypaHmOQPzWtuXkc(bool P_0)
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			if (P_0)
			{
				array[0] = 31;
				array[1] = 240;
			}
			else
			{
				array[0] = 16;
				array[1] = 1;
			}
			return wWEguSFtyAihEbahfITdWcSGHPxDb(new WvyfItRwfgjjewTNGJUMbhOAiGmx(56, array, 25), rCQeOCMEIryWeHkoprZEHDAZGbTo);
		}

		private bool ThthMRCHDNePFhZlKTJOIAjWKnEvA(byte P_0, byte P_1, byte P_2, byte[] P_3)
		{
			byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (wWEguSFtyAihEbahfITdWcSGHPxDb(new WvyfItRwfgjjewTNGJUMbhOAiGmx(16, array, array.Length), P_3) && P_3[15] == P_1 && P_3[16] == P_0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			Array.Copy(P_3, 20, P_3, 0, P_2);
			ArrayTools.Fill(P_3, (byte)0, (int)P_2, P_3.Length - P_2);
			return true;
		}

		private bool aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			switch (P_0)
			{
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous:
				return ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(OdRhINdCygWtgcGOteXZfFdHmxobc, 0);
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous:
				ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteAsync(OdRhINdCygWtgcGOteXZfFdHmxobc, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private byte quZQluGKSYfEbjcQoMzTBjUgLVFF()
		{
			if (rFrLcvOzLyXnQernkfSYqWfbePHb == 15)
			{
				rFrLcvOzLyXnQernkfSYqWfbePHb = 0;
			}
			else
			{
				rFrLcvOzLyXnQernkfSYqWfbePHb++;
			}
			return rFrLcvOzLyXnQernkfSYqWfbePHb;
		}

		private bool DwvKwrLVHoiiaQjxxcdZhhpdBoyyA()
		{
			bool flag = false;
			bool flag2 = _controllerType == RBOSFYcFMxSplZbDyfFnHXSWynIJ.JoyConLeft || _controllerType == RBOSFYcFMxSplZbDyfFnHXSWynIJ.ProController;
			Array.Clear(hnwrbTfsutlfAaoyZbMzVnONIjycA, 0, hnwrbTfsutlfAaoyZbMzVnONIjycA.Length);
			bool flag3 = false;
			if (ThthMRCHDNePFhZlKTJOIAjWKnEvA(128, (byte)(flag2 ? 18 : 29), 9, rCQeOCMEIryWeHkoprZEHDAZGbTo))
			{
				for (int i = 0; i < 9; i++)
				{
					if (rCQeOCMEIryWeHkoprZEHDAZGbTo[i] != byte.MaxValue)
					{
						flag3 = true;
					}
				}
			}
			if (!flag3 && ThthMRCHDNePFhZlKTJOIAjWKnEvA(96, (byte)(flag2 ? 61 : 70), 9, rCQeOCMEIryWeHkoprZEHDAZGbTo))
			{
				flag3 = true;
			}
			if (flag3)
			{
				YNdtRzAeIGadeeeLIrtlIEEQRRlqA yNdtRzAeIGadeeeLIrtlIEEQRRlqA = new YNdtRzAeIGadeeeLIrtlIEEQRRlqA();
				YNdtRzAeIGadeeeLIrtlIEEQRRlqA yNdtRzAeIGadeeeLIrtlIEEQRRlqA2 = new YNdtRzAeIGadeeeLIrtlIEEQRRlqA();
				ituyYnqVWBTxEsjIujSSGiMKbMEm(rCQeOCMEIryWeHkoprZEHDAZGbTo, yNdtRzAeIGadeeeLIrtlIEEQRRlqA, yNdtRzAeIGadeeeLIrtlIEEQRRlqA2, flag2);
				hnwrbTfsutlfAaoyZbMzVnONIjycA[0] = yNdtRzAeIGadeeeLIrtlIEEQRRlqA;
				hnwrbTfsutlfAaoyZbMzVnONIjycA[1] = yNdtRzAeIGadeeeLIrtlIEEQRRlqA2;
				flag = true;
				if (ThthMRCHDNePFhZlKTJOIAjWKnEvA(96, (byte)(flag2 ? 134 : 152), 16, rCQeOCMEIryWeHkoprZEHDAZGbTo))
				{
					dqkwZaGnfVyoMiiNEFKrBQAELqZv(rCQeOCMEIryWeHkoprZEHDAZGbTo, yNdtRzAeIGadeeeLIrtlIEEQRRlqA, yNdtRzAeIGadeeeLIrtlIEEQRRlqA2);
				}
			}
			else
			{
				flag = false;
			}
			if (_controllerType == RBOSFYcFMxSplZbDyfFnHXSWynIJ.ProController)
			{
				bool flag4 = false;
				if (ThthMRCHDNePFhZlKTJOIAjWKnEvA(128, (byte)((!flag2) ? 18 : 29), 9, rCQeOCMEIryWeHkoprZEHDAZGbTo))
				{
					for (int j = 0; j < 9; j++)
					{
						if (rCQeOCMEIryWeHkoprZEHDAZGbTo[j] != byte.MaxValue)
						{
							flag4 = true;
						}
					}
				}
				if (!flag4 && ThthMRCHDNePFhZlKTJOIAjWKnEvA(96, (byte)((!flag2) ? 61 : 70), 9, rCQeOCMEIryWeHkoprZEHDAZGbTo))
				{
					flag4 = true;
				}
				if (flag4)
				{
					YNdtRzAeIGadeeeLIrtlIEEQRRlqA yNdtRzAeIGadeeeLIrtlIEEQRRlqA3 = new YNdtRzAeIGadeeeLIrtlIEEQRRlqA();
					YNdtRzAeIGadeeeLIrtlIEEQRRlqA yNdtRzAeIGadeeeLIrtlIEEQRRlqA4 = new YNdtRzAeIGadeeeLIrtlIEEQRRlqA();
					ituyYnqVWBTxEsjIujSSGiMKbMEm(rCQeOCMEIryWeHkoprZEHDAZGbTo, yNdtRzAeIGadeeeLIrtlIEEQRRlqA3, yNdtRzAeIGadeeeLIrtlIEEQRRlqA4, !flag2);
					hnwrbTfsutlfAaoyZbMzVnONIjycA[2] = yNdtRzAeIGadeeeLIrtlIEEQRRlqA3;
					hnwrbTfsutlfAaoyZbMzVnONIjycA[3] = yNdtRzAeIGadeeeLIrtlIEEQRRlqA4;
					flag = true;
					if (ThthMRCHDNePFhZlKTJOIAjWKnEvA(96, (byte)((!flag2) ? 134 : 152), 16, rCQeOCMEIryWeHkoprZEHDAZGbTo))
					{
						dqkwZaGnfVyoMiiNEFKrBQAELqZv(rCQeOCMEIryWeHkoprZEHDAZGbTo, yNdtRzAeIGadeeeLIrtlIEEQRRlqA3, yNdtRzAeIGadeeeLIrtlIEEQRRlqA4);
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private static void ituyYnqVWBTxEsjIujSSGiMKbMEm(byte[] P_0, YNdtRzAeIGadeeeLIrtlIEEQRRlqA P_1, YNdtRzAeIGadeeeLIrtlIEEQRRlqA P_2, bool P_3)
		{
			ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
			ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
			ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
			ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
			ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
			if (P_3)
			{
				P_1.NEvCnncHbQKszkADGizKaJUbnsKiB = num;
				P_2.NEvCnncHbQKszkADGizKaJUbnsKiB = num2;
				P_1.IUUzTmjCPEKDPkZEmDQDohahvfoi = num3;
				P_2.IUUzTmjCPEKDPkZEmDQDohahvfoi = num4;
				P_1.mrSAzxsQiDtfXLIluTRYiLWfvhLF = num5;
				P_2.mrSAzxsQiDtfXLIluTRYiLWfvhLF = num6;
			}
			else
			{
				P_1.IUUzTmjCPEKDPkZEmDQDohahvfoi = num;
				P_2.IUUzTmjCPEKDPkZEmDQDohahvfoi = num2;
				P_1.mrSAzxsQiDtfXLIluTRYiLWfvhLF = num3;
				P_2.mrSAzxsQiDtfXLIluTRYiLWfvhLF = num4;
				P_1.NEvCnncHbQKszkADGizKaJUbnsKiB = num5;
				P_2.NEvCnncHbQKszkADGizKaJUbnsKiB = num6;
			}
		}

		private static void dqkwZaGnfVyoMiiNEFKrBQAELqZv(byte[] P_0, YNdtRzAeIGadeeeLIrtlIEEQRRlqA P_1, YNdtRzAeIGadeeeLIrtlIEEQRRlqA P_2)
		{
			P_1.jxgXMQCEnQBUXcakUkMlAeOGxhXqb = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			P_2.jxgXMQCEnQBUXcakUkMlAeOGxhXqb = P_1.jxgXMQCEnQBUXcakUkMlAeOGxhXqb;
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, YNdtRzAeIGadeeeLIrtlIEEQRRlqA calX, YNdtRzAeIGadeeeLIrtlIEEQRRlqA calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort jxgXMQCEnQBUXcakUkMlAeOGxhXqb = calX.jxgXMQCEnQBUXcakUkMlAeOGxhXqb;
			float num = valueX - calX.IUUzTmjCPEKDPkZEmDQDohahvfoi;
			float num2 = valueY - calY.IUUzTmjCPEKDPkZEmDQDohahvfoi;
			if (Math.Abs(num * num + num2 * num2) < (float)(jxgXMQCEnQBUXcakUkMlAeOGxhXqb * jxgXMQCEnQBUXcakUkMlAeOGxhXqb))
			{
				return false;
			}
			calibratedX = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num / (float)(int)((num > 0f) ? calX.NEvCnncHbQKszkADGizKaJUbnsKiB : calX.mrSAzxsQiDtfXLIluTRYiLWfvhLF), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num2 / (float)(int)((num2 > 0f) ? calY.NEvCnncHbQKszkADGizKaJUbnsKiB : calY.mrSAzxsQiDtfXLIluTRYiLWfvhLF), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			return true;
		}

		protected YNdtRzAeIGadeeeLIrtlIEEQRRlqA GetAxisCalibration(int index)
		{
			return hnwrbTfsutlfAaoyZbMzVnONIjycA[index];
		}

		private void TNcWPrbERDuIJOeRurmdoMrAbUeN(bool P_0)
		{
			if (jTgDGWADqAcTFEcrCvwAGnNcUXhmd && !P_0)
			{
				EnjrZOCsbGPvcYSaFtRkMhiNpjIt = ReInput.realTime;
			}
		}

		~NintendoSwitchGamepadDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			if (disposing)
			{
				ReInput.ApplicationPauseChangedEvent -= TNcWPrbERDuIJOeRurmdoMrAbUeN;
				if (!urBDemPOotqBqeojOrfYeWijKhII && HuOJQfTacspCpPwKDklzixhSDESC != null)
				{
					HuOJQfTacspCpPwKDklzixhSDESC.Clear();
					HuOJQfTacspCpPwKDklzixhSDESC[0] = 128;
					HuOJQfTacspCpPwKDklzixhSDESC[1] = 5;
					try
					{
						ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(OdRhINdCygWtgcGOteXZfFdHmxobc, 0);
					}
					catch
					{
					}
					HuOJQfTacspCpPwKDklzixhSDESC.Clear();
					HuOJQfTacspCpPwKDklzixhSDESC[0] = 128;
					HuOJQfTacspCpPwKDklzixhSDESC[1] = 6;
					try
					{
						ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(OdRhINdCygWtgcGOteXZfFdHmxobc, 0);
					}
					catch
					{
					}
				}
				if (WynDIcPUQZuoNwMFNYtngVTThDLT != null)
				{
					WynDIcPUQZuoNwMFNYtngVTThDLT.Dispose();
				}
				if (HuOJQfTacspCpPwKDklzixhSDESC != null)
				{
					HuOJQfTacspCpPwKDklzixhSDESC.Dispose();
				}
				if (seQHPoApwTevktEYhtyRqoYViUINA != null)
				{
					seQHPoApwTevktEYhtyRqoYViUINA.Dispose();
				}
				if (oZFqElwImDICfrfemnqkDVkLqlAj != null)
				{
					oZFqElwImDICfrfemnqkDVkLqlAj.Dispose();
				}
				if (kHjZihffHiYcXtMQEhbkVLnNlNIF == null)
				{
					kHjZihffHiYcXtMQEhbkVLnNlNIF.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private static void HZqUGAIkgQGtgFxdbznQqiqktUom(NativeBuffer P_0, int P_1)
		{
			P_0.TryWriteBytes(gbmNIRngXQpRFksxABGGqAGyblAf, gbmNIRngXQpRFksxABGGqAGyblAf.Length, P_1);
		}

		private static void HZqUGAIkgQGtgFxdbznQqiqktUom(byte[] P_0, int P_1)
		{
			Array.Copy(gbmNIRngXQpRFksxABGGqAGyblAf, 0, P_0, P_1, gbmNIRngXQpRFksxABGGqAGyblAf.Length);
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("SwitchGamepadDriverBase: " + msg);
			}
		}
	}
}
