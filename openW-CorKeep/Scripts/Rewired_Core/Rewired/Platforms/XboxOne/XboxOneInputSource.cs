using System;
using System.Collections.Generic;
using Rewired.Internal;
using Rewired.Internal.Localization;
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

		private struct blVfVCFedeHjGCyUyJuqYDsNfAiY
		{
			public uint BHzLXfnTHnPVVObFxvMFXQPJnXOb;

			public uint BRDFTaiIcXkpPUEiboTPVoKydmrqA;

			public blVfVCFedeHjGCyUyJuqYDsNfAiY(uint P_0, uint P_1)
			{
				BHzLXfnTHnPVVObFxvMFXQPJnXOb = P_0;
				BRDFTaiIcXkpPUEiboTPVoKydmrqA = P_1;
			}
		}

		private class TmUHherJBzemDuWyCZnaCSqAxVmL : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int qnlyQQafOwMdofOCyYLLqTgJslIE = 6;

			private const int oiYyhBFJlZvfgKdtWhVRyVPJJbiB = 14;

			private const string WizoiJwarfaKkXUwkTidXJlEikahA = "Xbox One Controller";

			private const string xRCFNUoozXIHxzFnIvIkyEIRsxKq = "Controller";

			private const int ufSBtiKrwUOOujORgFkMgLVhWrTKb = 0;

			private const int LPEESKhKotSHNItgkBOpyetRgspxA = 1;

			private const int qMhOxFGNjaZZxBRKEpPAHAxrDgbv = 2;

			private const int gtMcvuDvIrphYvDYCnfZisIlfotfb = 3;

			private const int mWZwAKcmKWfHEKgAhASHJQkVNpBHb = 4;

			private const int inVAFgDEBZpSBUPJMoFqTUySdMgR = 5;

			private const int zAsKDwkyGaAyiMDvUCNJCoEvXvub = 6;

			private const int jpyyxxnEtbySdtYbEKQtVxunymyH = 7;

			private const int vYIQGPhaByFBeeLuKhhsgMUQapuy = 8;

			private const int PlmbDZEibuBXsztqGjPEpuRmuTOW = 9;

			private const int OvzbyCFjBkbQZvhKmihkWwuXUePs = 12;

			private const int zkkZqZOiHNNKGkRnOKUuqjpyQfDI = 13;

			private const int QZfgnqmxdfNgWEyWylpgxIUfDjbZ = 14;

			private const int HFSvQxRVSZRHlZeJHpFjSZoQzVdc = 15;

			private const int PedzBVgLjNpoDkeuXUDDBEmEtmgu = 0;

			private const int KBSzlcvwlIheNfglXimGVlBUAVcAA = 1;

			private const int GXGInLOldGVWnpZWpuqIOtyzguHI = 3;

			private const int mHWjfAVoAFmUFZkrKDJYBuOBAyWv = 4;

			private const int yAhtvajCJsZcZdWEXAdohBZeEGjN = 8;

			private const int yINCViduzcxdcbaneAgLbAFVOONl = 9;

			private readonly IXboxOneInputSource UuEaaautBtzuqjNrneIEmLgqCBGy;

			private int zUtDMNJtVPjTvCNigogVSNPlsPFac;

			private ulong AQwSoovrBxEAIZJrbNpNUdRZJZLE;

			private string[] tcOHTLdRpWyGMCBzyxGmlMkYSTcPA;

			private HardwareJoystickMap_InputManager qHxKEOgDDlgQVfvnFbQfBDqpeKYM;

			private readonly LocalizedString JvENDvplbtrbpyYTYAfTPBcfBpun;

			public ulong YoOLGGAnDslQEuPjOsITmfXBrCwl => AQwSoovrBxEAIZJrbNpNUdRZJZLE;

			public TmUHherJBzemDuWyCZnaCSqAxVmL(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				UuEaaautBtzuqjNrneIEmLgqCBGy = P_0;
				zUtDMNJtVPjTvCNigogVSNPlsPFac = P_2 - 1;
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA = new string[6];
				lUUrfBvKQyCgqjctFSNBvKaVejvh();
				JvENDvplbtrbpyYTYAfTPBcfBpun = new LocalizedString();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					syLwLxSXtXystKIIMdtddLyGRaqf(P_1);
				}
				else
				{
					AQwSoovrBxEAIZJrbNpNUdRZJZLE = P_1;
				}
			}

			public virtual void AYQYDytttNhebpvBjxJfuQemEwxf()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(0);
					buttons[1].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(1);
					buttons[2].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(2);
					buttons[3].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(3);
					buttons[4].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(4);
					buttons[5].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(5);
					buttons[6].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(6);
					buttons[7].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(7);
					buttons[8].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(8);
					buttons[9].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(9);
					buttons[10].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(12);
					buttons[11].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(15);
					buttons[12].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(13);
					buttons[13].boolValue = citgcRcXMMlCVfWHIWcbbGTZIOld(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[0]);
					axes[1].value = Input.GetAxisRaw(tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[1]);
					axes[2].value = Input.GetAxisRaw(tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[2]);
					axes[3].value = Input.GetAxisRaw(tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[3]);
					axes[4].value = Input.GetAxisRaw(tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[4]);
					axes[5].value = Input.GetAxisRaw(tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[5]);
				}
			}

			public void syLwLxSXtXystKIIMdtddLyGRaqf(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					AQwSoovrBxEAIZJrbNpNUdRZJZLE = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						nJycAjGlcgJXsnhJxCwaGqOpAWdo();
					}
				}
			}

			private void nJycAjGlcgJXsnhJxCwaGqOpAWdo()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(AQwSoovrBxEAIZJrbNpNUdRZJZLE);
				}
				_customName = string.Format("{0} {1}", "Controller", base.unityId);
				JvENDvplbtrbpyYTYAfTPBcfBpun.Clear();
			}

			private bool citgcRcXMMlCVfWHIWcbbGTZIOld(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + zUtDMNJtVPjTvCNigogVSNPlsPFac * 20));
			}

			private void lUUrfBvKQyCgqjctFSNBvKaVejvh()
			{
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				tcOHTLdRpWyGMCBzyxGmlMkYSTcPA[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}

			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
			{
				qHxKEOgDDlgQVfvnFbQfBDqpeKYM = hardwareMap;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (qHxKEOgDDlgQVfvnFbQfBDqpeKYM == null)
				{
					value = null;
					return false;
				}
				if ((LocalizationManager.GetAndUpdateLocalizedString(JvENDvplbtrbpyYTYAfTPBcfBpun, qHxKEOgDDlgQVfvnFbQfBDqpeKYM.deviceLocalizationInfo.parentKeys, "controller", "Controller", out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
				{
					value = $"{value} {base.unityId}";
					JvENDvplbtrbpyYTYAfTPBcfBpun.cachedValue = value;
				}
				return true;
			}
		}

		private const int wORoKGccwVTcBQTWTPtWXRQVtvGP = 8;

		private readonly bool ZwwyfFVnilnyJIeYBUTYgiEAcwkj;

		private bool sTUKLEGYNuVMKjEAiKwjDMTNKVCQ;

		private Queue<blVfVCFedeHjGCyUyJuqYDsNfAiY> zwtKLjbEOBemVtukjxBPbcmJYbHm;

		private bool hUBjhzWTrTwRKcJWhwjecmXnfAWA;

		bool CustomInputSource.isReady => ZwwyfFVnilnyJIeYBUTYgiEAcwkj;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				zwtKLjbEOBemVtukjxBPbcmJYbHm = new Queue<blVfVCFedeHjGCyUyJuqYDsNfAiY>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = juYSYXEqLPwtusGytBzvSpFxCVns((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new TmUHherJBzemDuWyCZnaCSqAxVmL(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += fckEtkzvKABGCAPtMIKCKGUQDIwD;
				ZwwyfFVnilnyJIeYBUTYgiEAcwkj = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (ZwwyfFVnilnyJIeYBUTYgiEAcwkj)
			{
				iueCaEXoxjJhfmfpjlxqAHgTYVxi();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void fckEtkzvKABGCAPtMIKCKGUQDIwD(uint P_0, bool P_1)
		{
			if (!ZwwyfFVnilnyJIeYBUTYgiEAcwkj)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (juYSYXEqLPwtusGytBzvSpFxCVns(P_0, true, out var _))
				{
					pIYzuQjgfJVvJoUDfwOtOzRvUZmR(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as TmUHherJBzemDuWyCZnaCSqAxVmL).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void pIYzuQjgfJVvJoUDfwOtOzRvUZmR(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			TmUHherJBzemDuWyCZnaCSqAxVmL obj = GetJoysticks()[index] as TmUHherJBzemDuWyCZnaCSqAxVmL;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.syLwLxSXtXystKIIMdtddLyGRaqf(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void iueCaEXoxjJhfmfpjlxqAHgTYVxi()
		{
			int num = zwtKLjbEOBemVtukjxBPbcmJYbHm.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				blVfVCFedeHjGCyUyJuqYDsNfAiY item = zwtKLjbEOBemVtukjxBPbcmJYbHm.Dequeue();
				if (currentFrame >= item.BRDFTaiIcXkpPUEiboTPVoKydmrqA + 1)
				{
					if (juYSYXEqLPwtusGytBzvSpFxCVns(item.BHzLXfnTHnPVVObFxvMFXQPJnXOb, true, out var _))
					{
						pIYzuQjgfJVvJoUDfwOtOzRvUZmR(item.BHzLXfnTHnPVVObFxvMFXQPJnXOb, false);
						flag = true;
					}
				}
				else
				{
					zwtKLjbEOBemVtukjxBPbcmJYbHm.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool juYSYXEqLPwtusGytBzvSpFxCVns(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					zwtKLjbEOBemVtukjxBPbcmJYbHm.Enqueue(new blVfVCFedeHjGCyUyJuqYDsNfAiY(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void UZRrWyItOPJMQuJDyReuYIFRgZdf()
		{
			if (!sTUKLEGYNuVMKjEAiKwjDMTNKVCQ)
			{
				sTUKLEGYNuVMKjEAiKwjDMTNKVCQ = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!ZwwyfFVnilnyJIeYBUTYgiEAcwkj)
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
			if (ZwwyfFVnilnyJIeYBUTYgiEAcwkj)
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

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, poqVdBSaRLeupdLkAXXVBdSVpptwA vibration)
		{
			if (!ZwwyfFVnilnyJIeYBUTYgiEAcwkj)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.bEOhLSHRqiJuLektSoDLUZlXkOZQA, vibration.cPChLwbpiiZBIuQBlJvAxqpxDPLO, vibration.qnevNxPtBhgAOqRuMKBWKBbQvtEY, vibration.OphWZZchpFiQqdMfPAIcGtIQDLQaA);
		}

		bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, poqVdBSaRLeupdLkAXXVBdSVpptwA vibration)
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
			if (!hUBjhzWTrTwRKcJWhwjecmXnfAWA)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= fckEtkzvKABGCAPtMIKCKGUQDIwD;
				}
				hUBjhzWTrTwRKcJWhwjecmXnfAWA = true;
			}
		}
	}
}
