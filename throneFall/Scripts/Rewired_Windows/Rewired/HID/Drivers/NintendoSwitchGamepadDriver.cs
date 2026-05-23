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
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		protected enum BcXVNrwlGYMmCDHjgcGZTTSoSUao
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class zJYezyCeNBvDwgRsmNZvAKeTuqPBb
		{
			private pMGtGvfvhFCynWDpoUnlyTrPulZp OrirzTDeZvHKFDMIPDVzRyfHnJmQ;

			private vcTBOglcRBoFRHpiIwOslnvonnIA lqRfXBaZESbVjjiLrwqlLjvrOCeT;

			private float ptweyrcgEsrVVBefATlYlYBOjfTiA;

			private double nRzxchMegyvjPEppEdcxRreigNRr;

			public vcTBOglcRBoFRHpiIwOslnvonnIA ODCupDoKoilwQNbbRZZpiremGSwm => lqRfXBaZESbVjjiLrwqlLjvrOCeT;

			public zJYezyCeNBvDwgRsmNZvAKeTuqPBb(pMGtGvfvhFCynWDpoUnlyTrPulZp P_0)
			{
				OrirzTDeZvHKFDMIPDVzRyfHnJmQ = P_0;
				tTVUskonGgWRgsdiamZSUVanuTNm();
			}

			public void gAJSVmrxHVVdMDnPexRBwnkdMAgp(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
				if (P_4 < 0f)
				{
					P_4 = 0f;
				}
				ptweyrcgEsrVVBefATlYlYBOjfTiA = P_4;
				lqRfXBaZESbVjjiLrwqlLjvrOCeT.RuvFehAqtnATarUKIFFWrLKHGJiP = MathTools.Clamp01(P_0);
				lqRfXBaZESbVjjiLrwqlLjvrOCeT.chGpQqQwntwYDXEQXCkimdrMVFrG = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
				lqRfXBaZESbVjjiLrwqlLjvrOCeT.mpSprXbkhmBptiGERghNbZntOdooA = MathTools.Clamp01(P_2);
				lqRfXBaZESbVjjiLrwqlLjvrOCeT.LxQYEuDrmZovLeNemwGbWzQtTHCs = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
				OrirzTDeZvHKFDMIPDVzRyfHnJmQ.VkXdVAiMyWDgMKEYwLoxttDNIods = Math.Max(lqRfXBaZESbVjjiLrwqlLjvrOCeT.RuvFehAqtnATarUKIFFWrLKHGJiP, lqRfXBaZESbVjjiLrwqlLjvrOCeT.mpSprXbkhmBptiGERghNbZntOdooA);
				nRzxchMegyvjPEppEdcxRreigNRr = ReInput.realTime;
			}

			public void udLuuudZACyCzQAZoKgcRCbwRghh(double P_0)
			{
				if ((lqRfXBaZESbVjjiLrwqlLjvrOCeT.RuvFehAqtnATarUKIFFWrLKHGJiP > 0f || lqRfXBaZESbVjjiLrwqlLjvrOCeT.mpSprXbkhmBptiGERghNbZntOdooA > 0f) && ptweyrcgEsrVVBefATlYlYBOjfTiA > 0f && P_0 >= nRzxchMegyvjPEppEdcxRreigNRr + (double)ptweyrcgEsrVVBefATlYlYBOjfTiA)
				{
					rBFFTFfOjtCNBoIvdPNLjBJlqQcFA();
				}
			}

			public void rBFFTFfOjtCNBoIvdPNLjBJlqQcFA()
			{
				lqRfXBaZESbVjjiLrwqlLjvrOCeT.mpSprXbkhmBptiGERghNbZntOdooA = 0f;
				lqRfXBaZESbVjjiLrwqlLjvrOCeT.RuvFehAqtnATarUKIFFWrLKHGJiP = 0f;
				OrirzTDeZvHKFDMIPDVzRyfHnJmQ.IqUCAdAupfvNpXYQVecZbYudoQHV = 0;
				ptweyrcgEsrVVBefATlYlYBOjfTiA = 0f;
				nRzxchMegyvjPEppEdcxRreigNRr = ReInput.realTime;
			}

			public void tTVUskonGgWRgsdiamZSUVanuTNm()
			{
				lqRfXBaZESbVjjiLrwqlLjvrOCeT = vcTBOglcRBoFRHpiIwOslnvonnIA.jTQYLwNHbbbxGSQwZkplmPdLPmyF();
				OrirzTDeZvHKFDMIPDVzRyfHnJmQ.IqUCAdAupfvNpXYQVecZbYudoQHV = 0;
				ptweyrcgEsrVVBefATlYlYBOjfTiA = 0f;
				nRzxchMegyvjPEppEdcxRreigNRr = 0.0;
			}
		}

		protected struct vcTBOglcRBoFRHpiIwOslnvonnIA
		{
			public const int NVSOXOQwjtcewNNDjTEAxxbmRlOc = 160;

			public const int qhMfjIHCgIVhngoPeCYZKjpSydyNA = 320;

			public float RuvFehAqtnATarUKIFFWrLKHGJiP;

			public float chGpQqQwntwYDXEQXCkimdrMVFrG;

			public float mpSprXbkhmBptiGERghNbZntOdooA;

			public float LxQYEuDrmZovLeNemwGbWzQtTHCs;

			internal vcTBOglcRBoFRHpiIwOslnvonnIA(float P_0, float P_1, float P_2, float P_3)
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
				RuvFehAqtnATarUKIFFWrLKHGJiP = P_0;
				chGpQqQwntwYDXEQXCkimdrMVFrG = P_1;
				mpSprXbkhmBptiGERghNbZntOdooA = P_2;
				LxQYEuDrmZovLeNemwGbWzQtTHCs = P_3;
			}

			public static vcTBOglcRBoFRHpiIwOslnvonnIA jTQYLwNHbbbxGSQwZkplmPdLPmyF()
			{
				return new vcTBOglcRBoFRHpiIwOslnvonnIA(0f, 160f, 0f, 320f);
			}

			public string yuITyUQvHSeRQJpESjSOHDtSsmPm()
			{
				return "amplitudeLow: " + RuvFehAqtnATarUKIFFWrLKHGJiP + ", frequencyLow: " + chGpQqQwntwYDXEQXCkimdrMVFrG + ", amplitudeHigh: " + mpSprXbkhmBptiGERghNbZntOdooA + ", frequencyHigh: " + LxQYEuDrmZovLeNemwGbWzQtTHCs;
			}
		}

		private struct QxvbXMfBxFfxDAmtaGeupdWmmyIDB
		{
			public byte RSndShDiocZNdMjiIImtpQafZlVA;

			public byte[] GRNCUuMBjeyIbtCoRUedMpvdoKpV;

			public int OtqvXSPVBvRXmwhHhRYKtiiaIBNf;

			public QxvbXMfBxFfxDAmtaGeupdWmmyIDB(byte P_0, byte[] P_1, int P_2)
			{
				RSndShDiocZNdMjiIImtpQafZlVA = P_0;
				GRNCUuMBjeyIbtCoRUedMpvdoKpV = P_1;
				OtqvXSPVBvRXmwhHhRYKtiiaIBNf = P_2;
			}
		}

		protected class CNwlIMCmCdGhJiOlUBAFOiSkdrLEA
		{
			public ushort tBteoKDbTjOocipwjJvjbHxnixrbb;

			public ushort tXsJZoXxYdujtiikcsPmsycGUoYq;

			public ushort KSaIbiEcoogmAhLcgGyJqemfdvAfA;

			public ushort dhkKcvDrOauArpeblBJLkybNqjaoA;

			public virtual string kPopNVZvbXoqpHhTgjTeTXtwdxiF()
			{
				return "min: " + tBteoKDbTjOocipwjJvjbHxnixrbb + ", max: " + tXsJZoXxYdujtiikcsPmsycGUoYq + ", zero: " + KSaIbiEcoogmAhLcgGyJqemfdvAfA + ", deadzone: " + dhkKcvDrOauArpeblBJLkybNqjaoA;
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

		protected readonly BcXVNrwlGYMmCDHjgcGZTTSoSUao _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice uVCACDlVhuqkrYJOZfKQMOHXWoOE;

		private readonly HIDProperties yEBtnHoftaqtMucHrnZNdKwcKdTX;

		private readonly bool lLeFlZzrJQQoaCIEtCwMdWuGxZEV;

		private readonly NativeBuffer orxMpJYrUkADMSWTLHrYoYOGATxb;

		private readonly NativeBuffer cdKETPsvbvSQvFvaLkOLPhlyVFtu;

		private readonly NativeBuffer oZHqBZieHDtVWSVyjYAsYeFIWPaK;

		private readonly byte[] VLekNgFaZgFxOXEQRpwhbzdTsrPt;

		private readonly NativeBuffer VymGRxHGVypsQBFEEthUkAqLidlDb;

		private readonly NativeBuffer GXikoSsJPBxrmIPQlgLhMmXUiQYL;

		private dccInhMggZtLYGkWFjXacEyGQoUL UECIIqCldToTymhiaCSqdKuBRktpb;

		private double dNqKcNKiIuSjcSqcWKekWCGVZwCM;

		private byte hyZHpgomiRVvFkulSubFfMyEbjHz;

		private double wXRKQHIAvlpAQHsffSsAPKcDdxzn;

		private bool BICqhsDMFRZCgGIIXhOohxsJGGMY;

		private bool MxaGQGjYxJETIGLAlqHYMCXJVGVE;

		private zJYezyCeNBvDwgRsmNZvAKeTuqPBb[] UZVesoOMkyqtyeGIvKTKYzAFQwyk;

		private CNwlIMCmCdGhJiOlUBAFOiSkdrLEA[] PxbgljGkwMmGTQvdVXbviUnrjblXA;

		private static readonly byte[] ZzvHECAlxobIWaqVDniPuFTVLlVkA = new byte[8] { 0, 1, 64, 64, 0, 1, 64, 64 };

		int IDriver_NintendoSwitchController.vibrationMotorCount => _vibrationMotorCount;

		ushort IHIDControllerExtension.vendorId => yEBtnHoftaqtMucHrnZNdKwcKdTX.vendorId;

		ushort IHIDControllerExtension.productId => yEBtnHoftaqtMucHrnZNdKwcKdTX.productId;

		string IHIDControllerExtension.productName => yEBtnHoftaqtMucHrnZNdKwcKdTX.productName;

		string IHIDControllerExtension.manufacturer => yEBtnHoftaqtMucHrnZNdKwcKdTX.manufacturer;

		ushort IHIDControllerExtension.usagePage => yEBtnHoftaqtMucHrnZNdKwcKdTX.usagePage;

		ushort IHIDControllerExtension.usage => yEBtnHoftaqtMucHrnZNdKwcKdTX.usage;

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
				vcTBOglcRBoFRHpiIwOslnvonnIA vcTBOglcRBoFRHpiIwOslnvonnIA2 = UZVesoOMkyqtyeGIvKTKYzAFQwyk[motorIndex].ODCupDoKoilwQNbbRZZpiremGSwm;
				amplitudeLow = vcTBOglcRBoFRHpiIwOslnvonnIA2.RuvFehAqtnATarUKIFFWrLKHGJiP;
				frequencyLow = vcTBOglcRBoFRHpiIwOslnvonnIA2.chGpQqQwntwYDXEQXCkimdrMVFrG;
				amplitudeHigh = vcTBOglcRBoFRHpiIwOslnvonnIA2.mpSprXbkhmBptiGERghNbZntOdooA;
				frequencyHigh = vcTBOglcRBoFRHpiIwOslnvonnIA2.LxQYEuDrmZovLeNemwGbWzQtTHCs;
			}
		}

		void IDriver_NintendoSwitchController.GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetVibration
			this.GetVibration(motorIndex, out amplitudeLow, out frequencyLow, out amplitudeHigh, out frequencyHigh);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors: false);
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors);
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors: false);
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
			{
				if (stopOtherMotors)
				{
					PVNMbNkGdyuqGHbXvDiZlUrTlqKW(motorIndex);
				}
				UZVesoOMkyqtyeGIvKTKYzAFQwyk[motorIndex].gAJSVmrxHVVdMDnPexRBwnkdMAgp(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
			}
		}

		void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors);
		}

		public void StopVibration(int motorIndex)
		{
			if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
			{
				UZVesoOMkyqtyeGIvKTKYzAFQwyk[motorIndex].rBFFTFfOjtCNBoIvdPNLjBJlqQcFA();
			}
		}

		void IDriver_NintendoSwitchController.StopVibration(int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration(motorIndex);
		}

		public void StopVibration()
		{
			for (int i = 0; i < _vibrationMotorCount; i++)
			{
				UZVesoOMkyqtyeGIvKTKYzAFQwyk[i].rBFFTFfOjtCNBoIvdPNLjBJlqQcFA();
			}
		}

		void IDriver_NintendoSwitchController.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		private void PVNMbNkGdyuqGHbXvDiZlUrTlqKW(int P_0)
		{
			for (int i = 0; i < UZVesoOMkyqtyeGIvKTKYzAFQwyk.Length; i++)
			{
				if (i != P_0)
				{
					UZVesoOMkyqtyeGIvKTKYzAFQwyk[i].rBFFTFfOjtCNBoIvdPNLjBJlqQcFA();
				}
			}
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, BcXVNrwlGYMmCDHjgcGZTTSoSUao P_1, int P_2, int P_3, int P_4)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			_controllerType = P_1;
			_buttonCount = P_2;
			_axisCount = P_3;
			_vibrationMotorCount = P_4;
			uVCACDlVhuqkrYJOZfKQMOHXWoOE = P_0.hidDevice;
			yEBtnHoftaqtMucHrnZNdKwcKdTX = P_0.hidDevice.properties;
			lLeFlZzrJQQoaCIEtCwMdWuGxZEV = P_0.connectionType == RXEzGxJeQkuaNxkYCJIkKyWznLNi.Bluetooth;
			orxMpJYrUkADMSWTLHrYoYOGATxb = new NativeBuffer(yEBtnHoftaqtMucHrnZNdKwcKdTX.maxInputReportLength);
			cdKETPsvbvSQvFvaLkOLPhlyVFtu = new NativeBuffer(yEBtnHoftaqtMucHrnZNdKwcKdTX.maxOutputReportLength);
			oZHqBZieHDtVWSVyjYAsYeFIWPaK = new NativeBuffer(32);
			VLekNgFaZgFxOXEQRpwhbzdTsrPt = new byte[yEBtnHoftaqtMucHrnZNdKwcKdTX.maxInputReportLength];
			VymGRxHGVypsQBFEEthUkAqLidlDb = new NativeBuffer(yEBtnHoftaqtMucHrnZNdKwcKdTX.maxOutputReportLength);
			GXikoSsJPBxrmIPQlgLhMmXUiQYL = new NativeBuffer(49);
			if (yEBtnHoftaqtMucHrnZNdKwcKdTX.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			UECIIqCldToTymhiaCSqdKuBRktpb = new dccInhMggZtLYGkWFjXacEyGQoUL(cdKETPsvbvSQvFvaLkOLPhlyVFtu.Pointer, cdKETPsvbvSQvFvaLkOLPhlyVFtu.Length, cdKETPsvbvSQvFvaLkOLPhlyVFtu.Length);
			BICqhsDMFRZCgGIIXhOohxsJGGMY = !lLeFlZzrJQQoaCIEtCwMdWuGxZEV && UnityTools.effectivePlatform == Platform.Windows;
			ReInput.ApplicationPauseChangedEvent += BXveugFsOOakCunOsUGKXwNzrWXd;
			buttons = new YgmprUEDpDakYucBfpnWbXzouOGJ[P_2];
			for (int i = 0; i < P_2; i++)
			{
				buttons[i] = new YgmprUEDpDakYucBfpnWbXzouOGJ(33, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			PxbgljGkwMmGTQvdVXbviUnrjblXA = new CNwlIMCmCdGhJiOlUBAFOiSkdrLEA[_axisCount];
			vibrationMotors = new pMGtGvfvhFCynWDpoUnlyTrPulZp[P_4];
			for (int j = 0; j < vibrationMotors.Length; j++)
			{
				vibrationMotors[j] = new pMGtGvfvhFCynWDpoUnlyTrPulZp(0, 255);
			}
			UZVesoOMkyqtyeGIvKTKYzAFQwyk = new zJYezyCeNBvDwgRsmNZvAKeTuqPBb[P_4];
			for (int k = 0; k < UZVesoOMkyqtyeGIvKTKYzAFQwyk.Length; k++)
			{
				UZVesoOMkyqtyeGIvKTKYzAFQwyk[k] = new zJYezyCeNBvDwgRsmNZvAKeTuqPBb(vibrationMotors[k]);
			}
		}

		protected void Initialize()
		{
			MxaGQGjYxJETIGLAlqHYMCXJVGVE = false;
			cdKETPsvbvSQvFvaLkOLPhlyVFtu.Clear();
			if (!lLeFlZzrJQQoaCIEtCwMdWuGxZEV)
			{
				NativeBuffer nativeBuffer = cdKETPsvbvSQvFvaLkOLPhlyVFtu;
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 1;
				if (!ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB connection status.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 2;
				if (!ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 1.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 3;
				if (!ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB set baudrate.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 2;
				if (!ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 2.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 4;
				if (!ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB prevent hid timeout.", requiredThreadSafety: true);
					throw new Exception();
				}
			}
			if (!avquZwJNNnZnsmrprkaJkClFKKCx(new QxvbXMfBxFfxDAmtaGeupdWmmyIDB(72, new byte[1] { 1 }, 1), VLekNgFaZgFxOXEQRpwhbzdTsrPt))
			{
				throw new Exception();
			}
			if (!avquZwJNNnZnsmrprkaJkClFKKCx(new QxvbXMfBxFfxDAmtaGeupdWmmyIDB(3, new byte[1] { 48 }, 1), VLekNgFaZgFxOXEQRpwhbzdTsrPt))
			{
				throw new Exception();
			}
			zRcQxYJfBQNmAQzLtJgvHHBLiZlS();
			if (!kRCqLLTiWOcNFFWEvEFYVHKbdcGA())
			{
				throw new Exception();
			}
			if (BICqhsDMFRZCgGIIXhOohxsJGGMY)
			{
				wXRKQHIAvlpAQHsffSsAPKcDdxzn = ReInput.realTime;
			}
			MxaGQGjYxJETIGLAlqHYMCXJVGVE = true;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			double realTime = ReInput.realTime;
			if (BICqhsDMFRZCgGIIXhOohxsJGGMY && realTime >= wXRKQHIAvlpAQHsffSsAPKcDdxzn + 1.0)
			{
				try
				{
					Initialize();
				}
				catch
				{
					Logger.LogWarning("Error re-initializing Nintendo Switch Pro Controller. Will retry.");
					wXRKQHIAvlpAQHsffSsAPKcDdxzn = realTime;
				}
			}
			for (int i = 0; i < UZVesoOMkyqtyeGIvKTKYzAFQwyk.Length; i++)
			{
				UZVesoOMkyqtyeGIvKTKYzAFQwyk[i].udLuuudZACyCzQAZoKgcRCbwRghh(realTime);
			}
			if (realTime >= dNqKcNKiIuSjcSqcWKekWCGVZwCM + 0.01515151560306549)
			{
				dNqKcNKiIuSjcSqcWKekWCGVZwCM = realTime;
				ysSzLmdXBRqXQIuDCRVCrtJIRGXk(cdKETPsvbvSQvFvaLkOLPhlyVFtu);
				ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous);
			}
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (!MxaGQGjYxJETIGLAlqHYMCXJVGVE)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (orxMpJYrUkADMSWTLHrYoYOGATxb.Length < 49)
			{
				return false;
			}
			if (Marshal.ReadByte(inputReportPtr, 0) != 33)
			{
				return false;
			}
			if (BICqhsDMFRZCgGIIXhOohxsJGGMY)
			{
				wXRKQHIAvlpAQHsffSsAPKcDdxzn = ReInput.realTime;
			}
			int numBytesToWrite = Math.Min(inputReportLength, orxMpJYrUkADMSWTLHrYoYOGATxb.Length);
			orxMpJYrUkADMSWTLHrYoYOGATxb.Write(inputReportPtr, inputReportLength, numBytesToWrite);
			UpdateButtons(orxMpJYrUkADMSWTLHrYoYOGATxb, timestamp);
			QTwvMqRjxXBwLOoUpuezGnwheUbM[] elements = axes;
			UpdateElements(elements, orxMpJYrUkADMSWTLHrYoYOGATxb, timestamp);
			return true;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(QTwvMqRjxXBwLOoUpuezGnwheUbM[] elements, NativeBuffer inputReport, double timestamp);

		private bool avquZwJNNnZnsmrprkaJkClFKKCx(QxvbXMfBxFfxDAmtaGeupdWmmyIDB P_0, byte[] P_1)
		{
			try
			{
				if (P_0.GRNCUuMBjeyIbtCoRUedMpvdoKpV.Length + 11 > VymGRxHGVypsQBFEEthUkAqLidlDb.Length)
				{
					return false;
				}
				ysSzLmdXBRqXQIuDCRVCrtJIRGXk(VymGRxHGVypsQBFEEthUkAqLidlDb);
				VymGRxHGVypsQBFEEthUkAqLidlDb[10] = P_0.RSndShDiocZNdMjiIImtpQafZlVA;
				VymGRxHGVypsQBFEEthUkAqLidlDb.TryWriteBytes(P_0.GRNCUuMBjeyIbtCoRUedMpvdoKpV, P_0.OtqvXSPVBvRXmwhHhRYKtiiaIBNf, 11);
				int num = 2;
				bool flag = false;
				int num2 = 0;
				double num3 = 0.0;
				while (uVCACDlVhuqkrYJOZfKQMOHXWoOE.ReadSync(GXikoSsJPBxrmIPQlgLhMmXUiQYL, GXikoSsJPBxrmIPQlgLhMmXUiQYL.Length, 1))
				{
				}
				for (int i = 0; i < num; i++)
				{
					Array.Clear(P_1, 0, P_1.Length);
					GXikoSsJPBxrmIPQlgLhMmXUiQYL.Clear();
					MuPVzWikkIkkveSDUaRBMchvFBPJA(VymGRxHGVypsQBFEEthUkAqLidlDb, P_0.RSndShDiocZNdMjiIImtpQafZlVA);
					num3 = ReInput.realTime;
					if (i == 0)
					{
						_ = ReInput.realTime;
					}
					int num4 = 0;
					while (!(ReInput.realTime >= num3 + 0.5))
					{
						if (uVCACDlVhuqkrYJOZfKQMOHXWoOE.ReadSync(GXikoSsJPBxrmIPQlgLhMmXUiQYL, GXikoSsJPBxrmIPQlgLhMmXUiQYL.Length, 200) && GXikoSsJPBxrmIPQlgLhMmXUiQYL[0] == 33)
						{
							if (GXikoSsJPBxrmIPQlgLhMmXUiQYL[14] == P_0.RSndShDiocZNdMjiIImtpQafZlVA)
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
					GXikoSsJPBxrmIPQlgLhMmXUiQYL.Read(P_1, GXikoSsJPBxrmIPQlgLhMmXUiQYL.Length);
				}
				return flag;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool MuPVzWikkIkkveSDUaRBMchvFBPJA(NativeBuffer P_0, byte P_1)
		{
			if (!uVCACDlVhuqkrYJOZfKQMOHXWoOE.WriteSync(new dccInhMggZtLYGkWFjXacEyGQoUL(P_0, P_0.Length, P_0.Length), 1000))
			{
				return false;
			}
			return true;
		}

		private void kUMOJwMkcGlAmVoXerfiWhXsgMHp(byte P_0)
		{
			cdKETPsvbvSQvFvaLkOLPhlyVFtu.Clear();
			cdKETPsvbvSQvFvaLkOLPhlyVFtu[0] = 128;
			cdKETPsvbvSQvFvaLkOLPhlyVFtu[1] = 146;
			cdKETPsvbvSQvFvaLkOLPhlyVFtu[2] = 0;
			cdKETPsvbvSQvFvaLkOLPhlyVFtu[3] = 49;
			cdKETPsvbvSQvFvaLkOLPhlyVFtu[8] = P_0;
		}

		private void CGWBcggiuVcMfdrXfuTTMBIqREGfc(byte P_0, NativeBuffer P_1, int P_2, ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_3)
		{
			kUMOJwMkcGlAmVoXerfiWhXsgMHp(P_0);
			if (P_2 > 0)
			{
				cdKETPsvbvSQvFvaLkOLPhlyVFtu.Write(P_1, P_2, 9);
			}
		}

		private void ysSzLmdXBRqXQIuDCRVCrtJIRGXk(NativeBuffer P_0)
		{
			P_0.Clear();
			P_0[0] = 1;
			P_0[1] = JkwhrXBOdGpVrOoxbFpPpnhdiooj();
			ruodwchzsRFdcLNufKsnDsguPIWdb(P_0, 2);
		}

		private void ruodwchzsRFdcLNufKsnDsguPIWdb(NativeBuffer P_0, int P_1)
		{
			if (_controllerType == BcXVNrwlGYMmCDHjgcGZTTSoSUao.JoyConRight)
			{
				P_1 += 4;
			}
			for (int i = 0; i < UZVesoOMkyqtyeGIvKTKYzAFQwyk.Length; i++)
			{
				HsRyUPIkPXjWcfsfTfkQcdaEDKQIB(P_0, P_1, UZVesoOMkyqtyeGIvKTKYzAFQwyk[i].ODCupDoKoilwQNbbRZZpiremGSwm);
				P_1 += 4;
			}
		}

		private static void HsRyUPIkPXjWcfsfTfkQcdaEDKQIB(NativeBuffer P_0, int P_1, vcTBOglcRBoFRHpiIwOslnvonnIA P_2)
		{
			if (P_2.RuvFehAqtnATarUKIFFWrLKHGJiP == 0f && P_2.mpSprXbkhmBptiGERghNbZntOdooA == 0f)
			{
				P_0[P_1] = 0;
				P_0[1 + P_1] = 1;
				P_0[2 + P_1] = 64;
				P_0[3 + P_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.LxQYEuDrmZovLeNemwGbWzQtTHCs * 0.1f, 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.chGpQqQwntwYDXEQXCkimdrMVFrG * 0.1f, 2.0)) - 64.0);
			byte b2 = BIuCxcsUNdTvSBMROJbCdBAuMZTE(P_2.mpSprXbkhmBptiGERghNbZntOdooA);
			ushort num2 = (ushort)(Math.Round((double)(int)BIuCxcsUNdTvSBMROJbCdBAuMZTE(P_2.RuvFehAqtnATarUKIFFWrLKHGJiP)) * 0.5);
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

		private static byte BIuCxcsUNdTvSBMROJbCdBAuMZTE(float P_0)
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

		private void mkKMAQqFDRHKbkHuouSjmOGUlJJF(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			NativeBuffer nativeBuffer = oZHqBZieHDtVWSVyjYAsYeFIWPaK;
			nativeBuffer[0] = JkwhrXBOdGpVrOoxbFpPpnhdiooj();
			ruodwchzsRFdcLNufKsnDsguPIWdb(nativeBuffer, 1);
			CGWBcggiuVcMfdrXfuTTMBIqREGfc(16, nativeBuffer, 9, P_0);
			ThcxXpVsLqbVvjcJYKbNthPXCgnV(P_0);
		}

		private bool zRcQxYJfBQNmAQzLtJgvHHBLiZlS()
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return avquZwJNNnZnsmrprkaJkClFKKCx(new QxvbXMfBxFfxDAmtaGeupdWmmyIDB(56, array, 25), VLekNgFaZgFxOXEQRpwhbzdTsrPt);
		}

		private bool pGFALMGWwzBQVxYfrCKUtJLIhAHBb(bool P_0)
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
			return avquZwJNNnZnsmrprkaJkClFKKCx(new QxvbXMfBxFfxDAmtaGeupdWmmyIDB(56, array, 25), VLekNgFaZgFxOXEQRpwhbzdTsrPt);
		}

		private bool VkCMutnBYOpRWflEWRKZAofzWbcN(byte P_0, byte P_1, byte P_2, byte[] P_3)
		{
			byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (avquZwJNNnZnsmrprkaJkClFKKCx(new QxvbXMfBxFfxDAmtaGeupdWmmyIDB(16, array, array.Length), P_3) && P_3[15] == P_1 && P_3[16] == P_0)
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

		private bool ThcxXpVsLqbVvjcJYKbNthPXCgnV(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			switch (P_0)
			{
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous:
				return uVCACDlVhuqkrYJOZfKQMOHXWoOE.WriteSync(UECIIqCldToTymhiaCSqdKuBRktpb, 0);
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous:
				uVCACDlVhuqkrYJOZfKQMOHXWoOE.WriteAsync(UECIIqCldToTymhiaCSqdKuBRktpb, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private byte JkwhrXBOdGpVrOoxbFpPpnhdiooj()
		{
			if (hyZHpgomiRVvFkulSubFfMyEbjHz == 15)
			{
				hyZHpgomiRVvFkulSubFfMyEbjHz = 0;
			}
			else
			{
				hyZHpgomiRVvFkulSubFfMyEbjHz++;
			}
			return hyZHpgomiRVvFkulSubFfMyEbjHz;
		}

		private bool kRCqLLTiWOcNFFWEvEFYVHKbdcGA()
		{
			bool flag = false;
			bool flag2 = _controllerType == BcXVNrwlGYMmCDHjgcGZTTSoSUao.JoyConLeft || _controllerType == BcXVNrwlGYMmCDHjgcGZTTSoSUao.ProController;
			Array.Clear(PxbgljGkwMmGTQvdVXbviUnrjblXA, 0, PxbgljGkwMmGTQvdVXbviUnrjblXA.Length);
			bool flag3 = false;
			if (VkCMutnBYOpRWflEWRKZAofzWbcN(128, (byte)(flag2 ? 18 : 29), 9, VLekNgFaZgFxOXEQRpwhbzdTsrPt))
			{
				for (int i = 0; i < 9; i++)
				{
					if (VLekNgFaZgFxOXEQRpwhbzdTsrPt[i] != byte.MaxValue)
					{
						flag3 = true;
					}
				}
			}
			if (!flag3 && VkCMutnBYOpRWflEWRKZAofzWbcN(96, (byte)(flag2 ? 61 : 70), 9, VLekNgFaZgFxOXEQRpwhbzdTsrPt))
			{
				flag3 = true;
			}
			if (flag3)
			{
				CNwlIMCmCdGhJiOlUBAFOiSkdrLEA cNwlIMCmCdGhJiOlUBAFOiSkdrLEA = new CNwlIMCmCdGhJiOlUBAFOiSkdrLEA();
				CNwlIMCmCdGhJiOlUBAFOiSkdrLEA cNwlIMCmCdGhJiOlUBAFOiSkdrLEA2 = new CNwlIMCmCdGhJiOlUBAFOiSkdrLEA();
				nAPNoJTyMUHSGaBMUDRWQRQiNJVh(VLekNgFaZgFxOXEQRpwhbzdTsrPt, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA2, flag2);
				PxbgljGkwMmGTQvdVXbviUnrjblXA[0] = cNwlIMCmCdGhJiOlUBAFOiSkdrLEA;
				PxbgljGkwMmGTQvdVXbviUnrjblXA[1] = cNwlIMCmCdGhJiOlUBAFOiSkdrLEA2;
				flag = true;
				if (VkCMutnBYOpRWflEWRKZAofzWbcN(96, (byte)(flag2 ? 134 : 152), 16, VLekNgFaZgFxOXEQRpwhbzdTsrPt))
				{
					JNWnGKMXVPreWBsERAmjDNzucOMe(VLekNgFaZgFxOXEQRpwhbzdTsrPt, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA2);
				}
			}
			else
			{
				flag = false;
			}
			if (_controllerType == BcXVNrwlGYMmCDHjgcGZTTSoSUao.ProController)
			{
				bool flag4 = false;
				if (VkCMutnBYOpRWflEWRKZAofzWbcN(128, (byte)((!flag2) ? 18 : 29), 9, VLekNgFaZgFxOXEQRpwhbzdTsrPt))
				{
					for (int j = 0; j < 9; j++)
					{
						if (VLekNgFaZgFxOXEQRpwhbzdTsrPt[j] != byte.MaxValue)
						{
							flag4 = true;
						}
					}
				}
				if (!flag4 && VkCMutnBYOpRWflEWRKZAofzWbcN(96, (byte)((!flag2) ? 61 : 70), 9, VLekNgFaZgFxOXEQRpwhbzdTsrPt))
				{
					flag4 = true;
				}
				if (flag4)
				{
					CNwlIMCmCdGhJiOlUBAFOiSkdrLEA cNwlIMCmCdGhJiOlUBAFOiSkdrLEA3 = new CNwlIMCmCdGhJiOlUBAFOiSkdrLEA();
					CNwlIMCmCdGhJiOlUBAFOiSkdrLEA cNwlIMCmCdGhJiOlUBAFOiSkdrLEA4 = new CNwlIMCmCdGhJiOlUBAFOiSkdrLEA();
					nAPNoJTyMUHSGaBMUDRWQRQiNJVh(VLekNgFaZgFxOXEQRpwhbzdTsrPt, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA3, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA4, !flag2);
					PxbgljGkwMmGTQvdVXbviUnrjblXA[2] = cNwlIMCmCdGhJiOlUBAFOiSkdrLEA3;
					PxbgljGkwMmGTQvdVXbviUnrjblXA[3] = cNwlIMCmCdGhJiOlUBAFOiSkdrLEA4;
					flag = true;
					if (VkCMutnBYOpRWflEWRKZAofzWbcN(96, (byte)((!flag2) ? 134 : 152), 16, VLekNgFaZgFxOXEQRpwhbzdTsrPt))
					{
						JNWnGKMXVPreWBsERAmjDNzucOMe(VLekNgFaZgFxOXEQRpwhbzdTsrPt, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA3, cNwlIMCmCdGhJiOlUBAFOiSkdrLEA4);
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private static void nAPNoJTyMUHSGaBMUDRWQRQiNJVh(byte[] P_0, CNwlIMCmCdGhJiOlUBAFOiSkdrLEA P_1, CNwlIMCmCdGhJiOlUBAFOiSkdrLEA P_2, bool P_3)
		{
			ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
			ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
			ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
			ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
			ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
			if (P_3)
			{
				P_1.tXsJZoXxYdujtiikcsPmsycGUoYq = num;
				P_2.tXsJZoXxYdujtiikcsPmsycGUoYq = num2;
				P_1.KSaIbiEcoogmAhLcgGyJqemfdvAfA = num3;
				P_2.KSaIbiEcoogmAhLcgGyJqemfdvAfA = num4;
				P_1.tBteoKDbTjOocipwjJvjbHxnixrbb = num5;
				P_2.tBteoKDbTjOocipwjJvjbHxnixrbb = num6;
			}
			else
			{
				P_1.KSaIbiEcoogmAhLcgGyJqemfdvAfA = num;
				P_2.KSaIbiEcoogmAhLcgGyJqemfdvAfA = num2;
				P_1.tBteoKDbTjOocipwjJvjbHxnixrbb = num3;
				P_2.tBteoKDbTjOocipwjJvjbHxnixrbb = num4;
				P_1.tXsJZoXxYdujtiikcsPmsycGUoYq = num5;
				P_2.tXsJZoXxYdujtiikcsPmsycGUoYq = num6;
			}
		}

		private static void JNWnGKMXVPreWBsERAmjDNzucOMe(byte[] P_0, CNwlIMCmCdGhJiOlUBAFOiSkdrLEA P_1, CNwlIMCmCdGhJiOlUBAFOiSkdrLEA P_2)
		{
			P_1.dhkKcvDrOauArpeblBJLkybNqjaoA = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			P_2.dhkKcvDrOauArpeblBJLkybNqjaoA = P_1.dhkKcvDrOauArpeblBJLkybNqjaoA;
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, CNwlIMCmCdGhJiOlUBAFOiSkdrLEA calX, CNwlIMCmCdGhJiOlUBAFOiSkdrLEA calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort dhkKcvDrOauArpeblBJLkybNqjaoA = calX.dhkKcvDrOauArpeblBJLkybNqjaoA;
			float num = valueX - calX.KSaIbiEcoogmAhLcgGyJqemfdvAfA;
			float num2 = valueY - calY.KSaIbiEcoogmAhLcgGyJqemfdvAfA;
			if (Math.Abs(num * num + num2 * num2) < (float)(dhkKcvDrOauArpeblBJLkybNqjaoA * dhkKcvDrOauArpeblBJLkybNqjaoA))
			{
				return false;
			}
			calibratedX = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num / (float)(int)((num > 0f) ? calX.tXsJZoXxYdujtiikcsPmsycGUoYq : calX.tBteoKDbTjOocipwjJvjbHxnixrbb), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num2 / (float)(int)((num2 > 0f) ? calY.tXsJZoXxYdujtiikcsPmsycGUoYq : calY.tBteoKDbTjOocipwjJvjbHxnixrbb), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			return true;
		}

		protected CNwlIMCmCdGhJiOlUBAFOiSkdrLEA GetAxisCalibration(int index)
		{
			return PxbgljGkwMmGTQvdVXbviUnrjblXA[index];
		}

		private void BXveugFsOOakCunOsUGKXwNzrWXd(bool P_0)
		{
			if (BICqhsDMFRZCgGIIXhOohxsJGGMY && !P_0)
			{
				wXRKQHIAvlpAQHsffSsAPKcDdxzn = ReInput.realTime;
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
				ReInput.ApplicationPauseChangedEvent -= BXveugFsOOakCunOsUGKXwNzrWXd;
				if (!lLeFlZzrJQQoaCIEtCwMdWuGxZEV && cdKETPsvbvSQvFvaLkOLPhlyVFtu != null)
				{
					cdKETPsvbvSQvFvaLkOLPhlyVFtu.Clear();
					cdKETPsvbvSQvFvaLkOLPhlyVFtu[0] = 128;
					cdKETPsvbvSQvFvaLkOLPhlyVFtu[1] = 5;
					try
					{
						uVCACDlVhuqkrYJOZfKQMOHXWoOE.WriteSync(UECIIqCldToTymhiaCSqdKuBRktpb, 0);
					}
					catch
					{
					}
					cdKETPsvbvSQvFvaLkOLPhlyVFtu.Clear();
					cdKETPsvbvSQvFvaLkOLPhlyVFtu[0] = 128;
					cdKETPsvbvSQvFvaLkOLPhlyVFtu[1] = 6;
					try
					{
						uVCACDlVhuqkrYJOZfKQMOHXWoOE.WriteSync(UECIIqCldToTymhiaCSqdKuBRktpb, 0);
					}
					catch
					{
					}
				}
				if (orxMpJYrUkADMSWTLHrYoYOGATxb != null)
				{
					orxMpJYrUkADMSWTLHrYoYOGATxb.Dispose();
				}
				if (cdKETPsvbvSQvFvaLkOLPhlyVFtu != null)
				{
					cdKETPsvbvSQvFvaLkOLPhlyVFtu.Dispose();
				}
				if (VymGRxHGVypsQBFEEthUkAqLidlDb != null)
				{
					VymGRxHGVypsQBFEEthUkAqLidlDb.Dispose();
				}
				if (GXikoSsJPBxrmIPQlgLhMmXUiQYL != null)
				{
					GXikoSsJPBxrmIPQlgLhMmXUiQYL.Dispose();
				}
				if (oZHqBZieHDtVWSVyjYAsYeFIWPaK == null)
				{
					oZHqBZieHDtVWSVyjYAsYeFIWPaK.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private static void EwYrLuPoEwjedyHpsQZiOBZofuSFA(NativeBuffer P_0, int P_1)
		{
			P_0.TryWriteBytes(ZzvHECAlxobIWaqVDniPuFTVLlVkA, ZzvHECAlxobIWaqVDniPuFTVLlVkA.Length, P_1);
		}

		private static void lsfQurCZscbmuYEjvsVENZwjDDQm(byte[] P_0, int P_1)
		{
			Array.Copy(ZzvHECAlxobIWaqVDniPuFTVLlVkA, 0, P_0, P_1, ZzvHECAlxobIWaqVDniPuFTVLlVkA.Length);
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
