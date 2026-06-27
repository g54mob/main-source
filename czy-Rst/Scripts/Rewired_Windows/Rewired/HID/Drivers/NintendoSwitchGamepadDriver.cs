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
		protected enum HhGUzcDWBmLEChxRWFLeeoTNXhWA
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class zIqmswPYXObQajyiXuAdzuKkofUq
		{
			private zjaGFxWobEvzfkfnDIafHMDeSyQp UESGuXatZuyDHvIKaqMxosBceAdt;

			private twSMZYGEgQrtVhgxVjKACgBKeLyF hgtWOFRgUTTUzVHNKIpfccTSgLjOA;

			private float xaITttPwSbaENCJtvJqEbJhjCmQEA;

			private double xaHJfbppgvFiVcqjzpfxmJOZgYKEA;

			public twSMZYGEgQrtVhgxVjKACgBKeLyF MxkekNiVgbSbAilxaUClwBMXsDrZ => hgtWOFRgUTTUzVHNKIpfccTSgLjOA;

			public zIqmswPYXObQajyiXuAdzuKkofUq(zjaGFxWobEvzfkfnDIafHMDeSyQp P_0)
			{
				UESGuXatZuyDHvIKaqMxosBceAdt = P_0;
				lAzLbcTUEdrWeEsgPSxQxZAGjoKI();
			}

			public void atrCQykIBUqiOxRJZjOLdBWAxLxz(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
				if (P_4 < 0f)
				{
					P_4 = 0f;
				}
				xaITttPwSbaENCJtvJqEbJhjCmQEA = P_4;
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA.XBLwdptxlwGEoXCMvRCUGGyagYbBA = MathTools.Clamp01(P_0);
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA.ieHiqzVpoutXpjSqNvyVxJzWUiG = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA.cIsbgDbExrtufEKCqruDQkHAtqrNA = MathTools.Clamp01(P_2);
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA.XxuHHisZuYHuROOgZiFdFlyCPQXbA = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
				UESGuXatZuyDHvIKaqMxosBceAdt.FdnMOOHJyNvOIoiYNtolKFnibDkk = Math.Max(hgtWOFRgUTTUzVHNKIpfccTSgLjOA.XBLwdptxlwGEoXCMvRCUGGyagYbBA, hgtWOFRgUTTUzVHNKIpfccTSgLjOA.cIsbgDbExrtufEKCqruDQkHAtqrNA);
				xaHJfbppgvFiVcqjzpfxmJOZgYKEA = ReInput.realTime;
			}

			public void alvtXuCmHNdvfsMRPZgskkuPWtqI(double P_0)
			{
				if ((hgtWOFRgUTTUzVHNKIpfccTSgLjOA.XBLwdptxlwGEoXCMvRCUGGyagYbBA > 0f || hgtWOFRgUTTUzVHNKIpfccTSgLjOA.cIsbgDbExrtufEKCqruDQkHAtqrNA > 0f) && xaITttPwSbaENCJtvJqEbJhjCmQEA > 0f && P_0 >= xaHJfbppgvFiVcqjzpfxmJOZgYKEA + (double)xaITttPwSbaENCJtvJqEbJhjCmQEA)
				{
					pzvPCZbtxwjWTykfIhQBoJjWjLnv();
				}
			}

			public void pzvPCZbtxwjWTykfIhQBoJjWjLnv()
			{
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA.cIsbgDbExrtufEKCqruDQkHAtqrNA = 0f;
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA.XBLwdptxlwGEoXCMvRCUGGyagYbBA = 0f;
				UESGuXatZuyDHvIKaqMxosBceAdt.OZyBFjtdbmGNdxlWalLBCWEMJQKG = 0;
				xaITttPwSbaENCJtvJqEbJhjCmQEA = 0f;
				xaHJfbppgvFiVcqjzpfxmJOZgYKEA = ReInput.realTime;
			}

			public void lAzLbcTUEdrWeEsgPSxQxZAGjoKI()
			{
				hgtWOFRgUTTUzVHNKIpfccTSgLjOA = twSMZYGEgQrtVhgxVjKACgBKeLyF.twwDvuabxsAuIyFoiRdxRjZwcAdp();
				UESGuXatZuyDHvIKaqMxosBceAdt.OZyBFjtdbmGNdxlWalLBCWEMJQKG = 0;
				xaITttPwSbaENCJtvJqEbJhjCmQEA = 0f;
				xaHJfbppgvFiVcqjzpfxmJOZgYKEA = 0.0;
			}
		}

		protected struct twSMZYGEgQrtVhgxVjKACgBKeLyF
		{
			public const int BRtVWLdbqgtQknwZaKvYOTJXGzid = 160;

			public const int kTiqmUlgsJocfCJPVDJTjGVjSqhoA = 320;

			public float XBLwdptxlwGEoXCMvRCUGGyagYbBA;

			public float ieHiqzVpoutXpjSqNvyVxJzWUiG;

			public float cIsbgDbExrtufEKCqruDQkHAtqrNA;

			public float XxuHHisZuYHuROOgZiFdFlyCPQXbA;

			internal twSMZYGEgQrtVhgxVjKACgBKeLyF(float P_0, float P_1, float P_2, float P_3)
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
				XBLwdptxlwGEoXCMvRCUGGyagYbBA = P_0;
				ieHiqzVpoutXpjSqNvyVxJzWUiG = P_1;
				cIsbgDbExrtufEKCqruDQkHAtqrNA = P_2;
				XxuHHisZuYHuROOgZiFdFlyCPQXbA = P_3;
			}

			public static twSMZYGEgQrtVhgxVjKACgBKeLyF twwDvuabxsAuIyFoiRdxRjZwcAdp()
			{
				return new twSMZYGEgQrtVhgxVjKACgBKeLyF(0f, 160f, 0f, 320f);
			}

			public string sWqFxEzQLVjpWzTWfKuQwdVpQvGq()
			{
				return "amplitudeLow: " + XBLwdptxlwGEoXCMvRCUGGyagYbBA + ", frequencyLow: " + ieHiqzVpoutXpjSqNvyVxJzWUiG + ", amplitudeHigh: " + cIsbgDbExrtufEKCqruDQkHAtqrNA + ", frequencyHigh: " + XxuHHisZuYHuROOgZiFdFlyCPQXbA;
			}
		}

		private struct YaVpGQmulGskHSknfhruUAoBwrFU
		{
			public byte TimaOOIOmbYQVsFrVFKyUAeLYncH;

			public byte[] OApRtcdAlvJcnNImeIblpeZKwTsS;

			public int OuSBeUqMPgrOkGbjENCWUNMLwLWW;

			public YaVpGQmulGskHSknfhruUAoBwrFU(byte P_0, byte[] P_1, int P_2)
			{
				TimaOOIOmbYQVsFrVFKyUAeLYncH = P_0;
				OApRtcdAlvJcnNImeIblpeZKwTsS = P_1;
				OuSBeUqMPgrOkGbjENCWUNMLwLWW = P_2;
			}
		}

		protected class KMYCPMAbSgxeVFUhlzXPzkmVIiEgA
		{
			public ushort xVLmpSWZVcMfsLacMZizuWVGLosQ;

			public ushort hBCZGgmoEoZitIKiRFYoJxSrgdFt;

			public ushort MtKZylnwfzrEOJmqBzkRDKyGqHLE;

			public ushort fNCYfjsZKlbVpLAfOBATdLTararqA;

			public virtual string wBOsGLghfCdajxQRVoLcyBBLgBzH()
			{
				return "min: " + xVLmpSWZVcMfsLacMZizuWVGLosQ + ", max: " + hBCZGgmoEoZitIKiRFYoJxSrgdFt + ", zero: " + MtKZylnwfzrEOJmqBzkRDKyGqHLE + ", deadzone: " + fNCYfjsZKlbVpLAfOBATdLTararqA;
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

		protected readonly HhGUzcDWBmLEChxRWFLeeoTNXhWA _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice gqcNJHKRRhdSpqkHkesWfSoaDCFl;

		private readonly HIDProperties wmvguZDAbfMyYCtFWAIRAAQZnuAy;

		private readonly bool bnAWiBOzDBnxgeMKYqhEUHOdaOLkA;

		private readonly NativeBuffer mUJNljrqtrLIFeuAaEDtPCoxhDCr;

		private readonly NativeBuffer uReEZLJllgRqfhcRkDTDyRABYFwf;

		private readonly NativeBuffer gOrhToHRiCijCooFOJowvlYvZJzC;

		private readonly byte[] PiKnjkiIZpgmCvHYgzdxQMVmydWl;

		private readonly NativeBuffer LXKpQpjJRpzdQlKGniwKvqMowTsL;

		private readonly NativeBuffer UzOWnGJFVAAisdcOKrUhgbfzNnPaA;

		private fSMyuzvVmAACQsIYyLcgNLStbZVN MToPJqAHjYlQsRfoDtJefWUyAlgu;

		private double zjIYfFrbQjmikmrilrRildwaAjRn;

		private byte zYvYmsNdaIesRJSzlpuXkEWbuaMBA;

		private double cBjYZZjfroUVQfyjASvUoiKaXium;

		private bool HqmFwggwTWEFatkEmEJuhKMHaPNKb;

		private bool KOWVzIESQEPlXkqVYpBStlagUkKl;

		private zIqmswPYXObQajyiXuAdzuKkofUq[] WwtSluzRmnFdqSOCGxOOhjwgpFlR;

		private KMYCPMAbSgxeVFUhlzXPzkmVIiEgA[] XwLPohRTgZULRBEdszcpnpFAnywM;

		private static readonly byte[] BaPbLGKnxpPZOpSNeLvHbebuVoUgb = new byte[8] { 0, 1, 64, 64, 0, 1, 64, 64 };

		int IDriver_NintendoSwitchController.vibrationMotorCount => _vibrationMotorCount;

		ushort IHIDControllerExtension.vendorId => wmvguZDAbfMyYCtFWAIRAAQZnuAy.vendorId;

		ushort IHIDControllerExtension.productId => wmvguZDAbfMyYCtFWAIRAAQZnuAy.productId;

		string IHIDControllerExtension.productName => wmvguZDAbfMyYCtFWAIRAAQZnuAy.productName;

		string IHIDControllerExtension.manufacturer => wmvguZDAbfMyYCtFWAIRAAQZnuAy.manufacturer;

		ushort IHIDControllerExtension.usagePage => wmvguZDAbfMyYCtFWAIRAAQZnuAy.usagePage;

		ushort IHIDControllerExtension.usage => wmvguZDAbfMyYCtFWAIRAAQZnuAy.usage;

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
				twSMZYGEgQrtVhgxVjKACgBKeLyF twSMZYGEgQrtVhgxVjKACgBKeLyF2 = WwtSluzRmnFdqSOCGxOOhjwgpFlR[motorIndex].MxkekNiVgbSbAilxaUClwBMXsDrZ;
				amplitudeLow = twSMZYGEgQrtVhgxVjKACgBKeLyF2.XBLwdptxlwGEoXCMvRCUGGyagYbBA;
				frequencyLow = twSMZYGEgQrtVhgxVjKACgBKeLyF2.ieHiqzVpoutXpjSqNvyVxJzWUiG;
				amplitudeHigh = twSMZYGEgQrtVhgxVjKACgBKeLyF2.cIsbgDbExrtufEKCqruDQkHAtqrNA;
				frequencyHigh = twSMZYGEgQrtVhgxVjKACgBKeLyF2.XxuHHisZuYHuROOgZiFdFlyCPQXbA;
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
					HWjBTNRGhholGrkROqxTWtHaDzVu(motorIndex);
				}
				WwtSluzRmnFdqSOCGxOOhjwgpFlR[motorIndex].atrCQykIBUqiOxRJZjOLdBWAxLxz(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
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
				WwtSluzRmnFdqSOCGxOOhjwgpFlR[motorIndex].pzvPCZbtxwjWTykfIhQBoJjWjLnv();
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
				WwtSluzRmnFdqSOCGxOOhjwgpFlR[i].pzvPCZbtxwjWTykfIhQBoJjWjLnv();
			}
		}

		void IDriver_NintendoSwitchController.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		private void HWjBTNRGhholGrkROqxTWtHaDzVu(int P_0)
		{
			for (int i = 0; i < WwtSluzRmnFdqSOCGxOOhjwgpFlR.Length; i++)
			{
				if (i != P_0)
				{
					WwtSluzRmnFdqSOCGxOOhjwgpFlR[i].pzvPCZbtxwjWTykfIhQBoJjWjLnv();
				}
			}
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, HhGUzcDWBmLEChxRWFLeeoTNXhWA P_1, int P_2, int P_3, int P_4)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			_controllerType = P_1;
			_buttonCount = P_2;
			_axisCount = P_3;
			_vibrationMotorCount = P_4;
			gqcNJHKRRhdSpqkHkesWfSoaDCFl = P_0.hidDevice;
			wmvguZDAbfMyYCtFWAIRAAQZnuAy = P_0.hidDevice.properties;
			bnAWiBOzDBnxgeMKYqhEUHOdaOLkA = P_0.connectionType == RWcHFhaLOdObDBlAnlGahPsMjmIp.Bluetooth;
			mUJNljrqtrLIFeuAaEDtPCoxhDCr = new NativeBuffer(wmvguZDAbfMyYCtFWAIRAAQZnuAy.maxInputReportLength);
			uReEZLJllgRqfhcRkDTDyRABYFwf = new NativeBuffer(wmvguZDAbfMyYCtFWAIRAAQZnuAy.maxOutputReportLength);
			gOrhToHRiCijCooFOJowvlYvZJzC = new NativeBuffer(32);
			PiKnjkiIZpgmCvHYgzdxQMVmydWl = new byte[wmvguZDAbfMyYCtFWAIRAAQZnuAy.maxInputReportLength];
			LXKpQpjJRpzdQlKGniwKvqMowTsL = new NativeBuffer(wmvguZDAbfMyYCtFWAIRAAQZnuAy.maxOutputReportLength);
			UzOWnGJFVAAisdcOKrUhgbfzNnPaA = new NativeBuffer(49);
			if (wmvguZDAbfMyYCtFWAIRAAQZnuAy.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			MToPJqAHjYlQsRfoDtJefWUyAlgu = new fSMyuzvVmAACQsIYyLcgNLStbZVN(uReEZLJllgRqfhcRkDTDyRABYFwf.Pointer, uReEZLJllgRqfhcRkDTDyRABYFwf.Length, uReEZLJllgRqfhcRkDTDyRABYFwf.Length);
			HqmFwggwTWEFatkEmEJuhKMHaPNKb = !bnAWiBOzDBnxgeMKYqhEUHOdaOLkA && UnityTools.effectivePlatform == Platform.Windows;
			ReInput.ApplicationPauseChangedEvent += LuTbnaugmLGvOWYfPMPWiOMYRoSw;
			buttons = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS[P_2];
			for (int i = 0; i < P_2; i++)
			{
				buttons[i] = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS(33, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			XwLPohRTgZULRBEdszcpnpFAnywM = new KMYCPMAbSgxeVFUhlzXPzkmVIiEgA[_axisCount];
			vibrationMotors = new zjaGFxWobEvzfkfnDIafHMDeSyQp[P_4];
			for (int j = 0; j < vibrationMotors.Length; j++)
			{
				vibrationMotors[j] = new zjaGFxWobEvzfkfnDIafHMDeSyQp(0, 255);
			}
			WwtSluzRmnFdqSOCGxOOhjwgpFlR = new zIqmswPYXObQajyiXuAdzuKkofUq[P_4];
			for (int k = 0; k < WwtSluzRmnFdqSOCGxOOhjwgpFlR.Length; k++)
			{
				WwtSluzRmnFdqSOCGxOOhjwgpFlR[k] = new zIqmswPYXObQajyiXuAdzuKkofUq(vibrationMotors[k]);
			}
		}

		protected void Initialize()
		{
			KOWVzIESQEPlXkqVYpBStlagUkKl = false;
			uReEZLJllgRqfhcRkDTDyRABYFwf.Clear();
			if (!bnAWiBOzDBnxgeMKYqhEUHOdaOLkA)
			{
				NativeBuffer nativeBuffer = uReEZLJllgRqfhcRkDTDyRABYFwf;
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 1;
				if (!FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB connection status.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 2;
				if (!FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 1.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 3;
				if (!FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB set baudrate.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 2;
				if (!FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 2.", requiredThreadSafety: true);
					throw new Exception();
				}
				nativeBuffer[0] = 128;
				nativeBuffer[1] = 4;
				if (!FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB prevent hid timeout.", requiredThreadSafety: true);
					throw new Exception();
				}
			}
			if (!sVUnaukFloWkLGlkAxXYNNmePTrb(new YaVpGQmulGskHSknfhruUAoBwrFU(72, new byte[1] { 1 }, 1), PiKnjkiIZpgmCvHYgzdxQMVmydWl))
			{
				throw new Exception();
			}
			if (!sVUnaukFloWkLGlkAxXYNNmePTrb(new YaVpGQmulGskHSknfhruUAoBwrFU(3, new byte[1] { 48 }, 1), PiKnjkiIZpgmCvHYgzdxQMVmydWl))
			{
				throw new Exception();
			}
			leAfmWBqLDPvMXmBSUrpGqjwrKmiA();
			if (!aXbbDJyUkJnOXdeKfRSBdBzdsnhF())
			{
				throw new Exception();
			}
			if (HqmFwggwTWEFatkEmEJuhKMHaPNKb)
			{
				cBjYZZjfroUVQfyjASvUoiKaXium = ReInput.realTime;
			}
			KOWVzIESQEPlXkqVYpBStlagUkKl = true;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			double realTime = ReInput.realTime;
			if (HqmFwggwTWEFatkEmEJuhKMHaPNKb && realTime >= cBjYZZjfroUVQfyjASvUoiKaXium + 1.0)
			{
				try
				{
					Initialize();
				}
				catch
				{
					Logger.LogWarning("Error re-initializing Nintendo Switch Pro Controller. Will retry.");
					cBjYZZjfroUVQfyjASvUoiKaXium = realTime;
				}
			}
			for (int i = 0; i < WwtSluzRmnFdqSOCGxOOhjwgpFlR.Length; i++)
			{
				WwtSluzRmnFdqSOCGxOOhjwgpFlR[i].alvtXuCmHNdvfsMRPZgskkuPWtqI(realTime);
			}
			if (realTime >= zjIYfFrbQjmikmrilrRildwaAjRn + 0.01515151560306549)
			{
				zjIYfFrbQjmikmrilrRildwaAjRn = realTime;
				kWumSuAJIQrSIwDbpEyQOzkdUhIF(uReEZLJllgRqfhcRkDTDyRABYFwf);
				FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous);
			}
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (!KOWVzIESQEPlXkqVYpBStlagUkKl)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (mUJNljrqtrLIFeuAaEDtPCoxhDCr.Length < 49)
			{
				return false;
			}
			if (Marshal.ReadByte(inputReportPtr, 0) != 33)
			{
				return false;
			}
			if (HqmFwggwTWEFatkEmEJuhKMHaPNKb)
			{
				cBjYZZjfroUVQfyjASvUoiKaXium = ReInput.realTime;
			}
			int numBytesToWrite = Math.Min(inputReportLength, mUJNljrqtrLIFeuAaEDtPCoxhDCr.Length);
			mUJNljrqtrLIFeuAaEDtPCoxhDCr.Write(inputReportPtr, inputReportLength, numBytesToWrite);
			UpdateButtons(mUJNljrqtrLIFeuAaEDtPCoxhDCr, timestamp);
			QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] elements = axes;
			UpdateElements(elements, mUJNljrqtrLIFeuAaEDtPCoxhDCr, timestamp);
			return true;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] elements, NativeBuffer inputReport, double timestamp);

		private bool sVUnaukFloWkLGlkAxXYNNmePTrb(YaVpGQmulGskHSknfhruUAoBwrFU P_0, byte[] P_1)
		{
			try
			{
				if (P_0.OApRtcdAlvJcnNImeIblpeZKwTsS.Length + 11 > LXKpQpjJRpzdQlKGniwKvqMowTsL.Length)
				{
					return false;
				}
				kWumSuAJIQrSIwDbpEyQOzkdUhIF(LXKpQpjJRpzdQlKGniwKvqMowTsL);
				LXKpQpjJRpzdQlKGniwKvqMowTsL[10] = P_0.TimaOOIOmbYQVsFrVFKyUAeLYncH;
				LXKpQpjJRpzdQlKGniwKvqMowTsL.TryWriteBytes(P_0.OApRtcdAlvJcnNImeIblpeZKwTsS, P_0.OuSBeUqMPgrOkGbjENCWUNMLwLWW, 11);
				int num = 2;
				bool flag = false;
				int num2 = 0;
				double num3 = 0.0;
				while (gqcNJHKRRhdSpqkHkesWfSoaDCFl.ReadSync(UzOWnGJFVAAisdcOKrUhgbfzNnPaA, UzOWnGJFVAAisdcOKrUhgbfzNnPaA.Length, 1))
				{
				}
				for (int i = 0; i < num; i++)
				{
					Array.Clear(P_1, 0, P_1.Length);
					UzOWnGJFVAAisdcOKrUhgbfzNnPaA.Clear();
					QablaMFUeJDdpIpXjkIBvTDOjUCY(LXKpQpjJRpzdQlKGniwKvqMowTsL, P_0.TimaOOIOmbYQVsFrVFKyUAeLYncH);
					num3 = ReInput.realTime;
					if (i == 0)
					{
						_ = ReInput.realTime;
					}
					int num4 = 0;
					while (!(ReInput.realTime >= num3 + 0.5))
					{
						if (gqcNJHKRRhdSpqkHkesWfSoaDCFl.ReadSync(UzOWnGJFVAAisdcOKrUhgbfzNnPaA, UzOWnGJFVAAisdcOKrUhgbfzNnPaA.Length, 200) && UzOWnGJFVAAisdcOKrUhgbfzNnPaA[0] == 33)
						{
							if (UzOWnGJFVAAisdcOKrUhgbfzNnPaA[14] == P_0.TimaOOIOmbYQVsFrVFKyUAeLYncH)
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
					UzOWnGJFVAAisdcOKrUhgbfzNnPaA.Read(P_1, UzOWnGJFVAAisdcOKrUhgbfzNnPaA.Length);
				}
				return flag;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool QablaMFUeJDdpIpXjkIBvTDOjUCY(NativeBuffer P_0, byte P_1)
		{
			if (!gqcNJHKRRhdSpqkHkesWfSoaDCFl.WriteSync(new fSMyuzvVmAACQsIYyLcgNLStbZVN(P_0, P_0.Length, P_0.Length), 1000))
			{
				return false;
			}
			return true;
		}

		private void mrmDCmzcYFiwofXlNokenlwNVVOd(byte P_0)
		{
			uReEZLJllgRqfhcRkDTDyRABYFwf.Clear();
			uReEZLJllgRqfhcRkDTDyRABYFwf[0] = 128;
			uReEZLJllgRqfhcRkDTDyRABYFwf[1] = 146;
			uReEZLJllgRqfhcRkDTDyRABYFwf[2] = 0;
			uReEZLJllgRqfhcRkDTDyRABYFwf[3] = 49;
			uReEZLJllgRqfhcRkDTDyRABYFwf[8] = P_0;
		}

		private void QmkOxwXoyIOTvBGRHgYNfywawDRIA(byte P_0, NativeBuffer P_1, int P_2, UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_3)
		{
			mrmDCmzcYFiwofXlNokenlwNVVOd(P_0);
			if (P_2 > 0)
			{
				uReEZLJllgRqfhcRkDTDyRABYFwf.Write(P_1, P_2, 9);
			}
		}

		private void kWumSuAJIQrSIwDbpEyQOzkdUhIF(NativeBuffer P_0)
		{
			P_0.Clear();
			P_0[0] = 1;
			P_0[1] = BKyEZuxUPaslkxKOEDDYRPMlole();
			pBAShiKPqSDeeezoQWdrBJOJMBZGb(P_0, 2);
		}

		private void pBAShiKPqSDeeezoQWdrBJOJMBZGb(NativeBuffer P_0, int P_1)
		{
			if (_controllerType == HhGUzcDWBmLEChxRWFLeeoTNXhWA.JoyConRight)
			{
				P_1 += 4;
			}
			for (int i = 0; i < WwtSluzRmnFdqSOCGxOOhjwgpFlR.Length; i++)
			{
				BChIXHnCTUaPiKIboflUaWEbaVBSB(P_0, P_1, WwtSluzRmnFdqSOCGxOOhjwgpFlR[i].MxkekNiVgbSbAilxaUClwBMXsDrZ);
				P_1 += 4;
			}
		}

		private static void BChIXHnCTUaPiKIboflUaWEbaVBSB(NativeBuffer P_0, int P_1, twSMZYGEgQrtVhgxVjKACgBKeLyF P_2)
		{
			if (P_2.XBLwdptxlwGEoXCMvRCUGGyagYbBA == 0f && P_2.cIsbgDbExrtufEKCqruDQkHAtqrNA == 0f)
			{
				P_0[P_1] = 0;
				P_0[1 + P_1] = 1;
				P_0[2 + P_1] = 64;
				P_0[3 + P_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.XxuHHisZuYHuROOgZiFdFlyCPQXbA * 0.1f, 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.ieHiqzVpoutXpjSqNvyVxJzWUiG * 0.1f, 2.0)) - 64.0);
			byte b2 = JLGTlqDgOuGOClaOjoEEAsbDzPGN(P_2.cIsbgDbExrtufEKCqruDQkHAtqrNA);
			ushort num2 = (ushort)(Math.Round((double)(int)JLGTlqDgOuGOClaOjoEEAsbDzPGN(P_2.XBLwdptxlwGEoXCMvRCUGGyagYbBA)) * 0.5);
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

		private static byte JLGTlqDgOuGOClaOjoEEAsbDzPGN(float P_0)
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

		private void yckJHONzZCQnbIWqLrtzTJebaSYH(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			NativeBuffer nativeBuffer = gOrhToHRiCijCooFOJowvlYvZJzC;
			nativeBuffer[0] = BKyEZuxUPaslkxKOEDDYRPMlole();
			pBAShiKPqSDeeezoQWdrBJOJMBZGb(nativeBuffer, 1);
			QmkOxwXoyIOTvBGRHgYNfywawDRIA(16, nativeBuffer, 9, P_0);
			FJYynusRznwjZXNkjLZyUdjghcqb(P_0);
		}

		private bool leAfmWBqLDPvMXmBSUrpGqjwrKmiA()
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return sVUnaukFloWkLGlkAxXYNNmePTrb(new YaVpGQmulGskHSknfhruUAoBwrFU(56, array, 25), PiKnjkiIZpgmCvHYgzdxQMVmydWl);
		}

		private bool dOzNOCruecRRPeYjIFZImyrzdVCQ(bool P_0)
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
			return sVUnaukFloWkLGlkAxXYNNmePTrb(new YaVpGQmulGskHSknfhruUAoBwrFU(56, array, 25), PiKnjkiIZpgmCvHYgzdxQMVmydWl);
		}

		private bool XKeelrbQYVeEQUHUraLJPjZGlknnA(byte P_0, byte P_1, byte P_2, byte[] P_3)
		{
			byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (sVUnaukFloWkLGlkAxXYNNmePTrb(new YaVpGQmulGskHSknfhruUAoBwrFU(16, array, array.Length), P_3) && P_3[15] == P_1 && P_3[16] == P_0)
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

		private bool FJYynusRznwjZXNkjLZyUdjghcqb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			switch (P_0)
			{
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous:
				return gqcNJHKRRhdSpqkHkesWfSoaDCFl.WriteSync(MToPJqAHjYlQsRfoDtJefWUyAlgu, 0);
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous:
				gqcNJHKRRhdSpqkHkesWfSoaDCFl.WriteAsync(MToPJqAHjYlQsRfoDtJefWUyAlgu, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private byte BKyEZuxUPaslkxKOEDDYRPMlole()
		{
			if (zYvYmsNdaIesRJSzlpuXkEWbuaMBA == 15)
			{
				zYvYmsNdaIesRJSzlpuXkEWbuaMBA = 0;
			}
			else
			{
				zYvYmsNdaIesRJSzlpuXkEWbuaMBA++;
			}
			return zYvYmsNdaIesRJSzlpuXkEWbuaMBA;
		}

		private bool aXbbDJyUkJnOXdeKfRSBdBzdsnhF()
		{
			bool flag = false;
			bool flag2 = _controllerType == HhGUzcDWBmLEChxRWFLeeoTNXhWA.JoyConLeft || _controllerType == HhGUzcDWBmLEChxRWFLeeoTNXhWA.ProController;
			Array.Clear(XwLPohRTgZULRBEdszcpnpFAnywM, 0, XwLPohRTgZULRBEdszcpnpFAnywM.Length);
			bool flag3 = false;
			if (XKeelrbQYVeEQUHUraLJPjZGlknnA(128, (byte)(flag2 ? 18 : 29), 9, PiKnjkiIZpgmCvHYgzdxQMVmydWl))
			{
				for (int i = 0; i < 9; i++)
				{
					if (PiKnjkiIZpgmCvHYgzdxQMVmydWl[i] != byte.MaxValue)
					{
						flag3 = true;
					}
				}
			}
			if (!flag3 && XKeelrbQYVeEQUHUraLJPjZGlknnA(96, (byte)(flag2 ? 61 : 70), 9, PiKnjkiIZpgmCvHYgzdxQMVmydWl))
			{
				flag3 = true;
			}
			if (flag3)
			{
				KMYCPMAbSgxeVFUhlzXPzkmVIiEgA kMYCPMAbSgxeVFUhlzXPzkmVIiEgA = new KMYCPMAbSgxeVFUhlzXPzkmVIiEgA();
				KMYCPMAbSgxeVFUhlzXPzkmVIiEgA kMYCPMAbSgxeVFUhlzXPzkmVIiEgA2 = new KMYCPMAbSgxeVFUhlzXPzkmVIiEgA();
				lqpMZVeKOXSKDMMOlKKGtsGTKJCD(PiKnjkiIZpgmCvHYgzdxQMVmydWl, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA2, flag2);
				XwLPohRTgZULRBEdszcpnpFAnywM[0] = kMYCPMAbSgxeVFUhlzXPzkmVIiEgA;
				XwLPohRTgZULRBEdszcpnpFAnywM[1] = kMYCPMAbSgxeVFUhlzXPzkmVIiEgA2;
				flag = true;
				if (XKeelrbQYVeEQUHUraLJPjZGlknnA(96, (byte)(flag2 ? 134 : 152), 16, PiKnjkiIZpgmCvHYgzdxQMVmydWl))
				{
					RAueAIlhXAeaClXyuDDxaCpXDrBdA(PiKnjkiIZpgmCvHYgzdxQMVmydWl, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA2);
				}
			}
			else
			{
				flag = false;
			}
			if (_controllerType == HhGUzcDWBmLEChxRWFLeeoTNXhWA.ProController)
			{
				bool flag4 = false;
				if (XKeelrbQYVeEQUHUraLJPjZGlknnA(128, (byte)((!flag2) ? 18 : 29), 9, PiKnjkiIZpgmCvHYgzdxQMVmydWl))
				{
					for (int j = 0; j < 9; j++)
					{
						if (PiKnjkiIZpgmCvHYgzdxQMVmydWl[j] != byte.MaxValue)
						{
							flag4 = true;
						}
					}
				}
				if (!flag4 && XKeelrbQYVeEQUHUraLJPjZGlknnA(96, (byte)((!flag2) ? 61 : 70), 9, PiKnjkiIZpgmCvHYgzdxQMVmydWl))
				{
					flag4 = true;
				}
				if (flag4)
				{
					KMYCPMAbSgxeVFUhlzXPzkmVIiEgA kMYCPMAbSgxeVFUhlzXPzkmVIiEgA3 = new KMYCPMAbSgxeVFUhlzXPzkmVIiEgA();
					KMYCPMAbSgxeVFUhlzXPzkmVIiEgA kMYCPMAbSgxeVFUhlzXPzkmVIiEgA4 = new KMYCPMAbSgxeVFUhlzXPzkmVIiEgA();
					lqpMZVeKOXSKDMMOlKKGtsGTKJCD(PiKnjkiIZpgmCvHYgzdxQMVmydWl, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA3, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA4, !flag2);
					XwLPohRTgZULRBEdszcpnpFAnywM[2] = kMYCPMAbSgxeVFUhlzXPzkmVIiEgA3;
					XwLPohRTgZULRBEdszcpnpFAnywM[3] = kMYCPMAbSgxeVFUhlzXPzkmVIiEgA4;
					flag = true;
					if (XKeelrbQYVeEQUHUraLJPjZGlknnA(96, (byte)((!flag2) ? 134 : 152), 16, PiKnjkiIZpgmCvHYgzdxQMVmydWl))
					{
						RAueAIlhXAeaClXyuDDxaCpXDrBdA(PiKnjkiIZpgmCvHYgzdxQMVmydWl, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA3, kMYCPMAbSgxeVFUhlzXPzkmVIiEgA4);
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private static void lqpMZVeKOXSKDMMOlKKGtsGTKJCD(byte[] P_0, KMYCPMAbSgxeVFUhlzXPzkmVIiEgA P_1, KMYCPMAbSgxeVFUhlzXPzkmVIiEgA P_2, bool P_3)
		{
			ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
			ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
			ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
			ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
			ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
			if (P_3)
			{
				P_1.hBCZGgmoEoZitIKiRFYoJxSrgdFt = num;
				P_2.hBCZGgmoEoZitIKiRFYoJxSrgdFt = num2;
				P_1.MtKZylnwfzrEOJmqBzkRDKyGqHLE = num3;
				P_2.MtKZylnwfzrEOJmqBzkRDKyGqHLE = num4;
				P_1.xVLmpSWZVcMfsLacMZizuWVGLosQ = num5;
				P_2.xVLmpSWZVcMfsLacMZizuWVGLosQ = num6;
			}
			else
			{
				P_1.MtKZylnwfzrEOJmqBzkRDKyGqHLE = num;
				P_2.MtKZylnwfzrEOJmqBzkRDKyGqHLE = num2;
				P_1.xVLmpSWZVcMfsLacMZizuWVGLosQ = num3;
				P_2.xVLmpSWZVcMfsLacMZizuWVGLosQ = num4;
				P_1.hBCZGgmoEoZitIKiRFYoJxSrgdFt = num5;
				P_2.hBCZGgmoEoZitIKiRFYoJxSrgdFt = num6;
			}
		}

		private static void RAueAIlhXAeaClXyuDDxaCpXDrBdA(byte[] P_0, KMYCPMAbSgxeVFUhlzXPzkmVIiEgA P_1, KMYCPMAbSgxeVFUhlzXPzkmVIiEgA P_2)
		{
			P_1.fNCYfjsZKlbVpLAfOBATdLTararqA = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			P_2.fNCYfjsZKlbVpLAfOBATdLTararqA = P_1.fNCYfjsZKlbVpLAfOBATdLTararqA;
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, KMYCPMAbSgxeVFUhlzXPzkmVIiEgA calX, KMYCPMAbSgxeVFUhlzXPzkmVIiEgA calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort fNCYfjsZKlbVpLAfOBATdLTararqA = calX.fNCYfjsZKlbVpLAfOBATdLTararqA;
			float num = valueX - calX.MtKZylnwfzrEOJmqBzkRDKyGqHLE;
			float num2 = valueY - calY.MtKZylnwfzrEOJmqBzkRDKyGqHLE;
			if (Math.Abs(num * num + num2 * num2) < (float)(fNCYfjsZKlbVpLAfOBATdLTararqA * fNCYfjsZKlbVpLAfOBATdLTararqA))
			{
				return false;
			}
			calibratedX = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num / (float)(int)((num > 0f) ? calX.hBCZGgmoEoZitIKiRFYoJxSrgdFt : calX.xVLmpSWZVcMfsLacMZizuWVGLosQ), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num2 / (float)(int)((num2 > 0f) ? calY.hBCZGgmoEoZitIKiRFYoJxSrgdFt : calY.xVLmpSWZVcMfsLacMZizuWVGLosQ), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			return true;
		}

		protected KMYCPMAbSgxeVFUhlzXPzkmVIiEgA GetAxisCalibration(int index)
		{
			return XwLPohRTgZULRBEdszcpnpFAnywM[index];
		}

		private void LuTbnaugmLGvOWYfPMPWiOMYRoSw(bool P_0)
		{
			if (HqmFwggwTWEFatkEmEJuhKMHaPNKb && !P_0)
			{
				cBjYZZjfroUVQfyjASvUoiKaXium = ReInput.realTime;
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
				ReInput.ApplicationPauseChangedEvent -= LuTbnaugmLGvOWYfPMPWiOMYRoSw;
				if (!bnAWiBOzDBnxgeMKYqhEUHOdaOLkA && uReEZLJllgRqfhcRkDTDyRABYFwf != null)
				{
					uReEZLJllgRqfhcRkDTDyRABYFwf.Clear();
					uReEZLJllgRqfhcRkDTDyRABYFwf[0] = 128;
					uReEZLJllgRqfhcRkDTDyRABYFwf[1] = 5;
					try
					{
						gqcNJHKRRhdSpqkHkesWfSoaDCFl.WriteSync(MToPJqAHjYlQsRfoDtJefWUyAlgu, 0);
					}
					catch
					{
					}
					uReEZLJllgRqfhcRkDTDyRABYFwf.Clear();
					uReEZLJllgRqfhcRkDTDyRABYFwf[0] = 128;
					uReEZLJllgRqfhcRkDTDyRABYFwf[1] = 6;
					try
					{
						gqcNJHKRRhdSpqkHkesWfSoaDCFl.WriteSync(MToPJqAHjYlQsRfoDtJefWUyAlgu, 0);
					}
					catch
					{
					}
				}
				if (mUJNljrqtrLIFeuAaEDtPCoxhDCr != null)
				{
					mUJNljrqtrLIFeuAaEDtPCoxhDCr.Dispose();
				}
				if (uReEZLJllgRqfhcRkDTDyRABYFwf != null)
				{
					uReEZLJllgRqfhcRkDTDyRABYFwf.Dispose();
				}
				if (LXKpQpjJRpzdQlKGniwKvqMowTsL != null)
				{
					LXKpQpjJRpzdQlKGniwKvqMowTsL.Dispose();
				}
				if (UzOWnGJFVAAisdcOKrUhgbfzNnPaA != null)
				{
					UzOWnGJFVAAisdcOKrUhgbfzNnPaA.Dispose();
				}
				if (gOrhToHRiCijCooFOJowvlYvZJzC == null)
				{
					gOrhToHRiCijCooFOJowvlYvZJzC.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private static void AacGQeAyQbzptmWlBoWqkjxHnjTFb(NativeBuffer P_0, int P_1)
		{
			P_0.TryWriteBytes(BaPbLGKnxpPZOpSNeLvHbebuVoUgb, BaPbLGKnxpPZOpSNeLvHbebuVoUgb.Length, P_1);
		}

		private static void zDDflfdpybavqYqvUzGWsoGGuQBmA(byte[] P_0, int P_1)
		{
			Array.Copy(BaPbLGKnxpPZOpSNeLvHbebuVoUgb, 0, P_0, P_1, BaPbLGKnxpPZOpSNeLvHbebuVoUgb.Length);
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
