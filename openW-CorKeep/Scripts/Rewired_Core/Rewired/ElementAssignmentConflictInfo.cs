using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool HRiaZFdRsGoEdBSzyIDujWHAcSDZ;

		private bool PPcqqCdIfgQHPxvAuJlmSDTFdiKN;

		private int pIJAeaYrNPFGGjwejRSzDKWOjFXJA;

		private ControllerType UTpqVgKTpIrSCulCTFFfaveolvXbb;

		private int DnmUFFyfyeXamyXOlvYrKeatIJTeA;

		private int cnAUKNRKTIfXpmEPYSusZFGQIbpF;

		private int lrMGVDvmiklGXVVguMbxoRlRfYMr;

		private ControllerElementType ceKgPskmTOCDayXFmcdSEaeGXDpob;

		private int xnUWZcHNyAaGIIuaxwpzWbgBEwWe;

		private KeyCode ieDNqvpKVcjMYgxPdAGjTXMrEMmF;

		private ModifierKeyFlags ozvLHIdilBGraexBZzYWiXDFTwkUA;

		private int eMEGvNpRcaqhOGpwvZvQZWidSPAc;

		public bool isConflict
		{
			get
			{
				return HRiaZFdRsGoEdBSzyIDujWHAcSDZ;
			}
			internal set
			{
				HRiaZFdRsGoEdBSzyIDujWHAcSDZ = hRiaZFdRsGoEdBSzyIDujWHAcSDZ;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return PPcqqCdIfgQHPxvAuJlmSDTFdiKN;
			}
			internal set
			{
				PPcqqCdIfgQHPxvAuJlmSDTFdiKN = pPcqqCdIfgQHPxvAuJlmSDTFdiKN;
			}
		}

		public int playerId
		{
			get
			{
				return pIJAeaYrNPFGGjwejRSzDKWOjFXJA;
			}
			internal set
			{
				pIJAeaYrNPFGGjwejRSzDKWOjFXJA = num;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return UTpqVgKTpIrSCulCTFFfaveolvXbb;
			}
			internal set
			{
				UTpqVgKTpIrSCulCTFFfaveolvXbb = uTpqVgKTpIrSCulCTFFfaveolvXbb;
			}
		}

		public int controllerId
		{
			get
			{
				return DnmUFFyfyeXamyXOlvYrKeatIJTeA;
			}
			internal set
			{
				DnmUFFyfyeXamyXOlvYrKeatIJTeA = dnmUFFyfyeXamyXOlvYrKeatIJTeA;
			}
		}

		public int controllerMapId
		{
			get
			{
				return cnAUKNRKTIfXpmEPYSusZFGQIbpF;
			}
			internal set
			{
				cnAUKNRKTIfXpmEPYSusZFGQIbpF = num;
			}
		}

		public int elementMapId
		{
			get
			{
				return lrMGVDvmiklGXVVguMbxoRlRfYMr;
			}
			internal set
			{
				lrMGVDvmiklGXVVguMbxoRlRfYMr = num;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return ceKgPskmTOCDayXFmcdSEaeGXDpob;
			}
			internal set
			{
				ceKgPskmTOCDayXFmcdSEaeGXDpob = controllerElementType;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return xnUWZcHNyAaGIIuaxwpzWbgBEwWe;
			}
			internal set
			{
				xnUWZcHNyAaGIIuaxwpzWbgBEwWe = num;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return ieDNqvpKVcjMYgxPdAGjTXMrEMmF;
			}
			internal set
			{
				ieDNqvpKVcjMYgxPdAGjTXMrEMmF = keyCode;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return ozvLHIdilBGraexBZzYWiXDFTwkUA;
			}
			internal set
			{
				ozvLHIdilBGraexBZzYWiXDFTwkUA = modifierKeyFlags;
			}
		}

		public int actionId
		{
			get
			{
				return eMEGvNpRcaqhOGpwvZvQZWidSPAc;
			}
			internal set
			{
				eMEGvNpRcaqhOGpwvZvQZWidSPAc = num;
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
				return ReInput.players.GetPlayer(pIJAeaYrNPFGGjwejRSzDKWOjFXJA);
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
				return ReInput.mapping.GetAction(eMEGvNpRcaqhOGpwvZvQZWidSPAc);
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
				return ReInput.controllers.GetController(UTpqVgKTpIrSCulCTFFfaveolvXbb, DnmUFFyfyeXamyXOlvYrKeatIJTeA);
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
				return player.controllers.maps.GetMap(UTpqVgKTpIrSCulCTFFfaveolvXbb, DnmUFFyfyeXamyXOlvYrKeatIJTeA, cnAUKNRKTIfXpmEPYSusZFGQIbpF);
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
				return controller.GetElementIdentifierById(xnUWZcHNyAaGIIuaxwpzWbgBEwWe);
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
				return controllerMap.GetElementMap(lrMGVDvmiklGXVVguMbxoRlRfYMr);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (UTpqVgKTpIrSCulCTFFfaveolvXbb == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(ieDNqvpKVcjMYgxPdAGjTXMrEMmF, ozvLHIdilBGraexBZzYWiXDFTwkUA);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(xnUWZcHNyAaGIIuaxwpzWbgBEwWe);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			HRiaZFdRsGoEdBSzyIDujWHAcSDZ = P_0;
			PPcqqCdIfgQHPxvAuJlmSDTFdiKN = P_1;
			pIJAeaYrNPFGGjwejRSzDKWOjFXJA = P_2;
			UTpqVgKTpIrSCulCTFFfaveolvXbb = P_3;
			DnmUFFyfyeXamyXOlvYrKeatIJTeA = P_4;
			cnAUKNRKTIfXpmEPYSusZFGQIbpF = P_5;
			lrMGVDvmiklGXVVguMbxoRlRfYMr = P_6;
			eMEGvNpRcaqhOGpwvZvQZWidSPAc = P_7;
			ceKgPskmTOCDayXFmcdSEaeGXDpob = P_8;
			xnUWZcHNyAaGIIuaxwpzWbgBEwWe = P_9;
			ieDNqvpKVcjMYgxPdAGjTXMrEMmF = P_10;
			ozvLHIdilBGraexBZzYWiXDFTwkUA = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			HRiaZFdRsGoEdBSzyIDujWHAcSDZ = P_0.HRiaZFdRsGoEdBSzyIDujWHAcSDZ;
			PPcqqCdIfgQHPxvAuJlmSDTFdiKN = P_0.PPcqqCdIfgQHPxvAuJlmSDTFdiKN;
			pIJAeaYrNPFGGjwejRSzDKWOjFXJA = P_0.pIJAeaYrNPFGGjwejRSzDKWOjFXJA;
			UTpqVgKTpIrSCulCTFFfaveolvXbb = P_0.UTpqVgKTpIrSCulCTFFfaveolvXbb;
			DnmUFFyfyeXamyXOlvYrKeatIJTeA = P_0.DnmUFFyfyeXamyXOlvYrKeatIJTeA;
			cnAUKNRKTIfXpmEPYSusZFGQIbpF = P_0.cnAUKNRKTIfXpmEPYSusZFGQIbpF;
			lrMGVDvmiklGXVVguMbxoRlRfYMr = P_0.lrMGVDvmiklGXVVguMbxoRlRfYMr;
			eMEGvNpRcaqhOGpwvZvQZWidSPAc = P_0.eMEGvNpRcaqhOGpwvZvQZWidSPAc;
			ceKgPskmTOCDayXFmcdSEaeGXDpob = P_0.ceKgPskmTOCDayXFmcdSEaeGXDpob;
			xnUWZcHNyAaGIIuaxwpzWbgBEwWe = P_0.xnUWZcHNyAaGIIuaxwpzWbgBEwWe;
			ieDNqvpKVcjMYgxPdAGjTXMrEMmF = P_0.ieDNqvpKVcjMYgxPdAGjTXMrEMmF;
			ozvLHIdilBGraexBZzYWiXDFTwkUA = P_0.ozvLHIdilBGraexBZzYWiXDFTwkUA;
		}
	}
}
