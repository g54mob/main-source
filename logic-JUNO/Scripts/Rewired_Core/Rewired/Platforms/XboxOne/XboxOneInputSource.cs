using System;
using System.Collections.Generic;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.XboxOne
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
	{
		[CustomObfuscation(rename = false)]
		private enum BadConnectionReason
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			GamepadNotActive = 1,
			[CustomObfuscation(rename = false)]
			InvalidName = 2
		}

		private struct rYBEzbfvBXicSNZkahniiUblmnryA
		{
			public uint NvfhXyXCbEsQBRzBtnwQFWZzeKSu;

			public uint BsRTfTcXUcmKJBpSlUBLaOVOPmci;

			public rYBEzbfvBXicSNZkahniiUblmnryA(uint P_0, uint P_1)
			{
				NvfhXyXCbEsQBRzBtnwQFWZzeKSu = P_0;
				BsRTfTcXUcmKJBpSlUBLaOVOPmci = P_1;
			}
		}

		private class TSKtNVRtpIrLDpAwUmyLKzQsUpIb : Joystick
		{
			private const int aOnsydIcHHGHictaeyLHqrIhJVNl = 6;

			private const int iuMgiGhRfsgirJlLEEgXHmEllyeTA = 14;

			private const string swkBRCVjNqVMZBiWECsyFfMgNNLB = "Xbox One Controller";

			private const int ouYcrPDUKdaZqBYzyfDOHDUiGIMO = 0;

			private const int PwYEWrqCEGEGDkNMaCRdmAezOJun = 1;

			private const int atzsKumNXXIUbUgmUYeQTJkHFPyFA = 2;

			private const int cGOhwLDGmUstEWymOwtZanTJFyyf = 3;

			private const int oIFErjItwbQpCLHmpBhDWpvdQNKK = 4;

			private const int gzJDHRIbbcRRXBLzcCOuwLzgwrzNB = 5;

			private const int lGuIOcKuUTuLmZkzQfZZbOvXdsklA = 6;

			private const int tqoXeYRmJQBzbqBHEaJrJgrFSHtW = 7;

			private const int lFOfYqEDhLqKaVbQMssiouRkaUrTA = 8;

			private const int TQgAFsiyHNQQueiOYiQKWxGKbwHfb = 9;

			private const int IhdAabgrdROVBIyqqJsqBIffLLGNA = 12;

			private const int trenFksJtquSIvPBAdZiBgqEhpUUA = 13;

			private const int YmhbDJEJsGdWYBqnscuAnNUHKihc = 14;

			private const int LsMHdhfPjaCKBEIYTngPoGKeXUCiA = 15;

			private const int HWnJfuSqJqxJNvdQHhIDTcvkqXfs = 0;

			private const int MIOxvLJGTvVkNmQFBfxEZmGalgho = 1;

			private const int IMpNumiNlAdzyVqzlbIAQrNDnMJ = 3;

			private const int ecIrtRzoHqPFCCByEQCIRDOjBJgc = 4;

			private const int sAhOzTHFxRjKFuYuNOFknoSKIxkO = 8;

			private const int kCFTQRRLMBhwygLCkBHPIjUnKpUBb = 9;

			private readonly IXboxOneInputSource WpWBgJCdxGdbajcXlhPAaqlgQcFgc;

			private int jhzaOkVZxwaYdOXWoirJJKCCRmQR;

			private ulong WPgqQDLzFQpFYGBDrhOVKrwnXeIX;

			private string[] zhKJIupxFvBNOGjFyBBaGJpcNglq;

			public ulong SvMfNlwNFZceShrdGPrNgqWEvSzwB => WPgqQDLzFQpFYGBDrhOVKrwnXeIX;

			public TSKtNVRtpIrLDpAwUmyLKzQsUpIb(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				WpWBgJCdxGdbajcXlhPAaqlgQcFgc = P_0;
				jhzaOkVZxwaYdOXWoirJJKCCRmQR = P_2 - 1;
				zhKJIupxFvBNOGjFyBBaGJpcNglq = new string[6];
				loYOnwPOiFFTkbaDVTJLifhnhZsyA();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					eeHGmEimRwpnnCBqCLgtlvjiYszBA(P_1);
				}
				else
				{
					WPgqQDLzFQpFYGBDrhOVKrwnXeIX = P_1;
				}
			}

			public virtual void SEQYKNNhFkicthexzbsxSkdAWzmz()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].value = anlDucAcvfgkQeykYnPdVxDtexkCb(0);
					buttons[1].value = anlDucAcvfgkQeykYnPdVxDtexkCb(1);
					buttons[2].value = anlDucAcvfgkQeykYnPdVxDtexkCb(2);
					buttons[3].value = anlDucAcvfgkQeykYnPdVxDtexkCb(3);
					buttons[4].value = anlDucAcvfgkQeykYnPdVxDtexkCb(4);
					buttons[5].value = anlDucAcvfgkQeykYnPdVxDtexkCb(5);
					buttons[6].value = anlDucAcvfgkQeykYnPdVxDtexkCb(6);
					buttons[7].value = anlDucAcvfgkQeykYnPdVxDtexkCb(7);
					buttons[8].value = anlDucAcvfgkQeykYnPdVxDtexkCb(8);
					buttons[9].value = anlDucAcvfgkQeykYnPdVxDtexkCb(9);
					buttons[10].value = anlDucAcvfgkQeykYnPdVxDtexkCb(12);
					buttons[11].value = anlDucAcvfgkQeykYnPdVxDtexkCb(15);
					buttons[12].value = anlDucAcvfgkQeykYnPdVxDtexkCb(13);
					buttons[13].value = anlDucAcvfgkQeykYnPdVxDtexkCb(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(zhKJIupxFvBNOGjFyBBaGJpcNglq[0]);
					axes[1].value = Input.GetAxisRaw(zhKJIupxFvBNOGjFyBBaGJpcNglq[1]);
					axes[2].value = Input.GetAxisRaw(zhKJIupxFvBNOGjFyBBaGJpcNglq[2]);
					axes[3].value = Input.GetAxisRaw(zhKJIupxFvBNOGjFyBBaGJpcNglq[3]);
					axes[4].value = Input.GetAxisRaw(zhKJIupxFvBNOGjFyBBaGJpcNglq[4]);
					axes[5].value = Input.GetAxisRaw(zhKJIupxFvBNOGjFyBBaGJpcNglq[5]);
				}
			}

			public void eeHGmEimRwpnnCBqCLgtlvjiYszBA(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					WPgqQDLzFQpFYGBDrhOVKrwnXeIX = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						xPsBYUfsIFlMwfuxcdtevMBrVvcHB();
					}
				}
			}

			private void xPsBYUfsIFlMwfuxcdtevMBrVvcHB()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(WPgqQDLzFQpFYGBDrhOVKrwnXeIX);
				}
				_customName = "Controller " + base.unityId;
			}

			private bool anlDucAcvfgkQeykYnPdVxDtexkCb(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + jhzaOkVZxwaYdOXWoirJJKCCRmQR * 20));
			}

			private void loYOnwPOiFFTkbaDVTJLifhnhZsyA()
			{
				zhKJIupxFvBNOGjFyBBaGJpcNglq[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				zhKJIupxFvBNOGjFyBBaGJpcNglq[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				zhKJIupxFvBNOGjFyBBaGJpcNglq[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				zhKJIupxFvBNOGjFyBBaGJpcNglq[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				zhKJIupxFvBNOGjFyBBaGJpcNglq[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				zhKJIupxFvBNOGjFyBBaGJpcNglq[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}
		}

		private const int mWBYzzSIeilmPHoCRuBADKVpQgRH = 8;

		private readonly bool HegYkwjBQKweRXroLJFAgiNeVNjt;

		private bool eUAGAxiwdDxKMrcywGdtoLSxPcDdA;

		private Queue<rYBEzbfvBXicSNZkahniiUblmnryA> vCzqQGPNmyYrVinIpSyLnlfdxtGX;

		private bool pzQIjERpfUDbHDBtCLltaklvfQTHA;

		bool CustomInputSource.isReady => HegYkwjBQKweRXroLJFAgiNeVNjt;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				vCzqQGPNmyYrVinIpSyLnlfdxtGX = new Queue<rYBEzbfvBXicSNZkahniiUblmnryA>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = hoKSVgmPfgrggjDEbGenYBGJMkyT((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new TSKtNVRtpIrLDpAwUmyLKzQsUpIb(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += zWqRQFTQVbXQCRYvSmTMMkBgwsfO;
				HegYkwjBQKweRXroLJFAgiNeVNjt = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (HegYkwjBQKweRXroLJFAgiNeVNjt)
			{
				eMyNKfduUIjUdjIPvCqsKObpEjsEb();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void zWqRQFTQVbXQCRYvSmTMMkBgwsfO(uint P_0, bool P_1)
		{
			if (!HegYkwjBQKweRXroLJFAgiNeVNjt)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (hoKSVgmPfgrggjDEbGenYBGJMkyT(P_0, true, out var _))
				{
					zBKcNjRVNyqDRlopfRvfGdATmYbi(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as TSKtNVRtpIrLDpAwUmyLKzQsUpIb).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void zBKcNjRVNyqDRlopfRvfGdATmYbi(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			TSKtNVRtpIrLDpAwUmyLKzQsUpIb obj = GetJoysticks()[index] as TSKtNVRtpIrLDpAwUmyLKzQsUpIb;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.eeHGmEimRwpnnCBqCLgtlvjiYszBA(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void eMyNKfduUIjUdjIPvCqsKObpEjsEb()
		{
			int num = vCzqQGPNmyYrVinIpSyLnlfdxtGX.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				rYBEzbfvBXicSNZkahniiUblmnryA item = vCzqQGPNmyYrVinIpSyLnlfdxtGX.Dequeue();
				if (currentFrame >= item.BsRTfTcXUcmKJBpSlUBLaOVOPmci + 1)
				{
					if (hoKSVgmPfgrggjDEbGenYBGJMkyT(item.NvfhXyXCbEsQBRzBtnwQFWZzeKSu, true, out var _))
					{
						zBKcNjRVNyqDRlopfRvfGdATmYbi(item.NvfhXyXCbEsQBRzBtnwQFWZzeKSu, false);
						flag = true;
					}
				}
				else
				{
					vCzqQGPNmyYrVinIpSyLnlfdxtGX.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool hoKSVgmPfgrggjDEbGenYBGJMkyT(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			if (!UnityTools.externalTools.XboxOneInput_IsGamepadActive(P_0))
			{
				P_2 = BadConnectionReason.GamepadNotActive;
				return false;
			}
			string text = UnityTools.externalTools.XboxOneInput_GetControllerType(UnityTools.externalTools.XboxOneInput_GetControllerId(P_0));
			if (string.IsNullOrEmpty(text) || text == " ")
			{
				if (P_1)
				{
					vCzqQGPNmyYrVinIpSyLnlfdxtGX.Enqueue(new rYBEzbfvBXicSNZkahniiUblmnryA(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void AnPSnTuVsiFIQdBpqiYmYGGzxFsU()
		{
			if (!eUAGAxiwdDxKMrcywGdtoLSxPcDdA)
			{
				eUAGAxiwdDxKMrcywGdtoLSxPcDdA = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!HegYkwjBQKweRXroLJFAgiNeVNjt)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		int IXboxOneInputSource.GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetXboxOneUserIdFromUnityJoystick
			return this.GetXboxOneUserIdFromUnityJoystick(unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (HegYkwjBQKweRXroLJFAgiNeVNjt)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		void IXboxOneInputSource.PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PulseVibrateMotor
			this.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, buajiwwNvsvnjCGMEWoTzaPnJCiy vibration)
		{
			if (!HegYkwjBQKweRXroLJFAgiNeVNjt)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.nkGBJlvyKZhoFpnZWQfPHualpOUh, vibration.mWMDFmZETmIKjnpDjaSJhejRebQD, vibration.yUaVmWdMhCVsKbfQAGaMOCioeCZx, vibration.IvxJOwYmFiHKqkvRXNGcOlBmmONL);
		}

		bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, buajiwwNvsvnjCGMEWoTzaPnJCiy vibration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetXboxOneVibration
			return this.SetXboxOneVibration(xboxOneJoystickId, vibration);
		}

		public override void Dispose()
		{
			base.Dispose();
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~XboxOneInputSource()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!pzQIjERpfUDbHDBtCLltaklvfQTHA)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= zWqRQFTQVbXQCRYvSmTMMkBgwsfO;
				}
				pzQIjERpfUDbHDBtCLltaklvfQTHA = true;
			}
		}
	}
}
