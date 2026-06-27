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

		private struct cQqubCkGMcxLLXMgYxYDsgvZffXhA
		{
			public uint YVMLVDWosvczYCHNRPZvIxJRFSymA;

			public uint UQmBKabPJRHOMLSKTtKaOoXkVsWI;

			public cQqubCkGMcxLLXMgYxYDsgvZffXhA(uint P_0, uint P_1)
			{
				YVMLVDWosvczYCHNRPZvIxJRFSymA = P_0;
				UQmBKabPJRHOMLSKTtKaOoXkVsWI = P_1;
			}
		}

		private class CmpzRoIcmhOFYlESuTyVefvYUKNF : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int fqGiiATfIkNmheAqUgcifYYPxPts = 6;

			private const int bVbLqjorcXpJaVgJiNFoQPSDVsKP = 14;

			private const string HaOUaFHeYlBkrKSGCcOKidudCBDKB = "Xbox One Controller";

			private const string mghXDALdOXhYymiLqymBUINNgQnT = "Controller";

			private const int bczxOaGrRGuKvLcdMKSftDSWDSyr = 0;

			private const int UlvGdIdWTzxmAmvOSglCWpgNRsSg = 1;

			private const int pbGfILAnYkDrgAOwdkZrBvsObVQhb = 2;

			private const int nPfbYgQSvnFbJEEuqdTcEjVxvBSt = 3;

			private const int lrodAMREzITrLNhkVBgmjunHoKaBb = 4;

			private const int bpeuJaaliRmuSXYhaPrLnxxWdpFo = 5;

			private const int seBlGFLOZyorbFhxokLwwynvsmOJ = 6;

			private const int arXcsjDEMbNAiGqBdguYFhrmdLPmB = 7;

			private const int oontAFChqiMtvdDUkUDZMkXMaOXP = 8;

			private const int YWXvZDvqSsbdliFEgWttNRSquspQ = 9;

			private const int ZGWycUuzsmBgGgbeAJDZuTtTUZgw = 12;

			private const int sZVHNRbHkDXpVtwBoHyNAymkvGgJ = 13;

			private const int XkKpngLJKlSoDXcqGJtJTADdKbQL = 14;

			private const int SSrmfCmeqXptIQVWbDPacnCGFImp = 15;

			private const int MYQdNBHHANmIIreEjYrkrPrKGNHo = 0;

			private const int RgbavicCCIUJCgaRnoMbVlOMHoBdb = 1;

			private const int JhztJLlgMEvXwyFmBMlpuQblZfak = 3;

			private const int dwpnkGatTRsyEEDnoxCbpBPXDspf = 4;

			private const int nDAMpqMLgkIjEAkapeqFoROaAfUEb = 8;

			private const int jAcHAqSRRalHxitQQqomHkYHUjiw = 9;

			private readonly IXboxOneInputSource JhxgliDTklUBbitRLiPvKnlwsBpi;

			private int uNUQDDEyeVjIkSCCMOSyhaMmAywL;

			private ulong LiDGQkAwYfeaLCKZBbjseTuXBqwP;

			private string[] aAzVSHoPYYkJZUBXCcPZikbAqqBg;

			private HardwareJoystickMap_InputManager nAYvISHHklBQIofLbVNOzMpzCndiA;

			private readonly LocalizedString WLveBlaMIluPgsfzqEiaoztvUIBsA;

			public ulong DVrOFOnPUupZHtylyCNmOHUPMbTk => LiDGQkAwYfeaLCKZBbjseTuXBqwP;

			public CmpzRoIcmhOFYlESuTyVefvYUKNF(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				JhxgliDTklUBbitRLiPvKnlwsBpi = P_0;
				uNUQDDEyeVjIkSCCMOSyhaMmAywL = P_2 - 1;
				aAzVSHoPYYkJZUBXCcPZikbAqqBg = new string[6];
				illJfLUOlqOwliATpzcyBQtFARUhA();
				WLveBlaMIluPgsfzqEiaoztvUIBsA = new LocalizedString();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					dkiUqzhQCZESmDjasFDEeJrEugNkA(P_1);
				}
				else
				{
					LiDGQkAwYfeaLCKZBbjseTuXBqwP = P_1;
				}
			}

			public virtual void LoxAAmeWKPtXmIqpDYXIQWxmwnEHA()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(0);
					buttons[1].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(1);
					buttons[2].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(2);
					buttons[3].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(3);
					buttons[4].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(4);
					buttons[5].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(5);
					buttons[6].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(6);
					buttons[7].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(7);
					buttons[8].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(8);
					buttons[9].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(9);
					buttons[10].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(12);
					buttons[11].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(15);
					buttons[12].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(13);
					buttons[13].boolValue = nXUNmBBFyWLTJkreaduUTkDRtpWo(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(aAzVSHoPYYkJZUBXCcPZikbAqqBg[0]);
					axes[1].value = Input.GetAxisRaw(aAzVSHoPYYkJZUBXCcPZikbAqqBg[1]);
					axes[2].value = Input.GetAxisRaw(aAzVSHoPYYkJZUBXCcPZikbAqqBg[2]);
					axes[3].value = Input.GetAxisRaw(aAzVSHoPYYkJZUBXCcPZikbAqqBg[3]);
					axes[4].value = Input.GetAxisRaw(aAzVSHoPYYkJZUBXCcPZikbAqqBg[4]);
					axes[5].value = Input.GetAxisRaw(aAzVSHoPYYkJZUBXCcPZikbAqqBg[5]);
				}
			}

			public void dkiUqzhQCZESmDjasFDEeJrEugNkA(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					LiDGQkAwYfeaLCKZBbjseTuXBqwP = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						gzJWAbpdHqqzjwfjDoSHeNNbbvER();
					}
				}
			}

			private void gzJWAbpdHqqzjwfjDoSHeNNbbvER()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(LiDGQkAwYfeaLCKZBbjseTuXBqwP);
				}
				_customName = string.Format("{0} {1}", "Controller", base.unityId);
				WLveBlaMIluPgsfzqEiaoztvUIBsA.Clear();
			}

			private bool nXUNmBBFyWLTJkreaduUTkDRtpWo(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + uNUQDDEyeVjIkSCCMOSyhaMmAywL * 20));
			}

			private void illJfLUOlqOwliATpzcyBQtFARUhA()
			{
				aAzVSHoPYYkJZUBXCcPZikbAqqBg[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				aAzVSHoPYYkJZUBXCcPZikbAqqBg[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				aAzVSHoPYYkJZUBXCcPZikbAqqBg[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				aAzVSHoPYYkJZUBXCcPZikbAqqBg[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				aAzVSHoPYYkJZUBXCcPZikbAqqBg[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				aAzVSHoPYYkJZUBXCcPZikbAqqBg[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}

			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
			{
				nAYvISHHklBQIofLbVNOzMpzCndiA = hardwareMap;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (nAYvISHHklBQIofLbVNOzMpzCndiA == null)
				{
					value = null;
					return false;
				}
				if ((LocalizationManager.GetAndUpdateLocalizedString(WLveBlaMIluPgsfzqEiaoztvUIBsA, nAYvISHHklBQIofLbVNOzMpzCndiA.deviceLocalizationInfo.parentKeys, "controller", "Controller", out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
				{
					value = $"{value} {base.unityId}";
					WLveBlaMIluPgsfzqEiaoztvUIBsA.cachedValue = value;
				}
				return true;
			}
		}

		private const int rwrAQDRHNQQCPTivFNbFpHJpMdGb = 8;

		private readonly bool WKXbyFiaVzSXYqLevvqtnARMmTLvA;

		private bool pMxWCEnbemUrRujqWGSUzmQRKsfu;

		private Queue<cQqubCkGMcxLLXMgYxYDsgvZffXhA> iiAEAbSsnZSOUsKUFdPmNkjTFhmEA;

		private bool sYxKrdETovRUAJkjqwMMOLtXqEhp;

		bool CustomInputSource.isReady => WKXbyFiaVzSXYqLevvqtnARMmTLvA;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				iiAEAbSsnZSOUsKUFdPmNkjTFhmEA = new Queue<cQqubCkGMcxLLXMgYxYDsgvZffXhA>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = mhpKQVrxeVEUhvKRVDfOseEtkDOJ((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new CmpzRoIcmhOFYlESuTyVefvYUKNF(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += ucNiAcOpUEUbJLqhuVuzgGHQeeFgA;
				WKXbyFiaVzSXYqLevvqtnARMmTLvA = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (WKXbyFiaVzSXYqLevvqtnARMmTLvA)
			{
				tLLIKCsOJnkncvDFDpVBwtbLtbKr();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void ucNiAcOpUEUbJLqhuVuzgGHQeeFgA(uint P_0, bool P_1)
		{
			if (!WKXbyFiaVzSXYqLevvqtnARMmTLvA)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (mhpKQVrxeVEUhvKRVDfOseEtkDOJ(P_0, true, out var _))
				{
					utvCeIOAGRERSFbfNQwWCsSKjsHlb(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as CmpzRoIcmhOFYlESuTyVefvYUKNF).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void utvCeIOAGRERSFbfNQwWCsSKjsHlb(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			CmpzRoIcmhOFYlESuTyVefvYUKNF obj = GetJoysticks()[index] as CmpzRoIcmhOFYlESuTyVefvYUKNF;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.dkiUqzhQCZESmDjasFDEeJrEugNkA(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void tLLIKCsOJnkncvDFDpVBwtbLtbKr()
		{
			int num = iiAEAbSsnZSOUsKUFdPmNkjTFhmEA.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				cQqubCkGMcxLLXMgYxYDsgvZffXhA item = iiAEAbSsnZSOUsKUFdPmNkjTFhmEA.Dequeue();
				if (currentFrame >= item.UQmBKabPJRHOMLSKTtKaOoXkVsWI + 1)
				{
					if (mhpKQVrxeVEUhvKRVDfOseEtkDOJ(item.YVMLVDWosvczYCHNRPZvIxJRFSymA, true, out var _))
					{
						utvCeIOAGRERSFbfNQwWCsSKjsHlb(item.YVMLVDWosvczYCHNRPZvIxJRFSymA, false);
						flag = true;
					}
				}
				else
				{
					iiAEAbSsnZSOUsKUFdPmNkjTFhmEA.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool mhpKQVrxeVEUhvKRVDfOseEtkDOJ(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					iiAEAbSsnZSOUsKUFdPmNkjTFhmEA.Enqueue(new cQqubCkGMcxLLXMgYxYDsgvZffXhA(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void ZGqEtkGttJJhPXvfOWxZbcWZWTGaA()
		{
			if (!pMxWCEnbemUrRujqWGSUzmQRKsfu)
			{
				pMxWCEnbemUrRujqWGSUzmQRKsfu = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!WKXbyFiaVzSXYqLevvqtnARMmTLvA)
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
			if (WKXbyFiaVzSXYqLevvqtnARMmTLvA)
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

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, yNLniFhzsLYZmKMWkhKgLEHXMCSk vibration)
		{
			if (!WKXbyFiaVzSXYqLevvqtnARMmTLvA)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.iCrNVIiOZwKXKjELknTunTyJvTgh, vibration.boxZMiGLtgltLtpvZJfHNwFvucWc, vibration.noPDJfaAqhjyBpJKgtVhidaOISrP, vibration.BMEPmFFAWXEgneYJnPyVuURYsOlH);
		}

		bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, yNLniFhzsLYZmKMWkhKgLEHXMCSk vibration)
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
			if (!sYxKrdETovRUAJkjqwMMOLtXqEhp)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= ucNiAcOpUEUbJLqhuVuzgGHQeeFgA;
				}
				sYxKrdETovRUAJkjqwMMOLtXqEhp = true;
			}
		}
	}
}
