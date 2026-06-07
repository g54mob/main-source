using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool eQiIWdrUwYgduTmmPXUllCdaEHmaA;

		private int UqSjyUAvlyDJwxtrjlMcHDuHYCsT;

		private int ugVzYiRaAyGIuNArFyVkhKywXSZC;

		private string uWpxwWSwMlUhTGrDaIrlJtqEExeP;

		private ControllerType LnKNDkHjJLemqusbhODMriNBcZrB;

		private ControllerElementType ictQnIsfBnetTfmpYtXSlGylnXLx;

		private int wQCePYhVjnntMqWNEqfzGEpOlyLCb;

		private Pole zAFnPPHRmXDKeskyfqxkzlUMHHPh;

		private string rGUXcIOfCPAhOgrtjYVSyVusKwNL;

		private int RbxAwhfMmoALhbFyOgryItdPWfsr;

		private KeyCode jiIMNKBHaIdYONyqcBJXngsfJkFT;

		public bool success
		{
			get
			{
				return eQiIWdrUwYgduTmmPXUllCdaEHmaA;
			}
			internal set
			{
				eQiIWdrUwYgduTmmPXUllCdaEHmaA = flag;
			}
		}

		public int playerId
		{
			get
			{
				return UqSjyUAvlyDJwxtrjlMcHDuHYCsT;
			}
			internal set
			{
				UqSjyUAvlyDJwxtrjlMcHDuHYCsT = uqSjyUAvlyDJwxtrjlMcHDuHYCsT;
			}
		}

		public int controllerId
		{
			get
			{
				return ugVzYiRaAyGIuNArFyVkhKywXSZC;
			}
			internal set
			{
				ugVzYiRaAyGIuNArFyVkhKywXSZC = num;
			}
		}

		public string controllerName
		{
			get
			{
				return uWpxwWSwMlUhTGrDaIrlJtqEExeP;
			}
			internal set
			{
				uWpxwWSwMlUhTGrDaIrlJtqEExeP = text;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return LnKNDkHjJLemqusbhODMriNBcZrB;
			}
			internal set
			{
				LnKNDkHjJLemqusbhODMriNBcZrB = lnKNDkHjJLemqusbhODMriNBcZrB;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return ictQnIsfBnetTfmpYtXSlGylnXLx;
			}
			internal set
			{
				ictQnIsfBnetTfmpYtXSlGylnXLx = controllerElementType;
			}
		}

		public int elementIndex
		{
			get
			{
				return wQCePYhVjnntMqWNEqfzGEpOlyLCb;
			}
			internal set
			{
				wQCePYhVjnntMqWNEqfzGEpOlyLCb = num;
			}
		}

		public Pole axisPole
		{
			get
			{
				return zAFnPPHRmXDKeskyfqxkzlUMHHPh;
			}
			internal set
			{
				zAFnPPHRmXDKeskyfqxkzlUMHHPh = pole;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return rGUXcIOfCPAhOgrtjYVSyVusKwNL;
			}
			internal set
			{
				rGUXcIOfCPAhOgrtjYVSyVusKwNL = text;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return RbxAwhfMmoALhbFyOgryItdPWfsr;
			}
			internal set
			{
				RbxAwhfMmoALhbFyOgryItdPWfsr = rbxAwhfMmoALhbFyOgryItdPWfsr;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return jiIMNKBHaIdYONyqcBJXngsfJkFT;
			}
			internal set
			{
				jiIMNKBHaIdYONyqcBJXngsfJkFT = keyCode;
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
				if (!ReInput.VouJZmDPLGSEXPCTzKAxDlURnAgC.CnraUkgOpCTmmmKqDQamvIcHNpOQA(UqSjyUAvlyDJwxtrjlMcHDuHYCsT))
				{
					return null;
				}
				return ReInput.VouJZmDPLGSEXPCTzKAxDlURnAgC.CdVzoIAGjOsZSBsVEHDGWSgvSrMu(UqSjyUAvlyDJwxtrjlMcHDuHYCsT);
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
				return ReInput.controllers.GetController(LnKNDkHjJLemqusbhODMriNBcZrB, ugVzYiRaAyGIuNArFyVkhKywXSZC);
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
				return controller?.GetElementIdentifierById(RbxAwhfMmoALhbFyOgryItdPWfsr);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			eQiIWdrUwYgduTmmPXUllCdaEHmaA = P_0;
			UqSjyUAvlyDJwxtrjlMcHDuHYCsT = P_1;
			ugVzYiRaAyGIuNArFyVkhKywXSZC = P_2;
			uWpxwWSwMlUhTGrDaIrlJtqEExeP = P_3;
			LnKNDkHjJLemqusbhODMriNBcZrB = P_4;
			ictQnIsfBnetTfmpYtXSlGylnXLx = P_5;
			wQCePYhVjnntMqWNEqfzGEpOlyLCb = P_6;
			zAFnPPHRmXDKeskyfqxkzlUMHHPh = P_7;
			rGUXcIOfCPAhOgrtjYVSyVusKwNL = P_8;
			RbxAwhfMmoALhbFyOgryItdPWfsr = P_9;
			jiIMNKBHaIdYONyqcBJXngsfJkFT = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			eQiIWdrUwYgduTmmPXUllCdaEHmaA = P_0.eQiIWdrUwYgduTmmPXUllCdaEHmaA;
			UqSjyUAvlyDJwxtrjlMcHDuHYCsT = P_0.UqSjyUAvlyDJwxtrjlMcHDuHYCsT;
			ugVzYiRaAyGIuNArFyVkhKywXSZC = P_0.ugVzYiRaAyGIuNArFyVkhKywXSZC;
			uWpxwWSwMlUhTGrDaIrlJtqEExeP = P_0.uWpxwWSwMlUhTGrDaIrlJtqEExeP;
			LnKNDkHjJLemqusbhODMriNBcZrB = P_0.LnKNDkHjJLemqusbhODMriNBcZrB;
			ictQnIsfBnetTfmpYtXSlGylnXLx = P_0.ictQnIsfBnetTfmpYtXSlGylnXLx;
			wQCePYhVjnntMqWNEqfzGEpOlyLCb = P_0.wQCePYhVjnntMqWNEqfzGEpOlyLCb;
			zAFnPPHRmXDKeskyfqxkzlUMHHPh = P_0.zAFnPPHRmXDKeskyfqxkzlUMHHPh;
			rGUXcIOfCPAhOgrtjYVSyVusKwNL = P_0.rGUXcIOfCPAhOgrtjYVSyVusKwNL;
			RbxAwhfMmoALhbFyOgryItdPWfsr = P_0.RbxAwhfMmoALhbFyOgryItdPWfsr;
			jiIMNKBHaIdYONyqcBJXngsfJkFT = P_0.jiIMNKBHaIdYONyqcBJXngsfJkFT;
		}

		internal static ControllerPollingInfo VkUbZNQaTzvokZghSHJBDxjCgBnd()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
