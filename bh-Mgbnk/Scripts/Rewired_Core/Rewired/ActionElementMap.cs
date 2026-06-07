using System;
using System.Collections.Generic;
using System.Text;
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal bool _invert;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap VZbcOnbGHkbQCctumTLcvpEpIcLe;

		[NonSerialized]
		internal bool sJiZjarByPFOekuKHAIndKOqaLbdb;

		[NonSerialized]
		internal int obegvRevRhSJpQYUkeELmTdhTSxx;

		[NonSerialized]
		internal readonly int nhahTzMMoVhwYeqkXRELLTHoCNHkA;

		[NonSerialized]
		private uint MGlaOHQemlvwWFnItuHvCsGmNWxe;

		[NonSerialized]
		private string lQXqaXehGhWeYxLfvsGpxRTzSjlc;

		[NonSerialized]
		private string cqnMvchlbyATNjFDrUDpLCcehfdIA;

		[NonSerialized]
		private ModifierKeyFlags iPLbxrayPJsdbnNjhLOBReCoRLEXA;

		[NonSerialized]
		private HardwareControllerMap_Game aCtigVbbtwGnJVcmyoWkPAbDYtLv;

		[NonSerialized]
		private double vYksJvjEEqENWeUQhnowZlLbPMnW;

		private static int uidCounter;

		private static StringBuilder s_toStringSB;

		public int actionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return default(ControllerElementType);
			}
			internal set
			{
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return default(AxisRange);
			}
			set
			{
			}
		}

		public bool invert
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Pole axisContribution
		{
			get
			{
				return default(Pole);
			}
			set
			{
			}
		}

		public KeyboardKeyCode keyboardKeyCode
		{
			get
			{
				return default(KeyboardKeyCode);
			}
			set
			{
			}
		}

		public ModifierKey modifierKey1
		{
			get
			{
				return default(ModifierKey);
			}
			set
			{
			}
		}

		public ModifierKey modifierKey2
		{
			get
			{
				return default(ModifierKey);
			}
			set
			{
			}
		}

		public ModifierKey modifierKey3
		{
			get
			{
				return default(ModifierKey);
			}
			set
			{
			}
		}

		public AxisType axisType => default(AxisType);

		public ModifierKeyFlags modifierKeyFlags => default(ModifierKeyFlags);

		public KeyCode keyCode
		{
			get
			{
				return default(KeyCode);
			}
			set
			{
			}
		}

		public bool hasModifiers => false;

		[CustomObfuscation(rename = false)]
		internal double modifiedTime => 0.0;

		[CustomObfuscation(rename = false)]
		internal bool isModified
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ControllerMap controllerMap => null;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string elementIdentifierName => null;

		public string actionDescriptiveName => null;

		public int elementIndex => 0;

		public int id => 0;

		public object elementIdentifierGlyph => null;

		public int elementIdentifierGlyphCount => 0;

		private bool kVXCxBngBYyNDEoJkiCdfDGgyjis => false;

		private static int zWyqvvRcfcLlAnCJiudIOyLLgyET => 0;

		internal static bool nbmwXKvMPFMOrqQhkTwczlggEOQP(ActionElementMap P_0)
		{
			return false;
		}

		internal static void mSizZbtBNHCtLNwiUEuUAHBnRqdEA(ActionElementMap P_0, ActionElementMap P_1)
		{
		}

		public static bool TryGetCombinedElementIdentifierName(IList<ActionElementMap> actionElementMaps, out string result)
		{
			result = null;
			return false;
		}

		public static bool TryGetCombinedElementIdentifierGlyph(IList<ActionElementMap> actionElementMaps, out object result)
		{
			result = null;
			return false;
		}

		public static bool TryGetCombinedElementIdentifierFinalGlyphKey(IList<ActionElementMap> actionElementMaps, out string result)
		{
			result = null;
			return false;
		}

		private static bool scsicGBbABJGJqYcabNqpBoQnsci(IList<ActionElementMap> P_0, bool P_1, bool P_2, out object P_3, out string P_4)
		{
			P_3 = null;
			P_4 = null;
			return false;
		}

		public ActionElementMap()
		{
		}

		public ActionElementMap(ActionElementMap P_0)
		{
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, int P_2)
		{
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, int P_2, Pole P_3, AxisRange P_4)
		{
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, int P_2, Pole P_3, AxisRange P_4, bool P_5)
		{
		}

		public ActionElementMap(int P_0, ControllerElementType P_1, Pole P_2, KeyboardKeyCode P_3, ModifierKey P_4, ModifierKey P_5, ModifierKey P_6)
		{
		}

		public bool CheckForAssignmentConflict(ElementAssignment elementAssignment)
		{
			return false;
		}

		public bool CheckForAssignmentConflict(ActionElementMap elementMap)
		{
			return false;
		}

		public bool ShowInField(AxisRange fieldActionRange)
		{
			return false;
		}

		public bool IsTarget(ControllerElementTarget elementTarget)
		{
			return false;
		}

		public bool IsTarget(IControllerElementTarget elementTarget)
		{
			return false;
		}

		public int GetElementIdentifierGlyphs(ICollection<object> results)
		{
			return 0;
		}

		public int GetElementIdentifierGlyphs<T>(ICollection<T> results)
		{
			return 0;
		}

		public int GetElementIdentifierFinalGlyphKeys(ICollection<string> results)
		{
			return 0;
		}

		internal void AmDgvCwpJZwhkgneqPTVkTkxAsMx(ControllerMap P_0)
		{
		}

		internal void icpEqScKrgpExJpkrTOjcSlWbvhzA(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
		}

		private void umYvnyjHfvmdWJKMNYYDtZjrtmwd(bool P_0)
		{
		}

		private void SPJGgLoERQllnFallFbGqCRqpywr(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
		}

		private string CNyvOWeWeursZDPviNMgcJyWzaer()
		{
			return null;
		}

		private int FuAiWUtIVgavrWPuYlFCGySIMzzS(ICollection<object> P_0)
		{
			return 0;
		}

		private int kbDAFDaKrSqzxyzUUAMhhSnkAjyEA(ICollection<string> P_0)
		{
			return 0;
		}

		internal void zdgPVrIGqnQvejDMaaFFIsTZfORZ()
		{
		}

		private bool BKSfCvcTypkXEkRTchRbxJTeKIaHb(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		private bool vDpHqOaaRtnShuYqCIVOxWMuZfnr(int P_0, AxisRange P_1)
		{
			return false;
		}

		private bool rthqOXfrORFAWEkbmkOWtrJgejqN(ElementAssignmentType P_0)
		{
			return false;
		}

		private void OnfrlvNtQPUFGGnanliEyHmtsHYQ()
		{
		}

		private void anrOBoWrOWPJbmCXhtoILWyruPwL()
		{
		}

		private void cbXYOOtcsPitbErRaiPuPOsxanZIA()
		{
		}

		internal void aRXBEcokrpMhILNBhkhcKcgFOmOw()
		{
		}

		internal SerializedObject nvqIOszOvxBVQegwCRjZFyxwgNeb()
		{
			return null;
		}

		internal void hajqVaBLzeoqXPgJNHHSrpGeoDSP(SerializedObject P_0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
