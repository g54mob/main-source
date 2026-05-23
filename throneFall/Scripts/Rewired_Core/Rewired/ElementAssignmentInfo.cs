using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap npvMlPQLvZsyyhhAjngvmGCOuRhq;

		private readonly ControllerElementType ULqIpvoVEaexbMijjEXiJpcKjeyr;

		private readonly int tdDeAhDfQbkZpNigcPbLnsNTHrbU;

		private readonly int DIRnXSZuTtgiCjpgabQgkTMhVrSS;

		private readonly AxisRange UUfNkncybtGLOxzenkXyoEkycuaB;

		private readonly KeyCode GtYklDBrJHmMlHWWTqbwBgzqpmdc;

		private readonly ModifierKeyFlags oKkODVkrtvSznnkVePhAaHllNAzP;

		private readonly int IwGOfoDVfkVvGNxvaiCMPZtXfdly;

		private readonly Pole psYjTbUGfrUMnVhtjZRfbiZUFDoD;

		private readonly bool JNBNztXGcnJmdKFmcihrgkLJDgXw;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (npvMlPQLvZsyyhhAjngvmGCOuRhq == null)
				{
					return null;
				}
				return npvMlPQLvZsyyhhAjngvmGCOuRhq.player;
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
				return ReInput.mapping.GetAction(IwGOfoDVfkVvGNxvaiCMPZtXfdly);
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
				if (npvMlPQLvZsyyhhAjngvmGCOuRhq == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(npvMlPQLvZsyyhhAjngvmGCOuRhq.controllerType, npvMlPQLvZsyyhhAjngvmGCOuRhq.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || npvMlPQLvZsyyhhAjngvmGCOuRhq == null)
				{
					return ControllerType.Keyboard;
				}
				return npvMlPQLvZsyyhhAjngvmGCOuRhq.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || npvMlPQLvZsyyhhAjngvmGCOuRhq == null)
				{
					return -1;
				}
				return npvMlPQLvZsyyhhAjngvmGCOuRhq.controllerId;
			}
		}

		public ControllerMap controllerMap => npvMlPQLvZsyyhhAjngvmGCOuRhq;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(DIRnXSZuTtgiCjpgabQgkTMhVrSS);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (npvMlPQLvZsyyhhAjngvmGCOuRhq == null)
				{
					return null;
				}
				return npvMlPQLvZsyyhhAjngvmGCOuRhq.GetElementMap(tdDeAhDfQbkZpNigcPbLnsNTHrbU);
			}
		}

		public ControllerElementType elementType => ULqIpvoVEaexbMijjEXiJpcKjeyr;

		public Pole axisContribution => psYjTbUGfrUMnVhtjZRfbiZUFDoD;

		public AxisRange axisRange => UUfNkncybtGLOxzenkXyoEkycuaB;

		public bool invert => JNBNztXGcnJmdKFmcihrgkLJDgXw;

		public KeyCode keyCode => GtYklDBrJHmMlHWWTqbwBgzqpmdc;

		public ModifierKeyFlags modifierKeyFlags => oKkODVkrtvSznnkVePhAaHllNAzP;

		public string elementDisplayName
		{
			get
			{
				if (npvMlPQLvZsyyhhAjngvmGCOuRhq == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(DIRnXSZuTtgiCjpgabQgkTMhVrSS);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (ULqIpvoVEaexbMijjEXiJpcKjeyr == ControllerElementType.Axis)
				{
					if (UUfNkncybtGLOxzenkXyoEkycuaB == AxisRange.Full)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
					if (UUfNkncybtGLOxzenkXyoEkycuaB == AxisRange.Positive)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
					}
					if (UUfNkncybtGLOxzenkXyoEkycuaB == AxisRange.Negative)
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
			IwGOfoDVfkVvGNxvaiCMPZtXfdly = P_1.actionId;
			npvMlPQLvZsyyhhAjngvmGCOuRhq = P_0;
			tdDeAhDfQbkZpNigcPbLnsNTHrbU = P_1.elementMapId;
			DIRnXSZuTtgiCjpgabQgkTMhVrSS = P_1.elementIdentifierId;
			GtYklDBrJHmMlHWWTqbwBgzqpmdc = P_1.keyboardKey;
			oKkODVkrtvSznnkVePhAaHllNAzP = P_1.modifierKeyFlags;
			JNBNztXGcnJmdKFmcihrgkLJDgXw = P_1.invert;
			ULqIpvoVEaexbMijjEXiJpcKjeyr = SVQbmGoCgjXlQooYDoNZCFflMVzP.UeHIoYfXRtOMvsmupeRJgnkNPpWjA(P_1.type);
			psYjTbUGfrUMnVhtjZRfbiZUFDoD = P_1.axisContribution;
			UUfNkncybtGLOxzenkXyoEkycuaB = P_1.axisRange;
			if (npvMlPQLvZsyyhhAjngvmGCOuRhq.controllerType == ControllerType.Keyboard)
			{
				Keyboard.rpLFLEYGhGqlxLEmjQrjDcbgYLsW(ref DIRnXSZuTtgiCjpgabQgkTMhVrSS, ref GtYklDBrJHmMlHWWTqbwBgzqpmdc);
			}
		}
	}
}
