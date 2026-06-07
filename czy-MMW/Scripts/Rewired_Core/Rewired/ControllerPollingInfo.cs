using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool anvzRrqAzstGdPYbnKzoBNJpflWV;

		private int KnTYzANaoGEundVcXkhvbZQAiaEn;

		private int mMEAeiMGhUHphEDLvxHtPDstydvVA;

		private string uamndMRSRVTQKEjQWMCmjJUHaRKgA;

		private ControllerType XJBISFYQevVipcNnRfnCNDEUIMhN;

		private ControllerElementType aIggkMevMBKWGVwecfmFgyOhcrlbB;

		private int iKTNEKUBsVCYHQOQuAKedkHVPApZ;

		private Pole rYUeXRSbrJobIijNBRrbXTeNjhbc;

		private string zaJkjURWBrNOFgSoXSyDApSjuixx;

		private int VEkXHnsdyQlwwnfXuOfwkFSSPOqB;

		private KeyCode vBVLpOAtcgjDTPgbGgQYHcYsCXle;

		public bool success
		{
			get
			{
				return anvzRrqAzstGdPYbnKzoBNJpflWV;
			}
			internal set
			{
				anvzRrqAzstGdPYbnKzoBNJpflWV = flag;
			}
		}

		public int playerId
		{
			get
			{
				return KnTYzANaoGEundVcXkhvbZQAiaEn;
			}
			internal set
			{
				KnTYzANaoGEundVcXkhvbZQAiaEn = knTYzANaoGEundVcXkhvbZQAiaEn;
			}
		}

		public int controllerId
		{
			get
			{
				return mMEAeiMGhUHphEDLvxHtPDstydvVA;
			}
			internal set
			{
				mMEAeiMGhUHphEDLvxHtPDstydvVA = num;
			}
		}

		public string controllerName
		{
			get
			{
				return uamndMRSRVTQKEjQWMCmjJUHaRKgA;
			}
			internal set
			{
				uamndMRSRVTQKEjQWMCmjJUHaRKgA = text;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return XJBISFYQevVipcNnRfnCNDEUIMhN;
			}
			internal set
			{
				XJBISFYQevVipcNnRfnCNDEUIMhN = xJBISFYQevVipcNnRfnCNDEUIMhN;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return aIggkMevMBKWGVwecfmFgyOhcrlbB;
			}
			internal set
			{
				aIggkMevMBKWGVwecfmFgyOhcrlbB = controllerElementType;
			}
		}

		public int elementIndex
		{
			get
			{
				return iKTNEKUBsVCYHQOQuAKedkHVPApZ;
			}
			internal set
			{
				iKTNEKUBsVCYHQOQuAKedkHVPApZ = num;
			}
		}

		public Pole axisPole
		{
			get
			{
				return rYUeXRSbrJobIijNBRrbXTeNjhbc;
			}
			internal set
			{
				rYUeXRSbrJobIijNBRrbXTeNjhbc = pole;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return zaJkjURWBrNOFgSoXSyDApSjuixx;
			}
			internal set
			{
				zaJkjURWBrNOFgSoXSyDApSjuixx = text;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return VEkXHnsdyQlwwnfXuOfwkFSSPOqB;
			}
			internal set
			{
				VEkXHnsdyQlwwnfXuOfwkFSSPOqB = vEkXHnsdyQlwwnfXuOfwkFSSPOqB;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return vBVLpOAtcgjDTPgbGgQYHcYsCXle;
			}
			internal set
			{
				vBVLpOAtcgjDTPgbGgQYHcYsCXle = keyCode;
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
				if (!ReInput.NUfAUcWLCevjCFPFNKrevODCEJAs.UgiMDeTxuuKNnOzpnMPfmqCKEXgM(KnTYzANaoGEundVcXkhvbZQAiaEn))
				{
					return null;
				}
				return ReInput.NUfAUcWLCevjCFPFNKrevODCEJAs.MgIIdYJCmureJBUYamqZmJEeOVwP(KnTYzANaoGEundVcXkhvbZQAiaEn);
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
				return ReInput.controllers.GetController(XJBISFYQevVipcNnRfnCNDEUIMhN, mMEAeiMGhUHphEDLvxHtPDstydvVA);
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
				return controller?.GetElementIdentifierById(VEkXHnsdyQlwwnfXuOfwkFSSPOqB);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			anvzRrqAzstGdPYbnKzoBNJpflWV = P_0;
			KnTYzANaoGEundVcXkhvbZQAiaEn = P_1;
			mMEAeiMGhUHphEDLvxHtPDstydvVA = P_2;
			uamndMRSRVTQKEjQWMCmjJUHaRKgA = P_3;
			XJBISFYQevVipcNnRfnCNDEUIMhN = P_4;
			aIggkMevMBKWGVwecfmFgyOhcrlbB = P_5;
			iKTNEKUBsVCYHQOQuAKedkHVPApZ = P_6;
			rYUeXRSbrJobIijNBRrbXTeNjhbc = P_7;
			zaJkjURWBrNOFgSoXSyDApSjuixx = P_8;
			VEkXHnsdyQlwwnfXuOfwkFSSPOqB = P_9;
			vBVLpOAtcgjDTPgbGgQYHcYsCXle = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			anvzRrqAzstGdPYbnKzoBNJpflWV = P_0.anvzRrqAzstGdPYbnKzoBNJpflWV;
			KnTYzANaoGEundVcXkhvbZQAiaEn = P_0.KnTYzANaoGEundVcXkhvbZQAiaEn;
			mMEAeiMGhUHphEDLvxHtPDstydvVA = P_0.mMEAeiMGhUHphEDLvxHtPDstydvVA;
			uamndMRSRVTQKEjQWMCmjJUHaRKgA = P_0.uamndMRSRVTQKEjQWMCmjJUHaRKgA;
			XJBISFYQevVipcNnRfnCNDEUIMhN = P_0.XJBISFYQevVipcNnRfnCNDEUIMhN;
			aIggkMevMBKWGVwecfmFgyOhcrlbB = P_0.aIggkMevMBKWGVwecfmFgyOhcrlbB;
			iKTNEKUBsVCYHQOQuAKedkHVPApZ = P_0.iKTNEKUBsVCYHQOQuAKedkHVPApZ;
			rYUeXRSbrJobIijNBRrbXTeNjhbc = P_0.rYUeXRSbrJobIijNBRrbXTeNjhbc;
			zaJkjURWBrNOFgSoXSyDApSjuixx = P_0.zaJkjURWBrNOFgSoXSyDApSjuixx;
			VEkXHnsdyQlwwnfXuOfwkFSSPOqB = P_0.VEkXHnsdyQlwwnfXuOfwkFSSPOqB;
			vBVLpOAtcgjDTPgbGgQYHcYsCXle = P_0.vBVLpOAtcgjDTPgbGgQYHcYsCXle;
		}

		internal static ControllerPollingInfo LhJuMFPLfNImbTTnukGMlNDRCIFf()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
