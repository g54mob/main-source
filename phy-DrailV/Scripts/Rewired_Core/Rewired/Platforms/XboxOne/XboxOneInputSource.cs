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

		private struct wyhmPwSdAEJWQodfNZDQGIsQAYxQ
		{
			public uint xrqBheTqtmZIxFUqBRKdQnlFbTZG;

			public uint OtTkRpTfdtIGPOpJFidyUFyncgXd;

			public wyhmPwSdAEJWQodfNZDQGIsQAYxQ(uint P_0, uint P_1)
			{
				xrqBheTqtmZIxFUqBRKdQnlFbTZG = P_0;
				OtTkRpTfdtIGPOpJFidyUFyncgXd = P_1;
			}
		}

		private class YyuEeCcEyPITVOeBxLEKOluBhhvbA : Joystick, IInputManagerHardwareJoystickMapHandler, ITryGetLocalizedName
		{
			private const int KkbOXxEuXwhRkKpefZpsKkvoQFpI = 6;

			private const int sqOAjqiYgpyrLlQchddtcgIsmpGfb = 14;

			private const string zXHgGGwQsckSUJIidHFtJcWRiACPA = "Xbox One Controller";

			private const string pRUfRQKqNONpXxwKCPVyBwYYjbWr = "Controller";

			private const int IRTRtQNBDxqoDXVfTUtXznoTCktw = 0;

			private const int pPcJcfgxmTSLdkrodZkRXkaElUtB = 1;

			private const int UamqydYNmGpJzceHrgBSjvFsAYJK = 2;

			private const int pLKWOQywgVnkrbddqEYzbgRcAzJQA = 3;

			private const int aoGGROjHyKnaxSZaeVIANKHaqWzC = 4;

			private const int RewfuciFhmSGPOfjBYDJaGUfRREsA = 5;

			private const int lQZrfLHUEqQlCbRdljsjRMINHhqK = 6;

			private const int MYMjaVjucUIPTBRBBNSZPLaxkDpv = 7;

			private const int goiaYdufdALwPHutDunANdhxUshN = 8;

			private const int ISLdPyfDRZlkNfYrltQKAcJJqARPA = 9;

			private const int dauTrAEWXAlPWlgGjjIbBiNPfOBBA = 12;

			private const int gdwNexeqbiHZNdMqNqVOweUXJYyo = 13;

			private const int SMdxPRmzcDlnZtLaHARwXsHiAmYB = 14;

			private const int ODEZvrDyIAWgDMwPUmPSodzjmmpx = 15;

			private const int KmmkVrvxxLkfPnRviDncIhArIGJdA = 0;

			private const int zVHkmNFpRtaCTbRqgnsILLkppNVFA = 1;

			private const int omwYaYTpXhbuBoalRNQJOjrxCGTc = 3;

			private const int vZjdhsphBekAfDpuSDXRMRQnUGAP = 4;

			private const int YDHAfxOeFDPQJbFNxhRZjXRgeiDEA = 8;

			private const int tUSrYkOwKqMJlwOidvYaZrlrUeRK = 9;

			private readonly IXboxOneInputSource JNMBmPSsDBEFBkOLyoQWUaGjLnyvA;

			private int KOtpxUXimBlCfCTtnzWBAvPWpsmj;

			private ulong TuNqjqSFUWDOTaSKmiaWNoHJiDEd;

			private string[] mbXKXLIePIuPtbcVISsAkxtOWKJc;

			private HardwareJoystickMap_InputManager tZIuQAjrHYWwCXVWSchyGqJusgzf;

			private readonly LocalizedString pBHGSdiKqWIcVIxiLTzkoXwKRJelA;

			public ulong KrnxVvdrRcaXzsFTOVOHfaPSljab => TuNqjqSFUWDOTaSKmiaWNoHJiDEd;

			public YyuEeCcEyPITVOeBxLEKOluBhhvbA(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
				: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
			{
				JNMBmPSsDBEFBkOLyoQWUaGjLnyvA = P_0;
				KOtpxUXimBlCfCTtnzWBAvPWpsmj = P_2 - 1;
				mbXKXLIePIuPtbcVISsAkxtOWKJc = new string[6];
				RMOdVpbyptukguWRsBNsneiWhyquA();
				pBHGSdiKqWIcVIxiLTzkoXwKRJelA = new LocalizedString();
				base.extension = new XboxOneGamepadExtension(true, P_0);
				_isConnected = P_3;
				if (_isConnected)
				{
					TlzckGoQDITHcUYaslQXPQBOhTwq(P_1);
				}
				else
				{
					TuNqjqSFUWDOTaSKmiaWNoHJiDEd = P_1;
				}
			}

			public virtual void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
				if (_isConnected)
				{
					IList<Button> buttons = base.Buttons;
					buttons[0].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(0);
					buttons[1].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(1);
					buttons[2].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(2);
					buttons[3].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(3);
					buttons[4].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(4);
					buttons[5].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(5);
					buttons[6].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(6);
					buttons[7].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(7);
					buttons[8].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(8);
					buttons[9].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(9);
					buttons[10].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(12);
					buttons[11].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(15);
					buttons[12].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(13);
					buttons[13].boolValue = aBjKkYedffJMBNyjOkVFOWaUaAhq(14);
					IList<Axis> axes = base.Axes;
					axes[0].value = Input.GetAxisRaw(mbXKXLIePIuPtbcVISsAkxtOWKJc[0]);
					axes[1].value = Input.GetAxisRaw(mbXKXLIePIuPtbcVISsAkxtOWKJc[1]);
					axes[2].value = Input.GetAxisRaw(mbXKXLIePIuPtbcVISsAkxtOWKJc[2]);
					axes[3].value = Input.GetAxisRaw(mbXKXLIePIuPtbcVISsAkxtOWKJc[3]);
					axes[4].value = Input.GetAxisRaw(mbXKXLIePIuPtbcVISsAkxtOWKJc[4]);
					axes[5].value = Input.GetAxisRaw(mbXKXLIePIuPtbcVISsAkxtOWKJc[5]);
				}
			}

			public void TlzckGoQDITHcUYaslQXPQBOhTwq(ulong P_0)
			{
				if (!_isConnected)
				{
					_isConnected = true;
					TuNqjqSFUWDOTaSKmiaWNoHJiDEd = P_0;
					base.systemId = (long)P_0;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
					{
						Logger.LogError("Unity joystick id does not match expected id!");
						_isConnected = false;
					}
					else
					{
						kPoFkkbhIpTXGmEDHZbsUIqpbUTcA();
					}
				}
			}

			private void kPoFkkbhIpTXGmEDHZbsUIqpbUTcA()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(TuNqjqSFUWDOTaSKmiaWNoHJiDEd);
				}
				_customName = string.Format("{0} {1}", "Controller", base.unityId);
				pBHGSdiKqWIcVIxiLTzkoXwKRJelA.Clear();
			}

			private bool aBjKkYedffJMBNyjOkVFOWaUaAhq(int P_0)
			{
				return Input.GetKey((KeyCode)(350 + P_0 + KOtpxUXimBlCfCTtnzWBAvPWpsmj * 20));
			}

			private void RMOdVpbyptukguWRsBNsneiWhyquA()
			{
				mbXKXLIePIuPtbcVISsAkxtOWKJc[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				mbXKXLIePIuPtbcVISsAkxtOWKJc[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				mbXKXLIePIuPtbcVISsAkxtOWKJc[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				mbXKXLIePIuPtbcVISsAkxtOWKJc[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				mbXKXLIePIuPtbcVISsAkxtOWKJc[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				mbXKXLIePIuPtbcVISsAkxtOWKJc[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}

			private void FFRktSzPuAOZbqGtfcgtmqTrTteF(HardwareJoystickMap_InputManager P_0)
			{
				tZIuQAjrHYWwCXVWSchyGqJusgzf = P_0;
			}

			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FFRktSzPuAOZbqGtfcgtmqTrTteF
				this.FFRktSzPuAOZbqGtfcgtmqTrTteF(P_0);
			}

			private bool DxHoDPNzMdHYSxVnpKKUgghuWmEP(out string P_0)
			{
				if (tZIuQAjrHYWwCXVWSchyGqJusgzf == null)
				{
					P_0 = null;
					return false;
				}
				if ((LocalizationManager.GetAndUpdateLocalizedString(pBHGSdiKqWIcVIxiLTzkoXwKRJelA, tZIuQAjrHYWwCXVWSchyGqJusgzf.deviceLocalizationInfo.parentKeys, "controller", "Controller", out P_0) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
				{
					P_0 = $"{P_0} {base.unityId}";
					pBHGSdiKqWIcVIxiLTzkoXwKRJelA.cachedValue = P_0;
				}
				return true;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in DxHoDPNzMdHYSxVnpKKUgghuWmEP
				return this.DxHoDPNzMdHYSxVnpKKUgghuWmEP(out P_0);
			}
		}

		private const int JdfWfNBfIugVLaYrZWffGLarMSzy = 8;

		private readonly bool DlyzgeEtPbGSRivIvEmZhBSIEqiU;

		private bool uqIaNuvXvlQsTymZgjBhGUKYWvyU;

		private Queue<wyhmPwSdAEJWQodfNZDQGIsQAYxQ> XpGJqKTEvbWAtRyOvrHUJeCmfKYi;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public override bool isReady => DlyzgeEtPbGSRivIvEmZhBSIEqiU;

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				XpGJqKTEvbWAtRyOvrHUJeCmfKYi = new Queue<wyhmPwSdAEJWQodfNZDQGIsQAYxQ>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = pDkgmZKygjuFdUwqtidMkQuIDznN((uint)num, true, out badConnectionReason);
					ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new YyuEeCcEyPITVOeBxLEKOluBhhvbA(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += HkdLZNHyKSjYoxTagejOKIZqStuT;
				DlyzgeEtPbGSRivIvEmZhBSIEqiU = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				GkQafBaYzJBaSJetCKUdQzrpCGed();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				IList<Joystick> joysticks = GetJoysticks();
				int count = joysticks.Count;
				for (int i = 0; i < count; i++)
				{
					joysticks[i].Update();
				}
			}
		}

		private void HkdLZNHyKSjYoxTagejOKIZqStuT(uint P_0, bool P_1)
		{
			if (!DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return;
			}
			if (P_0 == 0)
			{
				Logger.LogError("Invalid unity joystick id");
			}
			else if (P_1)
			{
				if (pDkgmZKygjuFdUwqtidMkQuIDznN(P_0, true, out var _))
				{
					lZzJzOwRffemAqbFeEWjDjnqQLrc(P_0, true);
				}
			}
			else
			{
				int index = (int)(P_0 - 1);
				(GetJoysticks()[index] as YyuEeCcEyPITVOeBxLEKOluBhhvbA).Disconnect();
				OnJoystickDisconnected();
			}
		}

		private void lZzJzOwRffemAqbFeEWjDjnqQLrc(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			YyuEeCcEyPITVOeBxLEKOluBhhvbA obj = GetJoysticks()[index] as YyuEeCcEyPITVOeBxLEKOluBhhvbA;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
			obj.TlzckGoQDITHcUYaslQXPQBOhTwq(num);
			if (P_1)
			{
				OnJoystickConnected();
			}
		}

		private void GkQafBaYzJBaSJetCKUdQzrpCGed()
		{
			int num = XpGJqKTEvbWAtRyOvrHUJeCmfKYi.Count;
			if (num == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (num > 0)
			{
				wyhmPwSdAEJWQodfNZDQGIsQAYxQ item = XpGJqKTEvbWAtRyOvrHUJeCmfKYi.Dequeue();
				if (currentFrame >= item.OtTkRpTfdtIGPOpJFidyUFyncgXd + 1)
				{
					if (pDkgmZKygjuFdUwqtidMkQuIDznN(item.xrqBheTqtmZIxFUqBRKdQnlFbTZG, true, out var _))
					{
						lZzJzOwRffemAqbFeEWjDjnqQLrc(item.xrqBheTqtmZIxFUqBRKdQnlFbTZG, false);
						flag = true;
					}
				}
				else
				{
					XpGJqKTEvbWAtRyOvrHUJeCmfKYi.Enqueue(item);
				}
				num--;
			}
			if (flag)
			{
				OnJoystickConnected();
			}
		}

		private bool pDkgmZKygjuFdUwqtidMkQuIDznN(uint P_0, bool P_1, out BadConnectionReason P_2)
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
					XpGJqKTEvbWAtRyOvrHUJeCmfKYi.Enqueue(new wyhmPwSdAEJWQodfNZDQGIsQAYxQ(P_0, ReInput.time.currentFrame));
				}
				P_2 = BadConnectionReason.InvalidName;
				return false;
			}
			P_2 = BadConnectionReason.None;
			return true;
		}

		private void zPlIhkLfbDHOfihGGHxTYdZfKzSs()
		{
			if (!uqIaNuvXvlQsTymZgjBhGUKYWvyU)
			{
				uqIaNuvXvlQsTymZgjBhGUKYWvyU = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, oZISafBoibILjjNTfBebbZKKoxsR vibration)
		{
			if (!DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.ANSllAkSZftTtPPwCpMZCmCIBuRO, vibration.IkABAjbftCiucaTpRdfywWfzUnFJA, vibration.SFpBtBRdiJiAxhAUtkLOqnyysxro, vibration.BoyyVZHBdUSvedrASSmfAWpjqvVr);
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
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= HkdLZNHyKSjYoxTagejOKIZqStuT;
				}
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
			}
		}
	}
}
