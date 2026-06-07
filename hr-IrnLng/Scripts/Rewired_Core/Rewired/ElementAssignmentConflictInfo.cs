using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool yHvemuWyahNXQAIpDQotKWxlcaf;

		private bool lFhMOoJJtNPRXDqwLSEEWAtEOJz;

		private int EpFfrTuakcvBKacoggaztTmGfrG;

		private ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

		private int HOfXKstauKwTqpMsyTWXViZIbgl;

		private int tlYjFdkufxnjMyiiJvzlETBRxoa;

		private int QJDokKWoXgGLEeTmvEyDXKiQQDMJ;

		private ControllerElementType IDlBgcIyMAualOodjeMvFCUPFMBW;

		private int MAfbKattduhdBJEmosLzsDAtqCjp;

		private KeyCode BxuLSHaHsvketBoTjeGXEhXvhku;

		private ModifierKeyFlags wDaZeqSOupdtjqsnOLPLLqlYXsh;

		private int CYBGYVfPDvCydagiBzJBExAfcuYb;

		public bool isConflict
		{
			get
			{
				return yHvemuWyahNXQAIpDQotKWxlcaf;
			}
			internal set
			{
				yHvemuWyahNXQAIpDQotKWxlcaf = value;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return lFhMOoJJtNPRXDqwLSEEWAtEOJz;
			}
			internal set
			{
				lFhMOoJJtNPRXDqwLSEEWAtEOJz = value;
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

		public int controllerMapId
		{
			get
			{
				return tlYjFdkufxnjMyiiJvzlETBRxoa;
			}
			internal set
			{
				tlYjFdkufxnjMyiiJvzlETBRxoa = value;
			}
		}

		public int elementMapId
		{
			get
			{
				return QJDokKWoXgGLEeTmvEyDXKiQQDMJ;
			}
			internal set
			{
				QJDokKWoXgGLEeTmvEyDXKiQQDMJ = value;
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

		public KeyCode keyCode
		{
			get
			{
				return BxuLSHaHsvketBoTjeGXEhXvhku;
			}
			internal set
			{
				BxuLSHaHsvketBoTjeGXEhXvhku = value;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return wDaZeqSOupdtjqsnOLPLLqlYXsh;
			}
			internal set
			{
				wDaZeqSOupdtjqsnOLPLLqlYXsh = value;
			}
		}

		public int actionId
		{
			get
			{
				return CYBGYVfPDvCydagiBzJBExAfcuYb;
			}
			internal set
			{
				CYBGYVfPDvCydagiBzJBExAfcuYb = value;
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
				return ReInput.players.GetPlayer(EpFfrTuakcvBKacoggaztTmGfrG);
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
				return ReInput.mapping.GetAction(CYBGYVfPDvCydagiBzJBExAfcuYb);
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

		public ControllerMap controllerMap
		{
			get
			{
				if (player == null)
				{
					return null;
				}
				return player.controllers.maps.GetMap(VkxeQjDVSfumjFSZdzmQHhgPgAwE, HOfXKstauKwTqpMsyTWXViZIbgl, tlYjFdkufxnjMyiiJvzlETBRxoa);
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
				return controller.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
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
				return controllerMap.GetElementMap(QJDokKWoXgGLEeTmvEyDXKiQQDMJ);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(BxuLSHaHsvketBoTjeGXEhXvhku, wDaZeqSOupdtjqsnOLPLLqlYXsh);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.name;
			}
		}

		public ElementAssignmentConflictInfo(bool isConflict, bool isUserAssignable, int playerId, ControllerType controllerType, int controllerId, int controllerMapId, int elementMapId, int actionId, ControllerElementType elementType, int elementIdentifierId, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			yHvemuWyahNXQAIpDQotKWxlcaf = isConflict;
			lFhMOoJJtNPRXDqwLSEEWAtEOJz = isUserAssignable;
			EpFfrTuakcvBKacoggaztTmGfrG = playerId;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = controllerType;
			HOfXKstauKwTqpMsyTWXViZIbgl = controllerId;
			tlYjFdkufxnjMyiiJvzlETBRxoa = controllerMapId;
			QJDokKWoXgGLEeTmvEyDXKiQQDMJ = elementMapId;
			CYBGYVfPDvCydagiBzJBExAfcuYb = actionId;
			IDlBgcIyMAualOodjeMvFCUPFMBW = elementType;
			MAfbKattduhdBJEmosLzsDAtqCjp = elementIdentifierId;
			BxuLSHaHsvketBoTjeGXEhXvhku = keyCode;
			wDaZeqSOupdtjqsnOLPLLqlYXsh = modifierKeyFlags;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo source)
		{
			yHvemuWyahNXQAIpDQotKWxlcaf = source.yHvemuWyahNXQAIpDQotKWxlcaf;
			lFhMOoJJtNPRXDqwLSEEWAtEOJz = source.lFhMOoJJtNPRXDqwLSEEWAtEOJz;
			EpFfrTuakcvBKacoggaztTmGfrG = source.EpFfrTuakcvBKacoggaztTmGfrG;
			VkxeQjDVSfumjFSZdzmQHhgPgAwE = source.VkxeQjDVSfumjFSZdzmQHhgPgAwE;
			HOfXKstauKwTqpMsyTWXViZIbgl = source.HOfXKstauKwTqpMsyTWXViZIbgl;
			tlYjFdkufxnjMyiiJvzlETBRxoa = source.tlYjFdkufxnjMyiiJvzlETBRxoa;
			QJDokKWoXgGLEeTmvEyDXKiQQDMJ = source.QJDokKWoXgGLEeTmvEyDXKiQQDMJ;
			CYBGYVfPDvCydagiBzJBExAfcuYb = source.CYBGYVfPDvCydagiBzJBExAfcuYb;
			IDlBgcIyMAualOodjeMvFCUPFMBW = source.IDlBgcIyMAualOodjeMvFCUPFMBW;
			MAfbKattduhdBJEmosLzsDAtqCjp = source.MAfbKattduhdBJEmosLzsDAtqCjp;
			BxuLSHaHsvketBoTjeGXEhXvhku = source.BxuLSHaHsvketBoTjeGXEhXvhku;
			wDaZeqSOupdtjqsnOLPLLqlYXsh = source.wDaZeqSOupdtjqsnOLPLLqlYXsh;
		}
	}
}
