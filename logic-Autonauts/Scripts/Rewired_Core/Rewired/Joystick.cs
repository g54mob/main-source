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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return _joystickTypes_readOnly;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return -1L;
				}
				return _sourceJoystick.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = 1560320775;
						while (true)
						{
							switch (num ^ 0x5D009B06)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return -1;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 1560320774;
						}
					}
				}
				return _sourceJoystick.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Guid.Empty;
				}
				return _sourceJoystick.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return false;
				}
				return _supportsVibration;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				}
				if (!_supportsVibration)
				{
					return 0f;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 0)
				{
					goto IL_0045;
				}
				int num;
				if (!_supportsLocalVibration)
				{
					num = 330045740;
				}
				else
				{
					if (_localVibrationMotorCount <= 0)
					{
						return 0f;
					}
					num = 330045742;
				}
				goto IL_004a;
				IL_0045:
				num = 330045741;
				goto IL_004a;
				IL_004a:
				switch (num ^ 0x13AC192F)
				{
				case 0:
					break;
				case 2:
					return controllerVibrator.GetVibration(0);
				case 3:
					return 0f;
				default:
					return _localVibrationMotorValues[0];
				}
				goto IL_0045;
			}
			set
			{
				if (!_supportsVibration)
				{
					return;
				}
				while (true)
				{
					IL_0081:
					value = MathTools.Clamp(value, 0f, 1f);
					IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
					int num;
					if (controllerVibrator != null)
					{
						int num2;
						if (controllerVibrator.vibrationMotorCount <= 0)
						{
							num = 474929994;
							num2 = num;
						}
						else
						{
							num = 474929999;
							num2 = num;
						}
						goto IL_000e;
					}
					goto IL_0060;
					IL_0070:
					if (0 >= _localVibrationMotorCount)
					{
						break;
					}
					goto IL_003a;
					IL_003a:
					SetLocalVibration(0, value, 0f, false, true);
					num = 474929995;
					goto IL_000e;
					IL_000e:
					while (true)
					{
						switch (num ^ 0x1C4EDB4B)
						{
						case 2:
							num = 474929992;
							continue;
						default:
							return;
						case 5:
							break;
						case 4:
							controllerVibrator.SetVibration(0, value);
							return;
						case 1:
							goto IL_0060;
						case 6:
							goto IL_0070;
						case 3:
							goto IL_0081;
						case 0:
							return;
						}
						break;
					}
					goto IL_003a;
					IL_0060:
					if (!_supportsLocalVibration)
					{
						break;
					}
					goto IL_0070;
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				}
				if (!_supportsVibration)
				{
					return 0f;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 1)
				{
					return controllerVibrator.GetVibration(1);
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
					IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
					int num = 168164136;
					while (true)
					{
						switch (num ^ 0xA05FB2F)
						{
						case 5:
							num = 168164134;
							continue;
						default:
							return;
						case 4:
							SetLocalVibration(1, value, 0f, false, true);
							num = 168164137;
							continue;
						case 0:
						{
							int num2;
							if (_supportsLocalVibration)
							{
								num = 168164140;
								num2 = num;
							}
							else
							{
								num = 168164141;
								num2 = num;
							}
							continue;
						}
						case 7:
						{
							int num3;
							if (controllerVibrator != null)
							{
								num = 168164142;
								num3 = num;
							}
							else
							{
								num = 168164143;
								num3 = num;
							}
							continue;
						}
						case 9:
							break;
						case 2:
							return;
						case 1:
							if (controllerVibrator.vibrationMotorCount > 1)
							{
								controllerVibrator.SetVibration(1, value);
								num = 168164135;
								continue;
							}
							goto case 0;
						case 8:
							return;
						case 3:
							if (1 >= _localVibrationMotorCount)
							{
								return;
							}
							goto case 4;
						case 6:
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return _hatCount;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
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
				if (kABaypBwJpdJPQfaNrcsDzJUopW == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return kABaypBwJpdJPQfaNrcsDzJUopW.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController controller)
			: this(controller.sourceJoystick.rewiredId, controller.inputSource, controller.sourceJoystick.name, (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName)) ? controller.hw_bluetoothDeviceName : controller.productName, controller.hardwareIdentifier, controller.controllerTypeGuid, controller.axisCount, controller.buttonCount, controller.isButtonPressureSensitive, controller.gameHardwareMap, controller.controllerExtension, new ControllerDataUpdater(controller.inputManagerSource, controller.axisCount, controller.buttonCount, controller.unknownControllerHats))
		{
			_sourceJoystick = controller.sourceJoystick;
			_supportsVibration = controller.hw_supportsVibration;
			_supportsVoice = controller.hw_supportsVoice;
			_localVibrationMotorCount = ((!(controller.controllerExtension is IControllerVibrator)) ? controller.hw_localVibrationMotorCount : 0);
			if (_supportsVibration && _localVibrationMotorCount > 0)
			{
				_localVibrationMotorValues = new float[_localVibrationMotorCount];
				_localVibrationStopTimers = new TimerAbs[_localVibrationMotorCount];
				ArrayTools.Populate(_localVibrationStopTimers, 0, _localVibrationMotorCount);
				_supportsLocalVibration = true;
			}
			if (hLHPojWAxuyakcKOieCsahbSjqfw != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.NWqyoHHBVkTlIVXcKtnFOfKuruo(hLHPojWAxuyakcKOieCsahbSjqfw);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						HardwareJoystickTemplateMap hardwareJoystickTemplateMap = list[i];
						if (hardwareJoystickTemplateMap == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.adQzKzNdBifUDJeBXdCrHVmckZx(this, hardwareJoystickTemplateMap));
							if (controllerTemplate == null)
							{
								throw new Exception(string.Concat("Controller Template for guid ", hardwareJoystickTemplateMap.Guid, " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?"));
							}
						}
						catch (Exception ex)
						{
							Logger.LogErrorEditor(ex.Message);
							continue;
						}
						if (list2 == null)
						{
							list2 = new List<IControllerTemplate>();
						}
						list2.Add(controllerTemplate);
					}
					if (list2 != null)
					{
						EuTqFaJzSVKiMeLUrTRDniYPAwh(list2.ToArray());
					}
				}
			}
			DRbMoDMaPuHTEfQNWMCHwDDCfEIB();
		}

		private Joystick(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Joystick, hardwareTypeGuid, axisCount, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			if (hardwareMap == null || hardwareMap.joystickTypes == null || hardwareMap.joystickTypes.Length == 0)
			{
				JoystickType[] array = new JoystickType[1];
				_joystickTypes = array;
			}
			else
			{
				_joystickTypes = hardwareMap.joystickTypes;
			}
			_joystickTypes_readOnly = new ReadOnlyCollection<JoystickType>(_joystickTypes);
			_hatCount = hardwareMap.hatCount;
			_hats = new Hat[_hatCount];
			for (int i = 0; i < _hatCount; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = hardwareMap.GetHatData(i);
				if (hatData == null)
				{
					Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
					_hats[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					continue;
				}
				List<Button> list = new List<Button>();
				List<int> list2 = new List<int>();
				for (int j = 0; j < hatData.elementCount; j++)
				{
					int componentElementIdentifierId = hatData.GetComponentElementIdentifierId(j);
					if (!ArrayTools.Contains(hardwareMap.buttonElementIdentifierIds, componentElementIdentifierId))
					{
						list.Add(null);
						list2.Add(-1);
						continue;
					}
					int buttonIndex = hardwareMap.GetButtonIndex(componentElementIdentifierId);
					if (buttonIndex < 0)
					{
						list.Add(null);
						list2.Add(-1);
					}
					else
					{
						list.Add(buttons[buttonIndex]);
						list2.Add(buttonIndex);
					}
				}
				try
				{
					_hats[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
				}
				catch
				{
					Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
					_hats[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
				}
			}
			hats_readOnly = new ReadOnlyCollection<Hat>(_hats);
		}

		internal bool IsType(JoystickType joystickType)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num = _joystickTypes.Length;
			int num2 = -2009272854;
			goto IL_001e;
			IL_001e:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -2009272855)
				{
				case 0:
					break;
				case 1:
					if (_joystickTypes[num3] == joystickType)
					{
						return true;
					}
					num3++;
					num2 = -2009272852;
					continue;
				case 3:
					num3 = 0;
					num2 = -2009272853;
					continue;
				case 2:
					num2 = -2009272852;
					continue;
				case 4:
					return false;
				default:
					if (num3 >= num)
					{
						return false;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num2 = -2009272851;
			goto IL_001e;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				while (true)
				{
					switch (-1601020754 ^ -1601020756)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_001c;
			}
			goto IL_00e1;
			IL_00e1:
			int num;
			int num2;
			if (_supportsVibration)
			{
				num = -605462778;
				num2 = num;
			}
			else
			{
				num = -605462777;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -605462776;
			goto IL_0021;
			IL_0021:
			IControllerVibrator controllerVibrator = default(IControllerVibrator);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -605462783)
				{
				case 12:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					UpdateLocalControllerVibration();
					num = -605462773;
					continue;
				case 11:
					if (_localVibrationMotorCount > 1)
					{
						SetLocalVibration(1, rightMotorLevel, rightMotorDuration, false, false);
						num = -605462783;
						continue;
					}
					goto case 0;
				case 5:
					if (controllerVibrator == null)
					{
						goto IL_00c5;
					}
					num3 = controllerVibrator.vibrationMotorCount;
					if (num3 > 0)
					{
						controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
						num = -605462781;
						continue;
					}
					goto case 2;
				case 6:
					return;
				case 4:
					goto IL_00c5;
				case 3:
					goto IL_00e1;
				case 9:
					return;
				case 7:
					controllerVibrator = base.extension as IControllerVibrator;
					num = -605462780;
					continue;
				case 8:
					if (_localVibrationMotorCount > 0)
					{
						SetLocalVibration(0, leftMotorLevel, leftMotorDuration, false, false);
						num = -605462774;
						continue;
					}
					goto case 11;
				case 2:
					if (num3 > 1)
					{
						controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
						num = -605462779;
						continue;
					}
					goto IL_00c5;
				case 10:
					return;
				}
				break;
				IL_00c5:
				int num4;
				if (_supportsLocalVibration)
				{
					num = -605462775;
					num4 = num;
				}
				else
				{
					num = -605462784;
					num4 = num;
				}
			}
			goto IL_001c;
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
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			goto IL_0076;
			IL_0076:
			int num;
			if (_supportsVibration)
			{
				int num2;
				if (motorIndex < 0)
				{
					num = 1670966285;
					num2 = num;
				}
				else
				{
					num = 1670966275;
					num2 = num;
				}
				goto IL_001e;
			}
			return;
			IL_0019:
			num = 1670966279;
			goto IL_001e;
			IL_001e:
			IControllerVibrator controllerVibrator = default(IControllerVibrator);
			while (true)
			{
				switch (num ^ 0x6398EC05)
				{
				case 0:
					break;
				default:
					return;
				case 6:
					goto IL_0056;
				case 7:
					goto IL_0076;
				case 3:
					SetLocalVibration(motorIndex, motorLevel, duration, stopOtherMotors, true);
					num = 1670966276;
					continue;
				case 8:
					return;
				case 4:
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
					num = 1670966284;
					continue;
				case 5:
					if (motorIndex >= _localVibrationMotorCount)
					{
						return;
					}
					goto case 3;
				case 9:
					if (!_supportsLocalVibration)
					{
						return;
					}
					goto case 5;
				case 2:
					return;
				case 1:
					return;
				}
				break;
				IL_0056:
				controllerVibrator = base.extension as IControllerVibrator;
				int num3;
				if (controllerVibrator != null)
				{
					num = 1670966273;
					num3 = num;
				}
				else
				{
					num = 1670966284;
					num3 = num;
				}
			}
			goto IL_0019;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (!_supportsVibration || motorIndex < 0)
			{
				return 0f;
			}
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			if (controllerVibrator != null && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
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

		public void StopVibration()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			goto IL_0091;
			IL_0010:
			int num = 1397774364;
			goto IL_0015;
			IL_0015:
			IControllerVibrator controllerVibrator = default(IControllerVibrator);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x53505814)
				{
				case 10:
					break;
				default:
					return;
				case 8:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return;
				case 7:
					goto IL_0065;
				case 3:
					goto IL_007e;
				case 1:
					goto IL_0091;
				case 5:
					if (controllerVibrator != null)
					{
						controllerVibrator.StopVibration();
						num = 1397774355;
						continue;
					}
					goto IL_0065;
				case 4:
					_localVibrationStopTimers[num2].Clear();
					num2++;
					num = 1397774358;
					continue;
				case 6:
					if (_sourceJoystick != null)
					{
						_sourceJoystick.StopVibration();
						num = 1397774365;
						continue;
					}
					return;
				case 2:
					goto IL_00ef;
				case 0:
					Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
					num2 = 0;
					num = 1397774358;
					continue;
				case 9:
					return;
				}
				break;
				IL_00ef:
				int num3;
				if (num2 >= _localVibrationMotorCount)
				{
					num = 1397774354;
					num3 = num;
				}
				else
				{
					num = 1397774352;
					num3 = num;
				}
				continue;
				IL_0065:
				int num4;
				if (!_supportsLocalVibration)
				{
					num = 1397774354;
					num4 = num;
				}
				else
				{
					num = 1397774356;
					num4 = num;
				}
			}
			goto IL_0010;
			IL_007e:
			controllerVibrator = base.extension as IControllerVibrator;
			num = 1397774353;
			goto IL_0015;
			IL_0091:
			if (!_supportsVibration)
			{
				return;
			}
			goto IL_007e;
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			base.UpdateData(updateLoop);
			int num2 = default(int);
			while (true)
			{
				int num = 1972982979;
				while (true)
				{
					switch (num ^ 0x759954C1)
					{
					case 0:
						break;
					case 3:
						_hats[num2].KLhVytWTxZfEwTEmoGmNtOGgDXib(updateLoop, ROoGdHjYclVKlAjCTYtzRRhBjqvj);
						num = 1972982980;
						continue;
					case 1:
					{
						int num3;
						if (_hats[num2] == null)
						{
							num = 1972982980;
							num3 = num;
						}
						else
						{
							num = 1972982978;
							num3 = num;
						}
						continue;
					}
					case 5:
						num2++;
						num = 1972982981;
						continue;
					case 2:
						num2 = 0;
						num = 1972982981;
						continue;
					default:
						if (num2 >= _hatCount)
						{
							CheckVibrationTimeout();
							return;
						}
						goto case 1;
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
				int num = 1588141761;
				while (true)
				{
					switch (num ^ 0x5EA91EC0)
					{
					case 0:
						goto IL_0004;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0004:
					num = 1588141762;
				}
			}
		}

		private void UpdateControllerInfo(IInputManagerJoystickPublic joystick)
		{
			_sourceJoystick = joystick;
			if (joystick == null)
			{
				goto IL_000a;
			}
			goto IL_005b;
			IL_000a:
			int num = -411113201;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ -411113204)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					goto IL_0038;
				case 6:
					goto IL_005b;
				case 3:
					return;
				case 5:
					goto IL_007e;
				case 1:
					_name = joystick.name;
					num = -411113202;
					continue;
				case 2:
					return;
				}
				break;
				IL_0038:
				int num2;
				if (!(joystick.name != string.Empty))
				{
					num = -411113202;
					num2 = num;
				}
				else
				{
					num = -411113203;
					num2 = num;
				}
			}
			goto IL_000a;
			IL_005b:
			if (base.extension != null)
			{
				PtFyTWtbcoQAXecFTjaAQlkNBsW(joystick.extension);
				num = -411113208;
				goto IL_000f;
			}
			goto IL_007e;
			IL_007e:
			XSCFExJHpLZlPntjxNolSkPZvkYM(joystick.extension);
			num = -411113208;
			goto IL_000f;
		}

		internal override void Clear()
		{
			base.Clear();
			StopVibration();
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (!_supportsLocalVibration)
			{
				goto IL_004c;
			}
			Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
			int num = 0;
			goto IL_0068;
			IL_004c:
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			int num2;
			if (controllerVibrator != null)
			{
				controllerVibrator.StopVibration();
				num2 = -2006621697;
				goto IL_002b;
			}
			return;
			IL_0068:
			int num3;
			if (num < _localVibrationMotorCount)
			{
				num2 = -2006621703;
				num3 = num2;
			}
			else
			{
				num2 = -2006621699;
				num3 = num2;
			}
			goto IL_002b;
			IL_002b:
			while (true)
			{
				switch (num2 ^ -2006621699)
				{
				case 3:
					num2 = -2006621703;
					continue;
				default:
					return;
				case 0:
					break;
				case 1:
					goto IL_0068;
				case 4:
					_localVibrationStopTimers[num].Clear();
					num++;
					num2 = -2006621700;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_004c;
		}

		private void CheckVibrationTimeout()
		{
			if (!_supportsVibration)
			{
				return;
			}
			while (_supportsLocalVibration)
			{
				while (true)
				{
					int num = 0;
					int num2 = 1510488366;
					while (true)
					{
						switch (num2 ^ 0x5A08392A)
						{
						case 0:
							num2 = 1510488367;
							continue;
						case 1:
							if (_localVibrationStopTimers[num].Update())
							{
								SetVibration(num, 0f, false);
								num2 = 1510488360;
								continue;
							}
							goto case 2;
						case 3:
							break;
						case 5:
							goto end_IL_0056;
						case 2:
							num++;
							num2 = 1510488366;
							continue;
						default:
							if (num >= _localVibrationMotorCount)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
					continue;
					end_IL_0056:
					break;
				}
			}
		}

		private void SetLocalVibration(int motorIndex, float motorLevel, float motorDuration, bool stopOtherMotors, bool updateNow)
		{
			if (!_supportsLocalVibration)
			{
				goto IL_000b;
			}
			goto IL_00f4;
			IL_000b:
			int num = 705417346;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2A0BD086)
				{
				case 7:
					break;
				default:
					return;
				case 5:
					goto IL_0054;
				case 11:
					if (stopOtherMotors)
					{
						Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
						num2 = 0;
						num = 705417359;
						continue;
					}
					goto case 3;
				case 1:
					UpdateLocalControllerVibration();
					num = 705417358;
					continue;
				case 3:
					_localVibrationMotorValues[motorIndex] = MathTools.Clamp01(motorLevel);
					if (!(motorLevel <= 0f))
					{
						goto IL_00b0;
					}
					goto case 2;
				case 0:
					return;
				case 9:
					goto IL_00d7;
				case 6:
					goto IL_00f4;
				case 2:
					_localVibrationStopTimers[motorIndex].Clear();
					num = 705417347;
					continue;
				case 10:
					_localVibrationStopTimers[num2].Clear();
					num2++;
					num = 705417359;
					continue;
				case 4:
					return;
				case 12:
					_localVibrationStopTimers[motorIndex].Start(motorDuration);
					num = 705417347;
					continue;
				case 8:
					return;
				}
				break;
				IL_00d7:
				int num3;
				if (num2 >= _localVibrationMotorCount)
				{
					num = 705417349;
					num3 = num;
				}
				else
				{
					num = 705417356;
					num3 = num;
				}
				continue;
				IL_00b0:
				int num4;
				if (motorDuration > 0f)
				{
					num = 705417354;
					num4 = num;
				}
				else
				{
					num = 705417348;
					num4 = num;
				}
				continue;
				IL_0054:
				int num5;
				if (!updateNow)
				{
					num = 705417358;
					num5 = num;
				}
				else
				{
					num = 705417351;
					num5 = num;
				}
			}
			goto IL_000b;
			IL_00f4:
			if (motorIndex < 0)
			{
				return;
			}
			int num6;
			if (motorIndex >= _localVibrationMotorCount)
			{
				num = 705417350;
				num6 = num;
			}
			else
			{
				num = 705417357;
				num6 = num;
			}
			goto IL_0010;
		}

		private void UpdateLocalControllerVibration()
		{
			if (!_supportsVibration)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int num = -839430637;
				while (true)
				{
					switch (num ^ -839430638)
					{
					case 0:
						break;
					case 1:
					{
						int num3;
						if (!_supportsLocalVibration)
						{
							num = -839430640;
							num3 = num;
						}
						else
						{
							num = -839430633;
							num3 = num;
						}
						continue;
					}
					case 6:
						_sourceJoystick.SetVibration(_localVibrationMotorValues[num2], num2);
						num2++;
						num = -839430634;
						continue;
					case 5:
						if (_sourceJoystick == null)
						{
							return;
						}
						goto case 3;
					case 2:
						return;
					case 3:
						num2 = 0;
						num = -839430635;
						continue;
					case 7:
						num = -839430634;
						continue;
					default:
						if (num2 >= _localVibrationMotorValues.Length)
						{
							return;
						}
						goto case 6;
					}
					break;
				}
			}
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
				num = -831869735;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = -831869736;
			goto IL_0013;
			IL_0013:
			switch (num ^ -831869735)
			{
			case 2:
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
