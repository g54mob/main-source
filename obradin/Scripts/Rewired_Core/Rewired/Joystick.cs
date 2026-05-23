using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int LEFT_MOTOR_INDEX = 0;

		private const int RIGHT_MOTOR_INDEX = 1;

		private IInputManagerJoystickPublic _sourceJoystick;

		private readonly JoystickType[] _joystickTypes;

		private readonly ReadOnlyCollection<JoystickType> _joystickTypes_readOnly;

		private readonly bool _supportsVibration;

		private readonly bool _supportsLocalVibration;

		private readonly bool _supportsVoice;

		private readonly int _localVibrationMotorCount;

		private readonly float[] _localVibrationMotorValues;

		private readonly TimerAbs[] _localVibrationStopTimers;

		private readonly int _hatCount;

		private readonly Hat[] _hats;

		private readonly ReadOnlyCollection<Hat> hats_readOnly;

		internal IList<JoystickType> joystickTypes
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return _joystickTypes_readOnly;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1L;
				}
				return _sourceJoystick.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _sourceJoystick.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return _sourceJoystick.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return false;
				}
				return _supportsVibration;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					goto IL_000d;
				}
				if (!_supportsVibration)
				{
					return 0f;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				int num = 1382102607;
				goto IL_0012;
				IL_000d:
				num = 1382102606;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x5261364F)
					{
					case 2:
						break;
					case 1:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return 0f;
					case 0:
						if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 0)
						{
							goto IL_006e;
						}
						if (!_supportsLocalVibration)
						{
							return 0f;
						}
						if (_localVibrationMotorCount > 0)
						{
							return _localVibrationMotorValues[0];
						}
						return 0f;
					default:
						return controllerVibrator.GetVibration(0);
					}
					break;
					IL_006e:
					num = 1382102604;
				}
				goto IL_000d;
			}
			set
			{
				if (!_supportsVibration)
				{
					goto IL_0008;
				}
				goto IL_005e;
				IL_0008:
				int num = 1648693732;
				goto IL_000d;
				IL_000d:
				IControllerVibrator controllerVibrator = default(IControllerVibrator);
				while (true)
				{
					switch (num ^ 0x624511E0)
					{
					case 8:
						break;
					case 2:
						goto IL_0045;
					case 6:
						goto IL_005e;
					case 5:
						if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 0)
						{
							controllerVibrator.SetVibration(0, value);
							num = 1648693735;
							continue;
						}
						goto IL_0045;
					case 3:
						goto IL_00a1;
					case 7:
						return;
					case 0:
						return;
					case 4:
						return;
					case 9:
						return;
					default:
						SetLocalVibration(0, value, 0f, false, true);
						return;
					}
					break;
					IL_00a1:
					int num2;
					if (0 >= _localVibrationMotorCount)
					{
						num = 1648693728;
						num2 = num;
					}
					else
					{
						num = 1648693729;
						num2 = num;
					}
					continue;
					IL_0045:
					int num3;
					if (_supportsLocalVibration)
					{
						num = 1648693731;
						num3 = num;
					}
					else
					{
						num = 1648693737;
						num3 = num;
					}
				}
				goto IL_0008;
				IL_005e:
				value = MathTools.Clamp(value, 0f, 1f);
				controllerVibrator = base.extension as IControllerVibrator;
				num = 1648693733;
				goto IL_000d;
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					goto IL_0019;
				}
				if (!_supportsVibration)
				{
					return 0f;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				int num;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 1)
				{
					num = -1184240303;
					goto IL_001e;
				}
				if (!_supportsLocalVibration)
				{
					return 0f;
				}
				if (_localVibrationMotorCount > 1)
				{
					return _localVibrationMotorValues[1];
				}
				return 0f;
				IL_0019:
				num = -1184240302;
				goto IL_001e;
				IL_001e:
				switch (num ^ -1184240301)
				{
				case 0:
					break;
				case 1:
					return 0f;
				default:
					return controllerVibrator.GetVibration(1);
				}
				goto IL_0019;
			}
			set
			{
				if (!_supportsVibration)
				{
					return;
				}
				while (true)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					int num = 1511003605;
					while (true)
					{
						switch (num ^ 0x5A1015D5)
						{
						case 3:
							num = 1511003604;
							continue;
						case 4:
						{
							int num2;
							if (1 < _localVibrationMotorCount)
							{
								num = 1511003600;
								num2 = num;
							}
							else
							{
								num = 1511003607;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						case 1:
							break;
						case 6:
							if (!_supportsLocalVibration)
							{
								return;
							}
							goto case 4;
						case 0:
						{
							IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
							if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 1)
							{
								controllerVibrator.SetVibration(1, value);
								return;
							}
							goto case 6;
						}
						default:
							SetLocalVibration(1, value, 0f, false, true);
							return;
						}
						break;
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return _localVibrationMotorCount;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return 0;
				}
				return _hatCount;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return hats_readOnly;
			}
		}

		internal int inputManagerId
		{
			get
			{
				return _sourceJoystick.inputManagerId;
			}
		}

		internal HardwareControllerMapIdentifier hardwareJoystickMapIdentifier
		{
			get
			{
				if (RCNejcvnZtMAmgendVbiwgNYmdD == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return RCNejcvnZtMAmgendVbiwgNYmdD.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController controller)
			: this(controller.sourceJoystick.rewiredId, controller.inputSource, controller.sourceJoystick.name, (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName)) ? controller.hw_bluetoothDeviceName : controller.productName, controller.hardwareIdentifier, controller.controllerTypeGuid, controller.axisCount, controller.buttonCount, controller.isButtonPressureSensitive, controller.gameHardwareMap, controller.controllerExtension, new ControllerDataUpdater(controller.inputManagerSource, controller.axisCount, controller.buttonCount, controller.unknownControllerHats))
		{
			IList<HardwareJoystickTemplateMap> list = default(IList<HardwareJoystickTemplateMap>);
			List<IControllerTemplate> list2 = default(List<IControllerTemplate>);
			int num3 = default(int);
			while (true)
			{
				int num = 910564370;
				while (true)
				{
					switch (num ^ 0x36461C13)
					{
					case 6:
						break;
					case 4:
						_localVibrationMotorValues = new float[_localVibrationMotorCount];
						_localVibrationStopTimers = new TimerAbs[_localVibrationMotorCount];
						ArrayTools.Populate(_localVibrationStopTimers, 0, _localVibrationMotorCount);
						_supportsLocalVibration = true;
						num = 910564374;
						continue;
					case 3:
						list = ReInput.oKiFpADtDgRKbCjxFcbRklAzcrvC(OtVFjwsBdyyNFQHLWfYqCKpUyfa);
						if (list != null)
						{
							list2 = null;
							num3 = 0;
							goto IL_0227;
						}
						goto IL_023f;
					case 5:
						if (OtVFjwsBdyyNFQHLWfYqCKpUyfa != Guid.Empty)
						{
							num = 910564368;
							continue;
						}
						goto IL_023f;
					case 1:
						_sourceJoystick = controller.sourceJoystick;
						num = 910564371;
						continue;
					case 0:
						_supportsVibration = controller.hw_supportsVibration;
						_supportsVoice = controller.hw_supportsVoice;
						_localVibrationMotorCount = ((!(controller.controllerExtension is IControllerVibrator)) ? controller.hw_localVibrationMotorCount : 0);
						if (_supportsVibration)
						{
							int num2;
							if (_localVibrationMotorCount <= 0)
							{
								num = 910564374;
								num2 = num;
							}
							else
							{
								num = 910564375;
								num2 = num;
							}
							continue;
						}
						goto case 5;
					default:
						{
							HardwareJoystickTemplateMap hardwareJoystickTemplateMap = list[num3];
							if (!(hardwareJoystickTemplateMap == null))
							{
								IControllerTemplate controllerTemplate;
								try
								{
									controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.NTQeamxZJcOeTxKdrraxwupmbcy(this, hardwareJoystickTemplateMap));
									if (controllerTemplate == null)
									{
										throw new Exception(string.Concat("Controller Template for guid ", hardwareJoystickTemplateMap.Guid, " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?"));
									}
								}
								catch (Exception ex)
								{
									Logger.LogErrorEditor(ex.Message);
									goto IL_0223;
								}
								if (list2 == null)
								{
									list2 = new List<IControllerTemplate>();
								}
								list2.Add(controllerTemplate);
							}
							goto IL_0223;
						}
						IL_023f:
						snpHjGkGVogejiySyWIFjoJWDLTS();
						return;
						IL_0227:
						if (num3 < list.Count)
						{
							goto default;
						}
						if (list2 != null)
						{
							vRVgKtnyYDgVtYmVZcPHYjYJKvu(list2.ToArray());
						}
						goto IL_023f;
						IL_0223:
						num3++;
						goto IL_0227;
					}
					break;
				}
			}
		}

		private Joystick(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Joystick, hardwareTypeGuid, axisCount, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			int num2 = default(int);
			int num3 = default(int);
			int buttonIndex = default(int);
			int componentElementIdentifierId = default(int);
			List<Button> list = default(List<Button>);
			List<int> list2 = default(List<int>);
			HardwareJoystickMap.CompoundElement hatData = default(HardwareJoystickMap.CompoundElement);
			while (true)
			{
				int num = -2054764192;
				while (true)
				{
					switch (num ^ -2054764191)
					{
					case 0:
						break;
					case 7:
						num2++;
						num = -2054764184;
						continue;
					case 5:
						_hatCount = hardwareMap.hatCount;
						_hats = new Hat[_hatCount];
						num3 = 0;
						goto IL_02e3;
					case 8:
						buttonIndex = hardwareMap.GetButtonIndex(componentElementIdentifierId);
						if (buttonIndex < 0)
						{
							list.Add(null);
							list2.Add(-1);
							num = -2054764187;
							continue;
						}
						goto case 3;
					case 4:
						num = -2054764186;
						continue;
					case 10:
						list = new List<Button>();
						list2 = new List<int>();
						num2 = 0;
						num = -2054764175;
						continue;
					case 11:
						_joystickTypes_readOnly = new ReadOnlyCollection<JoystickType>(_joystickTypes);
						num = -2054764188;
						continue;
					case 3:
						list.Add(buttons[buttonIndex]);
						num = -2054764185;
						continue;
					case 6:
						list2.Add(buttonIndex);
						num = -2054764186;
						continue;
					case 13:
						list.Add(null);
						list2.Add(-1);
						num = -2054764186;
						continue;
					case 15:
					{
						componentElementIdentifierId = hatData.GetComponentElementIdentifierId(num2);
						int num5;
						if (ArrayTools.Contains(hardwareMap.buttonElementIdentifierIds, componentElementIdentifierId))
						{
							num = -2054764183;
							num5 = num;
						}
						else
						{
							num = -2054764180;
							num5 = num;
						}
						continue;
					}
					case 18:
						if (hatData == null)
						{
							Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
							_hats[num3] = new Hat(this, hatData.elementIdentifier, "Hat " + num3, new Button[0], new int[0]);
							num = -2054764177;
							continue;
						}
						goto case 10;
					case 12:
					{
						JoystickType[] array = new JoystickType[1];
						_joystickTypes = array;
						num = -2054764182;
						continue;
					}
					case 16:
						num = -2054764184;
						continue;
					case 17:
						_joystickTypes = hardwareMap.joystickTypes;
						num = -2054764182;
						continue;
					case 2:
						hatData = hardwareMap.GetHatData(num3);
						num = -2054764173;
						continue;
					case 1:
						if (hardwareMap != null && hardwareMap.joystickTypes != null)
						{
							int num4;
							if (hardwareMap.joystickTypes.Length != 0)
							{
								num = -2054764176;
								num4 = num;
							}
							else
							{
								num = -2054764179;
								num4 = num;
							}
							continue;
						}
						goto case 12;
					default:
						if (num2 < hatData.elementCount)
						{
							goto case 15;
						}
						try
						{
							_hats[num3] = new Hat(this, hatData.elementIdentifier, "Hat " + num3, list.ToArray(), list2.ToArray());
						}
						catch
						{
							Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
							_hats[num3] = new Hat(this, hatData.elementIdentifier, "Hat " + num3, new Button[0], new int[0]);
						}
						goto case 14;
					case 14:
						{
							num3++;
							goto IL_02e3;
						}
						IL_02e3:
						if (num3 >= _hatCount)
						{
							hats_readOnly = new ReadOnlyCollection<Hat>(_hats);
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		internal bool IsType(JoystickType joystickType)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			int num = _joystickTypes.Length;
			int num3 = default(int);
			while (true)
			{
				int num2 = 103054980;
				while (true)
				{
					switch (num2 ^ 0x6247E85)
					{
					case 3:
						break;
					case 2:
						if (_joystickTypes[num3] == joystickType)
						{
							return true;
						}
						num3++;
						num2 = 103054981;
						continue;
					case 4:
						num2 = 103054981;
						continue;
					case 1:
						num3 = 0;
						num2 = 103054977;
						continue;
					default:
						if (num3 >= num)
						{
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					switch (-1130458215 ^ -1130458213)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						return;
					}
					break;
				}
			}
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			int num3 = default(int);
			while (_supportsVibration)
			{
				while (true)
				{
					IL_007c:
					IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
					int num = 962326012;
					while (true)
					{
						switch (num ^ 0x395BEDFD)
						{
						case 4:
							num = 962326010;
							continue;
						case 7:
							break;
						case 10:
							controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
							num = 962326015;
							continue;
						case 8:
							goto IL_007c;
						case 6:
						{
							int num2;
							if (_localVibrationMotorCount <= 0)
							{
								num = 962326004;
								num2 = num;
							}
							else
							{
								num = 962326008;
								num2 = num;
							}
							continue;
						}
						case 5:
							SetLocalVibration(0, leftMotorLevel, leftMotorDuration, false, false);
							num = 962326004;
							continue;
						case 2:
							if (!_supportsLocalVibration)
							{
								return;
							}
							goto case 6;
						case 0:
							goto IL_00d4;
						case 1:
							if (controllerVibrator == null)
							{
								goto case 2;
							}
							num3 = controllerVibrator.vibrationMotorCount;
							if (num3 > 0)
							{
								controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
								num = 962326013;
								continue;
							}
							goto IL_00d4;
						case 9:
							if (_localVibrationMotorCount > 1)
							{
								SetLocalVibration(1, rightMotorLevel, rightMotorDuration, false, false);
								num = 962326014;
								continue;
							}
							goto default;
						default:
							UpdateLocalControllerVibration();
							return;
						}
						break;
						IL_00d4:
						int num4;
						if (num3 <= 1)
						{
							num = 962326015;
							num4 = num;
						}
						else
						{
							num = 962326007;
							num4 = num;
						}
					}
					break;
				}
			}
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_0010;
			}
			goto IL_00aa;
			IL_0010:
			int num = 1503054590;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x5996CAFB)
				{
				case 0:
					break;
				case 6:
					if (motorIndex >= _localVibrationMotorCount)
					{
						return;
					}
					goto default;
				case 4:
				{
					IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
					if (controllerVibrator != null)
					{
						controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
						num = 1503054588;
						continue;
					}
					goto IL_008e;
				}
				case 1:
					return;
				case 8:
					return;
				case 7:
					goto IL_008e;
				case 2:
					goto IL_00aa;
				case 5:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return;
				default:
					SetLocalVibration(motorIndex, motorLevel, duration, stopOtherMotors, true);
					return;
				}
				break;
				IL_008e:
				int num2;
				if (_supportsLocalVibration)
				{
					num = 1503054589;
					num2 = num;
				}
				else
				{
					num = 1503054586;
					num2 = num;
				}
			}
			goto IL_0010;
			IL_00aa:
			if (!_supportsVibration)
			{
				return;
			}
			int num3;
			if (motorIndex >= 0)
			{
				num = 1503054591;
				num3 = num;
			}
			else
			{
				num = 1503054579;
				num3 = num;
			}
			goto IL_0015;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			IControllerVibrator controllerVibrator = default(IControllerVibrator);
			int num;
			if (_supportsVibration)
			{
				if (motorIndex < 0)
				{
					goto IL_002b;
				}
				controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && motorIndex < controllerVibrator.vibrationMotorCount)
				{
					num = -1667595787;
					goto IL_0030;
				}
				if (!_supportsLocalVibration)
				{
					return 0f;
				}
				if (motorIndex >= _localVibrationMotorCount)
				{
					return 0f;
				}
				return _localVibrationMotorValues[motorIndex];
			}
			goto IL_0049;
			IL_0049:
			return 0f;
			IL_0030:
			switch (num ^ -1667595785)
			{
			case 0:
				break;
			case 1:
				goto IL_0049;
			default:
				return controllerVibrator.GetVibration(motorIndex);
			}
			goto IL_002b;
			IL_002b:
			num = -1667595786;
			goto IL_0030;
		}

		public void StopVibration()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			int num2 = default(int);
			while (_supportsVibration)
			{
				while (true)
				{
					IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
					int num = 214060664;
					while (true)
					{
						switch (num ^ 0xCC24E7E)
						{
						case 2:
							num = 214060671;
							continue;
						default:
							return;
						case 9:
							if (_sourceJoystick != null)
							{
								_sourceJoystick.StopVibration();
								num = 214060667;
								continue;
							}
							return;
						case 7:
							break;
						case 4:
							num = 214060669;
							continue;
						case 8:
							_localVibrationStopTimers[num2].Clear();
							num2++;
							num = 214060669;
							continue;
						case 0:
							if (_supportsLocalVibration)
							{
								Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
								num2 = 0;
								num = 214060666;
								continue;
							}
							goto case 9;
						case 6:
							if (controllerVibrator != null)
							{
								controllerVibrator.StopVibration();
								num = 214060670;
								continue;
							}
							goto case 0;
						case 3:
							goto IL_00e7;
						case 1:
							goto end_IL_0077;
						case 5:
							return;
						}
						break;
						IL_00e7:
						int num3;
						if (num2 >= _localVibrationMotorCount)
						{
							num = 214060663;
							num3 = num;
						}
						else
						{
							num = 214060662;
							num3 = num;
						}
					}
					continue;
					end_IL_0077:
					break;
				}
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			base.UpdateData(updateLoop);
			int num2 = default(int);
			while (true)
			{
				int num = -629039911;
				while (true)
				{
					switch (num ^ -629039912)
					{
					case 5:
						break;
					default:
						return;
					case 1:
						num2 = 0;
						num = -629039908;
						continue;
					case 2:
						num2++;
						num = -629039908;
						continue;
					case 0:
						if (_hats[num2] != null)
						{
							_hats[num2].dvtavmcwhNkMVmvvKqcPhKMHyKbP(updateLoop, ybiZyKuVmvsrOHqZzdmfwidXkdm);
							num = -629039910;
							continue;
						}
						goto case 2;
					case 4:
						if (num2 >= _hatCount)
						{
							CheckVibrationTimeout();
							num = -629039909;
							continue;
						}
						goto case 0;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal void UpdateControllerInfo(UpdateControllerInfoEventArgs args)
		{
			if (args != null)
			{
				UpdateControllerInfo(args.sourceJoystick);
			}
		}

		internal void UpdateControllerInfo(BridgedController controller)
		{
			if (controller == null)
			{
				return;
			}
			while (true)
			{
				UpdateControllerInfo(controller.sourceJoystick);
				int num = 1755166321;
				while (true)
				{
					switch (num ^ 0x689DB673)
					{
					case 0:
						goto IL_0004;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0004:
					num = 1755166322;
				}
			}
		}

		private void UpdateControllerInfo(IInputManagerJoystickPublic joystick)
		{
			_sourceJoystick = joystick;
			if (joystick == null)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (base.extension != null)
				{
					num = -765164661;
					num2 = num;
				}
				else
				{
					num = -765164663;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -765164659)
					{
					case 2:
						num = -765164660;
						continue;
					default:
						return;
					case 1:
						break;
					case 4:
						qVYVNupolNeIsaFeJRsbUHVXuxRg(joystick.extension);
						num = -765164664;
						continue;
					case 5:
					{
						int num3;
						if (joystick.name != string.Empty)
						{
							num = -765164659;
							num3 = num;
						}
						else
						{
							num = -765164658;
							num3 = num;
						}
						continue;
					}
					case 0:
						_name = joystick.name;
						num = -765164658;
						continue;
					case 6:
						wFNxILHosqnCwEOlbeICtkHZvYR(joystick.extension);
						num = -765164664;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal override void Clear()
		{
			base.Clear();
			StopVibration();
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			int num = default(int);
			if (_supportsLocalVibration)
			{
				Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
				num = 0;
				goto IL_0064;
			}
			goto IL_007e;
			IL_007e:
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			int num2;
			if (controllerVibrator != null)
			{
				controllerVibrator.StopVibration();
				num2 = -1469602778;
				goto IL_002b;
			}
			return;
			IL_0064:
			int num3;
			if (num >= _localVibrationMotorCount)
			{
				num2 = -1469602780;
				num3 = num2;
			}
			else
			{
				num2 = -1469602779;
				num3 = num2;
			}
			goto IL_002b;
			IL_002b:
			while (true)
			{
				switch (num2 ^ -1469602780)
				{
				case 4:
					num2 = -1469602779;
					continue;
				default:
					return;
				case 1:
					_localVibrationStopTimers[num].Clear();
					num++;
					num2 = -1469602777;
					continue;
				case 3:
					break;
				case 0:
					goto IL_007e;
				case 2:
					return;
				}
				break;
			}
			goto IL_0064;
		}

		private void CheckVibrationTimeout()
		{
			if (!_supportsVibration)
			{
				goto IL_0008;
			}
			goto IL_0064;
			IL_0008:
			int num = -2024883429;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -2024883430)
				{
				case 5:
					break;
				case 2:
					if (_localVibrationStopTimers[num2].Update())
					{
						SetVibration(num2, 0f, false);
						num = -2024883426;
						continue;
					}
					goto case 4;
				case 4:
					num2++;
					num = -2024883430;
					continue;
				case 3:
					goto IL_0064;
				case 1:
					return;
				case 6:
					goto IL_007c;
				default:
					if (num2 >= _localVibrationMotorCount)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0064:
			if (!_supportsLocalVibration)
			{
				return;
			}
			goto IL_007c;
			IL_007c:
			num2 = 0;
			num = -2024883430;
			goto IL_000d;
		}

		private void SetLocalVibration(int motorIndex, float motorLevel, float motorDuration, bool stopOtherMotors, bool updateNow)
		{
			if (!_supportsLocalVibration)
			{
				return;
			}
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (motorIndex < 0)
				{
					num = 2144125797;
					num2 = num;
				}
				else
				{
					num = 2144125802;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7FCCC360)
					{
					case 0:
						num = 2144125793;
						continue;
					default:
						return;
					case 14:
						if (!(motorLevel <= 0f))
						{
							int num6;
							if (motorDuration > 0f)
							{
								num = 2144125795;
								num6 = num;
							}
							else
							{
								num = 2144125794;
								num6 = num;
							}
							continue;
						}
						goto case 2;
					case 13:
						if (updateNow)
						{
							UpdateLocalControllerVibration();
							num = 2144125803;
							continue;
						}
						return;
					case 2:
						_localVibrationStopTimers[motorIndex].Clear();
						num = 2144125801;
						continue;
					case 7:
						_localVibrationStopTimers[num4].Clear();
						num = 2144125798;
						continue;
					case 8:
						if (stopOtherMotors)
						{
							Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
							num4 = 0;
							num = 2144125804;
							continue;
						}
						goto case 4;
					case 4:
						_localVibrationMotorValues[motorIndex] = MathTools.Clamp01(motorLevel);
						num = 2144125806;
						continue;
					case 12:
					{
						int num5;
						if (num4 >= _localVibrationMotorCount)
						{
							num = 2144125796;
							num5 = num;
						}
						else
						{
							num = 2144125799;
							num5 = num;
						}
						continue;
					}
					case 3:
						_localVibrationStopTimers[motorIndex].Start(motorDuration);
						num = 2144125805;
						continue;
					case 6:
						num4++;
						num = 2144125804;
						continue;
					case 9:
						num = 2144125805;
						continue;
					case 5:
						return;
					case 1:
						break;
					case 10:
					{
						int num3;
						if (motorIndex >= _localVibrationMotorCount)
						{
							num = 2144125797;
							num3 = num;
						}
						else
						{
							num = 2144125800;
							num3 = num;
						}
						continue;
					}
					case 11:
						return;
					}
					break;
				}
			}
		}

		private void UpdateLocalControllerVibration()
		{
			if (_supportsVibration)
			{
				if (!_supportsLocalVibration)
				{
					goto IL_0010;
				}
				goto IL_008a;
			}
			return;
			IL_008a:
			if (_sourceJoystick == null)
			{
				return;
			}
			goto IL_0081;
			IL_0010:
			int num = 920743850;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x36E16FAB)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					_sourceJoystick.SetVibration(_localVibrationMotorValues[num2], num2);
					num2++;
					num = 920743854;
					continue;
				case 5:
					goto IL_0065;
				case 6:
					goto IL_0081;
				case 2:
					goto IL_008a;
				case 4:
					return;
				}
				break;
				IL_0065:
				int num3;
				if (num2 >= _localVibrationMotorValues.Length)
				{
					num = 920743855;
					num3 = num;
				}
				else
				{
					num = 920743851;
					num3 = num;
				}
			}
			goto IL_0010;
			IL_0081:
			num2 = 0;
			num = 920743854;
			goto IL_0015;
		}

		private void StopAllVibration()
		{
		}

		internal static int CompareById_Ascending(Joystick a, Joystick b)
		{
			if (a.inputManagerId < b.inputManagerId)
			{
				goto IL_000e;
			}
			int num;
			if (a.inputManagerId > b.inputManagerId)
			{
				num = -430813414;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = -430813415;
			goto IL_0013;
			IL_0013:
			switch (num ^ -430813416)
			{
			case 0:
				break;
			case 1:
				return -1;
			default:
				return 1;
			}
			goto IL_000e;
		}
	}
}
