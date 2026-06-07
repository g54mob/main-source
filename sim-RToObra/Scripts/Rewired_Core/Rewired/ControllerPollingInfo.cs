using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool esjUIAiLRaIarZOZPKmRIqgRYfz;

		private int iueDnAHVXVmEMnNCzSowjkddzOFv;

		private int ruGCBfCWNtGZeTUKxKBCHIMxrSyL;

		private string YAGGDKUpGYxbxmirXGiNvpZasrT;

		private ControllerType xRMUSowrwSVmfxjnqwQXevUgxsr;

		private ControllerElementType geStyfnIbdATvfzZcIGcHdNutpK;

		private int mMyVYAPDqUrVlKvCuSgnRJfZwdm;

		private Pole VAPISRRMYKelrIOCoLZTGWNkWVg;

		private string ccLqwqerDNLPbYOQRmZkNRvlnZD;

		private int wyOUtAQIXRMHfdYotPsXMPVUbwu;

		private KeyCode zvUFYhgrXEclqMjRYJDZgofAdIWi;

		public bool success
		{
			get
			{
				return esjUIAiLRaIarZOZPKmRIqgRYfz;
			}
			internal set
			{
				esjUIAiLRaIarZOZPKmRIqgRYfz = value;
			}
		}

		public int playerId
		{
			get
			{
				return iueDnAHVXVmEMnNCzSowjkddzOFv;
			}
			internal set
			{
				iueDnAHVXVmEMnNCzSowjkddzOFv = value;
			}
		}

		public int controllerId
		{
			get
			{
				return ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
			}
			internal set
			{
				ruGCBfCWNtGZeTUKxKBCHIMxrSyL = value;
			}
		}

		public string controllerName
		{
			get
			{
				return YAGGDKUpGYxbxmirXGiNvpZasrT;
			}
			internal set
			{
				YAGGDKUpGYxbxmirXGiNvpZasrT = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return xRMUSowrwSVmfxjnqwQXevUgxsr;
			}
			internal set
			{
				xRMUSowrwSVmfxjnqwQXevUgxsr = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return geStyfnIbdATvfzZcIGcHdNutpK;
			}
			internal set
			{
				geStyfnIbdATvfzZcIGcHdNutpK = value;
			}
		}

		public int elementIndex
		{
			get
			{
				return mMyVYAPDqUrVlKvCuSgnRJfZwdm;
			}
			internal set
			{
				mMyVYAPDqUrVlKvCuSgnRJfZwdm = value;
			}
		}

		public Pole axisPole
		{
			get
			{
				return VAPISRRMYKelrIOCoLZTGWNkWVg;
			}
			internal set
			{
				VAPISRRMYKelrIOCoLZTGWNkWVg = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return ccLqwqerDNLPbYOQRmZkNRvlnZD;
			}
			internal set
			{
				ccLqwqerDNLPbYOQRmZkNRvlnZD = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return wyOUtAQIXRMHfdYotPsXMPVUbwu;
			}
			internal set
			{
				wyOUtAQIXRMHfdYotPsXMPVUbwu = value;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return zvUFYhgrXEclqMjRYJDZgofAdIWi;
			}
			internal set
			{
				zvUFYhgrXEclqMjRYJDZgofAdIWi = value;
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
				if (!ReInput.YYmRYrIJJDlFmDKErJxqlPcJEZJ.IDrKDdfuMsShzmwAlMuWnxGbEue(iueDnAHVXVmEMnNCzSowjkddzOFv))
				{
					return null;
				}
				return ReInput.YYmRYrIJJDlFmDKErJxqlPcJEZJ.BguZqZULdBNeIEfARdMNkptxqJou(iueDnAHVXVmEMnNCzSowjkddzOFv);
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
				return ReInput.controllers.GetController(xRMUSowrwSVmfxjnqwQXevUgxsr, ruGCBfCWNtGZeTUKxKBCHIMxrSyL);
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
				Controller controller = this.controller;
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
			}
		}

		internal ControllerPollingInfo(bool success, int playerId, int controllerId, string controllerName, ControllerType controllerType, ControllerElementType elementType, int elementIndex, Pole axisPole, string elementIdentifierName, int elementIdentifierId, KeyCode keyboardKey)
		{
			esjUIAiLRaIarZOZPKmRIqgRYfz = success;
			iueDnAHVXVmEMnNCzSowjkddzOFv = playerId;
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = controllerId;
			YAGGDKUpGYxbxmirXGiNvpZasrT = controllerName;
			xRMUSowrwSVmfxjnqwQXevUgxsr = controllerType;
			geStyfnIbdATvfzZcIGcHdNutpK = elementType;
			mMyVYAPDqUrVlKvCuSgnRJfZwdm = elementIndex;
			VAPISRRMYKelrIOCoLZTGWNkWVg = axisPole;
			ccLqwqerDNLPbYOQRmZkNRvlnZD = elementIdentifierName;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = elementIdentifierId;
			zvUFYhgrXEclqMjRYJDZgofAdIWi = keyboardKey;
		}

		internal ControllerPollingInfo(ControllerPollingInfo source)
		{
			esjUIAiLRaIarZOZPKmRIqgRYfz = source.esjUIAiLRaIarZOZPKmRIqgRYfz;
			iueDnAHVXVmEMnNCzSowjkddzOFv = source.iueDnAHVXVmEMnNCzSowjkddzOFv;
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = source.ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
			YAGGDKUpGYxbxmirXGiNvpZasrT = source.YAGGDKUpGYxbxmirXGiNvpZasrT;
			xRMUSowrwSVmfxjnqwQXevUgxsr = source.xRMUSowrwSVmfxjnqwQXevUgxsr;
			geStyfnIbdATvfzZcIGcHdNutpK = source.geStyfnIbdATvfzZcIGcHdNutpK;
			mMyVYAPDqUrVlKvCuSgnRJfZwdm = source.mMyVYAPDqUrVlKvCuSgnRJfZwdm;
			VAPISRRMYKelrIOCoLZTGWNkWVg = source.VAPISRRMYKelrIOCoLZTGWNkWVg;
			ccLqwqerDNLPbYOQRmZkNRvlnZD = source.ccLqwqerDNLPbYOQRmZkNRvlnZD;
			wyOUtAQIXRMHfdYotPsXMPVUbwu = source.wyOUtAQIXRMHfdYotPsXMPVUbwu;
			zvUFYhgrXEclqMjRYJDZgofAdIWi = source.zvUFYhgrXEclqMjRYJDZgofAdIWi;
		}

		internal static ControllerPollingInfo sjiLkgmIqUkLcvoxqoqlLNNXMgF()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
