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

		private struct UpMChzCWymvTUfABNAaHZRGBkfD
		{
			public uint uJPipuPamfASiUVOYPAWCrdOCcUp;

			public uint eBpkuBgiNVtcqWlPYGiBxrdtfrwM;

			public UpMChzCWymvTUfABNAaHZRGBkfD(uint P_0, uint P_1)
			{
				uJPipuPamfASiUVOYPAWCrdOCcUp = P_0;
				eBpkuBgiNVtcqWlPYGiBxrdtfrwM = P_1;
			}
		}

		private class aHwZIHHasvQzasyJvLCqXNTXFkzS : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			private const int BeDNMjSnMaPQPfbpJfhFhLoCWnJS = 6;

			private const int JKuXLOhbqZigWUFAtxYHtwiEUMaq = 14;

			private const string vFPNkjSMubZDJRXFVJtiQQDvbzxA = "Xbox One Controller";

			private const string QaocsdaUURPIYczObNnsZblUFqRGb = "Controller";

			private const int TMeGOVREFEpBHMoiTbBMQloJYyGT = 0;

			private const int oDsDvxqxTxOtmtzVJzxhhuEQxyaI = 1;

			private const int ZFHpsaafMySvSPflfMYUSPOezQqh = 2;

			private const int FAyMWFNJdjEkbHOpbbQNhPjahtiBA = 3;

			private const int HdtthjKytMoSnSfhOnlLHnHSXoIP = 4;

			private const int FvsATnsFBHAoGeepmRcSKZVVUni = 5;

			private const int SnUbKoOXNcPuFKnedtdTBSDiAfgH = 6;

			private const int SBOJcAXiKrdmMraOnvKjSVToxRjF = 7;

			private const int QqpditHeqaKZhuVhlKcgjfYJiznb = 8;

			private const int uCUcHscAVsWhDxZUxaHUiePzSBXC = 9;

			private const int ltRPrNhqBqFDuhxZLYiePNwGxuMC = 12;

			private const int GHWgViqVwFWuhuuIprLwjfIfjDQr = 13;

			private const int xzJGETGUWzdrrCUnZZGkKkbgIemSA = 14;

			private const int aiuSgbxXeJCFsXUTeQTLDgwJeXUj = 15;

			private const int yQPQsqKWELtlgyHNiOsNKoHVFhln = 0;

			private const int blaGUDDEHGyZovWlsFcMMhsNGPhL = 1;

			private const int zceGIigyEMVGCEhlCRJAcBToNdSFA = 3;

			private const int PqugCpkdfFVDsIHKrQoSpOpUpfXfA = 4;

			private const int RRHWvXRImyAawzmrspkgmgkdANgw = 8;

			private const int JJhdKZVpTsePJlwBZfFNkgsQBLQy = 9;

			private readonly IXboxOneInputSource jyuFBTCTkvvfDzKQMGxCxpLnhGTfA;

			private int YZBJreVeqTOAULmHJNNXUJqfdCIz;

			private ulong bXYnCJRqMfDvdNJGYkqPZVESYOQl;

			private string[] USwhuuxDICDLzhNOBDzixDZDNQbgb;

			private HardwareJoystickMap_InputManager PfRxfYGknvdysxGMsWfeILvkTLmc;

			private readonly LocalizedString ayquOEVEpviQtakgjvGJYRBmydxE;

			public ulong rdsbgtmJUiEcniwehLDDtzoIxstuA => bXYnCJRqMfDvdNJGYkqPZVESYOQl;

			public aHwZIHHasvQzasyJvLCqXNTXFkzS(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				jyuFBTCTkvvfDzKQMGxCxpLnhGTfA = P_0;
				YZBJreVeqTOAULmHJNNXUJqfdCIz = P_2 - 1;
				USwhuuxDICDLzhNOBDzixDZDNQbgb = new string[6];
				OSoIusXmloNHTlACwfbJqFTOGtehA();
				ayquOEVEpviQtakgjvGJYRBmydxE = new LocalizedString();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					ZbZHCgqGZchGBWxdPAfemXaRUbpc(P_1);
				}
				else
				{
					bXYnCJRqMfDvdNJGYkqPZVESYOQl = P_1;
				}
			}

			public virtual void huyjKHXYPHsbIvIwEESbhgVfVnaK()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(0);
					buttons[1].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(1);
					buttons[2].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(2);
					buttons[3].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(3);
					buttons[4].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(4);
					buttons[5].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(5);
					buttons[6].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(6);
					buttons[7].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(7);
					buttons[8].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(8);
					buttons[9].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(9);
					buttons[10].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(12);
					buttons[11].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(15);
					buttons[12].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(13);
					buttons[13].boolValue = NGVCTyYTgIRknzkxdKxzwofYMVuM(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(USwhuuxDICDLzhNOBDzixDZDNQbgb[0]);
					axes[1].value = Input.GetAxisRaw(USwhuuxDICDLzhNOBDzixDZDNQbgb[1]);
					axes[2].value = Input.GetAxisRaw(USwhuuxDICDLzhNOBDzixDZDNQbgb[2]);
					axes[3].value = Input.GetAxisRaw(USwhuuxDICDLzhNOBDzixDZDNQbgb[3]);
					axes[4].value = Input.GetAxisRaw(USwhuuxDICDLzhNOBDzixDZDNQbgb[4]);
					axes[5].value = Input.GetAxisRaw(USwhuuxDICDLzhNOBDzixDZDNQbgb[5]);
				}
			}

			public void ZbZHCgqGZchGBWxdPAfemXaRUbpc(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					bXYnCJRqMfDvdNJGYkqPZVESYOQl = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						QDInCMiHkgQkXvmhMXbcJrdaJbqG();
					}
				}
			}

			private void QDInCMiHkgQkXvmhMXbcJrdaJbqG()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(bXYnCJRqMfDvdNJGYkqPZVESYOQl);
				}
				_customName = string.Format("{0} {1}", "Controller", base.unityId);
				ayquOEVEpviQtakgjvGJYRBmydxE.Clear();
			}

			private bool NGVCTyYTgIRknzkxdKxzwofYMVuM(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + YZBJreVeqTOAULmHJNNXUJqfdCIz * 20));
			}

			private void OSoIusXmloNHTlACwfbJqFTOGtehA()
			{
				USwhuuxDICDLzhNOBDzixDZDNQbgb[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				USwhuuxDICDLzhNOBDzixDZDNQbgb[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				USwhuuxDICDLzhNOBDzixDZDNQbgb[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				USwhuuxDICDLzhNOBDzixDZDNQbgb[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				USwhuuxDICDLzhNOBDzixDZDNQbgb[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				USwhuuxDICDLzhNOBDzixDZDNQbgb[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}

			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
			{
				PfRxfYGknvdysxGMsWfeILvkTLmc = hardwareMap;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (PfRxfYGknvdysxGMsWfeILvkTLmc == null)
				{
					value = null;
					return false;
				}
				if ((LocalizationManager.GetAndUpdateLocalizedString(ayquOEVEpviQtakgjvGJYRBmydxE, PfRxfYGknvdysxGMsWfeILvkTLmc.deviceLocalizationInfo.parentKeys, "controller", "Controller", out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
				{
					value = $"{value} {base.unityId}";
					ayquOEVEpviQtakgjvGJYRBmydxE.cachedValue = value;
				}
				return true;
			}
		}

		private const int DIhujvMLTPXlqGrrkwMQGJbURuFu = 8;

		private readonly bool gPYDLczNmfuskCxXylNEhhrLjDxe;

		private bool PkMzzcemarKbElvHWLzyQuCWSXHA;

		private Queue<UpMChzCWymvTUfABNAaHZRGBkfD> IrDfiCXnjHvoqptRIStJcDBUHKWg;

		private bool KHwOVKZAshlreIHelHPlnnLImkJQ;

		bool CustomInputSource.isReady => gPYDLczNmfuskCxXylNEhhrLjDxe;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				IrDfiCXnjHvoqptRIStJcDBUHKWg = new Queue<UpMChzCWymvTUfABNAaHZRGBkfD>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = GZumzgynqTWbRyqRGzObDpqwjCap((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new aHwZIHHasvQzasyJvLCqXNTXFkzS(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += AkIbnLRMAOCkzCMejnzUPTdJSZjh;
				gPYDLczNmfuskCxXylNEhhrLjDxe = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (gPYDLczNmfuskCxXylNEhhrLjDxe)
			{
				TUEnAnrxPrKAGapCGUskDbHYXrkf();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void AkIbnLRMAOCkzCMejnzUPTdJSZjh(uint P_0, bool P_1)
		{
			if (!gPYDLczNmfuskCxXylNEhhrLjDxe)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (GZumzgynqTWbRyqRGzObDpqwjCap(P_0, true, out var _))
				{
					OLsqDnDXYBkOuqvoYhTxPreuObdi(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as aHwZIHHasvQzasyJvLCqXNTXFkzS).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void OLsqDnDXYBkOuqvoYhTxPreuObdi(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			aHwZIHHasvQzasyJvLCqXNTXFkzS obj = GetJoysticks()[index] as aHwZIHHasvQzasyJvLCqXNTXFkzS;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.ZbZHCgqGZchGBWxdPAfemXaRUbpc(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void TUEnAnrxPrKAGapCGUskDbHYXrkf()
		{
			int num = IrDfiCXnjHvoqptRIStJcDBUHKWg.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				UpMChzCWymvTUfABNAaHZRGBkfD item = IrDfiCXnjHvoqptRIStJcDBUHKWg.Dequeue();
				if (currentFrame >= item.eBpkuBgiNVtcqWlPYGiBxrdtfrwM + 1)
				{
					if (GZumzgynqTWbRyqRGzObDpqwjCap(item.uJPipuPamfASiUVOYPAWCrdOCcUp, true, out var _))
					{
						OLsqDnDXYBkOuqvoYhTxPreuObdi(item.uJPipuPamfASiUVOYPAWCrdOCcUp, false);
						flag = true;
					}
				}
				else
				{
					IrDfiCXnjHvoqptRIStJcDBUHKWg.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool GZumzgynqTWbRyqRGzObDpqwjCap(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					IrDfiCXnjHvoqptRIStJcDBUHKWg.Enqueue(new UpMChzCWymvTUfABNAaHZRGBkfD(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void zRtCdFcKrFCgryFsJcwsDeqKWpaN()
		{
			if (!PkMzzcemarKbElvHWLzyQuCWSXHA)
			{
				PkMzzcemarKbElvHWLzyQuCWSXHA = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!gPYDLczNmfuskCxXylNEhhrLjDxe)
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
			if (gPYDLczNmfuskCxXylNEhhrLjDxe)
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

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, KgGMEagteNevMTqZxNiFmnfMLmqQ vibration)
		{
			if (!gPYDLczNmfuskCxXylNEhhrLjDxe)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.CvwHglzUZuhzsoZOhImBUWMCQBQO, vibration.NiubcHdDBepKtIgmJISGleYgqCUoB, vibration.NfSnkUzCafbXlFqDvkoSyZOLbkXcA, vibration.vELleuCdIVXBPfpEqAfiTuxLSsLL);
		}

		bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, KgGMEagteNevMTqZxNiFmnfMLmqQ vibration)
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
			if (!KHwOVKZAshlreIHelHPlnnLImkJQ)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= AkIbnLRMAOCkzCMejnzUPTdJSZjh;
				}
				KHwOVKZAshlreIHelHPlnnLImkJQ = true;
			}
		}
	}
}
