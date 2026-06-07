using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool RKkBVkhVYptJhRXVsTGatqAkmfAM;

		private bool VVmnwrJWPLjTXwOgqAOsOAWrYZBO;

		private int hwNDeLDavsNFQprAdCFhIADkZoOiA;

		private ControllerType WTpTNNeNTvNMQpmdHWjdrxcUUCOG;

		private int TZcBZiOlQJbMwzxazXxfAKpJudIk;

		private int kTULSkhroxJypxdmWgZwfZCoElwgA;

		private int tDCNcXHEkDDLxCSWeofzcwRxbZCc;

		private ControllerElementType uyKXOJWzptUfuMkbcuNOuzwbmAug;

		private int lAGqOPbdfzZrWVsGblbnUZezrfZv;

		private KeyCode klLzNSRPdFaqWelxbmPhqVVHwlxY;

		private ModifierKeyFlags eabLkxFiFweLqcNrBLJMFuGlLell;

		private int kZKhOYTetPznfLhPfoCbBQVJepMFA;

		public bool isConflict
		{
			get
			{
				return RKkBVkhVYptJhRXVsTGatqAkmfAM;
			}
			internal set
			{
				RKkBVkhVYptJhRXVsTGatqAkmfAM = rKkBVkhVYptJhRXVsTGatqAkmfAM;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return VVmnwrJWPLjTXwOgqAOsOAWrYZBO;
			}
			internal set
			{
				VVmnwrJWPLjTXwOgqAOsOAWrYZBO = vVmnwrJWPLjTXwOgqAOsOAWrYZBO;
			}
		}

		public int playerId
		{
			get
			{
				return hwNDeLDavsNFQprAdCFhIADkZoOiA;
			}
			internal set
			{
				hwNDeLDavsNFQprAdCFhIADkZoOiA = num;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return WTpTNNeNTvNMQpmdHWjdrxcUUCOG;
			}
			internal set
			{
				WTpTNNeNTvNMQpmdHWjdrxcUUCOG = wTpTNNeNTvNMQpmdHWjdrxcUUCOG;
			}
		}

		public int controllerId
		{
			get
			{
				return TZcBZiOlQJbMwzxazXxfAKpJudIk;
			}
			internal set
			{
				TZcBZiOlQJbMwzxazXxfAKpJudIk = tZcBZiOlQJbMwzxazXxfAKpJudIk;
			}
		}

		public int controllerMapId
		{
			get
			{
				return kTULSkhroxJypxdmWgZwfZCoElwgA;
			}
			internal set
			{
				kTULSkhroxJypxdmWgZwfZCoElwgA = num;
			}
		}

		public int elementMapId
		{
			get
			{
				return tDCNcXHEkDDLxCSWeofzcwRxbZCc;
			}
			internal set
			{
				tDCNcXHEkDDLxCSWeofzcwRxbZCc = num;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return uyKXOJWzptUfuMkbcuNOuzwbmAug;
			}
			internal set
			{
				uyKXOJWzptUfuMkbcuNOuzwbmAug = controllerElementType;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return lAGqOPbdfzZrWVsGblbnUZezrfZv;
			}
			internal set
			{
				lAGqOPbdfzZrWVsGblbnUZezrfZv = num;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return klLzNSRPdFaqWelxbmPhqVVHwlxY;
			}
			internal set
			{
				klLzNSRPdFaqWelxbmPhqVVHwlxY = keyCode;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return eabLkxFiFweLqcNrBLJMFuGlLell;
			}
			internal set
			{
				eabLkxFiFweLqcNrBLJMFuGlLell = modifierKeyFlags;
			}
		}

		public int actionId
		{
			get
			{
				return kZKhOYTetPznfLhPfoCbBQVJepMFA;
			}
			internal set
			{
				kZKhOYTetPznfLhPfoCbBQVJepMFA = num;
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
				return ReInput.players.GetPlayer(hwNDeLDavsNFQprAdCFhIADkZoOiA);
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
				return ReInput.mapping.GetAction(kZKhOYTetPznfLhPfoCbBQVJepMFA);
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
				return ReInput.controllers.GetController(WTpTNNeNTvNMQpmdHWjdrxcUUCOG, TZcBZiOlQJbMwzxazXxfAKpJudIk);
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
				return player.controllers.maps.GetMap(WTpTNNeNTvNMQpmdHWjdrxcUUCOG, TZcBZiOlQJbMwzxazXxfAKpJudIk, kTULSkhroxJypxdmWgZwfZCoElwgA);
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
				return controller.GetElementIdentifierById(lAGqOPbdfzZrWVsGblbnUZezrfZv);
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
				return controllerMap.GetElementMap(tDCNcXHEkDDLxCSWeofzcwRxbZCc);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (WTpTNNeNTvNMQpmdHWjdrxcUUCOG == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(klLzNSRPdFaqWelxbmPhqVVHwlxY, eabLkxFiFweLqcNrBLJMFuGlLell);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(lAGqOPbdfzZrWVsGblbnUZezrfZv);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			RKkBVkhVYptJhRXVsTGatqAkmfAM = P_0;
			VVmnwrJWPLjTXwOgqAOsOAWrYZBO = P_1;
			hwNDeLDavsNFQprAdCFhIADkZoOiA = P_2;
			WTpTNNeNTvNMQpmdHWjdrxcUUCOG = P_3;
			TZcBZiOlQJbMwzxazXxfAKpJudIk = P_4;
			kTULSkhroxJypxdmWgZwfZCoElwgA = P_5;
			tDCNcXHEkDDLxCSWeofzcwRxbZCc = P_6;
			kZKhOYTetPznfLhPfoCbBQVJepMFA = P_7;
			uyKXOJWzptUfuMkbcuNOuzwbmAug = P_8;
			lAGqOPbdfzZrWVsGblbnUZezrfZv = P_9;
			klLzNSRPdFaqWelxbmPhqVVHwlxY = P_10;
			eabLkxFiFweLqcNrBLJMFuGlLell = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			RKkBVkhVYptJhRXVsTGatqAkmfAM = P_0.RKkBVkhVYptJhRXVsTGatqAkmfAM;
			VVmnwrJWPLjTXwOgqAOsOAWrYZBO = P_0.VVmnwrJWPLjTXwOgqAOsOAWrYZBO;
			hwNDeLDavsNFQprAdCFhIADkZoOiA = P_0.hwNDeLDavsNFQprAdCFhIADkZoOiA;
			WTpTNNeNTvNMQpmdHWjdrxcUUCOG = P_0.WTpTNNeNTvNMQpmdHWjdrxcUUCOG;
			TZcBZiOlQJbMwzxazXxfAKpJudIk = P_0.TZcBZiOlQJbMwzxazXxfAKpJudIk;
			kTULSkhroxJypxdmWgZwfZCoElwgA = P_0.kTULSkhroxJypxdmWgZwfZCoElwgA;
			tDCNcXHEkDDLxCSWeofzcwRxbZCc = P_0.tDCNcXHEkDDLxCSWeofzcwRxbZCc;
			kZKhOYTetPznfLhPfoCbBQVJepMFA = P_0.kZKhOYTetPznfLhPfoCbBQVJepMFA;
			uyKXOJWzptUfuMkbcuNOuzwbmAug = P_0.uyKXOJWzptUfuMkbcuNOuzwbmAug;
			lAGqOPbdfzZrWVsGblbnUZezrfZv = P_0.lAGqOPbdfzZrWVsGblbnUZezrfZv;
			klLzNSRPdFaqWelxbmPhqVVHwlxY = P_0.klLzNSRPdFaqWelxbmPhqVVHwlxY;
			eabLkxFiFweLqcNrBLJMFuGlLell = P_0.eabLkxFiFweLqcNrBLJMFuGlLell;
		}
	}
}
