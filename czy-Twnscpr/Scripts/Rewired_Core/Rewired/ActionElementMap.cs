using System;
using System.Text;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class ActionElementMap
	{
		[CustomObfuscation]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation]
		internal AxisRange _axisRange;

		[CustomObfuscation]
		[SerializeField]
		internal bool _invert;

		[CustomObfuscation]
		[SerializeField]
		internal Pole _axisContribution;

		[SerializeField]
		[CustomObfuscation]
		internal KeyboardKeyCode _keyboardKeyCode;

		[CustomObfuscation]
		[SerializeField]
		internal ModifierKey _modifierKey1;

		[CustomObfuscation]
		[SerializeField]
		internal ModifierKey _modifierKey2;

		[CustomObfuscation]
		[SerializeField]
		internal ModifierKey _modifierKey3;

		[NonSerialized]
		internal ControllerMap eqICMNAeQqPWKbMtCpCcRRFJaxS;

		[NonSerialized]
		internal bool ebJsAuYejvRqociTxulmKyAPKrq;

		[NonSerialized]
		private string PhtdAzyxfOojsYIYgNOGQVuqHbF;

		[NonSerialized]
		internal string OhAdHiaYRHUAwesgRmFbimEcbLQE;

		[NonSerialized]
		internal int HaIFwVJpONuFeABKLoTBEXiGngk;

		[NonSerialized]
		internal readonly int EPKCDchEYzXNdkVlXPBcLtJDQuC;

		[NonSerialized]
		private string rTsFtPGRAhthkEhYrcJddnNKgsdT;

		[NonSerialized]
		private ModifierKeyFlags zwoicecsUDswNfzvEjbPArHAqEl;

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

		internal static bool OkBZwsBeLRgqKBkNrJDXQDDmeyS(ActionElementMap P_0)
		{
			return false;
		}

		internal static void HYENTUPzoAxblFMFdVEQwFnSHhk(ActionElementMap P_0, ActionElementMap P_1)
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

		internal void dyURZLplAcAtfTmfwsEvZDVSmbL(ControllerMap P_0)
		{
		}

		internal void FTGyjauHEArkmgYoWkAvncxWkQQ(ControllerMap P_0, HardwareControllerMap_Game P_1)
		{
		}

		private void dyURZLplAcAtfTmfwsEvZDVSmbL(bool P_0)
		{
		}

		private void dyURZLplAcAtfTmfwsEvZDVSmbL(ControllerType P_0, HardwareControllerMap_Game P_1, bool P_2)
		{
		}

		private void YZTGKlVlZKYWekAsFkdSSOXine()
		{
		}

		private string TnOHIQIGKlDvTEtPTcGsBzhTGNB()
		{
			return null;
		}

		internal void CKSoitBPjLqWpFGpwBNgDbvTrVm()
		{
		}

		private bool hrYicYfUqIoPQfggebEXojAUHdp(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			return false;
		}

		private bool LvnWiNqAqeExbVDMTlwZhspkjio(int P_0, AxisRange P_1)
		{
			return false;
		}

		private bool RSYPqQbCzIOpFEXyYrKfnAnJtzx(ElementAssignmentType P_0)
		{
			return false;
		}

		private void QZSFDQdxXhLOGvTAzRBlYMDWDJk()
		{
		}

		private void zEDjcMySjbPgnkbRsooTwIeVIFta()
		{
		}

		private void GYVZIXPnKaFqviUekzdAzEDvwrW()
		{
		}

		internal SerializedObject JmwEySjsRbHsSSCjraSnRZkWpCK()
		{
			return null;
		}

		internal void cLtgvbqpSWEWaXWDxkkwTJrGVrd(SerializedObject P_0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
