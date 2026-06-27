using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool CKLVlBiOXMmOmFKFWnJFLhOAbhkJ;

		private bool QvDiuUUiGczmOsJqSszZibQHBHbgA;

		private int iycTgghLqHCmPhtORbkKceLCtaoZA;

		private ControllerType RQGTeodUMQmVAduYbvOIPxjwGkcc;

		private int GaNaVNLMJyLSrjncLIsSiutlPkgzA;

		private int fShGIVgBhMyJwbIgqLwLncEOibAdA;

		private int godJlRMgFeiAMOQAAPmOMjkPhNpI;

		private ControllerElementType lybNgiXZoElvpUqdQRnrUYbJeyGg;

		private int aQfeQymPaOiADLOODUWWiZmRMvln;

		private KeyCode pIwBDxEMqsCZVMzvNdsCIjBxWvXfA;

		private ModifierKeyFlags dAeFMCmSBDTrisbdnstutERTZVoA;

		private int lrpLYfKAagvUeBJFPDjCifDxsxoUA;

		public bool isConflict
		{
			get
			{
				return CKLVlBiOXMmOmFKFWnJFLhOAbhkJ;
			}
			internal set
			{
				CKLVlBiOXMmOmFKFWnJFLhOAbhkJ = cKLVlBiOXMmOmFKFWnJFLhOAbhkJ;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return QvDiuUUiGczmOsJqSszZibQHBHbgA;
			}
			internal set
			{
				QvDiuUUiGczmOsJqSszZibQHBHbgA = qvDiuUUiGczmOsJqSszZibQHBHbgA;
			}
		}

		public int playerId
		{
			get
			{
				return iycTgghLqHCmPhtORbkKceLCtaoZA;
			}
			internal set
			{
				iycTgghLqHCmPhtORbkKceLCtaoZA = num;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return RQGTeodUMQmVAduYbvOIPxjwGkcc;
			}
			internal set
			{
				RQGTeodUMQmVAduYbvOIPxjwGkcc = rQGTeodUMQmVAduYbvOIPxjwGkcc;
			}
		}

		public int controllerId
		{
			get
			{
				return GaNaVNLMJyLSrjncLIsSiutlPkgzA;
			}
			internal set
			{
				GaNaVNLMJyLSrjncLIsSiutlPkgzA = gaNaVNLMJyLSrjncLIsSiutlPkgzA;
			}
		}

		public int controllerMapId
		{
			get
			{
				return fShGIVgBhMyJwbIgqLwLncEOibAdA;
			}
			internal set
			{
				fShGIVgBhMyJwbIgqLwLncEOibAdA = num;
			}
		}

		public int elementMapId
		{
			get
			{
				return godJlRMgFeiAMOQAAPmOMjkPhNpI;
			}
			internal set
			{
				godJlRMgFeiAMOQAAPmOMjkPhNpI = num;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return lybNgiXZoElvpUqdQRnrUYbJeyGg;
			}
			internal set
			{
				lybNgiXZoElvpUqdQRnrUYbJeyGg = controllerElementType;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return aQfeQymPaOiADLOODUWWiZmRMvln;
			}
			internal set
			{
				aQfeQymPaOiADLOODUWWiZmRMvln = num;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return pIwBDxEMqsCZVMzvNdsCIjBxWvXfA;
			}
			internal set
			{
				pIwBDxEMqsCZVMzvNdsCIjBxWvXfA = keyCode;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return dAeFMCmSBDTrisbdnstutERTZVoA;
			}
			internal set
			{
				dAeFMCmSBDTrisbdnstutERTZVoA = modifierKeyFlags;
			}
		}

		public int actionId
		{
			get
			{
				return lrpLYfKAagvUeBJFPDjCifDxsxoUA;
			}
			internal set
			{
				lrpLYfKAagvUeBJFPDjCifDxsxoUA = num;
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
				return ReInput.players.GetPlayer(iycTgghLqHCmPhtORbkKceLCtaoZA);
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
				return ReInput.mapping.GetAction(lrpLYfKAagvUeBJFPDjCifDxsxoUA);
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
				return ReInput.controllers.GetController(RQGTeodUMQmVAduYbvOIPxjwGkcc, GaNaVNLMJyLSrjncLIsSiutlPkgzA);
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
				return player.controllers.maps.GetMap(RQGTeodUMQmVAduYbvOIPxjwGkcc, GaNaVNLMJyLSrjncLIsSiutlPkgzA, fShGIVgBhMyJwbIgqLwLncEOibAdA);
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
				return controller.GetElementIdentifierById(aQfeQymPaOiADLOODUWWiZmRMvln);
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
				return controllerMap.GetElementMap(godJlRMgFeiAMOQAAPmOMjkPhNpI);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (RQGTeodUMQmVAduYbvOIPxjwGkcc == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(pIwBDxEMqsCZVMzvNdsCIjBxWvXfA, dAeFMCmSBDTrisbdnstutERTZVoA);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(aQfeQymPaOiADLOODUWWiZmRMvln);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			CKLVlBiOXMmOmFKFWnJFLhOAbhkJ = P_0;
			QvDiuUUiGczmOsJqSszZibQHBHbgA = P_1;
			iycTgghLqHCmPhtORbkKceLCtaoZA = P_2;
			RQGTeodUMQmVAduYbvOIPxjwGkcc = P_3;
			GaNaVNLMJyLSrjncLIsSiutlPkgzA = P_4;
			fShGIVgBhMyJwbIgqLwLncEOibAdA = P_5;
			godJlRMgFeiAMOQAAPmOMjkPhNpI = P_6;
			lrpLYfKAagvUeBJFPDjCifDxsxoUA = P_7;
			lybNgiXZoElvpUqdQRnrUYbJeyGg = P_8;
			aQfeQymPaOiADLOODUWWiZmRMvln = P_9;
			pIwBDxEMqsCZVMzvNdsCIjBxWvXfA = P_10;
			dAeFMCmSBDTrisbdnstutERTZVoA = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			CKLVlBiOXMmOmFKFWnJFLhOAbhkJ = P_0.CKLVlBiOXMmOmFKFWnJFLhOAbhkJ;
			QvDiuUUiGczmOsJqSszZibQHBHbgA = P_0.QvDiuUUiGczmOsJqSszZibQHBHbgA;
			iycTgghLqHCmPhtORbkKceLCtaoZA = P_0.iycTgghLqHCmPhtORbkKceLCtaoZA;
			RQGTeodUMQmVAduYbvOIPxjwGkcc = P_0.RQGTeodUMQmVAduYbvOIPxjwGkcc;
			GaNaVNLMJyLSrjncLIsSiutlPkgzA = P_0.GaNaVNLMJyLSrjncLIsSiutlPkgzA;
			fShGIVgBhMyJwbIgqLwLncEOibAdA = P_0.fShGIVgBhMyJwbIgqLwLncEOibAdA;
			godJlRMgFeiAMOQAAPmOMjkPhNpI = P_0.godJlRMgFeiAMOQAAPmOMjkPhNpI;
			lrpLYfKAagvUeBJFPDjCifDxsxoUA = P_0.lrpLYfKAagvUeBJFPDjCifDxsxoUA;
			lybNgiXZoElvpUqdQRnrUYbJeyGg = P_0.lybNgiXZoElvpUqdQRnrUYbJeyGg;
			aQfeQymPaOiADLOODUWWiZmRMvln = P_0.aQfeQymPaOiADLOODUWWiZmRMvln;
			pIwBDxEMqsCZVMzvNdsCIjBxWvXfA = P_0.pIwBDxEMqsCZVMzvNdsCIjBxWvXfA;
			dAeFMCmSBDTrisbdnstutERTZVoA = P_0.dAeFMCmSBDTrisbdnstutERTZVoA;
		}
	}
}
