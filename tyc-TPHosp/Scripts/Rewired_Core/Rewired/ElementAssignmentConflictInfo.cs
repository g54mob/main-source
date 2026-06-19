using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool AljXkCtqRlclVNDigAAjYgjBKyU;

		private bool DWPBzQhwIQMwJDKSMPSNjASguXP;

		private int ivfdKpZALpQIAdtIdHmkpPFkwfq;

		private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

		private int hVLcwKGZNRwDcwqMxzBMRgucbhPa;

		private int HbeUpLHdDckEQdUGQJtkQcilLlU;

		private int uFfCJyGjuxCoIeYKhsiUuSFnsDqy;

		private ControllerElementType yWNDZKfljBHzdFXVgCeuIlnzKfx;

		private int aKTKfMYcYdTWZLyYfpZoZfzZGQT;

		private KeyCode tZYyArRcRkLxjOshwQPUAfmDHaI;

		private ModifierKeyFlags QaOwhKpQpcMhpjcMVDDKPLBmZPQ;

		private int sRbRrhSYcsdTbzpQQADExfvLSkq;

		public bool isConflict
		{
			get
			{
				return AljXkCtqRlclVNDigAAjYgjBKyU;
			}
			internal set
			{
				AljXkCtqRlclVNDigAAjYgjBKyU = value;
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return DWPBzQhwIQMwJDKSMPSNjASguXP;
			}
			internal set
			{
				DWPBzQhwIQMwJDKSMPSNjASguXP = value;
			}
		}

		public int playerId
		{
			get
			{
				return ivfdKpZALpQIAdtIdHmkpPFkwfq;
			}
			internal set
			{
				ivfdKpZALpQIAdtIdHmkpPFkwfq = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return beJOxBqDtyzXnNjzgKyRzARzFSQ;
			}
			internal set
			{
				beJOxBqDtyzXnNjzgKyRzARzFSQ = value;
			}
		}

		public int controllerId
		{
			get
			{
				return hVLcwKGZNRwDcwqMxzBMRgucbhPa;
			}
			internal set
			{
				hVLcwKGZNRwDcwqMxzBMRgucbhPa = value;
			}
		}

		public int controllerMapId
		{
			get
			{
				return HbeUpLHdDckEQdUGQJtkQcilLlU;
			}
			internal set
			{
				HbeUpLHdDckEQdUGQJtkQcilLlU = value;
			}
		}

		public int elementMapId
		{
			get
			{
				return uFfCJyGjuxCoIeYKhsiUuSFnsDqy;
			}
			internal set
			{
				uFfCJyGjuxCoIeYKhsiUuSFnsDqy = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return yWNDZKfljBHzdFXVgCeuIlnzKfx;
			}
			internal set
			{
				yWNDZKfljBHzdFXVgCeuIlnzKfx = value;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return aKTKfMYcYdTWZLyYfpZoZfzZGQT;
			}
			internal set
			{
				aKTKfMYcYdTWZLyYfpZoZfzZGQT = value;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return tZYyArRcRkLxjOshwQPUAfmDHaI;
			}
			internal set
			{
				tZYyArRcRkLxjOshwQPUAfmDHaI = value;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return QaOwhKpQpcMhpjcMVDDKPLBmZPQ;
			}
			internal set
			{
				QaOwhKpQpcMhpjcMVDDKPLBmZPQ = value;
			}
		}

		public int actionId
		{
			get
			{
				return sRbRrhSYcsdTbzpQQADExfvLSkq;
			}
			internal set
			{
				sRbRrhSYcsdTbzpQQADExfvLSkq = value;
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
				return ReInput.players.GetPlayer(ivfdKpZALpQIAdtIdHmkpPFkwfq);
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
				return ReInput.mapping.GetAction(sRbRrhSYcsdTbzpQQADExfvLSkq);
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
				return ReInput.controllers.GetController(beJOxBqDtyzXnNjzgKyRzARzFSQ, hVLcwKGZNRwDcwqMxzBMRgucbhPa);
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
				return player.controllers.maps.GetMap(beJOxBqDtyzXnNjzgKyRzARzFSQ, hVLcwKGZNRwDcwqMxzBMRgucbhPa, HbeUpLHdDckEQdUGQJtkQcilLlU);
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
				return controller.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
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
				return controllerMap.GetElementMap(uFfCJyGjuxCoIeYKhsiUuSFnsDqy);
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (beJOxBqDtyzXnNjzgKyRzARzFSQ == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(tZYyArRcRkLxjOshwQPUAfmDHaI, QaOwhKpQpcMhpjcMVDDKPLBmZPQ);
				}
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				return elementIdentifierById.name;
			}
		}

		public ElementAssignmentConflictInfo(bool isConflict, bool isUserAssignable, int playerId, ControllerType controllerType, int controllerId, int controllerMapId, int elementMapId, int actionId, ControllerElementType elementType, int elementIdentifierId, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			AljXkCtqRlclVNDigAAjYgjBKyU = isConflict;
			DWPBzQhwIQMwJDKSMPSNjASguXP = isUserAssignable;
			ivfdKpZALpQIAdtIdHmkpPFkwfq = playerId;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = controllerType;
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = controllerId;
			HbeUpLHdDckEQdUGQJtkQcilLlU = controllerMapId;
			uFfCJyGjuxCoIeYKhsiUuSFnsDqy = elementMapId;
			sRbRrhSYcsdTbzpQQADExfvLSkq = actionId;
			yWNDZKfljBHzdFXVgCeuIlnzKfx = elementType;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = elementIdentifierId;
			tZYyArRcRkLxjOshwQPUAfmDHaI = keyCode;
			QaOwhKpQpcMhpjcMVDDKPLBmZPQ = modifierKeyFlags;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo source)
		{
			AljXkCtqRlclVNDigAAjYgjBKyU = source.AljXkCtqRlclVNDigAAjYgjBKyU;
			DWPBzQhwIQMwJDKSMPSNjASguXP = source.DWPBzQhwIQMwJDKSMPSNjASguXP;
			ivfdKpZALpQIAdtIdHmkpPFkwfq = source.ivfdKpZALpQIAdtIdHmkpPFkwfq;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = source.beJOxBqDtyzXnNjzgKyRzARzFSQ;
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = source.hVLcwKGZNRwDcwqMxzBMRgucbhPa;
			HbeUpLHdDckEQdUGQJtkQcilLlU = source.HbeUpLHdDckEQdUGQJtkQcilLlU;
			uFfCJyGjuxCoIeYKhsiUuSFnsDqy = source.uFfCJyGjuxCoIeYKhsiUuSFnsDqy;
			sRbRrhSYcsdTbzpQQADExfvLSkq = source.sRbRrhSYcsdTbzpQQADExfvLSkq;
			yWNDZKfljBHzdFXVgCeuIlnzKfx = source.yWNDZKfljBHzdFXVgCeuIlnzKfx;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = source.aKTKfMYcYdTWZLyYfpZoZfzZGQT;
			tZYyArRcRkLxjOshwQPUAfmDHaI = source.tZYyArRcRkLxjOshwQPUAfmDHaI;
			QaOwhKpQpcMhpjcMVDDKPLBmZPQ = source.QaOwhKpQpcMhpjcMVDDKPLBmZPQ;
		}
	}
}
