using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool YukGltpadVYMtaCCVvQeepYJTqZ;

		private bool ZeEFuzwPtmeAfbPybDhGjcAmUuEl;

		private int cNcLkMBaCDcdcMeoQVAxVFVuHEv;

		private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

		private int vnEdenUwZllTYBycKwkNdiMcIIS;

		private int FMlFscZHgEaroOimxUJfmCwhSSB;

		private int oiqgKVfwRJIXctXeLPpJwwVgman;

		private ControllerElementType iDCCUtfTWxxiRkkzZhazaAppvzo;

		private int yBWjkrHKbDlkjegyONinAthRElAh;

		private KeyCode zvVrLCNqeWrMDfcLTvPLsgsTFBT;

		private ModifierKeyFlags YfXbVhhWcSuyNKacqoMLhXaiabR;

		private int qxoYaUQyNIsvDIFklnqXHPrHJLd;

		public bool isConflict
		{
			get
			{
				return YukGltpadVYMtaCCVvQeepYJTqZ;
			}
			internal set
			{
				YukGltpadVYMtaCCVvQeepYJTqZ = value;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return ZeEFuzwPtmeAfbPybDhGjcAmUuEl;
			}
			internal set
			{
				ZeEFuzwPtmeAfbPybDhGjcAmUuEl = value;
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

		public int controllerMapId
		{
			get
			{
				return FMlFscZHgEaroOimxUJfmCwhSSB;
			}
			internal set
			{
				FMlFscZHgEaroOimxUJfmCwhSSB = value;
			}
		}

		public int elementMapId
		{
			get
			{
				return oiqgKVfwRJIXctXeLPpJwwVgman;
			}
			internal set
			{
				oiqgKVfwRJIXctXeLPpJwwVgman = value;
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

		public KeyCode keyCode
		{
			get
			{
				return zvVrLCNqeWrMDfcLTvPLsgsTFBT;
			}
			internal set
			{
				zvVrLCNqeWrMDfcLTvPLsgsTFBT = value;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return YfXbVhhWcSuyNKacqoMLhXaiabR;
			}
			internal set
			{
				YfXbVhhWcSuyNKacqoMLhXaiabR = value;
			}
		}

		public int actionId
		{
			get
			{
				return qxoYaUQyNIsvDIFklnqXHPrHJLd;
			}
			internal set
			{
				qxoYaUQyNIsvDIFklnqXHPrHJLd = value;
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
				return ReInput.players.GetPlayer(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
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
				return ReInput.mapping.GetAction(qxoYaUQyNIsvDIFklnqXHPrHJLd);
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

		public ControllerMap controllerMap
		{
			get
			{
				if (player == null)
				{
					return null;
				}
				return player.controllers.maps.GetMap(fkEwyowpQQKzBaGTBxLUNmLjHtN, vnEdenUwZllTYBycKwkNdiMcIIS, FMlFscZHgEaroOimxUJfmCwhSSB);
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
				return controller.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
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
				return controllerMap.GetElementMap(oiqgKVfwRJIXctXeLPpJwwVgman);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (fkEwyowpQQKzBaGTBxLUNmLjHtN == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(zvVrLCNqeWrMDfcLTvPLsgsTFBT, YfXbVhhWcSuyNKacqoMLhXaiabR);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.name;
			}
		}

		public ElementAssignmentConflictInfo(bool isConflict, bool isUserAssignable, int playerId, ControllerType controllerType, int controllerId, int controllerMapId, int elementMapId, int actionId, ControllerElementType elementType, int elementIdentifierId, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			YukGltpadVYMtaCCVvQeepYJTqZ = isConflict;
			ZeEFuzwPtmeAfbPybDhGjcAmUuEl = isUserAssignable;
			cNcLkMBaCDcdcMeoQVAxVFVuHEv = playerId;
			fkEwyowpQQKzBaGTBxLUNmLjHtN = controllerType;
			vnEdenUwZllTYBycKwkNdiMcIIS = controllerId;
			FMlFscZHgEaroOimxUJfmCwhSSB = controllerMapId;
			oiqgKVfwRJIXctXeLPpJwwVgman = elementMapId;
			qxoYaUQyNIsvDIFklnqXHPrHJLd = actionId;
			iDCCUtfTWxxiRkkzZhazaAppvzo = elementType;
			yBWjkrHKbDlkjegyONinAthRElAh = elementIdentifierId;
			zvVrLCNqeWrMDfcLTvPLsgsTFBT = keyCode;
			YfXbVhhWcSuyNKacqoMLhXaiabR = modifierKeyFlags;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo source)
		{
			YukGltpadVYMtaCCVvQeepYJTqZ = source.YukGltpadVYMtaCCVvQeepYJTqZ;
			ZeEFuzwPtmeAfbPybDhGjcAmUuEl = source.ZeEFuzwPtmeAfbPybDhGjcAmUuEl;
			cNcLkMBaCDcdcMeoQVAxVFVuHEv = source.cNcLkMBaCDcdcMeoQVAxVFVuHEv;
			fkEwyowpQQKzBaGTBxLUNmLjHtN = source.fkEwyowpQQKzBaGTBxLUNmLjHtN;
			vnEdenUwZllTYBycKwkNdiMcIIS = source.vnEdenUwZllTYBycKwkNdiMcIIS;
			FMlFscZHgEaroOimxUJfmCwhSSB = source.FMlFscZHgEaroOimxUJfmCwhSSB;
			oiqgKVfwRJIXctXeLPpJwwVgman = source.oiqgKVfwRJIXctXeLPpJwwVgman;
			qxoYaUQyNIsvDIFklnqXHPrHJLd = source.qxoYaUQyNIsvDIFklnqXHPrHJLd;
			iDCCUtfTWxxiRkkzZhazaAppvzo = source.iDCCUtfTWxxiRkkzZhazaAppvzo;
			yBWjkrHKbDlkjegyONinAthRElAh = source.yBWjkrHKbDlkjegyONinAthRElAh;
			zvVrLCNqeWrMDfcLTvPLsgsTFBT = source.zvVrLCNqeWrMDfcLTvPLsgsTFBT;
			YfXbVhhWcSuyNKacqoMLhXaiabR = source.YfXbVhhWcSuyNKacqoMLhXaiabR;
		}
	}
}
