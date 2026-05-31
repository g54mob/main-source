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
		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal AxisRange _axisRange;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap fcPcTXdclCfFXHGkwVhNNBHdQNBk;

		[NonSerialized]
		internal bool fnEBjitvkHhPtXTzRLmBYpIxFbt = true;

		[NonSerialized]
		private string KyibyrTnauIwjdImEoNfIeeKwcG;

		[NonSerialized]
		internal string VLVqGkxrAftEjZOQxFNCaCEUmcB;

		[NonSerialized]
		internal int CRqOTsiLfoazJbodeeofQgavSxg;

		[NonSerialized]
		internal readonly int JYRMuwETpVNRqJXmtBgBFhZdTeP;

		[NonSerialized]
		private string yBdPcPoVJXlzzSDqTAFQhiVYoHg;

		[NonSerialized]
		private ModifierKeyFlags ueljBkFbdyEkdOuNNlxIICjtkZH;

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
				if (value != _actionId)
				{
					_actionId = value;
					if (Application.isPlaying)
					{
						JrKVrMQNqpMqPLqkEiWCIWGlWDt();
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
					return;
				}
				_elementIdentifierId = value;
				if (Application.isPlaying && fcPcTXdclCfFXHGkwVhNNBHdQNBk != null)
				{
					Controller controller = ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType, fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerId, true);
					if (controller != null)
					{
						Controller.Element elementById = controller.GetElementById(value);
						if (elementById != null && elementById.type != _elementType)
						{
							fcPcTXdclCfFXHGkwVhNNBHdQNBk.OxEMVbWTSfUOLcynBPcYYiHuOis(JYRMuwETpVNRqJXmtBgBFhZdTeP, elementById.type);
						}
					}
				}
				if (Application.isPlaying)
				{
					qOVDONBKVKOloJeRYYKGTFZqcKAM(false);
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
				if (_elementType != ControllerElementType.Axis && Application.isPlaying)
				{
					Logger.LogWarning("You cannot change AxisRange of a non-Axis mapping.");
					return;
				}
				_axisRange = value;
				if (Application.isPlaying)
				{
					qOVDONBKVKOloJeRYYKGTFZqcKAM(false);
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
				if (_axisContribution != value)
				{
					_axisContribution = value;
					if (Application.isPlaying)
					{
						qOVDONBKVKOloJeRYYKGTFZqcKAM(false);
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
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null && fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
					return;
				}
				_keyboardKeyCode = value;
				if (Application.isPlaying)
				{
					qOVDONBKVKOloJeRYYKGTFZqcKAM(true);
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
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null && fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey1 = value;
				if (Application.isPlaying)
				{
					TMYlPgNYWNByFGiAxzvnDYTDHm();
					qOVDONBKVKOloJeRYYKGTFZqcKAM(true);
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
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null && fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey2 = value;
				if (Application.isPlaying)
				{
					TMYlPgNYWNByFGiAxzvnDYTDHm();
					qOVDONBKVKOloJeRYYKGTFZqcKAM(true);
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
					return;
				}
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null && fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey3 = value;
				if (Application.isPlaying)
				{
					TMYlPgNYWNByFGiAxzvnDYTDHm();
					qOVDONBKVKOloJeRYYKGTFZqcKAM(true);
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
				return Keyboard.IhmChxYtdttpyTboioqMaXomHIW(_keyboardKeyCode);
			}
			set
			{
				keyboardKeyCode = Keyboard.eTNgJxbiatprFUOeyypTPrSKrwwN(value);
			}
		}

		public bool hasModifiers
		{
			get
			{
				if (_keyboardKeyCode == KeyboardKeyCode.None)
				{
					return false;
				}
				if (_modifierKey1 != ModifierKey.None || _modifierKey2 != ModifierKey.None || _modifierKey3 != ModifierKey.None)
				{
					return true;
				}
				return false;
			}
		}

		public ControllerMap controllerMap => fcPcTXdclCfFXHGkwVhNNBHdQNBk;

		public bool enabled
		{
			get
			{
				return fnEBjitvkHhPtXTzRLmBYpIxFbt;
			}
			set
			{
				fnEBjitvkHhPtXTzRLmBYpIxFbt = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk == null || fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType != ControllerType.Keyboard)
				{
					return KyibyrTnauIwjdImEoNfIeeKwcG;
				}
				return MUFCWQhBFXzFCfWxfAiNNNtzJpU();
			}
		}

		public string actionDescriptiveName => VLVqGkxrAftEjZOQxFNCaCEUmcB;

		public int elementIndex => CRqOTsiLfoazJbodeeofQgavSxg;

		public int id => JYRMuwETpVNRqJXmtBgBFhZdTeP;

		private bool isKeyboardMap
		{
			get
			{
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null)
				{
					return fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType == ControllerType.Keyboard;
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
					uidCounter++;
				}
				return result;
			}
		}

		internal static bool ZRWaEectppfsHBsWRgRqpGFYQNNI(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (P_0._actionId != -1 && !ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.qUMsmxJoDabnMgpnPbuRnplJapZC(P_0._actionId))
			{
				return false;
			}
			return true;
		}

		internal static void IcJONOwlAixNosnMPFzxahNmIVd(ActionElementMap P_0, ActionElementMap P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("destination");
			}
			P_1._actionId = P_0._actionId;
			P_1._actionCategoryId = P_0._actionCategoryId;
			P_1._elementType = P_0._elementType;
			P_1._elementIdentifierId = P_0._elementIdentifierId;
			P_1._axisRange = P_0._axisRange;
			P_1._invert = P_0._invert;
			P_1._axisContribution = P_0._axisContribution;
			P_1._keyboardKeyCode = P_0._keyboardKeyCode;
			P_1._modifierKey1 = P_0._modifierKey1;
			P_1._modifierKey2 = P_0._modifierKey2;
			P_1._modifierKey3 = P_0._modifierKey3;
			P_1.fcPcTXdclCfFXHGkwVhNNBHdQNBk = P_0.fcPcTXdclCfFXHGkwVhNNBHdQNBk;
			P_1.KyibyrTnauIwjdImEoNfIeeKwcG = P_0.KyibyrTnauIwjdImEoNfIeeKwcG;
			P_1.CRqOTsiLfoazJbodeeofQgavSxg = P_0.CRqOTsiLfoazJbodeeofQgavSxg;
			P_1.fnEBjitvkHhPtXTzRLmBYpIxFbt = P_0.fnEBjitvkHhPtXTzRLmBYpIxFbt;
			P_1.VLVqGkxrAftEjZOQxFNCaCEUmcB = P_0.VLVqGkxrAftEjZOQxFNCaCEUmcB;
		}

		public ActionElementMap()
		{
			JYRMuwETpVNRqJXmtBgBFhZdTeP = nextUid;
			_actionId = -1;
			_elementIdentifierId = -1;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
		}

		public ActionElementMap(ActionElementMap map)
			: this()
		{
			IcJONOwlAixNosnMPFzxahNmIVd(map, this);
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
			NQHYUWCTQRrQDSIcJERCIYFyFizO();
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!GzNAxEAKwmRpShrKuzGAgprrHEsX(elementAssignment.type))
			{
				return false;
			}
			if (isKeyboardMap || _keyboardKeyCode != KeyboardKeyCode.None)
			{
				KeyCode keyCode = elementAssignment.keyboardKey;
				if (keyCode == KeyCode.None)
				{
					keyCode = ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.Keyboard.GetKeyCodeById(elementAssignment.elementIdentifierId);
				}
				return iAXxiKQrvuaKNEQPAOIyoYSqENo(Keyboard.eTNgJxbiatprFUOeyypTPrSKrwwN(keyCode), elementAssignment.modifierKeyFlags);
			}
			return ChgTNFVapOKUkmmotebmjreIgSbc(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
		}

		public bool CheckForAssignmentConflict(ActionElementMap elementMap)
		{
			if (elementMap == null || elementMap == this)
			{
				return false;
			}
			if (_elementType != elementMap._elementType)
			{
				return false;
			}
			if (isKeyboardMap || _keyboardKeyCode != KeyboardKeyCode.None)
			{
				return iAXxiKQrvuaKNEQPAOIyoYSqENo(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
			}
			return ChgTNFVapOKUkmmotebmjreIgSbc(elementMap._elementIdentifierId, elementMap._axisRange);
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.qUMsmxJoDabnMgpnPbuRnplJapZC(_actionId))
			{
				return false;
			}
			if (fieldActionRange == AxisRange.Full)
			{
				if (_elementType == ControllerElementType.Axis)
				{
					if (axisRange != AxisRange.Full)
					{
						return false;
					}
				}
				else if (_elementType == ControllerElementType.Button && ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.NXSdxZEXhqvBULQyUjzTUlotAOY(_actionId).type == InputActionType.Axis)
				{
					return false;
				}
			}
			else
			{
				if (elementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
				{
					return false;
				}
				if (ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.NXSdxZEXhqvBULQyUjzTUlotAOY(_actionId).type == InputActionType.Axis)
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
		}

		public bool IsTarget(ControllerElementTarget elementTarget)
		{
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			bool result = IsTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return result;
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null)
			{
				Controller controller = elementTarget.controller;
				if (controller == null)
				{
					return false;
				}
				if (controller.id != fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerId || controller.type != fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType)
				{
					return false;
				}
			}
			if (_elementType != elementTarget.elementType)
			{
				return false;
			}
			if (_elementType == ControllerElementType.Axis)
			{
				if (_elementIdentifierId == elementTarget.elementIdentifierId)
				{
					return _axisRange == elementTarget.axisRange;
				}
				return false;
			}
			if (_elementType == ControllerElementType.Button)
			{
				return _elementIdentifierId == elementTarget.elementIdentifierId;
			}
			throw new NotImplementedException();
		}

		internal void qOVDONBKVKOloJeRYYKGTFZqcKAM(ControllerMap P_0)
		{
			fcPcTXdclCfFXHGkwVhNNBHdQNBk = P_0;
			ControllerType controllerType = P_0.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = ((P_0.controller != null) ? P_0.controller.rEqQznEUmYwtoLNJsErzjlKjjYY : null);
			qOVDONBKVKOloJeRYYKGTFZqcKAM(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		internal void QWHeqeJpXgHwdBRUqASObIjwFdH(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			fcPcTXdclCfFXHGkwVhNNBHdQNBk = P_0;
			qOVDONBKVKOloJeRYYKGTFZqcKAM(P_0.controllerType, P_1, P_0.controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		private void qOVDONBKVKOloJeRYYKGTFZqcKAM(bool P_0)
		{
			if (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null)
			{
				qOVDONBKVKOloJeRYYKGTFZqcKAM(fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType, (fcPcTXdclCfFXHGkwVhNNBHdQNBk.controller != null) ? fcPcTXdclCfFXHGkwVhNNBHdQNBk.controller.rEqQznEUmYwtoLNJsErzjlKjjYY : null, P_0);
			}
		}

		private void qOVDONBKVKOloJeRYYKGTFZqcKAM(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
			if (fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
			{
				return;
			}
			if (P_0 == ControllerType.Keyboard)
			{
				Keyboard keyboard = ReInput.controllers.Keyboard;
				if (P_2)
				{
					CRqOTsiLfoazJbodeeofQgavSxg = keyboard.GetButtonIndex(_keyboardKeyCode);
					NQHYUWCTQRrQDSIcJERCIYFyFizO();
				}
				else
				{
					CRqOTsiLfoazJbodeeofQgavSxg = keyboard.GetButtonIndexById(_elementIdentifierId);
					wvKtvKTYqVUayRwbQHeeqLyvcce();
				}
			}
			else
			{
				if (P_1 == null)
				{
					return;
				}
				switch (_elementType)
				{
				case ControllerElementType.Axis:
					CRqOTsiLfoazJbodeeofQgavSxg = P_1.GetAxisIndex(_elementIdentifierId);
					if (axisType == AxisType.Split)
					{
						if (_axisRange == AxisRange.Positive)
						{
							KyibyrTnauIwjdImEoNfIeeKwcG = P_1.GetElementIdentifierPositiveName(_elementIdentifierId);
							if (string.IsNullOrEmpty(elementIdentifierName))
							{
								KyibyrTnauIwjdImEoNfIeeKwcG = P_1.GetElementIdentifierName(_elementIdentifierId) + " +";
							}
						}
						else
						{
							KyibyrTnauIwjdImEoNfIeeKwcG = P_1.GetElementIdentifierNegativeName(_elementIdentifierId);
							if (string.IsNullOrEmpty(elementIdentifierName))
							{
								KyibyrTnauIwjdImEoNfIeeKwcG = P_1.GetElementIdentifierName(_elementIdentifierId) + " -";
							}
						}
					}
					else
					{
						KyibyrTnauIwjdImEoNfIeeKwcG = P_1.GetElementIdentifierName(_elementIdentifierId);
					}
					break;
				case ControllerElementType.Button:
					CRqOTsiLfoazJbodeeofQgavSxg = P_1.GetButtonIndex(_elementIdentifierId);
					KyibyrTnauIwjdImEoNfIeeKwcG = P_1.GetElementIdentifierName(_elementIdentifierId);
					break;
				default:
					throw new NotImplementedException();
				}
			}
			JrKVrMQNqpMqPLqkEiWCIWGlWDt();
		}

		private void JrKVrMQNqpMqPLqkEiWCIWGlWDt()
		{
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.NXSdxZEXhqvBULQyUjzTUlotAOY(_actionId);
			if (inputAction == null)
			{
				VLVqGkxrAftEjZOQxFNCaCEUmcB = string.Empty;
				return;
			}
			if (inputAction.type == InputActionType.Axis)
			{
				if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
				{
					VLVqGkxrAftEjZOQxFNCaCEUmcB = inputAction.descriptiveName;
					return;
				}
				if (_elementType == ControllerElementType.Axis || _elementType == ControllerElementType.Button)
				{
					if (_axisContribution == Pole.Positive)
					{
						VLVqGkxrAftEjZOQxFNCaCEUmcB = inputAction.positiveDescriptiveName;
						return;
					}
					if (_axisContribution == Pole.Negative)
					{
						VLVqGkxrAftEjZOQxFNCaCEUmcB = inputAction.negativeDescriptiveName;
						return;
					}
					throw new NotImplementedException();
				}
				throw new NotImplementedException();
			}
			if (inputAction.type == InputActionType.Button)
			{
				if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
				{
					VLVqGkxrAftEjZOQxFNCaCEUmcB = inputAction.descriptiveName;
					return;
				}
				if (_elementType == ControllerElementType.Axis || _elementType == ControllerElementType.Button)
				{
					if (_axisContribution == Pole.Negative)
					{
						VLVqGkxrAftEjZOQxFNCaCEUmcB = inputAction.negativeDescriptiveName;
					}
					else
					{
						VLVqGkxrAftEjZOQxFNCaCEUmcB = inputAction.descriptiveName;
					}
					return;
				}
				throw new NotImplementedException();
			}
			throw new NotImplementedException();
		}

		private string MUFCWQhBFXzFCfWxfAiNNNtzJpU()
		{
			string text = Keyboard.GetKeyName((KeyCode)_keyboardKeyCode);
			if (string.Equals(text, yBdPcPoVJXlzzSDqTAFQhiVYoHg, StringComparison.Ordinal) && ueljBkFbdyEkdOuNNlxIICjtkZH == modifierKeyFlags)
			{
				return KyibyrTnauIwjdImEoNfIeeKwcG;
			}
			yBdPcPoVJXlzzSDqTAFQhiVYoHg = text;
			ueljBkFbdyEkdOuNNlxIICjtkZH = modifierKeyFlags;
			if (_modifierKey3 != ModifierKey.None)
			{
				text = $"{Consts.modifierKeyShortNames[(int)_modifierKey3]} + {text}";
			}
			if (_modifierKey2 != ModifierKey.None)
			{
				text = $"{Consts.modifierKeyShortNames[(int)_modifierKey2]} + {text}";
			}
			if (_modifierKey1 != ModifierKey.None)
			{
				text = $"{Consts.modifierKeyShortNames[(int)_modifierKey1]} + {text}";
			}
			KyibyrTnauIwjdImEoNfIeeKwcG = text;
			return text;
		}

		internal void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			_actionCategoryId = -1;
			_actionId = -1;
			_elementType = ControllerElementType.Axis;
			_elementIdentifierId = -1;
			_axisRange = AxisRange.Full;
			_invert = false;
			_axisContribution = Pole.Positive;
			_keyboardKeyCode = KeyboardKeyCode.None;
			_modifierKey1 = ModifierKey.None;
			_modifierKey2 = ModifierKey.None;
			_modifierKey3 = ModifierKey.None;
			fcPcTXdclCfFXHGkwVhNNBHdQNBk = null;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
			KyibyrTnauIwjdImEoNfIeeKwcG = string.Empty;
			yBdPcPoVJXlzzSDqTAFQhiVYoHg = null;
			ueljBkFbdyEkdOuNNlxIICjtkZH = ModifierKeyFlags.None;
			CRqOTsiLfoazJbodeeofQgavSxg = -1;
		}

		private bool iAXxiKQrvuaKNEQPAOIyoYSqENo(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
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
			if (Keyboard.pdWwsAjklZfWFhcbWEXNcFLahil(modifierKeyFlags) != Keyboard.pdWwsAjklZfWFhcbWEXNcFLahil(P_1))
			{
				return false;
			}
			return true;
		}

		private bool ChgTNFVapOKUkmmotebmjreIgSbc(int P_0, AxisRange P_1)
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
				if (_axisRange == AxisRange.Full || P_1 == AxisRange.Full)
				{
					return true;
				}
				if (_axisRange == AxisRange.Positive && P_1 == AxisRange.Positive)
				{
					return true;
				}
				if (_axisRange == AxisRange.Negative && P_1 == AxisRange.Negative)
				{
					return true;
				}
				return false;
			}
			throw new NotImplementedException();
		}

		private bool GzNAxEAKwmRpShrKuzGAgprrHEsX(ElementAssignmentType P_0)
		{
			if (_elementType == ControllerElementType.Button)
			{
				if (P_0 == ElementAssignmentType.Button || P_0 == ElementAssignmentType.KeyboardKey)
				{
					return true;
				}
			}
			else
			{
				if (_elementType != ControllerElementType.Axis)
				{
					throw new NotImplementedException();
				}
				if (P_0 == ElementAssignmentType.FullAxis || P_0 == ElementAssignmentType.SplitAxis)
				{
					return true;
				}
			}
			return false;
		}

		private void NQHYUWCTQRrQDSIcJERCIYFyFizO()
		{
			_elementIdentifierId = Keyboard.rCtikjLooiIEdUQxxlwmHbJJqAx(_keyboardKeyCode);
		}

		private void wvKtvKTYqVUayRwbQHeeqLyvcce()
		{
			if (_elementIdentifierId < 0)
			{
				_keyboardKeyCode = KeyboardKeyCode.None;
			}
			else if (ReInput.isReady)
			{
				_keyboardKeyCode = Keyboard.eTNgJxbiatprFUOeyypTPrSKrwwN(ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.Keyboard.GetKeyCodeById(_elementIdentifierId));
			}
		}

		private void TMYlPgNYWNByFGiAxzvnDYTDHm()
		{
			if (_modifierKey1 != ModifierKey.None)
			{
				if (_modifierKey1 == _modifierKey2)
				{
					_modifierKey2 = ModifierKey.None;
				}
				if (_modifierKey1 == _modifierKey3)
				{
					_modifierKey3 = ModifierKey.None;
				}
			}
			if (_modifierKey2 != ModifierKey.None && _modifierKey2 == _modifierKey3)
			{
				_modifierKey3 = ModifierKey.None;
			}
			if (_modifierKey3 != ModifierKey.None && _modifierKey2 == ModifierKey.None)
			{
				_modifierKey2 = _modifierKey3;
				_modifierKey3 = ModifierKey.None;
			}
			if (_modifierKey2 != ModifierKey.None && _modifierKey1 == ModifierKey.None)
			{
				_modifierKey1 = _modifierKey2;
				_modifierKey2 = ModifierKey.None;
			}
		}

		internal SerializedObject MtzBZMSurJCTTdjsBqkSRhDyHCFi()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("actionCategoryId", _actionCategoryId);
			serializedObject.Add("actionId", _actionId);
			serializedObject.Add("elementType", _elementType);
			serializedObject.Add("elementIdentifierId", _elementIdentifierId);
			serializedObject.Add("axisRange", _axisRange);
			serializedObject.Add("invert", _invert);
			serializedObject.Add("axisContribution", _axisContribution);
			serializedObject.Add("keyboardKeyCode", _keyboardKeyCode);
			serializedObject.Add("modifierKey1", _modifierKey1);
			serializedObject.Add("modifierKey2", _modifierKey2);
			serializedObject.Add("modifierKey3", _modifierKey3);
			serializedObject.Add("enabled", fnEBjitvkHhPtXTzRLmBYpIxFbt);
			return serializedObject;
		}

		internal void tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			_actionCategoryId = -1;
			_actionId = -1;
			_elementIdentifierId = -1;
			_axisRange = AxisRange.Full;
			_invert = false;
			_axisContribution = Pole.Positive;
			_keyboardKeyCode = KeyboardKeyCode.None;
			_modifierKey1 = ModifierKey.None;
			_modifierKey2 = ModifierKey.None;
			_modifierKey3 = ModifierKey.None;
			fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
			P_0.TryGetDeserializedValueByRef("actionCategoryId", ref _actionCategoryId);
			P_0.TryGetDeserializedValueByRef("actionId", ref _actionId);
			P_0.TryGetDeserializedValueByRef("elementType", ref _elementType);
			P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref _elementIdentifierId);
			P_0.TryGetDeserializedValueByRef("axisRange", ref _axisRange);
			P_0.TryGetDeserializedValueByRef("invert", ref _invert);
			P_0.TryGetDeserializedValueByRef("axisContribution", ref _axisContribution);
			P_0.TryGetDeserializedValueByRef("keyboardKeyCode", ref _keyboardKeyCode);
			P_0.TryGetDeserializedValueByRef("modifierKey1", ref _modifierKey1);
			P_0.TryGetDeserializedValueByRef("modifierKey2", ref _modifierKey2);
			P_0.TryGetDeserializedValueByRef("modifierKey3", ref _modifierKey3);
			P_0.TryGetDeserializedValueByRef("enabled", ref fnEBjitvkHhPtXTzRLmBYpIxFbt);
		}

		public override string ToString()
		{
			if (s_toStringSB == null)
			{
				s_toStringSB = new StringBuilder();
			}
			StringTools.WriteVar(s_toStringSB, "Id", JYRMuwETpVNRqJXmtBgBFhZdTeP);
			StringTools.WriteVar(s_toStringSB, "Enabled", fnEBjitvkHhPtXTzRLmBYpIxFbt);
			StringTools.WriteVar(s_toStringSB, "Controller Map Id", (fcPcTXdclCfFXHGkwVhNNBHdQNBk != null) ? fcPcTXdclCfFXHGkwVhNNBHdQNBk.id : (-1));
			StringTools.WriteVar(s_toStringSB, "Action Id", _actionId);
			StringTools.WriteVar(s_toStringSB, "Action Descriptive Name", VLVqGkxrAftEjZOQxFNCaCEUmcB);
			StringTools.WriteVar(s_toStringSB, "Element Type", _elementType);
			StringTools.WriteVar(s_toStringSB, "Element Identifier Id", _elementIdentifierId);
			StringTools.WriteVar(s_toStringSB, "Element Identifier Name", KyibyrTnauIwjdImEoNfIeeKwcG);
			StringTools.WriteVar(s_toStringSB, "Element Index", CRqOTsiLfoazJbodeeofQgavSxg);
			StringTools.WriteVar(s_toStringSB, "Axis Range", _axisRange);
			StringTools.WriteVar(s_toStringSB, "Invert", _invert);
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
}
