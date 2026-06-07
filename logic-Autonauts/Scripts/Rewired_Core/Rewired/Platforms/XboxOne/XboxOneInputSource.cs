using System;
using System.Collections.Generic;
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

		private struct YswxWFiPsJoiwlusenqzVnWwasjh
		{
			public uint RnlBjNghLbwrPGsjqIiGkLRxhBTf;

			public uint kEMlKwfGZuGyrAFmsZPJANbXdYPs;

			public YswxWFiPsJoiwlusenqzVnWwasjh(uint unityJoystickId, uint connectedFrame)
			{
				RnlBjNghLbwrPGsjqIiGkLRxhBTf = unityJoystickId;
				kEMlKwfGZuGyrAFmsZPJANbXdYPs = connectedFrame;
			}
		}

		private class gohKndSKKMrshLlCEvnvLuObTMj : Joystick
		{
			private const int yfaDuOCudrwZMrXpSXqZqDHADalE = 6;

			private const int UeRLAPucUgFPnuevKJOMpWmEUZW = 14;

			private const string FZYfYZcUVCCJVdGVCuFQAEFdXyOv = "Xbox One Controller";

			private const int wAxRppjlirOjiKgyNUcGmEDhAtn = 0;

			private const int JKhntNIpJUyclhhgAZmFMTQyiBO = 1;

			private const int eVxbEQgkCXYFHclIMDmtgcnGEqNC = 2;

			private const int PbLDkfKJKGvUXessHUtIvNtCLBP = 3;

			private const int EIRjmlBjjXNDKNmSJgStOEoIEEv = 4;

			private const int jRhEdFtsHpoYncBogkVkHsxDjCA = 5;

			private const int RCKfHcKlitqumMemSqGGIYoHvbaP = 6;

			private const int kNJKcwVbUTnVjWaCanHoIxMLjKz = 7;

			private const int WYvyoUGEDDSIjADcufEfgGDLSMlD = 8;

			private const int sWWfbBpFnQFSpVJaKEzzGvlbdcNV = 9;

			private const int PDjLrLynMJPwouFgEngWGdOjixL = 12;

			private const int MifWIWOFcjrefoHlgiPvnAqdBuu = 13;

			private const int eZsRHmGhPYxNFuMAakjaCNSUcoqI = 14;

			private const int wtFHjApxmJOCdLWOzwZvpbVJEWl = 15;

			private const int gBpdcENTUMNdbyqSFMhTFeoZmuB = 0;

			private const int DLYKBmjgdeqJxChbHKXbUeQDhrJ = 1;

			private const int SXlnuvpLDyiVhHnhenyifFRPikKD = 3;

			private const int ZjoUVNZMvxcgTUIfjWwmJAqJQiK = 4;

			private const int ioQxJAsnnIWohiPIKRagmInEFMXA = 8;

			private const int NPLDRVJmmbhwBgxzHOIVwIDuNqRB = 9;

			private readonly IXboxOneInputSource rsTYFamRrKtdrFcGFJzbrFwDZOs;

			private int yKqGDhHrAETHXtPwAnMaiBpAiBkC;

			private ulong hPONWTobfBtbftuPTkTRORErlGO;

			private string[] QNYqqcagMROYvaXtparBvEPoLqW;

			public ulong xboxControllerId
			{
				get
				{
					return hPONWTobfBtbftuPTkTRORErlGO;
				}
			}

			public gohKndSKKMrshLlCEvnvLuObTMj(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(isConnected ? UnityTools.externalTools.XboxOneInput_GetControllerType(xboxControllerId) : "Xbox One Controller", (long)xboxControllerId, unityJoystickId, 6, 14)
			{
				rsTYFamRrKtdrFcGFJzbrFwDZOs = inputSource;
				yKqGDhHrAETHXtPwAnMaiBpAiBkC = unityJoystickId - 1;
				QNYqqcagMROYvaXtparBvEPoLqW = new string[6];
				zbRdMWMbJaiQSHxALwcPdHWwcEme();
				base.extension = new XboxOneGamepadExtension(true, inputSource);
				_isConnected = isConnected;
				if (_isConnected)
				{
					dFyvOnKBbTYzKLbxHBbiIGdcrpeH(xboxControllerId);
				}
				else
				{
					hPONWTobfBtbftuPTkTRORErlGO = xboxControllerId;
				}
			}

			public override void Update()
			{
				if (!_isConnected)
				{
					goto IL_0008;
				}
				goto IL_005b;
				IL_0008:
				int num = -1924021320;
				goto IL_000d;
				IL_000d:
				IList<Button> buttons = default(IList<Button>);
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					switch (num ^ -1924021317)
					{
					case 6:
						break;
					default:
						return;
					case 5:
						buttons[1].value = OMsDoddGLoMsnAOixNusrDCoKsdq(1);
						num = -1924021313;
						continue;
					case 8:
						goto IL_005b;
					case 7:
						buttons[9].value = OMsDoddGLoMsnAOixNusrDCoKsdq(9);
						buttons[10].value = OMsDoddGLoMsnAOixNusrDCoKsdq(12);
						buttons[11].value = OMsDoddGLoMsnAOixNusrDCoKsdq(15);
						num = -1924021317;
						continue;
					case 4:
						buttons[2].value = OMsDoddGLoMsnAOixNusrDCoKsdq(2);
						buttons[3].value = OMsDoddGLoMsnAOixNusrDCoKsdq(3);
						buttons[4].value = OMsDoddGLoMsnAOixNusrDCoKsdq(4);
						buttons[5].value = OMsDoddGLoMsnAOixNusrDCoKsdq(5);
						buttons[6].value = OMsDoddGLoMsnAOixNusrDCoKsdq(6);
						buttons[7].value = OMsDoddGLoMsnAOixNusrDCoKsdq(7);
						buttons[8].value = OMsDoddGLoMsnAOixNusrDCoKsdq(8);
						num = -1924021316;
						continue;
					case 0:
						buttons[12].value = OMsDoddGLoMsnAOixNusrDCoKsdq(13);
						buttons[13].value = OMsDoddGLoMsnAOixNusrDCoKsdq(14);
						axes = base.Axes;
						axes[0].value = Input.GetAxisRaw(QNYqqcagMROYvaXtparBvEPoLqW[0]);
						num = -1924021318;
						continue;
					case 1:
						axes[1].value = Input.GetAxisRaw(QNYqqcagMROYvaXtparBvEPoLqW[1]);
						axes[2].value = Input.GetAxisRaw(QNYqqcagMROYvaXtparBvEPoLqW[2]);
						axes[3].value = Input.GetAxisRaw(QNYqqcagMROYvaXtparBvEPoLqW[3]);
						axes[4].value = Input.GetAxisRaw(QNYqqcagMROYvaXtparBvEPoLqW[4]);
						axes[5].value = Input.GetAxisRaw(QNYqqcagMROYvaXtparBvEPoLqW[5]);
						num = -1924021319;
						continue;
					case 3:
						return;
					case 2:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_005b:
				buttons = base.Buttons;
				buttons[0].value = OMsDoddGLoMsnAOixNusrDCoKsdq(0);
				num = -1924021314;
				goto IL_000d;
			}

			public void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(ulong P_0)
			{
				if (_isConnected)
				{
					return;
				}
				while (true)
				{
					_isConnected = true;
					hPONWTobfBtbftuPTkTRORErlGO = P_0;
					base.systemId = (long)P_0;
					int num;
					int num2;
					if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) == (uint)base.unityId)
					{
						num = -1772990816;
						num2 = num;
					}
					else
					{
						num = -1772990815;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1772990813)
						{
						case 0:
							goto IL_0009;
						case 1:
							break;
						case 2:
							Logger.LogError("Unity joystick id does not match expected id!");
							_isConnected = false;
							return;
						default:
							IFpGKVXFaghSybCWgGXRHKOZiWN();
							return;
						}
						break;
						IL_0009:
						num = -1772990814;
					}
				}
			}

			private void IFpGKVXFaghSybCWgGXRHKOZiWN()
			{
				if (_isConnected)
				{
					while (true)
					{
						int num = 1335799969;
						while (true)
						{
							switch (num ^ 0x4F9EB0A0)
							{
							case 0:
								break;
							case 1:
								_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(hPONWTobfBtbftuPTkTRORErlGO);
								num = 1335799970;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				_customName = "Controller " + base.unityId;
			}

			private bool OMsDoddGLoMsnAOixNusrDCoKsdq(int P_0)
			{
				int key = 350 + P_0 + yKqGDhHrAETHXtPwAnMaiBpAiBkC * 20;
				return Input.GetKey((KeyCode)key);
			}

			private void zbRdMWMbJaiQSHxALwcPdHWwcEme()
			{
				QNYqqcagMROYvaXtparBvEPoLqW[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				QNYqqcagMROYvaXtparBvEPoLqW[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				QNYqqcagMROYvaXtparBvEPoLqW[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				QNYqqcagMROYvaXtparBvEPoLqW[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				QNYqqcagMROYvaXtparBvEPoLqW[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				QNYqqcagMROYvaXtparBvEPoLqW[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}
		}

		private const int zYaaggCrsbTjjHbumjISeFQeBehL = 8;

		private readonly bool fxzgZHdorylahBrNCBxmuceoqOgc;

		private bool IKZtnZVFLgmMtvnYNbqYcZasfXsb;

		private Queue<YswxWFiPsJoiwlusenqzVnWwasjh> hZRervxRBaReZIoNYBGtgMkSxRQd;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public override bool isReady
		{
			get
			{
				return fxzgZHdorylahBrNCBxmuceoqOgc;
			}
		}

		public XboxOneInputSource()
			: base(21)
		{
			try
			{
				hZRervxRBaReZIoNYBGtgMkSxRQd = new Queue<YswxWFiPsJoiwlusenqzVnWwasjh>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					BadConnectionReason badConnectionReason;
					bool flag = DkpKseqKCazTBJjnSSuprnSoRAz((uint)num, true, out badConnectionReason);
					ulong xboxControllerId = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
					AddJoystick(new gohKndSKKMrshLlCEvnvLuObTMj(this, xboxControllerId, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += fpwdwlvgQHwEHebNDUbKNbYYLyL;
				fxzgZHdorylahBrNCBxmuceoqOgc = true;
			}
			catch
			{
			}
		}

		public override void Update()
		{
			if (!fxzgZHdorylahBrNCBxmuceoqOgc)
			{
				return;
			}
			IList<Joystick> joysticks = default(IList<Joystick>);
			int count = default(int);
			int num2 = default(int);
			while (true)
			{
				wEFoCeAXoUSnyGizzvbCPSVFcwq();
				int num = 157853524;
				while (true)
				{
					switch (num ^ 0x968A757)
					{
					case 4:
						num = 157853525;
						continue;
					case 2:
						break;
					case 3:
						UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
						joysticks = GetJoysticks();
						count = joysticks.Count;
						num2 = 0;
						num = 157853527;
						continue;
					case 1:
						joysticks[num2].Update();
						num2++;
						num = 157853527;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private void fpwdwlvgQHwEHebNDUbKNbYYLyL(uint P_0, bool P_1)
		{
			if (!fxzgZHdorylahBrNCBxmuceoqOgc)
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
					IL_0066:
					if (!P_1)
					{
						while (true)
						{
							IL_0049:
							int index = (int)(P_0 - 1);
							gohKndSKKMrshLlCEvnvLuObTMj gohKndSKKMrshLlCEvnvLuObTMj2 = GetJoysticks()[index] as gohKndSKKMrshLlCEvnvLuObTMj;
							int num = -1461178945;
							while (true)
							{
								switch (num ^ -1461178946)
								{
								case 0:
									num = -1461178947;
									continue;
								default:
									return;
								case 3:
									break;
								case 2:
									goto IL_0049;
								case 5:
									goto IL_0066;
								case 1:
									gohKndSKKMrshLlCEvnvLuObTMj2.Disconnect();
									OnJoystickDisconnected();
									num = -1461178950;
									continue;
								case 4:
									return;
								}
								break;
							}
							break;
						}
						break;
					}
					BadConnectionReason badConnectionReason;
					if (DkpKseqKCazTBJjnSSuprnSoRAz(P_0, true, out badConnectionReason))
					{
						LtafrhIiriaYelsmJcdKCSHExiFH(P_0, true);
					}
					return;
				}
			}
		}

		private void LtafrhIiriaYelsmJcdKCSHExiFH(uint P_0, bool P_1)
		{
			int index = (int)(P_0 - 1);
			gohKndSKKMrshLlCEvnvLuObTMj gohKndSKKMrshLlCEvnvLuObTMj2 = default(gohKndSKKMrshLlCEvnvLuObTMj);
			while (true)
			{
				int num = -2072773180;
				while (true)
				{
					switch (num ^ -2072773177)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						gohKndSKKMrshLlCEvnvLuObTMj2 = GetJoysticks()[index] as gohKndSKKMrshLlCEvnvLuObTMj;
						num = -2072773177;
						continue;
					case 0:
					{
						ulong num2 = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
						gohKndSKKMrshLlCEvnvLuObTMj2.dFyvOnKBbTYzKLbxHBbiIGdcrpeH(num2);
						if (P_1)
						{
							OnJoystickConnected();
							num = -2072773178;
							continue;
						}
						return;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void wEFoCeAXoUSnyGizzvbCPSVFcwq()
		{
			int num = hZRervxRBaReZIoNYBGtgMkSxRQd.Count;
			if (num == 0)
			{
				goto IL_000f;
			}
			goto IL_005f;
			IL_000f:
			int num2 = 1850405386;
			goto IL_0014;
			IL_0014:
			bool flag = default(bool);
			YswxWFiPsJoiwlusenqzVnWwasjh item = default(YswxWFiPsJoiwlusenqzVnWwasjh);
			uint currentFrame = default(uint);
			while (true)
			{
				switch (num2 ^ 0x6E4AF208)
				{
				case 5:
					break;
				default:
					return;
				case 1:
					if (flag)
					{
						OnJoystickConnected();
						num2 = 1850405384;
						continue;
					}
					return;
				case 7:
					goto IL_005f;
				case 2:
					return;
				case 3:
					LtafrhIiriaYelsmJcdKCSHExiFH(item.RnlBjNghLbwrPGsjqIiGkLRxhBTf, false);
					flag = true;
					num2 = 1850405377;
					continue;
				case 4:
					hZRervxRBaReZIoNYBGtgMkSxRQd.Enqueue(item);
					num2 = 1850405377;
					continue;
				case 9:
					num--;
					num2 = 1850405376;
					continue;
				case 8:
					goto IL_00b6;
				case 6:
					item = hZRervxRBaReZIoNYBGtgMkSxRQd.Dequeue();
					if (currentFrame < item.kEMlKwfGZuGyrAFmsZPJANbXdYPs + 1)
					{
						goto case 4;
					}
					goto IL_00e6;
				case 0:
					return;
				}
				break;
				IL_00e6:
				BadConnectionReason badConnectionReason;
				int num3;
				if (!DkpKseqKCazTBJjnSSuprnSoRAz(item.RnlBjNghLbwrPGsjqIiGkLRxhBTf, true, out badConnectionReason))
				{
					num2 = 1850405377;
					num3 = num2;
				}
				else
				{
					num2 = 1850405387;
					num3 = num2;
				}
				continue;
				IL_00b6:
				int num4;
				if (num <= 0)
				{
					num2 = 1850405385;
					num4 = num2;
				}
				else
				{
					num2 = 1850405390;
					num4 = num2;
				}
			}
			goto IL_000f;
			IL_005f:
			flag = false;
			currentFrame = ReInput.time.currentFrame;
			num2 = 1850405376;
			goto IL_0014;
		}

		private bool DkpKseqKCazTBJjnSSuprnSoRAz(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			if (!UnityTools.externalTools.XboxOneInput_IsGamepadActive(P_0))
			{
				P_2 = BadConnectionReason.GamepadNotActive;
				goto IL_0010;
			}
			string text = UnityTools.externalTools.XboxOneInput_GetControllerType(UnityTools.externalTools.XboxOneInput_GetControllerId(P_0));
			int num;
			if (!string.IsNullOrEmpty(text))
			{
				if (text == " ")
				{
					num = -964712231;
					goto IL_0015;
				}
				P_2 = BadConnectionReason.None;
				return true;
			}
			goto IL_0040;
			IL_0010:
			num = -964712232;
			goto IL_0015;
			IL_0015:
			switch (num ^ -964712230)
			{
			case 4:
				break;
			case 1:
				goto IL_0036;
			case 3:
				goto IL_0040;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_0010;
			IL_0040:
			if (P_1)
			{
				hZRervxRBaReZIoNYBGtgMkSxRQd.Enqueue(new YswxWFiPsJoiwlusenqzVnWwasjh(P_0, ReInput.time.currentFrame));
				num = -964712229;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0036:
			P_2 = BadConnectionReason.InvalidName;
			num = -964712230;
			goto IL_0015;
		}

		private void NjyDyZdtXMdlLbxVnGWkLKlBODC()
		{
			if (!IKZtnZVFLgmMtvnYNbqYcZasfXsb)
			{
				IKZtnZVFLgmMtvnYNbqYcZasfXsb = true;
				Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
			}
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!fxzgZHdorylahBrNCBxmuceoqOgc)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (!fxzgZHdorylahBrNCBxmuceoqOgc)
			{
				return;
			}
			while (true)
			{
				ulong durationMS = (ulong)(duration * 1000f);
				int num = -2084602364;
				while (true)
				{
					switch (num ^ -2084602362)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
						return;
					}
					break;
					IL_0009:
					num = -2084602361;
				}
			}
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, UPBDAOvxMubxPuCIWMPOgwacbBs vibration)
		{
			if (!fxzgZHdorylahBrNCBxmuceoqOgc)
			{
				return false;
			}
			return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.sRRZbnUlyebNsUdNjxgfFkluEDr, vibration.oyLgKWFONRKvIQNgyEcZFvJRPSJ, vibration.cbgBrogdUYIeVCkXWKehqdEMqRne, vibration.vCzzTubfFTTSUcxBpROODeVRhZH);
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
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = -735460464;
			goto IL_000d;
			IL_000d:
			switch (num ^ -735460463)
			{
			case 3:
				break;
			default:
				return;
			case 4:
				goto IL_002e;
			case 2:
				goto IL_003c;
			case 1:
				return;
			case 0:
				return;
			}
			goto IL_0008;
			IL_003c:
			if (disposing)
			{
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= fpwdwlvgQHwEHebNDUbKNbYYLyL;
				num = -735460459;
				goto IL_000d;
			}
			goto IL_002e;
			IL_002e:
			QQqHByfwytAJSuMZiCPjJlZYHKG = true;
			num = -735460463;
			goto IL_000d;
		}
	}
}
