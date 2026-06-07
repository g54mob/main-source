using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap AyUXXRTpmYRSUoYewvycFOIqJcVe;

		private readonly ControllerElementType hvFRqxzQNnZlVLfAiCpfgaqyaFQF;

		private readonly int GsmBIdAuWmeyXSLihzwIKnXhQlRw;

		private readonly int eqalATYTmsHoAicOfRxFTYzVpiBc;

		private readonly AxisRange jNMLbcbTcqehpmPdmzXMPAIUigMS;

		private readonly KeyCode zIxjGXQqlKVRPARKKpSogbaMjpKy;

		private readonly ModifierKeyFlags PUXlgFvxQcWnLcVBlkGLDGjZWAXH;

		private readonly int ndKXqYZjdSSmAnvbEZDemhppnTJA;

		private readonly Pole YJlJLrFnQyCnHBEdelCmbUeyzRUMA;

		private readonly bool uCqEzdIJgoecZgZodFmqQNJvAozfb;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (AyUXXRTpmYRSUoYewvycFOIqJcVe == null)
				{
					return null;
				}
				return AyUXXRTpmYRSUoYewvycFOIqJcVe.player;
			}
		}

		public InputAction action
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.mapping.GetAction(ndKXqYZjdSSmAnvbEZDemhppnTJA);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (AyUXXRTpmYRSUoYewvycFOIqJcVe == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(AyUXXRTpmYRSUoYewvycFOIqJcVe.controllerType, AyUXXRTpmYRSUoYewvycFOIqJcVe.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || AyUXXRTpmYRSUoYewvycFOIqJcVe == null)
				{
					return ControllerType.Keyboard;
				}
				return AyUXXRTpmYRSUoYewvycFOIqJcVe.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || AyUXXRTpmYRSUoYewvycFOIqJcVe == null)
				{
					return -1;
				}
				return AyUXXRTpmYRSUoYewvycFOIqJcVe.controllerId;
			}
		}

		public ControllerMap controllerMap => AyUXXRTpmYRSUoYewvycFOIqJcVe;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(eqalATYTmsHoAicOfRxFTYzVpiBc);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (AyUXXRTpmYRSUoYewvycFOIqJcVe == null)
				{
					return null;
				}
				return AyUXXRTpmYRSUoYewvycFOIqJcVe.GetElementMap(GsmBIdAuWmeyXSLihzwIKnXhQlRw);
			}
		}

		public ControllerElementType elementType => hvFRqxzQNnZlVLfAiCpfgaqyaFQF;

		public Pole axisContribution => YJlJLrFnQyCnHBEdelCmbUeyzRUMA;

		public AxisRange axisRange => jNMLbcbTcqehpmPdmzXMPAIUigMS;

		public bool invert => uCqEzdIJgoecZgZodFmqQNJvAozfb;

		public KeyCode keyCode => zIxjGXQqlKVRPARKKpSogbaMjpKy;

		public ModifierKeyFlags modifierKeyFlags => PUXlgFvxQcWnLcVBlkGLDGjZWAXH;

		public string elementDisplayName
		{
			get
			{
				if (AyUXXRTpmYRSUoYewvycFOIqJcVe == null)
				{
					return string.Empty;
				}
				if (controllerType == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(keyCode, modifierKeyFlags);
				}
				Controller controller = this.controller;
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(eqalATYTmsHoAicOfRxFTYzVpiBc);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (hvFRqxzQNnZlVLfAiCpfgaqyaFQF == ControllerElementType.Axis)
				{
					if (jNMLbcbTcqehpmPdmzXMPAIUigMS == AxisRange.Full)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
					if (jNMLbcbTcqehpmPdmzXMPAIUigMS == AxisRange.Positive)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
					}
					if (jNMLbcbTcqehpmPdmzXMPAIUigMS == AxisRange.Negative)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName;
					}
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		internal ElementAssignmentInfo(ControllerMap P_0, ElementAssignment P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			ndKXqYZjdSSmAnvbEZDemhppnTJA = P_1.actionId;
			AyUXXRTpmYRSUoYewvycFOIqJcVe = P_0;
			GsmBIdAuWmeyXSLihzwIKnXhQlRw = P_1.elementMapId;
			eqalATYTmsHoAicOfRxFTYzVpiBc = P_1.elementIdentifierId;
			zIxjGXQqlKVRPARKKpSogbaMjpKy = P_1.keyboardKey;
			PUXlgFvxQcWnLcVBlkGLDGjZWAXH = P_1.modifierKeyFlags;
			uCqEzdIJgoecZgZodFmqQNJvAozfb = P_1.invert;
			hvFRqxzQNnZlVLfAiCpfgaqyaFQF = pMvvECjJycyKibKKCAXEnFbBPTVk.xNeYpGuJHefJZlyNqQjEMgcfdnoC(P_1.type);
			YJlJLrFnQyCnHBEdelCmbUeyzRUMA = P_1.axisContribution;
			jNMLbcbTcqehpmPdmzXMPAIUigMS = P_1.axisRange;
			if (AyUXXRTpmYRSUoYewvycFOIqJcVe.controllerType == ControllerType.Keyboard)
			{
				Keyboard.EygbfUBdfHOlPWAecJsoicbWKRQT(ref eqalATYTmsHoAicOfRxFTYzVpiBc, ref zIxjGXQqlKVRPARKKpSogbaMjpKy);
			}
		}
	}
}
