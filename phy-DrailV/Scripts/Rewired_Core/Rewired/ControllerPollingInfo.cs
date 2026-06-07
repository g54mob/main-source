using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool ztirUueIbrxPkkLPKLOqaeCrCgaI;

		private int lZxGiiRCjWjNVgZWofZDCyZVhNIF;

		private int iaZAeHIptgfYnzhUoKmpmEkRtvpO;

		private string ZONyurIkOTqoVJdxYJweFdAKSWBB;

		private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

		private ControllerElementType jRBPSVtNKcYysODJtvbPjIhQUBZJ;

		private int nAznauVeWTEKclGKxeRUvILhqOtm;

		private Pole WgIvbFHiCVwfopEkzygrsnwWitEB;

		private string vHALIUehnCCpunjAGuuNdgRVqXWg;

		private int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

		private KeyCode ajPzIFdYbFozdQcNDuMcYBFmvdBm;

		public bool success
		{
			get
			{
				return ztirUueIbrxPkkLPKLOqaeCrCgaI;
			}
			internal set
			{
				ztirUueIbrxPkkLPKLOqaeCrCgaI = flag;
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

		public string controllerName
		{
			get
			{
				return ZONyurIkOTqoVJdxYJweFdAKSWBB;
			}
			internal set
			{
				ZONyurIkOTqoVJdxYJweFdAKSWBB = zONyurIkOTqoVJdxYJweFdAKSWBB;
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

		public int elementIndex
		{
			get
			{
				return nAznauVeWTEKclGKxeRUvILhqOtm;
			}
			internal set
			{
				nAznauVeWTEKclGKxeRUvILhqOtm = num;
			}
		}

		public Pole axisPole
		{
			get
			{
				return WgIvbFHiCVwfopEkzygrsnwWitEB;
			}
			internal set
			{
				WgIvbFHiCVwfopEkzygrsnwWitEB = wgIvbFHiCVwfopEkzygrsnwWitEB;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return vHALIUehnCCpunjAGuuNdgRVqXWg;
			}
			internal set
			{
				vHALIUehnCCpunjAGuuNdgRVqXWg = text;
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

		public KeyCode keyboardKey
		{
			get
			{
				return ajPzIFdYbFozdQcNDuMcYBFmvdBm;
			}
			internal set
			{
				ajPzIFdYbFozdQcNDuMcYBFmvdBm = keyCode;
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
				if (!ReInput.LmvhkTCrnWKGfgMggYILVjKvuRWf.PewwNLbwpvegjTYkSPjCBkENpnkB(lZxGiiRCjWjNVgZWofZDCyZVhNIF))
				{
					return null;
				}
				return ReInput.LmvhkTCrnWKGfgMggYILVjKvuRWf.GMfdPhKaTGGvREtYKUxukZZFdgrwA(lZxGiiRCjWjNVgZWofZDCyZVhNIF);
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

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return controller?.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			ztirUueIbrxPkkLPKLOqaeCrCgaI = P_0;
			lZxGiiRCjWjNVgZWofZDCyZVhNIF = P_1;
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_2;
			ZONyurIkOTqoVJdxYJweFdAKSWBB = P_3;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_4;
			jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_5;
			nAznauVeWTEKclGKxeRUvILhqOtm = P_6;
			WgIvbFHiCVwfopEkzygrsnwWitEB = P_7;
			vHALIUehnCCpunjAGuuNdgRVqXWg = P_8;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_9;
			ajPzIFdYbFozdQcNDuMcYBFmvdBm = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			ztirUueIbrxPkkLPKLOqaeCrCgaI = P_0.ztirUueIbrxPkkLPKLOqaeCrCgaI;
			lZxGiiRCjWjNVgZWofZDCyZVhNIF = P_0.lZxGiiRCjWjNVgZWofZDCyZVhNIF;
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_0.iaZAeHIptgfYnzhUoKmpmEkRtvpO;
			ZONyurIkOTqoVJdxYJweFdAKSWBB = P_0.ZONyurIkOTqoVJdxYJweFdAKSWBB;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_0.ueTsfWyPNTdEyAOjfZNcYrBGNSmq;
			jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_0.jRBPSVtNKcYysODJtvbPjIhQUBZJ;
			nAznauVeWTEKclGKxeRUvILhqOtm = P_0.nAznauVeWTEKclGKxeRUvILhqOtm;
			WgIvbFHiCVwfopEkzygrsnwWitEB = P_0.WgIvbFHiCVwfopEkzygrsnwWitEB;
			vHALIUehnCCpunjAGuuNdgRVqXWg = P_0.vHALIUehnCCpunjAGuuNdgRVqXWg;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_0.hkJhlFMpiETPSIkMyOmVuFxkJKlT;
			ajPzIFdYbFozdQcNDuMcYBFmvdBm = P_0.ajPzIFdYbFozdQcNDuMcYBFmvdBm;
		}

		internal static ControllerPollingInfo rVpgmYdiORKOxsMzdJFOFbvjVBGPA()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
