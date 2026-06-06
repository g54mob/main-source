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

		private struct nMLrJWvFgmbFqjcsdlwFFiQsLbae
		{
			public uint PNdCNEZylzVJbnFRaUkrMDQqSsJS;

			public uint VmViJpoCAFznbrSSkrSctdQRvpjS;

			public nMLrJWvFgmbFqjcsdlwFFiQsLbae(uint P_0, uint P_1)
			{
				PNdCNEZylzVJbnFRaUkrMDQqSsJS = P_0;
				VmViJpoCAFznbrSSkrSctdQRvpjS = P_1;
			}
		}

		private class VrAFvdEPbhoqxcBYVKcBcPwbFoiyA : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int gsvqFRSLDwSxKAgapNhgzaBgetWM = 6;

			private const int gNUduydUpHMbHdqFFPwefKTwLUzW = 14;

			private const string CCvkiSCDYjWHCwKNhtIOKDrvpwsj = "Xbox One Controller";

			private const string fYSCTDkURHwZDCsJVHHTvSKycsCBA = "Controller";

			private const int gbGJnbDSSSPOEnofpnzvOMZbqwNM = 0;

			private const int BQWjIRyWQzWXdMSOlrDCrQlmnxtN = 1;

			private const int wInYHCgbLqLNHmNmVcopKCdEGfhu = 2;

			private const int aoWEhfFiwdetgfkwPKkqubKIVtdUA = 3;

			private const int wRRlIDSKgCUZunSaiNBqDboceqPJA = 4;

			private const int iNDFevhzaLSjnnCpHGwZSHqnZemI = 5;

			private const int lZyCOCWxMkBUMxehLLHiJDgWSIpo = 6;

			private const int nSsgGsZeVpidNUhXNhPYWDwCQtiv = 7;

			private const int dUEKhYNzwwJhODIlTaVPxCspkskd = 8;

			private const int XEoRSKaZPgZUHGOsBQfDgNULEQSc = 9;

			private const int WhYcHsxrqsKhRUatecNbZgmhxHBb = 12;

			private const int liqRhAexjXXWyPBPRHvVrsvJTfBJ = 13;

			private const int EyfbplhCVtYwchpmxhaPGkWhKyvuB = 14;

			private const int NKYBbHfLdRaFvisAEDwyTbDdPkLw = 15;

			private const int ZfplJUGnTTdqhJVUAJUoWamtVpav = 0;

			private const int YYElTjLkNUxQpElPWhYhEuDhGlwi = 1;

			private const int YBYdvUbePGvLZwKmkOxzjDyQDzJSA = 3;

			private const int cNGcdZzWwDyMfwHRVQIlIrEqAbQw = 4;

			private const int wEpdavLMlkHqdMvgGNZFkTVZTipH = 8;

			private const int igNQxbHoEqhZWIYRpFGuaHLeROTk = 9;

			private readonly IXboxOneInputSource GwKHcdMIlnnmCGbRsqJndfePrYKU;

			private int hOxDOEPpfLSHLkmCfZdcEABXzAZV;

			private ulong QueOshZTXfMxwiIPqKhmHjpkKAHi;

			private string[] bcAiLSfRPUbYwwJJleHFTHufLUwp;

			private HardwareJoystickMap_InputManager idlQeZAjNngmlOXNEmgKGdcMLxCJ;

			private readonly LocalizedString LxKZXcRNxjpfRPvWPFNmWcyEolaE;

			public ulong CoYDTFqbZudmqRxzFteerdTigMsJ => QueOshZTXfMxwiIPqKhmHjpkKAHi;

			public VrAFvdEPbhoqxcBYVKcBcPwbFoiyA(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				GwKHcdMIlnnmCGbRsqJndfePrYKU = P_0;
				hOxDOEPpfLSHLkmCfZdcEABXzAZV = P_2 - 1;
				bcAiLSfRPUbYwwJJleHFTHufLUwp = new string[6];
				nSApYWJsEiQjGUiVMDlakaqmpzbG();
				LxKZXcRNxjpfRPvWPFNmWcyEolaE = new LocalizedString();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					ysZccwmXZPoRonuDFaeQwaSzCoqD(P_1);
				}
				else
				{
					QueOshZTXfMxwiIPqKhmHjpkKAHi = P_1;
				}
			}

			public virtual void IuCAMxFhBVtPTMMzcaACrSeVZFpI()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(0);
					buttons[1].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(1);
					buttons[2].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(2);
					buttons[3].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(3);
					buttons[4].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(4);
					buttons[5].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(5);
					buttons[6].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(6);
					buttons[7].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(7);
					buttons[8].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(8);
					buttons[9].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(9);
					buttons[10].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(12);
					buttons[11].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(15);
					buttons[12].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(13);
					buttons[13].boolValue = qgbbiMQklKbfeQuqDBZAeDSwCJpFA(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(bcAiLSfRPUbYwwJJleHFTHufLUwp[0]);
					axes[1].value = Input.GetAxisRaw(bcAiLSfRPUbYwwJJleHFTHufLUwp[1]);
					axes[2].value = Input.GetAxisRaw(bcAiLSfRPUbYwwJJleHFTHufLUwp[2]);
					axes[3].value = Input.GetAxisRaw(bcAiLSfRPUbYwwJJleHFTHufLUwp[3]);
					axes[4].value = Input.GetAxisRaw(bcAiLSfRPUbYwwJJleHFTHufLUwp[4]);
					axes[5].value = Input.GetAxisRaw(bcAiLSfRPUbYwwJJleHFTHufLUwp[5]);
				}
			}

			public void ysZccwmXZPoRonuDFaeQwaSzCoqD(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					QueOshZTXfMxwiIPqKhmHjpkKAHi = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						hEcAuOkOioBCASdQonFYNWUQLhUB();
					}
				}
			}

			private void hEcAuOkOioBCASdQonFYNWUQLhUB()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(QueOshZTXfMxwiIPqKhmHjpkKAHi);
				}
				_customName = string.Format("{0} {1}", "Controller", base.unityId);
				LxKZXcRNxjpfRPvWPFNmWcyEolaE.Clear();
			}

			private bool qgbbiMQklKbfeQuqDBZAeDSwCJpFA(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + hOxDOEPpfLSHLkmCfZdcEABXzAZV * 20));
			}

			private void nSApYWJsEiQjGUiVMDlakaqmpzbG()
			{
				bcAiLSfRPUbYwwJJleHFTHufLUwp[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				bcAiLSfRPUbYwwJJleHFTHufLUwp[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				bcAiLSfRPUbYwwJJleHFTHufLUwp[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				bcAiLSfRPUbYwwJJleHFTHufLUwp[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				bcAiLSfRPUbYwwJJleHFTHufLUwp[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				bcAiLSfRPUbYwwJJleHFTHufLUwp[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}

			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
			{
				idlQeZAjNngmlOXNEmgKGdcMLxCJ = hardwareMap;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (idlQeZAjNngmlOXNEmgKGdcMLxCJ == null)
				{
					value = null;
					return false;
				}
				if ((LocalizationManager.GetAndUpdateLocalizedString(LxKZXcRNxjpfRPvWPFNmWcyEolaE, idlQeZAjNngmlOXNEmgKGdcMLxCJ.deviceLocalizationInfo.parentKeys, "controller", "Controller", out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
				{
					value = $"{value} {base.unityId}";
					LxKZXcRNxjpfRPvWPFNmWcyEolaE.cachedValue = value;
				}
				return true;
			}
		}

		private const int mTHZYFWPGPJerfHaKhwlAwQcVwKr = 8;

		private readonly bool NTyunCtbGnzGxrpwOZpzxMKtrwkC;

		private bool uVUYJmojFwNggMyRxpWLQRpwIKxB;

		private Queue<nMLrJWvFgmbFqjcsdlwFFiQsLbae> nTrOZaRrgBaUdOnIguJkuqqaJRFi;

		private bool nECdvkJxrzwijhwnHVrEpZassgQw;

		bool CustomInputSource.isReady => NTyunCtbGnzGxrpwOZpzxMKtrwkC;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				nTrOZaRrgBaUdOnIguJkuqqaJRFi = new Queue<nMLrJWvFgmbFqjcsdlwFFiQsLbae>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = lwAPKQaCrXLqQPWWaByUTyBKFSlt((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new VrAFvdEPbhoqxcBYVKcBcPwbFoiyA(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += vAcSUdPLPAFachHnRJNpVdElGCkz;
				NTyunCtbGnzGxrpwOZpzxMKtrwkC = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (NTyunCtbGnzGxrpwOZpzxMKtrwkC)
			{
				iQqGeHtmMtJQRVqNeqaFRMwkFmrj();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void vAcSUdPLPAFachHnRJNpVdElGCkz(uint P_0, bool P_1)
		{
			if (!NTyunCtbGnzGxrpwOZpzxMKtrwkC)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (lwAPKQaCrXLqQPWWaByUTyBKFSlt(P_0, true, out var _))
				{
					dkAmmJNEVLFjhiFvkeBKIFXHUOsPb(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as VrAFvdEPbhoqxcBYVKcBcPwbFoiyA).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void dkAmmJNEVLFjhiFvkeBKIFXHUOsPb(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			VrAFvdEPbhoqxcBYVKcBcPwbFoiyA obj = GetJoysticks()[index] as VrAFvdEPbhoqxcBYVKcBcPwbFoiyA;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.ysZccwmXZPoRonuDFaeQwaSzCoqD(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void iQqGeHtmMtJQRVqNeqaFRMwkFmrj()
		{
			int num = nTrOZaRrgBaUdOnIguJkuqqaJRFi.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				nMLrJWvFgmbFqjcsdlwFFiQsLbae item = nTrOZaRrgBaUdOnIguJkuqqaJRFi.Dequeue();
				if (currentFrame >= item.VmViJpoCAFznbrSSkrSctdQRvpjS + 1)
				{
					if (lwAPKQaCrXLqQPWWaByUTyBKFSlt(item.PNdCNEZylzVJbnFRaUkrMDQqSsJS, true, out var _))
					{
						dkAmmJNEVLFjhiFvkeBKIFXHUOsPb(item.PNdCNEZylzVJbnFRaUkrMDQqSsJS, false);
						flag = true;
					}
				}
				else
				{
					nTrOZaRrgBaUdOnIguJkuqqaJRFi.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool lwAPKQaCrXLqQPWWaByUTyBKFSlt(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					nTrOZaRrgBaUdOnIguJkuqqaJRFi.Enqueue(new nMLrJWvFgmbFqjcsdlwFFiQsLbae(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void GCXzFxiGgBDMgVjrrECXDhFybJbj()
		{
			if (!uVUYJmojFwNggMyRxpWLQRpwIKxB)
			{
				uVUYJmojFwNggMyRxpWLQRpwIKxB = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!NTyunCtbGnzGxrpwOZpzxMKtrwkC)
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
			if (NTyunCtbGnzGxrpwOZpzxMKtrwkC)
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

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, nqksfUukzDEiLaSMNzYesOWcFujw vibration)
		{
			if (!NTyunCtbGnzGxrpwOZpzxMKtrwkC)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.jeShRHvcUevipPLBBhMsISnyTRTRA, vibration.kwYGRnFHWuvFyeFtyRydpubGPMRLA, vibration.eQgRXqzfrjqGsBKYDIMdLCjlIuAx, vibration.CRlQHOKRLHxOSIkFANHLFGKjTKAM);
		}

		bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, nqksfUukzDEiLaSMNzYesOWcFujw vibration)
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
			if (!nECdvkJxrzwijhwnHVrEpZassgQw)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= vAcSUdPLPAFachHnRJNpVdElGCkz;
				}
				nECdvkJxrzwijhwnHVrEpZassgQw = true;
			}
		}
	}
}
