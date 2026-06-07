using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool rBodfkRQNJhByhXbSuClAyLEmCsU;

		private bool sfAJboWUMsLmaALRoAKTkymntHz;

		private int VUcYiZtcJRatratRXOokIFfcdNSg;

		private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

		private int WuIXWewTRtkXNcGHNDHMpyChWRj;

		private int oObggzFhPIUffDtZyBnmnuCyLXyy;

		private int NjsrlERmaDZZxQiTMonWeEbdxoY;

		private ControllerElementType ZcCJfoFOnfaVWPxSGABewnPoqKP;

		private int TZSPqisJATrQkFfRXLKedgRIcwv;

		private KeyCode EZXgGJlJJGLqECQiOgASqMQAZMg;

		private ModifierKeyFlags tmDdGydFlWVbCarXzSZWfplxDpyN;

		private int ZUoDkTcclUigIzTjeFLCXFMQOaU;

		public bool isConflict
		{
			get
			{
				return rBodfkRQNJhByhXbSuClAyLEmCsU;
			}
			internal set
			{
				rBodfkRQNJhByhXbSuClAyLEmCsU = value;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return sfAJboWUMsLmaALRoAKTkymntHz;
			}
			internal set
			{
				sfAJboWUMsLmaALRoAKTkymntHz = value;
			}
		}

		public int playerId
		{
			get
			{
				return VUcYiZtcJRatratRXOokIFfcdNSg;
			}
			internal set
			{
				VUcYiZtcJRatratRXOokIFfcdNSg = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return CiEHnIGrjScHYHuMEoDVXvEgwiy;
			}
			internal set
			{
				CiEHnIGrjScHYHuMEoDVXvEgwiy = value;
			}
		}

		public int controllerId
		{
			get
			{
				return WuIXWewTRtkXNcGHNDHMpyChWRj;
			}
			internal set
			{
				WuIXWewTRtkXNcGHNDHMpyChWRj = value;
			}
		}

		public int controllerMapId
		{
			get
			{
				return oObggzFhPIUffDtZyBnmnuCyLXyy;
			}
			internal set
			{
				oObggzFhPIUffDtZyBnmnuCyLXyy = value;
			}
		}

		public int elementMapId
		{
			get
			{
				return NjsrlERmaDZZxQiTMonWeEbdxoY;
			}
			internal set
			{
				NjsrlERmaDZZxQiTMonWeEbdxoY = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return ZcCJfoFOnfaVWPxSGABewnPoqKP;
			}
			internal set
			{
				ZcCJfoFOnfaVWPxSGABewnPoqKP = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return TZSPqisJATrQkFfRXLKedgRIcwv;
			}
			internal set
			{
				TZSPqisJATrQkFfRXLKedgRIcwv = value;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return EZXgGJlJJGLqECQiOgASqMQAZMg;
			}
			internal set
			{
				EZXgGJlJJGLqECQiOgASqMQAZMg = value;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return tmDdGydFlWVbCarXzSZWfplxDpyN;
			}
			internal set
			{
				tmDdGydFlWVbCarXzSZWfplxDpyN = value;
			}
		}

		public int actionId
		{
			get
			{
				return ZUoDkTcclUigIzTjeFLCXFMQOaU;
			}
			internal set
			{
				ZUoDkTcclUigIzTjeFLCXFMQOaU = value;
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
				return ReInput.players.GetPlayer(VUcYiZtcJRatratRXOokIFfcdNSg);
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
				return ReInput.mapping.GetAction(ZUoDkTcclUigIzTjeFLCXFMQOaU);
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
				return ReInput.controllers.GetController(CiEHnIGrjScHYHuMEoDVXvEgwiy, WuIXWewTRtkXNcGHNDHMpyChWRj);
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
				return player.controllers.maps.GetMap(CiEHnIGrjScHYHuMEoDVXvEgwiy, WuIXWewTRtkXNcGHNDHMpyChWRj, oObggzFhPIUffDtZyBnmnuCyLXyy);
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
				return controller.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
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
				return controllerMap.GetElementMap(NjsrlERmaDZZxQiTMonWeEbdxoY);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (CiEHnIGrjScHYHuMEoDVXvEgwiy == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(EZXgGJlJJGLqECQiOgASqMQAZMg, tmDdGydFlWVbCarXzSZWfplxDpyN);
				}
				if (controller == null)
				{
					goto IL_0022;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
				int num;
				if (elementIdentifierById == null)
				{
					num = 67308386;
					goto IL_0027;
				}
				return elementIdentifierById.name;
				IL_0027:
				switch (num ^ 0x4030B62)
				{
				case 2:
					break;
				case 1:
					return string.Empty;
				default:
					return string.Empty;
				}
				goto IL_0022;
				IL_0022:
				num = 67308387;
				goto IL_0027;
			}
		}

		public ElementAssignmentConflictInfo(bool isConflict, bool isUserAssignable, int playerId, ControllerType controllerType, int controllerId, int controllerMapId, int elementMapId, int actionId, ControllerElementType elementType, int elementIdentifierId, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			rBodfkRQNJhByhXbSuClAyLEmCsU = isConflict;
			sfAJboWUMsLmaALRoAKTkymntHz = isUserAssignable;
			VUcYiZtcJRatratRXOokIFfcdNSg = playerId;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = controllerType;
			WuIXWewTRtkXNcGHNDHMpyChWRj = controllerId;
			oObggzFhPIUffDtZyBnmnuCyLXyy = controllerMapId;
			NjsrlERmaDZZxQiTMonWeEbdxoY = elementMapId;
			ZUoDkTcclUigIzTjeFLCXFMQOaU = actionId;
			ZcCJfoFOnfaVWPxSGABewnPoqKP = elementType;
			TZSPqisJATrQkFfRXLKedgRIcwv = elementIdentifierId;
			EZXgGJlJJGLqECQiOgASqMQAZMg = keyCode;
			tmDdGydFlWVbCarXzSZWfplxDpyN = modifierKeyFlags;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo source)
		{
			rBodfkRQNJhByhXbSuClAyLEmCsU = source.rBodfkRQNJhByhXbSuClAyLEmCsU;
			sfAJboWUMsLmaALRoAKTkymntHz = source.sfAJboWUMsLmaALRoAKTkymntHz;
			VUcYiZtcJRatratRXOokIFfcdNSg = source.VUcYiZtcJRatratRXOokIFfcdNSg;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = source.CiEHnIGrjScHYHuMEoDVXvEgwiy;
			WuIXWewTRtkXNcGHNDHMpyChWRj = source.WuIXWewTRtkXNcGHNDHMpyChWRj;
			oObggzFhPIUffDtZyBnmnuCyLXyy = source.oObggzFhPIUffDtZyBnmnuCyLXyy;
			NjsrlERmaDZZxQiTMonWeEbdxoY = source.NjsrlERmaDZZxQiTMonWeEbdxoY;
			ZUoDkTcclUigIzTjeFLCXFMQOaU = source.ZUoDkTcclUigIzTjeFLCXFMQOaU;
			ZcCJfoFOnfaVWPxSGABewnPoqKP = source.ZcCJfoFOnfaVWPxSGABewnPoqKP;
			TZSPqisJATrQkFfRXLKedgRIcwv = source.TZSPqisJATrQkFfRXLKedgRIcwv;
			EZXgGJlJJGLqECQiOgASqMQAZMg = source.EZXgGJlJJGLqECQiOgASqMQAZMg;
			tmDdGydFlWVbCarXzSZWfplxDpyN = source.tmDdGydFlWVbCarXzSZWfplxDpyN;
		}
	}
}
