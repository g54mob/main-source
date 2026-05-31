using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool IlCWPnJcHHNEfknKQwAsJjBcAKw;

		private int EpFfrTuakcvBKacoggaztTmGfrG;

		private int HOfXKstauKwTqpMsyTWXViZIbgl;

		private string yKrXzVnCbfWjxFDHOHiYyCYJbMWC;

		private ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

		private ControllerElementType IDlBgcIyMAualOodjeMvFCUPFMBW;

		private int CRqOTsiLfoazJbodeeofQgavSxg;

		private Pole pyqOtYytztMxdrcufXcWFUVDgff;

		private string KyibyrTnauIwjdImEoNfIeeKwcG;

		private int MAfbKattduhdBJEmosLzsDAtqCjp;

		private KeyCode DSzQdmGhwfIgwOPfHJGAxNirtHP;

		public bool success
		{
			get
			{
				return IlCWPnJcHHNEfknKQwAsJjBcAKw;
			}
			internal set
			{
				IlCWPnJcHHNEfknKQwAsJjBcAKw = value;
			}
		}

		public int playerId
		{
			get
			{
				return EpFfrTuakcvBKacoggaztTmGfrG;
			}
			internal set
			{
				EpFfrTuakcvBKacoggaztTmGfrG = value;
			}
		}

		public int controllerId
		{
			get
			{
				return HOfXKstauKwTqpMsyTWXViZIbgl;
			}
			internal set
			{
				HOfXKstauKwTqpMsyTWXViZIbgl = value;
			}
		}

		public string controllerName
		{
			get
			{
				return yKrXzVnCbfWjxFDHOHiYyCYJbMWC;
			}
			internal set
			{
				yKrXzVnCbfWjxFDHOHiYyCYJbMWC = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return VkxeQjDVSfumjFSZdzmQHhgPgAwE;
			}
			internal set
			{
				VkxeQjDVSfumjFSZdzmQHhgPgAwE = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return IDlBgcIyMAualOodjeMvFCUPFMBW;
			}
			internal set
			{
				IDlBgcIyMAualOodjeMvFCUPFMBW = value;
			}
		}

		public int elementIndex
		{
			get
			{
				return CRqOTsiLfoazJbodeeofQgavSxg;
			}
			internal set
			{
				CRqOTsiLfoazJbodeeofQgavSxg = value;
			}
		}

		public Pole axisPole
		{
			get
			{
				return pyqOtYytztMxdrcufXcWFUVDgff;
			}
			internal set
			{
				pyqOtYytztMxdrcufXcWFUVDgff = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return KyibyrTnauIwjdImEoNfIeeKwcG;
			}
			internal set
			{
				KyibyrTnauIwjdImEoNfIeeKwcG = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return MAfbKattduhdBJEmosLzsDAtqCjp;
			}
			internal set
			{
				MAfbKattduhdBJEmosLzsDAtqCjp = value;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return DSzQdmGhwfIgwOPfHJGAxNirtHP;
			}
			internal set
			{
				DSzQdmGhwfIgwOPfHJGAxNirtHP = value;
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
				if (!ReInput.yIRdWijqyghmemPssevxkoxocsUE.waMPqyEZdXSlrPjgiomVglTYvwr(EpFfrTuakcvBKacoggaztTmGfrG))
				{
					return null;
				}
				return ReInput.yIRdWijqyghmemPssevxkoxocsUE.lZXmlWxQPcBFEbyBUMCSggeIoJj(EpFfrTuakcvBKacoggaztTmGfrG);
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
				return ReInput.controllers.GetController(VkxeQjDVSfumjFSZdzmQHhgPgAwE, HOfXKstauKwTqpMsyTWXViZIbgl);
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
				return controller?.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
			}
		}

		internal ControllerPollingInfo(bool success, int playerId, int controllerId, string controllerName, ControllerType controllerType, ControllerElementType elementType, int elementIndex, Pole axisPole, string elementIdentifierName, int elementIdentifierId, KeyCode keyboardKey)
		{
			IlCWPnJcHHNEfknKQwAsJjBcAKw = success;
			EpFfrTuakcvBKacoggaztTmGfrG = playerId;
			HOfXKstauKwTqpMsyTWXViZIbgl = controllerId;
			yKrXzVnCbfWjxFDHOHiYyCYJbMWC = controllerName;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = controllerType;
			IDlBgcIyMAualOodjeMvFCUPFMBW = elementType;
			CRqOTsiLfoazJbodeeofQgavSxg = elementIndex;
			pyqOtYytztMxdrcufXcWFUVDgff = axisPole;
			KyibyrTnauIwjdImEoNfIeeKwcG = elementIdentifierName;
			MAfbKattduhdBJEmosLzsDAtqCjp = elementIdentifierId;
			DSzQdmGhwfIgwOPfHJGAxNirtHP = keyboardKey;
		}

		internal ControllerPollingInfo(ControllerPollingInfo source)
		{
			IlCWPnJcHHNEfknKQwAsJjBcAKw = source.IlCWPnJcHHNEfknKQwAsJjBcAKw;
			EpFfrTuakcvBKacoggaztTmGfrG = source.EpFfrTuakcvBKacoggaztTmGfrG;
			HOfXKstauKwTqpMsyTWXViZIbgl = source.HOfXKstauKwTqpMsyTWXViZIbgl;
			yKrXzVnCbfWjxFDHOHiYyCYJbMWC = source.yKrXzVnCbfWjxFDHOHiYyCYJbMWC;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = source.VkxeQjDVSfumjFSZdzmQHhgPgAwE;
			IDlBgcIyMAualOodjeMvFCUPFMBW = source.IDlBgcIyMAualOodjeMvFCUPFMBW;
			CRqOTsiLfoazJbodeeofQgavSxg = source.CRqOTsiLfoazJbodeeofQgavSxg;
			pyqOtYytztMxdrcufXcWFUVDgff = source.pyqOtYytztMxdrcufXcWFUVDgff;
			KyibyrTnauIwjdImEoNfIeeKwcG = source.KyibyrTnauIwjdImEoNfIeeKwcG;
			MAfbKattduhdBJEmosLzsDAtqCjp = source.MAfbKattduhdBJEmosLzsDAtqCjp;
			DSzQdmGhwfIgwOPfHJGAxNirtHP = source.DSzQdmGhwfIgwOPfHJGAxNirtHP;
		}

		internal static ControllerPollingInfo SzFLVfJyThMscGjHlMeaEHMuwJY()
		{
			return new ControllerPollingInfo(success: false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
