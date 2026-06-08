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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return _joystickTypes_readOnly;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					while (true)
					{
						int num = -2134396946;
						while (true)
						{
							switch (num ^ -2134396948)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return -1L;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -2134396947;
						}
					}
				}
				return _sourceJoystick.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return -1;
				}
				return _sourceJoystick.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return _sourceJoystick.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				}
				return _supportsVibration;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0f;
				}
				if (!_supportsVibration)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
				{
					return controllerVibrator.GetVibration(0);
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
			}
			set
			{
				if (!_supportsVibration)
				{
					goto IL_000b;
				}
				goto IL_00f1;
				IL_000b:
				int num = 1062839220;
				goto IL_0010;
				IL_0010:
				IControllerVibrator controllerVibrator = default(IControllerVibrator);
				while (true)
				{
					switch (num ^ 0x3F59A3BE)
					{
					case 0:
						break;
					default:
						return;
					case 11:
						goto IL_0050;
					case 4:
						return;
					case 2:
						return;
					case 9:
						return;
					case 10:
						return;
					case 6:
						goto IL_0084;
					case 3:
						if (controllerVibrator.vibrationMotorCount > 0)
						{
							controllerVibrator.SetVibration(0, value);
							num = 1062839228;
							continue;
						}
						goto IL_0084;
					case 7:
						SetLocalVibration(0, value, 0f, stopOtherMotors: false, updateNow: true);
						num = 1062839227;
						continue;
					case 8:
						goto IL_00d4;
					case 1:
						goto IL_00f1;
					case 5:
						return;
					}
					break;
					IL_00d4:
					int num2;
					if (0 < _localVibrationMotorCount)
					{
						num = 1062839225;
						num2 = num;
					}
					else
					{
						num = 1062839223;
						num2 = num;
					}
					continue;
					IL_0084:
					int num3;
					if (!_supportsLocalVibration)
					{
						num = 1062839226;
						num3 = num;
					}
					else
					{
						num = 1062839222;
						num3 = num;
					}
					continue;
					IL_0050:
					int num4;
					if (controllerVibrator != null)
					{
						num = 1062839229;
						num4 = num;
					}
					else
					{
						num = 1062839224;
						num4 = num;
					}
				}
				goto IL_000b;
				IL_00f1:
				value = MathTools.Clamp(value, 0f, 1f);
				controllerVibrator = base.extension as IControllerVibrator;
				num = 1062839221;
				goto IL_0010;
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0f;
				}
				if (!_supportsVibration)
				{
					goto IL_0027;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				int num;
				if (controllerVibrator != null)
				{
					num = -2021745592;
					goto IL_002c;
				}
				goto IL_0076;
				IL_002c:
				switch (num ^ -2021745590)
				{
				case 0:
					break;
				case 1:
					return 0f;
				case 2:
					goto IL_0065;
				default:
					return _localVibrationMotorValues[1];
				}
				goto IL_0027;
				IL_0065:
				if (controllerVibrator.vibrationMotorCount > 1)
				{
					return controllerVibrator.GetVibration(1);
				}
				goto IL_0076;
				IL_0076:
				if (!_supportsLocalVibration)
				{
					return 0f;
				}
				if (_localVibrationMotorCount > 1)
				{
					num = -2021745591;
					goto IL_002c;
				}
				return 0f;
				IL_0027:
				num = -2021745589;
				goto IL_002c;
			}
			set
			{
				if (!_supportsVibration)
				{
					goto IL_0008;
				}
				goto IL_0046;
				IL_0008:
				int num = 1746240652;
				goto IL_000d;
				IL_000d:
				IControllerVibrator controllerVibrator = default(IControllerVibrator);
				switch (num ^ 0x68158488)
				{
				case 0:
					break;
				case 3:
					if (!_supportsLocalVibration)
					{
						return;
					}
					goto case 2;
				case 5:
					goto IL_0046;
				case 6:
					if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 1)
					{
						controllerVibrator.SetVibration(1, value);
						return;
					}
					goto case 3;
				case 2:
					if (1 >= _localVibrationMotorCount)
					{
						return;
					}
					goto default;
				case 4:
					return;
				default:
					SetLocalVibration(1, value, 0f, stopOtherMotors: false, updateNow: true);
					return;
				}
				goto IL_0008;
				IL_0046:
				value = MathTools.Clamp(value, 0f, 1f);
				controllerVibrator = base.extension as IControllerVibrator;
				num = 1746240654;
				goto IL_000d;
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return _hatCount;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return hats_readOnly;
			}
		}

		internal int inputManagerId => _sourceJoystick.inputManagerId;

		internal HardwareControllerMapIdentifier hardwareJoystickMapIdentifier
		{
			get
			{
				if (REZiFujnwfIcWniRKvMxDxhPHlx == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return REZiFujnwfIcWniRKvMxDxhPHlx.hardwareMapIdentifier;
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
			if (WhXaNimcOuXdrXZrlSbhrrJNttC != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.quoVIvtygeuHBmJeXGCUKguhrtR(WhXaNimcOuXdrXZrlSbhrrJNttC);
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
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.LkCFQeezyqvcQaogCkWyFVUFlxWV(this, hardwareJoystickTemplateMap));
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
						vPBcgbtXlRkxBJGxiPgEznsEEhOi(list2.ToArray());
					}
				}
			}
			aNzXPWgGkyjIHrJsRxlIZSjJoXv();
		}

		private Joystick(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Joystick, hardwareTypeGuid, axisCount, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			List<int> list2 = default(List<int>);
			int buttonIndex = default(int);
			List<Button> list = default(List<Button>);
			int componentElementIdentifierId = default(int);
			int num2 = default(int);
			HardwareJoystickMap.CompoundElement hatData = default(HardwareJoystickMap.CompoundElement);
			int num3 = default(int);
			while (true)
			{
				int num = -1255304024;
				while (true)
				{
					switch (num ^ -1255304023)
					{
					case 14:
						break;
					case 1:
					{
						int num7;
						if (hardwareMap == null)
						{
							num = -1255304018;
							num7 = num;
						}
						else
						{
							num = -1255304017;
							num7 = num;
						}
						continue;
					}
					case 5:
						_joystickTypes_readOnly = new ReadOnlyCollection<JoystickType>(_joystickTypes);
						num = -1255304032;
						continue;
					case 3:
						list2.Add(buttonIndex);
						num = -1255304008;
						continue;
					case 2:
						list = new List<Button>();
						list2 = new List<int>();
						num = -1255304027;
						continue;
					case 4:
						buttonIndex = hardwareMap.GetButtonIndex(componentElementIdentifierId);
						if (buttonIndex < 0)
						{
							list.Add(null);
							num = -1255304026;
							continue;
						}
						goto case 10;
					case 0:
					{
						int num4;
						if (hardwareMap.joystickTypes.Length != 0)
						{
							num = -1255304028;
							num4 = num;
						}
						else
						{
							num = -1255304018;
							num4 = num;
						}
						continue;
					}
					case 19:
						list.Add(null);
						list2.Add(-1);
						num = -1255304008;
						continue;
					case 17:
						num2++;
						num = -1255304031;
						continue;
					case 13:
						_joystickTypes = hardwareMap.joystickTypes;
						num = -1255304020;
						continue;
					case 21:
						hatData = hardwareMap.GetHatData(num3);
						num = -1255304003;
						continue;
					case 12:
						num2 = 0;
						num = -1255304031;
						continue;
					case 20:
						if (hatData != null)
						{
							goto case 2;
						}
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						_hats[num3] = new Hat(this, hatData.elementIdentifier, "Hat " + num3, new Button[0], new int[0]);
						goto IL_031d;
					case 10:
						list.Add(buttons[buttonIndex]);
						num = -1255304022;
						continue;
					case 6:
					{
						int num6;
						if (hardwareMap.joystickTypes == null)
						{
							num = -1255304018;
							num6 = num;
						}
						else
						{
							num = -1255304023;
							num6 = num;
						}
						continue;
					}
					case 9:
						_hatCount = hardwareMap.hatCount;
						_hats = new Hat[_hatCount];
						num3 = 0;
						num = -1255304005;
						continue;
					case 7:
					{
						JoystickType[] array = new JoystickType[1];
						_joystickTypes = array;
						num = -1255304007;
						continue;
					}
					case 11:
					{
						componentElementIdentifierId = hatData.GetComponentElementIdentifierId(num2);
						int num5;
						if (ArrayTools.Contains(hardwareMap.buttonElementIdentifierIds, componentElementIdentifierId))
						{
							num = -1255304019;
							num5 = num;
						}
						else
						{
							num = -1255304006;
							num5 = num;
						}
						continue;
					}
					case 15:
						list2.Add(-1);
						num = -1255304008;
						continue;
					case 16:
						num = -1255304020;
						continue;
					default:
						if (num2 < hatData.elementCount)
						{
							goto case 11;
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
						goto IL_031d;
					case 18:
						{
							if (num3 >= _hatCount)
							{
								hats_readOnly = new ReadOnlyCollection<Hat>(_hats);
								return;
							}
							goto case 21;
						}
						IL_031d:
						num3++;
						goto case 18;
					}
					break;
				}
			}
		}

		internal bool IsType(JoystickType joystickType)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num = _joystickTypes.Length;
			int num2 = -1697188077;
			goto IL_0012;
			IL_0012:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1697188078)
				{
				case 0:
					break;
				case 3:
					if (_joystickTypes[num3] == joystickType)
					{
						num2 = -1697188074;
						continue;
					}
					num3++;
					num2 = -1697188073;
					continue;
				case 1:
					num3 = 0;
					num2 = -1697188073;
					continue;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				case 4:
					return true;
				default:
					if (num3 >= num)
					{
						return false;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num2 = -1697188080;
			goto IL_0012;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = 1232698648;
					while (true)
					{
						switch (num ^ 0x49797D1A)
						{
						case 0:
							break;
						case 2:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = 1232698651;
							continue;
						case 1:
							return;
						default:
							goto end_IL_000d;
						}
						break;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			goto IL_00f7;
			IL_00f7:
			int num;
			int num2;
			if (!_supportsVibration)
			{
				num = -1818742430;
				num2 = num;
			}
			else
			{
				num = -1818742431;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -1818742418;
			goto IL_0021;
			IL_0021:
			IControllerVibrator controllerVibrator = default(IControllerVibrator);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1818742428)
				{
				case 11:
					break;
				default:
					return;
				case 1:
					UpdateLocalControllerVibration();
					num = -1818742419;
					continue;
				case 4:
					goto IL_0076;
				case 6:
					return;
				case 8:
					if (_localVibrationMotorCount > 1)
					{
						SetLocalVibration(1, rightMotorLevel, rightMotorDuration, stopOtherMotors: false, updateNow: false);
						num = -1818742427;
						continue;
					}
					goto case 1;
				case 7:
					SetLocalVibration(0, leftMotorLevel, leftMotorDuration, stopOtherMotors: false, updateNow: false);
					num = -1818742420;
					continue;
				case 2:
					return;
				case 12:
					if (controllerVibrator == null)
					{
						goto IL_0076;
					}
					num3 = controllerVibrator.vibrationMotorCount;
					if (num3 > 0)
					{
						controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
						num = -1818742428;
						continue;
					}
					goto case 0;
				case 3:
					goto IL_00f7;
				case 0:
					if (num3 > 1)
					{
						controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
						num = -1818742432;
						continue;
					}
					goto IL_0076;
				case 13:
					goto IL_012e;
				case 10:
					return;
				case 5:
					controllerVibrator = base.extension as IControllerVibrator;
					num = -1818742424;
					continue;
				case 9:
					return;
				}
				break;
				IL_012e:
				int num4;
				if (_localVibrationMotorCount > 0)
				{
					num = -1818742429;
					num4 = num;
				}
				else
				{
					num = -1818742420;
					num4 = num;
				}
				continue;
				IL_0076:
				int num5;
				if (_supportsLocalVibration)
				{
					num = -1818742423;
					num5 = num;
				}
				else
				{
					num = -1818742426;
					num5 = num;
				}
			}
			goto IL_001c;
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			goto IL_009a;
			IL_0010:
			int num = -220774769;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -220774773)
				{
				case 5:
					break;
				default:
					return;
				case 4:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				case 8:
					if (motorIndex >= _localVibrationMotorCount)
					{
						return;
					}
					goto case 7;
				case 1:
					return;
				case 6:
					if (base.extension is IControllerVibrator controllerVibrator)
					{
						controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
						num = -220774773;
						continue;
					}
					goto case 0;
				case 3:
					goto IL_009a;
				case 0:
					if (!_supportsLocalVibration)
					{
						return;
					}
					goto case 8;
				case 7:
					SetLocalVibration(motorIndex, motorLevel, duration, stopOtherMotors, updateNow: true);
					num = -220774775;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_0010;
			IL_009a:
			if (!_supportsVibration)
			{
				return;
			}
			int num2;
			if (motorIndex >= 0)
			{
				num = -220774771;
				num2 = num;
			}
			else
			{
				num = -220774774;
				num2 = num;
			}
			goto IL_0015;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				num = 1932741632;
				goto IL_0030;
			}
			goto IL_0051;
			IL_009a:
			if (motorIndex >= _localVibrationMotorCount)
			{
				return 0f;
			}
			return _localVibrationMotorValues[motorIndex];
			IL_0030:
			while (true)
			{
				switch (num ^ 0x73334C02)
				{
				case 3:
					break;
				case 1:
					goto IL_0051;
				case 0:
					goto IL_006a;
				case 2:
					goto IL_008a;
				default:
					return 0f;
				}
				break;
				IL_008a:
				if (controllerVibrator != null)
				{
					num = 1932741634;
					continue;
				}
				goto IL_007b;
				IL_007b:
				if (!_supportsLocalVibration)
				{
					num = 1932741638;
					continue;
				}
				goto IL_009a;
				IL_006a:
				if (motorIndex < controllerVibrator.vibrationMotorCount)
				{
					return controllerVibrator.GetVibration(motorIndex);
				}
				goto IL_007b;
			}
			goto IL_002b;
			IL_0051:
			return 0f;
			IL_002b:
			num = 1932741635;
			goto IL_0030;
		}

		public void StopVibration()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			goto IL_00ed;
			IL_0010:
			int num = -1623445952;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1623445949)
				{
				case 5:
					break;
				default:
					return;
				case 6:
					goto IL_004d;
				case 7:
					num2++;
					num = -1623445950;
					continue;
				case 2:
					goto IL_0074;
				case 0:
					goto IL_009c;
				case 4:
					_localVibrationStopTimers[num2].Clear();
					num = -1623445948;
					continue;
				case 1:
					goto IL_00d0;
				case 9:
					goto IL_00ed;
				case 3:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return;
				case 8:
					return;
				}
				break;
				IL_00d0:
				int num3;
				if (num2 >= _localVibrationMotorCount)
				{
					num = -1623445949;
					num3 = num;
				}
				else
				{
					num = -1623445945;
					num3 = num;
				}
			}
			goto IL_0010;
			IL_009c:
			if (_sourceJoystick != null)
			{
				_sourceJoystick.StopVibration();
				num = -1623445941;
				goto IL_0015;
			}
			return;
			IL_004d:
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
				num = -1623445951;
				goto IL_0015;
			}
			goto IL_0074;
			IL_0074:
			if (_supportsLocalVibration)
			{
				Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
				num2 = 0;
				num = -1623445950;
				goto IL_0015;
			}
			goto IL_009c;
			IL_00ed:
			if (!_supportsVibration)
			{
				return;
			}
			goto IL_004d;
		}

		internal virtual void UpdateData(UpdateLoopType updateLoop)
		{
			kckuoUXEwQcigNbCseRHnXueOkT(updateLoop);
			int num = 0;
			while (num < _hatCount)
			{
				while (true)
				{
					int num2;
					if (_hats[num] != null)
					{
						_hats[num].fEfTuMgIgNspmcJifDAbjyclSfZ(updateLoop, cMcAtEwaThLpgGZfIIRmVCJQjDU);
						num2 = -1838003113;
						goto IL_0010;
					}
					goto IL_0052;
					IL_0010:
					while (true)
					{
						switch (num2 ^ -1838003113)
						{
						case 2:
							num2 = -1838003116;
							continue;
						case 3:
							break;
						case 0:
							goto IL_0052;
						default:
							goto end_IL_002d;
						}
						break;
					}
					continue;
					IL_0052:
					num++;
					num2 = -1838003114;
					goto IL_0010;
					continue;
					end_IL_002d:
					break;
				}
			}
			CheckVibrationTimeout();
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
			if (controller != null)
			{
				UpdateControllerInfo(controller.sourceJoystick);
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
				if (base.extension != null)
				{
					cATIZLBUFegHKkJeQETToGESSlfq(joystick.extension);
					num = -1477074760;
					goto IL_0010;
				}
				goto IL_0050;
				IL_0010:
				while (true)
				{
					switch (num ^ -1477074757)
					{
					case 0:
						num = -1477074753;
						continue;
					default:
						return;
					case 4:
						break;
					case 5:
						goto IL_0050;
					case 3:
						goto IL_0063;
					case 1:
						_name = joystick.name;
						num = -1477074759;
						continue;
					case 2:
						return;
					}
					break;
					IL_0063:
					int num2;
					if (!(joystick.name != string.Empty))
					{
						num = -1477074759;
						num2 = num;
					}
					else
					{
						num = -1477074758;
						num2 = num;
					}
				}
				continue;
				IL_0050:
				crQnLutgKZoSSMlUmZAkqAvIErv(joystick.extension);
				num = -1477074760;
				goto IL_0010;
			}
		}

		internal virtual void Clear()
		{
			tAgADqjTsMUxSqYXeDyJIdETYRAp();
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
				goto IL_0024;
			}
			goto IL_0059;
			IL_0059:
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			int num2 = -1306868043;
			goto IL_0029;
			IL_0024:
			num2 = -1306868047;
			goto IL_0029;
			IL_0029:
			while (true)
			{
				switch (num2 ^ -1306868041)
				{
				case 0:
					break;
				default:
					return;
				case 6:
					num2 = -1306868046;
					continue;
				case 1:
					goto IL_0059;
				case 5:
					goto IL_006c;
				case 2:
					if (controllerVibrator != null)
					{
						controllerVibrator.StopVibration();
						num2 = -1306868044;
						continue;
					}
					return;
				case 4:
					_localVibrationStopTimers[num].Clear();
					num++;
					num2 = -1306868046;
					continue;
				case 3:
					return;
				}
				break;
				IL_006c:
				int num3;
				if (num < _localVibrationMotorCount)
				{
					num2 = -1306868045;
					num3 = num2;
				}
				else
				{
					num2 = -1306868042;
					num3 = num2;
				}
			}
			goto IL_0024;
		}

		private void CheckVibrationTimeout()
		{
			if (!_supportsVibration)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (!_supportsLocalVibration)
				{
					num = 1865397983;
					num2 = num;
				}
				else
				{
					num = 1865397980;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6F2FB6D8)
					{
					case 5:
						num = 1865397979;
						continue;
					default:
						return;
					case 0:
						num3++;
						num = 1865397968;
						continue;
					case 7:
						return;
					case 8:
					{
						int num4;
						if (num3 >= _localVibrationMotorCount)
						{
							num = 1865397977;
							num4 = num;
						}
						else
						{
							num = 1865397982;
							num4 = num;
						}
						continue;
					}
					case 6:
						if (_localVibrationStopTimers[num3].Update())
						{
							SetVibration(num3, 0f, stopOtherMotors: false);
							num = 1865397976;
							continue;
						}
						goto case 0;
					case 2:
						num = 1865397968;
						continue;
					case 4:
						num3 = 0;
						num = 1865397978;
						continue;
					case 3:
						break;
					case 1:
						return;
					}
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
			goto IL_00d4;
			IL_000b:
			int num = 2052867355;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x7A5C451D)
				{
				case 7:
					break;
				default:
					return;
				case 0:
					if (stopOtherMotors)
					{
						Array.Clear(_localVibrationMotorValues, 0, _localVibrationMotorValues.Length);
						num2 = 0;
						num = 2052867353;
						continue;
					}
					goto case 8;
				case 3:
					return;
				case 2:
					_localVibrationStopTimers[motorIndex].Clear();
					num = 2052867348;
					continue;
				case 8:
					_localVibrationMotorValues[motorIndex] = MathTools.Clamp01(motorLevel);
					if (motorLevel <= 0f)
					{
						goto case 2;
					}
					goto IL_00ae;
				case 9:
					num = 2052867345;
					continue;
				case 10:
					goto IL_00d4;
				case 12:
					if (updateNow)
					{
						UpdateLocalControllerVibration();
						num = 2052867344;
						continue;
					}
					return;
				case 6:
					return;
				case 4:
					num = 2052867352;
					continue;
				case 11:
					_localVibrationStopTimers[num2].Clear();
					num2++;
					num = 2052867352;
					continue;
				case 1:
					_localVibrationStopTimers[motorIndex].Start(motorDuration);
					num = 2052867345;
					continue;
				case 5:
					goto IL_0152;
				case 13:
					return;
				}
				break;
				IL_0152:
				int num3;
				if (num2 >= _localVibrationMotorCount)
				{
					num = 2052867349;
					num3 = num;
				}
				else
				{
					num = 2052867350;
					num3 = num;
				}
				continue;
				IL_00ae:
				int num4;
				if (motorDuration <= 0f)
				{
					num = 2052867359;
					num4 = num;
				}
				else
				{
					num = 2052867356;
					num4 = num;
				}
			}
			goto IL_000b;
			IL_00d4:
			if (motorIndex < 0)
			{
				return;
			}
			int num5;
			if (motorIndex < _localVibrationMotorCount)
			{
				num = 2052867357;
				num5 = num;
			}
			else
			{
				num = 2052867358;
				num5 = num;
			}
			goto IL_0010;
		}

		private void UpdateLocalControllerVibration()
		{
			if (_supportsVibration)
			{
				if (!_supportsLocalVibration)
				{
					goto IL_0010;
				}
				goto IL_0069;
			}
			return;
			IL_0080:
			int num = 0;
			int num2 = -1044225438;
			goto IL_0015;
			IL_0010:
			num2 = -1044225440;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -1044225439)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					return;
				case 5:
					_sourceJoystick.SetVibration(_localVibrationMotorValues[num], num);
					num++;
					num2 = -1044225435;
					continue;
				case 0:
					goto IL_0069;
				case 3:
					num2 = -1044225435;
					continue;
				case 6:
					goto IL_0080;
				case 4:
					goto IL_0089;
				case 7:
					return;
				}
				break;
				IL_0089:
				int num3;
				if (num < _localVibrationMotorValues.Length)
				{
					num2 = -1044225436;
					num3 = num2;
				}
				else
				{
					num2 = -1044225434;
					num3 = num2;
				}
			}
			goto IL_0010;
			IL_0069:
			if (_sourceJoystick == null)
			{
				return;
			}
			goto IL_0080;
		}

		private void StopAllVibration()
		{
		}

		internal static int CompareById_Ascending(Joystick a, Joystick b)
		{
			if (a.inputManagerId < b.inputManagerId)
			{
				return -1;
			}
			if (a.inputManagerId > b.inputManagerId)
			{
				return 1;
			}
			return 0;
		}
	}
}
