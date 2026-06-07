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

			[SerializeField]
			[CustomObfuscation]
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

			public Mapping(bool enabled, int categoryId, int layoutId)
			{
			}

			public void Clear()
			{
			}

			public Mapping Clone()
			{
				return null;
			}

			internal wcMoGDQtbahdosEotcJAidJHHxLH pwWEUBMacawpPBnwEVDbIFbntVO()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class ControllerMapLayoutManagerSettings : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation]
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

			public ControllerMapLayoutManagerSettings(ControllerMapLayoutManagerSettings source)
			{
			}

			internal ControllerMapLayoutManager.StartingSettings sxGsTrROyNvdKtfZIgzOeOfceaU()
			{
				return null;
			}

			private xwlhFTsQYtjrmxDuPWBtZARKTuD[] nlBTZaRchsMmnBJxHDyTeNbeJiy()
			{
				return null;
			}

			private object KPfRFRKLWxAatcPaDDQxiAPwmfHV()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in KPfRFRKLWxAatcPaDDQxiAPwmfHV
				return this.KPfRFRKLWxAatcPaDDQxiAPwmfHV();
			}
		}

		[Serializable]
		public sealed class ControllerMapEnablerSettings : IDeepCloneable
		{
			[CustomObfuscation]
			[SerializeField]
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

			public ControllerMapEnablerSettings(ControllerMapEnablerSettings source)
			{
			}

			internal ControllerMapEnabler.qIjMFrOnBtzCkPNWSvzPUfZdmEE sxGsTrROyNvdKtfZIgzOeOfceaU()
			{
				return null;
			}

			private xwlhFTsQYtjrmxDuPWBtZARKTuD[] nlBTZaRchsMmnBJxHDyTeNbeJiy()
			{
				return null;
			}

			private object KPfRFRKLWxAatcPaDDQxiAPwmfHV()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in KPfRFRKLWxAatcPaDDQxiAPwmfHV
				return this.KPfRFRKLWxAatcPaDDQxiAPwmfHV();
			}
		}

		[Serializable]
		public sealed class RuleSetMapping : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation]
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

			public RuleSetMapping(RuleSetMapping source)
			{
			}

			public RuleSetMapping(bool enabled, int id)
			{
			}

			public void Clear()
			{
			}

			public RuleSetMapping Clone()
			{
				return null;
			}

			internal xwlhFTsQYtjrmxDuPWBtZARKTuD EOIvMNyncqukSybbrlDyfqwmxsn()
			{
				return null;
			}

			private object KPfRFRKLWxAatcPaDDQxiAPwmfHV()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in KPfRFRKLWxAatcPaDDQxiAPwmfHV
				return this.KPfRFRKLWxAatcPaDDQxiAPwmfHV();
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

			public CreateControllerInfo(int sourceId, string tag)
			{
			}

			public CreateControllerInfo(CreateControllerInfo source)
			{
			}
		}

		[SerializeField]
		[CustomObfuscation]
		private int _id;

		[CustomObfuscation]
		[SerializeField]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation]
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

		[SerializeField]
		[CustomObfuscation]
		private List<Mapping> _defaultCustomControllerMaps;

		[CustomObfuscation]
		[SerializeField]
		private List<CreateControllerInfo> _startingCustomControllers;

		[SerializeField]
		[CustomObfuscation]
		private bool _assignMouseOnStart;

		[CustomObfuscation]
		[SerializeField]
		private bool _assignKeyboardOnStart;

		[SerializeField]
		[CustomObfuscation]
		private bool _excludeFromControllerAutoAssignment;

		[SerializeField]
		[CustomObfuscation]
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

		public Player_Editor(Player_Editor source)
		{
		}

		public Player_Editor Clone()
		{
			return null;
		}

		internal cXcSgAPIRCJFlxOWGaCyRbGoPJi pxMLqlJIctSZWRcINfmDJoNxEXFi()
		{
			return null;
		}
	}
}
