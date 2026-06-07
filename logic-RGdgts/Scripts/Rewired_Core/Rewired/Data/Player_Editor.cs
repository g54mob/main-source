using System;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	public sealed class Player_Editor
	{
		[Serializable]
		public sealed class Mapping
		{
			[SerializeField]
			[CustomObfuscation]
			private bool _enabled;

			[CustomObfuscation]
			[SerializeField]
			private int _categoryId;

			[CustomObfuscation]
			[SerializeField]
			private int _layoutId;

			public int categoryId
			{
				get
				{
					return 0;
				}
				internal set
				{
				}
			}

			public int layoutId
			{
				get
				{
					return 0;
				}
				internal set
				{
				}
			}

			public bool enabled
			{
				get
				{
					return false;
				}
				internal set
				{
				}
			}

			public Mapping()
			{
			}

			public Mapping(bool P_0, int P_1, int P_2)
			{
			}

			public void Clear()
			{
			}

			public Mapping Clone()
			{
				return null;
			}

			internal fltsBxmjXaFeMfcWglOfHGHvtAQsA wEbSdzigWkbvxeLDTZQAhupBlEHeA()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class ControllerMapLayoutManagerSettings : IDeepCloneable
		{
			[CustomObfuscation]
			[SerializeField]
			private bool _enabled;

			[CustomObfuscation]
			[SerializeField]
			private bool _loadFromUserDataStore;

			[SerializeField]
			[CustomObfuscation]
			private List<RuleSetMapping> _ruleSets;

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool loadFromUserDataStore
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public List<RuleSetMapping> ruleSets
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ControllerMapLayoutManagerSettings()
			{
			}

			public ControllerMapLayoutManagerSettings(ControllerMapLayoutManagerSettings P_0)
			{
			}

			internal ControllerMapLayoutManager.nwmaXXBRLHdsFSHrcaeHCCJdihJCc vtjZXZpyCBGschetPSgbKdzUOHNT()
			{
				return null;
			}

			private qmEcFrQmpjkfExHMGEuMliRmNVKH[] aHyvaApLVqeTXLzJMqhuGzxGiBtm()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class ControllerMapEnablerSettings : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation]
			private bool _enabled;

			[CustomObfuscation]
			[SerializeField]
			private List<RuleSetMapping> _ruleSets;

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public List<RuleSetMapping> ruleSets
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public ControllerMapEnablerSettings()
			{
			}

			public ControllerMapEnablerSettings(ControllerMapEnablerSettings P_0)
			{
			}

			internal ControllerMapEnabler.bfKxbNaTbdokMFkgReyogCBTNRVl vtjZXZpyCBGschetPSgbKdzUOHNT()
			{
				return null;
			}

			private qmEcFrQmpjkfExHMGEuMliRmNVKH[] aHyvaApLVqeTXLzJMqhuGzxGiBtm()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class RuleSetMapping : IDeepCloneable
		{
			[CustomObfuscation]
			[SerializeField]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation]
			private int _id;

			public int id
			{
				get
				{
					return 0;
				}
				internal set
				{
				}
			}

			public bool enabled
			{
				get
				{
					return false;
				}
				internal set
				{
				}
			}

			public RuleSetMapping()
			{
			}

			public RuleSetMapping(RuleSetMapping P_0)
			{
			}

			public RuleSetMapping(bool P_0, int P_1)
			{
			}

			public void Clear()
			{
			}

			public RuleSetMapping Clone()
			{
				return null;
			}

			internal qmEcFrQmpjkfExHMGEuMliRmNVKH RsljwjGGAgziyyfHkMsFHHwMaRkM()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class CreateControllerInfo
		{
			[CustomObfuscation]
			[SerializeField]
			private int _sourceId;

			[CustomObfuscation]
			[SerializeField]
			private string _tag;

			public int sourceId
			{
				get
				{
					return 0;
				}
				internal set
				{
				}
			}

			public string tag
			{
				get
				{
					return null;
				}
				internal set
				{
				}
			}

			public CreateControllerInfo()
			{
			}

			public CreateControllerInfo(int P_0, string P_1)
			{
			}

			public CreateControllerInfo(CreateControllerInfo P_0)
			{
			}
		}

		[CustomObfuscation]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _descriptiveName;

		[CustomObfuscation]
		[SerializeField]
		private bool _startPlaying;

		[CustomObfuscation]
		[SerializeField]
		private List<Mapping> _defaultJoystickMaps;

		[CustomObfuscation]
		[SerializeField]
		private List<Mapping> _defaultMouseMaps;

		[CustomObfuscation]
		[SerializeField]
		private List<Mapping> _defaultKeyboardMaps;

		[CustomObfuscation]
		[SerializeField]
		private List<Mapping> _defaultCustomControllerMaps;

		[SerializeField]
		[CustomObfuscation]
		private List<CreateControllerInfo> _startingCustomControllers;

		[CustomObfuscation]
		[SerializeField]
		private bool _assignMouseOnStart;

		[CustomObfuscation]
		[SerializeField]
		private bool _assignKeyboardOnStart;

		[SerializeField]
		[CustomObfuscation]
		private bool _excludeFromControllerAutoAssignment;

		[CustomObfuscation]
		[SerializeField]
		private ControllerMapLayoutManagerSettings _controllerMapLayoutManagerSettings;

		[SerializeField]
		[CustomObfuscation]
		private ControllerMapEnablerSettings _controllerMapEnablerSettings;

		public int id
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public string name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string descriptiveName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool startPlaying
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public List<Mapping> defaultJoystickMaps
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public List<Mapping> defaultMouseMaps
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public List<Mapping> defaultKeyboardMaps
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public List<Mapping> defaultCustomControllerMaps
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public List<CreateControllerInfo> startingCustomControllers
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool assignMouseOnStart
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public bool assignKeyboardOnStart
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public bool excludeFromControllerAutoAssignment
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public ControllerMapLayoutManagerSettings controllerMapLayoutManagerSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ControllerMapEnablerSettings controllerMapEnablerSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Player_Editor()
		{
		}

		public Player_Editor(Player_Editor P_0)
		{
		}

		public Player_Editor Clone()
		{
			return null;
		}

		internal rTFRhglKgUYuRjbuHfpVdAGUmulr qnhFaJbEXxChcZiwGfOafxXBabSK()
		{
			return null;
		}
	}
}
