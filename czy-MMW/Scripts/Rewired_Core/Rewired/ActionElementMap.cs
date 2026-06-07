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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
		internal ControllerMap SzVdJMEQxohIcvuNjRRIbrgZqmZJA;

		[NonSerialized]
		internal bool dQASdaEFVJzbOgxgKEdsYSDArFzi = true;

		[NonSerialized]
		private string aULpZKHJEpyYvKPMNVMOPHXlhORS;

		[NonSerialized]
		internal string SwwQgKFAcOPLbKoMvcfHBeBKcgqb;

		[NonSerialized]
		internal int rLYEVHHFczfqTKqknfIMkkwHoRbL;

		[NonSerialized]
		internal readonly int oFUAyzlkDBdPoonWGgEIgJYWTzJOA;

		[NonSerialized]
		private string UKJjEznTmDOfZkcDjGEpEaDoiWlH;

		[NonSerialized]
		private ModifierKeyFlags rfqStJjeBhGLDBByPSSyVPAcbGgA;

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
					if (Application.isPlaying)
					{
						UkVcqvktomVIbreBHAdwkjTZNVMGA();
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
				if (Application.isPlaying && SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null)
				{
					Controller controller = ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.DxfjMakBNHsfwQIMeHaXPCHSdWpiA(SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType, SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerId, true);
					if (controller != null)
					{
						Controller.Element elementById = controller.GetElementById(value);
						if (elementById != null && elementById.type != _elementType)
						{
							SzVdJMEQxohIcvuNjRRIbrgZqmZJA.AirUPgEHNKSrqFnVWAYcisLSfUQNA(oFUAyzlkDBdPoonWGgEIgJYWTzJOA, elementById.type);
						}
					}
				}
				if (Application.isPlaying)
				{
					vbgcQaDScfuLcANwGoAAnxARYJcn(false);
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
					vbgcQaDScfuLcANwGoAAnxARYJcn(false);
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
						vbgcQaDScfuLcANwGoAAnxARYJcn(false);
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
				if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null && SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set the key code on a non-Keyboard mapping.");
					return;
				}
				_keyboardKeyCode = value;
				if (Application.isPlaying)
				{
					vbgcQaDScfuLcANwGoAAnxARYJcn(true);
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
				if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null && SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey1 = value;
				if (Application.isPlaying)
				{
					rMtQxOKlBVPGXKZbrILjXElJWDBR();
					vbgcQaDScfuLcANwGoAAnxARYJcn(true);
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
				if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null && SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey2 = value;
				if (Application.isPlaying)
				{
					rMtQxOKlBVPGXKZbrILjXElJWDBR();
					vbgcQaDScfuLcANwGoAAnxARYJcn(true);
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
				if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null && SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType != ControllerType.Keyboard)
				{
					Logger.LogWarning("You cannot set a modifier key on a non-Keyboard mapping.");
					return;
				}
				_modifierKey3 = value;
				if (Application.isPlaying)
				{
					rMtQxOKlBVPGXKZbrILjXElJWDBR();
					vbgcQaDScfuLcANwGoAAnxARYJcn(true);
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
				return Keyboard.OfCNknHjvWuFWXcJUAjpYhJvOYIN(_keyboardKeyCode);
			}
			set
			{
				keyboardKeyCode = Keyboard.GQPyDmRjsYNCPFQsslsUvqcurVKM(value);
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

		public ControllerMap controllerMap => SzVdJMEQxohIcvuNjRRIbrgZqmZJA;

		public bool enabled
		{
			get
			{
				return dQASdaEFVJzbOgxgKEdsYSDArFzi;
			}
			set
			{
				dQASdaEFVJzbOgxgKEdsYSDArFzi = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA == null || SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType != ControllerType.Keyboard)
				{
					return aULpZKHJEpyYvKPMNVMOPHXlhORS;
				}
				return NySvtKDJgcHcnTJWfSHheddkAlwL();
			}
		}

		public string actionDescriptiveName => SwwQgKFAcOPLbKoMvcfHBeBKcgqb;

		public int elementIndex => rLYEVHHFczfqTKqknfIMkkwHoRbL;

		public int id => oFUAyzlkDBdPoonWGgEIgJYWTzJOA;

		private bool tQhjYXWWgKayjKQftMsixvNOZRei
		{
			get
			{
				if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null)
				{
					return SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType == ControllerType.Keyboard;
				}
				return false;
			}
		}

		private static int uQEADhabCgHOanMbbGlPQFKxmMWo
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

		internal static bool cKGcyYGyQDfPHsLIvwcztnLQaKGd(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (P_0._actionId != -1 && !ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.SByHFKqDWWqrMsNsCdjvEQeskxdFb(P_0._actionId))
			{
				return false;
			}
			return true;
		}

		internal static void hvComfYbuVCRlXHAXkdLPGQNAGxM(ActionElementMap P_0, ActionElementMap P_1)
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
			P_1.SzVdJMEQxohIcvuNjRRIbrgZqmZJA = P_0.SzVdJMEQxohIcvuNjRRIbrgZqmZJA;
			P_1.aULpZKHJEpyYvKPMNVMOPHXlhORS = P_0.aULpZKHJEpyYvKPMNVMOPHXlhORS;
			P_1.rLYEVHHFczfqTKqknfIMkkwHoRbL = P_0.rLYEVHHFczfqTKqknfIMkkwHoRbL;
			P_1.dQASdaEFVJzbOgxgKEdsYSDArFzi = P_0.dQASdaEFVJzbOgxgKEdsYSDArFzi;
			P_1.SwwQgKFAcOPLbKoMvcfHBeBKcgqb = P_0.SwwQgKFAcOPLbKoMvcfHBeBKcgqb;
		}

		public ActionElementMap()
		{
			oFUAyzlkDBdPoonWGgEIgJYWTzJOA = uQEADhabCgHOanMbbGlPQFKxmMWo;
			_actionId = -1;
			_elementIdentifierId = -1;
			dQASdaEFVJzbOgxgKEdsYSDArFzi = true;
		}

		public ActionElementMap(ActionElementMap P_0)
			: this()
		{
			hvComfYbuVCRlXHAXkdLPGQNAGxM(P_0, this);
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
			FALYfhkIdRdkiOnEiAqPwolDbrYHA();
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			if (!yuJjBLOXxTfimQfTxYVLvWKCTsiG(elementAssignment.type))
			{
				return false;
			}
			if (tQhjYXWWgKayjKQftMsixvNOZRei || _keyboardKeyCode != KeyboardKeyCode.None)
			{
				KeyCode keyCode = elementAssignment.keyboardKey;
				if (keyCode == KeyCode.None)
				{
					keyCode = ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.IHPfnLMrgyTtYeIwxJsMlnCYMDst.GetKeyCodeById(elementAssignment.elementIdentifierId);
				}
				return MOudzagXGxgywZxUhTckFGnAucmb(Keyboard.GQPyDmRjsYNCPFQsslsUvqcurVKM(keyCode), elementAssignment.modifierKeyFlags);
			}
			return mIVLiOXewpbkFYSnXNOPlLaULstC(elementAssignment.elementIdentifierId, elementAssignment.axisRange);
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
			if (tQhjYXWWgKayjKQftMsixvNOZRei || _keyboardKeyCode != KeyboardKeyCode.None)
			{
				return MOudzagXGxgywZxUhTckFGnAucmb(elementMap._keyboardKeyCode, elementMap.modifierKeyFlags);
			}
			return mIVLiOXewpbkFYSnXNOPlLaULstC(elementMap._elementIdentifierId, elementMap._axisRange);
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			if (!ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.SByHFKqDWWqrMsNsCdjvEQeskxdFb(_actionId))
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
				else if (_elementType == ControllerElementType.Button && ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.cyZjgBDAIIsjivyJJljRrGGufDpj(_actionId).type == InputActionType.Axis)
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
				if (ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.cyZjgBDAIIsjivyJJljRrGGufDpj(_actionId).type == InputActionType.Axis)
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
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			bool result = IsTarget(vpAKgrswCxoCdmGxzoexhctSYmGI);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return result;
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			if (elementTarget == null)
			{
				return false;
			}
			if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null)
			{
				Controller controller = elementTarget.controller;
				if (controller == null)
				{
					return false;
				}
				if (controller.id != SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerId || controller.type != SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType)
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

		internal void PZvEkWRBkXBIEonMjbHYqghRdEUeA(ControllerMap P_0)
		{
			SzVdJMEQxohIcvuNjRRIbrgZqmZJA = P_0;
			ControllerType controllerType = P_0.controllerType;
			HardwareControllerMap_Game hardwareControllerMap_Game = ((P_0.controller != null) ? P_0.controller.XRregwEugLWeubJCKxSQAwUDapNP : null);
			RjpXnZXZgYcAHBbRsclFfqKAuKkz(controllerType, hardwareControllerMap_Game, controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		internal void nyVHOotMlgdJavSeaIKsOuVqTCnE(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
			SzVdJMEQxohIcvuNjRRIbrgZqmZJA = P_0;
			RjpXnZXZgYcAHBbRsclFfqKAuKkz(P_0.controllerType, P_1, P_0.controllerType == ControllerType.Keyboard && _elementIdentifierId <= 0);
		}

		private void vbgcQaDScfuLcANwGoAAnxARYJcn(bool P_0)
		{
			if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null)
			{
				RjpXnZXZgYcAHBbRsclFfqKAuKkz(SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controllerType, (SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controller != null) ? SzVdJMEQxohIcvuNjRRIbrgZqmZJA.controller.XRregwEugLWeubJCKxSQAwUDapNP : null, P_0);
			}
		}

		private void RjpXnZXZgYcAHBbRsclFfqKAuKkz(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
			if (SzVdJMEQxohIcvuNjRRIbrgZqmZJA == null)
			{
				return;
			}
			if (P_0 == ControllerType.Keyboard)
			{
				Keyboard keyboard = ReInput.controllers.Keyboard;
				if (P_2)
				{
					rLYEVHHFczfqTKqknfIMkkwHoRbL = keyboard.GetButtonIndex(_keyboardKeyCode);
					FALYfhkIdRdkiOnEiAqPwolDbrYHA();
				}
				else
				{
					rLYEVHHFczfqTKqknfIMkkwHoRbL = keyboard.GetButtonIndexById(_elementIdentifierId);
					baVmhqlnvYorHqBvmgBVVwzNGlkJ();
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
					rLYEVHHFczfqTKqknfIMkkwHoRbL = P_1.GetAxisIndex(_elementIdentifierId);
					if (axisType == AxisType.Split)
					{
						if (_axisRange == AxisRange.Positive)
						{
							aULpZKHJEpyYvKPMNVMOPHXlhORS = P_1.GetElementIdentifierPositiveName(_elementIdentifierId);
							if (string.IsNullOrEmpty(elementIdentifierName))
							{
								aULpZKHJEpyYvKPMNVMOPHXlhORS = P_1.GetElementIdentifierName(_elementIdentifierId) + " +";
							}
						}
						else
						{
							aULpZKHJEpyYvKPMNVMOPHXlhORS = P_1.GetElementIdentifierNegativeName(_elementIdentifierId);
							if (string.IsNullOrEmpty(elementIdentifierName))
							{
								aULpZKHJEpyYvKPMNVMOPHXlhORS = P_1.GetElementIdentifierName(_elementIdentifierId) + " -";
							}
						}
					}
					else
					{
						aULpZKHJEpyYvKPMNVMOPHXlhORS = P_1.GetElementIdentifierName(_elementIdentifierId);
					}
					break;
				case ControllerElementType.Button:
					rLYEVHHFczfqTKqknfIMkkwHoRbL = P_1.GetButtonIndex(_elementIdentifierId);
					aULpZKHJEpyYvKPMNVMOPHXlhORS = P_1.GetElementIdentifierName(_elementIdentifierId);
					break;
				default:
					throw new NotImplementedException();
				}
			}
			UkVcqvktomVIbreBHAdwkjTZNVMGA();
		}

		private void UkVcqvktomVIbreBHAdwkjTZNVMGA()
		{
			InputAction inputAction = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.cyZjgBDAIIsjivyJJljRrGGufDpj(_actionId);
			if (inputAction == null)
			{
				SwwQgKFAcOPLbKoMvcfHBeBKcgqb = string.Empty;
				return;
			}
			if (inputAction.type == InputActionType.Axis)
			{
				if (_elementType == ControllerElementType.Axis && _axisRange == AxisRange.Full)
				{
					SwwQgKFAcOPLbKoMvcfHBeBKcgqb = inputAction.descriptiveName;
					return;
				}
				if (_elementType == ControllerElementType.Axis || _elementType == ControllerElementType.Button)
				{
					if (_axisContribution == Pole.Positive)
					{
						SwwQgKFAcOPLbKoMvcfHBeBKcgqb = inputAction.positiveDescriptiveName;
						return;
					}
					if (_axisContribution == Pole.Negative)
					{
						SwwQgKFAcOPLbKoMvcfHBeBKcgqb = inputAction.negativeDescriptiveName;
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
					SwwQgKFAcOPLbKoMvcfHBeBKcgqb = inputAction.descriptiveName;
					return;
				}
				if (_elementType == ControllerElementType.Axis || _elementType == ControllerElementType.Button)
				{
					if (_axisContribution == Pole.Negative)
					{
						SwwQgKFAcOPLbKoMvcfHBeBKcgqb = inputAction.negativeDescriptiveName;
					}
					else
					{
						SwwQgKFAcOPLbKoMvcfHBeBKcgqb = inputAction.descriptiveName;
					}
					return;
				}
				throw new NotImplementedException();
			}
			throw new NotImplementedException();
		}

		private string NySvtKDJgcHcnTJWfSHheddkAlwL()
		{
			string text = Keyboard.GetKeyName((KeyCode)_keyboardKeyCode);
			if (string.Equals(text, UKJjEznTmDOfZkcDjGEpEaDoiWlH, StringComparison.Ordinal) && rfqStJjeBhGLDBByPSSyVPAcbGgA == modifierKeyFlags)
			{
				return aULpZKHJEpyYvKPMNVMOPHXlhORS;
			}
			UKJjEznTmDOfZkcDjGEpEaDoiWlH = text;
			rfqStJjeBhGLDBByPSSyVPAcbGgA = modifierKeyFlags;
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
			aULpZKHJEpyYvKPMNVMOPHXlhORS = text;
			return text;
		}

		internal void qiOiajljPpDlMenubKTEdMYtXaRGA()
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
			SzVdJMEQxohIcvuNjRRIbrgZqmZJA = null;
			dQASdaEFVJzbOgxgKEdsYSDArFzi = true;
			aULpZKHJEpyYvKPMNVMOPHXlhORS = string.Empty;
			UKJjEznTmDOfZkcDjGEpEaDoiWlH = null;
			rfqStJjeBhGLDBByPSSyVPAcbGgA = ModifierKeyFlags.None;
			rLYEVHHFczfqTKqknfIMkkwHoRbL = -1;
		}

		private bool MOudzagXGxgywZxUhTckFGnAucmb(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
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
			if (Keyboard.VGcYyBOHCbhFjbBQbXjzLjeUDSEdA(modifierKeyFlags) != Keyboard.VGcYyBOHCbhFjbBQbXjzLjeUDSEdA(P_1))
			{
				return false;
			}
			return true;
		}

		private bool mIVLiOXewpbkFYSnXNOPlLaULstC(int P_0, AxisRange P_1)
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

		private bool yuJjBLOXxTfimQfTxYVLvWKCTsiG(ElementAssignmentType P_0)
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

		private void FALYfhkIdRdkiOnEiAqPwolDbrYHA()
		{
			_elementIdentifierId = Keyboard.HfoWUohxjLpEXszmGVPxhJmNRcfp(_keyboardKeyCode);
		}

		private void baVmhqlnvYorHqBvmgBVVwzNGlkJ()
		{
			if (_elementIdentifierId < 0)
			{
				_keyboardKeyCode = KeyboardKeyCode.None;
			}
			else if (ReInput.isReady)
			{
				_keyboardKeyCode = Keyboard.GQPyDmRjsYNCPFQsslsUvqcurVKM(ReInput.MRYlWddHEDKxegbDTAfXRjoQYitX.IHPfnLMrgyTtYeIwxJsMlnCYMDst.GetKeyCodeById(_elementIdentifierId));
			}
		}

		private void rMtQxOKlBVPGXKZbrILjXElJWDBR()
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

		internal SerializedObject cSOgtQGQhdPyjGwILCVsTHtTgUFxA()
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
				{ "enabled", dQASdaEFVJzbOgxgKEdsYSDArFzi }
			};
		}

		internal void gzRmpiyWMaJwdTlfQTwJfqBAzPKK(SerializedObject P_0)
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
			dQASdaEFVJzbOgxgKEdsYSDArFzi = true;
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
			P_0.TryGetDeserializedValueByRef("enabled", ref dQASdaEFVJzbOgxgKEdsYSDArFzi);
		}

		public override string ToString()
		{
			if (s_toStringSB == null)
			{
				s_toStringSB = new StringBuilder();
			}
			StringTools.WriteVar(s_toStringSB, "Id", oFUAyzlkDBdPoonWGgEIgJYWTzJOA);
			StringTools.WriteVar(s_toStringSB, "Enabled", dQASdaEFVJzbOgxgKEdsYSDArFzi);
			StringTools.WriteVar(s_toStringSB, "Controller Map Id", (SzVdJMEQxohIcvuNjRRIbrgZqmZJA != null) ? SzVdJMEQxohIcvuNjRRIbrgZqmZJA.id : (-1));
			StringTools.WriteVar(s_toStringSB, "Action Id", _actionId);
			StringTools.WriteVar(s_toStringSB, "Action Descriptive Name", SwwQgKFAcOPLbKoMvcfHBeBKcgqb);
			StringTools.WriteVar(s_toStringSB, "Element Type", _elementType);
			StringTools.WriteVar(s_toStringSB, "Element Identifier Id", _elementIdentifierId);
			StringTools.WriteVar(s_toStringSB, "Element Identifier Name", aULpZKHJEpyYvKPMNVMOPHXlhORS);
			StringTools.WriteVar(s_toStringSB, "Element Index", rLYEVHHFczfqTKqknfIMkkwHoRbL);
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
