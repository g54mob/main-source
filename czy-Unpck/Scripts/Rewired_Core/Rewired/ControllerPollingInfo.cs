using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool umjuEUyAqcKcJGYzkXdQndOCrqN;

		private int cNcLkMBaCDcdcMeoQVAxVFVuHEv;

		private int vnEdenUwZllTYBycKwkNdiMcIIS;

		private string YKMrgIKIpMALFlbTeSJGUlvbbzx;

		private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

		private ControllerElementType iDCCUtfTWxxiRkkzZhazaAppvzo;

		private int ouusLSVThShOJXeTBDNomJoAhtU;

		private Pole PyFcoDLnvOEVBPWgPlmErgplBHOG;

		private string kyNQyqewsLrqXDcmgwjbeFBcFgr;

		private int yBWjkrHKbDlkjegyONinAthRElAh;

		private KeyCode rrWqncxgbIFcEuxwlwCQFTNRWpk;

		public bool success
		{
			get
			{
				return umjuEUyAqcKcJGYzkXdQndOCrqN;
			}
			internal set
			{
				umjuEUyAqcKcJGYzkXdQndOCrqN = value;
			}
		}

		public int playerId
		{
			get
			{
				return cNcLkMBaCDcdcMeoQVAxVFVuHEv;
			}
			internal set
			{
				cNcLkMBaCDcdcMeoQVAxVFVuHEv = value;
			}
		}

		public int controllerId
		{
			get
			{
				return vnEdenUwZllTYBycKwkNdiMcIIS;
			}
			internal set
			{
				vnEdenUwZllTYBycKwkNdiMcIIS = value;
			}
		}

		public string controllerName
		{
			get
			{
				return YKMrgIKIpMALFlbTeSJGUlvbbzx;
			}
			internal set
			{
				YKMrgIKIpMALFlbTeSJGUlvbbzx = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return fkEwyowpQQKzBaGTBxLUNmLjHtN;
			}
			internal set
			{
				fkEwyowpQQKzBaGTBxLUNmLjHtN = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return iDCCUtfTWxxiRkkzZhazaAppvzo;
			}
			internal set
			{
				iDCCUtfTWxxiRkkzZhazaAppvzo = value;
			}
		}

		public int elementIndex
		{
			get
			{
				return ouusLSVThShOJXeTBDNomJoAhtU;
			}
			internal set
			{
				ouusLSVThShOJXeTBDNomJoAhtU = value;
			}
		}

		public Pole axisPole
		{
			get
			{
				return PyFcoDLnvOEVBPWgPlmErgplBHOG;
			}
			internal set
			{
				PyFcoDLnvOEVBPWgPlmErgplBHOG = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return kyNQyqewsLrqXDcmgwjbeFBcFgr;
			}
			internal set
			{
				kyNQyqewsLrqXDcmgwjbeFBcFgr = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return yBWjkrHKbDlkjegyONinAthRElAh;
			}
			internal set
			{
				yBWjkrHKbDlkjegyONinAthRElAh = value;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return rrWqncxgbIFcEuxwlwCQFTNRWpk;
			}
			internal set
			{
				rrWqncxgbIFcEuxwlwCQFTNRWpk = value;
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
				if (!ReInput.WhcqAfYYqNfRCEGkYApjWYGKVjr.IBtfhptRpkxJLxquIWDLWUiaeKE(cNcLkMBaCDcdcMeoQVAxVFVuHEv))
				{
					return null;
				}
				return ReInput.WhcqAfYYqNfRCEGkYApjWYGKVjr.LwwGNDEKhVGiAVsVapAOKLGgPGB(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
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
				return ReInput.controllers.GetController(fkEwyowpQQKzBaGTBxLUNmLjHtN, vnEdenUwZllTYBycKwkNdiMcIIS);
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
				while (true)
				{
					int num = 381060231;
					while (true)
					{
						switch (num ^ 0x16B68485)
						{
						case 0:
							break;
						case 2:
							if (controller == null)
							{
								goto IL_0031;
							}
							return controller.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
						default:
							return null;
						}
						break;
						IL_0031:
						num = 381060228;
					}
				}
			}
		}

		internal ControllerPollingInfo(bool success, int playerId, int controllerId, string controllerName, ControllerType controllerType, ControllerElementType elementType, int elementIndex, Pole axisPole, string elementIdentifierName, int elementIdentifierId, KeyCode keyboardKey)
		{
			umjuEUyAqcKcJGYzkXdQndOCrqN = success;
			cNcLkMBaCDcdcMeoQVAxVFVuHEv = playerId;
			vnEdenUwZllTYBycKwkNdiMcIIS = controllerId;
			YKMrgIKIpMALFlbTeSJGUlvbbzx = controllerName;
			fkEwyowpQQKzBaGTBxLUNmLjHtN = controllerType;
			iDCCUtfTWxxiRkkzZhazaAppvzo = elementType;
			ouusLSVThShOJXeTBDNomJoAhtU = elementIndex;
			PyFcoDLnvOEVBPWgPlmErgplBHOG = axisPole;
			kyNQyqewsLrqXDcmgwjbeFBcFgr = elementIdentifierName;
			yBWjkrHKbDlkjegyONinAthRElAh = elementIdentifierId;
			rrWqncxgbIFcEuxwlwCQFTNRWpk = keyboardKey;
		}

		internal ControllerPollingInfo(ControllerPollingInfo source)
		{
			umjuEUyAqcKcJGYzkXdQndOCrqN = source.umjuEUyAqcKcJGYzkXdQndOCrqN;
			cNcLkMBaCDcdcMeoQVAxVFVuHEv = source.cNcLkMBaCDcdcMeoQVAxVFVuHEv;
			vnEdenUwZllTYBycKwkNdiMcIIS = source.vnEdenUwZllTYBycKwkNdiMcIIS;
			YKMrgIKIpMALFlbTeSJGUlvbbzx = source.YKMrgIKIpMALFlbTeSJGUlvbbzx;
			fkEwyowpQQKzBaGTBxLUNmLjHtN = source.fkEwyowpQQKzBaGTBxLUNmLjHtN;
			iDCCUtfTWxxiRkkzZhazaAppvzo = source.iDCCUtfTWxxiRkkzZhazaAppvzo;
			ouusLSVThShOJXeTBDNomJoAhtU = source.ouusLSVThShOJXeTBDNomJoAhtU;
			PyFcoDLnvOEVBPWgPlmErgplBHOG = source.PyFcoDLnvOEVBPWgPlmErgplBHOG;
			kyNQyqewsLrqXDcmgwjbeFBcFgr = source.kyNQyqewsLrqXDcmgwjbeFBcFgr;
			yBWjkrHKbDlkjegyONinAthRElAh = source.yBWjkrHKbDlkjegyONinAthRElAh;
			rrWqncxgbIFcEuxwlwCQFTNRWpk = source.rrWqncxgbIFcEuxwlwCQFTNRWpk;
		}

		internal static ControllerPollingInfo czsDbiqQNWsvQguTJNJasHdCGwp()
		{
			return new ControllerPollingInfo(success: false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
