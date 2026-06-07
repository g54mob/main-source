using System;
using System.Text;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class ActionElementMap
	{
		[SerializeField]
		[CustomObfuscation]
		internal int _actionCategoryId;

		[SerializeField]
		[CustomObfuscation]
		internal int _actionId;

		[CustomObfuscation]
		[SerializeField]
		internal ControllerElementType _elementType;

		[CustomObfuscation]
		[SerializeField]
		internal int _elementIdentifierId;

		[CustomObfuscation]
		[SerializeField]
		internal AxisRange _axisRange;

		[SerializeField]
		[CustomObfuscation]
		internal bool _invert;

		[SerializeField]
		[CustomObfuscation]
		internal Pole _axisContribution;

		[SerializeField]
		[CustomObfuscation]
		internal KeyboardKeyCode _keyboardKeyCode;

		[SerializeField]
		[CustomObfuscation]
		internal ModifierKey _modifierKey1;

		[CustomObfuscation]
		[SerializeField]
		internal ModifierKey _modifierKey2;

		[SerializeField]
		[CustomObfuscation]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap xnhNfzyqGuCronbiVjqLrzXhjTDR;

		[NonSerialized]
		internal bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		[NonSerialized]
		private string QrYLUFYhZCvlEQOknfEziPsOZsSq;

		[NonSerialized]
		internal string XJdwKIichZeREkIGUnEESOQKckFHA;

		[NonSerialized]
		internal int UxnXexdLmPFrOAXyWtEwqWmaGYzH;

		[NonSerialized]
		internal readonly int HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

		[NonSerialized]
		private string qwVEWbvCsdgkMbHmwUSQPGDSjBefA;

		[NonSerialized]
		private ModifierKeyFlags eJViRESkYGfxSxIRgwoKsSvxBPRq;

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

		private bool gfrJWmCMLMIXBCMMGoQWXoGJXlBi => false;

		private static int YufSeXkYYuGgFwUwgPnDOhSwWduK => 0;

		internal static bool RgypiEzrKNlXmJDSoHMwaLTKYTNS(ActionElementMap P_0)
		{
			return false;
		}

		internal static void GwhfegIpGUviJtPvwbEnBEpfySlwb(ActionElementMap P_0, ActionElementMap P_1)
		{
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

		internal void kArqsxPmpmoyPVFqtFYUjLfaKBQC(ControllerMap P_0)
		{
		}

		internal void YxfUMMITaOjqKeSvHPHGBhfovMBh(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
		}

		private void kArqsxPmpmoyPVFqtFYUjLfaKBQC(bool P_0)
		{
		}

		private void kArqsxPmpmoyPVFqtFYUjLfaKBQC(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
		}

		private void FFgHdePLPPdVmsUuvpzWqbQhtSbO()
		{
		}

		private string MxrnaeqTudiQxAafEHvZDjtrydUCA()
		{
			return null;
		}

		internal void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
		}

		private bool qnbWZgJUOAepadEIlNHkMBEaJCefA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		private bool MrOstvWiMyaJRLgeINocXwcWeCvn(int P_0, AxisRange P_1)
		{
			return false;
		}

		private bool KWxLxoTHPSaorGQNNHeKVrvnGJqe(ElementAssignmentType P_0)
		{
			return false;
		}

		private void DfasoTofvVBgvRaiGtCqOJyelnH()
		{
		}

		private void avyHcrYJvddVfyfmhbcBCenjqcmb()
		{
		}

		private void VUsXorrFmwHQHHiSbowtgZDgLHRVB()
		{
		}

		internal SerializedObject OwZlvwNnIfDEsAMweyvGbtLoYQJtA()
		{
			return null;
		}

		internal void xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
