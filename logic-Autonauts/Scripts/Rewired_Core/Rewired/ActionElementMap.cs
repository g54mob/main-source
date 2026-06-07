using System;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class ActionElementMap
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionCategoryId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ControllerElementType _elementType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal int _elementIdentifierId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal AxisRange _axisRange;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal bool _invert;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal Pole _axisContribution;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal KeyboardKeyCode _keyboardKeyCode;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey1;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey2;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap yAkjWJqxMpaNcNJFRMpKjoUYObX;

		[NonSerialized]
		internal bool gmbIkkevNmPVGSTIwKcAwoPYANrc = true;

		[NonSerialized]
		internal string FcZlvtEnXFMiEicBtcTcDitrjYGb;

		[NonSerialized]
		internal string YloFuagLjOEDSYNjORAVEzRtYpV;

		[NonSerialized]
		internal int ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;

		[NonSerialized]
		internal readonly int KAixZgRycuVSHIYaEVNGzKGIdgV;

		private static int uidCounter = 0;

		private static StringBuilder s_toStringSB;

		public int actionId
		{
			get
			{
				return _actionId;
			}
			set
			{
				if (value == _actionId)
				{
					goto IL_0009;
				}
				goto IL_004b;
				IL_0009:
				int num = 684390588;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x28CAF8BF)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						return;
					case 2:
						if (Application.isPlaying)
						{
							OvrPUMRcXKoUwMYTjEoLkNBMHkz();
							num = 684390587;
							continue;
						}
						return;
					case 1:
						goto IL_004b;
					case 4:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_004b:
				_actionId = value;
				num = 684390589;
				goto IL_000e;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return _elementType;
			}
			internal set
			{
				_elementType = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return _elementIdentifierId;
			}
			set
			{
				if (_elementIdentifierId == value)
				{
					return;
				}
				Controller controller = default(Controller);
				Controller.Element elementById = default(Controller.Element);
				while (true)
				{
					_elementIdentifierId = value;
					int num;
					int num2;
					if (Application.isPlaying)
					{
						num = -1443434537;
						num2 = num;
					}
					else
					{
						num = -1443434538;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1443434543)
						{
						case 4:
							num = -1443434542;
							continue;
						default:
							return;
						case 5:
						{
							controller = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.YVImgJAVYrCFxvRCiDMpssMfsKM(yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType, yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerId, true);
							int num4;
							if (controller == null)
							{
								num = -1443434538;
								num4 = num;
							}
							else
							{
								num = -1443434543;
								num4 = num;
							}
							continue;
						}
						case 7:
							if (Application.isPlaying)
							{
								rlmHPtRaQxhZqxiQpUHlvKLFmAK(false);
								num = -1443434544;
								continue;
							}
							return;
						case 3:
							break;
						case 6:
						{
							int num5;
							if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
							{
								num = -1443434538;
								num5 = num;
							}
							else
							{
								num = -1443434540;
								num5 = num;
							}
							continue;
						}
						case 2:
							yAkjWJqxMpaNcNJFRMpKjoUYObX.DWfqRrTmjQCuqbFAiFRBseSVqsw(KAixZgRycuVSHIYaEVNGzKGIdgV, elementById.type);
							num = -1443434538;
							continue;
						case 0:
							elementById = controller.GetElementById(value);
							if (elementById != null)
							{
								int num3;
								if (elementById.type == _elementType)
								{
									num = -1443434538;
									num3 = num;
								}
								else
								{
									num = -1443434541;
									num3 = num;
								}
								continue;
							}
							goto case 7;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return _axisRange;
			}
			set
			{
				if (_axisRange == value)
				{
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (_elementType == ControllerElementType.Axis)
					{
						num = -492450144;
						num2 = num;
					}
					else
					{
						num = -492450141;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -492450142)
						{
						case 0:
							num = -492450137;
							continue;
						default:
							return;
						case 5:
							break;
						case 1:
							if (Application.isPlaying)
							{
								Logger.LogWarning("You cannot change AxisRange of a non-Axis mapping.");
								return;
							}
							goto case 2;
						case 4:
						{
							int num3;
							if (!Application.isPlaying)
							{
								num = -492450143;
								num3 = num;
							}
							else
							{
								num = -492450140;
								num3 = num;
							}
							continue;
						}
						case 6:
							rlmHPtRaQxhZqxiQpUHlvKLFmAK(false);
							num = -492450143;
							continue;
						case 2:
							_axisRange = value;
							num = -492450138;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		public bool invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		public Pole axisContribution
		{
			get
			{
				return _axisContribution;
			}
			set
			{
				if (_axisContribution == value)
				{
					return;
				}
				while (true)
				{
					_axisContribution = value;
					int num = 770858604;
					while (true)
					{
						switch (num ^ 0x2DF25E6E)
						{
						case 3:
							num = 770858607;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							if (Application.isPlaying)
							{
								rlmHPtRaQxhZqxiQpUHlvKLFmAK(false);
								num = 770858606;
								continue;
							}
							return;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		public KeyboardKeyCode keyboardKeyCode
		{
			get
			{
				return _keyboardKeyCode;
			}
			set
			{
				if (_keyboardKeyCode == value)
				{
					goto IL_0009;
				}
				goto IL_003f;
				IL_0009:
				int num = -987216904;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -987216901)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						return;
					case 6:
						goto IL_003f;
					case 2:
						Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
						return;
					case 5:
						goto IL_0077;
					case 1:
						if (Application.isPlaying)
						{
							rlmHPtRaQxhZqxiQpUHlvKLFmAK(true);
							num = -987216897;
							continue;
						}
						return;
					case 4:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_003f:
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX != null)
				{
					int num2;
					if (yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType == ControllerType.Keyboard)
					{
						num = -987216898;
						num2 = num;
					}
					else
					{
						num = -987216903;
						num2 = num;
					}
					goto IL_000e;
				}
				goto IL_0077;
				IL_0077:
				_keyboardKeyCode = value;
				num = -987216902;
				goto IL_000e;
			}
		}

		public ModifierKey modifierKey1
		{
			get
			{
				return _modifierKey1;
			}
			set
			{
				if (_modifierKey1 == value)
				{
					goto IL_0009;
				}
				goto IL_0074;
				IL_0009:
				int num = 1600444057;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x5F64D69B)
					{
					case 6:
						break;
					default:
						return;
					case 0:
						rlmHPtRaQxhZqxiQpUHlvKLFmAK(true);
						num = 1600444063;
						continue;
					case 7:
						_modifierKey1 = value;
						if (Application.isPlaying)
						{
							KjvZXJhpsdUBZKRhlotuDjUkonN();
							num = 1600444059;
							continue;
						}
						return;
					case 5:
						return;
					case 2:
						return;
					case 3:
						goto IL_0074;
					case 1:
						if (yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType != ControllerType.Keyboard)
						{
							Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
							num = 1600444062;
							continue;
						}
						goto case 7;
					case 4:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0074:
				int num2;
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					num = 1600444060;
					num2 = num;
				}
				else
				{
					num = 1600444058;
					num2 = num;
				}
				goto IL_000e;
			}
		}

		public ModifierKey modifierKey2
		{
			get
			{
				return _modifierKey2;
			}
			set
			{
				if (_modifierKey2 == value)
				{
					return;
				}
				while (yAkjWJqxMpaNcNJFRMpKjoUYObX == null || yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType == ControllerType.Keyboard)
				{
					while (true)
					{
						_modifierKey2 = value;
						int num;
						int num2;
						if (Application.isPlaying)
						{
							num = -2144362396;
							num2 = num;
						}
						else
						{
							num = -2144362400;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -2144362396)
							{
							case 5:
								num = -2144362395;
								continue;
							default:
								return;
							case 3:
								rlmHPtRaQxhZqxiQpUHlvKLFmAK(true);
								num = -2144362400;
								continue;
							case 0:
								KjvZXJhpsdUBZKRhlotuDjUkonN();
								num = -2144362393;
								continue;
							case 2:
								break;
							case 1:
								goto end_IL_004f;
							case 4:
								return;
							}
							break;
						}
						continue;
						end_IL_004f:
						break;
					}
				}
				Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
			}
		}

		public ModifierKey modifierKey3
		{
			get
			{
				return _modifierKey3;
			}
			set
			{
				if (_modifierKey3 == value)
				{
					return;
				}
				while (true)
				{
					IL_0065:
					int num;
					if (yAkjWJqxMpaNcNJFRMpKjoUYObX != null && yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType != ControllerType.Keyboard)
					{
						Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
						num = 1111394811;
						goto IL_000f;
					}
					goto IL_0034;
					IL_0034:
					_modifierKey3 = value;
					num = 1111394808;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ 0x423E89F9)
						{
						case 0:
							num = 1111394813;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							return;
						case 1:
							if (Application.isPlaying)
							{
								KjvZXJhpsdUBZKRhlotuDjUkonN();
								rlmHPtRaQxhZqxiQpUHlvKLFmAK(true);
								num = 1111394812;
								continue;
							}
							return;
						case 4:
							goto IL_0065;
						case 5:
							return;
						}
						break;
					}
					goto IL_0034;
				}
			}
		}

		public AxisType axisType
		{
			get
			{
				if (_elementType != ControllerElementType.Axis)
				{
					return AxisType.None;
				}
				if (_axisRange == AxisRange.Full)
				{
					return AxisType.Normal;
				}
				return AxisType.Split;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
				modifierKeyFlags |= Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey1);
				while (true)
				{
					int num = 980094060;
					while (true)
					{
						switch (num ^ 0x3A6B0C6D)
						{
						case 0:
							break;
						case 1:
							goto IL_002e;
						default:
							return modifierKeyFlags;
						}
						break;
						IL_002e:
						modifierKeyFlags |= Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey2);
						modifierKeyFlags |= Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey3);
						num = 980094063;
					}
				}
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return Keyboard.KeyboardKeyCodeToKeyCode(_keyboardKeyCode);
			}
			set
			{
				keyboardKeyCode = Keyboard.KeyCodeToKeyboardKeyCode(value);
			}
		}

		public bool hasModifiers
		{
			get
			{
				if (_keyboardKeyCode == KeyboardKeyCode.None)
				{
					goto IL_0008;
				}
				int num;
				if (_modifierKey1 == ModifierKey.None)
				{
					int num2;
					if (_modifierKey2 == ModifierKey.None)
					{
						num = -595213792;
						num2 = num;
					}
					else
					{
						num = -595213791;
						num2 = num;
					}
					goto IL_000d;
				}
				goto IL_005c;
				IL_000d:
				while (true)
				{
					switch (num ^ -595213790)
					{
					case 0:
						break;
					case 1:
						return false;
					case 2:
						goto IL_004d;
					default:
						goto IL_005c;
					}
					break;
					IL_004d:
					if (_modifierKey3 != ModifierKey.None)
					{
						num = -595213791;
						continue;
					}
					return false;
				}
				goto IL_0008;
				IL_0008:
				num = -595213789;
				goto IL_000d;
				IL_005c:
				return true;
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				return yAkjWJqxMpaNcNJFRMpKjoUYObX;
			}
		}

		public bool enabled
		{
			get
			{
				return gmbIkkevNmPVGSTIwKcAwoPYANrc;
			}
			set
			{
				gmbIkkevNmPVGSTIwKcAwoPYANrc = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return FcZlvtEnXFMiEicBtcTcDitrjYGb;
			}
		}

		public string actionDescriptiveName
		{
			get
			{
				return YloFuagLjOEDSYNjORAVEzRtYpV;
			}
		}

		public int elementIndex
		{
			get
			{
				return ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
			}
		}

		public int id
		{
			get
			{
				return KAixZgRycuVSHIYaEVNGzKGIdgV;
			}
		}

		private bool isKeyboardMap
		{
			get
			{
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX != null)
				{
					return yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType == ControllerType.Keyboard;
				}
				return false;
			}
		}

		private static int nextUid
		{
			get
			{
				int result = uidCounter;
				if (uidCounter == int.MaxValue)
				{
					uidCounter = 0;
				}
				else
				{
					while (true)
					{
						uidCounter++;
						int num = -247616146;
						while (true)
						{
							switch (num ^ -247616145)
							{
							case 0:
								num = -247616147;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0038;
							}
							break;
						}
						continue;
						end_IL_0038:
						break;
					}
				}
				return result;
			}
		}

		internal static bool YuthJqnjOQMiolEvklDruXMdObP(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num;
			if (P_0._actionId != -1)
			{
				num = -71202620;
				goto IL_0008;
			}
			goto IL_0052;
			IL_0008:
			while (true)
			{
				switch (num ^ -71202617)
				{
				case 0:
					break;
				case 1:
					return false;
				case 3:
					goto IL_0037;
				default:
					return false;
				}
				break;
				IL_0037:
				if (!ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.hVhfCpEYePxtliVMkmzCRpiiDkB(P_0._actionId))
				{
					num = -71202619;
					continue;
				}
				goto IL_0052;
			}
			goto IL_0003;
			IL_0052:
			return true;
			IL_0003:
			num = -71202618;
			goto IL_0008;
		}

		internal static void LjmtPIxpGXMhDrlIicBiSLaPJef(ActionElementMap P_0, ActionElementMap P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			while (true)
			{
				int num;
				int num2;
				if (P_1 == null)
				{
					num = -1356427356;
					num2 = num;
				}
				else
				{
					num = -1356427352;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1356427358)
					{
					case 5:
						num = -1356427354;
						continue;
					case 4:
						break;
					case 8:
						P_1.yAkjWJqxMpaNcNJFRMpKjoUYObX = P_0.yAkjWJqxMpaNcNJFRMpKjoUYObX;
						num = -1356427355;
						continue;
					case 7:
						P_1.FcZlvtEnXFMiEicBtcTcDitrjYGb = P_0.FcZlvtEnXFMiEicBtcTcDitrjYGb;
						P_1.ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = P_0.ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
						P_1.gmbIkkevNmPVGSTIwKcAwoPYANrc = P_0.gmbIkkevNmPVGSTIwKcAwoPYANrc;
						num = -1356427358;
						continue;
					case 6:
						throw new ArgumentNullException("destination");
					case 10:
						P_1._actionId = P_0._actionId;
						P_1._actionCategoryId = P_0._actionCategoryId;
						P_1._elementType = P_0._elementType;
						num = -1356427360;
						continue;
					case 1:
						P_1._keyboardKeyCode = P_0._keyboardKeyCode;
						P_1._modifierKey1 = P_0._modifierKey1;
						num = -1356427349;
						continue;
					case 2:
						P_1._elementIdentifierId = P_0._elementIdentifierId;
						num = -1356427359;
						continue;
					case 9:
						P_1._modifierKey2 = P_0._modifierKey2;
						P_1._modifierKey3 = P_0._modifierKey3;
						num = -1356427350;
						continue;
					case 3:
						P_1._axisRange = P_0._axisRange;
						P_1._invert = P_0._invert;
						P_1._axisContribution = P_0._axisContribution;
						num = -1356427357;
						continue;
					default:
						P_1.YloFuagLjOEDSYNjORAVEzRtYpV = P_0.YloFuagLjOEDSYNjORAVEzRtYpV;
						return;
					}
					break;
				}
			}
		}

		public ActionElementMap()
		{
			while (true)
			{
				int num = -548943969;
				while (true)
				{
					switch (num ^ -548943971)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						KAixZgRycuVSHIYaEVNGzKGIdgV = nextUid;
						_actionId = -1;
						num = -548943972;
						continue;
					case 4:
						gmbIkkevNmPVGSTIwKcAwoPYANrc = true;
						num = -548943970;
						continue;
					case 1:
						_elementIdentifierId = -1;
						num = -548943975;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public ActionElementMap(ActionElementMap map)
			: this()
		{
			LjmtPIxpGXMhDrlIicBiSLaPJef(map, this);
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_elementIdentifierId = elementIdentifierId;
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId, Pole axisContribution, AxisRange axisRange)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_elementIdentifierId = elementIdentifierId;
			_axisContribution = axisContribution;
			_axisRange = axisRange;
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId, Pole axisContribution, AxisRange axisRange, bool invert)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_elementIdentifierId = elementIdentifierId;
			_axisContribution = axisContribution;
			_axisRange = axisRange;
			_invert = invert;
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, Pole axisContribution, KeyboardKeyCode keyboardKeyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
			: this()
		{
			_actionId = actionId;
			_elementType = elementType;
			_axisContribution = axisContribution;
			_keyboardKeyCode = keyboardKeyCode;
			_modifierKey1 = modifierKey1;
			_modifierKey2 = modifierKey2;
			_modifierKey3 = modifierKey3;
			SPsZpAVIfyQHmRuTeLlHeSGNAml();
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!TiHoOcTHeBvhpgraTMTxHmDEqau(elementAssignment.type))
			{
				goto IL_000f;
			}
			int num;
			int num2;
			if (!isKeyboardMap)
			{
				num = -1530061859;
				num2 = num;
			}
			else
			{
				num = -1530061861;
				num2 = num;
			}
			goto IL_0014;
			IL_000f:
			num = -1530061864;
			goto IL_0014;
			IL_0014:
			KeyCode keyCode = default(KeyCode);
			while (true)
			{
				switch (num ^ -1530061863)
				{
				case 3:
					break;
				case 1:
					return false;
				case 4:
					if (_keyboardKeyCode != KeyboardKeyCode.None)
					{
						num = -1530061861;
						continue;
					}
					return HEJfEHICEbmATnhFUglvALxrTwxM(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
				case 2:
					keyCode = elementAssignment.keyboardKey;
					if (keyCode == KeyCode.None)
					{
						keyCode = ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Keyboard.GetKeyCodeById(elementAssignment.elementIdentifierId);
						num = -1530061863;
						continue;
					}
					goto default;
				default:
					return bdoGqKcXYHAowjPlfnWfQEHrNycJ(Keyboard.KeyCodeToKeyboardKeyCode(keyCode), elementAssignment.modifierKeyFlags);
				}
				break;
			}
			goto IL_000f;
		}

		public bool CheckForAssignmentConflict(ActionElementMap elementMap)
		{
			if (elementMap == null)
			{
				goto IL_0025;
			}
			if (elementMap == this)
			{
				goto IL_0007;
			}
			if (_elementType != elementMap._elementType)
			{
				return false;
			}
			int num;
			if (!isKeyboardMap)
			{
				if (_keyboardKeyCode != KeyboardKeyCode.None)
				{
					num = -7255862;
					goto IL_000c;
				}
				return HEJfEHICEbmATnhFUglvALxrTwxM(elementMap._elementIdentifierId, elementMap._axisRange);
			}
			goto IL_004e;
			IL_004e:
			return bdoGqKcXYHAowjPlfnWfQEHrNycJ(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
			IL_0025:
			return false;
			IL_0007:
			num = -7255863;
			goto IL_000c;
			IL_000c:
			switch (num ^ -7255864)
			{
			case 0:
				break;
			case 1:
				goto IL_0025;
			default:
				goto IL_004e;
			}
			goto IL_0007;
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.hVhfCpEYePxtliVMkmzCRpiiDkB(_actionId))
			{
				return false;
			}
			int num;
			if (fieldActionRange == AxisRange.Full)
			{
				if (_elementType == ControllerElementType.Axis)
				{
					if (axisRange != AxisRange.Full)
					{
						goto IL_002a;
					}
				}
				else if (_elementType == ControllerElementType.Button)
				{
					num = -93837421;
					goto IL_002f;
				}
			}
			else
			{
				if (elementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
				{
					return false;
				}
				if (ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.YvfKaVFkYNkHtYuRlvvGuDrWhaQ(_actionId).type == InputActionType.Axis)
				{
					if (fieldActionRange == AxisRange.Positive)
					{
						num = -93837424;
						goto IL_002f;
					}
					goto IL_00b5;
				}
				if (axisContribution != axisContribution)
				{
					return false;
				}
			}
			goto IL_00d4;
			IL_00ab:
			if (axisContribution != Pole.Positive)
			{
				return false;
			}
			goto IL_00b5;
			IL_005e:
			if (ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.YvfKaVFkYNkHtYuRlvvGuDrWhaQ(_actionId).type == InputActionType.Axis)
			{
				return false;
			}
			goto IL_00d4;
			IL_002f:
			switch (num ^ -93837421)
			{
			case 2:
				break;
			case 1:
				return false;
			case 0:
				goto IL_005e;
			default:
				goto IL_00ab;
			}
			goto IL_002a;
			IL_002a:
			num = -93837422;
			goto IL_002f;
			IL_00d4:
			return true;
			IL_00b5:
			if (fieldActionRange == AxisRange.Negative && axisContribution != Pole.Negative)
			{
				return false;
			}
			goto IL_00d4;
		}

		public bool IsTarget(ControllerElementTarget elementTarget)
		{
			auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = auqagPyfULkTIGtBZGYbYCoEQli.RAogkGGXATfLnoLSmrKCnfyrAHzh(elementTarget);
			bool result = default(bool);
			while (true)
			{
				int num = -1888275946;
				while (true)
				{
					switch (num ^ -1888275945)
					{
					case 0:
						break;
					case 1:
						goto IL_0025;
					default:
						return result;
					}
					break;
					IL_0025:
					result = IsTarget(auqagPyfULkTIGtBZGYbYCoEQli2);
					auqagPyfULkTIGtBZGYbYCoEQli.OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli2);
					num = -1888275947;
				}
			}
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			if (yAkjWJqxMpaNcNJFRMpKjoUYObX != null)
			{
				goto IL_000d;
			}
			goto IL_0055;
			IL_0055:
			int num;
			if (_elementType != elementTarget.elementType)
			{
				num = 1707728656;
			}
			else if (_elementType == ControllerElementType.Axis)
			{
				num = 1707728663;
			}
			else
			{
				if (_elementType != ControllerElementType.Button)
				{
					throw new NotImplementedException();
				}
				num = 1707728659;
			}
			goto IL_0012;
			IL_000d:
			num = 1707728658;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x65C9DF11)
				{
				case 4:
					break;
				case 6:
					goto IL_003e;
				case 0:
					goto IL_0053;
				case 1:
					return false;
				case 3:
					goto IL_007b;
				case 5:
					return _axisRange == elementTarget.axisRange;
				default:
					return _elementIdentifierId == elementTarget.elementIdentifierId;
				}
				break;
				IL_007b:
				Controller controller = elementTarget.controller;
				if (controller == null)
				{
					return false;
				}
				if (controller.id != yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerId)
				{
					goto IL_0053;
				}
				if (controller.type != yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType)
				{
					num = 1707728657;
					continue;
				}
				goto IL_0055;
				IL_0053:
				return false;
				IL_003e:
				if (_elementIdentifierId == elementTarget.elementIdentifierId)
				{
					num = 1707728660;
					continue;
				}
				return false;
			}
			goto IL_000d;
		}

		internal void rlmHPtRaQxhZqxiQpUHlvKLFmAK(ControllerMap P_0)
		{
			yAkjWJqxMpaNcNJFRMpKjoUYObX = P_0;
			ControllerType controllerType = P_0.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = ((P_0.controller != null) ? P_0.controller.kABaypBwJpdJPQfaNrcsDzJUopW : null);
			rlmHPtRaQxhZqxiQpUHlvKLFmAK(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		internal void JzofFaEBuBqtMKafREtZVzuDRBD(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			yAkjWJqxMpaNcNJFRMpKjoUYObX = P_0;
			rlmHPtRaQxhZqxiQpUHlvKLFmAK(P_0.controllerType, P_1, P_0.controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		private void rlmHPtRaQxhZqxiQpUHlvKLFmAK(bool P_0)
		{
			if (yAkjWJqxMpaNcNJFRMpKjoUYObX != null)
			{
				rlmHPtRaQxhZqxiQpUHlvKLFmAK(yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType, (yAkjWJqxMpaNcNJFRMpKjoUYObX.controller != null) ? yAkjWJqxMpaNcNJFRMpKjoUYObX.controller.kABaypBwJpdJPQfaNrcsDzJUopW : null, P_0);
			}
		}

		private void rlmHPtRaQxhZqxiQpUHlvKLFmAK(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
			if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
			{
				return;
			}
			Keyboard keyboard = default(Keyboard);
			string text = default(string);
			while (true)
			{
				if (P_0 != ControllerType.Keyboard)
				{
					goto IL_014e;
				}
				keyboard = ReInput.controllers.Keyboard;
				int num;
				if (P_2)
				{
					ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = keyboard.GetButtonIndex(_keyboardKeyCode);
					SPsZpAVIfyQHmRuTeLlHeSGNAml();
					num = -1510219601;
					goto IL_000e;
				}
				goto IL_01ea;
				IL_01ea:
				ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = keyboard.GetButtonIndexById(_elementIdentifierId);
				ztxuoESNUmaqBMMVdkWbInAKWHa();
				num = -1510219612;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1510219604)
					{
					case 12:
						num = -1510219608;
						continue;
					case 4:
						break;
					case 18:
						goto IL_00b7;
					case 22:
						goto IL_00d3;
					case 16:
						FcZlvtEnXFMiEicBtcTcDitrjYGb = P_1.GetElementIdentifierName(_elementIdentifierId);
						num = -1510219585;
						continue;
					case 15:
						num = -1510219585;
						continue;
					case 11:
						text = string.Format("{0} + {1}", Consts.modifierKeyShortNames[(int)_modifierKey3], text);
						num = -1510219591;
						continue;
					case 7:
						goto IL_014e;
					case 6:
						num = -1510219585;
						continue;
					case 10:
						FcZlvtEnXFMiEicBtcTcDitrjYGb = text;
						num = -1510219613;
						continue;
					case 0:
						FcZlvtEnXFMiEicBtcTcDitrjYGb = P_1.GetElementIdentifierNegativeName(_elementIdentifierId);
						num = -1510219607;
						continue;
					case 3:
						num = -1510219612;
						continue;
					case 17:
						if (_modifierKey1 != ModifierKey.None)
						{
							text = string.Format("{0} + {1}", Consts.modifierKeyShortNames[(int)_modifierKey1], text);
							num = -1510219610;
							continue;
						}
						goto case 10;
					case 20:
						FcZlvtEnXFMiEicBtcTcDitrjYGb = P_1.GetElementIdentifierName(_elementIdentifierId);
						num = -1510219606;
						continue;
					case 14:
						goto IL_01ea;
					case 13:
						if (_axisRange != AxisRange.Positive)
						{
							goto case 0;
						}
						FcZlvtEnXFMiEicBtcTcDitrjYGb = P_1.GetElementIdentifierPositiveName(_elementIdentifierId);
						if (string.IsNullOrEmpty(elementIdentifierName))
						{
							FcZlvtEnXFMiEicBtcTcDitrjYGb = P_1.GetElementIdentifierName(_elementIdentifierId) + " +";
							num = -1510219585;
							continue;
						}
						goto default;
					case 1:
						throw new NotImplementedException();
					case 21:
						if (_modifierKey2 != ModifierKey.None)
						{
							text = string.Format("{0} + {1}", Consts.modifierKeyShortNames[(int)_modifierKey2], text);
							num = -1510219587;
							continue;
						}
						goto case 17;
					case 9:
						goto IL_02a1;
					case 8:
						text = Keyboard.GetKeyName((KeyCode)_keyboardKeyCode);
						num = -1510219586;
						continue;
					case 5:
						goto IL_02d6;
					case 2:
						FcZlvtEnXFMiEicBtcTcDitrjYGb = P_1.GetElementIdentifierName(_elementIdentifierId) + " -";
						num = -1510219585;
						continue;
					case 23:
						goto IL_031d;
					default:
						OvrPUMRcXKoUwMYTjEoLkNBMHkz();
						return;
					}
					break;
					IL_02d6:
					int num2;
					if (string.IsNullOrEmpty(elementIdentifierName))
					{
						num = -1510219602;
						num2 = num;
					}
					else
					{
						num = -1510219585;
						num2 = num;
					}
					continue;
					IL_00b7:
					int num3;
					if (_modifierKey3 != ModifierKey.None)
					{
						num = -1510219609;
						num3 = num;
					}
					else
					{
						num = -1510219591;
						num3 = num;
					}
				}
				continue;
				IL_014e:
				if (P_1 == null)
				{
					break;
				}
				goto IL_02a1;
				IL_02a1:
				switch (_elementType)
				{
				case ControllerElementType.Axis:
					break;
				default:
					goto IL_02b6;
				case ControllerElementType.Button:
					goto IL_031d;
				}
				goto IL_00d3;
				IL_02b6:
				num = -1510219603;
				goto IL_000e;
				IL_00d3:
				ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = P_1.GetAxisIndex(_elementIdentifierId);
				int num4;
				if (axisType == AxisType.Split)
				{
					num = -1510219615;
					num4 = num;
				}
				else
				{
					num = -1510219588;
					num4 = num;
				}
				goto IL_000e;
				IL_031d:
				ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = P_1.GetButtonIndex(_elementIdentifierId);
				num = -1510219592;
				goto IL_000e;
			}
		}

		private void OvrPUMRcXKoUwMYTjEoLkNBMHkz()
		{
			InputAction inputAction = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.YvfKaVFkYNkHtYuRlvvGuDrWhaQ(_actionId);
			while (true)
			{
				int num = 1568595686;
				while (true)
				{
					switch (num ^ 0x5D7EDEE7)
					{
					case 5:
						break;
					case 0:
						if (_axisContribution == Pole.Negative)
						{
							YloFuagLjOEDSYNjORAVEzRtYpV = inputAction.negativeDescriptiveName;
							num = 1568595695;
							continue;
						}
						goto case 4;
					case 16:
						YloFuagLjOEDSYNjORAVEzRtYpV = inputAction.descriptiveName;
						return;
					case 13:
						if (_elementType != ControllerElementType.Axis)
						{
							int num4;
							if (_elementType == ControllerElementType.Button)
							{
								num = 1568595688;
								num4 = num;
							}
							else
							{
								num = 1568595685;
								num4 = num;
							}
							continue;
						}
						goto case 15;
					case 9:
						YloFuagLjOEDSYNjORAVEzRtYpV = inputAction.negativeDescriptiveName;
						return;
					case 6:
					{
						int num7;
						if (_elementType == ControllerElementType.Axis)
						{
							num = 1568595700;
							num7 = num;
						}
						else
						{
							num = 1568595702;
							num7 = num;
						}
						continue;
					}
					case 18:
						return;
					case 17:
					{
						int num5;
						if (_elementType != ControllerElementType.Button)
						{
							num = 1568595680;
							num5 = num;
						}
						else
						{
							num = 1568595700;
							num5 = num;
						}
						continue;
					}
					case 4:
						throw new NotImplementedException();
					case 19:
					{
						int num2;
						if (_axisContribution != Pole.Negative)
						{
							num = 1568595703;
							num2 = num;
						}
						else
						{
							num = 1568595694;
							num2 = num;
						}
						continue;
					}
					case 2:
						throw new NotImplementedException();
					case 10:
						if (_axisRange == AxisRange.Full)
						{
							YloFuagLjOEDSYNjORAVEzRtYpV = inputAction.descriptiveName;
							return;
						}
						goto case 13;
					case 12:
						if (inputAction.type == InputActionType.Button)
						{
							if (_elementType == ControllerElementType.Axis)
							{
								int num6;
								if (_axisRange == AxisRange.Full)
								{
									num = 1568595692;
									num6 = num;
								}
								else
								{
									num = 1568595681;
									num6 = num;
								}
								continue;
							}
							goto case 6;
						}
						goto default;
					case 3:
						if (inputAction.type == InputActionType.Axis)
						{
							int num3;
							if (_elementType != ControllerElementType.Axis)
							{
								num = 1568595690;
								num3 = num;
							}
							else
							{
								num = 1568595693;
								num3 = num;
							}
							continue;
						}
						goto case 12;
					case 1:
						if (inputAction == null)
						{
							YloFuagLjOEDSYNjORAVEzRtYpV = string.Empty;
							num = 1568595701;
							continue;
						}
						goto case 3;
					case 8:
						return;
					case 15:
						if (_axisContribution == Pole.Positive)
						{
							YloFuagLjOEDSYNjORAVEzRtYpV = inputAction.positiveDescriptiveName;
							return;
						}
						goto case 0;
					case 7:
						throw new NotImplementedException();
					case 11:
						YloFuagLjOEDSYNjORAVEzRtYpV = inputAction.descriptiveName;
						return;
					default:
						throw new NotImplementedException();
					}
					break;
				}
			}
		}

		internal void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
		{
			_actionCategoryId = -1;
			_actionId = -1;
			_elementType = ControllerElementType.Axis;
			_elementIdentifierId = -1;
			while (true)
			{
				int num = 1568379517;
				while (true)
				{
					switch (num ^ 0x5D7B927F)
					{
					case 0:
						break;
					case 4:
						_modifierKey1 = ModifierKey.None;
						_modifierKey2 = ModifierKey.None;
						num = 1568379518;
						continue;
					case 3:
						_invert = false;
						_axisContribution = Pole.Positive;
						_keyboardKeyCode = KeyboardKeyCode.None;
						num = 1568379515;
						continue;
					case 2:
						_axisRange = AxisRange.Full;
						num = 1568379516;
						continue;
					default:
						_modifierKey3 = ModifierKey.None;
						yAkjWJqxMpaNcNJFRMpKjoUYObX = null;
						gmbIkkevNmPVGSTIwKcAwoPYANrc = true;
						FcZlvtEnXFMiEicBtcTcDitrjYGb = string.Empty;
						ZwgAVZCxcUqkUVeFEgwfcqhdLwxy = -1;
						return;
					}
					break;
				}
			}
		}

		private bool bdoGqKcXYHAowjPlfnWfQEHrNycJ(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (_elementType != ControllerElementType.Button)
			{
				return false;
			}
			if (P_0 == KeyboardKeyCode.None)
			{
				return false;
			}
			if (_keyboardKeyCode != P_0)
			{
				return false;
			}
			if (Keyboard.ConvertModifierKeyFlagsSingleToDouble(modifierKeyFlags) != Keyboard.ConvertModifierKeyFlagsSingleToDouble(P_1))
			{
				return false;
			}
			return true;
		}

		private bool HEJfEHICEbmATnhFUglvALxrTwxM(int P_0, AxisRange P_1)
		{
			if (_elementIdentifierId != P_0)
			{
				return false;
			}
			if (_elementType == ControllerElementType.Button)
			{
				return true;
			}
			if (_elementType == ControllerElementType.Axis)
			{
				while (true)
				{
					int num = -2029273378;
					while (true)
					{
						switch (num ^ -2029273382)
						{
						case 3:
							break;
						case 4:
							if (_axisRange == AxisRange.Full)
							{
								goto case 0;
							}
							if (P_1 == AxisRange.Full)
							{
								num = -2029273382;
								continue;
							}
							if (_axisRange == AxisRange.Positive)
							{
								num = -2029273384;
								continue;
							}
							goto IL_0072;
						case 0:
							return true;
						case 2:
							if (P_1 == AxisRange.Positive)
							{
								return true;
							}
							goto IL_0072;
						case 1:
							if (P_1 == AxisRange.Negative)
							{
								num = -2029273377;
								continue;
							}
							goto IL_008f;
						default:
							{
								return true;
							}
							IL_0072:
							if (_axisRange == AxisRange.Negative)
							{
								num = -2029273381;
								continue;
							}
							goto IL_008f;
							IL_008f:
							return false;
						}
						break;
					}
				}
			}
			throw new NotImplementedException();
		}

		private bool TiHoOcTHeBvhpgraTMTxHmDEqau(ElementAssignmentType P_0)
		{
			if (_elementType == ControllerElementType.Button)
			{
				if (P_0 == ElementAssignmentType.Button)
				{
					goto IL_0033;
				}
				if (P_0 == ElementAssignmentType.KeyboardKey)
				{
					goto IL_0011;
				}
				goto IL_0064;
			}
			int num;
			if (_elementType == ControllerElementType.Axis)
			{
				if (P_0 != ElementAssignmentType.FullAxis)
				{
					int num2;
					if (P_0 == ElementAssignmentType.SplitAxis)
					{
						num = 1612981775;
						num2 = num;
					}
					else
					{
						num = 1612981772;
						num2 = num;
					}
					goto IL_0016;
				}
				goto IL_0055;
			}
			throw new NotImplementedException();
			IL_0033:
			return true;
			IL_0016:
			switch (num ^ 0x6024260F)
			{
			case 2:
				break;
			case 1:
				goto IL_0033;
			case 0:
				goto IL_0055;
			default:
				goto IL_0064;
			}
			goto IL_0011;
			IL_0011:
			num = 1612981774;
			goto IL_0016;
			IL_0055:
			return true;
			IL_0064:
			return false;
		}

		private void SPsZpAVIfyQHmRuTeLlHeSGNAml()
		{
			_elementIdentifierId = Keyboard.GetElementIdentifierIdByKeyCode(_keyboardKeyCode);
		}

		private void ztxuoESNUmaqBMMVdkWbInAKWHa()
		{
			if (_elementIdentifierId < 0)
			{
				while (true)
				{
					int num = 1026144741;
					while (true)
					{
						switch (num ^ 0x3D29B9E4)
						{
						case 3:
							break;
						case 1:
							_keyboardKeyCode = KeyboardKeyCode.None;
							num = 1026144740;
							continue;
						case 2:
							goto end_IL_0009;
						case 0:
							return;
						default:
							goto IL_0054;
						}
						break;
					}
					continue;
					end_IL_0009:
					break;
				}
			}
			if (!ReInput.isReady)
			{
				return;
			}
			goto IL_0054;
			IL_0054:
			_keyboardKeyCode = Keyboard.KeyCodeToKeyboardKeyCode(ReInput.TjEnOXyhIcFYKPeZiqgPVRhKsqQ.Keyboard.GetKeyCodeById(_elementIdentifierId));
		}

		private void KjvZXJhpsdUBZKRhlotuDjUkonN()
		{
			if (_modifierKey1 == ModifierKey.None)
			{
				goto IL_004f;
			}
			if (_modifierKey1 == _modifierKey2)
			{
				goto IL_0016;
			}
			goto IL_0079;
			IL_004f:
			int num;
			if (_modifierKey2 != ModifierKey.None && _modifierKey2 == _modifierKey3)
			{
				_modifierKey3 = ModifierKey.None;
				num = -510212903;
				goto IL_001b;
			}
			goto IL_010c;
			IL_0016:
			num = -510212912;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -510212911)
				{
				case 4:
					break;
				default:
					return;
				case 5:
					goto IL_004f;
				case 6:
					goto IL_0079;
				case 7:
					goto IL_0095;
				case 0:
					_modifierKey2 = _modifierKey3;
					_modifierKey3 = ModifierKey.None;
					num = -510212909;
					continue;
				case 2:
					if (_modifierKey2 != ModifierKey.None && _modifierKey1 == ModifierKey.None)
					{
						_modifierKey1 = _modifierKey2;
						_modifierKey2 = ModifierKey.None;
						num = -510212910;
						continue;
					}
					return;
				case 1:
					_modifierKey2 = ModifierKey.None;
					num = -510212905;
					continue;
				case 8:
					goto IL_010c;
				case 3:
					return;
				}
				break;
				IL_0095:
				int num2;
				if (_modifierKey2 != ModifierKey.None)
				{
					num = -510212909;
					num2 = num;
				}
				else
				{
					num = -510212911;
					num2 = num;
				}
			}
			goto IL_0016;
			IL_010c:
			int num3;
			if (_modifierKey3 == ModifierKey.None)
			{
				num = -510212909;
				num3 = num;
			}
			else
			{
				num = -510212906;
				num3 = num;
			}
			goto IL_001b;
			IL_0079:
			if (_modifierKey1 == _modifierKey3)
			{
				_modifierKey3 = ModifierKey.None;
				num = -510212908;
				goto IL_001b;
			}
			goto IL_004f;
		}

		internal SerializedObject LxAJUQVkKiSNqkaHsfsZAlQLTqTK()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			while (true)
			{
				int num = -493108943;
				while (true)
				{
					switch (num ^ -493108940)
					{
					case 6:
						break;
					case 0:
						serializedObject.Add("modifierKey3", _modifierKey3);
						num = -493108941;
						continue;
					case 3:
						serializedObject.Add("elementType", _elementType);
						serializedObject.Add("elementIdentifierId", _elementIdentifierId);
						serializedObject.Add("axisRange", _axisRange);
						num = -493108944;
						continue;
					case 5:
						serializedObject.Add("actionCategoryId", _actionCategoryId);
						serializedObject.Add("actionId", _actionId);
						num = -493108937;
						continue;
					case 4:
						serializedObject.Add("invert", _invert);
						serializedObject.Add("axisContribution", _axisContribution);
						num = -493108939;
						continue;
					case 1:
						serializedObject.Add("keyboardKeyCode", _keyboardKeyCode);
						num = -493108938;
						continue;
					case 2:
						serializedObject.Add("modifierKey1", _modifierKey1);
						serializedObject.Add("modifierKey2", _modifierKey2);
						num = -493108940;
						continue;
					default:
						serializedObject.Add("enabled", gmbIkkevNmPVGSTIwKcAwoPYANrc);
						return serializedObject;
					}
					break;
				}
			}
		}

		internal void kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject P_0)
		{
			_actionCategoryId = -1;
			_actionId = -1;
			_elementIdentifierId = -1;
			_axisRange = AxisRange.Full;
			while (true)
			{
				int num = 429461036;
				while (true)
				{
					switch (num ^ 0x19990E28)
					{
					case 3:
						break;
					default:
						return;
					case 5:
						P_0.TryGetDeserializedValueByRef("modifierKey1", ref _modifierKey1);
						P_0.TryGetDeserializedValueByRef("modifierKey2", ref _modifierKey2);
						P_0.TryGetDeserializedValueByRef("modifierKey3", ref _modifierKey3);
						P_0.TryGetDeserializedValueByRef("enabled", ref gmbIkkevNmPVGSTIwKcAwoPYANrc);
						num = 429461024;
						continue;
					case 6:
						P_0.TryGetDeserializedValueByRef("elementType", ref _elementType);
						num = 429461039;
						continue;
					case 2:
						_modifierKey2 = ModifierKey.None;
						_modifierKey3 = ModifierKey.None;
						gmbIkkevNmPVGSTIwKcAwoPYANrc = true;
						P_0.TryGetDeserializedValueByRef("actionCategoryId", ref _actionCategoryId);
						num = 429461032;
						continue;
					case 0:
						P_0.TryGetDeserializedValueByRef("actionId", ref _actionId);
						num = 429461038;
						continue;
					case 4:
						_invert = false;
						_axisContribution = Pole.Positive;
						_keyboardKeyCode = KeyboardKeyCode.None;
						_modifierKey1 = ModifierKey.None;
						num = 429461034;
						continue;
					case 1:
						P_0.TryGetDeserializedValueByRef("axisContribution", ref _axisContribution);
						P_0.TryGetDeserializedValueByRef("keyboardKeyCode", ref _keyboardKeyCode);
						num = 429461037;
						continue;
					case 7:
						P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref _elementIdentifierId);
						P_0.TryGetDeserializedValueByRef("axisRange", ref _axisRange);
						P_0.TryGetDeserializedValueByRef("invert", ref _invert);
						num = 429461033;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		public override string ToString()
		{
			if (s_toStringSB == null)
			{
				s_toStringSB = new StringBuilder();
				goto IL_0014;
			}
			goto IL_011c;
			IL_011c:
			StringTools.WriteVar(s_toStringSB, "Id", KAixZgRycuVSHIYaEVNGzKGIdgV);
			int num = -1656015008;
			goto IL_0019;
			IL_0014:
			num = -1656014994;
			goto IL_0019;
			IL_0019:
			while (true)
			{
				switch (num ^ -1656015000)
				{
				case 5:
					break;
				case 4:
					StringTools.WriteVar(s_toStringSB, "Action Id", _actionId);
					StringTools.WriteVar(s_toStringSB, "Action Descriptive Name", YloFuagLjOEDSYNjORAVEzRtYpV);
					StringTools.WriteVar(s_toStringSB, "Element Type", _elementType);
					num = -1656015000;
					continue;
				case 8:
					StringTools.WriteVar(s_toStringSB, "Enabled", gmbIkkevNmPVGSTIwKcAwoPYANrc);
					num = -1656014997;
					continue;
				case 0:
					StringTools.WriteVar(s_toStringSB, "Element Identifier Id", _elementIdentifierId);
					num = -1656014998;
					continue;
				case 3:
					StringTools.WriteVar(s_toStringSB, "Controller Map Id", (yAkjWJqxMpaNcNJFRMpKjoUYObX != null) ? yAkjWJqxMpaNcNJFRMpKjoUYObX.id : (-1));
					num = -1656014996;
					continue;
				case 6:
					goto IL_011c;
				case 2:
					StringTools.WriteVar(s_toStringSB, "Element Identifier Name", FcZlvtEnXFMiEicBtcTcDitrjYGb);
					StringTools.WriteVar(s_toStringSB, "Element Index", ZwgAVZCxcUqkUVeFEgwfcqhdLwxy);
					num = -1656014993;
					continue;
				case 7:
					StringTools.WriteVar(s_toStringSB, "Axis Range", _axisRange);
					StringTools.WriteVar(s_toStringSB, "Invert", _invert);
					num = -1656014999;
					continue;
				default:
				{
					StringTools.WriteVar(s_toStringSB, "Axis Contribution", _axisContribution);
					StringTools.WriteVar(s_toStringSB, "Keyboard Key Code", _keyboardKeyCode);
					StringTools.WriteVar(s_toStringSB, "Has Modifiers", hasModifiers);
					StringTools.WriteVar(s_toStringSB, "Modifier Key 1", _modifierKey1);
					StringTools.WriteVar(s_toStringSB, "modifier Key 2", _modifierKey2);
					StringTools.WriteVar(s_toStringSB, "modifier Key 3", _modifierKey3);
					StringTools.WriteVar(s_toStringSB, "modifier Key Flags", modifierKeyFlags);
					string result = s_toStringSB.ToString();
					s_toStringSB.Length = 0;
					return result;
				}
				}
				break;
			}
			goto IL_0014;
		}
	}
}
