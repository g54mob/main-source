using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool AkqtmznNXRiyRfReyuAbFKNECHn;

		private bool ZcGaQhiqEshyZmkWIsQHXtgtsge;

		private int iueDnAHVXVmEMnNCzSowjkddzOFv;

		private ControllerType xRMUSowrwSVmfxjnqwQXevUgxsr;

		private int ruGCBfCWNtGZeTUKxKBCHIMxrSyL;

		private int BBfYdePpPGmEWHXGSKvuJJYoDWr;

		private int eSiuJRjaeNauGonEcsqAHmpnOiB;

		private ControllerElementType geStyfnIbdATvfzZcIGcHdNutpK;

		private int wyOUtAQIXRMHfdYotPsXMPVUbwu;

		private KeyCode vmRqFGHKVGMNlaRfwJESBKSAxJt;

		private ModifierKeyFlags EuXSHfxCxOKWtPSMReFOETpbVgh;

		private int mecAvOSCkKTUzDMSKLpGqHuOJBZ;

		public bool isConflict
		{
			get
			{
				return AkqtmznNXRiyRfReyuAbFKNECHn;
			}
			internal set
			{
				AkqtmznNXRiyRfReyuAbFKNECHn = value;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return ZcGaQhiqEshyZmkWIsQHXtgtsge;
			}
			internal set
			{
				ZcGaQhiqEshyZmkWIsQHXtgtsge = value;
			}
		}

		public int playerId
		{
			get
			{
				return iueDnAHVXVmEMnNCzSowjkddzOFv;
			}
			internal set
			{
				iueDnAHVXVmEMnNCzSowjkddzOFv = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return xRMUSowrwSVmfxjnqwQXevUgxsr;
			}
			internal set
			{
				xRMUSowrwSVmfxjnqwQXevUgxsr = value;
			}
		}

		public int controllerId
		{
			get
			{
				return ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
			}
			internal set
			{
				ruGCBfCWNtGZeTUKxKBCHIMxrSyL = value;
			}
		}

		public int controllerMapId
		{
			get
			{
				return BBfYdePpPGmEWHXGSKvuJJYoDWr;
			}
			internal set
			{
				BBfYdePpPGmEWHXGSKvuJJYoDWr = value;
			}
		}

		public int elementMapId
		{
			get
			{
				return eSiuJRjaeNauGonEcsqAHmpnOiB;
			}
			internal set
			{
				eSiuJRjaeNauGonEcsqAHmpnOiB = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return geStyfnIbdATvfzZcIGcHdNutpK;
			}
			internal set
			{
				geStyfnIbdATvfzZcIGcHdNutpK = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return wyOUtAQIXRMHfdYotPsXMPVUbwu;
			}
			internal set
			{
				wyOUtAQIXRMHfdYotPsXMPVUbwu = value;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return vmRqFGHKVGMNlaRfwJESBKSAxJt;
			}
			internal set
			{
				vmRqFGHKVGMNlaRfwJESBKSAxJt = value;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return EuXSHfxCxOKWtPSMReFOETpbVgh;
			}
			internal set
			{
				EuXSHfxCxOKWtPSMReFOETpbVgh = value;
			}
		}

		public int actionId
		{
			get
			{
				return mecAvOSCkKTUzDMSKLpGqHuOJBZ;
			}
			internal set
			{
				mecAvOSCkKTUzDMSKLpGqHuOJBZ = value;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(iueDnAHVXVmEMnNCzSowjkddzOFv);
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
				return ReInput.controllers.GetController(xRMUSowrwSVmfxjnqwQXevUgxsr, ruGCBfCWNtGZeTUKxKBCHIMxrSyL);
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				if (player == null)
				{
					return null;
				}
				return player.controllers.maps.GetMap(xRMUSowrwSVmfxjnqwQXevUgxsr, ruGCBfCWNtGZeTUKxKBCHIMxrSyL, BBfYdePpPGmEWHXGSKvuJJYoDWr);
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
				if (controllerMap == null)
				{
					return null;
				}
				return controllerMap.GetElementMap(eSiuJRjaeNauGonEcsqAHmpnOiB);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (xRMUSowrwSVmfxjnqwQXevUgxsr == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(vmRqFGHKVGMNlaRfwJESBKSAxJt, EuXSHfxCxOKWtPSMReFOETpbVgh);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.name;
			}
		}

		public ElementAssignmentConflictInfo(bool isConflict, bool isUserAssignable, int playerId, ControllerType controllerType, int controllerId, int controllerMapId, int elementMapId, int actionId, ControllerElementType elementType, int elementIdentifierId, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			AkqtmznNXRiyRfReyuAbFKNECHn = isConflict;
			ZcGaQhiqEshyZmkWIsQHXtgtsge = isUserAssignable;
			iueDnAHVXVmEMnNCzSowjkddzOFv = playerId;
			xRMUSowrwSVmfxjnqwQXevUgxsr = controllerType;
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = controllerId;
			BBfYdePpPGmEWHXGSKvuJJYoDWr = controllerMapId;
			eSiuJRjaeNauGonEcsqAHmpnOiB = elementMapId;
			mecAvOSCkKTUzDMSKLpGqHuOJBZ = actionId;
			geStyfnIbdATvfzZcIGcHdNutpK = elementType;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = elementIdentifierId;
			vmRqFGHKVGMNlaRfwJESBKSAxJt = keyCode;
			EuXSHfxCxOKWtPSMReFOETpbVgh = modifierKeyFlags;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo source)
		{
			AkqtmznNXRiyRfReyuAbFKNECHn = source.AkqtmznNXRiyRfReyuAbFKNECHn;
			ZcGaQhiqEshyZmkWIsQHXtgtsge = source.ZcGaQhiqEshyZmkWIsQHXtgtsge;
			iueDnAHVXVmEMnNCzSowjkddzOFv = source.iueDnAHVXVmEMnNCzSowjkddzOFv;
			xRMUSowrwSVmfxjnqwQXevUgxsr = source.xRMUSowrwSVmfxjnqwQXevUgxsr;
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = source.ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
			BBfYdePpPGmEWHXGSKvuJJYoDWr = source.BBfYdePpPGmEWHXGSKvuJJYoDWr;
			eSiuJRjaeNauGonEcsqAHmpnOiB = source.eSiuJRjaeNauGonEcsqAHmpnOiB;
			mecAvOSCkKTUzDMSKLpGqHuOJBZ = source.mecAvOSCkKTUzDMSKLpGqHuOJBZ;
			geStyfnIbdATvfzZcIGcHdNutpK = source.geStyfnIbdATvfzZcIGcHdNutpK;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = source.wyOUtAQIXRMHfdYotPsXMPVUbwu;
			vmRqFGHKVGMNlaRfwJESBKSAxJt = source.vmRqFGHKVGMNlaRfwJESBKSAxJt;
			EuXSHfxCxOKWtPSMReFOETpbVgh = source.EuXSHfxCxOKWtPSMReFOETpbVgh;
		}
	}
}
