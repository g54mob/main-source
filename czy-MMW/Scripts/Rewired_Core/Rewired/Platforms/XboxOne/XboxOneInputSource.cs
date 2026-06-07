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

		private struct jsUnuluBCtXDLPprIXEfsYBiEPLR
		{
			public uint FBaYEkYugoftYHcQJvXFvopkNism;

			public uint NLEQUJxFOYTJKRBDZdYGSlMPtxAC;

			public jsUnuluBCtXDLPprIXEfsYBiEPLR(uint P_0, uint P_1)
			{
				FBaYEkYugoftYHcQJvXFvopkNism = P_0;
				NLEQUJxFOYTJKRBDZdYGSlMPtxAC = P_1;
			}
		}

		private class TpTeITGUsuKSWjTDsFJxiLPnmmLJ : Joystick
		{
			private const int oUmElrhJUnAiremlFQwGPIyWszzqb = 6;

			private const int qABZjEeuyArHmVOEmqLYWYakhGGt = 14;

			private const string etbORVMsiQuOPHHzadqnhANrpXxf = "Xbox One Controller";

			private const int oXPymHQdJNwszRioSMkNbawvaWoe = 0;

			private const int XPBLcxdiDibJAkuDQcweQvKufDQk = 1;

			private const int owmFLslqYrVpyCvbgJPPlsAYbvGo = 2;

			private const int gkLyCNUetwRiTCIjuNeKGqbKhXCI = 3;

			private const int smYNntTdGPlJRRhhZqMzcXKyuixB = 4;

			private const int ysUoQPolqSvsOJEowBtthjLhRXNIA = 5;

			private const int ldrzHwRMXxFczEReoimIDqTDOIIBB = 6;

			private const int tTxkxMCXEmbYokOEaVkcvRVQLfTO = 7;

			private const int pjDRViAeqtEzlCbFeSRteAvhnqNMB = 8;

			private const int XutmSaxdEtDdxacNotxTRjsHcEjEA = 9;

			private const int WkeMxvmUgfsyUiqpMuZhoTZkqrax = 12;

			private const int hXvZMyrmqShxPlXMuEsdUOMPWRaP = 13;

			private const int OjekoZFUSyCqTVydGHPlDgzUgDWF = 14;

			private const int ZyVvizyWgArlCCOFbdJWedszGyaCA = 15;

			private const int VewUkeBOiQSCspZIbxSZrRoxrFwb = 0;

			private const int UcPKuZGjYTINQemKfQWDnFezvIHw = 1;

			private const int WILoCibrIDfBeihdZGYJkVZONtaQ = 3;

			private const int uYXafpeLjKcaYEdYefrLzAhyelrcA = 4;

			private const int khodwDKMyrUtEkSvveovFOsHVTAt = 8;

			private const int kzKFXNFYLhrVvQqBEPgSmPaeQPeHA = 9;

			private readonly IXboxOneInputSource OIZtqLRFgmGvbwwAFqFPIcJLJOjr;

			private int nKsRXsQgkErKsYBmUQyAbwpJWhgg;

			private ulong MMtGDJgISeJuRLYWJHzWTsAopCoeb;

			private string[] vATYTciGpHevLSKqMwEfeZyjEPBE;

			public ulong EsZSMzlQKdrXRnnwsCTGCyacopPI => MMtGDJgISeJuRLYWJHzWTsAopCoeb;

			public TpTeITGUsuKSWjTDsFJxiLPnmmLJ(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				OIZtqLRFgmGvbwwAFqFPIcJLJOjr = P_0;
				nKsRXsQgkErKsYBmUQyAbwpJWhgg = P_2 - 1;
				vATYTciGpHevLSKqMwEfeZyjEPBE = new string[6];
				xKXCkgfYxxZqbxcYtHeIoLPasfYIA();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					shKqbCdnOKCSkGLdkqHwJDNtaKVEb(P_1);
				}
				else
				{
					MMtGDJgISeJuRLYWJHzWTsAopCoeb = P_1;
				}
			}

			public virtual void GiNjLTImCIvZqaMqFCXiKUFBIXMr()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(0);
					buttons[1].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(1);
					buttons[2].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(2);
					buttons[3].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(3);
					buttons[4].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(4);
					buttons[5].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(5);
					buttons[6].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(6);
					buttons[7].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(7);
					buttons[8].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(8);
					buttons[9].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(9);
					buttons[10].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(12);
					buttons[11].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(15);
					buttons[12].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(13);
					buttons[13].value = iTaUbaHAyBGJTakjiLuyWDvmHZQx(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(vATYTciGpHevLSKqMwEfeZyjEPBE[0]);
					axes[1].value = Input.GetAxisRaw(vATYTciGpHevLSKqMwEfeZyjEPBE[1]);
					axes[2].value = Input.GetAxisRaw(vATYTciGpHevLSKqMwEfeZyjEPBE[2]);
					axes[3].value = Input.GetAxisRaw(vATYTciGpHevLSKqMwEfeZyjEPBE[3]);
					axes[4].value = Input.GetAxisRaw(vATYTciGpHevLSKqMwEfeZyjEPBE[4]);
					axes[5].value = Input.GetAxisRaw(vATYTciGpHevLSKqMwEfeZyjEPBE[5]);
				}
			}

			public void shKqbCdnOKCSkGLdkqHwJDNtaKVEb(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					MMtGDJgISeJuRLYWJHzWTsAopCoeb = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						bThlVAvaPlbppCgaDPKtiidQCFCTA();
					}
				}
			}

			private void bThlVAvaPlbppCgaDPKtiidQCFCTA()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(MMtGDJgISeJuRLYWJHzWTsAopCoeb);
				}
				_customName = "Controller " + base.unityId;
			}

			private bool iTaUbaHAyBGJTakjiLuyWDvmHZQx(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + nKsRXsQgkErKsYBmUQyAbwpJWhgg * 20));
			}

			private void xKXCkgfYxxZqbxcYtHeIoLPasfYIA()
			{
				vATYTciGpHevLSKqMwEfeZyjEPBE[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				vATYTciGpHevLSKqMwEfeZyjEPBE[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				vATYTciGpHevLSKqMwEfeZyjEPBE[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				vATYTciGpHevLSKqMwEfeZyjEPBE[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				vATYTciGpHevLSKqMwEfeZyjEPBE[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				vATYTciGpHevLSKqMwEfeZyjEPBE[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}
		}

		private const int itQALdTIVAoKIRNrnfLTpmxmBglx = 8;

		private readonly bool HHxjrasvPukTMPIxpjoFYxzjIrHN;

		private bool moRqXxpagzahNeVfUHKaifcqlAxib;

		private Queue<jsUnuluBCtXDLPprIXEfsYBiEPLR> jjsgXCFIfEyEQouDVBTEdNZshNypA;

		private bool bwNziKYrycOCKPxmmTImSsBmbwbq;

		bool CustomInputSource.isReady => HHxjrasvPukTMPIxpjoFYxzjIrHN;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				jjsgXCFIfEyEQouDVBTEdNZshNypA = new Queue<jsUnuluBCtXDLPprIXEfsYBiEPLR>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = zhPViapcNYOevbFGDFWuegtOIISd((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new TpTeITGUsuKSWjTDsFJxiLPnmmLJ(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += dDhHXPfOKPIpLpJeycuXAkxfSIRDb;
				HHxjrasvPukTMPIxpjoFYxzjIrHN = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (HHxjrasvPukTMPIxpjoFYxzjIrHN)
			{
				ajfeJpkgTeTtcdjIVyXljgToGJOLA();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void dDhHXPfOKPIpLpJeycuXAkxfSIRDb(uint P_0, bool P_1)
		{
			if (!HHxjrasvPukTMPIxpjoFYxzjIrHN)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (zhPViapcNYOevbFGDFWuegtOIISd(P_0, true, out var _))
				{
					rXalpbSQjMNIAjmzBoiyeaEwGNxA(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as TpTeITGUsuKSWjTDsFJxiLPnmmLJ).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void rXalpbSQjMNIAjmzBoiyeaEwGNxA(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			TpTeITGUsuKSWjTDsFJxiLPnmmLJ obj = GetJoysticks()[index] as TpTeITGUsuKSWjTDsFJxiLPnmmLJ;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.shKqbCdnOKCSkGLdkqHwJDNtaKVEb(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void ajfeJpkgTeTtcdjIVyXljgToGJOLA()
		{
			int num = jjsgXCFIfEyEQouDVBTEdNZshNypA.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				jsUnuluBCtXDLPprIXEfsYBiEPLR item = jjsgXCFIfEyEQouDVBTEdNZshNypA.Dequeue();
				if (currentFrame >= item.NLEQUJxFOYTJKRBDZdYGSlMPtxAC + 1)
				{
					if (zhPViapcNYOevbFGDFWuegtOIISd(item.FBaYEkYugoftYHcQJvXFvopkNism, true, out var _))
					{
						rXalpbSQjMNIAjmzBoiyeaEwGNxA(item.FBaYEkYugoftYHcQJvXFvopkNism, false);
						flag = true;
					}
				}
				else
				{
					jjsgXCFIfEyEQouDVBTEdNZshNypA.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool zhPViapcNYOevbFGDFWuegtOIISd(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					jjsgXCFIfEyEQouDVBTEdNZshNypA.Enqueue(new jsUnuluBCtXDLPprIXEfsYBiEPLR(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void MGWfaVnZxOEvDxncWzvjieeqjdSM()
		{
			if (!moRqXxpagzahNeVfUHKaifcqlAxib)
			{
				moRqXxpagzahNeVfUHKaifcqlAxib = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!HHxjrasvPukTMPIxpjoFYxzjIrHN)
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
			if (HHxjrasvPukTMPIxpjoFYxzjIrHN)
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

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, xnlieJzaCUMurEZZmzCtThDssQyB vibration)
		{
			if (!HHxjrasvPukTMPIxpjoFYxzjIrHN)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.jDPYQbyTQhExOvKKsfXCvAmyZsed, vibration.ytZUPBQOZznGXtnkHTiLZhSUIsqL, vibration.qodKWCuyxkkNfhDHqpCReIPdozxc, vibration.UOgMqeTGmCobbmEOrezAazhvCfnD);
		}

		bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, xnlieJzaCUMurEZZmzCtThDssQyB vibration)
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
			if (!bwNziKYrycOCKPxmmTImSsBmbwbq)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= dDhHXPfOKPIpLpJeycuXAkxfSIRDb;
				}
				bwNziKYrycOCKPxmmTImSsBmbwbq = true;
			}
		}
	}
}
