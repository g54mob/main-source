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

		private struct LHranhjgcYahoLHHqOjsfZVPsMjjb
		{
			public uint MoaYEjrLFoYkBemAelbFTXOAMzBT;

			public uint fqFJlKjOHjVtrnNTuPAENkyiUuHs;

			public LHranhjgcYahoLHHqOjsfZVPsMjjb(uint P_0, uint P_1)
			{
				MoaYEjrLFoYkBemAelbFTXOAMzBT = P_0;
				fqFJlKjOHjVtrnNTuPAENkyiUuHs = P_1;
			}
		}

		private class rujIRYAcHgTrblxQgsVFVBGfilC : Joystick
		{
			private const int hTtWFqoKfkIVSdGOWffSHmWvCWjfA = 6;

			private const int BhCbgrefAhFSrJIISsNLWhvlnnANA = 14;

			private const string QWXsbbOKXViOJereSHAFWqMwgUGr = "Xbox One Controller";

			private const int pUNoZFjhAbRtbyRCcLbzgHRImitf = 0;

			private const int AMikShWKFTMdvXKDYvpCAXTLFtSS = 1;

			private const int hxuztowzSKPMFZirIyruyikzmSPs = 2;

			private const int YOWFyZOFSHRaLQZXHeoVldsrpbXi = 3;

			private const int VKANNVTLrAbYQDnrZsvsDWvzQcbNA = 4;

			private const int cvidxnvIZypxxKgBeVnzBetggZIy = 5;

			private const int WnPVqGdMqyWziEuNCLDZSvxWtLeU = 6;

			private const int tBCbJMJCkGaFpsCrwyVzCJLwNJtl = 7;

			private const int VxgaBwBCHQnFfYeXqWFixWQuqibuA = 8;

			private const int xVRMqnlXpFLXvdLNWocqfssMQgNL = 9;

			private const int QdkiJReJpCMLoUpwSiuXQbqOMgDk = 12;

			private const int VggjtiILbwgLnYULsnBwnFxQASah = 13;

			private const int lwrEoAEQHDMKTSSnyKgvGXLjxSyU = 14;

			private const int tuSwyqfQwEBxzbFfpbeojDCcAizR = 15;

			private const int zpyQuPBZTVWrfMTTrLIAHbiuMRqc = 0;

			private const int EzPfYrptdzhtAmWhFScyELDkTFSc = 1;

			private const int DVoHVLpIVhSWbXFAsulbDkMwyOKT = 3;

			private const int QjxfepdVfeMxBgiApWtdaJhmTWWtA = 4;

			private const int nnFAggwrlNFnvGVbGdxvfgudccLLA = 8;

			private const int KeEZsvohyekdNFRSIlHOGIYitWHs = 9;

			private readonly IXboxOneInputSource ieYluIwipVjyjzLjHAiijAxmNxsP;

			private int xlzwqHtwYBSMRvLFABJfHAkXCpwFA;

			private ulong oDJJfhmKlWFgtRawLVCCKHBEewKEA;

			private string[] NKNDXQanYWbRlGTUvsgYvJETCIUm;

			public ulong lhvDsQPcLZOThRXxyjheiSPWTvpT => oDJJfhmKlWFgtRawLVCCKHBEewKEA;

			public rujIRYAcHgTrblxQgsVFVBGfilC(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				ieYluIwipVjyjzLjHAiijAxmNxsP = P_0;
				xlzwqHtwYBSMRvLFABJfHAkXCpwFA = P_2 - 1;
				NKNDXQanYWbRlGTUvsgYvJETCIUm = new string[6];
				eqCErkQjJzeZQbwnFzuClGTXiiar();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					gUxczTgMdKUcYRnCXamteWaCXJodc(P_1);
				}
				else
				{
					oDJJfhmKlWFgtRawLVCCKHBEewKEA = P_1;
				}
			}

			public virtual void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].value = PKxzXBSMXndnnwoVrPblHLVDZExv(0);
					buttons[1].value = PKxzXBSMXndnnwoVrPblHLVDZExv(1);
					buttons[2].value = PKxzXBSMXndnnwoVrPblHLVDZExv(2);
					buttons[3].value = PKxzXBSMXndnnwoVrPblHLVDZExv(3);
					buttons[4].value = PKxzXBSMXndnnwoVrPblHLVDZExv(4);
					buttons[5].value = PKxzXBSMXndnnwoVrPblHLVDZExv(5);
					buttons[6].value = PKxzXBSMXndnnwoVrPblHLVDZExv(6);
					buttons[7].value = PKxzXBSMXndnnwoVrPblHLVDZExv(7);
					buttons[8].value = PKxzXBSMXndnnwoVrPblHLVDZExv(8);
					buttons[9].value = PKxzXBSMXndnnwoVrPblHLVDZExv(9);
					buttons[10].value = PKxzXBSMXndnnwoVrPblHLVDZExv(12);
					buttons[11].value = PKxzXBSMXndnnwoVrPblHLVDZExv(15);
					buttons[12].value = PKxzXBSMXndnnwoVrPblHLVDZExv(13);
					buttons[13].value = PKxzXBSMXndnnwoVrPblHLVDZExv(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(NKNDXQanYWbRlGTUvsgYvJETCIUm[0]);
					axes[1].value = Input.GetAxisRaw(NKNDXQanYWbRlGTUvsgYvJETCIUm[1]);
					axes[2].value = Input.GetAxisRaw(NKNDXQanYWbRlGTUvsgYvJETCIUm[2]);
					axes[3].value = Input.GetAxisRaw(NKNDXQanYWbRlGTUvsgYvJETCIUm[3]);
					axes[4].value = Input.GetAxisRaw(NKNDXQanYWbRlGTUvsgYvJETCIUm[4]);
					axes[5].value = Input.GetAxisRaw(NKNDXQanYWbRlGTUvsgYvJETCIUm[5]);
				}
			}

			public void gUxczTgMdKUcYRnCXamteWaCXJodc(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					oDJJfhmKlWFgtRawLVCCKHBEewKEA = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						XgwbhwHygfckKPbCmHYWDLomAXsc();
					}
				}
			}

			private void XgwbhwHygfckKPbCmHYWDLomAXsc()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(oDJJfhmKlWFgtRawLVCCKHBEewKEA);
				}
				_customName = "Controller " + base.unityId;
			}

			private bool PKxzXBSMXndnnwoVrPblHLVDZExv(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + xlzwqHtwYBSMRvLFABJfHAkXCpwFA * 20));
			}

			private void eqCErkQjJzeZQbwnFzuClGTXiiar()
			{
				NKNDXQanYWbRlGTUvsgYvJETCIUm[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				NKNDXQanYWbRlGTUvsgYvJETCIUm[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				NKNDXQanYWbRlGTUvsgYvJETCIUm[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				NKNDXQanYWbRlGTUvsgYvJETCIUm[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				NKNDXQanYWbRlGTUvsgYvJETCIUm[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				NKNDXQanYWbRlGTUvsgYvJETCIUm[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}
		}

		private const int uZtyPIlJauCmfVvHgfRVRuZomYlQ = 8;

		private readonly bool qumTafanxrjKbDduWdypwIzXqmiP;

		private bool HnCfKzJTZtvFvdLbXzfTLPfLrnkpA;

		private Queue<LHranhjgcYahoLHHqOjsfZVPsMjjb> sYWnIHxKZbXfXgnwCQTkMqzxybWR;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public override bool isReady => qumTafanxrjKbDduWdypwIzXqmiP;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				sYWnIHxKZbXfXgnwCQTkMqzxybWR = new Queue<LHranhjgcYahoLHHqOjsfZVPsMjjb>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = YyhnGclWdyuLrNCGpPoxCZRCbjHA((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new rujIRYAcHgTrblxQgsVFVBGfilC(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += gArKfWdiwKdfIEQOTJlyNbijJpkp;
				qumTafanxrjKbDduWdypwIzXqmiP = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (qumTafanxrjKbDduWdypwIzXqmiP)
			{
				vtOgxOYCiXieoboCpugDoJSkUCihA();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void gArKfWdiwKdfIEQOTJlyNbijJpkp(uint P_0, bool P_1)
		{
			if (!qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (YyhnGclWdyuLrNCGpPoxCZRCbjHA(P_0, true, out var _))
				{
					EWrRYZIpjhOHaVdVPbaZGvChAKFDA(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as rujIRYAcHgTrblxQgsVFVBGfilC).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void EWrRYZIpjhOHaVdVPbaZGvChAKFDA(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			rujIRYAcHgTrblxQgsVFVBGfilC obj = GetJoysticks()[index] as rujIRYAcHgTrblxQgsVFVBGfilC;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.gUxczTgMdKUcYRnCXamteWaCXJodc(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void vtOgxOYCiXieoboCpugDoJSkUCihA()
		{
			int num = sYWnIHxKZbXfXgnwCQTkMqzxybWR.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				LHranhjgcYahoLHHqOjsfZVPsMjjb item = sYWnIHxKZbXfXgnwCQTkMqzxybWR.Dequeue();
				if (currentFrame >= item.fqFJlKjOHjVtrnNTuPAENkyiUuHs + 1)
				{
					if (YyhnGclWdyuLrNCGpPoxCZRCbjHA(item.MoaYEjrLFoYkBemAelbFTXOAMzBT, true, out var _))
					{
						EWrRYZIpjhOHaVdVPbaZGvChAKFDA(item.MoaYEjrLFoYkBemAelbFTXOAMzBT, false);
						flag = true;
					}
				}
				else
				{
					sYWnIHxKZbXfXgnwCQTkMqzxybWR.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool YyhnGclWdyuLrNCGpPoxCZRCbjHA(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					sYWnIHxKZbXfXgnwCQTkMqzxybWR.Enqueue(new LHranhjgcYahoLHHqOjsfZVPsMjjb(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void GMbrTnnZRTBiLXkqzzZhHAuiYfCn()
		{
			if (!HnCfKzJTZtvFvdLbXzfTLPfLrnkpA)
			{
				HnCfKzJTZtvFvdLbXzfTLPfLrnkpA = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (qumTafanxrjKbDduWdypwIzXqmiP)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, ZCUdBedUUjmCBSWhOAJNcgvTbdyn vibration)
		{
			if (!qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.beUkeDKrwnofPgcMxoPtNYdTwMZH, vibration.vAEFueFHPSFJQkEHuaLADFQgepXab, vibration.tplbEYhfSZWlVKMyULvknlZvqxfsA, vibration.srsKgIroRWEpEQdszGmVRBAkzWPH);
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
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= gArKfWdiwKdfIEQOTJlyNbijJpkp;
				}
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}
	}
}
