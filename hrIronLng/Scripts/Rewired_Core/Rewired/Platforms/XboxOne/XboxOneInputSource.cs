using System;
using System.Collections.Generic;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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

		private struct FQJFkXvBKsegNmKHHurwdDPRKYr
		{
			public uint CKFiVsSuUhzmBIWNiuZfIACGvL;

			public uint lexFucujcRyyCQNTPNjWxbooiAB;

			public FQJFkXvBKsegNmKHHurwdDPRKYr(uint unityJoystickId, uint connectedFrame)
			{
				CKFiVsSuUhzmBIWNiuZfIACGvL = unityJoystickId;
				lexFucujcRyyCQNTPNjWxbooiAB = connectedFrame;
			}
		}

		private class xUKyFxXfjzAbWAIfbohaJjLSxjpT : Joystick
		{
			private const int hdPfWCbEBCXchGQqzkLUjCOtChr = 6;

			private const int BIqrSHxnfVeJEnjKdnGBTolrmbG = 14;

			private const string IrxDdNXuVtDHyDwWzXZxqKXiKGt = "Xbox One Controller";

			private const int bDlCOdgwEHJGSUHXVnAtyUTKpevY = 0;

			private const int MkQeeHHnqfgGScfBpCcWcHFXypC = 1;

			private const int rQQBEnrvmbVyAmpixmoFAwwdEZH = 2;

			private const int AzoIpbRTflaGyjoHmInZbPqbRnTd = 3;

			private const int HEecrhWvGoHPdErdyotuiAzjbqj = 4;

			private const int wWMMNTgZaMikGzrXRkmvxcrebXC = 5;

			private const int CAdOqtyJvAwHfvBhlUgNsrpIBKe = 6;

			private const int fOcWDqCbfyddOKLzNTdfLqLsKLjN = 7;

			private const int HsAtoKVsrqGDOLaTTKGgotOiqft = 8;

			private const int dwhrgTsoWhcYKGaLzCfkAJwWnGJG = 9;

			private const int KmUCQrHjEuXNHxfwbozZEggJSSBO = 12;

			private const int XpGGRIDPiOFrYSjGNdkkBJxaKIee = 13;

			private const int nuTYcoLIuzhZenRrVKppolHbECm = 14;

			private const int fwqDOOcEFysSMIgzAayidVAeBivM = 15;

			private const int phCVoOKfmdNRWjDPcuACbHngAKXG = 0;

			private const int SrxvDwgmWFniOVLQokDcknTsLWF = 1;

			private const int NYUhebgraZPjCobEJgjfdMCsYDE = 3;

			private const int IIREYBWGdYcVeTSwSurdvtkmYYQ = 4;

			private const int fItILEzcIzelSjlstqcpQfqdgKX = 8;

			private const int MmsEXlrBPWcityEUhAMRqWfqUiF = 9;

			private readonly IXboxOneInputSource iRyNPwfaIbylCKBnafrigDzkSzy;

			private int dCZEgzobTpHayGZtxUSftmjRvGe;

			private ulong kkzFHTjpMkjDWaJagBMQkbPOjuC;

			private string[] DJprzqfMnuGSAvTEGvUALAUDEVK;

			public ulong xboxControllerId => kkzFHTjpMkjDWaJagBMQkbPOjuC;

			public xUKyFxXfjzAbWAIfbohaJjLSxjpT(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(isConnected ? UnityTools.externalTools.XboxOneInput_GetControllerType(xboxControllerId) : "Xbox One Controller", (long)xboxControllerId, unityJoystickId, 6, 14)
			{
				iRyNPwfaIbylCKBnafrigDzkSzy = inputSource;
				dCZEgzobTpHayGZtxUSftmjRvGe = unityJoystickId - 1;
				DJprzqfMnuGSAvTEGvUALAUDEVK = new string[6];
				uBqTsSHmiZaItJMnqvkCbRZZkqg();
				base.extension = new XboxOneGamepadExtension(supportsVibration: true, inputSource);
				_isConnected = isConnected;
				if (_isConnected)
				{
					iDBXctPcOcjjzWbKaCnxuPiVNUc(xboxControllerId);
				}
				else
				{
					kkzFHTjpMkjDWaJagBMQkbPOjuC = xboxControllerId;
				}
			}

			public virtual void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].value = JFLhhsViRZmASHFRAirmzVNMOhf(0);
					buttons[1].value = JFLhhsViRZmASHFRAirmzVNMOhf(1);
					buttons[2].value = JFLhhsViRZmASHFRAirmzVNMOhf(2);
					buttons[3].value = JFLhhsViRZmASHFRAirmzVNMOhf(3);
					buttons[4].value = JFLhhsViRZmASHFRAirmzVNMOhf(4);
					buttons[5].value = JFLhhsViRZmASHFRAirmzVNMOhf(5);
					buttons[6].value = JFLhhsViRZmASHFRAirmzVNMOhf(6);
					buttons[7].value = JFLhhsViRZmASHFRAirmzVNMOhf(7);
					buttons[8].value = JFLhhsViRZmASHFRAirmzVNMOhf(8);
					buttons[9].value = JFLhhsViRZmASHFRAirmzVNMOhf(9);
					buttons[10].value = JFLhhsViRZmASHFRAirmzVNMOhf(12);
					buttons[11].value = JFLhhsViRZmASHFRAirmzVNMOhf(15);
					buttons[12].value = JFLhhsViRZmASHFRAirmzVNMOhf(13);
					buttons[13].value = JFLhhsViRZmASHFRAirmzVNMOhf(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(DJprzqfMnuGSAvTEGvUALAUDEVK[0]);
					axes[1].value = Input.GetAxisRaw(DJprzqfMnuGSAvTEGvUALAUDEVK[1]);
					axes[2].value = Input.GetAxisRaw(DJprzqfMnuGSAvTEGvUALAUDEVK[2]);
					axes[3].value = Input.GetAxisRaw(DJprzqfMnuGSAvTEGvUALAUDEVK[3]);
					axes[4].value = Input.GetAxisRaw(DJprzqfMnuGSAvTEGvUALAUDEVK[4]);
					axes[5].value = Input.GetAxisRaw(DJprzqfMnuGSAvTEGvUALAUDEVK[5]);
				}
			}

			public void iDBXctPcOcjjzWbKaCnxuPiVNUc(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					kkzFHTjpMkjDWaJagBMQkbPOjuC = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						DHMxZDCyFTvxNsqfBoMSdIXkFSHe();
					}
				}
			}

			private void DHMxZDCyFTvxNsqfBoMSdIXkFSHe()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(kkzFHTjpMkjDWaJagBMQkbPOjuC);
				}
				_customName = "Controller " + base.unityId;
			}

			private bool JFLhhsViRZmASHFRAirmzVNMOhf(int P_0)
			{
				int key = 350 + P_0 + dCZEgzobTpHayGZtxUSftmjRvGe * 20;
				return Input.GetKey((KeyCode)key);
			}

			private void uBqTsSHmiZaItJMnqvkCbRZZkqg()
			{
				DJprzqfMnuGSAvTEGvUALAUDEVK[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				DJprzqfMnuGSAvTEGvUALAUDEVK[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				DJprzqfMnuGSAvTEGvUALAUDEVK[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				DJprzqfMnuGSAvTEGvUALAUDEVK[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				DJprzqfMnuGSAvTEGvUALAUDEVK[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				DJprzqfMnuGSAvTEGvUALAUDEVK[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}
		}

		private const int cVdhkVaVAPtQCcBkTAJzdRagUpH = 8;

		private readonly bool iTMWkJzAQHobYymwbflfUznXqqe;

		private bool LIemNDGcNPYIOsCpkihRdmlNvwa;

		private Queue<FQJFkXvBKsegNmKHHurwdDPRKYr> yWeiJjsyuJaKgBlixKoskqxtzBO;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public override bool isReady => iTMWkJzAQHobYymwbflfUznXqqe;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				yWeiJjsyuJaKgBlixKoskqxtzBO = new Queue<FQJFkXvBKsegNmKHHurwdDPRKYr>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = OPIZRglKjXjjoIkUpeWmRPPLAth((uint)num, true, out badConnectionReason);
					ulong xboxControllerId = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new xUKyFxXfjzAbWAIfbohaJjLSxjpT(this, xboxControllerId, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += iXPDouJgBqtabBfKgxEgBtmzaveM;
				iTMWkJzAQHobYymwbflfUznXqqe = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe)
			{
				vAuJKuDRRhrSNPhUAvlBtaMwGHo();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void iXPDouJgBqtabBfKgxEgBtmzaveM(uint P_0, bool P_1)
		{
			if (!iTMWkJzAQHobYymwbflfUznXqqe)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (OPIZRglKjXjjoIkUpeWmRPPLAth(P_0, true, out var _))
				{
					UvPaMjThKNfUBklHuGnXegOnUIX(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				xUKyFxXfjzAbWAIfbohaJjLSxjpT xUKyFxXfjzAbWAIfbohaJjLSxjpT2 = GetJoysticks()[index] as xUKyFxXfjzAbWAIfbohaJjLSxjpT;
				xUKyFxXfjzAbWAIfbohaJjLSxjpT2.Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void UvPaMjThKNfUBklHuGnXegOnUIX(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			xUKyFxXfjzAbWAIfbohaJjLSxjpT xUKyFxXfjzAbWAIfbohaJjLSxjpT2 = GetJoysticks()[index] as xUKyFxXfjzAbWAIfbohaJjLSxjpT;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			xUKyFxXfjzAbWAIfbohaJjLSxjpT2.iDBXctPcOcjjzWbKaCnxuPiVNUc(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void vAuJKuDRRhrSNPhUAvlBtaMwGHo()
		{
			int num = yWeiJjsyuJaKgBlixKoskqxtzBO.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				FQJFkXvBKsegNmKHHurwdDPRKYr item = yWeiJjsyuJaKgBlixKoskqxtzBO.Dequeue();
				if (currentFrame >= item.lexFucujcRyyCQNTPNjWxbooiAB + 1)
				{
					if (OPIZRglKjXjjoIkUpeWmRPPLAth(item.CKFiVsSuUhzmBIWNiuZfIACGvL, true, out var _))
					{
						UvPaMjThKNfUBklHuGnXegOnUIX(item.CKFiVsSuUhzmBIWNiuZfIACGvL, false);
						flag = true;
					}
				}
				else
				{
					yWeiJjsyuJaKgBlixKoskqxtzBO.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool OPIZRglKjXjjoIkUpeWmRPPLAth(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					yWeiJjsyuJaKgBlixKoskqxtzBO.Enqueue(new FQJFkXvBKsegNmKHHurwdDPRKYr(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void ILXnFJayojfLoutmQKfxrFiegbK()
		{
			if (!LIemNDGcNPYIOsCpkihRdmlNvwa)
			{
				LIemNDGcNPYIOsCpkihRdmlNvwa = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!iTMWkJzAQHobYymwbflfUznXqqe)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (iTMWkJzAQHobYymwbflfUznXqqe)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, PTwkXEwshTTlutazpmTDEohBwzi vibration)
		{
			if (!iTMWkJzAQHobYymwbflfUznXqqe)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.puceKrRUGBErqiVMCwppzwpRjqTf, vibration.vxkobSKBkcBUtCRJJqCIkpCuzxH, vibration.jaJiGacwlrqHibbqpcmmFARfBpbh, vibration.ufAhusuFicIPpijaSRFDChWgqhTK);
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= iXPDouJgBqtabBfKgxEgBtmzaveM;
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
