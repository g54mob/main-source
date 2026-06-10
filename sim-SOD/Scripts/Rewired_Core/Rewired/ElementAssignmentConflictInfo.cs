using UnityEngine;

namespace Rewired
{
	public struct ElementAssignmentConflictInfo
	{
		private bool wmhMRDZuZcnIGjFoJCjpcwzszNl;

		private bool tdHjNHWEjBUUaeWdpbaVkErDiPi;

		private int CvnGUgdDPoraRVDOSPLmFGFLbYT;

		private ControllerType BUBbyESKvfplkrdvXFKZHEBGbit;

		private int LvNigBeOHUHpbkESSgiOurkLsUwi;

		private int dXkoGKhCNvfyBcHAfOQayoaEeShn;

		private int MnrTvqNiotIDukGPYRGesVXwgLR;

		private ControllerElementType KBXbDLkLbEVjqjnHFWngPgnQczYe;

		private int YcDcbHqQMwtgQxoISZasthfuQlm;

		private KeyCode LqYzeknTZrTxyuRrNGrSguecMLt;

		private ModifierKeyFlags gvUmwPTqhvWmgTUEohkItzJVUmh;

		private int CijfVweIqbvViXAEzqkELDhcHIR;

		public bool isConflict
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public bool isUserAssignable
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public int playerId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return default(ControllerType);
			}
			internal set
			{
			}
		}

		public int controllerId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public int controllerMapId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public int elementMapId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return default(ControllerElementType);
			}
			internal set
			{
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return default(KeyCode);
			}
			internal set
			{
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return default(ModifierKeyFlags);
			}
			internal set
			{
			}
		}

		public int actionId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public Player player => null;

		public InputAction action => null;

		public Controller controller => null;

		public ControllerMap controllerMap => null;

		public ControllerElementIdentifier elementIdentifier => null;

		public ActionElementMap elementMap => null;

		public string elementDisplayName => null;

		public ElementAssignmentConflictInfo(bool isConflict, bool isUserAssignable, int playerId, ControllerType controllerType, int controllerId, int controllerMapId, int elementMapId, int actionId, ControllerElementType elementType, int elementIdentifierId, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			wmhMRDZuZcnIGjFoJCjpcwzszNl = false;
			tdHjNHWEjBUUaeWdpbaVkErDiPi = false;
			CvnGUgdDPoraRVDOSPLmFGFLbYT = 0;
			BUBbyESKvfplkrdvXFKZHEBGbit = default(ControllerType);
			LvNigBeOHUHpbkESSgiOurkLsUwi = 0;
			dXkoGKhCNvfyBcHAfOQayoaEeShn = 0;
			MnrTvqNiotIDukGPYRGesVXwgLR = 0;
			KBXbDLkLbEVjqjnHFWngPgnQczYe = default(ControllerElementType);
			YcDcbHqQMwtgQxoISZasthfuQlm = 0;
			LqYzeknTZrTxyuRrNGrSguecMLt = default(KeyCode);
			gvUmwPTqhvWmgTUEohkItzJVUmh = default(ModifierKeyFlags);
			CijfVweIqbvViXAEzqkELDhcHIR = 0;
		}

		public ElementAssignmentConflictInfo(ElementAssignmentConflictInfo source)
		{
			wmhMRDZuZcnIGjFoJCjpcwzszNl = false;
			tdHjNHWEjBUUaeWdpbaVkErDiPi = false;
			CvnGUgdDPoraRVDOSPLmFGFLbYT = 0;
			BUBbyESKvfplkrdvXFKZHEBGbit = default(ControllerType);
			LvNigBeOHUHpbkESSgiOurkLsUwi = 0;
			dXkoGKhCNvfyBcHAfOQayoaEeShn = 0;
			MnrTvqNiotIDukGPYRGesVXwgLR = 0;
			KBXbDLkLbEVjqjnHFWngPgnQczYe = default(ControllerElementType);
			YcDcbHqQMwtgQxoISZasthfuQlm = 0;
			LqYzeknTZrTxyuRrNGrSguecMLt = default(KeyCode);
			gvUmwPTqhvWmgTUEohkItzJVUmh = default(ModifierKeyFlags);
			CijfVweIqbvViXAEzqkELDhcHIR = 0;
		}
	}
}
