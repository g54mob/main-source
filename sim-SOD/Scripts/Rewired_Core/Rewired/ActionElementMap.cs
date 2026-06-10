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
		[CustomObfuscation(rename = false)]
		internal int _actionCategoryId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		internal int _actionId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
		internal ControllerMap rAbbicgqWKQOAQlOWnWEeduwIaQG;

		[NonSerialized]
		internal bool fYgWWBiWXTDKmooXjoXGiYdmpQy;

		[NonSerialized]
		private string KEIZHCYARwVdmUAWwvkouOLFMVL;

		[NonSerialized]
		internal string ZvxpRsonObPcJiufRuLKSlBZREU;

		[NonSerialized]
		internal int OIzOlwldabDhgIIGLQVxBqZzqlcE;

		[NonSerialized]
		internal readonly int ZjhenRHxqNuSrgJhTzeCvEoySmU;

		[NonSerialized]
		private string eJIBirouJycgvVEnFcVRscBtkn;

		[NonSerialized]
		private ModifierKeyFlags mZHFWPfCEsNpepXxtAGZEkEkjsIA;

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

		private bool isKeyboardMap => false;

		private static int nextUid => 0;

		internal static bool XUwXhTzSIxUtAFDchoinqDcNCeSG(ActionElementMap P_0)
		{
			return false;
		}

		internal static void YFfHrdvfAqUabBOBvbgeQpSxkza(ActionElementMap P_0, ActionElementMap P_1)
		{
		}

		public ActionElementMap()
		{
		}

		public ActionElementMap(ActionElementMap map)
		{
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId)
		{
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId, Pole axisContribution, AxisRange axisRange)
		{
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, int elementIdentifierId, Pole axisContribution, AxisRange axisRange, bool invert)
		{
		}

		public ActionElementMap(int actionId, ControllerElementType elementType, Pole axisContribution, KeyboardKeyCode keyboardKeyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
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

		internal void cOvnwcNhkYikxNIruzRTdfelpoD(ControllerMap P_0)
		{
		}

		internal void CIrHtZOeFqvUaekBGhlHTWhlCFK(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
		}

		private void cOvnwcNhkYikxNIruzRTdfelpoD(bool P_0)
		{
		}

		private void cOvnwcNhkYikxNIruzRTdfelpoD(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
		}

		private void NVifgnHLRhAZYZsWuPVTnkdoQhw()
		{
		}

		private string WKnyptcVyHMIHYpTNpTUxXWaMIV()
		{
			return null;
		}

		internal void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		private bool uajSQfLMEiQlCjmyiGnxkAldMdjA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		private bool EfQVsoEpUUTRhRVODUCdPmBZdzc(int P_0, AxisRange P_1)
		{
			return false;
		}

		private bool QjnWblJmTimGTCxwAvpLDQuitaz(ElementAssignmentType P_0)
		{
			return false;
		}

		private void ZsfrxlHHhZHVOxaAjhqRsssfXFy()
		{
		}

		private void kKmaMzKXZJtblksPikFjOEZsDNxC()
		{
		}

		private void LhupjcffyCjGfyNyyKMwVRgCNgA()
		{
		}

		internal SerializedObject IJTYgxRVETFGIEeOvEZXpvilyrI()
		{
			return null;
		}

		internal void jygDICBMHaTDOHrItEJCbjkpEXhs(SerializedObject P_0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
