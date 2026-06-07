using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class QoxnqedNaRRwbtmYzpLCDBISzMH : IControllerExtensionSource
		{
			public const int dFeMnzRTSNcMYNGuAWZUeFGTLNj = 4;

			public lSVDqDVnIqWqaQvJeLzQNKaiGHr NdFdLJgqEkQANUgOMbcjvMhqVCpT;

			public readonly IXboxOneInputSource xtEqWpphJfrugPgKOKqLznSjqto;

			public readonly bool wweKDPecOEKQRjeLwREKUOeenHA;

			public QoxnqedNaRRwbtmYzpLCDBISzMH(bool supportsVibration, IXboxOneInputSource xboxOneInputSource, lSVDqDVnIqWqaQvJeLzQNKaiGHr vibrationData)
			{
				NdFdLJgqEkQANUgOMbcjvMhqVCpT = vibrationData;
				xtEqWpphJfrugPgKOKqLznSjqto = xboxOneInputSource;
				wweKDPecOEKQRjeLwREKUOeenHA = supportsVibration;
			}
		}

		private QoxnqedNaRRwbtmYzpLCDBISzMH WVeuvvGVKxuwIVofyhIJOpLcDjb;

		private TimerAbs[] pSngNFXjFJqIDusOVrrEyDkmFgW;

		private Joystick joystick
		{
			get
			{
				return GetController<Joystick>();
			}
		}

		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (WVeuvvGVKxuwIVofyhIJOpLcDjb.xtEqWpphJfrugPgKOKqLznSjqto != null)
				{
					while (true)
					{
						int num = 1619895506;
						while (true)
						{
							switch (num ^ 0x608DA4D3)
							{
							case 0:
								break;
							case 1:
								goto IL_0046;
							default:
								goto end_IL_0028;
							}
							break;
							IL_0046:
							if (joystick == null)
							{
								num = 1619895505;
								continue;
							}
							return WVeuvvGVKxuwIVofyhIJOpLcDjb.xtEqWpphJfrugPgKOKqLznSjqto.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
						}
						continue;
						end_IL_0028:
						break;
					}
				}
				return -1;
			}
		}

		public ulong xboxOneJoystickId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					goto IL_0019;
				}
				int num;
				long? systemId = default(long?);
				if (joystick == null)
				{
					num = -1070746391;
				}
				else
				{
					systemId = joystick.systemId;
					num = -1070746392;
				}
				goto IL_001e;
				IL_0019:
				num = -1070746389;
				goto IL_001e;
				IL_001e:
				switch (num ^ -1070746390)
				{
				case 0:
					break;
				case 1:
					return 0uL;
				case 3:
					return 0uL;
				default:
					if (!systemId.HasValue)
					{
						return 0uL;
					}
					return (ulong)systemId.Value;
				}
				goto IL_0019;
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return 4;
			}
		}

		internal XboxOneGamepadExtension(bool supportsVibration, IXboxOneInputSource xboxOneInputSource)
			: base(new QoxnqedNaRRwbtmYzpLCDBISzMH(supportsVibration, xboxOneInputSource, default(lSVDqDVnIqWqaQvJeLzQNKaiGHr)))
		{
			while (true)
			{
				int num = -854892008;
				while (true)
				{
					switch (num ^ -854892007)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (xboxOneInputSource != null)
						{
							goto IL_004d;
						}
						throw new ArgumentNullException("xboxOneInputSource");
					case 2:
						goto IL_004d;
					case 0:
						return;
					}
					break;
					IL_004d:
					pSngNFXjFJqIDusOVrrEyDkmFgW = new TimerAbs[4];
					ArrayTools.Populate(pSngNFXjFJqIDusOVrrEyDkmFgW, 0, pSngNFXjFJqIDusOVrrEyDkmFgW.Length);
					num = -854892007;
				}
			}
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension source)
			: base(source)
		{
			pSngNFXjFJqIDusOVrrEyDkmFgW = new TimerAbs[4];
			ArrayTools.Populate(pSngNFXjFJqIDusOVrrEyDkmFgW, 0, pSngNFXjFJqIDusOVrrEyDkmFgW.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_001c;
			}
			goto IL_00ab;
			IL_00ab:
			int num;
			int num2;
			if (motorIndex < 0)
			{
				num = 675603417;
				num2 = num;
			}
			else
			{
				num = 675603422;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = 675603408;
			goto IL_0021;
			IL_0021:
			XboxOneGamepadMotorType motor = default(XboxOneGamepadMotorType);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x2844E3D8)
				{
				case 11:
					break;
				case 8:
					return;
				case 13:
					motor = XboxOneGamepadMotorType.LeftMotor;
					num = 675603409;
					continue;
				case 2:
					goto IL_007a;
				case 10:
					num = 675603423;
					continue;
				case 4:
					goto IL_008a;
				case 7:
					throw new NotImplementedException();
				case 1:
					return;
				case 3:
					goto IL_00ab;
				case 0:
					switch (num3)
					{
					case 0:
						break;
					case 2:
						goto IL_007a;
					case 1:
						goto IL_008a;
					default:
						goto IL_00d9;
					case 3:
						goto IL_00e3;
					}
					goto case 13;
				case 5:
					goto IL_00e3;
				case 6:
					goto IL_00ef;
				case 12:
					num3 = motorIndex;
					num = 675603416;
					continue;
				default:
					{
						SetVibration(motor, motorLevel, duration, stopOtherMotors);
						return;
					}
					IL_00e3:
					motor = XboxOneGamepadMotorType.RightTriggerMotor;
					num = 675603409;
					continue;
					IL_00d9:
					num = 675603410;
					continue;
					IL_008a:
					motor = XboxOneGamepadMotorType.RightMotor;
					num = 675603409;
					continue;
					IL_007a:
					motor = XboxOneGamepadMotorType.LeftTriggerMotor;
					num = 675603409;
					continue;
				}
				break;
				IL_00ef:
				int num4;
				if (motorIndex < 4)
				{
					num = 675603412;
					num4 = num;
				}
				else
				{
					num = 675603417;
					num4 = num;
				}
			}
			goto IL_001c;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				return 0f;
			}
			switch (motorIndex)
			{
			default:
				while (true)
				{
					switch (0x44853E9C ^ 0x44853E9E)
					{
					case 0:
						continue;
					case 2:
						return 0f;
					}
					break;
				}
				goto case 0;
			case 0:
				return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.LpDEvqwJlgQCmmOgNzfyiKukXOW;
			case 1:
				return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.DLNcfFjLRRffvgHpOVGJwSJHDAW;
			case 2:
				return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.NfiGsdhFACvFosWIwxcdFSUANOaB;
			case 3:
				return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.IgxgWbRhBXmfdYnKFTlMuNVBENC;
			}
		}

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			if (!WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				return 0f;
			}
			XboxOneGamepadMotorType xboxOneGamepadMotorType = motor;
			int num = 487096857;
			goto IL_0012;
			IL_000d:
			num = 487096859;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x1D08821A)
				{
				case 2:
					break;
				case 1:
					goto IL_0033;
				case 0:
					return 0f;
				case 3:
					switch (xboxOneGamepadMotorType)
					{
					case XboxOneGamepadMotorType.LeftMotor:
						break;
					case XboxOneGamepadMotorType.RightMotor:
						return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.DLNcfFjLRRffvgHpOVGJwSJHDAW;
					case XboxOneGamepadMotorType.LeftTriggerMotor:
						return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.NfiGsdhFACvFosWIwxcdFSUANOaB;
					case XboxOneGamepadMotorType.RightTriggerMotor:
						return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.IgxgWbRhBXmfdYnKFTlMuNVBENC;
					default:
						throw new NotImplementedException();
					}
					goto default;
				default:
					return WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.LpDEvqwJlgQCmmOgNzfyiKukXOW;
				}
				break;
				IL_0033:
				ReInput.CheckInitialized(_reInputId);
				num = 487096858;
			}
			goto IL_000d;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0043;
			IL_000d:
			int num = -1159252253;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1159252255)
				{
				case 6:
					break;
				case 8:
					goto IL_0043;
				case 1:
					num = -1159252250;
					continue;
				case 0:
					pSngNFXjFJqIDusOVrrEyDkmFgW[num2].Clear();
					num = -1159252251;
					continue;
				case 3:
					goto IL_0073;
				case 5:
					return;
				case 4:
					num2++;
					num = -1159252250;
					continue;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					num = -1159252252;
					continue;
				default:
					if (num2 >= 4)
					{
						JTAhuXWSuaNKiVjtBONLbjGlAMIj();
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_000d;
			IL_0073:
			WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.zmVPenaCrqxqQokFDJyPALOTRjY();
			num2 = 0;
			num = -1159252256;
			goto IL_0012;
			IL_0043:
			if (!WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				return;
			}
			goto IL_0073;
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, false);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration)
		{
			SetVibration(motor, motorLevel, duration, false);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0071;
			IL_000d:
			int num = 1752635555;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			XboxOneGamepadMotorType xboxOneGamepadMotorType = default(XboxOneGamepadMotorType);
			while (true)
			{
				switch (num ^ 0x687718AC)
				{
				case 3:
					break;
				case 6:
					num = 1752635563;
					continue;
				case 14:
					goto IL_0071;
				case 0:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.IgxgWbRhBXmfdYnKFTlMuNVBENC = motorLevel;
					num = 1752635559;
					continue;
				case 7:
					throw new NotImplementedException();
				case 10:
					pSngNFXjFJqIDusOVrrEyDkmFgW[num2].Clear();
					num = 1752635556;
					continue;
				case 8:
					num2++;
					num = 1752635560;
					continue;
				case 2:
					goto IL_00d6;
				case 15:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 13:
					goto IL_010b;
				case 17:
					goto IL_0126;
				case 5:
					goto IL_013a;
				case 4:
					goto IL_0155;
				case 12:
					switch (xboxOneGamepadMotorType)
					{
					case XboxOneGamepadMotorType.RightTriggerMotor:
						break;
					case XboxOneGamepadMotorType.RightMotor:
						goto IL_010b;
					case XboxOneGamepadMotorType.LeftMotor:
						goto IL_013a;
					default:
						goto IL_0183;
					case XboxOneGamepadMotorType.LeftTriggerMotor:
						goto IL_01a0;
					}
					goto case 0;
				case 11:
					PkvIixiBJQgzJxQXdAWDrKLgpHX(motor, motorLevel, duration);
					num = 1752635557;
					continue;
				case 16:
					goto IL_01a0;
				case 1:
					num2 = 0;
					num = 1752635560;
					continue;
				default:
					{
						JTAhuXWSuaNKiVjtBONLbjGlAMIj();
						return;
					}
					IL_01a0:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.NfiGsdhFACvFosWIwxcdFSUANOaB = motorLevel;
					num = 1752635559;
					continue;
					IL_0183:
					num = 1752635562;
					continue;
					IL_013a:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.LpDEvqwJlgQCmmOgNzfyiKukXOW = motorLevel;
					num = 1752635559;
					continue;
					IL_010b:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.DLNcfFjLRRffvgHpOVGJwSJHDAW = motorLevel;
					num = 1752635559;
					continue;
				}
				break;
				IL_0155:
				int num3;
				if (num2 >= 4)
				{
					num = 1752635581;
					num3 = num;
				}
				else
				{
					num = 1752635558;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_0126:
			motorLevel = MathTools.Clamp01(motorLevel);
			xboxOneGamepadMotorType = motor;
			num = 1752635552;
			goto IL_0012;
			IL_00d6:
			if (stopOtherMotors)
			{
				WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.zmVPenaCrqxqQokFDJyPALOTRjY();
				num = 1752635565;
				goto IL_0012;
			}
			goto IL_0126;
			IL_0071:
			if (!WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				return;
			}
			goto IL_00d6;
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, false);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num = default(int);
			while (WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				while (true)
				{
					int num2;
					if (stopOtherMotors)
					{
						WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.zmVPenaCrqxqQokFDJyPALOTRjY();
						num = 0;
						num2 = -1942643760;
						goto IL_0022;
					}
					goto IL_00be;
					IL_0022:
					while (true)
					{
						switch (num2 ^ -1942643756)
						{
						case 0:
							num2 = -1942643757;
							continue;
						case 1:
							pSngNFXjFJqIDusOVrrEyDkmFgW[num].Clear();
							num++;
							num2 = -1942643748;
							continue;
						case 8:
							break;
						case 2:
							goto end_IL_0022;
						case 7:
							goto end_IL_0087;
						case 3:
							goto IL_00be;
						case 4:
							num2 = -1942643748;
							continue;
						case 6:
							pSngNFXjFJqIDusOVrrEyDkmFgW[1].Clear();
							num2 = -1942643759;
							continue;
						case 9:
							WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.DLNcfFjLRRffvgHpOVGJwSJHDAW = MathTools.Clamp01(rightMotorLevel);
							pSngNFXjFJqIDusOVrrEyDkmFgW[0].Clear();
							num2 = -1942643758;
							continue;
						default:
							JTAhuXWSuaNKiVjtBONLbjGlAMIj();
							return;
						}
						int num3;
						if (num < 4)
						{
							num2 = -1942643755;
							num3 = num2;
						}
						else
						{
							num2 = -1942643753;
							num3 = num2;
						}
						continue;
						end_IL_0022:
						break;
					}
					continue;
					IL_00be:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.hCTGHaHaMaOxSseahZzkgyXXUuS = xboxOneJoystickId;
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.LpDEvqwJlgQCmmOgNzfyiKukXOW = MathTools.Clamp01(leftMotorLevel);
					num2 = -1942643747;
					goto IL_0022;
					continue;
					end_IL_0087:
					break;
				}
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_001c;
			}
			goto IL_0093;
			IL_0093:
			if (!WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				return;
			}
			goto IL_00ab;
			IL_001c:
			int num = 1789098966;
			goto IL_0021;
			IL_0021:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x6AA37BD0)
				{
				case 8:
					break;
				case 3:
					pSngNFXjFJqIDusOVrrEyDkmFgW[num2].Clear();
					num2++;
					num = 1789098964;
					continue;
				case 7:
					num2 = 0;
					num = 1789098964;
					continue;
				case 5:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.LpDEvqwJlgQCmmOgNzfyiKukXOW = MathTools.Clamp01(leftMotorLevel);
					num = 1789098960;
					continue;
				case 2:
					goto IL_0093;
				case 1:
					goto IL_00ab;
				case 0:
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.DLNcfFjLRRffvgHpOVGJwSJHDAW = MathTools.Clamp01(rightMotorLevel);
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.NfiGsdhFACvFosWIwxcdFSUANOaB = MathTools.Clamp01(leftTriggerLevel);
					WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.IgxgWbRhBXmfdYnKFTlMuNVBENC = MathTools.Clamp01(rightTriggerLevel);
					num = 1789098967;
					continue;
				case 6:
					return;
				default:
					if (num2 >= 4)
					{
						JTAhuXWSuaNKiVjtBONLbjGlAMIj();
						return;
					}
					goto case 3;
				}
				break;
			}
			goto IL_001c;
			IL_00ab:
			WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT.hCTGHaHaMaOxSseahZzkgyXXUuS = xboxOneJoystickId;
			num = 1789098965;
			goto IL_0021;
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (base.isJoystickConnected)
			{
				int num;
				int num2;
				if (WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
				{
					num = 348713271;
					num2 = num;
				}
				else
				{
					num = 348713269;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x14C8F134)
					{
					case 0:
						goto IL_001a;
					case 2:
						break;
					case 1:
						return;
					default:
						PkvIixiBJQgzJxQXdAWDrKLgpHX(motor, 0f, 0f);
						WVeuvvGVKxuwIVofyhIJOpLcDjb.xtEqWpphJfrugPgKOKqLznSjqto.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
						return;
					}
					break;
					IL_001a:
					num = 348713270;
				}
			}
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			qxBgmSGduLZblrclmRJKaMoDcVOA();
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
			WVeuvvGVKxuwIVofyhIJOpLcDjb = P_0 as QoxnqedNaRRwbtmYzpLCDBISzMH;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void qxBgmSGduLZblrclmRJKaMoDcVOA()
		{
			if (!WVeuvvGVKxuwIVofyhIJOpLcDjb.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = 1320622931;
				while (true)
				{
					switch (num2 ^ 0x4EB71B57)
					{
					case 0:
						num2 = 1320622933;
						continue;
					default:
						return;
					case 2:
						break;
					case 3:
						SetVibration(num, 0f, false);
						num2 = 1320622934;
						continue;
					case 5:
					{
						int num4;
						if (pSngNFXjFJqIDusOVrrEyDkmFgW[num].Update())
						{
							num2 = 1320622932;
							num4 = num2;
						}
						else
						{
							num2 = 1320622934;
							num4 = num2;
						}
						continue;
					}
					case 1:
						num++;
						num2 = 1320622931;
						continue;
					case 4:
					{
						int num3;
						if (num >= 4)
						{
							num2 = 1320622929;
							num3 = num2;
						}
						else
						{
							num2 = 1320622930;
							num3 = num2;
						}
						continue;
					}
					case 6:
						return;
					}
					break;
				}
			}
		}

		private void PkvIixiBJQgzJxQXdAWDrKLgpHX(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
			int num;
			int num2;
			switch (P_0)
			{
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				num = 2;
				num2 = -261061298;
				goto IL_001f;
			case XboxOneGamepadMotorType.RightMotor:
				goto IL_00b4;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				goto IL_00e3;
			case XboxOneGamepadMotorType.LeftMotor:
				goto IL_00ef;
				IL_001f:
				while (true)
				{
					switch (num2 ^ -261061299)
					{
					case 0:
						num2 = -261061307;
						continue;
					default:
						return;
					case 7:
						if (!(P_1 <= 0f))
						{
							goto IL_0067;
						}
						goto case 10;
					case 4:
						break;
					case 11:
						goto end_IL_0003;
					case 3:
						num2 = -261061302;
						continue;
					case 10:
						pSngNFXjFJqIDusOVrrEyDkmFgW[num].Clear();
						num2 = -261061308;
						continue;
					case 5:
						goto IL_00b4;
					case 6:
						pSngNFXjFJqIDusOVrrEyDkmFgW[num].Start(P_2);
						num2 = -261061297;
						continue;
					case 9:
						return;
					case 1:
						goto IL_00e3;
					case 8:
						goto IL_00ef;
					case 2:
						return;
					}
					break;
					IL_0067:
					int num3;
					if (P_2 <= 0f)
					{
						num2 = -261061305;
						num3 = num2;
					}
					else
					{
						num2 = -261061301;
						num3 = num2;
					}
				}
				goto case XboxOneGamepadMotorType.LeftTriggerMotor;
				IL_00ef:
				num = 0;
				num2 = -261061302;
				goto IL_001f;
				IL_00e3:
				num = 3;
				num2 = -261061302;
				goto IL_001f;
				IL_00b4:
				num = 1;
				num2 = -261061302;
				goto IL_001f;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}

		private void JTAhuXWSuaNKiVjtBONLbjGlAMIj()
		{
			if (base.isJoystickConnected)
			{
				WVeuvvGVKxuwIVofyhIJOpLcDjb.xtEqWpphJfrugPgKOKqLznSjqto.SetXboxOneVibration(xboxOneJoystickId, WVeuvvGVKxuwIVofyhIJOpLcDjb.NdFdLJgqEkQANUgOMbcjvMhqVCpT);
			}
		}
	}
}
