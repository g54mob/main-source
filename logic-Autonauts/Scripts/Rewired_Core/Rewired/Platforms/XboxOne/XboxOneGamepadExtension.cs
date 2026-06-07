using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class beaqTtVRoXqmVNzrJtrRePhOuzJ : IControllerExtensionSource
		{
			public const int QTcZLynCWHLLppDxcAAAPxKXLEc = 4;

			public UPBDAOvxMubxPuCIWMPOgwacbBs clBTKGSxGawtcErRcukttOhcYTq;

			public readonly IXboxOneInputSource IpSnymFRXnKSRjjNqsxPSQMvpLt;

			public readonly bool JgidXSSSAGvvkDcAIVICtlmgnKR;

			public beaqTtVRoXqmVNzrJtrRePhOuzJ(bool supportsVibration, IXboxOneInputSource xboxOneInputSource, UPBDAOvxMubxPuCIWMPOgwacbBs vibrationData)
			{
				while (true)
				{
					int num = 1388821942;
					while (true)
					{
						switch (num ^ 0x52C7BDB7)
						{
						case 2:
							break;
						case 1:
							goto IL_0024;
						default:
							IpSnymFRXnKSRjjNqsxPSQMvpLt = xboxOneInputSource;
							JgidXSSSAGvvkDcAIVICtlmgnKR = supportsVibration;
							return;
						}
						break;
						IL_0024:
						clBTKGSxGawtcErRcukttOhcYTq = vibrationData;
						num = 1388821943;
					}
				}
			}
		}

		private beaqTtVRoXqmVNzrJtrRePhOuzJ pjmDqcGcEdmXbvnkITKNjUFiEooD;

		private TimerAbs[] EKvpQGhJhXJTuQtvfhYGZZMoAhR;

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
				if (pjmDqcGcEdmXbvnkITKNjUFiEooD.IpSnymFRXnKSRjjNqsxPSQMvpLt == null || joystick == null)
				{
					return -1;
				}
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.IpSnymFRXnKSRjjNqsxPSQMvpLt.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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
					return 0uL;
				}
				long? systemId = joystick.systemId;
				if (!systemId.HasValue)
				{
					return 0uL;
				}
				return (ulong)systemId.Value;
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
			: base(new beaqTtVRoXqmVNzrJtrRePhOuzJ(supportsVibration, xboxOneInputSource, default(UPBDAOvxMubxPuCIWMPOgwacbBs)))
		{
			while (true)
			{
				int num = -582095928;
				while (true)
				{
					switch (num ^ -582095925)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						if (xboxOneInputSource != null)
						{
							goto IL_004d;
						}
						throw new ArgumentNullException("xboxOneInputSource");
					case 1:
						goto IL_004d;
					case 2:
						return;
					}
					break;
					IL_004d:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR = new TimerAbs[4];
					ArrayTools.Populate(EKvpQGhJhXJTuQtvfhYGZZMoAhR, 0, EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length);
					num = -582095927;
				}
			}
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension source)
			: base(source)
		{
			EKvpQGhJhXJTuQtvfhYGZZMoAhR = new TimerAbs[4];
			ArrayTools.Populate(EKvpQGhJhXJTuQtvfhYGZZMoAhR, 0, EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length);
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
				goto IL_0010;
			}
			goto IL_00f0;
			IL_0010:
			int num = 1462969999;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			XboxOneGamepadMotorType motor = default(XboxOneGamepadMotorType);
			while (true)
			{
				switch (num ^ 0x5733268D)
				{
				case 12:
					break;
				case 5:
					num = 1462969988;
					continue;
				case 1:
					num2 = motorIndex;
					num = 1462969997;
					continue;
				case 3:
					motor = XboxOneGamepadMotorType.LeftTriggerMotor;
					num = 1462969992;
					continue;
				case 8:
					return;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 0:
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00a8;
					case 3:
						goto IL_00b2;
					case 0:
						goto IL_00be;
					case 1:
						goto IL_00e4;
					}
					goto case 3;
				case 7:
					goto IL_00b2;
				case 13:
					goto IL_00be;
				case 11:
					throw new NotImplementedException();
				case 10:
					num = 1462969988;
					continue;
				case 6:
					goto IL_00e4;
				case 4:
					goto IL_00f0;
				default:
					{
						SetVibration(motor, motorLevel, duration, stopOtherMotors);
						return;
					}
					IL_00e4:
					motor = XboxOneGamepadMotorType.RightMotor;
					num = 1462969991;
					continue;
					IL_00be:
					motor = XboxOneGamepadMotorType.LeftMotor;
					num = 1462969988;
					continue;
					IL_00b2:
					motor = XboxOneGamepadMotorType.RightTriggerMotor;
					num = 1462969988;
					continue;
					IL_00a8:
					num = 1462969990;
					continue;
				}
				break;
			}
			goto IL_0010;
			IL_00f0:
			if (motorIndex < 0)
			{
				return;
			}
			int num3;
			if (motorIndex < 4)
			{
				num = 1462969996;
				num3 = num;
			}
			else
			{
				num = 1462969989;
				num3 = num;
			}
			goto IL_0015;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				return 0f;
			}
			switch (motorIndex)
			{
			case 0:
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.sRRZbnUlyebNsUdNjxgfFkluEDr;
			case 1:
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.oyLgKWFONRKvIQNgyEcZFvJRPSJ;
			case 2:
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.cbgBrogdUYIeVCkXWKehqdEMqRne;
			case 3:
				return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.vCzzTubfFTTSUcxBpROODeVRhZH;
			default:
				return 0f;
			}
		}

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			if (!pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				return 0f;
			}
			XboxOneGamepadMotorType xboxOneGamepadMotorType = motor;
			int num = -1296588239;
			goto IL_001e;
			IL_0019:
			num = -1296588237;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1296588238)
				{
				case 2:
					break;
				case 3:
					switch (xboxOneGamepadMotorType)
					{
					default:
						goto IL_0061;
					case XboxOneGamepadMotorType.LeftMotor:
						break;
					case XboxOneGamepadMotorType.RightMotor:
						return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.oyLgKWFONRKvIQNgyEcZFvJRPSJ;
					case XboxOneGamepadMotorType.LeftTriggerMotor:
						return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.cbgBrogdUYIeVCkXWKehqdEMqRne;
					case XboxOneGamepadMotorType.RightTriggerMotor:
						return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.vCzzTubfFTTSUcxBpROODeVRhZH;
					}
					goto default;
				case 1:
					return 0f;
				default:
					return pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.sRRZbnUlyebNsUdNjxgfFkluEDr;
				case 0:
					throw new NotImplementedException();
				}
				break;
				IL_0061:
				num = -1296588238;
			}
			goto IL_0019;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_007c;
			IL_000d:
			int num = 302268844;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x120441AD)
				{
				case 6:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 2:
					goto IL_004f;
				case 5:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR[num2].Clear();
					num2++;
					num = 302268847;
					continue;
				case 0:
					goto IL_007c;
				case 3:
					goto IL_0091;
				default:
					oQYQtKoYamPnNvXsnnJBSQOnAXZ();
					return;
				}
				break;
				IL_004f:
				int num3;
				if (num2 >= 4)
				{
					num = 302268841;
					num3 = num;
				}
				else
				{
					num = 302268840;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_007c:
			if (!pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				return;
			}
			goto IL_0091;
			IL_0091:
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.UQHOCoKIKmYWhCUtfVaHxiRBbED();
			num2 = 0;
			num = 302268847;
			goto IL_0012;
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
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num = default(int);
			XboxOneGamepadMotorType xboxOneGamepadMotorType = default(XboxOneGamepadMotorType);
			while (pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				while (true)
				{
					IL_015c:
					int num2;
					if (stopOtherMotors)
					{
						pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.UQHOCoKIKmYWhCUtfVaHxiRBbED();
						num = 0;
						num2 = 795385800;
						goto IL_001f;
					}
					goto IL_011d;
					IL_001f:
					while (true)
					{
						switch (num2 ^ 0x2F689FCF)
						{
						case 12:
							num2 = 795385793;
							continue;
						case 14:
							break;
						case 4:
							pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.sRRZbnUlyebNsUdNjxgfFkluEDr = motorLevel;
							num2 = 795385801;
							continue;
						case 5:
							EKvpQGhJhXJTuQtvfhYGZZMoAhR[num].Clear();
							num++;
							num2 = 795385804;
							continue;
						case 13:
							switch (xboxOneGamepadMotorType)
							{
							case XboxOneGamepadMotorType.LeftMotor:
								break;
							default:
								goto IL_00cc;
							case XboxOneGamepadMotorType.RightMotor:
								goto IL_0102;
							case XboxOneGamepadMotorType.LeftTriggerMotor:
								goto IL_0131;
							case XboxOneGamepadMotorType.RightTriggerMotor:
								goto IL_017c;
							}
							goto case 4;
						case 8:
							num2 = 795385806;
							continue;
						case 7:
							num2 = 795385804;
							continue;
						case 3:
							goto IL_00ea;
						case 0:
							goto IL_0102;
						case 9:
							goto IL_011d;
						case 2:
							goto IL_0131;
						case 1:
							throw new NotImplementedException();
						case 10:
							goto IL_015c;
						case 11:
							goto IL_017c;
						default:
							{
								uvdRZwKNKWMEiNFUBKZVMFXyWAY(motor, motorLevel, duration);
								oQYQtKoYamPnNvXsnnJBSQOnAXZ();
								return;
							}
							IL_017c:
							pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.vCzzTubfFTTSUcxBpROODeVRhZH = motorLevel;
							num2 = 795385801;
							continue;
							IL_0131:
							pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.cbgBrogdUYIeVCkXWKehqdEMqRne = motorLevel;
							num2 = 795385801;
							continue;
							IL_0102:
							pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.oyLgKWFONRKvIQNgyEcZFvJRPSJ = motorLevel;
							num2 = 795385801;
							continue;
							IL_00cc:
							num2 = 795385799;
							continue;
						}
						break;
						IL_00ea:
						int num3;
						if (num < 4)
						{
							num2 = 795385802;
							num3 = num2;
						}
						else
						{
							num2 = 795385798;
							num3 = num2;
						}
					}
					break;
					IL_011d:
					motorLevel = MathTools.Clamp01(motorLevel);
					xboxOneGamepadMotorType = motor;
					num2 = 795385794;
					goto IL_001f;
				}
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, false);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_0010;
			}
			goto IL_0114;
			IL_0010:
			int num = -264936223;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -264936224)
				{
				case 5:
					break;
				default:
					return;
				case 7:
					goto IL_0049;
				case 3:
					num = -264936220;
					continue;
				case 4:
					goto IL_00bf;
				case 8:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR[num2].Clear();
					num2++;
					num = -264936220;
					continue;
				case 0:
					goto IL_00f2;
				case 6:
					goto IL_0114;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 2:
					return;
				}
				break;
				IL_00bf:
				int num3;
				if (num2 >= 4)
				{
					num = -264936217;
					num3 = num;
				}
				else
				{
					num = -264936216;
					num3 = num;
				}
			}
			goto IL_0010;
			IL_0049:
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.SdDcMpiCAoeUdyGrZHpsBLJVrBJd = xboxOneJoystickId;
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.sRRZbnUlyebNsUdNjxgfFkluEDr = MathTools.Clamp01(leftMotorLevel);
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.oyLgKWFONRKvIQNgyEcZFvJRPSJ = MathTools.Clamp01(rightMotorLevel);
			EKvpQGhJhXJTuQtvfhYGZZMoAhR[0].Clear();
			EKvpQGhJhXJTuQtvfhYGZZMoAhR[1].Clear();
			oQYQtKoYamPnNvXsnnJBSQOnAXZ();
			num = -264936222;
			goto IL_0015;
			IL_0114:
			if (!pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				return;
			}
			goto IL_00f2;
			IL_00f2:
			if (stopOtherMotors)
			{
				pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.UQHOCoKIKmYWhCUtfVaHxiRBbED();
				num2 = 0;
				num = -264936221;
				goto IL_0015;
			}
			goto IL_0049;
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0059;
			IL_000d:
			int num = -996540153;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -996540159)
				{
				case 8:
					break;
				default:
					return;
				case 6:
					ReInput.CheckInitialized(_reInputId);
					num = -996540155;
					continue;
				case 7:
					goto IL_0059;
				case 5:
					oQYQtKoYamPnNvXsnnJBSQOnAXZ();
					num = -996540158;
					continue;
				case 2:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR[num2].Clear();
					num2++;
					num = -996540160;
					continue;
				case 4:
					return;
				case 1:
					goto IL_00a1;
				case 0:
					goto IL_00b9;
				case 3:
					return;
				}
				break;
				IL_00a1:
				int num3;
				if (num2 < 4)
				{
					num = -996540157;
					num3 = num;
				}
				else
				{
					num = -996540156;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_0059:
			if (!pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				return;
			}
			goto IL_00b9;
			IL_00b9:
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.SdDcMpiCAoeUdyGrZHpsBLJVrBJd = xboxOneJoystickId;
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.sRRZbnUlyebNsUdNjxgfFkluEDr = MathTools.Clamp01(leftMotorLevel);
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.oyLgKWFONRKvIQNgyEcZFvJRPSJ = MathTools.Clamp01(rightMotorLevel);
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.cbgBrogdUYIeVCkXWKehqdEMqRne = MathTools.Clamp01(leftTriggerLevel);
			pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq.vCzzTubfFTTSUcxBpROODeVRhZH = MathTools.Clamp01(rightTriggerLevel);
			num2 = 0;
			num = -996540160;
			goto IL_0012;
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
				if (pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
				{
					num = -1647249852;
					num2 = num;
				}
				else
				{
					num = -1647249851;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1647249851)
					{
					case 2:
						goto IL_001a;
					case 3:
						break;
					case 0:
						return;
					default:
						uvdRZwKNKWMEiNFUBKZVMFXyWAY(motor, 0f, 0f);
						pjmDqcGcEdmXbvnkITKNjUFiEooD.IpSnymFRXnKSRjjNqsxPSQMvpLt.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
						return;
					}
					break;
					IL_001a:
					num = -1647249850;
				}
			}
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			VJFYjFBUsXRKMAFoSRHQlMiHIYB();
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
			pjmDqcGcEdmXbvnkITKNjUFiEooD = P_0 as beaqTtVRoXqmVNzrJtrRePhOuzJ;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void VJFYjFBUsXRKMAFoSRHQlMiHIYB()
		{
			if (!pjmDqcGcEdmXbvnkITKNjUFiEooD.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = -215097076;
				while (true)
				{
					switch (num2 ^ -215097075)
					{
					case 0:
						num2 = -215097074;
						continue;
					case 2:
						SetVibration(num, 0f, false);
						num2 = -215097079;
						continue;
					case 5:
					{
						int num3;
						if (EKvpQGhJhXJTuQtvfhYGZZMoAhR[num].Update())
						{
							num2 = -215097073;
							num3 = num2;
						}
						else
						{
							num2 = -215097079;
							num3 = num2;
						}
						continue;
					}
					case 3:
						break;
					case 4:
						num++;
						num2 = -215097076;
						continue;
					default:
						if (num >= 4)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		private void uvdRZwKNKWMEiNFUBKZVMFXyWAY(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
			int num;
			int num2 = default(int);
			switch (P_0)
			{
			default:
				num = 1666496275;
				goto IL_001d;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				goto IL_0072;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				goto IL_007b;
			case XboxOneGamepadMotorType.RightMotor:
				goto IL_0084;
			case XboxOneGamepadMotorType.LeftMotor:
				goto IL_008d;
				IL_001d:
				while (true)
				{
					switch (num ^ 0x6354B71A)
					{
					case 2:
						break;
					case 5:
						EKvpQGhJhXJTuQtvfhYGZZMoAhR[num2].Clear();
						return;
					case 4:
						num = 1666496281;
						continue;
					case 10:
						goto IL_0072;
					case 6:
						goto IL_007b;
					case 8:
						goto IL_0084;
					case 7:
						goto IL_008d;
					case 9:
						num = 1666496282;
						continue;
					case 3:
						if (P_1 <= 0f)
						{
							goto case 5;
						}
						goto IL_00a5;
					case 0:
						throw new NotImplementedException();
					default:
						EKvpQGhJhXJTuQtvfhYGZZMoAhR[num2].Start(P_2);
						return;
					}
					break;
					IL_00a5:
					int num3;
					if (P_2 > 0f)
					{
						num = 1666496283;
						num3 = num;
					}
					else
					{
						num = 1666496287;
						num3 = num;
					}
				}
				goto default;
				IL_008d:
				num2 = 0;
				num = 1666496281;
				goto IL_001d;
				IL_0084:
				num2 = 1;
				num = 1666496281;
				goto IL_001d;
				IL_007b:
				num2 = 3;
				num = 1666496286;
				goto IL_001d;
				IL_0072:
				num2 = 2;
				num = 1666496281;
				goto IL_001d;
			}
		}

		private void oQYQtKoYamPnNvXsnnJBSQOnAXZ()
		{
			if (!base.isJoystickConnected)
			{
				return;
			}
			while (true)
			{
				pjmDqcGcEdmXbvnkITKNjUFiEooD.IpSnymFRXnKSRjjNqsxPSQMvpLt.SetXboxOneVibration(xboxOneJoystickId, pjmDqcGcEdmXbvnkITKNjUFiEooD.clBTKGSxGawtcErRcukttOhcYTq);
				int num = -274304140;
				while (true)
				{
					switch (num ^ -274304138)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = -274304137;
				}
			}
		}
	}
}
