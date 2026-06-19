using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool ayyzCfqLFWyRhbIDFyPHPcAYGCW;

		private int ivfdKpZALpQIAdtIdHmkpPFkwfq;

		private int hVLcwKGZNRwDcwqMxzBMRgucbhPa;

		private string EXtqjAYEwIzvCInREcHyTftYYm;

		private ControllerType beJOxBqDtyzXnNjzgKyRzARzFSQ;

		private ControllerElementType yWNDZKfljBHzdFXVgCeuIlnzKfx;

		private int ofrrxjPHuwNabkrGucUvSPRIAGB;

		private Pole DiUjdyRCeufrjgUjoPYNVzhfsDZ;

		private string wiMBnBoIJbBnniESRANgWJJmDkyg;

		private int aKTKfMYcYdTWZLyYfpZoZfzZGQT;

		private KeyCode njXCrWjjPsBpeBQXYJvRrcFBebv;

		public bool success
		{
			get
			{
				return ayyzCfqLFWyRhbIDFyPHPcAYGCW;
			}
			internal set
			{
				ayyzCfqLFWyRhbIDFyPHPcAYGCW = value;
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

		public string controllerName
		{
			get
			{
				return EXtqjAYEwIzvCInREcHyTftYYm;
			}
			internal set
			{
				EXtqjAYEwIzvCInREcHyTftYYm = value;
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

		public int elementIndex
		{
			get
			{
				return ofrrxjPHuwNabkrGucUvSPRIAGB;
			}
			internal set
			{
				ofrrxjPHuwNabkrGucUvSPRIAGB = value;
			}
		}

		public Pole axisPole
		{
			get
			{
				return DiUjdyRCeufrjgUjoPYNVzhfsDZ;
			}
			internal set
			{
				DiUjdyRCeufrjgUjoPYNVzhfsDZ = value;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return wiMBnBoIJbBnniESRANgWJJmDkyg;
			}
			internal set
			{
				wiMBnBoIJbBnniESRANgWJJmDkyg = value;
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

		public KeyCode keyboardKey
		{
			get
			{
				return njXCrWjjPsBpeBQXYJvRrcFBebv;
			}
			internal set
			{
				njXCrWjjPsBpeBQXYJvRrcFBebv = value;
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
				if (!ReInput.USfldASbLlPourbEtKfoowSEGgo.EJgmhObMJAnIfOIVroEKcjegjXB(ivfdKpZALpQIAdtIdHmkpPFkwfq))
				{
					return null;
				}
				return ReInput.USfldASbLlPourbEtKfoowSEGgo.FgvPueKchdieOiiAPcILDqNkmwJD(ivfdKpZALpQIAdtIdHmkpPFkwfq);
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

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return controller?.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			}
		}

		internal ControllerPollingInfo(bool success, int playerId, int controllerId, string controllerName, ControllerType controllerType, ControllerElementType elementType, int elementIndex, Pole axisPole, string elementIdentifierName, int elementIdentifierId, KeyCode keyboardKey)
		{
			ayyzCfqLFWyRhbIDFyPHPcAYGCW = success;
			ivfdKpZALpQIAdtIdHmkpPFkwfq = playerId;
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = controllerId;
			EXtqjAYEwIzvCInREcHyTftYYm = controllerName;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = controllerType;
			yWNDZKfljBHzdFXVgCeuIlnzKfx = elementType;
			ofrrxjPHuwNabkrGucUvSPRIAGB = elementIndex;
			DiUjdyRCeufrjgUjoPYNVzhfsDZ = axisPole;
			wiMBnBoIJbBnniESRANgWJJmDkyg = elementIdentifierName;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = elementIdentifierId;
			njXCrWjjPsBpeBQXYJvRrcFBebv = keyboardKey;
		}

		internal ControllerPollingInfo(ControllerPollingInfo source)
		{
			ayyzCfqLFWyRhbIDFyPHPcAYGCW = source.ayyzCfqLFWyRhbIDFyPHPcAYGCW;
			ivfdKpZALpQIAdtIdHmkpPFkwfq = source.ivfdKpZALpQIAdtIdHmkpPFkwfq;
			hVLcwKGZNRwDcwqMxzBMRgucbhPa = source.hVLcwKGZNRwDcwqMxzBMRgucbhPa;
			EXtqjAYEwIzvCInREcHyTftYYm = source.EXtqjAYEwIzvCInREcHyTftYYm;
			beJOxBqDtyzXnNjzgKyRzARzFSQ = source.beJOxBqDtyzXnNjzgKyRzARzFSQ;
			yWNDZKfljBHzdFXVgCeuIlnzKfx = source.yWNDZKfljBHzdFXVgCeuIlnzKfx;
			ofrrxjPHuwNabkrGucUvSPRIAGB = source.ofrrxjPHuwNabkrGucUvSPRIAGB;
			DiUjdyRCeufrjgUjoPYNVzhfsDZ = source.DiUjdyRCeufrjgUjoPYNVzhfsDZ;
			wiMBnBoIJbBnniESRANgWJJmDkyg = source.wiMBnBoIJbBnniESRANgWJJmDkyg;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = source.aKTKfMYcYdTWZLyYfpZoZfzZGQT;
			njXCrWjjPsBpeBQXYJvRrcFBebv = source.njXCrWjjPsBpeBQXYJvRrcFBebv;
		}

		internal static ControllerPollingInfo gpfCsRFuwmhJyfJraYsxIMhInTuX()
		{
			return new ControllerPollingInfo(success: false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
