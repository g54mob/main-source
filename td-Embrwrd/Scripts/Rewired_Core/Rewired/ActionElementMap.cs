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
		[CustomObfuscation(rename = false)]
		[SerializeField]
		internal int _actionCategoryId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
		internal ControllerMap SJaDkUFiuzaUSVQoBatruxbJKISBA;

		[NonSerialized]
		internal bool nJztAqkKSSbwqErJiikDAyAWJwkj;

		[NonSerialized]
		internal int nrtdVRdyzyyTtiuRDonpmjfPOboK;

		[NonSerialized]
		internal readonly int aCndXpFsGMILKWSfyeclREHUQXUu;

		[NonSerialized]
		private uint RtszoHHyCmlYsbXgIItTGDiQTRoH;

		[NonSerialized]
		private string qLABiqHbHycxKgTSWxYNbpTITWyJb;

		[NonSerialized]
		private string jwkjWuepHnatXJbSUlUTXagEvIgm;

		[NonSerialized]
		private ModifierKeyFlags nuGdbrfbcOIYjrmMQkprqOyMRbRe;

		[NonSerialized]
		private HardwareControllerMap_Game dNyJcFclXvGAJjHdNieYjFxphpWVA;

		[NonSerialized]
		private double qrliormnqjpcAEiPGsCALbHBcWeiA;

		[NonSerialized]
		private ActionElementMap QeChUkutgirYEzjUecqxxuuFnwfS;

		[NonSerialized]
		private ActionElementMap xjGbruYEPERWYXSRbKspnIfVpHQl;

		[NonSerialized]
		private int CwmeQaawDIfPpZnQleaQTAWGafEE;

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

		private bool doMebDeQbXawZyPYNKoNxIGAmfdq => false;

		private static int mpltEzCuFbUqOJGtPPEcKIPnawDH => 0;

		internal static bool VWUYogPiMNhumUheUauAQftTKwrf(ActionElementMap P_0, out ActionElementMap P_1, out ActionElementMap P_2)
		{
			P_1 = null;
			P_2 = null;
			return false;
		}

		internal static bool qObByIktTQjDjQkKTGqMfwHMKANg(ActionElementMap P_0)
		{
			return false;
		}

		internal static void pJbHNxurtACMBzlLdAXkJHvFkfqD(ActionElementMap P_0, ActionElementMap P_1)
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

		private static bool dXzUuIKziOucBSNhXSJQdbgwEpjaA(IList<ActionElementMap> P_0, bool P_1, bool P_2, out object P_3, out string P_4)
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

		internal void FHWctItHnGwUmEjlXjbxFswHuoNTA(ControllerMap P_0)
		{
		}

		internal void lawiWpBLmhlllXzSQwPnMfaslgEc(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
		}

		private void pgHUruaYjeCRMlMVwEurEdDVzbdTA(bool P_0)
		{
		}

		private void JCOvOHhhjXvIjrHwInJyymVOdabw(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
		}

		private string DgjCsAbdWpZAHnPaTigMceeadabM()
		{
			return null;
		}

		private int GwBGLAqDrjaGbeQnbenuCOUumbyu(ICollection<object> P_0)
		{
			return 0;
		}

		private int dSUVuJFBtXAGbRKZrcxNpvrWjXbg(ICollection<string> P_0)
		{
			return 0;
		}

		internal void eWjiZbLDQwybeJjVRrpnYEVnFIEaA()
		{
		}

		private bool EjTApBGYCekJEzKNLdFNRNiYAFve(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		private bool kiacUWhdsPfhNqbndheYfEIlfePA(int P_0, AxisRange P_1)
		{
			return false;
		}

		private bool mGkAdDssuMpQEmWwZuAotMNUfgdI(ElementAssignmentType P_0)
		{
			return false;
		}

		private void NfsfUvACiMejScZjEWvwcIsFHVVh()
		{
		}

		private void nGyFTyTRoNgknYlYIYzcPkyRwFbF()
		{
		}

		private void lSULYWcPUQuGvkuCXRfWVFuHAvAiA()
		{
		}

		internal void dICFOyvwVsnUIjSSYOZSUzgtByXV()
		{
		}

		internal SerializedObject yQnbUGikmglaZbGpdkdNcRyRkgKfb()
		{
			return null;
		}

		internal void ucsPpsYpNjNuHveCgnRqlbIMRyTg(SerializedObject P_0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
