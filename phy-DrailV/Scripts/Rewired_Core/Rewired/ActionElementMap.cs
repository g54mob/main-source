using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Internal.Localization;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal int _actionId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _elementIdentifierId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey1;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey2;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap KQrkQkAkhknsIKIpiSyrmaMcHTQc;

		[NonSerialized]
		internal bool KByWFLCBjjvqwXYVZFDfzPdklyjf = true;

		[NonSerialized]
		internal int nAznauVeWTEKclGKxeRUvILhqOtm;

		[NonSerialized]
		internal readonly int kqvbpTxWGdGtrNRdxLepeZkwTJDn;

		[NonSerialized]
		private uint DYgCGBfVyMsMebuhDGOzSNezihKEb;

		[NonSerialized]
		private string NmLTERFmwfQIstBmLxmJQChhudkA;

		[NonSerialized]
		private string cWGfopGEeXEgBZiYclaJgprsmCsBb;

		[NonSerialized]
		private ModifierKeyFlags TJKAZFagGIGopQbXqSsEnEyyRZhA;

		[NonSerialized]
		private HardwareControllerMap_Game BeBdYQDlXBoAmHUFAWBBddLtqQoo;

		private static int uidCounter;

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
				_elementType = controllerElementType;
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
				if (ReInput.isReady && KQrkQkAkhknsIKIpiSyrmaMcHTQc != null)
				{
					Controller controller = ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType, KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerId, true);
					if (controller != null)
					{
						Controller.Element elementById = controller.GetElementById(value);
						if (elementById != null && elementById.type != _elementType)
						{
							KQrkQkAkhknsIKIpiSyrmaMcHTQc.nJqxGslZOByOFqDlBssAtoptIguB(kqvbpTxWGdGtrNRdxLepeZkwTJDn, elementById.type);
						}
					}
				}
				if (ReInput.isReady)
				{
					XxnQtsdeMuILfHyfAVjirqwliWOgA(false);
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
				if (_elementType != ControllerElementType.Axis && ReInput.isReady)
				{
					Logger.LogWarning("You cannot change AxisRange of a non-Axis mapping.");
					return;
				}
				_axisRange = value;
				if (ReInput.isReady)
				{
					XxnQtsdeMuILfHyfAVjirqwliWOgA(false);
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
					if (ReInput.isReady)
					{
						XxnQtsdeMuILfHyfAVjirqwliWOgA(false);
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
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
					return;
				}
				_keyboardKeyCode = value;
				if (ReInput.isReady)
				{
					XxnQtsdeMuILfHyfAVjirqwliWOgA(true);
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
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey1 = value;
				if (ReInput.isReady)
				{
					aykhrkTwCklPrRmwAYRRKjyMLvJG();
					XxnQtsdeMuILfHyfAVjirqwliWOgA(true);
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
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey2 = value;
				if (ReInput.isReady)
				{
					aykhrkTwCklPrRmwAYRRKjyMLvJG();
					XxnQtsdeMuILfHyfAVjirqwliWOgA(true);
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
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey3 = value;
				if (ReInput.isReady)
				{
					aykhrkTwCklPrRmwAYRRKjyMLvJG();
					XxnQtsdeMuILfHyfAVjirqwliWOgA(true);
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

		public ModifierKeyFlags modifierKeyFlags => ModifierKeyFlags.None | Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey1) | Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey2) | Keyboard.ModifierKeyToModifierKeyFlags(_modifierKey3);

		public KeyCode keyCode
		{
			get
			{
				return Keyboard.hLCSNOjmzRRszVIigLVwNHstOdSE(_keyboardKeyCode);
			}
			set
			{
				keyboardKeyCode = Keyboard.XbboyWJyzBtZEWrUkIElMurDOyys(value);
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

		public ControllerMap controllerMap => KQrkQkAkhknsIKIpiSyrmaMcHTQc;

		public bool enabled
		{
			get
			{
				return KByWFLCBjjvqwXYVZFDfzPdklyjf;
			}
			set
			{
				KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType == ControllerType.Keyboard)
				{
					return zNzzadQOrzxxXrDKdZDvoSDevpMD();
				}
				HardwareControllerMap_Game hardwareControllerMap_Game = ((KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller != null) ? KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller.AWCbIECppuLDtCThiwONsElGeIEub : BeBdYQDlXBoAmHUFAWBBddLtqQoo);
				if (hardwareControllerMap_Game == null)
				{
					return string.Empty;
				}
				switch (_elementType)
				{
				case ControllerElementType.Axis:
					if (axisType == AxisType.Split)
					{
						if (_axisRange == AxisRange.Positive)
						{
							return hardwareControllerMap_Game.GetElementIdentifierPositiveName(_elementIdentifierId);
						}
						return hardwareControllerMap_Game.GetElementIdentifierNegativeName(_elementIdentifierId);
					}
					return hardwareControllerMap_Game.GetElementIdentifierName(_elementIdentifierId);
				case ControllerElementType.Button:
					return hardwareControllerMap_Game.GetElementIdentifierName(_elementIdentifierId);
				default:
					throw new NotImplementedException();
				}
			}
		}

		public string actionDescriptiveName
		{
			get
			{
				InputAction inputAction = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.qKuCVofiSWfeXLQSYWsbtNcyAMGe(_actionId);
				if (inputAction == null)
				{
					return string.Empty;
				}
				if (inputAction.type == InputActionType.Axis)
				{
					if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
					{
						return inputAction.descriptiveName;
					}
					if (_elementType == ControllerElementType.Axis || _elementType == ControllerElementType.Button)
					{
						if (_axisContribution == Pole.Positive)
						{
							return inputAction.positiveDescriptiveName;
						}
						if (_axisContribution == Pole.Negative)
						{
							return inputAction.negativeDescriptiveName;
						}
						throw new NotImplementedException();
					}
					throw new NotImplementedException();
				}
				if (inputAction.type == InputActionType.Button)
				{
					if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
					{
						return inputAction.descriptiveName;
					}
					if (_elementType == ControllerElementType.Axis || _elementType == ControllerElementType.Button)
					{
						if (_axisContribution == Pole.Negative)
						{
							return inputAction.negativeDescriptiveName;
						}
						return inputAction.descriptiveName;
					}
					throw new NotImplementedException();
				}
				throw new NotImplementedException();
			}
		}

		public int elementIndex => nAznauVeWTEKclGKxeRUvILhqOtm;

		public int id => kqvbpTxWGdGtrNRdxLepeZkwTJDn;

		public object elementIdentifierGlyph
		{
			get
			{
				using (TempListPool.TList<object> tList = TempListPool.GetTList<object>())
				{
					int elementIdentifierGlyphs = GetElementIdentifierGlyphs(tList.list);
					if (elementIdentifierGlyphs == 0)
					{
						return null;
					}
					return tList.list[elementIdentifierGlyphs - 1];
				}
			}
		}

		public int elementIdentifierGlyphCount
		{
			get
			{
				using (TempListPool.TList<object> tList = TempListPool.GetTList<object>())
				{
					return GetElementIdentifierGlyphs(tList.list);
				}
			}
		}

		private bool XBjBGvHsrCKtjrfkfFScXQtIhNPFb
		{
			get
			{
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null)
				{
					return KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType == ControllerType.Keyboard;
				}
				return false;
			}
		}

		private static int zDtyNUOEekmtfLkCREvrANjxUWwz
		{
			get
			{
				int result = uidCounter;
				if (uidCounter == int.MaxValue)
				{
					uidCounter = 0;
					return result;
				}
				uidCounter++;
				return result;
			}
		}

		internal static bool iJkboRPqUFYIIceuRqjUryWVRsDe(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (P_0._actionId != -1 && !ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(P_0._actionId))
			{
				return false;
			}
			return true;
		}

		internal static void nzvalbFFwAEZlduJVVoNwHWdJAvEb(ActionElementMap P_0, ActionElementMap P_1)
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
			P_1.KQrkQkAkhknsIKIpiSyrmaMcHTQc = P_0.KQrkQkAkhknsIKIpiSyrmaMcHTQc;
			P_1.nAznauVeWTEKclGKxeRUvILhqOtm = P_0.nAznauVeWTEKclGKxeRUvILhqOtm;
			P_1.KByWFLCBjjvqwXYVZFDfzPdklyjf = P_0.KByWFLCBjjvqwXYVZFDfzPdklyjf;
		}

		public static bool TryGetCombinedElementIdentifierName(IList<ActionElementMap> actionElementMaps, out string result)
		{
			int count;
			if (actionElementMaps == null || (count = actionElementMaps.Count) == 0)
			{
				result = null;
				return false;
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = null;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = actionElementMaps[i];
				if (actionElementMap == null)
				{
					continue;
				}
				HardwareControllerMap_Game hardwareControllerMap_Game2 = ((actionElementMap.KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && actionElementMap.KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller != null) ? actionElementMap.KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller.AWCbIECppuLDtCThiwONsElGeIEub : actionElementMap.BeBdYQDlXBoAmHUFAWBBddLtqQoo);
				if (hardwareControllerMap_Game != null)
				{
					if (hardwareControllerMap_Game2 != hardwareControllerMap_Game)
					{
						result = null;
						return false;
					}
				}
				else
				{
					hardwareControllerMap_Game = hardwareControllerMap_Game2;
				}
			}
			if (hardwareControllerMap_Game == null)
			{
				result = null;
				return false;
			}
			for (int j = 0; j < count; j++)
			{
				ActionElementMap actionElementMap = actionElementMaps[j];
				if (actionElementMap != null && hardwareControllerMap_Game.TryGetCompoundElementMemberCombinedLocalizedName(actionElementMaps, out result))
				{
					return true;
				}
			}
			result = null;
			return false;
		}

		public static bool TryGetCombinedElementIdentifierGlyph(IList<ActionElementMap> actionElementMaps, out object result)
		{
			string text;
			return eMRDhRflVxeYCAemSnfHSZKmmQJnA(actionElementMaps, true, false, out result, out text);
		}

		public static bool TryGetCombinedElementIdentifierFinalGlyphKey(IList<ActionElementMap> actionElementMaps, out string result)
		{
			object obj;
			return eMRDhRflVxeYCAemSnfHSZKmmQJnA(actionElementMaps, false, true, out obj, out result);
		}

		private static bool eMRDhRflVxeYCAemSnfHSZKmmQJnA(IList<ActionElementMap> P_0, bool P_1, bool P_2, out object P_3, out string P_4)
		{
			int count;
			if (P_0 == null || (count = P_0.Count) == 0)
			{
				P_3 = null;
				P_4 = null;
				return false;
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = null;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = P_0[i];
				if (actionElementMap == null)
				{
					continue;
				}
				HardwareControllerMap_Game hardwareControllerMap_Game2 = ((actionElementMap.KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && actionElementMap.KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller != null) ? actionElementMap.KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller.AWCbIECppuLDtCThiwONsElGeIEub : actionElementMap.BeBdYQDlXBoAmHUFAWBBddLtqQoo);
				if (hardwareControllerMap_Game != null)
				{
					if (hardwareControllerMap_Game2 != hardwareControllerMap_Game)
					{
						P_3 = null;
						P_4 = null;
						return false;
					}
				}
				else
				{
					hardwareControllerMap_Game = hardwareControllerMap_Game2;
				}
			}
			if (hardwareControllerMap_Game == null)
			{
				P_3 = null;
				P_4 = null;
				return false;
			}
			for (int j = 0; j < count; j++)
			{
				ActionElementMap actionElementMap = P_0[j];
				if (actionElementMap != null && hardwareControllerMap_Game.TryGetCompoundElementMemberCombinedGlyph(P_0, P_1, P_2, out P_3, out P_4))
				{
					return true;
				}
			}
			P_3 = null;
			P_4 = null;
			return false;
		}

		public ActionElementMap()
		{
			kqvbpTxWGdGtrNRdxLepeZkwTJDn = zDtyNUOEekmtfLkCREvrANjxUWwz;
			_actionId = -1;
			_elementIdentifierId = -1;
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
		}

		public ActionElementMap(ActionElementMap P_0)
			: this()
		{
			nzvalbFFwAEZlduJVVoNwHWdJAvEb(P_0, this);
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, int P_2)
			: this()
		{
			_actionId = P_0;
			_elementType = P_1;
			_elementIdentifierId = P_2;
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, int P_2, Pole P_3, AxisRange P_4)
			: this()
		{
			_actionId = P_0;
			_elementType = P_1;
			_elementIdentifierId = P_2;
			_axisContribution = P_3;
			_axisRange = P_4;
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, int P_2, Pole P_3, AxisRange P_4, bool P_5)
			: this()
		{
			_actionId = P_0;
			_elementType = P_1;
			_elementIdentifierId = P_2;
			_axisContribution = P_3;
			_axisRange = P_4;
			_invert = P_5;
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, Pole P_2, KeyboardKeyCode P_3, ModifierKey P_4, ModifierKey P_5, ModifierKey P_6)
			: this()
		{
			_actionId = P_0;
			_elementType = P_1;
			_axisContribution = P_2;
			_keyboardKeyCode = P_3;
			_modifierKey1 = P_4;
			_modifierKey2 = P_5;
			_modifierKey3 = P_6;
			wajhpfheRvSaMCTIFWqohsgrpazT();
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!xthrElhzhIsVPvnysMpmGhOcWKcY(elementAssignment.type))
			{
				return false;
			}
			if (XBjBGvHsrCKtjrfkfFScXQtIhNPFb || _keyboardKeyCode != KeyboardKeyCode.None)
			{
				KeyCode keyCode = elementAssignment.keyboardKey;
				if (keyCode == KeyCode.None)
				{
					keyCode = ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.ksIrgmIMxbskrWvzAPRFSsoyIedU.GetKeyCodeById(elementAssignment.elementIdentifierId);
				}
				return BQrOWfxaaUKPUCbyGjxUTtdvUNql(Keyboard.XbboyWJyzBtZEWrUkIElMurDOyys(keyCode), elementAssignment.modifierKeyFlags);
			}
			return fUWuAikkeacYnyqUfEzIYOHZSUhF(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
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
			if (XBjBGvHsrCKtjrfkfFScXQtIhNPFb || _keyboardKeyCode != KeyboardKeyCode.None)
			{
				return BQrOWfxaaUKPUCbyGjxUTtdvUNql(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
			}
			return fUWuAikkeacYnyqUfEzIYOHZSUhF(elementMap._elementIdentifierId, elementMap._axisRange);
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.XrqcBMeuSMEFFHtBARTfiYGSMlVMB(_actionId))
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
				else if (_elementType == ControllerElementType.Button && ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.qKuCVofiSWfeXLQSYWsbtNcyAMGe(_actionId).type == InputActionType.Axis)
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
				if (ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.qKuCVofiSWfeXLQSYWsbtNcyAMGe(_actionId).type == InputActionType.Axis)
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
			WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = WortGyCOkKTpqRUAkJvQBKSaUPen.lQlAsdadwIrBBlEHFJjzwWQNAhrm(elementTarget);
			bool result = IsTarget(wortGyCOkKTpqRUAkJvQBKSaUPen);
			WortGyCOkKTpqRUAkJvQBKSaUPen.mChfdSJRxqNkGWGYLQKdLjonbMYVA(wortGyCOkKTpqRUAkJvQBKSaUPen);
			return result;
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null)
			{
				Controller controller = elementTarget.controller;
				if (controller == null)
				{
					return false;
				}
				if (controller.id != KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerId || controller.type != KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType)
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

		public int GetElementIdentifierGlyphs(ICollection<object> results)
		{
			int count = results.Count;
			if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType == ControllerType.Keyboard)
			{
				return LvqRhGoagGburieBVEuAWnmPEuypA(results);
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = ((KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller != null) ? KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller.AWCbIECppuLDtCThiwONsElGeIEub : BeBdYQDlXBoAmHUFAWBBddLtqQoo);
			if (hardwareControllerMap_Game == null)
			{
				return 0;
			}
			ControllerElementIdentifier elementIdentifierById = hardwareControllerMap_Game.GetElementIdentifierById(_elementIdentifierId);
			if (elementIdentifierById == null)
			{
				return 0;
			}
			object obj;
			switch (_elementType)
			{
			case ControllerElementType.Axis:
				obj = ((axisType != AxisType.Split) ? elementIdentifierById.glyph : ((_axisRange != AxisRange.Positive) ? elementIdentifierById.negativeGlyph : elementIdentifierById.positiveGlyph));
				break;
			case ControllerElementType.Button:
				obj = elementIdentifierById.glyph;
				break;
			default:
				throw new NotImplementedException();
			}
			if (obj != null)
			{
				results.Add(obj);
			}
			return results.Count - count;
		}

		public int GetElementIdentifierGlyphs<T>(ICollection<T> results)
		{
			using (TempListPool.TList<object> tList = TempListPool.GetTList<object>())
			{
				List<object> list = tList.list;
				int elementIdentifierGlyphs = GetElementIdentifierGlyphs(list);
				int count = results.Count;
				for (int i = 0; i < elementIdentifierGlyphs; i++)
				{
					if (!(list[i] is T))
					{
						return 0;
					}
				}
				for (int j = 0; j < elementIdentifierGlyphs; j++)
				{
					results.Add((T)list[j]);
				}
				return results.Count - count;
			}
		}

		public int GetElementIdentifierFinalGlyphKeys(ICollection<string> results)
		{
			int count = results.Count;
			if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType == ControllerType.Keyboard)
			{
				return vXRTziRetjjJCYHEHXFBqoblEbwQ(results);
			}
			HardwareControllerMap_Game hardwareControllerMap_Game = ((KQrkQkAkhknsIKIpiSyrmaMcHTQc != null && KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller != null) ? KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller.AWCbIECppuLDtCThiwONsElGeIEub : BeBdYQDlXBoAmHUFAWBBddLtqQoo);
			if (hardwareControllerMap_Game == null)
			{
				return 0;
			}
			ControllerElementIdentifier elementIdentifierById = hardwareControllerMap_Game.GetElementIdentifierById(_elementIdentifierId);
			if (elementIdentifierById == null)
			{
				return 0;
			}
			string text;
			switch (_elementType)
			{
			case ControllerElementType.Axis:
				text = ((axisType != AxisType.Split) ? elementIdentifierById.GetFinalGlyphKey(_elementType, AxisRange.Full) : elementIdentifierById.GetFinalGlyphKey(_elementType, _axisRange));
				break;
			case ControllerElementType.Button:
				text = elementIdentifierById.GetFinalGlyphKey(_elementType, AxisRange.Full);
				break;
			default:
				throw new NotImplementedException();
			}
			if (text != null)
			{
				results.Add(text);
			}
			return results.Count - count;
		}

		internal void XxnQtsdeMuILfHyfAVjirqwliWOgA(ControllerMap P_0)
		{
			KQrkQkAkhknsIKIpiSyrmaMcHTQc = P_0;
			ControllerType controllerType = P_0.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = ((P_0.controller != null) ? P_0.controller.AWCbIECppuLDtCThiwONsElGeIEub : null);
			XxnQtsdeMuILfHyfAVjirqwliWOgA(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		internal void lupzNBkwMYPWmXbwcpveWSWjXxTV(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			KQrkQkAkhknsIKIpiSyrmaMcHTQc = P_0;
			BeBdYQDlXBoAmHUFAWBBddLtqQoo = P_1;
			XxnQtsdeMuILfHyfAVjirqwliWOgA(P_0.controllerType, P_1, P_0.controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		private void XxnQtsdeMuILfHyfAVjirqwliWOgA(bool P_0)
		{
			if (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null)
			{
				XxnQtsdeMuILfHyfAVjirqwliWOgA(KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType, (KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller != null) ? KQrkQkAkhknsIKIpiSyrmaMcHTQc.controller.AWCbIECppuLDtCThiwONsElGeIEub : null, P_0);
			}
		}

		private void XxnQtsdeMuILfHyfAVjirqwliWOgA(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
			if (KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
			{
				return;
			}
			if (P_0 == ControllerType.Keyboard)
			{
				Keyboard keyboard = ReInput.controllers.Keyboard;
				if (P_2)
				{
					nAznauVeWTEKclGKxeRUvILhqOtm = keyboard.GetButtonIndex(_keyboardKeyCode);
					wajhpfheRvSaMCTIFWqohsgrpazT();
				}
				else
				{
					nAznauVeWTEKclGKxeRUvILhqOtm = keyboard.GetButtonIndexById(_elementIdentifierId);
					TekkOnmDxzrAlRlPQUZETKXuGsmW();
				}
			}
			else if (P_1 != null)
			{
				switch (_elementType)
				{
				case ControllerElementType.Axis:
					nAznauVeWTEKclGKxeRUvILhqOtm = P_1.GetAxisIndex(_elementIdentifierId);
					break;
				case ControllerElementType.Button:
					nAznauVeWTEKclGKxeRUvILhqOtm = P_1.GetButtonIndex(_elementIdentifierId);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private string zNzzadQOrzxxXrDKdZDvoSDevpMD()
		{
			string text = Keyboard.GetKeyName((KeyCode)_keyboardKeyCode);
			if (string.Equals(text, NmLTERFmwfQIstBmLxmJQChhudkA, StringComparison.Ordinal) && TJKAZFagGIGopQbXqSsEnEyyRZhA == modifierKeyFlags && (!LocalizationManager.isEnabled || DYgCGBfVyMsMebuhDGOzSNezihKEb == LocalizationManager.version))
			{
				return cWGfopGEeXEgBZiYclaJgprsmCsBb;
			}
			NmLTERFmwfQIstBmLxmJQChhudkA = text;
			TJKAZFagGIGopQbXqSsEnEyyRZhA = modifierKeyFlags;
			if (LocalizationManager.isEnabled)
			{
				DYgCGBfVyMsMebuhDGOzSNezihKEb = LocalizationManager.version;
			}
			if (_modifierKey3 != ModifierKey.None)
			{
				text = $"{Keyboard.GetModifierKeyName(_modifierKey3, getShortName: true)} + {text}";
			}
			if (_modifierKey2 != ModifierKey.None)
			{
				text = $"{Keyboard.GetModifierKeyName(_modifierKey2, getShortName: true)} + {text}";
			}
			if (_modifierKey1 != ModifierKey.None)
			{
				text = $"{Keyboard.GetModifierKeyName(_modifierKey1, getShortName: true)} + {text}";
			}
			cWGfopGEeXEgBZiYclaJgprsmCsBb = text;
			return cWGfopGEeXEgBZiYclaJgprsmCsBb;
		}

		private int LvqRhGoagGburieBVEuAWnmPEuypA(ICollection<object> P_0)
		{
			object glyph = ReInput.controllers.Keyboard.GetElementIdentifierByKeyCode((KeyCode)_keyboardKeyCode).glyph;
			if (glyph == null)
			{
				return 0;
			}
			int count = P_0.Count;
			using (TempListPool.TList<object> tList = TempListPool.GetTList<object>())
			{
				List<object> list = tList.list;
				if (_modifierKey1 != ModifierKey.None)
				{
					object modifierKeyGlyph = Keyboard.GetModifierKeyGlyph(_modifierKey1);
					if (modifierKeyGlyph == null)
					{
						return 0;
					}
					list.Add(modifierKeyGlyph);
				}
				if (_modifierKey2 != ModifierKey.None)
				{
					object modifierKeyGlyph2 = Keyboard.GetModifierKeyGlyph(_modifierKey2);
					if (modifierKeyGlyph2 == null)
					{
						return 0;
					}
					list.Add(modifierKeyGlyph2);
				}
				if (_modifierKey3 != ModifierKey.None)
				{
					object modifierKeyGlyph3 = Keyboard.GetModifierKeyGlyph(_modifierKey3);
					if (modifierKeyGlyph3 == null)
					{
						return 0;
					}
					list.Add(modifierKeyGlyph3);
				}
				for (int i = 0; i < list.Count; i++)
				{
					P_0.Add(list[i]);
				}
			}
			P_0.Add(glyph);
			return P_0.Count - count;
		}

		private int vXRTziRetjjJCYHEHXFBqoblEbwQ(ICollection<string> P_0)
		{
			string finalGlyphKey = ReInput.controllers.Keyboard.GetElementIdentifierByKeyCode((KeyCode)_keyboardKeyCode).GetFinalGlyphKey(AxisRange.Full);
			if (finalGlyphKey == null)
			{
				return 0;
			}
			int count = P_0.Count;
			using (TempListPool.TList<string> tList = TempListPool.GetTList<string>())
			{
				List<string> list = tList.list;
				if (_modifierKey1 != ModifierKey.None)
				{
					string text = Keyboard.jymnBHidUmzuuKypeGgPOWzQNXDb(_modifierKey1);
					if (text == null)
					{
						return 0;
					}
					list.Add(text);
				}
				if (_modifierKey2 != ModifierKey.None)
				{
					string text2 = Keyboard.jymnBHidUmzuuKypeGgPOWzQNXDb(_modifierKey2);
					if (text2 == null)
					{
						return 0;
					}
					list.Add(text2);
				}
				if (_modifierKey3 != ModifierKey.None)
				{
					string text3 = Keyboard.jymnBHidUmzuuKypeGgPOWzQNXDb(_modifierKey3);
					if (text3 == null)
					{
						return 0;
					}
					list.Add(text3);
				}
				for (int i = 0; i < list.Count; i++)
				{
					P_0.Add(list[i]);
				}
			}
			P_0.Add(finalGlyphKey);
			return P_0.Count - count;
		}

		internal void wJjPIIRJfHhEbGedUconecGfiwzgB()
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
			KQrkQkAkhknsIKIpiSyrmaMcHTQc = null;
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
			NmLTERFmwfQIstBmLxmJQChhudkA = null;
			cWGfopGEeXEgBZiYclaJgprsmCsBb = null;
			DYgCGBfVyMsMebuhDGOzSNezihKEb = 0u;
			TJKAZFagGIGopQbXqSsEnEyyRZhA = ModifierKeyFlags.None;
			nAznauVeWTEKclGKxeRUvILhqOtm = -1;
		}

		private bool BQrOWfxaaUKPUCbyGjxUTtdvUNql(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
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
			if (Keyboard.WpiPGdUCevALQlmVADrdROktvftm(modifierKeyFlags) != Keyboard.WpiPGdUCevALQlmVADrdROktvftm(P_1))
			{
				return false;
			}
			return true;
		}

		private bool fUWuAikkeacYnyqUfEzIYOHZSUhF(int P_0, AxisRange P_1)
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

		private bool xthrElhzhIsVPvnysMpmGhOcWKcY(ElementAssignmentType P_0)
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

		private void wajhpfheRvSaMCTIFWqohsgrpazT()
		{
			_elementIdentifierId = Keyboard.SoZRTGcHjCoUcYlszSAEabCCdixn(_keyboardKeyCode);
		}

		private void TekkOnmDxzrAlRlPQUZETKXuGsmW()
		{
			if (_elementIdentifierId < 0)
			{
				_keyboardKeyCode = KeyboardKeyCode.None;
			}
			else if (ReInput.isReady)
			{
				_keyboardKeyCode = Keyboard.XbboyWJyzBtZEWrUkIElMurDOyys(ReInput.vnBcsWOiBrsweGQzTZwXEVWsKEyb.ksIrgmIMxbskrWvzAPRFSsoyIedU.GetKeyCodeById(_elementIdentifierId));
			}
		}

		private void aykhrkTwCklPrRmwAYRRKjyMLvJG()
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

		internal SerializedObject pMFmgpdCytjWAfCkBRuiiiznUeVd()
		{
			return new SerializedObject(GetType(), SerializedObject.ObjectType.Object)
			{
				{ "actionCategoryId", _actionCategoryId },
				{ "actionId", _actionId },
				{ "elementType", _elementType },
				{ "elementIdentifierId", _elementIdentifierId },
				{ "axisRange", _axisRange },
				{ "invert", _invert },
				{ "axisContribution", _axisContribution },
				{ "keyboardKeyCode", _keyboardKeyCode },
				{ "modifierKey1", _modifierKey1 },
				{ "modifierKey2", _modifierKey2 },
				{ "modifierKey3", _modifierKey3 },
				{ "enabled", KByWFLCBjjvqwXYVZFDfzPdklyjf }
			};
		}

		internal void IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
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
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
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
			P_0.TryGetDeserializedValueByRef("enabled", ref KByWFLCBjjvqwXYVZFDfzPdklyjf);
		}

		public override string ToString()
		{
			if (s_toStringSB == null)
			{
				s_toStringSB = new StringBuilder();
			}
			StringTools.WriteVar(s_toStringSB, "Id", kqvbpTxWGdGtrNRdxLepeZkwTJDn);
			StringTools.WriteVar(s_toStringSB, "Enabled", KByWFLCBjjvqwXYVZFDfzPdklyjf);
			StringTools.WriteVar(s_toStringSB, "Controller Map Id", (KQrkQkAkhknsIKIpiSyrmaMcHTQc != null) ? KQrkQkAkhknsIKIpiSyrmaMcHTQc.id : (-1));
			StringTools.WriteVar(s_toStringSB, "Action Id", _actionId);
			StringTools.WriteVar(s_toStringSB, "Action Descriptive Name", actionDescriptiveName);
			StringTools.WriteVar(s_toStringSB, "Element Type", _elementType);
			StringTools.WriteVar(s_toStringSB, "Element Identifier Id", _elementIdentifierId);
			StringTools.WriteVar(s_toStringSB, "Element Index", nAznauVeWTEKclGKxeRUvILhqOtm);
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
