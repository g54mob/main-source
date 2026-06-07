using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool BodYsgoFZNuUiNqOWpndBaodRPiK;

		private bool RsnZfvUNShIkWgvfMvfbiWokivrS;

		private int rzIohJxneCfqDzsLPsmuuQfbiUwq;

		private ControllerType MQoCMJvASJwWFnjjbexuXFNZumux;

		private int FTfAEoBJFnMudljlTadmmbFGOAqi;

		private int kqFbDwcmjVTHyNzlyvozotwnvHYLA;

		private int bKJUqoUVBfkgMAIRQVWiABOyRVtk;

		private ControllerElementType iBJOXZVkzLnEjGaQQLCRIeZoIHYj;

		private int lxVeZVhkqVhMHcRRdFCwjiQiiDItE;

		private KeyCode sEAjMUINabOFFptoLeasjOlKtPHU;

		private ModifierKeyFlags wgmdUpIpGSDTxkkcfeqLcjaamlTpA;

		private int aWFwXMCmynmWuNuCRTrwzmrYcVuN;

		public bool isConflict
		{
			get
			{
				return BodYsgoFZNuUiNqOWpndBaodRPiK;
			}
			internal set
			{
				BodYsgoFZNuUiNqOWpndBaodRPiK = bodYsgoFZNuUiNqOWpndBaodRPiK;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return RsnZfvUNShIkWgvfMvfbiWokivrS;
			}
			internal set
			{
				RsnZfvUNShIkWgvfMvfbiWokivrS = rsnZfvUNShIkWgvfMvfbiWokivrS;
			}
		}

		public int playerId
		{
			get
			{
				return rzIohJxneCfqDzsLPsmuuQfbiUwq;
			}
			internal set
			{
				rzIohJxneCfqDzsLPsmuuQfbiUwq = num;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return MQoCMJvASJwWFnjjbexuXFNZumux;
			}
			internal set
			{
				MQoCMJvASJwWFnjjbexuXFNZumux = mQoCMJvASJwWFnjjbexuXFNZumux;
			}
		}

		public int controllerId
		{
			get
			{
				return FTfAEoBJFnMudljlTadmmbFGOAqi;
			}
			internal set
			{
				FTfAEoBJFnMudljlTadmmbFGOAqi = fTfAEoBJFnMudljlTadmmbFGOAqi;
			}
		}

		public int controllerMapId
		{
			get
			{
				return kqFbDwcmjVTHyNzlyvozotwnvHYLA;
			}
			internal set
			{
				kqFbDwcmjVTHyNzlyvozotwnvHYLA = num;
			}
		}

		public int elementMapId
		{
			get
			{
				return bKJUqoUVBfkgMAIRQVWiABOyRVtk;
			}
			internal set
			{
				bKJUqoUVBfkgMAIRQVWiABOyRVtk = num;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return iBJOXZVkzLnEjGaQQLCRIeZoIHYj;
			}
			internal set
			{
				iBJOXZVkzLnEjGaQQLCRIeZoIHYj = controllerElementType;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return lxVeZVhkqVhMHcRRdFCwjiQiiDItE;
			}
			internal set
			{
				lxVeZVhkqVhMHcRRdFCwjiQiiDItE = num;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return sEAjMUINabOFFptoLeasjOlKtPHU;
			}
			internal set
			{
				sEAjMUINabOFFptoLeasjOlKtPHU = keyCode;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return wgmdUpIpGSDTxkkcfeqLcjaamlTpA;
			}
			internal set
			{
				wgmdUpIpGSDTxkkcfeqLcjaamlTpA = modifierKeyFlags;
			}
		}

		public int actionId
		{
			get
			{
				return aWFwXMCmynmWuNuCRTrwzmrYcVuN;
			}
			internal set
			{
				aWFwXMCmynmWuNuCRTrwzmrYcVuN = num;
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
				return ReInput.players.GetPlayer(rzIohJxneCfqDzsLPsmuuQfbiUwq);
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
				return ReInput.mapping.GetAction(aWFwXMCmynmWuNuCRTrwzmrYcVuN);
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
				return ReInput.controllers.GetController(MQoCMJvASJwWFnjjbexuXFNZumux, FTfAEoBJFnMudljlTadmmbFGOAqi);
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
				return player.controllers.maps.GetMap(MQoCMJvASJwWFnjjbexuXFNZumux, FTfAEoBJFnMudljlTadmmbFGOAqi, kqFbDwcmjVTHyNzlyvozotwnvHYLA);
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
				return controller.GetElementIdentifierById(lxVeZVhkqVhMHcRRdFCwjiQiiDItE);
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
				return controllerMap.GetElementMap(bKJUqoUVBfkgMAIRQVWiABOyRVtk);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (MQoCMJvASJwWFnjjbexuXFNZumux == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(sEAjMUINabOFFptoLeasjOlKtPHU, wgmdUpIpGSDTxkkcfeqLcjaamlTpA);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(lxVeZVhkqVhMHcRRdFCwjiQiiDItE);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			BodYsgoFZNuUiNqOWpndBaodRPiK = P_0;
			RsnZfvUNShIkWgvfMvfbiWokivrS = P_1;
			rzIohJxneCfqDzsLPsmuuQfbiUwq = P_2;
			MQoCMJvASJwWFnjjbexuXFNZumux = P_3;
			FTfAEoBJFnMudljlTadmmbFGOAqi = P_4;
			kqFbDwcmjVTHyNzlyvozotwnvHYLA = P_5;
			bKJUqoUVBfkgMAIRQVWiABOyRVtk = P_6;
			aWFwXMCmynmWuNuCRTrwzmrYcVuN = P_7;
			iBJOXZVkzLnEjGaQQLCRIeZoIHYj = P_8;
			lxVeZVhkqVhMHcRRdFCwjiQiiDItE = P_9;
			sEAjMUINabOFFptoLeasjOlKtPHU = P_10;
			wgmdUpIpGSDTxkkcfeqLcjaamlTpA = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			BodYsgoFZNuUiNqOWpndBaodRPiK = P_0.BodYsgoFZNuUiNqOWpndBaodRPiK;
			RsnZfvUNShIkWgvfMvfbiWokivrS = P_0.RsnZfvUNShIkWgvfMvfbiWokivrS;
			rzIohJxneCfqDzsLPsmuuQfbiUwq = P_0.rzIohJxneCfqDzsLPsmuuQfbiUwq;
			MQoCMJvASJwWFnjjbexuXFNZumux = P_0.MQoCMJvASJwWFnjjbexuXFNZumux;
			FTfAEoBJFnMudljlTadmmbFGOAqi = P_0.FTfAEoBJFnMudljlTadmmbFGOAqi;
			kqFbDwcmjVTHyNzlyvozotwnvHYLA = P_0.kqFbDwcmjVTHyNzlyvozotwnvHYLA;
			bKJUqoUVBfkgMAIRQVWiABOyRVtk = P_0.bKJUqoUVBfkgMAIRQVWiABOyRVtk;
			aWFwXMCmynmWuNuCRTrwzmrYcVuN = P_0.aWFwXMCmynmWuNuCRTrwzmrYcVuN;
			iBJOXZVkzLnEjGaQQLCRIeZoIHYj = P_0.iBJOXZVkzLnEjGaQQLCRIeZoIHYj;
			lxVeZVhkqVhMHcRRdFCwjiQiiDItE = P_0.lxVeZVhkqVhMHcRRdFCwjiQiiDItE;
			sEAjMUINabOFFptoLeasjOlKtPHU = P_0.sEAjMUINabOFFptoLeasjOlKtPHU;
			wgmdUpIpGSDTxkkcfeqLcjaamlTpA = P_0.wgmdUpIpGSDTxkkcfeqLcjaamlTpA;
		}
	}
}
