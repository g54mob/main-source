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

		private struct xxrBwzKbivtPZdHtCNqrrRqpUMD
		{
			public uint gmeZbvToPHWGaAzcSsVQduvojtd;

			public uint JRjeYLXLYTVIKXnGWRPCfTUkazf;

			public xxrBwzKbivtPZdHtCNqrrRqpUMD(uint unityJoystickId, uint connectedFrame)
			{
				gmeZbvToPHWGaAzcSsVQduvojtd = unityJoystickId;
				JRjeYLXLYTVIKXnGWRPCfTUkazf = connectedFrame;
			}
		}

		private class TYeIkVipUmNKCFkPqvwffgywvEL : Joystick
		{
			private const int RJpArmCUtRiPnVeoaamBjjbTBEHe = 6;

			private const int rVYednFAWMyyCdseuzQUGHWBwloT = 14;

			private const string sNLutdaxBoaagQqAmZOEsbREWds = "Xbox One Controller";

			private const int HrJozZFNhYltQGqrUEEiHAygksXD = 0;

			private const int amSZpumPwHFAjzdyZwFwBafQfq = 1;

			private const int JgcygiWoQjqLwpOXmyJvIURRGtp = 2;

			private const int imWXIDsLQyKpumErjcjOKDHDrxvi = 3;

			private const int dOSWVFxjZjezTXVyroxneKZBqNc = 4;

			private const int MkmBczaRPJpBWotzKZouhlSUlHq = 5;

			private const int mxLtKATTiXHmNuirwGhOgTYuLRS = 6;

			private const int TyCFsUreIbfUMgWNSKdqTcoUsVVs = 7;

			private const int bOubEsebXnanAFOxErWttkrKyqXb = 8;

			private const int LtVGJldRfoanWtVjeidrsDBwxWv = 9;

			private const int yFmNxTYFrppiXgGQaFtADwVcTQjm = 12;

			private const int pceuwameNNgAGkycGqetUXQgsCQB = 13;

			private const int NnnrDKqLVyyuraBDKfCkisLJAaE = 14;

			private const int RiWtdmTmonflQXqTHwylLSjMVwR = 15;

			private const int FKcGDmxMVoCiSuthngYFjGSKLCv = 0;

			private const int aAXguOVrzORGWKGolDLhkayWYVb = 1;

			private const int nLkKVTPZlIcWFvmxKqaRhpRYCsy = 3;

			private const int qFzfvbvXnTBayMyiLmUufkKCAke = 4;

			private const int PzTBleESpgnJEmcTefeqGSXDImjW = 8;

			private const int uzInFfMWgLXImbEuoeIXyCxOnIj = 9;

			private readonly IXboxOneInputSource MHWfeAIIxgGWGdDJknvdMLOmOzQM;

			private int FpdtqZZTWeqPcFFnqYkufVBjbtW;

			private ulong GDVsvRItbnASdfQpbHFWkisaawe;

			private string[] lWJKaYMYGhftEewBPlNZBvFdCZy;

			public ulong xboxControllerId => GDVsvRItbnASdfQpbHFWkisaawe;

			public TYeIkVipUmNKCFkPqvwffgywvEL(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(isConnected ? UnityTools.externalTools.XboxOneInput_GetControllerType(xboxControllerId) : "Xbox One Controller", (long)xboxControllerId, unityJoystickId, 6, 14)
			{
				MHWfeAIIxgGWGdDJknvdMLOmOzQM = inputSource;
				FpdtqZZTWeqPcFFnqYkufVBjbtW = unityJoystickId - 1;
				lWJKaYMYGhftEewBPlNZBvFdCZy = new string[6];
				EOYGBagkNWMpxVXHxpyVDFkrkeKh();
				base.extension = new XboxOneGamepadExtension(supportsVibration: true, inputSource);
				_isConnected = isConnected;
				if (_isConnected)
				{
					EJpmrTgGvrhKjJnkpXbomYBpQTQ(xboxControllerId);
				}
				else
				{
					GDVsvRItbnASdfQpbHFWkisaawe = xboxControllerId;
				}
			}

			public virtual void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].value = tczGrLoSLQRKAWwrReBmbHatjKF(0);
					buttons[1].value = tczGrLoSLQRKAWwrReBmbHatjKF(1);
					buttons[2].value = tczGrLoSLQRKAWwrReBmbHatjKF(2);
					buttons[3].value = tczGrLoSLQRKAWwrReBmbHatjKF(3);
					buttons[4].value = tczGrLoSLQRKAWwrReBmbHatjKF(4);
					buttons[5].value = tczGrLoSLQRKAWwrReBmbHatjKF(5);
					buttons[6].value = tczGrLoSLQRKAWwrReBmbHatjKF(6);
					buttons[7].value = tczGrLoSLQRKAWwrReBmbHatjKF(7);
					buttons[8].value = tczGrLoSLQRKAWwrReBmbHatjKF(8);
					buttons[9].value = tczGrLoSLQRKAWwrReBmbHatjKF(9);
					buttons[10].value = tczGrLoSLQRKAWwrReBmbHatjKF(12);
					buttons[11].value = tczGrLoSLQRKAWwrReBmbHatjKF(15);
					buttons[12].value = tczGrLoSLQRKAWwrReBmbHatjKF(13);
					buttons[13].value = tczGrLoSLQRKAWwrReBmbHatjKF(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(lWJKaYMYGhftEewBPlNZBvFdCZy[0]);
					axes[1].value = Input.GetAxisRaw(lWJKaYMYGhftEewBPlNZBvFdCZy[1]);
					axes[2].value = Input.GetAxisRaw(lWJKaYMYGhftEewBPlNZBvFdCZy[2]);
					axes[3].value = Input.GetAxisRaw(lWJKaYMYGhftEewBPlNZBvFdCZy[3]);
					axes[4].value = Input.GetAxisRaw(lWJKaYMYGhftEewBPlNZBvFdCZy[4]);
					axes[5].value = Input.GetAxisRaw(lWJKaYMYGhftEewBPlNZBvFdCZy[5]);
				}
			}

			public void EJpmrTgGvrhKjJnkpXbomYBpQTQ(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					GDVsvRItbnASdfQpbHFWkisaawe = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						zrahqzhRyQTOPrjZKnMJjcgWSGl();
					}
				}
			}

			private void zrahqzhRyQTOPrjZKnMJjcgWSGl()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(GDVsvRItbnASdfQpbHFWkisaawe);
				}
				_customName = "Controller " + base.unityId;
			}

			private bool tczGrLoSLQRKAWwrReBmbHatjKF(int P_0)
			{
				int key = 350 + P_0 + FpdtqZZTWeqPcFFnqYkufVBjbtW * 20;
				return Input.GetKey((KeyCode)key);
			}

			private void EOYGBagkNWMpxVXHxpyVDFkrkeKh()
			{
				lWJKaYMYGhftEewBPlNZBvFdCZy[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				lWJKaYMYGhftEewBPlNZBvFdCZy[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				lWJKaYMYGhftEewBPlNZBvFdCZy[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				lWJKaYMYGhftEewBPlNZBvFdCZy[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				lWJKaYMYGhftEewBPlNZBvFdCZy[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				lWJKaYMYGhftEewBPlNZBvFdCZy[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}
		}

		private const int OCxCaUZtaFGiAxGzQiOUfJyWEOXe = 8;

		private readonly bool SqipAxIcjKKBSnKUcHhsIAAfbiWH;

		private bool hOYZftlaTSjbShnJbyqIpuMhxsM;

		private Queue<xxrBwzKbivtPZdHtCNqrrRqpUMD> GkWTVTRJrMDsoASGgIzfuWUXrhe;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public override bool isReady => SqipAxIcjKKBSnKUcHhsIAAfbiWH;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				GkWTVTRJrMDsoASGgIzfuWUXrhe = new Queue<xxrBwzKbivtPZdHtCNqrrRqpUMD>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = oCsmgGGpWKuAuZRkgKQzNJehPfR((uint)num, true, out badConnectionReason);
					ulong xboxControllerId = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new TYeIkVipUmNKCFkPqvwffgywvEL(this, xboxControllerId, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += SklRFCPwmlQVlyRozbSrppXPWjY;
				SqipAxIcjKKBSnKUcHhsIAAfbiWH = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
			{
				JEGiWmksuQUXfCsGNvWYvfsQCOo();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void SklRFCPwmlQVlyRozbSrppXPWjY(uint P_0, bool P_1)
		{
			if (!SqipAxIcjKKBSnKUcHhsIAAfbiWH)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (oCsmgGGpWKuAuZRkgKQzNJehPfR(P_0, true, out var _))
				{
					gFnVsFydCCbLVvhljhHUagfJOCn(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				TYeIkVipUmNKCFkPqvwffgywvEL tYeIkVipUmNKCFkPqvwffgywvEL = GetJoysticks()[index] as TYeIkVipUmNKCFkPqvwffgywvEL;
				tYeIkVipUmNKCFkPqvwffgywvEL.Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void gFnVsFydCCbLVvhljhHUagfJOCn(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			TYeIkVipUmNKCFkPqvwffgywvEL tYeIkVipUmNKCFkPqvwffgywvEL = GetJoysticks()[index] as TYeIkVipUmNKCFkPqvwffgywvEL;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			tYeIkVipUmNKCFkPqvwffgywvEL.EJpmrTgGvrhKjJnkpXbomYBpQTQ(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void JEGiWmksuQUXfCsGNvWYvfsQCOo()
		{
			int num = GkWTVTRJrMDsoASGgIzfuWUXrhe.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				xxrBwzKbivtPZdHtCNqrrRqpUMD item = GkWTVTRJrMDsoASGgIzfuWUXrhe.Dequeue();
				if (currentFrame >= item.JRjeYLXLYTVIKXnGWRPCfTUkazf + 1)
				{
					if (oCsmgGGpWKuAuZRkgKQzNJehPfR(item.gmeZbvToPHWGaAzcSsVQduvojtd, true, out var _))
					{
						gFnVsFydCCbLVvhljhHUagfJOCn(item.gmeZbvToPHWGaAzcSsVQduvojtd, false);
						flag = true;
					}
				}
				else
				{
					GkWTVTRJrMDsoASGgIzfuWUXrhe.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool oCsmgGGpWKuAuZRkgKQzNJehPfR(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					GkWTVTRJrMDsoASGgIzfuWUXrhe.Enqueue(new xxrBwzKbivtPZdHtCNqrrRqpUMD(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void wpbORtJNTmWtulYnNIiyjPBYtAc()
		{
			if (!hOYZftlaTSjbShnJbyqIpuMhxsM)
			{
				hOYZftlaTSjbShnJbyqIpuMhxsM = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!SqipAxIcjKKBSnKUcHhsIAAfbiWH)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, baObqiGLCEnOuOsTehPAyECzcjCx vibration)
		{
			if (!SqipAxIcjKKBSnKUcHhsIAAfbiWH)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.FHARfJwFjGtAuCfaZbvefjItCedM, vibration.VeKfSmItNnzdreClITSFcjrOIjxR, vibration.DMzcBQLYYkiJcgrOwMazRMaZAhZ, vibration.UmoUBOZzTtSynwTGPqDEjhbOphz);
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
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= SklRFCPwmlQVlyRozbSrppXPWjY;
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
