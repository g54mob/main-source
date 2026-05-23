using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap JdetZGSYAxuUPraClBlCSLMWOmU;

		private readonly ControllerElementType geStyfnIbdATvfzZcIGcHdNutpK;

		private readonly int KFfZLEMSnjgXtdVfyqrheefMMKVb;

		private readonly int wyOUtAQIXRMHfdYotPsXMPVUbwu;

		private readonly AxisRange ObWitXNhWFZMnOJBWvYTcBBfVnG;

		private readonly KeyCode vmRqFGHKVGMNlaRfwJESBKSAxJt;

		private readonly ModifierKeyFlags EuXSHfxCxOKWtPSMReFOETpbVgh;

		private readonly int mecAvOSCkKTUzDMSKLpGqHuOJBZ;

		private readonly Pole RQQsGIecPtkXpHobDdmZtQkIRSs;

		private readonly bool vkDZTsWOJBkpzXazOFlYaCZkzNP;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
				{
					return null;
				}
				return JdetZGSYAxuUPraClBlCSLMWOmU.player;
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
				return ReInput.mapping.GetAction(mecAvOSCkKTUzDMSKLpGqHuOJBZ);
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
				if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(JdetZGSYAxuUPraClBlCSLMWOmU.controllerType, JdetZGSYAxuUPraClBlCSLMWOmU.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput.isReady)
				{
					while (true)
					{
						int num = 1417242828;
						while (true)
						{
							switch (num ^ 0x547968CD)
							{
							case 2:
								break;
							case 1:
								goto IL_0025;
							default:
								goto end_IL_0007;
							}
							break;
							IL_0025:
							if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
							{
								num = 1417242829;
								continue;
							}
							return JdetZGSYAxuUPraClBlCSLMWOmU.controllerType;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				return ControllerType.Keyboard;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || JdetZGSYAxuUPraClBlCSLMWOmU == null)
				{
					return -1;
				}
				return JdetZGSYAxuUPraClBlCSLMWOmU.controllerId;
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				return JdetZGSYAxuUPraClBlCSLMWOmU;
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
				{
					return null;
				}
				return JdetZGSYAxuUPraClBlCSLMWOmU.GetElementMap(KFfZLEMSnjgXtdVfyqrheefMMKVb);
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return geStyfnIbdATvfzZcIGcHdNutpK;
			}
		}

		public Pole axisContribution
		{
			get
			{
				return RQQsGIecPtkXpHobDdmZtQkIRSs;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return ObWitXNhWFZMnOJBWvYTcBBfVnG;
			}
		}

		public bool invert
		{
			get
			{
				return vkDZTsWOJBkpzXazOFlYaCZkzNP;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return vmRqFGHKVGMNlaRfwJESBKSAxJt;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return EuXSHfxCxOKWtPSMReFOETpbVgh;
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (JdetZGSYAxuUPraClBlCSLMWOmU == null)
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
					goto IL_0032;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
				int num = 1477746486;
				goto IL_0037;
				IL_0032:
				num = 1477746483;
				goto IL_0037;
				IL_0037:
				while (true)
				{
					switch (num ^ 0x58149F32)
					{
					case 0:
						break;
					case 1:
						return string.Empty;
					case 4:
						if (elementIdentifierById == null)
						{
							num = 1477746480;
							continue;
						}
						if (geStyfnIbdATvfzZcIGcHdNutpK == ControllerElementType.Axis)
						{
							if (ObWitXNhWFZMnOJBWvYTcBBfVnG == AxisRange.Full)
							{
								return elementIdentifierById.name;
							}
							if (ObWitXNhWFZMnOJBWvYTcBBfVnG == AxisRange.Positive)
							{
								return elementIdentifierById.positiveName;
							}
							if (ObWitXNhWFZMnOJBWvYTcBBfVnG == AxisRange.Negative)
							{
								num = 1477746481;
								continue;
							}
						}
						return elementIdentifierById.name;
					case 2:
						return string.Empty;
					default:
						return elementIdentifierById.negativeName;
					}
					break;
				}
				goto IL_0032;
			}
		}

		internal ElementAssignmentInfo(ControllerMap controllerMap, ElementAssignment assignment)
		{
			if (controllerMap == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			mecAvOSCkKTUzDMSKLpGqHuOJBZ = assignment.actionId;
			JdetZGSYAxuUPraClBlCSLMWOmU = controllerMap;
			KFfZLEMSnjgXtdVfyqrheefMMKVb = assignment.elementMapId;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = assignment.elementIdentifierId;
			vmRqFGHKVGMNlaRfwJESBKSAxJt = assignment.keyboardKey;
			EuXSHfxCxOKWtPSMReFOETpbVgh = assignment.modifierKeyFlags;
			vkDZTsWOJBkpzXazOFlYaCZkzNP = assignment.invert;
			geStyfnIbdATvfzZcIGcHdNutpK = jHLGlrXjGMMIuxAEONcGlnwHltw.CSNCkOQjILujRXYRCEZThnKdpKC(assignment.type);
			RQQsGIecPtkXpHobDdmZtQkIRSs = assignment.axisContribution;
			ObWitXNhWFZMnOJBWvYTcBBfVnG = assignment.axisRange;
			if (JdetZGSYAxuUPraClBlCSLMWOmU.controllerType == ControllerType.Keyboard)
			{
				Keyboard.FixKeyboardAssignments(ref wyOUtAQIXRMHfdYotPsXMPVUbwu, ref vmRqFGHKVGMNlaRfwJESBKSAxJt);
			}
		}
	}
}
