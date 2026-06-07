using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum vcRikLjxeOhNWIbjVLyKaSHbtazzb
		{
			None = 0,
			Success = 1,
			Fail = 2,
			Ready = 3
		}

		private class IHEyLnkdBVkOYXgEdgtJXWFSFYai : Exception
		{
		}

		private enum RjRzjOvxivqxcXLlCnFiQdqwmgYH
		{
			GetUsbStatus = 1
		}

		private delegate bool iyYMrnLIKiERMtIHgBsfSzgNHHtU(uint responseTimeoutMs);

		protected enum NMOoxbNrRRsluLpmhhjPhxWOwZVpA
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class xLxXgQPOMPcIqFnrTwfPgabrzuaA
		{
			private rTJgTxMejKLMRUmSvWOxEnqbcNsC CYjVYZejUqjlnJAXKcXhnYvnQKDj;

			private zmhcxUcUtUbZbzRitpLYGJzDseKhA dGYviXBhZHCgFnWEadVtbohBvVNN;

			private float rzzUtcTXEtyxNocLRKQiyLVyeghB;

			private double fyiKVntdrdKgpWckNkHzvJsGaCix;

			public zmhcxUcUtUbZbzRitpLYGJzDseKhA IQDFXNNTzxXcaBHoGiJjUZuIDsZF => dGYviXBhZHCgFnWEadVtbohBvVNN;

			public bool IkSQvPjYkKmcihPZWGTojFtCcmOrA => CYjVYZejUqjlnJAXKcXhnYvnQKDj.SzNjajnXuqTkLVKNUlPZHTgLWZsS > 0;

			public xLxXgQPOMPcIqFnrTwfPgabrzuaA(rTJgTxMejKLMRUmSvWOxEnqbcNsC P_0)
			{
				CYjVYZejUqjlnJAXKcXhnYvnQKDj = P_0;
				xyAYHcBaRvmySetfxetYwPoLhPsI();
			}

			public void uOGvBmMIOWHAiZyGtOuBCIwLqXXp(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
				if (P_4 < 0f)
				{
					P_4 = 0f;
				}
				rzzUtcTXEtyxNocLRKQiyLVyeghB = P_4;
				dGYviXBhZHCgFnWEadVtbohBvVNN.ZLuIghfXamuoIvkXDgrAHKAnWdZH = MathTools.Clamp01(P_0);
				dGYviXBhZHCgFnWEadVtbohBvVNN.sXRlLojYeaFTvFMPMqvcYofkGCMX = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
				dGYviXBhZHCgFnWEadVtbohBvVNN.mEDVkXCuujAgHcMZWUfNxEnRoJBF = MathTools.Clamp01(P_2);
				dGYviXBhZHCgFnWEadVtbohBvVNN.ZiBoNcoDdKKqrsQnfxhdalILKwxf = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
				CYjVYZejUqjlnJAXKcXhnYvnQKDj.PvKIhOBqjFDTufSBvzXfLPDhKvGfb = Math.Max(dGYviXBhZHCgFnWEadVtbohBvVNN.ZLuIghfXamuoIvkXDgrAHKAnWdZH, dGYviXBhZHCgFnWEadVtbohBvVNN.mEDVkXCuujAgHcMZWUfNxEnRoJBF);
				fyiKVntdrdKgpWckNkHzvJsGaCix = ReInput.realTime;
			}

			public bool mYYeWqDWSRBDLyWNdSdkjUOCyMWx(double P_0)
			{
				if ((dGYviXBhZHCgFnWEadVtbohBvVNN.ZLuIghfXamuoIvkXDgrAHKAnWdZH > 0f || dGYviXBhZHCgFnWEadVtbohBvVNN.mEDVkXCuujAgHcMZWUfNxEnRoJBF > 0f) && rzzUtcTXEtyxNocLRKQiyLVyeghB > 0f && P_0 >= fyiKVntdrdKgpWckNkHzvJsGaCix + (double)rzzUtcTXEtyxNocLRKQiyLVyeghB)
				{
					nfMveZrkSuuclYawisABnXeVLzJe();
					return true;
				}
				return false;
			}

			public void nfMveZrkSuuclYawisABnXeVLzJe()
			{
				dGYviXBhZHCgFnWEadVtbohBvVNN.mEDVkXCuujAgHcMZWUfNxEnRoJBF = 0f;
				dGYviXBhZHCgFnWEadVtbohBvVNN.ZLuIghfXamuoIvkXDgrAHKAnWdZH = 0f;
				CYjVYZejUqjlnJAXKcXhnYvnQKDj.SzNjajnXuqTkLVKNUlPZHTgLWZsS = 0;
				rzzUtcTXEtyxNocLRKQiyLVyeghB = 0f;
				fyiKVntdrdKgpWckNkHzvJsGaCix = ReInput.realTime;
			}

			public void xyAYHcBaRvmySetfxetYwPoLhPsI()
			{
				dGYviXBhZHCgFnWEadVtbohBvVNN = zmhcxUcUtUbZbzRitpLYGJzDseKhA.bmRzwyakmoFCaKmpSzTjMejjeCLbA();
				CYjVYZejUqjlnJAXKcXhnYvnQKDj.SzNjajnXuqTkLVKNUlPZHTgLWZsS = 0;
				rzzUtcTXEtyxNocLRKQiyLVyeghB = 0f;
				fyiKVntdrdKgpWckNkHzvJsGaCix = 0.0;
			}
		}

		protected struct zmhcxUcUtUbZbzRitpLYGJzDseKhA
		{
			public const int JlSDqDehnmXVUNxIWdaWfXtKBKItA = 160;

			public const int uPHTYxnxRNKBYaAhvlNYPbcEeHyA = 320;

			public float ZLuIghfXamuoIvkXDgrAHKAnWdZH;

			public float sXRlLojYeaFTvFMPMqvcYofkGCMX;

			public float mEDVkXCuujAgHcMZWUfNxEnRoJBF;

			public float ZiBoNcoDdKKqrsQnfxhdalILKwxf;

			internal zmhcxUcUtUbZbzRitpLYGJzDseKhA(float P_0, float P_1, float P_2, float P_3)
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
				ZLuIghfXamuoIvkXDgrAHKAnWdZH = P_0;
				sXRlLojYeaFTvFMPMqvcYofkGCMX = P_1;
				mEDVkXCuujAgHcMZWUfNxEnRoJBF = P_2;
				ZiBoNcoDdKKqrsQnfxhdalILKwxf = P_3;
			}

			public static zmhcxUcUtUbZbzRitpLYGJzDseKhA bmRzwyakmoFCaKmpSzTjMejjeCLbA()
			{
				return new zmhcxUcUtUbZbzRitpLYGJzDseKhA(0f, 160f, 0f, 320f);
			}

			public string khRSpSdQqRXnaXRrLYTItniarbyD()
			{
				return "amplitudeLow: " + ZLuIghfXamuoIvkXDgrAHKAnWdZH + ", frequencyLow: " + sXRlLojYeaFTvFMPMqvcYofkGCMX + ", amplitudeHigh: " + mEDVkXCuujAgHcMZWUfNxEnRoJBF + ", frequencyHigh: " + ZiBoNcoDdKKqrsQnfxhdalILKwxf;
			}
		}

		private struct YmQnGgWwUAAbgyuHIVmVKICnnxu
		{
			public byte ZyTZZUUYznfozWDqddzwFVCENGKZA;

			public byte[] GdCLaihKarAxFtohWoBvyHhLWLWX;

			public int IjtzPAaLQkmmQoogkimEhHwQvRieA;

			public YmQnGgWwUAAbgyuHIVmVKICnnxu(byte P_0, byte[] P_1, int P_2)
			{
				ZyTZZUUYznfozWDqddzwFVCENGKZA = P_0;
				GdCLaihKarAxFtohWoBvyHhLWLWX = P_1;
				IjtzPAaLQkmmQoogkimEhHwQvRieA = P_2;
			}
		}

		protected class CttqfMbwLaWOhcQiNnIFagKOAwwT
		{
			public ushort otorQnYgCxtXXcJgcsukGtgBzqBh;

			public ushort vqSbSEcmxUYfMYRbocEEvCuBeBpk;

			public ushort SKIYWywKtokiXonrYvfVqsDtHtbc;

			public ushort keAkDbLbAAEhwSpQaiKjrlJrglRK;

			public virtual string chleJLwqsMjFHNuUxeQclpdUkoNM()
			{
				return "min: " + otorQnYgCxtXXcJgcsukGtgBzqBh + ", max: " + vqSbSEcmxUYfMYRbocEEvCuBeBpk + ", zero: " + SKIYWywKtokiXonrYvfVqsDtHtbc + ", deadzone: " + keAkDbLbAAEhwSpQaiKjrlJrglRK;
			}
		}

		private const uint MhhPzOesOfkscQFOhJWfLjiMTLro = 40u;

		private const float yCnKesSjDsOImMSXUfGjdnYUPyUN = 0.025f;

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

		private const int tvApqFiqCZPTMGPNQDyJeRuWvKWC = 4;

		private const string mkUEJqbnVbQfjHWiiUvUfiZDGikZ = "Failed to allocate memory.";

		protected readonly NMOoxbNrRRsluLpmhhjPhxWOwZVpA _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice gTPgoLCGKvODJmKQMfMQEcYnvRhYA;

		private readonly HIDProperties cMYTrPDaadITueITogrHDeFIyAwG;

		private readonly bool fUlBHDUCEFiPKMLXwDrGDikkEQrS;

		private readonly NativeBuffer uouGmjHpinIhnRSBOkcnQMGoXFaDA;

		private readonly NativeBuffer kRVJdXDQioEpNZHxAPlNxZbSFQAW;

		private readonly NativeBuffer cqArWVTkAKdOkMEfkfxiDaHaLFHvA;

		private readonly byte[] VulEMkeSMbEKqHeVIgZviBffissgb;

		private readonly NativeBuffer FHvlbRpADzLHeDXyNYFMsgfhmlQe;

		private readonly NativeBuffer OnzBGQNDUGtQGAmXuAwhsoFagpvCA;

		private dQrAZjxmvMRuuUvHYPSsKegoCJrCA SPDoEoSgIYoAGbzfpbYgcolzheAF;

		private byte njUbHkHDpQuGjyhyPkWRPSmcvgeP;

		private bool ZDYrtalaqxhUbyhUSOfUuFyWevIl;

		private xLxXgQPOMPcIqFnrTwfPgabrzuaA[] WJSaIylqtxzVKmdNgbeYdeCrpBNlA;

		private CttqfMbwLaWOhcQiNnIFagKOAwwT[] VigJEzNrSFlLxtyxMQHvebiJeQMd;

		private double usIgajFlmqNHfvIBwdrzGEPFQXQsA;

		private ManualResetEvent buqGETCnWGtNWMCuoMLKjAMbyhOi;

		private vcRikLjxeOhNWIbjVLyKaSHbtazzb DYjbSeHrGtGLrQhdxRENgeELzRAfA;

		private const int mCAVSkURAEwDVkclCfYyObBPIlGj = 100;

		private Dictionary<int, iyYMrnLIKiERMtIHgBsfSzgNHHtU> xkfMbOfpZlGqnCIvSgDYpxcFiDAxA;

		int IDriver_NintendoSwitchController.vibrationMotorCount => _vibrationMotorCount;

		ushort IHIDControllerExtension.vendorId => cMYTrPDaadITueITogrHDeFIyAwG.vendorId;

		ushort IHIDControllerExtension.productId => cMYTrPDaadITueITogrHDeFIyAwG.productId;

		string IHIDControllerExtension.productName => cMYTrPDaadITueITogrHDeFIyAwG.productName;

		string IHIDControllerExtension.manufacturer => cMYTrPDaadITueITogrHDeFIyAwG.manufacturer;

		ushort IHIDControllerExtension.usagePage => cMYTrPDaadITueITogrHDeFIyAwG.usagePage;

		ushort IHIDControllerExtension.usage => cMYTrPDaadITueITogrHDeFIyAwG.usage;

		private Dictionary<int, iyYMrnLIKiERMtIHgBsfSzgNHHtU> initializationCommands
		{
			get
			{
				if (xkfMbOfpZlGqnCIvSgDYpxcFiDAxA == null)
				{
					xkfMbOfpZlGqnCIvSgDYpxcFiDAxA = new Dictionary<int, iyYMrnLIKiERMtIHgBsfSzgNHHtU> { { 1, NfwcAiVDxVTEFjKsIcjdNOOvbiPs } };
				}
				return xkfMbOfpZlGqnCIvSgDYpxcFiDAxA;
			}
		}

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
				zmhcxUcUtUbZbzRitpLYGJzDseKhA zmhcxUcUtUbZbzRitpLYGJzDseKhA2 = WJSaIylqtxzVKmdNgbeYdeCrpBNlA[motorIndex].IQDFXNNTzxXcaBHoGiJjUZuIDsZF;
				amplitudeLow = zmhcxUcUtUbZbzRitpLYGJzDseKhA2.ZLuIghfXamuoIvkXDgrAHKAnWdZH;
				frequencyLow = zmhcxUcUtUbZbzRitpLYGJzDseKhA2.sXRlLojYeaFTvFMPMqvcYofkGCMX;
				amplitudeHigh = zmhcxUcUtUbZbzRitpLYGJzDseKhA2.mEDVkXCuujAgHcMZWUfNxEnRoJBF;
				frequencyHigh = zmhcxUcUtUbZbzRitpLYGJzDseKhA2.ZiBoNcoDdKKqrsQnfxhdalILKwxf;
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
					FLWYaHHkkbVBiNaOiLFHDcbjgdtGA(motorIndex);
				}
				WJSaIylqtxzVKmdNgbeYdeCrpBNlA[motorIndex].uOGvBmMIOWHAiZyGtOuBCIwLqXXp(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
				ETPqQCqKHQamOYavXHHEBXxCfKOk(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous);
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
				WJSaIylqtxzVKmdNgbeYdeCrpBNlA[motorIndex].nfMveZrkSuuclYawisABnXeVLzJe();
				ETPqQCqKHQamOYavXHHEBXxCfKOk(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous);
			}
		}

		void IDriver_NintendoSwitchController.StopVibration(int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration(motorIndex);
		}

		public void StopVibration()
		{
			StopVibration(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous);
		}

		void IDriver_NintendoSwitchController.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		private void StopVibration(IpOusHhkFVHLPKjRNBUJTzZIWToMA asyncMode)
		{
			for (int i = 0; i < _vibrationMotorCount; i++)
			{
				WJSaIylqtxzVKmdNgbeYdeCrpBNlA[i].nfMveZrkSuuclYawisABnXeVLzJe();
			}
			ETPqQCqKHQamOYavXHHEBXxCfKOk(asyncMode);
		}

		private void FLWYaHHkkbVBiNaOiLFHDcbjgdtGA(int P_0)
		{
			for (int i = 0; i < WJSaIylqtxzVKmdNgbeYdeCrpBNlA.Length; i++)
			{
				if (i != P_0)
				{
					WJSaIylqtxzVKmdNgbeYdeCrpBNlA[i].nfMveZrkSuuclYawisABnXeVLzJe();
				}
			}
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, NMOoxbNrRRsluLpmhhjPhxWOwZVpA P_1, int P_2, int P_3, int P_4)
			: base(P_0)
		{
			_controllerType = P_1;
			_buttonCount = P_2;
			_axisCount = P_3;
			_vibrationMotorCount = P_4;
			gTPgoLCGKvODJmKQMfMQEcYnvRhYA = P_0.hidDevice;
			cMYTrPDaadITueITogrHDeFIyAwG = P_0.hidDevice.properties;
			fUlBHDUCEFiPKMLXwDrGDikkEQrS = P_0.connectionType == THNsKdmFHrPljnxJReWkqtKXyhyf.Bluetooth;
			if (cMYTrPDaadITueITogrHDeFIyAwG.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			uouGmjHpinIhnRSBOkcnQMGoXFaDA = MgldmcHMHDgVqTZmlJrahFngISorA(cMYTrPDaadITueITogrHDeFIyAwG.maxInputReportLength);
			kRVJdXDQioEpNZHxAPlNxZbSFQAW = MgldmcHMHDgVqTZmlJrahFngISorA(cMYTrPDaadITueITogrHDeFIyAwG.maxOutputReportLength);
			cqArWVTkAKdOkMEfkfxiDaHaLFHvA = MgldmcHMHDgVqTZmlJrahFngISorA(32);
			VulEMkeSMbEKqHeVIgZviBffissgb = new byte[cMYTrPDaadITueITogrHDeFIyAwG.maxInputReportLength];
			FHvlbRpADzLHeDXyNYFMsgfhmlQe = MgldmcHMHDgVqTZmlJrahFngISorA(cMYTrPDaadITueITogrHDeFIyAwG.maxOutputReportLength);
			OnzBGQNDUGtQGAmXuAwhsoFagpvCA = MgldmcHMHDgVqTZmlJrahFngISorA(49);
			SPDoEoSgIYoAGbzfpbYgcolzheAF = new dQrAZjxmvMRuuUvHYPSsKegoCJrCA(kRVJdXDQioEpNZHxAPlNxZbSFQAW.Pointer, kRVJdXDQioEpNZHxAPlNxZbSFQAW.Length, kRVJdXDQioEpNZHxAPlNxZbSFQAW.Length);
			ReInput.ApplicationPauseChangedEvent += HMsvEaenvJjDoeiatThSdauHOoor;
			buttons = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA[P_2];
			for (int i = 0; i < P_2; i++)
			{
				buttons[i] = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA(48, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			VigJEzNrSFlLxtyxMQHvebiJeQMd = new CttqfMbwLaWOhcQiNnIFagKOAwwT[_axisCount];
			vibrationMotors = new rTJgTxMejKLMRUmSvWOxEnqbcNsC[P_4];
			for (int j = 0; j < vibrationMotors.Length; j++)
			{
				vibrationMotors[j] = new rTJgTxMejKLMRUmSvWOxEnqbcNsC(0, 255);
			}
			WJSaIylqtxzVKmdNgbeYdeCrpBNlA = new xLxXgQPOMPcIqFnrTwfPgabrzuaA[P_4];
			for (int k = 0; k < WJSaIylqtxzVKmdNgbeYdeCrpBNlA.Length; k++)
			{
				WJSaIylqtxzVKmdNgbeYdeCrpBNlA[k] = new xLxXgQPOMPcIqFnrTwfPgabrzuaA(vibrationMotors[k]);
			}
		}

		protected override void OnInitialize()
		{
			DYjbSeHrGtGLrQhdxRENgeELzRAfA = vcRikLjxeOhNWIbjVLyKaSHbtazzb.None;
			buqGETCnWGtNWMCuoMLKjAMbyhOi = new ManualResetEvent(initialState: false);
			try
			{
				new Thread((ThreadStart)delegate
				{
					try
					{
						DYjbSeHrGtGLrQhdxRENgeELzRAfA = lMhgTJaEbDuAGQsnYFFVbBhYdFsiA();
					}
					catch
					{
						DYjbSeHrGtGLrQhdxRENgeELzRAfA = vcRikLjxeOhNWIbjVLyKaSHbtazzb.Fail;
					}
					buqGETCnWGtNWMCuoMLKjAMbyhOi.Set();
				}).Start();
			}
			catch
			{
				buqGETCnWGtNWMCuoMLKjAMbyhOi.Set();
			}
		}

		private vcRikLjxeOhNWIbjVLyKaSHbtazzb lMhgTJaEbDuAGQsnYFFVbBhYdFsiA()
		{
			Action action = delegate
			{
				if (ZDYrtalaqxhUbyhUSOfUuFyWevIl)
				{
					throw new IHEyLnkdBVkOYXgEdgtJXWFSFYai();
				}
			};
			int num = 0;
			while (num < 3)
			{
				action();
				try
				{
					kRVJdXDQioEpNZHxAPlNxZbSFQAW.Clear();
					if (!fUlBHDUCEFiPKMLXwDrGDikkEQrS)
					{
						NativeBuffer nativeBuffer = kRVJdXDQioEpNZHxAPlNxZbSFQAW;
						action();
						FxjYsWMzPUYldQAcJeLusjMYoUsN(RjRzjOvxivqxcXLlCnFiQdqwmgYH.GetUsbStatus, 5u, 500u);
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 2;
						if (!BafRDzqVSjpERxmYJnPPTZDvfjEL(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous))
						{
							throw new Exception();
						}
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 3;
						if (!BafRDzqVSjpERxmYJnPPTZDvfjEL(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous))
						{
							throw new Exception();
						}
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 2;
						if (!BafRDzqVSjpERxmYJnPPTZDvfjEL(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous))
						{
							throw new Exception();
						}
						action();
						nativeBuffer[0] = 128;
						nativeBuffer[1] = 4;
						if (!BafRDzqVSjpERxmYJnPPTZDvfjEL(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous))
						{
							throw new Exception();
						}
					}
					action();
					if (!ZKBXSTDLRxtWcmzlAwzHaURloutB(new YmQnGgWwUAAbgyuHIVmVKICnnxu(72, new byte[1] { 1 }, 1), VulEMkeSMbEKqHeVIgZviBffissgb, action))
					{
						throw new Exception();
					}
					action();
					if (!ZKBXSTDLRxtWcmzlAwzHaURloutB(new YmQnGgWwUAAbgyuHIVmVKICnnxu(3, new byte[1] { 48 }, 1), VulEMkeSMbEKqHeVIgZviBffissgb, action))
					{
						throw new Exception();
					}
					action();
					IzbkTkiPtxNjPHkyIcJcdRJfmGRAb(action);
					action();
					if (!iWBzntmWBcIcvLOsxfTDeePMPZbV(action))
					{
						throw new Exception();
					}
					return vcRikLjxeOhNWIbjVLyKaSHbtazzb.Success;
				}
				catch (IHEyLnkdBVkOYXgEdgtJXWFSFYai)
				{
					return vcRikLjxeOhNWIbjVLyKaSHbtazzb.Fail;
				}
				catch
				{
					num++;
				}
			}
			throw new Exception();
		}

		private bool FxjYsWMzPUYldQAcJeLusjMYoUsN(RjRzjOvxivqxcXLlCnFiQdqwmgYH P_0, uint P_1, uint P_2)
		{
			if (!initializationCommands.TryGetValue((int)P_0, out var value))
			{
				throw new Exception();
			}
			uint num = 0u;
			do
			{
				if (value(P_2))
				{
					return true;
				}
				num++;
			}
			while (num <= P_1);
			throw new Exception();
		}

		private bool NfwcAiVDxVTEFjKsIcjdNOOvbiPs(uint P_0)
		{
			NativeBuffer nativeBuffer = kRVJdXDQioEpNZHxAPlNxZbSFQAW;
			nativeBuffer.Clear();
			nativeBuffer[0] = 128;
			nativeBuffer[1] = 1;
			if (!BafRDzqVSjpERxmYJnPPTZDvfjEL(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous))
			{
				return false;
			}
			double num = ReInput.realTime + (double)((float)P_0 * 0.001f);
			do
			{
				IL_0069:
				if (gTPgoLCGKvODJmKQMfMQEcYnvRhYA.ReadSync(OnzBGQNDUGtQGAmXuAwhsoFagpvCA, OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Length, 100))
				{
					if (OnzBGQNDUGtQGAmXuAwhsoFagpvCA[0] == 129 && OnzBGQNDUGtQGAmXuAwhsoFagpvCA[1] == 1)
					{
						return true;
					}
					if (!(ReInput.realTime >= num))
					{
						goto IL_0069;
					}
				}
			}
			while (ReInput.realTime < num);
			return false;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			switch (DYjbSeHrGtGLrQhdxRENgeELzRAfA)
			{
			case vcRikLjxeOhNWIbjVLyKaSHbtazzb.Success:
				DYjbSeHrGtGLrQhdxRENgeELzRAfA = vcRikLjxeOhNWIbjVLyKaSHbtazzb.Ready;
				InitializationFinished(initialized: true);
				break;
			case vcRikLjxeOhNWIbjVLyKaSHbtazzb.Fail:
				if (!base.disposed)
				{
					InitializationFinished(initialized: false);
					Dispose();
					Error(DnxCacaTXSZEpeSgtDxoenPsQrOsA.AsyncInitialization);
				}
				break;
			}
			if (DYjbSeHrGtGLrQhdxRENgeELzRAfA != vcRikLjxeOhNWIbjVLyKaSHbtazzb.Ready)
			{
				return;
			}
			double realTime = ReInput.realTime;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < WJSaIylqtxzVKmdNgbeYdeCrpBNlA.Length; i++)
			{
				if (WJSaIylqtxzVKmdNgbeYdeCrpBNlA[i].mYYeWqDWSRBDLyWNdSdkjUOCyMWx(realTime))
				{
					flag = true;
				}
				if (WJSaIylqtxzVKmdNgbeYdeCrpBNlA[i].IkSQvPjYkKmcihPZWGTojFtCcmOrA)
				{
					flag2 = true;
				}
			}
			if (flag || (flag2 && realTime >= usIgajFlmqNHfvIBwdrzGEPFQXQsA + 0.02500000037252903))
			{
				ETPqQCqKHQamOYavXHHEBXxCfKOk(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous);
			}
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (DYjbSeHrGtGLrQhdxRENgeELzRAfA != vcRikLjxeOhNWIbjVLyKaSHbtazzb.Ready)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (uouGmjHpinIhnRSBOkcnQMGoXFaDA.Length < 49)
			{
				return false;
			}
			byte b = Marshal.ReadByte(inputReportPtr, 0);
			if (b != 33 && b != 48)
			{
				return false;
			}
			int numBytesToWrite = Math.Min(inputReportLength, uouGmjHpinIhnRSBOkcnQMGoXFaDA.Length);
			uouGmjHpinIhnRSBOkcnQMGoXFaDA.Write(inputReportPtr, inputReportLength, numBytesToWrite);
			uouGmjHpinIhnRSBOkcnQMGoXFaDA.Write((byte)48, 0);
			UpdateButtons(uouGmjHpinIhnRSBOkcnQMGoXFaDA, timestamp);
			OYzieseEeYXDrIqXsZAdwVmBBsCg[] elements = axes;
			UpdateElements(elements, uouGmjHpinIhnRSBOkcnQMGoXFaDA, timestamp);
			return true;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(OYzieseEeYXDrIqXsZAdwVmBBsCg[] elements, NativeBuffer inputReport, double timestamp);

		private bool ZKBXSTDLRxtWcmzlAwzHaURloutB(YmQnGgWwUAAbgyuHIVmVKICnnxu P_0, byte[] P_1, Action P_2)
		{
			try
			{
				P_2();
				if (P_0.GdCLaihKarAxFtohWoBvyHhLWLWX.Length + 11 > FHvlbRpADzLHeDXyNYFMsgfhmlQe.Length)
				{
					return false;
				}
				kjXeZaWdIEePwfYUXgqSqXNeaMooA(FHvlbRpADzLHeDXyNYFMsgfhmlQe);
				FHvlbRpADzLHeDXyNYFMsgfhmlQe[10] = P_0.ZyTZZUUYznfozWDqddzwFVCENGKZA;
				FHvlbRpADzLHeDXyNYFMsgfhmlQe.TryWriteBytes(P_0.GdCLaihKarAxFtohWoBvyHhLWLWX, P_0.IjtzPAaLQkmmQoogkimEhHwQvRieA, 11);
				int num = 3;
				bool flag = false;
				int num2 = 0;
				double num3 = 0.0;
				while (gTPgoLCGKvODJmKQMfMQEcYnvRhYA.ReadSync(OnzBGQNDUGtQGAmXuAwhsoFagpvCA, OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Length, 1))
				{
					P_2();
				}
				for (int i = 0; i < num; i++)
				{
					P_2();
					Array.Clear(P_1, 0, P_1.Length);
					OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Clear();
					CyGDEYVHtRXTXgUMLwDLeXbTIUih(FHvlbRpADzLHeDXyNYFMsgfhmlQe, P_0.ZyTZZUUYznfozWDqddzwFVCENGKZA);
					num3 = ReInput.realTime;
					if (i == 0)
					{
						_ = ReInput.realTime;
					}
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					while (true)
					{
						P_2();
						if (ReInput.realTime >= num3 + 1.0)
						{
							break;
						}
						if (gTPgoLCGKvODJmKQMfMQEcYnvRhYA.ReadSync(OnzBGQNDUGtQGAmXuAwhsoFagpvCA, OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Length, 200))
						{
							num6++;
							if (OnzBGQNDUGtQGAmXuAwhsoFagpvCA[0] == 33)
							{
								if (OnzBGQNDUGtQGAmXuAwhsoFagpvCA[14] == P_0.ZyTZZUUYznfozWDqddzwFVCENGKZA)
								{
									flag = true;
									_ = ReInput.realTime;
									break;
								}
								num4++;
								num2++;
							}
						}
						else
						{
							num5++;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Read(P_1, OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Length);
				}
				return flag;
			}
			catch (IHEyLnkdBVkOYXgEdgtJXWFSFYai)
			{
				throw;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private bool CyGDEYVHtRXTXgUMLwDLeXbTIUih(NativeBuffer P_0, byte P_1)
		{
			if (!gTPgoLCGKvODJmKQMfMQEcYnvRhYA.WriteSync(new dQrAZjxmvMRuuUvHYPSsKegoCJrCA(P_0, P_0.Length, P_0.Length), 1000))
			{
				return false;
			}
			return true;
		}

		private void kjXeZaWdIEePwfYUXgqSqXNeaMooA(NativeBuffer P_0)
		{
			P_0.Clear();
			P_0[0] = 1;
			P_0[1] = VEznZJaimNrQRQysuAuVPBnHhtLaA();
			zXxAcKGplICECZdYaJrPOkjARxfB(P_0, 2);
		}

		private void zXxAcKGplICECZdYaJrPOkjARxfB(NativeBuffer P_0, int P_1)
		{
			if (_controllerType == NMOoxbNrRRsluLpmhhjPhxWOwZVpA.JoyConRight)
			{
				P_1 += 4;
			}
			for (int i = 0; i < WJSaIylqtxzVKmdNgbeYdeCrpBNlA.Length; i++)
			{
				LXQwOFjKASbHMgDiGbVCNoelxBfR(P_0, P_1, WJSaIylqtxzVKmdNgbeYdeCrpBNlA[i].IQDFXNNTzxXcaBHoGiJjUZuIDsZF);
				P_1 += 4;
			}
		}

		private static void LXQwOFjKASbHMgDiGbVCNoelxBfR(NativeBuffer P_0, int P_1, zmhcxUcUtUbZbzRitpLYGJzDseKhA P_2)
		{
			if (P_1 + 4 >= P_0.Length)
			{
				return;
			}
			if (P_2.ZLuIghfXamuoIvkXDgrAHKAnWdZH == 0f && P_2.mEDVkXCuujAgHcMZWUfNxEnRoJBF == 0f)
			{
				P_0[P_1] = 0;
				P_0[1 + P_1] = 1;
				P_0[2 + P_1] = 64;
				P_0[3 + P_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.ZiBoNcoDdKKqrsQnfxhdalILKwxf * 0.1f, 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.sXRlLojYeaFTvFMPMqvcYofkGCMX * 0.1f, 2.0)) - 64.0);
			byte b2 = HBbxoaRTHwemaDjBDHeKRuLMjPcCA(P_2.mEDVkXCuujAgHcMZWUfNxEnRoJBF);
			ushort num2 = (ushort)(Math.Round((double)(int)HBbxoaRTHwemaDjBDHeKRuLMjPcCA(P_2.ZLuIghfXamuoIvkXDgrAHKAnWdZH)) * 0.5);
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

		private static byte HBbxoaRTHwemaDjBDHeKRuLMjPcCA(float P_0)
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

		private void ETPqQCqKHQamOYavXHHEBXxCfKOk(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			if (kRVJdXDQioEpNZHxAPlNxZbSFQAW.Length >= 2 + WJSaIylqtxzVKmdNgbeYdeCrpBNlA.Length * 4)
			{
				kRVJdXDQioEpNZHxAPlNxZbSFQAW.Clear();
				kRVJdXDQioEpNZHxAPlNxZbSFQAW[0] = 16;
				kRVJdXDQioEpNZHxAPlNxZbSFQAW[1] = VEznZJaimNrQRQysuAuVPBnHhtLaA();
				zXxAcKGplICECZdYaJrPOkjARxfB(kRVJdXDQioEpNZHxAPlNxZbSFQAW, 2);
				if (BafRDzqVSjpERxmYJnPPTZDvfjEL(P_0))
				{
					usIgajFlmqNHfvIBwdrzGEPFQXQsA = ReInput.realTime;
				}
			}
		}

		private bool IzbkTkiPtxNjPHkyIcJcdRJfmGRAb(Action P_0)
		{
			byte[] array = new byte[25];
			ArrayTools.Fill(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return ZKBXSTDLRxtWcmzlAwzHaURloutB(new YmQnGgWwUAAbgyuHIVmVKICnnxu(56, array, 25), VulEMkeSMbEKqHeVIgZviBffissgb, P_0);
		}

		private bool prTeNqZCqCUpfwnLDqHAajbrBEEx(bool P_0, Action P_1)
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
			return ZKBXSTDLRxtWcmzlAwzHaURloutB(new YmQnGgWwUAAbgyuHIVmVKICnnxu(56, array, 25), VulEMkeSMbEKqHeVIgZviBffissgb, P_1);
		}

		private bool huxpdrGyijWzpAAPTGhBUueSzZrP(byte P_0, byte P_1, byte P_2, byte[] P_3, Action P_4)
		{
			byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (ZKBXSTDLRxtWcmzlAwzHaURloutB(new YmQnGgWwUAAbgyuHIVmVKICnnxu(16, array, array.Length), P_3, P_4) && P_3[15] == P_1 && P_3[16] == P_0)
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

		private bool BafRDzqVSjpERxmYJnPPTZDvfjEL(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			switch (P_0)
			{
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous:
				return gTPgoLCGKvODJmKQMfMQEcYnvRhYA.WriteSync(SPDoEoSgIYoAGbzfpbYgcolzheAF, 0);
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous:
				gTPgoLCGKvODJmKQMfMQEcYnvRhYA.WriteAsync(SPDoEoSgIYoAGbzfpbYgcolzheAF, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private byte VEznZJaimNrQRQysuAuVPBnHhtLaA()
		{
			if (njUbHkHDpQuGjyhyPkWRPSmcvgeP == 15)
			{
				njUbHkHDpQuGjyhyPkWRPSmcvgeP = 0;
			}
			else
			{
				njUbHkHDpQuGjyhyPkWRPSmcvgeP++;
			}
			return njUbHkHDpQuGjyhyPkWRPSmcvgeP;
		}

		private bool iWBzntmWBcIcvLOsxfTDeePMPZbV(Action P_0)
		{
			bool flag = false;
			bool flag2 = _controllerType == NMOoxbNrRRsluLpmhhjPhxWOwZVpA.JoyConLeft || _controllerType == NMOoxbNrRRsluLpmhhjPhxWOwZVpA.ProController;
			Array.Clear(VigJEzNrSFlLxtyxMQHvebiJeQMd, 0, VigJEzNrSFlLxtyxMQHvebiJeQMd.Length);
			bool flag3 = false;
			if (huxpdrGyijWzpAAPTGhBUueSzZrP(128, (byte)(flag2 ? 18 : 29), 9, VulEMkeSMbEKqHeVIgZviBffissgb, P_0))
			{
				for (int i = 0; i < 9; i++)
				{
					if (VulEMkeSMbEKqHeVIgZviBffissgb[i] != byte.MaxValue)
					{
						flag3 = true;
					}
				}
			}
			if (!flag3 && huxpdrGyijWzpAAPTGhBUueSzZrP(96, (byte)(flag2 ? 61 : 70), 9, VulEMkeSMbEKqHeVIgZviBffissgb, P_0))
			{
				flag3 = true;
			}
			if (flag3)
			{
				CttqfMbwLaWOhcQiNnIFagKOAwwT cttqfMbwLaWOhcQiNnIFagKOAwwT = new CttqfMbwLaWOhcQiNnIFagKOAwwT();
				CttqfMbwLaWOhcQiNnIFagKOAwwT cttqfMbwLaWOhcQiNnIFagKOAwwT2 = new CttqfMbwLaWOhcQiNnIFagKOAwwT();
				buQqtXkBTLyuwwWVXyxUezESSQsF(VulEMkeSMbEKqHeVIgZviBffissgb, cttqfMbwLaWOhcQiNnIFagKOAwwT, cttqfMbwLaWOhcQiNnIFagKOAwwT2, flag2);
				VigJEzNrSFlLxtyxMQHvebiJeQMd[0] = cttqfMbwLaWOhcQiNnIFagKOAwwT;
				VigJEzNrSFlLxtyxMQHvebiJeQMd[1] = cttqfMbwLaWOhcQiNnIFagKOAwwT2;
				flag = true;
				if (huxpdrGyijWzpAAPTGhBUueSzZrP(96, (byte)(flag2 ? 134 : 152), 16, VulEMkeSMbEKqHeVIgZviBffissgb, P_0))
				{
					TBJHJGFlAWUGsQLxYEtfanJcIbtIc(VulEMkeSMbEKqHeVIgZviBffissgb, cttqfMbwLaWOhcQiNnIFagKOAwwT, cttqfMbwLaWOhcQiNnIFagKOAwwT2);
				}
			}
			else
			{
				flag = false;
			}
			if (_controllerType == NMOoxbNrRRsluLpmhhjPhxWOwZVpA.ProController)
			{
				bool flag4 = false;
				if (huxpdrGyijWzpAAPTGhBUueSzZrP(128, (byte)((!flag2) ? 18 : 29), 9, VulEMkeSMbEKqHeVIgZviBffissgb, P_0))
				{
					for (int j = 0; j < 9; j++)
					{
						if (VulEMkeSMbEKqHeVIgZviBffissgb[j] != byte.MaxValue)
						{
							flag4 = true;
						}
					}
				}
				if (!flag4 && huxpdrGyijWzpAAPTGhBUueSzZrP(96, (byte)((!flag2) ? 61 : 70), 9, VulEMkeSMbEKqHeVIgZviBffissgb, P_0))
				{
					flag4 = true;
				}
				if (flag4)
				{
					CttqfMbwLaWOhcQiNnIFagKOAwwT cttqfMbwLaWOhcQiNnIFagKOAwwT3 = new CttqfMbwLaWOhcQiNnIFagKOAwwT();
					CttqfMbwLaWOhcQiNnIFagKOAwwT cttqfMbwLaWOhcQiNnIFagKOAwwT4 = new CttqfMbwLaWOhcQiNnIFagKOAwwT();
					buQqtXkBTLyuwwWVXyxUezESSQsF(VulEMkeSMbEKqHeVIgZviBffissgb, cttqfMbwLaWOhcQiNnIFagKOAwwT3, cttqfMbwLaWOhcQiNnIFagKOAwwT4, !flag2);
					VigJEzNrSFlLxtyxMQHvebiJeQMd[2] = cttqfMbwLaWOhcQiNnIFagKOAwwT3;
					VigJEzNrSFlLxtyxMQHvebiJeQMd[3] = cttqfMbwLaWOhcQiNnIFagKOAwwT4;
					flag = true;
					if (huxpdrGyijWzpAAPTGhBUueSzZrP(96, (byte)((!flag2) ? 134 : 152), 16, VulEMkeSMbEKqHeVIgZviBffissgb, P_0))
					{
						TBJHJGFlAWUGsQLxYEtfanJcIbtIc(VulEMkeSMbEKqHeVIgZviBffissgb, cttqfMbwLaWOhcQiNnIFagKOAwwT3, cttqfMbwLaWOhcQiNnIFagKOAwwT4);
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private static void buQqtXkBTLyuwwWVXyxUezESSQsF(byte[] P_0, CttqfMbwLaWOhcQiNnIFagKOAwwT P_1, CttqfMbwLaWOhcQiNnIFagKOAwwT P_2, bool P_3)
		{
			ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
			ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
			ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
			ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
			ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
			if (P_3)
			{
				P_1.vqSbSEcmxUYfMYRbocEEvCuBeBpk = num;
				P_2.vqSbSEcmxUYfMYRbocEEvCuBeBpk = num2;
				P_1.SKIYWywKtokiXonrYvfVqsDtHtbc = num3;
				P_2.SKIYWywKtokiXonrYvfVqsDtHtbc = num4;
				P_1.otorQnYgCxtXXcJgcsukGtgBzqBh = num5;
				P_2.otorQnYgCxtXXcJgcsukGtgBzqBh = num6;
			}
			else
			{
				P_1.SKIYWywKtokiXonrYvfVqsDtHtbc = num;
				P_2.SKIYWywKtokiXonrYvfVqsDtHtbc = num2;
				P_1.otorQnYgCxtXXcJgcsukGtgBzqBh = num3;
				P_2.otorQnYgCxtXXcJgcsukGtgBzqBh = num4;
				P_1.vqSbSEcmxUYfMYRbocEEvCuBeBpk = num5;
				P_2.vqSbSEcmxUYfMYRbocEEvCuBeBpk = num6;
			}
		}

		private static void TBJHJGFlAWUGsQLxYEtfanJcIbtIc(byte[] P_0, CttqfMbwLaWOhcQiNnIFagKOAwwT P_1, CttqfMbwLaWOhcQiNnIFagKOAwwT P_2)
		{
			P_1.keAkDbLbAAEhwSpQaiKjrlJrglRK = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
			P_2.keAkDbLbAAEhwSpQaiKjrlJrglRK = P_1.keAkDbLbAAEhwSpQaiKjrlJrglRK;
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, CttqfMbwLaWOhcQiNnIFagKOAwwT calX, CttqfMbwLaWOhcQiNnIFagKOAwwT calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort num = MathTools.Max(calX.keAkDbLbAAEhwSpQaiKjrlJrglRK, calY.keAkDbLbAAEhwSpQaiKjrlJrglRK);
			int num2 = valueX - calX.SKIYWywKtokiXonrYvfVqsDtHtbc;
			int num3 = valueY - calY.SKIYWywKtokiXonrYvfVqsDtHtbc;
			if (Math.Abs(num2 * num2 + num3 * num3) <= num * num)
			{
				return false;
			}
			Vector2 vector = new Vector2(InputTools.TransformAxis2DComponentValue((int)valueX, (int)calX.SKIYWywKtokiXonrYvfVqsDtHtbc, calX.SKIYWywKtokiXonrYvfVqsDtHtbc - calX.otorQnYgCxtXXcJgcsukGtgBzqBh, calX.SKIYWywKtokiXonrYvfVqsDtHtbc + calX.vqSbSEcmxUYfMYRbocEEvCuBeBpk, 0f, -1f, 1f, clamp: false), InputTools.TransformAxis2DComponentValue((int)valueY, (int)calY.SKIYWywKtokiXonrYvfVqsDtHtbc, calY.SKIYWywKtokiXonrYvfVqsDtHtbc - calY.otorQnYgCxtXXcJgcsukGtgBzqBh, calY.SKIYWywKtokiXonrYvfVqsDtHtbc + calY.vqSbSEcmxUYfMYRbocEEvCuBeBpk, 0f, -1f, 1f, clamp: false));
			float num4 = (float)(calX.otorQnYgCxtXXcJgcsukGtgBzqBh + calX.vqSbSEcmxUYfMYRbocEEvCuBeBpk + calY.otorQnYgCxtXXcJgcsukGtgBzqBh + calY.vqSbSEcmxUYfMYRbocEEvCuBeBpk) * 0.5f;
			float lowerDeadzone = (float)(int)num / (num4 * 0.5f);
			vector = InputTools.ApplyRadialDeadZone(vector.x, vector.y, lowerDeadzone, 0f, 1f, InputTools.ClampAxis2D.None);
			calibratedX = (ushort)MathTools.ValueInNewRange(vector.x, -1f, 1f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(vector.y, -1f, 1f, 0f, 65535f);
			return true;
		}

		protected CttqfMbwLaWOhcQiNnIFagKOAwwT GetAxisCalibration(int index)
		{
			return VigJEzNrSFlLxtyxMQHvebiJeQMd[index];
		}

		private void HMsvEaenvJjDoeiatThSdauHOoor(bool P_0)
		{
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
			ZDYrtalaqxhUbyhUSOfUuFyWevIl = true;
			if (buqGETCnWGtNWMCuoMLKjAMbyhOi != null)
			{
				buqGETCnWGtNWMCuoMLKjAMbyhOi.WaitOne();
			}
			if (disposing)
			{
				ReInput.ApplicationPauseChangedEvent -= HMsvEaenvJjDoeiatThSdauHOoor;
				if (DYjbSeHrGtGLrQhdxRENgeELzRAfA != vcRikLjxeOhNWIbjVLyKaSHbtazzb.Ready)
				{
					try
					{
						StopVibration(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
					}
					catch (Exception)
					{
					}
				}
				if (!fUlBHDUCEFiPKMLXwDrGDikkEQrS && kRVJdXDQioEpNZHxAPlNxZbSFQAW != null)
				{
					kRVJdXDQioEpNZHxAPlNxZbSFQAW.Clear();
					kRVJdXDQioEpNZHxAPlNxZbSFQAW[0] = 128;
					kRVJdXDQioEpNZHxAPlNxZbSFQAW[1] = 5;
					try
					{
						gTPgoLCGKvODJmKQMfMQEcYnvRhYA.WriteSync(SPDoEoSgIYoAGbzfpbYgcolzheAF, 0);
					}
					catch
					{
					}
					kRVJdXDQioEpNZHxAPlNxZbSFQAW.Clear();
					kRVJdXDQioEpNZHxAPlNxZbSFQAW[0] = 128;
					kRVJdXDQioEpNZHxAPlNxZbSFQAW[1] = 6;
					try
					{
						gTPgoLCGKvODJmKQMfMQEcYnvRhYA.WriteSync(SPDoEoSgIYoAGbzfpbYgcolzheAF, 0);
					}
					catch
					{
					}
				}
				if (uouGmjHpinIhnRSBOkcnQMGoXFaDA != null)
				{
					uouGmjHpinIhnRSBOkcnQMGoXFaDA.Dispose();
				}
				if (kRVJdXDQioEpNZHxAPlNxZbSFQAW != null)
				{
					kRVJdXDQioEpNZHxAPlNxZbSFQAW.Dispose();
				}
				if (FHvlbRpADzLHeDXyNYFMsgfhmlQe != null)
				{
					FHvlbRpADzLHeDXyNYFMsgfhmlQe.Dispose();
				}
				if (OnzBGQNDUGtQGAmXuAwhsoFagpvCA != null)
				{
					OnzBGQNDUGtQGAmXuAwhsoFagpvCA.Dispose();
				}
				if (cqArWVTkAKdOkMEfkfxiDaHaLFHvA == null)
				{
					cqArWVTkAKdOkMEfkfxiDaHaLFHvA.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private static NativeBuffer MgldmcHMHDgVqTZmlJrahFngISorA(int P_0)
		{
			NativeBuffer nativeBuffer = new NativeBuffer(P_0);
			if (nativeBuffer.Length != P_0)
			{
				throw new Exception("Failed to allocate memory.");
			}
			return nativeBuffer;
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("SwitchGamepadDriverBase: " + msg);
			}
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLogWarning(object msg)
		{
			if (msg != null)
			{
				Logger.LogWarning("SwitchGamepadDriverBase: " + msg, requiredThreadSafety: true);
			}
		}

		[Conditional("DEBUG_THIS")]
		protected static void DLogError(object msg)
		{
			if (msg != null)
			{
				Logger.LogError("SwitchGamepadDriverBase: " + msg, requiredThreadSafety: true);
			}
		}

		[Conditional("DEBUG_THIS_DISPOSE")]
		protected static void DDisposeLog(object msg)
		{
			if (msg != null)
			{
				Logger.Log("SwitchGamepadDriverBase: " + msg);
			}
		}

		[CompilerGenerated]
		private void oGfWhTOOwyHPmPPYQemaUgHdchdh()
		{
			try
			{
				DYjbSeHrGtGLrQhdxRENgeELzRAfA = lMhgTJaEbDuAGQsnYFFVbBhYdFsiA();
			}
			catch
			{
				DYjbSeHrGtGLrQhdxRENgeELzRAfA = vcRikLjxeOhNWIbjVLyKaSHbtazzb.Fail;
			}
			buqGETCnWGtNWMCuoMLKjAMbyhOi.Set();
		}

		[CompilerGenerated]
		private void LdYrAjfVjnidnxsidlTJaGhCnWqP()
		{
			if (ZDYrtalaqxhUbyhUSOfUuFyWevIl)
			{
				throw new IHEyLnkdBVkOYXgEdgtJXWFSFYai();
			}
		}
	}
}
