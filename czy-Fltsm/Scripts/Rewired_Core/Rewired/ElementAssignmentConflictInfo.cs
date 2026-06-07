using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool HsgHJUzrQUdAVpEFlMMFmYVfdTLo;

		private bool BNyyhXBSDqErfUMyhMFZZzPetFUH;

		private int bKJiCvqhjJIbcPHOiVwQVvAjWfZH;

		private ControllerType SRbWNzqPVMDKmfZaIFGEocaPzuDNA;

		private int BjqQZAOfWoZeUXlosHPIDHmQdGZeb;

		private int kKEWpOnLcSdGTNoyXZdROHXbLbth;

		private int zpMBLSjDGwUUtTmEnloKbzdegVGfA;

		private ControllerElementType wEGeRlGrvCtZEuDnhtmffQwwUIzp;

		private int jsCMftpXvAeawleCgIpYVIfsnRMs;

		private KeyCode wbHRwaVAxafcaPilqhNACEMWXBer;

		private ModifierKeyFlags kXjZXRHJLBxnOWqdMZPjAkPeTzeU;

		private int itACUoFRhgGcVlHRwCMUIQIQQBRSA;

		public bool isConflict
		{
			get
			{
				return HsgHJUzrQUdAVpEFlMMFmYVfdTLo;
			}
			internal set
			{
				HsgHJUzrQUdAVpEFlMMFmYVfdTLo = hsgHJUzrQUdAVpEFlMMFmYVfdTLo;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return BNyyhXBSDqErfUMyhMFZZzPetFUH;
			}
			internal set
			{
				BNyyhXBSDqErfUMyhMFZZzPetFUH = bNyyhXBSDqErfUMyhMFZZzPetFUH;
			}
		}

		public int playerId
		{
			get
			{
				return bKJiCvqhjJIbcPHOiVwQVvAjWfZH;
			}
			internal set
			{
				bKJiCvqhjJIbcPHOiVwQVvAjWfZH = num;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return SRbWNzqPVMDKmfZaIFGEocaPzuDNA;
			}
			internal set
			{
				SRbWNzqPVMDKmfZaIFGEocaPzuDNA = sRbWNzqPVMDKmfZaIFGEocaPzuDNA;
			}
		}

		public int controllerId
		{
			get
			{
				return BjqQZAOfWoZeUXlosHPIDHmQdGZeb;
			}
			internal set
			{
				BjqQZAOfWoZeUXlosHPIDHmQdGZeb = bjqQZAOfWoZeUXlosHPIDHmQdGZeb;
			}
		}

		public int controllerMapId
		{
			get
			{
				return kKEWpOnLcSdGTNoyXZdROHXbLbth;
			}
			internal set
			{
				kKEWpOnLcSdGTNoyXZdROHXbLbth = num;
			}
		}

		public int elementMapId
		{
			get
			{
				return zpMBLSjDGwUUtTmEnloKbzdegVGfA;
			}
			internal set
			{
				zpMBLSjDGwUUtTmEnloKbzdegVGfA = num;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return wEGeRlGrvCtZEuDnhtmffQwwUIzp;
			}
			internal set
			{
				wEGeRlGrvCtZEuDnhtmffQwwUIzp = controllerElementType;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return jsCMftpXvAeawleCgIpYVIfsnRMs;
			}
			internal set
			{
				jsCMftpXvAeawleCgIpYVIfsnRMs = num;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return wbHRwaVAxafcaPilqhNACEMWXBer;
			}
			internal set
			{
				wbHRwaVAxafcaPilqhNACEMWXBer = keyCode;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return kXjZXRHJLBxnOWqdMZPjAkPeTzeU;
			}
			internal set
			{
				kXjZXRHJLBxnOWqdMZPjAkPeTzeU = modifierKeyFlags;
			}
		}

		public int actionId
		{
			get
			{
				return itACUoFRhgGcVlHRwCMUIQIQQBRSA;
			}
			internal set
			{
				itACUoFRhgGcVlHRwCMUIQIQQBRSA = num;
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
				return ReInput.players.GetPlayer(bKJiCvqhjJIbcPHOiVwQVvAjWfZH);
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
				return ReInput.mapping.GetAction(itACUoFRhgGcVlHRwCMUIQIQQBRSA);
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
				return ReInput.controllers.GetController(SRbWNzqPVMDKmfZaIFGEocaPzuDNA, BjqQZAOfWoZeUXlosHPIDHmQdGZeb);
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
				return player.controllers.maps.GetMap(SRbWNzqPVMDKmfZaIFGEocaPzuDNA, BjqQZAOfWoZeUXlosHPIDHmQdGZeb, kKEWpOnLcSdGTNoyXZdROHXbLbth);
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
				return controller.GetElementIdentifierById(jsCMftpXvAeawleCgIpYVIfsnRMs);
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
				return controllerMap.GetElementMap(zpMBLSjDGwUUtTmEnloKbzdegVGfA);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (SRbWNzqPVMDKmfZaIFGEocaPzuDNA == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(wbHRwaVAxafcaPilqhNACEMWXBer, kXjZXRHJLBxnOWqdMZPjAkPeTzeU);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(jsCMftpXvAeawleCgIpYVIfsnRMs);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		public ElementAssignmentConflictInfo(bool P_0, bool P_1, int P_2, ControllerType P_3, int P_4, int P_5, int P_6, int P_7, ControllerElementType P_8, int P_9, KeyCode P_10, ModifierKeyFlags P_11)
		{
			HsgHJUzrQUdAVpEFlMMFmYVfdTLo = P_0;
			BNyyhXBSDqErfUMyhMFZZzPetFUH = P_1;
			bKJiCvqhjJIbcPHOiVwQVvAjWfZH = P_2;
			SRbWNzqPVMDKmfZaIFGEocaPzuDNA = P_3;
			BjqQZAOfWoZeUXlosHPIDHmQdGZeb = P_4;
			kKEWpOnLcSdGTNoyXZdROHXbLbth = P_5;
			zpMBLSjDGwUUtTmEnloKbzdegVGfA = P_6;
			itACUoFRhgGcVlHRwCMUIQIQQBRSA = P_7;
			wEGeRlGrvCtZEuDnhtmffQwwUIzp = P_8;
			jsCMftpXvAeawleCgIpYVIfsnRMs = P_9;
			wbHRwaVAxafcaPilqhNACEMWXBer = P_10;
			kXjZXRHJLBxnOWqdMZPjAkPeTzeU = P_11;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo P_0)
		{
			HsgHJUzrQUdAVpEFlMMFmYVfdTLo = P_0.HsgHJUzrQUdAVpEFlMMFmYVfdTLo;
			BNyyhXBSDqErfUMyhMFZZzPetFUH = P_0.BNyyhXBSDqErfUMyhMFZZzPetFUH;
			bKJiCvqhjJIbcPHOiVwQVvAjWfZH = P_0.bKJiCvqhjJIbcPHOiVwQVvAjWfZH;
			SRbWNzqPVMDKmfZaIFGEocaPzuDNA = P_0.SRbWNzqPVMDKmfZaIFGEocaPzuDNA;
			BjqQZAOfWoZeUXlosHPIDHmQdGZeb = P_0.BjqQZAOfWoZeUXlosHPIDHmQdGZeb;
			kKEWpOnLcSdGTNoyXZdROHXbLbth = P_0.kKEWpOnLcSdGTNoyXZdROHXbLbth;
			zpMBLSjDGwUUtTmEnloKbzdegVGfA = P_0.zpMBLSjDGwUUtTmEnloKbzdegVGfA;
			itACUoFRhgGcVlHRwCMUIQIQQBRSA = P_0.itACUoFRhgGcVlHRwCMUIQIQQBRSA;
			wEGeRlGrvCtZEuDnhtmffQwwUIzp = P_0.wEGeRlGrvCtZEuDnhtmffQwwUIzp;
			jsCMftpXvAeawleCgIpYVIfsnRMs = P_0.jsCMftpXvAeawleCgIpYVIfsnRMs;
			wbHRwaVAxafcaPilqhNACEMWXBer = P_0.wbHRwaVAxafcaPilqhNACEMWXBer;
			kXjZXRHJLBxnOWqdMZPjAkPeTzeU = P_0.kXjZXRHJLBxnOWqdMZPjAkPeTzeU;
		}
	}
}
