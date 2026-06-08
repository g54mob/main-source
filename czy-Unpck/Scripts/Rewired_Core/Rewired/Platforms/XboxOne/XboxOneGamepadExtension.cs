using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class GggcVwfrkBOfMjuKYBQCwmdJmtmz : IControllerExtensionSource
		{
			public const int hSqMknHvfLaCaSKUtNrDJWiYQVX = 4;

			public fuZrdLLYfsbiIDndZbyZiLEjiMX HNqjLcwpeWgrvjovCNyEpBzQKZP;

			public readonly IXboxOneInputSource ptUIQrhqkpnVOSWehwLWSEigScO;

			public readonly bool gkkruTywtCSgfaMjHfnJvKIxFVy;

			public GggcVwfrkBOfMjuKYBQCwmdJmtmz(bool supportsVibration, IXboxOneInputSource xboxOneInputSource, fuZrdLLYfsbiIDndZbyZiLEjiMX vibrationData)
			{
				while (true)
				{
					int num = 1779421842;
					while (true)
					{
						switch (num ^ 0x6A0FD290)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						HNqjLcwpeWgrvjovCNyEpBzQKZP = vibrationData;
						ptUIQrhqkpnVOSWehwLWSEigScO = xboxOneInputSource;
						gkkruTywtCSgfaMjHfnJvKIxFVy = supportsVibration;
						num = 1779421841;
					}
				}
			}
		}

		private GggcVwfrkBOfMjuKYBQCwmdJmtmz QhiXIzSBnzSGaWwDVddQlyhdvkF;

		private TimerAbs[] zmxGOJkPYLhUdcrIkgYFpHzgdPkg;

		private Joystick joystick => GetController<Joystick>();

		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				int num;
				int num2;
				if (QhiXIzSBnzSGaWwDVddQlyhdvkF.ptUIQrhqkpnVOSWehwLWSEigScO == null)
				{
					num = 1863617922;
					num2 = num;
				}
				else
				{
					num = 1863617923;
					num2 = num;
				}
				goto IL_0012;
				IL_000d:
				num = 1863617920;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x6F148D82)
					{
					case 3:
						break;
					case 2:
						ReInput.CheckInitialized(_reInputId);
						return -1;
					case 1:
						if (joystick == null)
						{
							goto IL_0063;
						}
						return QhiXIzSBnzSGaWwDVddQlyhdvkF.ptUIQrhqkpnVOSWehwLWSEigScO.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
					default:
						return -1;
					}
					break;
					IL_0063:
					num = 1863617922;
				}
				goto IL_000d;
			}
		}

		public ulong xboxOneJoystickId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0uL;
				}
				if (joystick == null)
				{
					goto IL_0024;
				}
				long? systemId = joystick.systemId;
				int num = 13375285;
				goto IL_0029;
				IL_0029:
				switch (num ^ 0xCC1735)
				{
				case 2:
					break;
				case 1:
					return 0uL;
				default:
					if (!systemId.HasValue)
					{
						return 0uL;
					}
					return (ulong)systemId.Value;
				}
				goto IL_0024;
				IL_0024:
				num = 13375284;
				goto IL_0029;
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
			: base(new GggcVwfrkBOfMjuKYBQCwmdJmtmz(supportsVibration, xboxOneInputSource, default(fuZrdLLYfsbiIDndZbyZiLEjiMX)))
		{
			if (xboxOneInputSource == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[4];
			ArrayTools.Populate(zmxGOJkPYLhUdcrIkgYFpHzgdPkg, 0, zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension source)
			: base(source)
		{
			zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[4];
			ArrayTools.Populate(zmxGOJkPYLhUdcrIkgYFpHzgdPkg, 0, zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_0010;
			}
			goto IL_0094;
			IL_0010:
			int num = 1046620642;
			goto IL_0015;
			IL_0015:
			XboxOneGamepadMotorType motor = default(XboxOneGamepadMotorType);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x3E6229E3)
				{
				case 4:
					break;
				default:
					return;
				case 6:
					num = 1046620651;
					continue;
				case 0:
					motor = XboxOneGamepadMotorType.RightMotor;
					num = 1046620651;
					continue;
				case 10:
					goto IL_006d;
				case 3:
					throw new NotImplementedException();
				case 9:
					goto IL_0083;
				case 12:
					return;
				case 11:
					goto IL_0094;
				case 2:
					num2 = motorIndex;
					num = 1046620644;
					continue;
				case 7:
					switch (num2)
					{
					case 1:
						break;
					case 3:
						goto IL_006d;
					case 0:
						goto IL_0083;
					default:
						goto IL_00d2;
					case 2:
						goto IL_0108;
					}
					goto case 0;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 8:
					SetVibration(motor, motorLevel, duration, stopOtherMotors);
					num = 1046620646;
					continue;
				case 13:
					goto IL_0108;
				case 5:
					return;
					IL_0108:
					motor = XboxOneGamepadMotorType.LeftTriggerMotor;
					num = 1046620651;
					continue;
					IL_00d2:
					num = 1046620640;
					continue;
					IL_0083:
					motor = XboxOneGamepadMotorType.LeftMotor;
					num = 1046620651;
					continue;
					IL_006d:
					motor = XboxOneGamepadMotorType.RightTriggerMotor;
					num = 1046620645;
					continue;
				}
				break;
			}
			goto IL_0010;
			IL_0094:
			if (motorIndex < 0)
			{
				return;
			}
			int num3;
			if (motorIndex < 4)
			{
				num = 1046620641;
				num3 = num;
			}
			else
			{
				num = 1046620655;
				num3 = num;
			}
			goto IL_0015;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				while (true)
				{
					switch (0x40FAD31D ^ 0x40FAD31C)
					{
					case 0:
						continue;
					case 1:
						return 0f;
					}
					break;
				}
			}
			else
			{
				if (!QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
				{
					return 0f;
				}
				switch (motorIndex)
				{
				case 0:
					break;
				case 1:
					return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.VxZgBTvLcLhDLpcLzUhWPMfElMe;
				case 2:
					return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.HYwUfjBbbOpvGLyiZFSajsPZAQS;
				case 3:
					return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.WGbNQbRcuRIWFXqkkqqBXtxACGu;
				default:
					return 0f;
				}
			}
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.ZTRwmqcDYuawIFdUyiEvDZOHpXgi;
		}

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			if (QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					break;
				case XboxOneGamepadMotorType.RightMotor:
					return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.VxZgBTvLcLhDLpcLzUhWPMfElMe;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.HYwUfjBbbOpvGLyiZFSajsPZAQS;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.WGbNQbRcuRIWFXqkkqqBXtxACGu;
				default:
					throw new NotImplementedException();
				}
				goto IL_0087;
			}
			int num = -1877239668;
			goto IL_0012;
			IL_000d:
			num = -1877239665;
			goto IL_0012;
			IL_0087:
			return QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.ZTRwmqcDYuawIFdUyiEvDZOHpXgi;
			IL_0012:
			while (true)
			{
				switch (num ^ -1877239666)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					num = -1877239666;
					continue;
				case 2:
					return 0f;
				case 0:
					return 0f;
				default:
					goto IL_0087;
				}
				break;
			}
			goto IL_000d;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				while (true)
				{
					IL_0071:
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.pSJefhCsrsNBwQrMoByYJlhYCFur();
					int num = 0;
					int num2 = 1952916057;
					while (true)
					{
						switch (num2 ^ 0x7467225C)
						{
						case 3:
							num2 = 1952916061;
							continue;
						case 1:
							break;
						case 0:
							zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Clear();
							num++;
							num2 = 1952916057;
							continue;
						case 2:
							goto IL_0071;
						case 5:
							goto IL_008a;
						default:
							ZRUbQPIvJqpuQWbVoZmAIpoutAo();
							return;
						}
						break;
						IL_008a:
						int num3;
						if (num < 4)
						{
							num2 = 1952916060;
							num3 = num2;
						}
						else
						{
							num2 = 1952916056;
							num3 = num2;
						}
					}
					break;
				}
			}
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration)
		{
			SetVibration(motor, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			XboxOneGamepadMotorType xboxOneGamepadMotorType = default(XboxOneGamepadMotorType);
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
				{
					num = -495188938;
					num2 = num;
				}
				else
				{
					num = -495188931;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -495188932)
					{
					case 9:
						num = -495188929;
						continue;
					default:
						return;
					case 12:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.ZTRwmqcDYuawIFdUyiEvDZOHpXgi = motorLevel;
						num = -495188941;
						continue;
					case 4:
						goto IL_008e;
					case 7:
						motorLevel = MathTools.Clamp01(motorLevel);
						xboxOneGamepadMotorType = motor;
						num = -495188937;
						continue;
					case 11:
						switch (xboxOneGamepadMotorType)
						{
						case XboxOneGamepadMotorType.LeftMotor:
							break;
						case XboxOneGamepadMotorType.RightTriggerMotor:
							goto IL_008e;
						default:
							goto IL_00d3;
						case XboxOneGamepadMotorType.LeftTriggerMotor:
							goto IL_011a;
						case XboxOneGamepadMotorType.RightMotor:
							goto IL_0135;
						}
						goto case 12;
					case 14:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.pSJefhCsrsNBwQrMoByYJlhYCFur();
						num3 = 0;
						num = -495188932;
						continue;
					case 3:
						break;
					case 8:
						goto IL_011a;
					case 5:
						goto IL_0135;
					case 16:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num3].Clear();
						num3++;
						num = -495188932;
						continue;
					case 10:
					{
						int num5;
						if (stopOtherMotors)
						{
							num = -495188942;
							num5 = num;
						}
						else
						{
							num = -495188933;
							num5 = num;
						}
						continue;
					}
					case 0:
					{
						int num4;
						if (num3 >= 4)
						{
							num = -495188933;
							num4 = num;
						}
						else
						{
							num = -495188948;
							num4 = num;
						}
						continue;
					}
					case 15:
						TzfDwdqMmCsJvyIzIMpUAOlpgRjg(motor, motorLevel, duration);
						ZRUbQPIvJqpuQWbVoZmAIpoutAo();
						num = -495188943;
						continue;
					case 6:
						num = -495188941;
						continue;
					case 1:
						return;
					case 2:
						throw new NotImplementedException();
					case 13:
						return;
						IL_008e:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.WGbNQbRcuRIWFXqkkqqBXtxACGu = motorLevel;
						num = -495188941;
						continue;
						IL_0135:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.VxZgBTvLcLhDLpcLzUhWPMfElMe = motorLevel;
						num = -495188941;
						continue;
						IL_011a:
						QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.HYwUfjBbbOpvGLyiZFSajsPZAQS = motorLevel;
						num = -495188934;
						continue;
						IL_00d3:
						num = -495188930;
						continue;
					}
					break;
				}
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, stopOtherMotors: false);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_001c;
			}
			goto IL_00f2;
			IL_00f2:
			if (!QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				return;
			}
			goto IL_010a;
			IL_001c:
			int num = 785975916;
			goto IL_0021;
			IL_0021:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2ED90A6E)
				{
				case 6:
					break;
				case 3:
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num2].Clear();
					num2++;
					num = 785975919;
					continue;
				case 1:
					goto IL_006d;
				case 7:
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.ZTRwmqcDYuawIFdUyiEvDZOHpXgi = MathTools.Clamp01(leftMotorLevel);
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.VxZgBTvLcLhDLpcLzUhWPMfElMe = MathTools.Clamp01(rightMotorLevel);
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[0].Clear();
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[1].Clear();
					num = 785975915;
					continue;
				case 0:
					goto IL_00d2;
				case 8:
					goto IL_00f2;
				case 4:
					goto IL_010a;
				case 2:
					return;
				default:
					ZRUbQPIvJqpuQWbVoZmAIpoutAo();
					return;
				}
				break;
				IL_006d:
				int num3;
				if (num2 < 4)
				{
					num = 785975917;
					num3 = num;
				}
				else
				{
					num = 785975918;
					num3 = num;
				}
			}
			goto IL_001c;
			IL_010a:
			if (stopOtherMotors)
			{
				QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.pSJefhCsrsNBwQrMoByYJlhYCFur();
				num2 = 0;
				num = 785975919;
				goto IL_0021;
			}
			goto IL_00d2;
			IL_00d2:
			QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.rwZrfmghwmBtsbSKISPtTfrGCpc = xboxOneJoystickId;
			num = 785975913;
			goto IL_0021;
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				while (true)
				{
					IL_0070:
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.rwZrfmghwmBtsbSKISPtTfrGCpc = xboxOneJoystickId;
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.ZTRwmqcDYuawIFdUyiEvDZOHpXgi = MathTools.Clamp01(leftMotorLevel);
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.VxZgBTvLcLhDLpcLzUhWPMfElMe = MathTools.Clamp01(rightMotorLevel);
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.HYwUfjBbbOpvGLyiZFSajsPZAQS = MathTools.Clamp01(leftTriggerLevel);
					QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP.WGbNQbRcuRIWFXqkkqqBXtxACGu = MathTools.Clamp01(rightTriggerLevel);
					int num = 0;
					int num2 = 1561679639;
					while (true)
					{
						switch (num2 ^ 0x5D155716)
						{
						case 0:
							num2 = 1561679634;
							continue;
						case 4:
							break;
						case 3:
							zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Clear();
							num2 = 1561679635;
							continue;
						case 2:
							goto IL_0070;
						case 5:
							num++;
							num2 = 1561679639;
							continue;
						default:
							if (num >= 4)
							{
								ZRUbQPIvJqpuQWbVoZmAIpoutAo();
								return;
							}
							goto case 3;
						}
						break;
					}
					break;
				}
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_003b;
			IL_000d:
			int num = 710254615;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2A55A013)
				{
				case 6:
					break;
				case 5:
					goto IL_003b;
				case 0:
					return;
				case 1:
					goto IL_005c;
				case 2:
					return;
				case 4:
					ReInput.CheckInitialized(_reInputId);
					num = 710254611;
					continue;
				default:
					TzfDwdqMmCsJvyIzIMpUAOlpgRjg(motor, 0f, 0f);
					QhiXIzSBnzSGaWwDVddQlyhdvkF.ptUIQrhqkpnVOSWehwLWSEigScO.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
					return;
				}
				break;
				IL_005c:
				int num2;
				if (QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
				{
					num = 710254608;
					num2 = num;
				}
				else
				{
					num = 710254609;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_003b:
			int num3;
			if (!base.isJoystickConnected)
			{
				num = 710254609;
				num3 = num;
			}
			else
			{
				num = 710254610;
				num3 = num;
			}
			goto IL_0012;
		}

		internal void kckuoUXEwQcigNbCseRHnXueOkT(UpdateLoopType P_0)
		{
			adBKkIfVoFTvDlZNRkPVjUCCRov();
		}

		internal void fIBaXcnjmllWSuIUKZjDotVxWIx(IControllerExtensionSource P_0)
		{
			QhiXIzSBnzSGaWwDVddQlyhdvkF = P_0 as GggcVwfrkBOfMjuKYBQCwmdJmtmz;
		}

		internal Controller.Extension EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void adBKkIfVoFTvDlZNRkPVjUCCRov()
		{
			if (!QhiXIzSBnzSGaWwDVddQlyhdvkF.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = -79807079;
				while (true)
				{
					switch (num2 ^ -79807079)
					{
					case 3:
						num2 = -79807080;
						continue;
					case 4:
						num++;
						num2 = -79807079;
						continue;
					case 2:
						if (zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Update())
						{
							SetVibration(num, 0f, stopOtherMotors: false);
							num2 = -79807075;
							continue;
						}
						goto case 4;
					case 1:
						break;
					default:
						if (num >= 4)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private void TzfDwdqMmCsJvyIzIMpUAOlpgRjg(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
			int num;
			int num2;
			switch (P_0)
			{
			case XboxOneGamepadMotorType.RightTriggerMotor:
				num = 3;
				num2 = 1655458869;
				goto IL_0022;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				goto IL_009d;
			case XboxOneGamepadMotorType.RightMotor:
				goto IL_00b9;
			case XboxOneGamepadMotorType.LeftMotor:
				goto IL_00c5;
				IL_0022:
				while (true)
				{
					switch (num2 ^ 0x62AC4C32)
					{
					case 0:
						num2 = 1655458864;
						continue;
					case 6:
						num2 = 1655458869;
						continue;
					case 7:
						if (!(P_1 <= 0f))
						{
							goto IL_0066;
						}
						goto case 5;
					case 5:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Clear();
						return;
					case 1:
						break;
					case 8:
						goto IL_009d;
					case 3:
						goto end_IL_0003;
					case 9:
						goto IL_00b9;
					case 2:
						goto IL_00c5;
					default:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Start(P_2);
						return;
					}
					break;
					IL_0066:
					int num3;
					if (P_2 > 0f)
					{
						num2 = 1655458870;
						num3 = num2;
					}
					else
					{
						num2 = 1655458871;
						num3 = num2;
					}
				}
				goto case XboxOneGamepadMotorType.RightTriggerMotor;
				IL_00c5:
				num = 0;
				num2 = 1655458869;
				goto IL_0022;
				IL_00b9:
				num = 1;
				num2 = 1655458868;
				goto IL_0022;
				IL_009d:
				num = 2;
				num2 = 1655458869;
				goto IL_0022;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}

		private void ZRUbQPIvJqpuQWbVoZmAIpoutAo()
		{
			if (base.isJoystickConnected)
			{
				QhiXIzSBnzSGaWwDVddQlyhdvkF.ptUIQrhqkpnVOSWehwLWSEigScO.SetXboxOneVibration(xboxOneJoystickId, QhiXIzSBnzSGaWwDVddQlyhdvkF.HNqjLcwpeWgrvjovCNyEpBzQKZP);
			}
		}
	}
}
