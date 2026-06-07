using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool RqtRZXtohKxXQKBwzxMSnObmywqg;

		private bool SBZfhHauqhWbUkLEJcdirfQJrBhPA;

		private int lZxGiiRCjWjNVgZWofZDCyZVhNIF;

		private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

		private int iaZAeHIptgfYnzhUoKmpmEkRtvpO;

		private int GcwOISTqpNXzNmSWJYbFzBuMHzyr;

		private int dfnIDhEhWSktREJSenVxKfRqPNGkb;

		private ControllerElementType jRBPSVtNKcYysODJtvbPjIhQUBZJ;

		private int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

		private KeyCode cEMwviPpEXMoeVlCpjvfpcneqbmd;

		private ModifierKeyFlags LAWskThCRZDFawlWQqsxyYTLFVmX;

		private int nqrNxyIjKJnAagqUPKmjCYvwkyMr;

		public bool isConflict
		{
			get
			{
				return RqtRZXtohKxXQKBwzxMSnObmywqg;
			}
			internal set
			{
				RqtRZXtohKxXQKBwzxMSnObmywqg = rqtRZXtohKxXQKBwzxMSnObmywqg;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return SBZfhHauqhWbUkLEJcdirfQJrBhPA;
			}
			internal set
			{
				SBZfhHauqhWbUkLEJcdirfQJrBhPA = sBZfhHauqhWbUkLEJcdirfQJrBhPA;
			}
		}

		public int playerId
		{
			get
			{
				return lZxGiiRCjWjNVgZWofZDCyZVhNIF;
			}
			internal set
			{
				lZxGiiRCjWjNVgZWofZDCyZVhNIF = num;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return ueTsfWyPNTdEyAOjfZNcYrBGNSmq;
			}
			internal set
			{
				ueTsfWyPNTdEyAOjfZNcYrBGNSmq = controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				return iaZAeHIptgfYnzhUoKmpmEkRtvpO;
			}
			internal set
			{
				iaZAeHIptgfYnzhUoKmpmEkRtvpO = num;
			}
		}

		public int controllerMapId
		{
			get
			{
				return GcwOISTqpNXzNmSWJYbFzBuMHzyr;
			}
			internal set
			{
				GcwOISTqpNXzNmSWJYbFzBuMHzyr = gcwOISTqpNXzNmSWJYbFzBuMHzyr;
			}
		}

		public int elementMapId
		{
			get
			{
				return dfnIDhEhWSktREJSenVxKfRqPNGkb;
			}
			internal set
			{
				dfnIDhEhWSktREJSenVxKfRqPNGkb = num;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return jRBPSVtNKcYysODJtvbPjIhQUBZJ;
			}
			internal set
			{
				jRBPSVtNKcYysODJtvbPjIhQUBZJ = controllerElementType;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return hkJhlFMpiETPSIkMyOmVuFxkJKlT;
			}
			internal set
			{
				hkJhlFMpiETPSIkMyOmVuFxkJKlT = num;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return cEMwviPpEXMoeVlCpjvfpcneqbmd;
			}
			internal set
			{
				cEMwviPpEXMoeVlCpjvfpcneqbmd = keyCode;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return LAWskThCRZDFawlWQqsxyYTLFVmX;
			}
			internal set
			{
				LAWskThCRZDFawlWQqsxyYTLFVmX = lAWskThCRZDFawlWQqsxyYTLFVmX;
			}
		}

		public int actionId
		{
			get
			{
				return nqrNxyIjKJnAagqUPKmjCYvwkyMr;
			}
			internal set
			{
				nqrNxyIjKJnAagqUPKmjCYvwkyMr = num;
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
				return ReInput.players.GetPlayer(lZxGiiRCjWjNVgZWofZDCyZVhNIF);
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
				return ReInput.mapping.GetAction(nqrNxyIjKJnAagqUPKmjCYvwkyMr);
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
				return ReInput.controllers.GetController(ueTsfWyPNTdEyAOjfZNcYrBGNSmq, iaZAeHIptgfYnzhUoKmpmEkRtvpO);
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
				return player.controllers.maps.GetMap(ueTsfWyPNTdEyAOjfZNcYrBGNSmq, iaZAeHIptgfYnzhUoKmpmEkRtvpO, GcwOISTqpNXzNmSWJYbFzBuMHzyr);
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
				return controller.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
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
				return controllerMap.GetElementMap(dfnIDhEhWSktREJSenVxKfRqPNGkb);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (ueTsfWyPNTdEyAOjfZNcYrBGNSmq == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(cEMwviPpEXMoeVlCpjvfpcneqbmd, LAWskThCRZDFawlWQqsxyYTLFVmX);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.name;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			RqtRZXtohKxXQKBwzxMSnObmywqg = P_0;
			SBZfhHauqhWbUkLEJcdirfQJrBhPA = P_1;
			lZxGiiRCjWjNVgZWofZDCyZVhNIF = P_2;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_3;
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_4;
			GcwOISTqpNXzNmSWJYbFzBuMHzyr = P_5;
			dfnIDhEhWSktREJSenVxKfRqPNGkb = P_6;
			nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_7;
			jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_8;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_9;
			cEMwviPpEXMoeVlCpjvfpcneqbmd = P_10;
			LAWskThCRZDFawlWQqsxyYTLFVmX = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			RqtRZXtohKxXQKBwzxMSnObmywqg = P_0.RqtRZXtohKxXQKBwzxMSnObmywqg;
			SBZfhHauqhWbUkLEJcdirfQJrBhPA = P_0.SBZfhHauqhWbUkLEJcdirfQJrBhPA;
			lZxGiiRCjWjNVgZWofZDCyZVhNIF = P_0.lZxGiiRCjWjNVgZWofZDCyZVhNIF;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_0.ueTsfWyPNTdEyAOjfZNcYrBGNSmq;
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_0.iaZAeHIptgfYnzhUoKmpmEkRtvpO;
			GcwOISTqpNXzNmSWJYbFzBuMHzyr = P_0.GcwOISTqpNXzNmSWJYbFzBuMHzyr;
			dfnIDhEhWSktREJSenVxKfRqPNGkb = P_0.dfnIDhEhWSktREJSenVxKfRqPNGkb;
			nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_0.nqrNxyIjKJnAagqUPKmjCYvwkyMr;
			jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_0.jRBPSVtNKcYysODJtvbPjIhQUBZJ;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_0.hkJhlFMpiETPSIkMyOmVuFxkJKlT;
			cEMwviPpEXMoeVlCpjvfpcneqbmd = P_0.cEMwviPpEXMoeVlCpjvfpcneqbmd;
			LAWskThCRZDFawlWQqsxyYTLFVmX = P_0.LAWskThCRZDFawlWQqsxyYTLFVmX;
		}
	}
}
