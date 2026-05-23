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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _elementIdentifierId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal AxisRange _axisRange;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal bool _invert;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal Pole _axisContribution;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal KeyboardKeyCode _keyboardKeyCode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey1;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey2;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap JdetZGSYAxuUPraClBlCSLMWOmU;

		[NonSerialized]
		internal bool PAfqntGWZaNgzmZFIOyQPuJGOCq = true;

		[NonSerialized]
		internal string ccLqwqerDNLPbYOQRmZkNRvlnZD;

		[NonSerialized]
		internal string jUqISdUetYbnjgLgoIZFzsPzuHC;

		[NonSerialized]
		internal int mMyVYAPDqUrVlKvCuSgnRJfZwdm;

		[NonSerialized]
		internal readonly int rOuBUzbbciWwktcpmiPWpQIKoaAa;

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
					return;
				}
				while (true)
				{
					_actionId = value;
					int num = 1288342586;
					while (true)
					{
						switch (num ^ 0x4CCA8C38)
						{
						case 0:
							num = 1288342588;
							continue;
						default:
							return;
						case 4:
							break;
						case 3:
							vqhKBZdPDCprRoXORisLFpTMfls();
							num = 1288342585;
							continue;
						case 2:
						{
							int num2;
							if (!Application.isPlaying)
							{
								num = 1288342585;
								num2 = num;
							}
							else
							{
								num = 1288342587;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						}
						break;
					}
				}
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
					goto IL_000c;
				}
				goto IL_00df;
				IL_000c:
				int num = 1266409873;
				goto IL_0011;
				IL_0011:
				Controller.Element elementById = default(Controller.Element);
				Controller controller = default(Controller);
				while (true)
				{
					switch (num ^ 0x4B7BE19A)
					{
					case 4:
						break;
					default:
						return;
					case 6:
						goto IL_0051;
					case 9:
						goto IL_0065;
					case 3:
						if (elementById.type != _elementType)
						{
							JdetZGSYAxuUPraClBlCSLMWOmU.gjbIScrKvQatHDCNOLNXFZCFGhv(rOuBUzbbciWwktcpmiPWpQIKoaAa, elementById.type);
							num = 1266409874;
							continue;
						}
						goto IL_010b;
					case 1:
						elementById = controller.GetElementById(value);
						num = 1266409884;
						continue;
					case 0:
						goto IL_00df;
					case 10:
						goto IL_00f0;
					case 8:
						goto IL_010b;
					case 2:
						IKsKsQjqHpGcmPftZSVTCEpXtFB(false);
						num = 1266409885;
						continue;
					case 5:
						goto IL_0137;
					case 11:
						return;
					case 7:
						return;
					}
					break;
					IL_0137:
					int num2;
					if (JdetZGSYAxuUPraClBlCSLMWOmU != null)
					{
						num = 1266409875;
						num2 = num;
					}
					else
					{
						num = 1266409874;
						num2 = num;
					}
					continue;
					IL_0051:
					int num3;
					if (elementById != null)
					{
						num = 1266409881;
						num3 = num;
					}
					else
					{
						num = 1266409874;
						num3 = num;
					}
					continue;
					IL_010b:
					int num4;
					if (Application.isPlaying)
					{
						num = 1266409880;
						num4 = num;
					}
					else
					{
						num = 1266409885;
						num4 = num;
					}
					continue;
					IL_00f0:
					int num5;
					if (!Application.isPlaying)
					{
						num = 1266409874;
						num5 = num;
					}
					else
					{
						num = 1266409887;
						num5 = num;
					}
					continue;
					IL_0065:
					controller = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.lHAHnEiPErByQLPNWMxnJGMpiHF(JdetZGSYAxuUPraClBlCSLMWOmU.controllerType, JdetZGSYAxuUPraClBlCSLMWOmU.controllerId, true);
					int num6;
					if (controller != null)
					{
						num = 1266409883;
						num6 = num;
					}
					else
					{
						num = 1266409874;
						num6 = num;
					}
				}
				goto IL_000c;
				IL_00df:
				_elementIdentifierId = value;
				num = 1266409872;
				goto IL_0011;
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
					if (_elementType != ControllerElementType.Axis)
					{
						num = 571546195;
						num2 = num;
					}
					else
					{
						num = 571546199;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x22111A57)
						{
						case 3:
							num = 571546198;
							continue;
						default:
							return;
						case 5:
							if (Application.isPlaying)
							{
								IKsKsQjqHpGcmPftZSVTCEpXtFB(false);
								num = 571546197;
								continue;
							}
							return;
						case 0:
							_axisRange = value;
							num = 571546194;
							continue;
						case 4:
							if (Application.isPlaying)
							{
								Logger.LogWarning("You cannot change AxisRange of a non-Axis mapping.");
								return;
							}
							goto case 0;
						case 1:
							break;
						case 2:
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
					if (!Application.isPlaying)
					{
						break;
					}
					IKsKsQjqHpGcmPftZSVTCEpXtFB(false);
					int num = -91524866;
					while (true)
					{
						switch (num ^ -91524868)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = -91524867;
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
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (JdetZGSYAxuUPraClBlCSLMWOmU != null)
					{
						num = 1432633663;
						num2 = num;
					}
					else
					{
						num = 1432633656;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x5564413B)
						{
						case 0:
							num = 1432633658;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							_keyboardKeyCode = value;
							if (Application.isPlaying)
							{
								IKsKsQjqHpGcmPftZSVTCEpXtFB(true);
								num = 1432633657;
								continue;
							}
							return;
						case 4:
							if (JdetZGSYAxuUPraClBlCSLMWOmU.controllerType != ControllerType.Keyboard)
							{
								Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
								return;
							}
							goto case 3;
						case 2:
							return;
						}
						break;
					}
				}
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
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (JdetZGSYAxuUPraClBlCSLMWOmU != null)
					{
						num = 86946492;
						num2 = num;
					}
					else
					{
						num = 86946495;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x52EB2BA)
						{
						case 3:
							num = 86946491;
							continue;
						default:
							return;
						case 1:
							break;
						case 5:
						{
							_modifierKey1 = value;
							int num3;
							if (Application.isPlaying)
							{
								num = 86946488;
								num3 = num;
							}
							else
							{
								num = 86946490;
								num3 = num;
							}
							continue;
						}
						case 4:
							IKsKsQjqHpGcmPftZSVTCEpXtFB(true);
							num = 86946490;
							continue;
						case 2:
							pEtUUWJQexUouqAgXMxcmOMiomM();
							num = 86946494;
							continue;
						case 6:
							if (JdetZGSYAxuUPraClBlCSLMWOmU.controllerType != ControllerType.Keyboard)
							{
								Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
								return;
							}
							goto case 5;
						case 0:
							return;
						}
						break;
					}
				}
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
				while (true)
				{
					IL_0064:
					int num;
					if (JdetZGSYAxuUPraClBlCSLMWOmU != null)
					{
						int num2;
						if (JdetZGSYAxuUPraClBlCSLMWOmU.controllerType == ControllerType.Keyboard)
						{
							num = 200409824;
							num2 = num;
						}
						else
						{
							num = 200409827;
							num2 = num;
						}
						goto IL_000f;
					}
					goto IL_0030;
					IL_000f:
					while (true)
					{
						switch (num ^ 0xBF202E3)
						{
						case 2:
							num = 200409831;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
							return;
						case 4:
							goto IL_0064;
						case 1:
							return;
						}
						break;
					}
					goto IL_0030;
					IL_0030:
					_modifierKey2 = value;
					if (Application.isPlaying)
					{
						pEtUUWJQexUouqAgXMxcmOMiomM();
						IKsKsQjqHpGcmPftZSVTCEpXtFB(true);
						num = 200409826;
						goto IL_000f;
					}
					break;
				}
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
					goto IL_0009;
				}
				goto IL_003b;
				IL_0009:
				int num = -1349010827;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1349010828)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					goto IL_003b;
				case 5:
					goto IL_0061;
				case 1:
					return;
				case 0:
					return;
				}
				goto IL_0009;
				IL_003b:
				if (JdetZGSYAxuUPraClBlCSLMWOmU != null && JdetZGSYAxuUPraClBlCSLMWOmU.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					num = -1349010826;
					goto IL_000e;
				}
				goto IL_0061;
				IL_0061:
				_modifierKey3 = value;
				if (Application.isPlaying)
				{
					pEtUUWJQexUouqAgXMxcmOMiomM();
					IKsKsQjqHpGcmPftZSVTCEpXtFB(true);
					num = -1349010828;
					goto IL_000e;
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
				modifierKeyFlags |= Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey2);
				return modifierKeyFlags | Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey3);
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
						num = -15842887;
						num2 = num;
					}
					else
					{
						num = -15842888;
						num2 = num;
					}
					goto IL_000d;
				}
				goto IL_005c;
				IL_000d:
				while (true)
				{
					switch (num ^ -15842887)
					{
					case 2:
						break;
					case 3:
						return false;
					case 0:
						goto IL_004d;
					default:
						goto IL_005c;
					}
					break;
					IL_004d:
					if (_modifierKey3 != ModifierKey.None)
					{
						num = -15842888;
						continue;
					}
					return false;
				}
				goto IL_0008;
				IL_0008:
				num = -15842886;
				goto IL_000d;
				IL_005c:
				return true;
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				return JdetZGSYAxuUPraClBlCSLMWOmU;
			}
		}

		public bool enabled
		{
			get
			{
				return PAfqntGWZaNgzmZFIOyQPuJGOCq;
			}
			set
			{
				PAfqntGWZaNgzmZFIOyQPuJGOCq = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return ccLqwqerDNLPbYOQRmZkNRvlnZD;
			}
		}

		public string actionDescriptiveName
		{
			get
			{
				return jUqISdUetYbnjgLgoIZFzsPzuHC;
			}
		}

		public int elementIndex
		{
			get
			{
				return mMyVYAPDqUrVlKvCuSgnRJfZwdm;
			}
		}

		public int id
		{
			get
			{
				return rOuBUzbbciWwktcpmiPWpQIKoaAa;
			}
		}

		private bool isKeyboardMap
		{
			get
			{
				if (JdetZGSYAxuUPraClBlCSLMWOmU != null)
				{
					return JdetZGSYAxuUPraClBlCSLMWOmU.controllerType == ControllerType.Keyboard;
				}
				return false;
			}
		}

		private static int nextUid
		{
			get
			{
				int result = uidCounter;
				while (true)
				{
					int num = 704281192;
					while (true)
					{
						switch (num ^ 0x29FA7A6A)
						{
						case 0:
							break;
						case 2:
							if (uidCounter == int.MaxValue)
							{
								uidCounter = 0;
								num = 704281195;
								continue;
							}
							goto case 3;
						case 3:
							uidCounter++;
							num = 704281195;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}
		}

		internal static bool lrnrCzJkUCjDHPoqSOHzRASvAkAd(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (P_0._actionId != -1 && !ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.WfhdeimYiTFGUIbHSjqOJaakYWS(P_0._actionId))
			{
				return false;
			}
			return true;
		}

		internal static void qgsdKNFPMNwQyZTFEZFcvtiRJvm(ActionElementMap P_0, ActionElementMap P_1)
		{
			if (P_0 == null)
			{
				goto IL_0006;
			}
			goto IL_015f;
			IL_0006:
			int num = -1029324441;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num ^ -1029324448)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					P_1._modifierKey3 = P_0._modifierKey3;
					P_1.JdetZGSYAxuUPraClBlCSLMWOmU = P_0.JdetZGSYAxuUPraClBlCSLMWOmU;
					P_1.ccLqwqerDNLPbYOQRmZkNRvlnZD = P_0.ccLqwqerDNLPbYOQRmZkNRvlnZD;
					P_1.mMyVYAPDqUrVlKvCuSgnRJfZwdm = P_0.mMyVYAPDqUrVlKvCuSgnRJfZwdm;
					num = -1029324445;
					continue;
				case 9:
					P_1._axisContribution = P_0._axisContribution;
					num = -1029324444;
					continue;
				case 7:
					throw new ArgumentNullException("source");
				case 6:
					P_1._actionCategoryId = P_0._actionCategoryId;
					P_1._elementType = P_0._elementType;
					P_1._elementIdentifierId = P_0._elementIdentifierId;
					P_1._axisRange = P_0._axisRange;
					P_1._invert = P_0._invert;
					num = -1029324439;
					continue;
				case 3:
					P_1.PAfqntGWZaNgzmZFIOyQPuJGOCq = P_0.PAfqntGWZaNgzmZFIOyQPuJGOCq;
					P_1.jUqISdUetYbnjgLgoIZFzsPzuHC = P_0.jUqISdUetYbnjgLgoIZFzsPzuHC;
					num = -1029324438;
					continue;
				case 4:
					P_1._keyboardKeyCode = P_0._keyboardKeyCode;
					num = -1029324447;
					continue;
				case 8:
					goto IL_0127;
				case 1:
					P_1._modifierKey1 = P_0._modifierKey1;
					P_1._modifierKey2 = P_0._modifierKey2;
					num = -1029324446;
					continue;
				case 5:
					goto IL_015f;
				case 10:
					return;
				}
				break;
			}
			goto IL_0006;
			IL_015f:
			if (P_1 == null)
			{
				throw new ArgumentNullException("destination");
			}
			goto IL_0127;
			IL_0127:
			P_1._actionId = P_0._actionId;
			num = -1029324442;
			goto IL_000b;
		}

		public ActionElementMap()
		{
			rOuBUzbbciWwktcpmiPWpQIKoaAa = nextUid;
			_actionId = -1;
			_elementIdentifierId = -1;
			PAfqntGWZaNgzmZFIOyQPuJGOCq = true;
		}

		public ActionElementMap(ActionElementMap map)
			: this()
		{
			qgsdKNFPMNwQyZTFEZFcvtiRJvm(map, this);
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
			while (true)
			{
				int num = -879794717;
				while (true)
				{
					switch (num ^ -879794719)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						_axisContribution = axisContribution;
						_axisRange = axisRange;
						return;
					}
					break;
					IL_0024:
					_actionId = actionId;
					_elementType = elementType;
					_elementIdentifierId = elementIdentifierId;
					num = -879794720;
				}
			}
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
			while (true)
			{
				int num = -134790131;
				while (true)
				{
					switch (num ^ -134790132)
					{
					case 4:
						break;
					case 3:
						_modifierKey1 = modifierKey1;
						_modifierKey2 = modifierKey2;
						_modifierKey3 = modifierKey3;
						num = -134790132;
						continue;
					case 2:
						_elementType = elementType;
						_axisContribution = axisContribution;
						_keyboardKeyCode = keyboardKeyCode;
						num = -134790129;
						continue;
					case 1:
						_actionId = actionId;
						num = -134790130;
						continue;
					default:
						xooIDYnnQgtVptGzEJXHHUhVVdc();
						return;
					}
					break;
				}
			}
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!iGatOJnTiRWMQCgrdKhDscmElMv(elementAssignment.type))
			{
				goto IL_000f;
			}
			int num;
			if (!isKeyboardMap)
			{
				if (_keyboardKeyCode != KeyboardKeyCode.None)
				{
					num = -1655016738;
					goto IL_0014;
				}
				return ogHpLKiGYnmnmTgAiHhxornbzvc(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
			}
			goto IL_006f;
			IL_0014:
			KeyCode keyCode = default(KeyCode);
			while (true)
			{
				switch (num ^ -1655016738)
				{
				case 2:
					break;
				case 4:
					return false;
				case 3:
					if (keyCode == KeyCode.None)
					{
						keyCode = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.Keyboard.GetKeyCodeById(elementAssignment.elementIdentifierId);
						num = -1655016737;
						continue;
					}
					goto default;
				case 0:
					goto IL_006f;
				default:
					return YCgclHbbGNoPDuziLFIrwrZRnhjU(Keyboard.KeyCodeToKeyboardKeyCode(keyCode), elementAssignment.modifierKeyFlags);
				}
				break;
			}
			goto IL_000f;
			IL_000f:
			num = -1655016742;
			goto IL_0014;
			IL_006f:
			keyCode = elementAssignment.keyboardKey;
			num = -1655016739;
			goto IL_0014;
		}

		public bool CheckForAssignmentConflict(ActionElementMap elementMap)
		{
			int num;
			if (elementMap != null)
			{
				if (elementMap == this)
				{
					goto IL_0007;
				}
				if (_elementType != elementMap._elementType)
				{
					return false;
				}
				int num2;
				if (!isKeyboardMap)
				{
					num = -1565595201;
					num2 = num;
				}
				else
				{
					num = -1565595203;
					num2 = num;
				}
				goto IL_000c;
			}
			goto IL_0029;
			IL_0029:
			return false;
			IL_000c:
			while (true)
			{
				switch (num ^ -1565595202)
				{
				case 0:
					break;
				case 2:
					goto IL_0029;
				case 1:
					goto IL_0054;
				default:
					return YCgclHbbGNoPDuziLFIrwrZRnhjU(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
				}
				break;
				IL_0054:
				if (_keyboardKeyCode != KeyboardKeyCode.None)
				{
					num = -1565595203;
					continue;
				}
				return ogHpLKiGYnmnmTgAiHhxornbzvc(elementMap._elementIdentifierId, elementMap._axisRange);
			}
			goto IL_0007;
			IL_0007:
			num = -1565595204;
			goto IL_000c;
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.WfhdeimYiTFGUIbHSjqOJaakYWS(_actionId))
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
				else if (_elementType == ControllerElementType.Button && ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.lklRvOtWMNouCgbGRftSXhlYipRk(_actionId).type == InputActionType.Axis)
				{
					num = -1904997147;
					goto IL_002f;
				}
			}
			else
			{
				if (elementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
				{
					return false;
				}
				if (ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.lklRvOtWMNouCgbGRftSXhlYipRk(_actionId).type == InputActionType.Axis)
				{
					if (fieldActionRange == AxisRange.Positive && axisContribution != Pole.Positive)
					{
						return false;
					}
					if (fieldActionRange == AxisRange.Negative && axisContribution != Pole.Negative)
					{
						return false;
					}
				}
				else if (axisContribution != axisContribution)
				{
					return false;
				}
			}
			return true;
			IL_002a:
			num = -1904997146;
			goto IL_002f;
			IL_002f:
			switch (num ^ -1904997148)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_002a;
		}

		public bool IsTarget(ControllerElementTarget elementTarget)
		{
			RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = RPsfaUSCQTmtficMhKUbbYyMecr.ekwKfFcYONBmEYVTASOMSVczoEq(elementTarget);
			bool result = default(bool);
			while (true)
			{
				int num = -1666466416;
				while (true)
				{
					switch (num ^ -1666466415)
					{
					case 2:
						break;
					case 1:
						result = IsTarget(rPsfaUSCQTmtficMhKUbbYyMecr);
						num = -1666466414;
						continue;
					case 3:
						RPsfaUSCQTmtficMhKUbbYyMecr.fIwAMwHkLhYlTnWMCSbGViIFIbJg(rPsfaUSCQTmtficMhKUbbYyMecr);
						num = -1666466415;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			Controller controller = default(Controller);
			if (JdetZGSYAxuUPraClBlCSLMWOmU != null)
			{
				controller = elementTarget.controller;
				goto IL_0014;
			}
			goto IL_0075;
			IL_0075:
			if (_elementType != elementTarget.elementType)
			{
				return false;
			}
			int num;
			if (_elementType == ControllerElementType.Axis)
			{
				num = -1753555095;
				goto IL_0019;
			}
			if (_elementType == ControllerElementType.Button)
			{
				return _elementIdentifierId == elementTarget.elementIdentifierId;
			}
			throw new NotImplementedException();
			IL_0094:
			if (_elementIdentifierId == elementTarget.elementIdentifierId)
			{
				return _axisRange == elementTarget.axisRange;
			}
			return false;
			IL_0014:
			num = -1753555096;
			goto IL_0019;
			IL_0019:
			while (true)
			{
				switch (num ^ -1753555093)
				{
				case 4:
					break;
				case 3:
					goto IL_003a;
				case 0:
					return false;
				case 1:
					goto IL_0073;
				default:
					goto IL_0094;
				}
				break;
				IL_003a:
				if (controller == null)
				{
					num = -1753555093;
					continue;
				}
				if (controller.id != JdetZGSYAxuUPraClBlCSLMWOmU.controllerId)
				{
					goto IL_0073;
				}
				if (controller.type != JdetZGSYAxuUPraClBlCSLMWOmU.controllerType)
				{
					num = -1753555094;
					continue;
				}
				goto IL_0075;
				IL_0073:
				return false;
			}
			goto IL_0014;
		}

		internal void IKsKsQjqHpGcmPftZSVTCEpXtFB(ControllerMap P_0)
		{
			JdetZGSYAxuUPraClBlCSLMWOmU = P_0;
			ControllerType controllerType = P_0.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = ((P_0.controller != null) ? P_0.controller.RCNejcvnZtMAmgendVbiwgNYmdD : null);
			IKsKsQjqHpGcmPftZSVTCEpXtFB(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		internal void whwkUxeoVTXElgAgnQdNaqmBOcM(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			JdetZGSYAxuUPraClBlCSLMWOmU = P_0;
			IKsKsQjqHpGcmPftZSVTCEpXtFB(P_0.controllerType, P_1, P_0.controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		private void IKsKsQjqHpGcmPftZSVTCEpXtFB(bool P_0)
		{
			if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
			{
				while (true)
				{
					switch (-115951392 ^ -115951390)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			IKsKsQjqHpGcmPftZSVTCEpXtFB(JdetZGSYAxuUPraClBlCSLMWOmU.controllerType, (JdetZGSYAxuUPraClBlCSLMWOmU.controller != null) ? JdetZGSYAxuUPraClBlCSLMWOmU.controller.RCNejcvnZtMAmgendVbiwgNYmdD : null, P_0);
		}

		private void IKsKsQjqHpGcmPftZSVTCEpXtFB(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
			if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
			{
				return;
			}
			Keyboard keyboard = default(Keyboard);
			string arg = default(string);
			while (true)
			{
				IL_025a:
				int num;
				if (P_0 == ControllerType.Keyboard)
				{
					keyboard = ReInput.controllers.Keyboard;
					int num2;
					if (!P_2)
					{
						num = 933712623;
						num2 = num;
					}
					else
					{
						num = 933712633;
						num2 = num;
					}
					goto IL_0011;
				}
				goto IL_0071;
				IL_0011:
				while (true)
				{
					switch (num ^ 0x37A752E9)
					{
					case 4:
						num = 933712634;
						continue;
					case 12:
						break;
					case 1:
						num = 933712622;
						continue;
					case 6:
						mMyVYAPDqUrVlKvCuSgnRJfZwdm = keyboard.GetButtonIndexById(_elementIdentifierId);
						OfdlLMePveHqkaPWXgpevlpOPzm();
						num = 933712609;
						continue;
					case 11:
						mMyVYAPDqUrVlKvCuSgnRJfZwdm = P_1.GetButtonIndex(_elementIdentifierId);
						ccLqwqerDNLPbYOQRmZkNRvlnZD = P_1.GetElementIdentifierName(_elementIdentifierId);
						num = 933712622;
						continue;
					case 14:
						return;
					case 16:
						mMyVYAPDqUrVlKvCuSgnRJfZwdm = keyboard.GetButtonIndex(_keyboardKeyCode);
						xooIDYnnQgtVptGzEJXHHUhVVdc();
						num = 933712611;
						continue;
					case 2:
						ccLqwqerDNLPbYOQRmZkNRvlnZD = P_1.GetElementIdentifierName(_elementIdentifierId);
						num = 933712622;
						continue;
					case 18:
						throw new NotImplementedException();
					case 0:
						ccLqwqerDNLPbYOQRmZkNRvlnZD = P_1.GetElementIdentifierNegativeName(_elementIdentifierId);
						if (string.IsNullOrEmpty(elementIdentifierName))
						{
							ccLqwqerDNLPbYOQRmZkNRvlnZD = P_1.GetElementIdentifierName(_elementIdentifierId) + " -";
							num = 933712616;
							continue;
						}
						goto default;
					case 8:
						arg = Keyboard.GetKeyName((KeyCode)_keyboardKeyCode);
						if (_modifierKey3 != ModifierKey.None)
						{
							arg = string.Format("{0} + {1}", Consts.modifierKeyShortNames[(int)_modifierKey3], arg);
							num = 933712608;
							continue;
						}
						goto case 9;
					case 13:
						goto IL_01ba;
					case 9:
						if (_modifierKey2 != ModifierKey.None)
						{
							arg = string.Format("{0} + {1}", Consts.modifierKeyShortNames[(int)_modifierKey2], arg);
							num = 933712614;
							continue;
						}
						goto case 15;
					case 19:
						goto IL_025a;
					case 15:
						if (_modifierKey1 != ModifierKey.None)
						{
							arg = string.Format("{0} + {1}", Consts.modifierKeyShortNames[(int)_modifierKey1], arg);
							num = 933712618;
							continue;
						}
						goto case 3;
					case 10:
						num = 933712609;
						continue;
					case 5:
						num = 933712622;
						continue;
					case 17:
						switch (_elementType)
						{
						case ControllerElementType.Button:
							break;
						case ControllerElementType.Axis:
							goto IL_01ba;
						default:
							goto IL_02d9;
						}
						goto case 11;
					case 3:
						ccLqwqerDNLPbYOQRmZkNRvlnZD = arg;
						num = 933712620;
						continue;
					default:
						{
							vqhKBZdPDCprRoXORisLFpTMfls();
							return;
						}
						IL_02d9:
						num = 933712635;
						continue;
						IL_01ba:
						mMyVYAPDqUrVlKvCuSgnRJfZwdm = P_1.GetAxisIndex(_elementIdentifierId);
						if (axisType != AxisType.Split)
						{
							goto case 2;
						}
						if (_axisRange != AxisRange.Positive)
						{
							goto case 0;
						}
						ccLqwqerDNLPbYOQRmZkNRvlnZD = P_1.GetElementIdentifierPositiveName(_elementIdentifierId);
						if (string.IsNullOrEmpty(elementIdentifierName))
						{
							ccLqwqerDNLPbYOQRmZkNRvlnZD = P_1.GetElementIdentifierName(_elementIdentifierId) + " +";
							num = 933712622;
							continue;
						}
						goto default;
					}
					break;
				}
				goto IL_0071;
				IL_0071:
				int num3;
				if (P_1 != null)
				{
					num = 933712632;
					num3 = num;
				}
				else
				{
					num = 933712615;
					num3 = num;
				}
				goto IL_0011;
			}
		}

		private void vqhKBZdPDCprRoXORisLFpTMfls()
		{
			InputAction inputAction = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.lklRvOtWMNouCgbGRftSXhlYipRk(_actionId);
			while (true)
			{
				int num = 2100544467;
				while (true)
				{
					switch (num ^ 0x7D33C3D2)
					{
					case 7:
						break;
					case 5:
						throw new NotImplementedException();
					case 6:
					{
						int num4;
						if (_axisContribution != Pole.Positive)
						{
							num = 2100544476;
							num4 = num;
						}
						else
						{
							num = 2100544465;
							num4 = num;
						}
						continue;
					}
					case 15:
						throw new NotImplementedException();
					case 8:
						throw new NotImplementedException();
					case 19:
						if (inputAction.type == InputActionType.Button)
						{
							if (_elementType == ControllerElementType.Axis)
							{
								int num2;
								if (_axisRange == AxisRange.Full)
								{
									num = 2100544448;
									num2 = num;
								}
								else
								{
									num = 2100544473;
									num2 = num;
								}
								continue;
							}
							goto case 11;
						}
						goto default;
					case 0:
						return;
					case 11:
						if (_elementType != ControllerElementType.Axis)
						{
							int num6;
							if (_elementType != ControllerElementType.Button)
							{
								num = 2100544474;
								num6 = num;
							}
							else
							{
								num = 2100544479;
								num6 = num;
							}
							continue;
						}
						goto case 13;
					case 10:
						return;
					case 14:
						if (_axisContribution == Pole.Negative)
						{
							jUqISdUetYbnjgLgoIZFzsPzuHC = inputAction.negativeDescriptiveName;
							num = 2100544450;
							continue;
						}
						goto case 5;
					case 12:
						if (inputAction.type != InputActionType.Axis)
						{
							goto case 19;
						}
						if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
						{
							jUqISdUetYbnjgLgoIZFzsPzuHC = inputAction.descriptiveName;
							return;
						}
						goto case 9;
					case 13:
					{
						int num3;
						if (_axisContribution != Pole.Negative)
						{
							num = 2100544470;
							num3 = num;
						}
						else
						{
							num = 2100544451;
							num3 = num;
						}
						continue;
					}
					case 3:
						jUqISdUetYbnjgLgoIZFzsPzuHC = inputAction.positiveDescriptiveName;
						return;
					case 16:
						return;
					case 18:
						jUqISdUetYbnjgLgoIZFzsPzuHC = inputAction.descriptiveName;
						return;
					case 1:
						if (inputAction == null)
						{
							jUqISdUetYbnjgLgoIZFzsPzuHC = string.Empty;
							num = 2100544466;
							continue;
						}
						goto case 12;
					case 9:
						if (_elementType != ControllerElementType.Axis)
						{
							int num5;
							if (_elementType != ControllerElementType.Button)
							{
								num = 2100544477;
								num5 = num;
							}
							else
							{
								num = 2100544468;
								num5 = num;
							}
							continue;
						}
						goto case 6;
					case 17:
						jUqISdUetYbnjgLgoIZFzsPzuHC = inputAction.negativeDescriptiveName;
						num = 2100544472;
						continue;
					case 4:
						jUqISdUetYbnjgLgoIZFzsPzuHC = inputAction.descriptiveName;
						return;
					default:
						throw new NotImplementedException();
					}
					break;
				}
			}
		}

		internal void nympziBLtYDUiPlWNRoEGqbSPfa()
		{
			_actionCategoryId = -1;
			_actionId = -1;
			while (true)
			{
				int num = -1326926933;
				while (true)
				{
					switch (num ^ -1326926930)
					{
					case 4:
						break;
					case 5:
						_elementType = ControllerElementType.Axis;
						_elementIdentifierId = -1;
						_axisRange = AxisRange.Full;
						num = -1326926932;
						continue;
					case 0:
						_axisContribution = Pole.Positive;
						_keyboardKeyCode = KeyboardKeyCode.None;
						num = -1326926931;
						continue;
					case 1:
						JdetZGSYAxuUPraClBlCSLMWOmU = null;
						num = -1326926936;
						continue;
					case 3:
						_modifierKey1 = ModifierKey.None;
						_modifierKey2 = ModifierKey.None;
						_modifierKey3 = ModifierKey.None;
						num = -1326926929;
						continue;
					case 2:
						_invert = false;
						num = -1326926930;
						continue;
					default:
						PAfqntGWZaNgzmZFIOyQPuJGOCq = true;
						ccLqwqerDNLPbYOQRmZkNRvlnZD = string.Empty;
						mMyVYAPDqUrVlKvCuSgnRJfZwdm = -1;
						return;
					}
					break;
				}
			}
		}

		private bool YCgclHbbGNoPDuziLFIrwrZRnhjU(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
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

		private bool ogHpLKiGYnmnmTgAiHhxornbzvc(int P_0, AxisRange P_1)
		{
			if (_elementIdentifierId != P_0)
			{
				goto IL_0009;
			}
			if (_elementType == ControllerElementType.Button)
			{
				return true;
			}
			int num;
			if (_elementType == ControllerElementType.Axis)
			{
				if (_axisRange != AxisRange.Full)
				{
					if (P_1 != AxisRange.Full)
					{
						if (_axisRange != AxisRange.Positive || P_1 != AxisRange.Positive)
						{
							if (_axisRange != AxisRange.Negative)
							{
								goto IL_008f;
							}
							num = 157554730;
						}
						else
						{
							num = 157554729;
						}
					}
					else
					{
						num = 157554735;
					}
					goto IL_000e;
				}
				goto IL_0045;
			}
			throw new NotImplementedException();
			IL_0045:
			return true;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x964182B)
				{
				case 5:
					break;
				case 2:
					return true;
				case 4:
					goto IL_0045;
				case 3:
					return false;
				case 1:
					goto IL_0082;
				default:
					return true;
				}
				break;
				IL_0082:
				if (P_1 == AxisRange.Negative)
				{
					num = 157554731;
					continue;
				}
				goto IL_008f;
			}
			goto IL_0009;
			IL_008f:
			return false;
			IL_0009:
			num = 157554728;
			goto IL_000e;
		}

		private bool iGatOJnTiRWMQCgrdKhDscmElMv(ElementAssignmentType P_0)
		{
			if (_elementType == ControllerElementType.Button)
			{
				goto IL_0009;
			}
			if (_elementType != ControllerElementType.Axis)
			{
				throw new NotImplementedException();
			}
			int num;
			if (P_0 != ElementAssignmentType.FullAxis)
			{
				int num2;
				if (P_0 != ElementAssignmentType.SplitAxis)
				{
					num = 683005130;
					num2 = num;
				}
				else
				{
					num = 683005134;
					num2 = num;
				}
				goto IL_000e;
			}
			goto IL_0033;
			IL_0009:
			num = 683005135;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x28B5D4CE)
				{
				case 5:
					break;
				case 0:
					goto IL_0033;
				case 2:
					goto IL_0042;
				case 1:
					goto IL_0057;
				case 3:
					return true;
				default:
					return false;
				}
				break;
				IL_0057:
				int num3;
				if (P_0 == ElementAssignmentType.Button)
				{
					num = 683005133;
					num3 = num;
				}
				else
				{
					num = 683005132;
					num3 = num;
				}
				continue;
				IL_0042:
				int num4;
				if (P_0 == ElementAssignmentType.KeyboardKey)
				{
					num = 683005133;
					num4 = num;
				}
				else
				{
					num = 683005130;
					num4 = num;
				}
			}
			goto IL_0009;
			IL_0033:
			return true;
		}

		private void xooIDYnnQgtVptGzEJXHHUhVVdc()
		{
			_elementIdentifierId = Keyboard.GetElementIdentifierIdByKeyCode(_keyboardKeyCode);
		}

		private void OfdlLMePveHqkaPWXgpevlpOPzm()
		{
			if (_elementIdentifierId < 0)
			{
				_keyboardKeyCode = KeyboardKeyCode.None;
				goto IL_0010;
			}
			goto IL_0071;
			IL_0071:
			int num;
			int num2;
			if (!ReInput.isReady)
			{
				num = -891817107;
				num2 = num;
			}
			else
			{
				num = -891817105;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = -891817106;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -891817108)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					_keyboardKeyCode = Keyboard.KeyCodeToKeyboardKeyCode(ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.Keyboard.GetKeyCodeById(_elementIdentifierId));
					num = -891817111;
					continue;
				case 1:
					return;
				case 4:
					goto IL_0071;
				case 5:
					return;
				}
				break;
			}
			goto IL_0010;
		}

		private void pEtUUWJQexUouqAgXMxcmOMiomM()
		{
			if (_modifierKey1 != ModifierKey.None)
			{
				goto IL_0008;
			}
			goto IL_004d;
			IL_0008:
			int num = 859848960;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x33404101)
				{
				case 10:
					break;
				default:
					return;
				case 8:
					goto IL_004d;
				case 7:
					if (_modifierKey2 == _modifierKey3)
					{
						_modifierKey3 = ModifierKey.None;
						num = 859848964;
						continue;
					}
					goto case 5;
				case 0:
					_modifierKey2 = ModifierKey.None;
					num = 859848968;
					continue;
				case 11:
					goto IL_0096;
				case 2:
					_modifierKey3 = ModifierKey.None;
					num = 859848970;
					continue;
				case 1:
					if (_modifierKey1 == _modifierKey2)
					{
						_modifierKey2 = ModifierKey.None;
						num = 859848962;
						continue;
					}
					goto case 3;
				case 3:
					if (_modifierKey1 == _modifierKey3)
					{
						_modifierKey3 = ModifierKey.None;
						num = 859848969;
						continue;
					}
					goto IL_004d;
				case 4:
					goto IL_0104;
				case 5:
					if (_modifierKey3 != ModifierKey.None && _modifierKey2 == ModifierKey.None)
					{
						_modifierKey2 = _modifierKey3;
						num = 859848963;
						continue;
					}
					goto IL_0096;
				case 6:
					_modifierKey1 = _modifierKey2;
					num = 859848961;
					continue;
				case 9:
					return;
				}
				break;
				IL_0104:
				int num2;
				if (_modifierKey1 == ModifierKey.None)
				{
					num = 859848967;
					num2 = num;
				}
				else
				{
					num = 859848968;
					num2 = num;
				}
				continue;
				IL_0096:
				int num3;
				if (_modifierKey2 == ModifierKey.None)
				{
					num = 859848968;
					num3 = num;
				}
				else
				{
					num = 859848965;
					num3 = num;
				}
			}
			goto IL_0008;
			IL_004d:
			int num4;
			if (_modifierKey2 != ModifierKey.None)
			{
				num = 859848966;
				num4 = num;
			}
			else
			{
				num = 859848964;
				num4 = num;
			}
			goto IL_000d;
		}

		internal SerializedObject wGWQXZtIQyRkZMrIKWqTSlWZlQY()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			while (true)
			{
				int num = 1660067745;
				while (true)
				{
					switch (num ^ 0x62F29FA2)
					{
					case 0:
						break;
					case 3:
						serializedObject.Add("actionCategoryId", _actionCategoryId);
						serializedObject.Add("actionId", _actionId);
						serializedObject.Add("elementType", _elementType);
						num = 1660067751;
						continue;
					case 4:
						serializedObject.Add("axisRange", _axisRange);
						serializedObject.Add("invert", _invert);
						serializedObject.Add("axisContribution", _axisContribution);
						serializedObject.Add("keyboardKeyCode", _keyboardKeyCode);
						serializedObject.Add("modifierKey1", _modifierKey1);
						serializedObject.Add("modifierKey2", _modifierKey2);
						num = 1660067747;
						continue;
					case 1:
						serializedObject.Add("modifierKey3", _modifierKey3);
						num = 1660067744;
						continue;
					case 5:
						serializedObject.Add("elementIdentifierId", _elementIdentifierId);
						num = 1660067750;
						continue;
					default:
						serializedObject.Add("enabled", PAfqntGWZaNgzmZFIOyQPuJGOCq);
						return serializedObject;
					}
					break;
				}
			}
		}

		internal void DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject P_0)
		{
			_actionCategoryId = -1;
			_actionId = -1;
			_elementIdentifierId = -1;
			_axisRange = AxisRange.Full;
			while (true)
			{
				int num = 1095469278;
				while (true)
				{
					switch (num ^ 0x414B88D8)
					{
					case 0:
						break;
					case 6:
						_invert = false;
						_axisContribution = Pole.Positive;
						num = 1095469274;
						continue;
					case 3:
						_modifierKey2 = ModifierKey.None;
						_modifierKey3 = ModifierKey.None;
						num = 1095469279;
						continue;
					case 8:
						P_0.TryGetDeserializedValueByRef("actionCategoryId", ref _actionCategoryId);
						num = 1095469265;
						continue;
					case 2:
						_keyboardKeyCode = KeyboardKeyCode.None;
						_modifierKey1 = ModifierKey.None;
						num = 1095469275;
						continue;
					case 1:
						P_0.TryGetDeserializedValueByRef("modifierKey2", ref _modifierKey2);
						num = 1095469276;
						continue;
					case 7:
						PAfqntGWZaNgzmZFIOyQPuJGOCq = true;
						num = 1095469264;
						continue;
					case 9:
						P_0.TryGetDeserializedValueByRef("actionId", ref _actionId);
						P_0.TryGetDeserializedValueByRef("elementType", ref _elementType);
						P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref _elementIdentifierId);
						P_0.TryGetDeserializedValueByRef("axisRange", ref _axisRange);
						P_0.TryGetDeserializedValueByRef("invert", ref _invert);
						P_0.TryGetDeserializedValueByRef("axisContribution", ref _axisContribution);
						P_0.TryGetDeserializedValueByRef("keyboardKeyCode", ref _keyboardKeyCode);
						P_0.TryGetDeserializedValueByRef("modifierKey1", ref _modifierKey1);
						num = 1095469273;
						continue;
					case 4:
						P_0.TryGetDeserializedValueByRef("modifierKey3", ref _modifierKey3);
						num = 1095469277;
						continue;
					default:
						P_0.TryGetDeserializedValueByRef("enabled", ref PAfqntGWZaNgzmZFIOyQPuJGOCq);
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
			goto IL_01d0;
			IL_01d0:
			StringTools.WriteVar(s_toStringSB, "Id", rOuBUzbbciWwktcpmiPWpQIKoaAa);
			int num = -1164213147;
			goto IL_0019;
			IL_0014:
			num = -1164213141;
			goto IL_0019;
			IL_0019:
			string result = default(string);
			while (true)
			{
				switch (num ^ -1164213149)
				{
				case 0:
					break;
				case 2:
					StringTools.WriteVar(s_toStringSB, "Keyboard Key Code", _keyboardKeyCode);
					num = -1164213146;
					continue;
				case 4:
					StringTools.WriteVar(s_toStringSB, "Action Descriptive Name", jUqISdUetYbnjgLgoIZFzsPzuHC);
					StringTools.WriteVar(s_toStringSB, "Element Type", _elementType);
					StringTools.WriteVar(s_toStringSB, "Element Identifier Id", _elementIdentifierId);
					StringTools.WriteVar(s_toStringSB, "Element Identifier Name", ccLqwqerDNLPbYOQRmZkNRvlnZD);
					StringTools.WriteVar(s_toStringSB, "Element Index", mMyVYAPDqUrVlKvCuSgnRJfZwdm);
					StringTools.WriteVar(s_toStringSB, "Axis Range", _axisRange);
					StringTools.WriteVar(s_toStringSB, "Invert", _invert);
					num = -1164213152;
					continue;
				case 7:
					StringTools.WriteVar(s_toStringSB, "modifier Key 3", _modifierKey3);
					StringTools.WriteVar(s_toStringSB, "modifier Key Flags", modifierKeyFlags);
					result = s_toStringSB.ToString();
					s_toStringSB.Length = 0;
					num = -1164213150;
					continue;
				case 5:
					StringTools.WriteVar(s_toStringSB, "Has Modifiers", hasModifiers);
					StringTools.WriteVar(s_toStringSB, "Modifier Key 1", _modifierKey1);
					StringTools.WriteVar(s_toStringSB, "modifier Key 2", _modifierKey2);
					num = -1164213148;
					continue;
				case 8:
					goto IL_01d0;
				case 3:
					StringTools.WriteVar(s_toStringSB, "Axis Contribution", _axisContribution);
					num = -1164213151;
					continue;
				case 6:
					StringTools.WriteVar(s_toStringSB, "Enabled", PAfqntGWZaNgzmZFIOyQPuJGOCq);
					StringTools.WriteVar(s_toStringSB, "Controller Map Id", (JdetZGSYAxuUPraClBlCSLMWOmU != null) ? JdetZGSYAxuUPraClBlCSLMWOmU.id : (-1));
					StringTools.WriteVar(s_toStringSB, "Action Id", _actionId);
					num = -1164213145;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_0014;
		}
	}
}
