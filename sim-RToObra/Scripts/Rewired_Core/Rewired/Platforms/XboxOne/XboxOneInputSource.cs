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

		private struct bXmcTMfGwFwLLQZrIAsdJeUcWzy
		{
			public uint aYpumKHzXlKGeinaYggEyjZraQSC;

			public uint PfEGJlZJLohXMpnrEXVDellLDPS;

			public bXmcTMfGwFwLLQZrIAsdJeUcWzy(uint unityJoystickId, uint connectedFrame)
			{
				aYpumKHzXlKGeinaYggEyjZraQSC = unityJoystickId;
				PfEGJlZJLohXMpnrEXVDellLDPS = connectedFrame;
			}
		}

		private class VrjTyZoECUUIfnXhabttsAzpAeW : Joystick
		{
			private const int RIkTzHMebzlynxPmgnyFuNPUwtk = 6;

			private const int jWRCMWQrEgSaEEOkwnKCQeiQjUVe = 14;

			private const string wHUXVWmeTAuicieUwWHCzEDLWbN = "Xbox One Controller";

			private const int RJEYLkXjBazjYiDxKCzwHJYbRle = 0;

			private const int ybviqOgNXAwHQFldkAgXjSOiEKBD = 1;

			private const int VmvwBZMWCHRiiXITyqwtPXfAQnQ = 2;

			private const int oZTdhkunCOzqkYBvjExEKmvGjQK = 3;

			private const int tVBQpsdKdLRwfzLFpEcxzgiKFLue = 4;

			private const int SJbaVANPVfbBQISzQAqykweNooFT = 5;

			private const int ydAaIfkPyfSDDbAhkBEQVrgtPchD = 6;

			private const int PBIBttRCBcUSGqPSzdyIdCTRouk = 7;

			private const int pifFpNCwFHQnUEizOfYnRhXDlBse = 8;

			private const int JGKCoQXDvScpAGbfiFzngQhfnrKF = 9;

			private const int aSrUoeQvPLqATMQXqpWrprbjdIE = 12;

			private const int twpJHNihXvEoKSjoUuVxSranhjn = 13;

			private const int RhwkMvciVWWqySIPUDnonhAUEzj = 14;

			private const int HJLCKRZOgNtMWpqZNgIdKiNLJXi = 15;

			private const int TvqzRdPTMqlEMpjnIxNqpqZxFG = 0;

			private const int wWRDxkJboFVMwkixpRfGtEBtwEg = 1;

			private const int fKtFpcPPRgFoKKTiIGygdsNBxdZC = 3;

			private const int kyyZOYzIjlcFoavgHGasgnyHQjH = 4;

			private const int HyScAVFOrWcDUFIZkguiFZpnUPOd = 8;

			private const int itHuQSUOcvzHiJOqkCYJrrHZDpIb = 9;

			private readonly IXboxOneInputSource CpNbHtCijSICCnUFhUdnSnuZaCd;

			private int NwgZCoPcMAFocejfaTMgksjuPEtb;

			private ulong CoCeZQIEtDRCWBcWzqXXxFMtlTL;

			private string[] vvUGppAcYXonOEueXDnXKzJafXN;

			public ulong xboxControllerId
			{
				get
				{
					return CoCeZQIEtDRCWBcWzqXXxFMtlTL;
				}
			}

			public VrjTyZoECUUIfnXhabttsAzpAeW(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(isConnected ? UnityTools.externalTools.XboxOneInput_GetControllerType(xboxControllerId) : "Xbox One Controller", (long)xboxControllerId, unityJoystickId, 6, 14)
			{
				CpNbHtCijSICCnUFhUdnSnuZaCd = inputSource;
				NwgZCoPcMAFocejfaTMgksjuPEtb = unityJoystickId - 1;
				vvUGppAcYXonOEueXDnXKzJafXN = new string[6];
				QAPCoPutXwDtlfjJrcwThAGgZLjR();
				base.extension = new XboxOneGamepadExtension(true, inputSource);
				_isConnected = isConnected;
				if (_isConnected)
				{
					YJaAHaimrHWIfKrgfWxeihnqrcza(xboxControllerId);
				}
				else
				{
					CoCeZQIEtDRCWBcWzqXXxFMtlTL = xboxControllerId;
				}
			}

			public override void Update()
			{
				if (!_isConnected)
				{
					goto IL_0008;
				}
				goto IL_0070;
				IL_0008:
				int num = -1056211761;
				goto IL_000d;
				IL_000d:
				IList<Button> buttons = default(IList<Button>);
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					switch (num ^ -1056211763)
					{
					case 0:
						break;
					case 2:
						return;
					case 1:
						buttons[8].value = lvyTpewEByrJQaPpHiuasLSeNzw(8);
						buttons[9].value = lvyTpewEByrJQaPpHiuasLSeNzw(9);
						num = -1056211762;
						continue;
					case 6:
						goto IL_0070;
					case 3:
						buttons[10].value = lvyTpewEByrJQaPpHiuasLSeNzw(12);
						buttons[11].value = lvyTpewEByrJQaPpHiuasLSeNzw(15);
						buttons[12].value = lvyTpewEByrJQaPpHiuasLSeNzw(13);
						num = -1056211767;
						continue;
					case 4:
						buttons[13].value = lvyTpewEByrJQaPpHiuasLSeNzw(14);
						axes = base.Axes;
						axes[0].value = Input.GetAxisRaw(vvUGppAcYXonOEueXDnXKzJafXN[0]);
						axes[1].value = Input.GetAxisRaw(vvUGppAcYXonOEueXDnXKzJafXN[1]);
						axes[2].value = Input.GetAxisRaw(vvUGppAcYXonOEueXDnXKzJafXN[2]);
						num = -1056211768;
						continue;
					default:
						axes[3].value = Input.GetAxisRaw(vvUGppAcYXonOEueXDnXKzJafXN[3]);
						axes[4].value = Input.GetAxisRaw(vvUGppAcYXonOEueXDnXKzJafXN[4]);
						axes[5].value = Input.GetAxisRaw(vvUGppAcYXonOEueXDnXKzJafXN[5]);
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0070:
				buttons = base.Buttons;
				buttons[0].value = lvyTpewEByrJQaPpHiuasLSeNzw(0);
				buttons[1].value = lvyTpewEByrJQaPpHiuasLSeNzw(1);
				buttons[2].value = lvyTpewEByrJQaPpHiuasLSeNzw(2);
				buttons[3].value = lvyTpewEByrJQaPpHiuasLSeNzw(3);
				buttons[4].value = lvyTpewEByrJQaPpHiuasLSeNzw(4);
				buttons[5].value = lvyTpewEByrJQaPpHiuasLSeNzw(5);
				buttons[6].value = lvyTpewEByrJQaPpHiuasLSeNzw(6);
				buttons[7].value = lvyTpewEByrJQaPpHiuasLSeNzw(7);
				num = -1056211764;
				goto IL_000d;
			}

			public void YJaAHaimrHWIfKrgfWxeihnqrcza(ulong P_0)
			{
				if (_isConnected)
				{
					goto IL_0008;
				}
				goto IL_004d;
				IL_0008:
				int num = -2018520720;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ -2018520719)
					{
					case 5:
						break;
					case 1:
						return;
					case 0:
						_isConnected = false;
						return;
					case 6:
						goto IL_004d;
					case 3:
						if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
						{
							Logger.LogError("Unity joystick id does not match expected id!");
							num = -2018520719;
							continue;
						}
						goto default;
					case 2:
						CoCeZQIEtDRCWBcWzqXXxFMtlTL = P_0;
						base.systemId = (long)P_0;
						num = -2018520718;
						continue;
					default:
						vrtROXlgaeUcHBHqSIqBsWVBhQv();
						return;
					}
					break;
				}
				goto IL_0008;
				IL_004d:
				_isConnected = true;
				num = -2018520717;
				goto IL_000d;
			}

			private void vrtROXlgaeUcHBHqSIqBsWVBhQv()
			{
				if (_isConnected)
				{
					_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(CoCeZQIEtDRCWBcWzqXXxFMtlTL);
					goto IL_001e;
				}
				goto IL_003c;
				IL_003c:
				_customName = "Controller " + base.unityId;
				int num = -333299732;
				goto IL_0023;
				IL_001e:
				num = -333299729;
				goto IL_0023;
				IL_0023:
				switch (num ^ -333299730)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_003c;
				case 2:
					return;
				}
				goto IL_001e;
			}

			private bool lvyTpewEByrJQaPpHiuasLSeNzw(int P_0)
			{
				int key = 350 + P_0 + NwgZCoPcMAFocejfaTMgksjuPEtb * 20;
				return Input.GetKey((KeyCode)key);
			}

			private void QAPCoPutXwDtlfjJrcwThAGgZLjR()
			{
				vvUGppAcYXonOEueXDnXKzJafXN[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				while (true)
				{
					int num = -1386544054;
					while (true)
					{
						switch (num ^ -1386544053)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							vvUGppAcYXonOEueXDnXKzJafXN[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
							vvUGppAcYXonOEueXDnXKzJafXN[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
							vvUGppAcYXonOEueXDnXKzJafXN[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
							num = -1386544056;
							continue;
						case 3:
							vvUGppAcYXonOEueXDnXKzJafXN[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
							vvUGppAcYXonOEueXDnXKzJafXN[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
							num = -1386544055;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private const int MksvhpHFkpnQAZsxETKGyjQVofk = 8;

		private readonly bool WktzUSAcjulBYRNUcifkLEmijRhD;

		private bool vcHdmCElPotxGUPFlwmYBoiumQve;

		private Queue<bXmcTMfGwFwLLQZrIAsdJeUcWzy> QIJLkgXNPkoJsuNWoVMxvdgKYGZ;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public override bool isReady
		{
			get
			{
				return WktzUSAcjulBYRNUcifkLEmijRhD;
			}
		}

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				QIJLkgXNPkoJsuNWoVMxvdgKYGZ = new Queue<bXmcTMfGwFwLLQZrIAsdJeUcWzy>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = kWzBpAIAakIesbuGsYFjMIGuGdq((uint)num, true, out badConnectionReason);
					ulong xboxControllerId = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new VrjTyZoECUUIfnXhabttsAzpAeW(this, xboxControllerId, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += MQeqppLmuFFClKfqjGZhidlIQAb;
				WktzUSAcjulBYRNUcifkLEmijRhD = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (!WktzUSAcjulBYRNUcifkLEmijRhD)
			{
				return;
			}
			IList<Joystick> joysticks = default(IList<Joystick>);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				BDTeFhyViIWATqfkJBdOawJNAxbB();
				UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
				int num = -2136686378;
				while (true)
				{
					switch (num ^ -2136686377)
					{
					case 0:
						num = -2136686380;
						continue;
					case 3:
						break;
					case 2:
						joysticks[num2].Update();
						num2++;
						num = -2136686381;
						continue;
					case 1:
						joysticks = GetJoysticks();
						count = joysticks.Count;
						num2 = 0;
						num = -2136686381;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private void MQeqppLmuFFClKfqjGZhidlIQAb(uint P_0, bool P_1)
		{
			if (!WktzUSAcjulBYRNUcifkLEmijRhD)
			{
				return;
			}
			while (true)
			{
				if (P_0 == 0)
				{
					Logger.LogError("Invalid unity joystick id");
					break;
				}
				while (true)
				{
					IL_0049:
					int num;
					if (P_1)
					{
						BadConnectionReason badConnectionReason;
						if (kWzBpAIAakIesbuGsYFjMIGuGdq(P_0, true, out badConnectionReason))
						{
							uliOsomhfgBbVCFjbEfSohVOtdIo(P_0, true);
							num = 1449096727;
							goto IL_000e;
						}
						return;
					}
					goto IL_006f;
					IL_006f:
					int index = (int)(P_0 - 1);
					VrjTyZoECUUIfnXhabttsAzpAeW vrjTyZoECUUIfnXhabttsAzpAeW = GetJoysticks()[index] as VrjTyZoECUUIfnXhabttsAzpAeW;
					vrjTyZoECUUIfnXhabttsAzpAeW.Disconnect();
					OnJoystickDisconnected();
					num = 1449096720;
					goto IL_000e;
					IL_000e:
					while (true)
					{
						switch (num ^ 0x565F7613)
						{
						case 5:
							num = 1449096721;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_0049;
						case 4:
							return;
						case 0:
							goto IL_006f;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void uliOsomhfgBbVCFjbEfSohVOtdIo(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			VrjTyZoECUUIfnXhabttsAzpAeW vrjTyZoECUUIfnXhabttsAzpAeW = GetJoysticks()[index] as VrjTyZoECUUIfnXhabttsAzpAeW;
			while (true)
			{
				int num = 2136420439;
				while (true)
				{
					switch (num ^ 0x7F573056)
					{
					case 2:
						break;
					default:
						return;
					case 4:
						OnJoystickConnected();
						num = 2136420438;
						continue;
					case 3:
					{
						int num3;
						if (P_1)
						{
							num = 2136420434;
							num3 = num;
						}
						else
						{
							num = 2136420438;
							num3 = num;
						}
						continue;
					}
					case 1:
					{
						ulong num2 = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
						vrjTyZoECUUIfnXhabttsAzpAeW.YJaAHaimrHWIfKrgfWxeihnqrcza(num2);
						num = 2136420437;
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void BDTeFhyViIWATqfkJBdOawJNAxbB()
		{
			int num = QIJLkgXNPkoJsuNWoVMxvdgKYGZ.Count;
			if (num == 0)
			{
				goto IL_0012;
			}
			goto IL_00c3;
			IL_0012:
			int num2 = 1793538636;
			goto IL_0017;
			IL_0017:
			bXmcTMfGwFwLLQZrIAsdJeUcWzy item = default(bXmcTMfGwFwLLQZrIAsdJeUcWzy);
			uint currentFrame = default(uint);
			bool flag = default(bool);
			while (true)
			{
				switch (num2 ^ 0x6AE73A4F)
				{
				case 7:
					break;
				default:
					return;
				case 2:
					item = QIJLkgXNPkoJsuNWoVMxvdgKYGZ.Dequeue();
					if (currentFrame >= item.PfEGJlZJLohXMpnrEXVDellLDPS + 1)
					{
						BadConnectionReason badConnectionReason;
						if (kWzBpAIAakIesbuGsYFjMIGuGdq(item.aYpumKHzXlKGeinaYggEyjZraQSC, true, out badConnectionReason))
						{
							uliOsomhfgBbVCFjbEfSohVOtdIo(item.aYpumKHzXlKGeinaYggEyjZraQSC, false);
							flag = true;
							num2 = 1793538638;
							continue;
						}
						goto case 1;
					}
					goto case 5;
				case 4:
					if (num <= 0)
					{
						if (flag)
						{
							OnJoystickConnected();
							num2 = 1793538639;
							continue;
						}
						return;
					}
					goto case 2;
				case 6:
					currentFrame = ReInput.time.currentFrame;
					num2 = 1793538635;
					continue;
				case 3:
					return;
				case 8:
					goto IL_00c3;
				case 1:
					num--;
					num2 = 1793538635;
					continue;
				case 5:
					QIJLkgXNPkoJsuNWoVMxvdgKYGZ.Enqueue(item);
					num2 = 1793538638;
					continue;
				case 0:
					return;
				}
				break;
			}
			goto IL_0012;
			IL_00c3:
			flag = false;
			num2 = 1793538633;
			goto IL_0017;
		}

		private bool kWzBpAIAakIesbuGsYFjMIGuGdq(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			if (!UnityTools.externalTools.XboxOneInput_IsGamepadActive(P_0))
			{
				P_2 = BadConnectionReason.GamepadNotActive;
				return false;
			}
			string text = UnityTools.externalTools.XboxOneInput_GetControllerType(UnityTools.externalTools.XboxOneInput_GetControllerId(P_0));
			while (true)
			{
				int num = 1665590425;
				while (true)
				{
					switch (num ^ 0x6346E49A)
					{
					case 5:
						break;
					case 4:
						P_2 = BadConnectionReason.InvalidName;
						num = 1665590424;
						continue;
					case 1:
						QIJLkgXNPkoJsuNWoVMxvdgKYGZ.Enqueue(new bXmcTMfGwFwLLQZrIAsdJeUcWzy(P_0, ReInput.time.currentFrame));
						num = 1665590430;
						continue;
					case 0:
					{
						int num2;
						if (P_1)
						{
							num = 1665590427;
							num2 = num;
						}
						else
						{
							num = 1665590430;
							num2 = num;
						}
						continue;
					}
					case 3:
						if (!string.IsNullOrEmpty(text))
						{
							if (text == " ")
							{
								num = 1665590426;
								continue;
							}
							P_2 = BadConnectionReason.None;
							return true;
						}
						goto case 0;
					default:
						return false;
					}
					break;
				}
			}
		}

		private void iBsNbIZBBGNEoHmSPRSsyptZoWX()
		{
			if (!vcHdmCElPotxGUPFlwmYBoiumQve)
			{
				vcHdmCElPotxGUPFlwmYBoiumQve = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!WktzUSAcjulBYRNUcifkLEmijRhD)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (WktzUSAcjulBYRNUcifkLEmijRhD)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, lSVDqDVnIqWqaQvJeLzQNKaiGHr vibration)
		{
			if (!WktzUSAcjulBYRNUcifkLEmijRhD)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.LpDEvqwJlgQCmmOgNzfyiKukXOW, vibration.DLNcfFjLRRffvgHpOVGJwSJHDAW, vibration.NfiGsdhFACvFosWIwxcdFSUANOaB, vibration.IgxgWbRhBXmfdYnKFTlMuNVBENC);
		}

		public override void Dispose()
		{
			base.Dispose();
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~XboxOneInputSource()
		{
			Dispose(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				int num;
				if (disposing)
				{
					UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= MQeqppLmuFFClKfqjGZhidlIQAb;
					num = -1142157311;
					goto IL_000e;
				}
				goto IL_004b;
				IL_000e:
				while (true)
				{
					switch (num ^ -1142157310)
					{
					case 2:
						num = -1142157309;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						goto IL_004b;
					case 0:
						return;
					}
					break;
				}
				continue;
				IL_004b:
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				num = -1142157310;
				goto IL_000e;
			}
		}
	}
}
