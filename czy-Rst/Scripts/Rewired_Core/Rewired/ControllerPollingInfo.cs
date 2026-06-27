using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool tHTNEKuavfzEfDkmtWdEXClKYTYR;

		private int NHdOorDkuRBkxnVjZjzDitidnKOnA;

		private int hnkdJTMpcRpkbFIMzRTFDQBKVHze;

		private string reYcmhBBJWVMIGUNUHEUprgsBbOIb;

		private ControllerType WKvPlcQbuyXPpgnqJvzaZvgpwTtf;

		private ControllerElementType hkOeftbmOMqAKuwzihoruwmPVRjl;

		private int xqvzRdKGeAsYFGSHoBQOozrkMuxo;

		private Pole gVodrwKqnywspeXgJuRNVfjaINjgA;

		private string ahhAclcXPqoIDTkxZCyjvQqOoOrgA;

		private int OlIOJUyazXtJmtzcmCvButUjxGIh;

		private KeyCode mAzGafIezvghBFemCzckPQyFqazm;

		public bool success
		{
			get
			{
				return tHTNEKuavfzEfDkmtWdEXClKYTYR;
			}
			internal set
			{
				tHTNEKuavfzEfDkmtWdEXClKYTYR = flag;
			}
		}

		public int playerId
		{
			get
			{
				return NHdOorDkuRBkxnVjZjzDitidnKOnA;
			}
			internal set
			{
				NHdOorDkuRBkxnVjZjzDitidnKOnA = nHdOorDkuRBkxnVjZjzDitidnKOnA;
			}
		}

		public int controllerId
		{
			get
			{
				return hnkdJTMpcRpkbFIMzRTFDQBKVHze;
			}
			internal set
			{
				hnkdJTMpcRpkbFIMzRTFDQBKVHze = num;
			}
		}

		public string controllerName
		{
			get
			{
				return reYcmhBBJWVMIGUNUHEUprgsBbOIb;
			}
			internal set
			{
				reYcmhBBJWVMIGUNUHEUprgsBbOIb = text;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return WKvPlcQbuyXPpgnqJvzaZvgpwTtf;
			}
			internal set
			{
				WKvPlcQbuyXPpgnqJvzaZvgpwTtf = wKvPlcQbuyXPpgnqJvzaZvgpwTtf;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return hkOeftbmOMqAKuwzihoruwmPVRjl;
			}
			internal set
			{
				hkOeftbmOMqAKuwzihoruwmPVRjl = controllerElementType;
			}
		}

		public int elementIndex
		{
			get
			{
				return xqvzRdKGeAsYFGSHoBQOozrkMuxo;
			}
			internal set
			{
				xqvzRdKGeAsYFGSHoBQOozrkMuxo = num;
			}
		}

		public Pole axisPole
		{
			get
			{
				return gVodrwKqnywspeXgJuRNVfjaINjgA;
			}
			internal set
			{
				gVodrwKqnywspeXgJuRNVfjaINjgA = pole;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return ahhAclcXPqoIDTkxZCyjvQqOoOrgA;
			}
			internal set
			{
				ahhAclcXPqoIDTkxZCyjvQqOoOrgA = text;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return OlIOJUyazXtJmtzcmCvButUjxGIh;
			}
			internal set
			{
				OlIOJUyazXtJmtzcmCvButUjxGIh = olIOJUyazXtJmtzcmCvButUjxGIh;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return mAzGafIezvghBFemCzckPQyFqazm;
			}
			internal set
			{
				mAzGafIezvghBFemCzckPQyFqazm = keyCode;
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
				if (!ReInput.ABDTVoIIjFlEZLKHRhISrlbClCcb.BgKyOLXYenjPzKFwpJJDovuhtjeN(NHdOorDkuRBkxnVjZjzDitidnKOnA))
				{
					return null;
				}
				return ReInput.ABDTVoIIjFlEZLKHRhISrlbClCcb.RmeButhFmdxsBQPRyEgbZicZgdaPA(NHdOorDkuRBkxnVjZjzDitidnKOnA);
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
				return ReInput.controllers.GetController(WKvPlcQbuyXPpgnqJvzaZvgpwTtf, hnkdJTMpcRpkbFIMzRTFDQBKVHze);
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
				return controller?.GetElementIdentifierById(OlIOJUyazXtJmtzcmCvButUjxGIh);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			tHTNEKuavfzEfDkmtWdEXClKYTYR = P_0;
			NHdOorDkuRBkxnVjZjzDitidnKOnA = P_1;
			hnkdJTMpcRpkbFIMzRTFDQBKVHze = P_2;
			reYcmhBBJWVMIGUNUHEUprgsBbOIb = P_3;
			WKvPlcQbuyXPpgnqJvzaZvgpwTtf = P_4;
			hkOeftbmOMqAKuwzihoruwmPVRjl = P_5;
			xqvzRdKGeAsYFGSHoBQOozrkMuxo = P_6;
			gVodrwKqnywspeXgJuRNVfjaINjgA = P_7;
			ahhAclcXPqoIDTkxZCyjvQqOoOrgA = P_8;
			OlIOJUyazXtJmtzcmCvButUjxGIh = P_9;
			mAzGafIezvghBFemCzckPQyFqazm = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			tHTNEKuavfzEfDkmtWdEXClKYTYR = P_0.tHTNEKuavfzEfDkmtWdEXClKYTYR;
			NHdOorDkuRBkxnVjZjzDitidnKOnA = P_0.NHdOorDkuRBkxnVjZjzDitidnKOnA;
			hnkdJTMpcRpkbFIMzRTFDQBKVHze = P_0.hnkdJTMpcRpkbFIMzRTFDQBKVHze;
			reYcmhBBJWVMIGUNUHEUprgsBbOIb = P_0.reYcmhBBJWVMIGUNUHEUprgsBbOIb;
			WKvPlcQbuyXPpgnqJvzaZvgpwTtf = P_0.WKvPlcQbuyXPpgnqJvzaZvgpwTtf;
			hkOeftbmOMqAKuwzihoruwmPVRjl = P_0.hkOeftbmOMqAKuwzihoruwmPVRjl;
			xqvzRdKGeAsYFGSHoBQOozrkMuxo = P_0.xqvzRdKGeAsYFGSHoBQOozrkMuxo;
			gVodrwKqnywspeXgJuRNVfjaINjgA = P_0.gVodrwKqnywspeXgJuRNVfjaINjgA;
			ahhAclcXPqoIDTkxZCyjvQqOoOrgA = P_0.ahhAclcXPqoIDTkxZCyjvQqOoOrgA;
			OlIOJUyazXtJmtzcmCvButUjxGIh = P_0.OlIOJUyazXtJmtzcmCvButUjxGIh;
			mAzGafIezvghBFemCzckPQyFqazm = P_0.mAzGafIezvghBFemCzckPQyFqazm;
		}

		internal static ControllerPollingInfo QIblrqHbUMAgdPjecsWonWhgowHj()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
