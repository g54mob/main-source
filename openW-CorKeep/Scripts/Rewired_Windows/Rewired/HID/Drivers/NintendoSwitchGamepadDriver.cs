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
		protected enum yLpbwZJUFNkRouxglOYNdRyBNHOG
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class YeaAQADPQMsdYWaxpIFbZaIqSbdMA
		{
			private OuyedDeYgCfMJhRepxbdANVcvqtM faWgWvePOmqwrucTSbDvjuZqSOGo;

			private QcCssoCbfSGRfkQchmIULAFUgwPs YhhqovPaHZTfTYoAqYglzLXQCJUZ;

			private float UoAtTDPEFvOvrPpgFalUsBrxlszU;

			private double QdZDDBbdvlGNzatsCBgzJlGAPOihD;

			public QcCssoCbfSGRfkQchmIULAFUgwPs fHigMnZyzxTMioMyWPRjQzSFCFYP => YhhqovPaHZTfTYoAqYglzLXQCJUZ;

			public YeaAQADPQMsdYWaxpIFbZaIqSbdMA(OuyedDeYgCfMJhRepxbdANVcvqtM P_0)
			{
				faWgWvePOmqwrucTSbDvjuZqSOGo = P_0;
				UMrbZEfDXftdAlVnbUZQqMMAgbvcA();
			}

			public void NKnhsYMiEGzBquCGpnHTGfGMiLUBA(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
				if (P_4 < 0f)
				{
					P_4 = 0f;
				}
				UoAtTDPEFvOvrPpgFalUsBrxlszU = P_4;
				YhhqovPaHZTfTYoAqYglzLXQCJUZ.cdHQDZxAaqVvKEXVJdVONEamrOMM = MathTools.Clamp01(P_0);
				YhhqovPaHZTfTYoAqYglzLXQCJUZ.HAyeIEbcuaeAxaiFACKabGLFjEHvb = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
				YhhqovPaHZTfTYoAqYglzLXQCJUZ.XwyjIzMnktiNRVDJWbpTrXHKAsCz = MathTools.Clamp01(P_2);
				YhhqovPaHZTfTYoAqYglzLXQCJUZ.mricfIduxQqDnjJtfIOngeoOGColA = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
				faWgWvePOmqwrucTSbDvjuZqSOGo.kebuKyNPnNUAwnkFlyJfDbfeAhBW = Math.Max(YhhqovPaHZTfTYoAqYglzLXQCJUZ.cdHQDZxAaqVvKEXVJdVONEamrOMM, YhhqovPaHZTfTYoAqYglzLXQCJUZ.XwyjIzMnktiNRVDJWbpTrXHKAsCz);
				QdZDDBbdvlGNzatsCBgzJlGAPOihD = ReInput.realTime;
			}

			public void RNjNtIEWfJWiZpeZhKQubnuTYvTg(double P_0)
			{
				if ((YhhqovPaHZTfTYoAqYglzLXQCJUZ.cdHQDZxAaqVvKEXVJdVONEamrOMM > 0f || YhhqovPaHZTfTYoAqYglzLXQCJUZ.XwyjIzMnktiNRVDJWbpTrXHKAsCz > 0f) && UoAtTDPEFvOvrPpgFalUsBrxlszU > 0f && P_0 >= QdZDDBbdvlGNzatsCBgzJlGAPOihD + (double)UoAtTDPEFvOvrPpgFalUsBrxlszU)
				{
					CFjucjfBokAfxdwaqAXJFftGjPQwA();
				}
			}

			public void CFjucjfBokAfxdwaqAXJFftGjPQwA()
			{
				YhhqovPaHZTfTYoAqYglzLXQCJUZ.XwyjIzMnktiNRVDJWbpTrXHKAsCz = 0f;
				YhhqovPaHZTfTYoAqYglzLXQCJUZ.cdHQDZxAaqVvKEXVJdVONEamrOMM = 0f;
				faWgWvePOmqwrucTSbDvjuZqSOGo.rXanWTxGcklOZyeDGcMFZMCGBbhL = 0;
				UoAtTDPEFvOvrPpgFalUsBrxlszU = 0f;
				QdZDDBbdvlGNzatsCBgzJlGAPOihD = ReInput.realTime;
			}

			public void UMrbZEfDXftdAlVnbUZQqMMAgbvcA()
			{
				YhhqovPaHZTfTYoAqYglzLXQCJUZ = QcCssoCbfSGRfkQchmIULAFUgwPs.WKslORwmjiPyhdtAGkHtYRYmYQMC();
				faWgWvePOmqwrucTSbDvjuZqSOGo.rXanWTxGcklOZyeDGcMFZMCGBbhL = 0;
				UoAtTDPEFvOvrPpgFalUsBrxlszU = 0f;
				QdZDDBbdvlGNzatsCBgzJlGAPOihD = 0.0;
			}
		}

		protected struct QcCssoCbfSGRfkQchmIULAFUgwPs
		{
			public const int irlxuvhEleOPYkzEULoQTEJDjOXR = 160;

			public const int NTaUMitOvTjTJPpCxDKBCRBbCoYXA = 320;

			public float cdHQDZxAaqVvKEXVJdVONEamrOMM;

			public float HAyeIEbcuaeAxaiFACKabGLFjEHvb;

			public float XwyjIzMnktiNRVDJWbpTrXHKAsCz;

			public float mricfIduxQqDnjJtfIOngeoOGColA;

			internal QcCssoCbfSGRfkQchmIULAFUgwPs(float P_0, float P_1, float P_2, float P_3)
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
				cdHQDZxAaqVvKEXVJdVONEamrOMM = P_0;
				HAyeIEbcuaeAxaiFACKabGLFjEHvb = P_1;
				XwyjIzMnktiNRVDJWbpTrXHKAsCz = P_2;
				mricfIduxQqDnjJtfIOngeoOGColA = P_3;
			}

			public static QcCssoCbfSGRfkQchmIULAFUgwPs WKslORwmjiPyhdtAGkHtYRYmYQMC()
			{
				return new QcCssoCbfSGRfkQchmIULAFUgwPs(0f, 160f, 0f, 320f);
			}

			public string VGafVkvuILdWifwBBuzEShNfjrpmA()
			{
				return "amplitudeLow: " + cdHQDZxAaqVvKEXVJdVONEamrOMM + ", frequencyLow: " + HAyeIEbcuaeAxaiFACKabGLFjEHvb + ", amplitudeHigh: " + XwyjIzMnktiNRVDJWbpTrXHKAsCz + ", frequencyHigh: " + mricfIduxQqDnjJtfIOngeoOGColA;
			}
		}

		private struct hdXxgasagMjZbaZiVAeujVcDZpweA
		{
			public byte qqkGbaCIhdvPpbMwjAWkBweHIMBk;

			public byte[] jWtpVMleyxsBDEcjGsQfgYDGBBZl;

			public int dEQMoeiOoJfENjicSVSZxORODzu;

			public hdXxgasagMjZbaZiVAeujVcDZpweA(byte P_0, byte[] P_1, int P_2)
			{
				qqkGbaCIhdvPpbMwjAWkBweHIMBk = P_0;
				jWtpVMleyxsBDEcjGsQfgYDGBBZl = P_1;
				dEQMoeiOoJfENjicSVSZxORODzu = P_2;
			}
		}

		protected class drUhrinNPucRxTwgPGMBgegBBqdIA
		{
			public ushort USTXPeKwIyOOAIixwPdptPXMekVo;

			public ushort KnUNgSciNoxZHPOxndZgAGObabwCA;

			public ushort ppCvuUvavpaCeYbhnBwZcCGQmkaxA;

			public ushort MrILFTiDVxKkTWgwkeLVDMPkKuKXA;

			public virtual string BFQMuzqnqKWnXyESrbyolDJRcqCd()
			{
				return "min: " + USTXPeKwIyOOAIixwPdptPXMekVo + ", max: " + KnUNgSciNoxZHPOxndZgAGObabwCA + ", zero: " + ppCvuUvavpaCeYbhnBwZcCGQmkaxA + ", deadzone: " + MrILFTiDVxKkTWgwkeLVDMPkKuKXA;
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

		protected readonly yLpbwZJUFNkRouxglOYNdRyBNHOG _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice LIcjIzUUhdWFFbCGUfvKkmViJEig;

		private readonly HIDProperties VcvGSzdXotZHuVuMaJNDkPIHPejuA;

		private readonly bool YRYoIlAdYNBKOixJslmEPLMprKmHA;

		private readonly NativeBuffer XNXpCXzcoryxzhPHGHgpKsWtHEnE;

		private readonly NativeBuffer DFsuRxNKqgwAPkTbYQbXxpDXGCVH;

		private readonly NativeBuffer RIfDvnFdGYkZgbedcVKkyebnxZKu;

		private readonly byte[] qpKRkUsOMpNYiaaLKerlVwVqwfzI;

		private readonly NativeBuffer mPWVqZlPIpBQuyVLVBnUecAcacNzA;

		private readonly NativeBuffer doENNsXWYQjBGbLNelFhcQpnWbuS;

		private MwEMUNdEdQpngdbXMtjwIdOvEFgfA tJsvjECNcSqhMYLrdLOuyoQaErVIA;

		private double GeIoFvhvHxcZWhnnBIsqyuumRroP;

		private byte SFxLMILxjCnFnJImLBlDgVEdRaleA;

		private double HnjozlzYuiDkceOgwZgCfdMgqqTO;

		private bool sOmfYAgBIWgqWFhRGECwBZOgaBiPb;

		private bool zTYvncIBdKsohvQnmaiSoyHqKapg;

		private YeaAQADPQMsdYWaxpIFbZaIqSbdMA[] jrpsLKjollKMYJVBabXGytqmHBMp;

		private drUhrinNPucRxTwgPGMBgegBBqdIA[] irPvOXFlnFqunAaoEjtbhqDGRcZqA;

		private static readonly byte[] qETLngrjetckkcHIOBuBFhvFqenqb = new byte[8] { 0, 1, 64, 64, 0, 1, 64, 64 };

		int IDriver_NintendoSwitchController.vibrationMotorCount => _vibrationMotorCount;

		ushort IHIDControllerExtension.vendorId => VcvGSzdXotZHuVuMaJNDkPIHPejuA.vendorId;

		ushort IHIDControllerExtension.productId => VcvGSzdXotZHuVuMaJNDkPIHPejuA.productId;

		string IHIDControllerExtension.productName => VcvGSzdXotZHuVuMaJNDkPIHPejuA.productName;

		string IHIDControllerExtension.manufacturer => VcvGSzdXotZHuVuMaJNDkPIHPejuA.manufacturer;

		ushort IHIDControllerExtension.usagePage => VcvGSzdXotZHuVuMaJNDkPIHPejuA.usagePage;

		ushort IHIDControllerExtension.usage => VcvGSzdXotZHuVuMaJNDkPIHPejuA.usage;

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
				QcCssoCbfSGRfkQchmIULAFUgwPs qcCssoCbfSGRfkQchmIULAFUgwPs = jrpsLKjollKMYJVBabXGytqmHBMp[motorIndex].fHigMnZyzxTMioMyWPRjQzSFCFYP;
				amplitudeLow = qcCssoCbfSGRfkQchmIULAFUgwPs.cdHQDZxAaqVvKEXVJdVONEamrOMM;
				frequencyLow = qcCssoCbfSGRfkQchmIULAFUgwPs.HAyeIEbcuaeAxaiFACKabGLFjEHvb;
				amplitudeHigh = qcCssoCbfSGRfkQchmIULAFUgwPs.XwyjIzMnktiNRVDJWbpTrXHKAsCz;
				frequencyHigh = qcCssoCbfSGRfkQchmIULAFUgwPs.mricfIduxQqDnjJtfIOngeoOGColA;
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
					cnzilXFsxEluofIcokNRtHehscK(motorIndex);
				}
				jrpsLKjollKMYJVBabXGytqmHBMp[motorIndex].NKnhsYMiEGzBquCGpnHTGfGMiLUBA(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
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
				jrpsLKjollKMYJVBabXGytqmHBMp[motorIndex].CFjucjfBokAfxdwaqAXJFftGjPQwA();
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
				jrpsLKjollKMYJVBabXGytqmHBMp[i].CFjucjfBokAfxdwaqAXJFftGjPQwA();
			}
		}

		void IDriver_NintendoSwitchController.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		private void cnzilXFsxEluofIcokNRtHehscK(int P_0)
		{
			for (int i = 0; i < jrpsLKjollKMYJVBabXGytqmHBMp.Length; i++)
			{
				if (i != P_0)
				{
					jrpsLKjollKMYJVBabXGytqmHBMp[i].CFjucjfBokAfxdwaqAXJFftGjPQwA();
				}
			}
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, yLpbwZJUFNkRouxglOYNdRyBNHOG P_1, int P_2, int P_3, int P_4)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			_controllerType = P_1;
			_buttonCount = P_2;
			_axisCount = P_3;
			_vibrationMotorCount = P_4;
			LIcjIzUUhdWFFbCGUfvKkmViJEig = P_0.hidDevice;
			VcvGSzdXotZHuVuMaJNDkPIHPejuA = P_0.hidDevice.properties;
			YRYoIlAdYNBKOixJslmEPLMprKmHA = P_0.connectionType == gQgddHFyNfVGfPIXZPBcuigOMkbz.Bluetooth;
			XNXpCXzcoryxzhPHGHgpKsWtHEnE = new NativeBuffer(VcvGSzdXotZHuVuMaJNDkPIHPejuA.maxInputReportLength);
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH = new NativeBuffer(VcvGSzdXotZHuVuMaJNDkPIHPejuA.maxOutputReportLength);
			RIfDvnFdGYkZgbedcVKkyebnxZKu = new NativeBuffer(32);
			qpKRkUsOMpNYiaaLKerlVwVqwfzI = new byte[VcvGSzdXotZHuVuMaJNDkPIHPejuA.maxInputReportLength];
			mPWVqZlPIpBQuyVLVBnUecAcacNzA = new NativeBuffer(VcvGSzdXotZHuVuMaJNDkPIHPejuA.maxOutputReportLength);
			doENNsXWYQjBGbLNelFhcQpnWbuS = new NativeBuffer(49);
			if (VcvGSzdXotZHuVuMaJNDkPIHPejuA.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			tJsvjECNcSqhMYLrdLOuyoQaErVIA = new MwEMUNdEdQpngdbXMtjwIdOvEFgfA(DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Pointer, DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Length, DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Length);
			sOmfYAgBIWgqWFhRGECwBZOgaBiPb = !YRYoIlAdYNBKOixJslmEPLMprKmHA && UnityTools.effectivePlatform == Platform.Windows;
			ReInput.ApplicationPauseChangedEvent += qoDTESqhLFQdqZsztOSGjUPAeWjC;
			buttons = new jIFGialkYdAmDDAGsjKrXJoDparB[P_2];
			for (int i = 0; i < P_2; i++)
			{
				buttons[i] = new jIFGialkYdAmDDAGsjKrXJoDparB(33, new tNSBtIwTqUeWpGtNoXsrdaEOoFDcA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			irPvOXFlnFqunAaoEjtbhqDGRcZqA = new drUhrinNPucRxTwgPGMBgegBBqdIA[_axisCount];
			vibrationMotors = new OuyedDeYgCfMJhRepxbdANVcvqtM[P_4];
			for (int j = 0; j < vibrationMotors.Length; j++)
			{
				vibrationMotors[j] = new OuyedDeYgCfMJhRepxbdANVcvqtM(0, 255);
			}
			jrpsLKjollKMYJVBabXGytqmHBMp = new YeaAQADPQMsdYWaxpIFbZaIqSbdMA[P_4];
			for (int k = 0; k < jrpsLKjollKMYJVBabXGytqmHBMp.Length; k++)
			{
				jrpsLKjollKMYJVBabXGytqmHBMp[k] = new YeaAQADPQMsdYWaxpIFbZaIqSbdMA(vibrationMotors[k]);
			}
		}

		protected void Initialize()
		{
			zTYvncIBdKsohvQnmaiSoyHqKapg = false;
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Clear();
			if (!YRYoIlAdYNBKOixJslmEPLMprKmHA)
			{
				NativeBuffer dFsuRxNKqgwAPkTbYQbXxpDXGCVH = DFsuRxNKqgwAPkTbYQbXxpDXGCVH;
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 1;
				if (!sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB connection status.", requiredThreadSafety: true);
					throw new Exception();
				}
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 2;
				if (!sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 1.", requiredThreadSafety: true);
					throw new Exception();
				}
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 3;
				if (!sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB set baudrate.", requiredThreadSafety: true);
					throw new Exception();
				}
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 2;
				if (!sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 2.", requiredThreadSafety: true);
					throw new Exception();
				}
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
				dFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 4;
				if (!sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB prevent hid timeout.", requiredThreadSafety: true);
					throw new Exception();
				}
			}
			if (!JMMJQIsbCyDvCBaocpaBCWNmTRok(new hdXxgasagMjZbaZiVAeujVcDZpweA(72, new byte[1] { 1 }, 1), qpKRkUsOMpNYiaaLKerlVwVqwfzI))
			{
				throw new Exception();
			}
			if (!JMMJQIsbCyDvCBaocpaBCWNmTRok(new hdXxgasagMjZbaZiVAeujVcDZpweA(3, new byte[1] { 48 }, 1), qpKRkUsOMpNYiaaLKerlVwVqwfzI))
			{
				throw new Exception();
			}
			UzQFOuueERTKejpCcailpNvuNQVy();
			if (!RbvPmxcCjZKlrsLPVUMLyHxpeqUu())
			{
				throw new Exception();
			}
			if (sOmfYAgBIWgqWFhRGECwBZOgaBiPb)
			{
				HnjozlzYuiDkceOgwZgCfdMgqqTO = ReInput.realTime;
			}
			zTYvncIBdKsohvQnmaiSoyHqKapg = true;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			double realTime = ReInput.realTime;
			if (sOmfYAgBIWgqWFhRGECwBZOgaBiPb && realTime >= HnjozlzYuiDkceOgwZgCfdMgqqTO + 1.0)
			{
				try
				{
					Initialize();
				}
				catch
				{
					Logger.LogWarning("Error re-initializing Nintendo Switch Pro Controller. Will retry.");
					HnjozlzYuiDkceOgwZgCfdMgqqTO = realTime;
				}
			}
			for (int i = 0; i < jrpsLKjollKMYJVBabXGytqmHBMp.Length; i++)
			{
				jrpsLKjollKMYJVBabXGytqmHBMp[i].RNjNtIEWfJWiZpeZhKQubnuTYvTg(realTime);
			}
			if (realTime >= GeIoFvhvHxcZWhnnBIsqyuumRroP + 0.01515151560306549)
			{
				GeIoFvhvHxcZWhnnBIsqyuumRroP = realTime;
				HcuWsCQmMIWduhKGFByARbtbWujF(DFsuRxNKqgwAPkTbYQbXxpDXGCVH);
				sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous);
			}
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (!zTYvncIBdKsohvQnmaiSoyHqKapg)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (XNXpCXzcoryxzhPHGHgpKsWtHEnE.Length < 49)
			{
				return false;
			}
			if (Marshal.ReadByte(inputReportPtr, 0) != 33)
			{
				return false;
			}
			if (sOmfYAgBIWgqWFhRGECwBZOgaBiPb)
			{
				HnjozlzYuiDkceOgwZgCfdMgqqTO = ReInput.realTime;
			}
			int numBytesToWrite = Math.Min(inputReportLength, XNXpCXzcoryxzhPHGHgpKsWtHEnE.Length);
			XNXpCXzcoryxzhPHGHgpKsWtHEnE.Write(inputReportPtr, inputReportLength, numBytesToWrite);
			UpdateButtons(XNXpCXzcoryxzhPHGHgpKsWtHEnE, timestamp);
			tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] elements = axes;
			UpdateElements(elements, XNXpCXzcoryxzhPHGHgpKsWtHEnE, timestamp);
			return true;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] elements, NativeBuffer inputReport, double timestamp);

		private bool JMMJQIsbCyDvCBaocpaBCWNmTRok(hdXxgasagMjZbaZiVAeujVcDZpweA P_0, byte[] P_1)
		{
			try
			{
				if (P_0.jWtpVMleyxsBDEcjGsQfgYDGBBZl.Length + 11 > mPWVqZlPIpBQuyVLVBnUecAcacNzA.Length)
				{
					return false;
				}
				HcuWsCQmMIWduhKGFByARbtbWujF(mPWVqZlPIpBQuyVLVBnUecAcacNzA);
				mPWVqZlPIpBQuyVLVBnUecAcacNzA[10] = P_0.qqkGbaCIhdvPpbMwjAWkBweHIMBk;
				mPWVqZlPIpBQuyVLVBnUecAcacNzA.TryWriteBytes(P_0.jWtpVMleyxsBDEcjGsQfgYDGBBZl, P_0.dEQMoeiOoJfENjicSVSZxORODzu, 11);
				int num = 2;
				bool flag = false;
				int num2 = 0;
				double num3 = 0.0;
				while (LIcjIzUUhdWFFbCGUfvKkmViJEig.ReadSync(doENNsXWYQjBGbLNelFhcQpnWbuS, doENNsXWYQjBGbLNelFhcQpnWbuS.Length, 1))
				{
				}
				for (int i = 0; i < num; i++)
				{
					Array.Clear(P_1, 0, P_1.Length);
					doENNsXWYQjBGbLNelFhcQpnWbuS.Clear();
					hnjBYqDLhNxMXNUKPkHHqvBIQIfw(mPWVqZlPIpBQuyVLVBnUecAcacNzA, P_0.qqkGbaCIhdvPpbMwjAWkBweHIMBk);
					num3 = ReInput.realTime;
					if (i == 0)
					{
						_ = ReInput.realTime;
					}
					int num4 = 0;
					while (!(ReInput.realTime >= num3 + 0.5))
					{
						if (LIcjIzUUhdWFFbCGUfvKkmViJEig.ReadSync(doENNsXWYQjBGbLNelFhcQpnWbuS, doENNsXWYQjBGbLNelFhcQpnWbuS.Length, 200) && doENNsXWYQjBGbLNelFhcQpnWbuS[0] == 33)
						{
							if (doENNsXWYQjBGbLNelFhcQpnWbuS[14] == P_0.qqkGbaCIhdvPpbMwjAWkBweHIMBk)
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
					doENNsXWYQjBGbLNelFhcQpnWbuS.Read(P_1, doENNsXWYQjBGbLNelFhcQpnWbuS.Length);
				}
				return flag;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool hnjBYqDLhNxMXNUKPkHHqvBIQIfw(NativeBuffer P_0, byte P_1)
		{
			if (!LIcjIzUUhdWFFbCGUfvKkmViJEig.WriteSync(new MwEMUNdEdQpngdbXMtjwIdOvEFgfA(P_0, P_0.Length, P_0.Length), 1000))
			{
				return false;
			}
			return true;
		}

		private void LgcjnWrxxXDDMsCSdbbmqMlZABfP(byte P_0)
		{
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Clear();
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 146;
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH[2] = 0;
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH[3] = 49;
			DFsuRxNKqgwAPkTbYQbXxpDXGCVH[8] = P_0;
		}

		private void hbyXXMJifMmcPUnKhYLZdmkgITeR(byte P_0, NativeBuffer P_1, int P_2, pVnphHvTNRURYWZADvNPfpgNNbuB P_3)
		{
			LgcjnWrxxXDDMsCSdbbmqMlZABfP(P_0);
			if (P_2 > 0)
			{
				DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Write(P_1, P_2, 9);
			}
		}

		private void HcuWsCQmMIWduhKGFByARbtbWujF(NativeBuffer P_0)
		{
			P_0.Clear();
			P_0[0] = 1;
			P_0[1] = qXKBUdaMkVORRfAaudNPHNZWNhIMA();
			CnQuHYKhpUIPUccvmeodwOMJGDgxA(P_0, 2);
		}

		private void CnQuHYKhpUIPUccvmeodwOMJGDgxA(NativeBuffer P_0, int P_1)
		{
			if (_controllerType == yLpbwZJUFNkRouxglOYNdRyBNHOG.JoyConRight)
			{
				P_1 += 4;
			}
			for (int i = 0; i < jrpsLKjollKMYJVBabXGytqmHBMp.Length; i++)
			{
				qclevnGzQISwGtJuQfaQiZOmnLkab(P_0, P_1, jrpsLKjollKMYJVBabXGytqmHBMp[i].fHigMnZyzxTMioMyWPRjQzSFCFYP);
				P_1 += 4;
			}
		}

		private static void qclevnGzQISwGtJuQfaQiZOmnLkab(NativeBuffer P_0, int P_1, QcCssoCbfSGRfkQchmIULAFUgwPs P_2)
		{
			if (P_2.cdHQDZxAaqVvKEXVJdVONEamrOMM == 0f && P_2.XwyjIzMnktiNRVDJWbpTrXHKAsCz == 0f)
			{
				P_0[P_1] = 0;
				P_0[1 + P_1] = 1;
				P_0[2 + P_1] = 64;
				P_0[3 + P_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.mricfIduxQqDnjJtfIOngeoOGColA * 0.1f, 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.HAyeIEbcuaeAxaiFACKabGLFjEHvb * 0.1f, 2.0)) - 64.0);
			byte b2 = axYjFIBXxklcgcXnNJAWDbnBVCjl(P_2.XwyjIzMnktiNRVDJWbpTrXHKAsCz);
			ushort num2 = (ushort)(Math.Round((double)(int)axYjFIBXxklcgcXnNJAWDbnBVCjl(P_2.cdHQDZxAaqVvKEXVJdVONEamrOMM)) * 0.5);
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

		private static byte axYjFIBXxklcgcXnNJAWDbnBVCjl(float P_0)
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

		private void ZUstjeFQzIvqBHznbulrGwghmibF(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			NativeBuffer rIfDvnFdGYkZgbedcVKkyebnxZKu = RIfDvnFdGYkZgbedcVKkyebnxZKu;
			rIfDvnFdGYkZgbedcVKkyebnxZKu[0] = qXKBUdaMkVORRfAaudNPHNZWNhIMA();
			CnQuHYKhpUIPUccvmeodwOMJGDgxA(rIfDvnFdGYkZgbedcVKkyebnxZKu, 1);
			hbyXXMJifMmcPUnKhYLZdmkgITeR(16, rIfDvnFdGYkZgbedcVKkyebnxZKu, 9, P_0);
			sNEYrPsIMnHVVSNILpYLZXraqtPv(P_0);
		}

		private bool UzQFOuueERTKejpCcailpNvuNQVy()
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return JMMJQIsbCyDvCBaocpaBCWNmTRok(new hdXxgasagMjZbaZiVAeujVcDZpweA(56, array, 25), qpKRkUsOMpNYiaaLKerlVwVqwfzI);
		}

		private bool OahZosrLhmMgrnquupYSpdlzjTvaA(bool P_0)
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
			return JMMJQIsbCyDvCBaocpaBCWNmTRok(new hdXxgasagMjZbaZiVAeujVcDZpweA(56, array, 25), qpKRkUsOMpNYiaaLKerlVwVqwfzI);
		}

		private bool uTggNPQCHZQtwCZVZRMBwGNMXaCT(byte P_0, byte P_1, byte P_2, byte[] P_3)
		{
			byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (JMMJQIsbCyDvCBaocpaBCWNmTRok(new hdXxgasagMjZbaZiVAeujVcDZpweA(16, array, array.Length), P_3) && P_3[15] == P_1 && P_3[16] == P_0)
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

		private bool sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			switch (P_0)
			{
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Synchronous:
				return LIcjIzUUhdWFFbCGUfvKkmViJEig.WriteSync(tJsvjECNcSqhMYLrdLOuyoQaErVIA, 0);
			case pVnphHvTNRURYWZADvNPfpgNNbuB.Asynchronous:
				LIcjIzUUhdWFFbCGUfvKkmViJEig.WriteAsync(tJsvjECNcSqhMYLrdLOuyoQaErVIA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private byte qXKBUdaMkVORRfAaudNPHNZWNhIMA()
		{
			if (SFxLMILxjCnFnJImLBlDgVEdRaleA == 15)
			{
				SFxLMILxjCnFnJImLBlDgVEdRaleA = 0;
			}
			else
			{
				SFxLMILxjCnFnJImLBlDgVEdRaleA++;
			}
			return SFxLMILxjCnFnJImLBlDgVEdRaleA;
		}

		private bool RbvPmxcCjZKlrsLPVUMLyHxpeqUu()
		{
			bool flag = false;
			bool flag2 = _controllerType == yLpbwZJUFNkRouxglOYNdRyBNHOG.JoyConLeft || _controllerType == yLpbwZJUFNkRouxglOYNdRyBNHOG.ProController;
			Array.Clear(irPvOXFlnFqunAaoEjtbhqDGRcZqA, 0, irPvOXFlnFqunAaoEjtbhqDGRcZqA.Length);
			bool flag3 = false;
			if (uTggNPQCHZQtwCZVZRMBwGNMXaCT(128, (byte)(flag2 ? 18 : 29), 9, qpKRkUsOMpNYiaaLKerlVwVqwfzI))
			{
				for (int i = 0; i < 9; i++)
				{
					if (qpKRkUsOMpNYiaaLKerlVwVqwfzI[i] != byte.MaxValue)
					{
						flag3 = true;
					}
				}
			}
			if (!flag3 && uTggNPQCHZQtwCZVZRMBwGNMXaCT(96, (byte)(flag2 ? 61 : 70), 9, qpKRkUsOMpNYiaaLKerlVwVqwfzI))
			{
				flag3 = true;
			}
			if (flag3)
			{
				drUhrinNPucRxTwgPGMBgegBBqdIA drUhrinNPucRxTwgPGMBgegBBqdIA2 = new drUhrinNPucRxTwgPGMBgegBBqdIA();
				drUhrinNPucRxTwgPGMBgegBBqdIA drUhrinNPucRxTwgPGMBgegBBqdIA3 = new drUhrinNPucRxTwgPGMBgegBBqdIA();
				MhpewfgzNJhLePcVPdPIowaRPWpU(qpKRkUsOMpNYiaaLKerlVwVqwfzI, drUhrinNPucRxTwgPGMBgegBBqdIA2, drUhrinNPucRxTwgPGMBgegBBqdIA3, flag2);
				irPvOXFlnFqunAaoEjtbhqDGRcZqA[0] = drUhrinNPucRxTwgPGMBgegBBqdIA2;
				irPvOXFlnFqunAaoEjtbhqDGRcZqA[1] = drUhrinNPucRxTwgPGMBgegBBqdIA3;
				flag = true;
				if (uTggNPQCHZQtwCZVZRMBwGNMXaCT(96, (byte)(flag2 ? 134 : 152), 16, qpKRkUsOMpNYiaaLKerlVwVqwfzI))
				{
					sXaCrezAnYJlggfaMAXplhkLjgue(qpKRkUsOMpNYiaaLKerlVwVqwfzI, drUhrinNPucRxTwgPGMBgegBBqdIA2, drUhrinNPucRxTwgPGMBgegBBqdIA3);
				}
			}
			else
			{
				flag = false;
			}
			if (_controllerType == yLpbwZJUFNkRouxglOYNdRyBNHOG.ProController)
			{
				bool flag4 = false;
				if (uTggNPQCHZQtwCZVZRMBwGNMXaCT(128, (byte)((!flag2) ? 18 : 29), 9, qpKRkUsOMpNYiaaLKerlVwVqwfzI))
				{
					for (int j = 0; j < 9; j++)
					{
						if (qpKRkUsOMpNYiaaLKerlVwVqwfzI[j] != byte.MaxValue)
						{
							flag4 = true;
						}
					}
				}
				if (!flag4 && uTggNPQCHZQtwCZVZRMBwGNMXaCT(96, (byte)((!flag2) ? 61 : 70), 9, qpKRkUsOMpNYiaaLKerlVwVqwfzI))
				{
					flag4 = true;
				}
				if (flag4)
				{
					drUhrinNPucRxTwgPGMBgegBBqdIA drUhrinNPucRxTwgPGMBgegBBqdIA4 = new drUhrinNPucRxTwgPGMBgegBBqdIA();
					drUhrinNPucRxTwgPGMBgegBBqdIA drUhrinNPucRxTwgPGMBgegBBqdIA5 = new drUhrinNPucRxTwgPGMBgegBBqdIA();
					MhpewfgzNJhLePcVPdPIowaRPWpU(qpKRkUsOMpNYiaaLKerlVwVqwfzI, drUhrinNPucRxTwgPGMBgegBBqdIA4, drUhrinNPucRxTwgPGMBgegBBqdIA5, !flag2);
					irPvOXFlnFqunAaoEjtbhqDGRcZqA[2] = drUhrinNPucRxTwgPGMBgegBBqdIA4;
					irPvOXFlnFqunAaoEjtbhqDGRcZqA[3] = drUhrinNPucRxTwgPGMBgegBBqdIA5;
					flag = true;
					if (uTggNPQCHZQtwCZVZRMBwGNMXaCT(96, (byte)((!flag2) ? 134 : 152), 16, qpKRkUsOMpNYiaaLKerlVwVqwfzI))
					{
						sXaCrezAnYJlggfaMAXplhkLjgue(qpKRkUsOMpNYiaaLKerlVwVqwfzI, drUhrinNPucRxTwgPGMBgegBBqdIA4, drUhrinNPucRxTwgPGMBgegBBqdIA5);
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private static void MhpewfgzNJhLePcVPdPIowaRPWpU(byte[] P_0, drUhrinNPucRxTwgPGMBgegBBqdIA P_1, drUhrinNPucRxTwgPGMBgegBBqdIA P_2, bool P_3)
		{
			ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
			ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
			ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
			ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
			ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
			if (P_3)
			{
				P_1.KnUNgSciNoxZHPOxndZgAGObabwCA = num;
				P_2.KnUNgSciNoxZHPOxndZgAGObabwCA = num2;
				P_1.ppCvuUvavpaCeYbhnBwZcCGQmkaxA = num3;
				P_2.ppCvuUvavpaCeYbhnBwZcCGQmkaxA = num4;
				P_1.USTXPeKwIyOOAIixwPdptPXMekVo = num5;
				P_2.USTXPeKwIyOOAIixwPdptPXMekVo = num6;
			}
			else
			{
				P_1.ppCvuUvavpaCeYbhnBwZcCGQmkaxA = num;
				P_2.ppCvuUvavpaCeYbhnBwZcCGQmkaxA = num2;
				P_1.USTXPeKwIyOOAIixwPdptPXMekVo = num3;
				P_2.USTXPeKwIyOOAIixwPdptPXMekVo = num4;
				P_1.KnUNgSciNoxZHPOxndZgAGObabwCA = num5;
				P_2.KnUNgSciNoxZHPOxndZgAGObabwCA = num6;
			}
		}

		private static void sXaCrezAnYJlggfaMAXplhkLjgue(byte[] P_0, drUhrinNPucRxTwgPGMBgegBBqdIA P_1, drUhrinNPucRxTwgPGMBgegBBqdIA P_2)
		{
			P_1.MrILFTiDVxKkTWgwkeLVDMPkKuKXA = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			P_2.MrILFTiDVxKkTWgwkeLVDMPkKuKXA = P_1.MrILFTiDVxKkTWgwkeLVDMPkKuKXA;
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, drUhrinNPucRxTwgPGMBgegBBqdIA calX, drUhrinNPucRxTwgPGMBgegBBqdIA calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort mrILFTiDVxKkTWgwkeLVDMPkKuKXA = calX.MrILFTiDVxKkTWgwkeLVDMPkKuKXA;
			float num = valueX - calX.ppCvuUvavpaCeYbhnBwZcCGQmkaxA;
			float num2 = valueY - calY.ppCvuUvavpaCeYbhnBwZcCGQmkaxA;
			if (Math.Abs(num * num + num2 * num2) < (float)(mrILFTiDVxKkTWgwkeLVDMPkKuKXA * mrILFTiDVxKkTWgwkeLVDMPkKuKXA))
			{
				return false;
			}
			calibratedX = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num / (float)(int)((num > 0f) ? calX.KnUNgSciNoxZHPOxndZgAGObabwCA : calX.USTXPeKwIyOOAIixwPdptPXMekVo), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num2 / (float)(int)((num2 > 0f) ? calY.KnUNgSciNoxZHPOxndZgAGObabwCA : calY.USTXPeKwIyOOAIixwPdptPXMekVo), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			return true;
		}

		protected drUhrinNPucRxTwgPGMBgegBBqdIA GetAxisCalibration(int index)
		{
			return irPvOXFlnFqunAaoEjtbhqDGRcZqA[index];
		}

		private void qoDTESqhLFQdqZsztOSGjUPAeWjC(bool P_0)
		{
			if (sOmfYAgBIWgqWFhRGECwBZOgaBiPb && !P_0)
			{
				HnjozlzYuiDkceOgwZgCfdMgqqTO = ReInput.realTime;
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
				ReInput.ApplicationPauseChangedEvent -= qoDTESqhLFQdqZsztOSGjUPAeWjC;
				if (!YRYoIlAdYNBKOixJslmEPLMprKmHA && DFsuRxNKqgwAPkTbYQbXxpDXGCVH != null)
				{
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Clear();
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 5;
					try
					{
						LIcjIzUUhdWFFbCGUfvKkmViJEig.WriteSync(tJsvjECNcSqhMYLrdLOuyoQaErVIA, 0);
					}
					catch
					{
					}
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Clear();
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH[0] = 128;
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH[1] = 6;
					try
					{
						LIcjIzUUhdWFFbCGUfvKkmViJEig.WriteSync(tJsvjECNcSqhMYLrdLOuyoQaErVIA, 0);
					}
					catch
					{
					}
				}
				if (XNXpCXzcoryxzhPHGHgpKsWtHEnE != null)
				{
					XNXpCXzcoryxzhPHGHgpKsWtHEnE.Dispose();
				}
				if (DFsuRxNKqgwAPkTbYQbXxpDXGCVH != null)
				{
					DFsuRxNKqgwAPkTbYQbXxpDXGCVH.Dispose();
				}
				if (mPWVqZlPIpBQuyVLVBnUecAcacNzA != null)
				{
					mPWVqZlPIpBQuyVLVBnUecAcacNzA.Dispose();
				}
				if (doENNsXWYQjBGbLNelFhcQpnWbuS != null)
				{
					doENNsXWYQjBGbLNelFhcQpnWbuS.Dispose();
				}
				if (RIfDvnFdGYkZgbedcVKkyebnxZKu == null)
				{
					RIfDvnFdGYkZgbedcVKkyebnxZKu.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private static void jOggsAuMFjACJBLafEPoqtdTmpux(NativeBuffer P_0, int P_1)
		{
			P_0.TryWriteBytes(qETLngrjetckkcHIOBuBFhvFqenqb, qETLngrjetckkcHIOBuBFhvFqenqb.Length, P_1);
		}

		private static void OZPFNFpYdljKAzKokbFKhtKKdUsP(byte[] P_0, int P_1)
		{
			Array.Copy(qETLngrjetckkcHIOBuBFhvFqenqb, 0, P_0, P_1, qETLngrjetckkcHIOBuBFhvFqenqb.Length);
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
