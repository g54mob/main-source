using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class Player_Editor
	{
		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class Mapping
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _categoryId;

			[SerializeField]
			[CustomObfuscation(rename = false)]
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

			internal RaNQuZbfZxMLFpVAcoFsKDCVHzhCA wUzyggcaAdnkgNpOXOWRtYrqZtHE()
			{
				return null;
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerMapLayoutManagerSettings : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _loadFromUserDataStore;

			[SerializeField]
			[CustomObfuscation(rename = false)]
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

			internal ControllerMapLayoutManager.HJUjelWIXSAXWIJzmDjEJSCOpYgxA DCqEtOpFAnihcMHCmarRaTPcgIUlA()
			{
				return null;
			}

			private SDwFRPBdsaePJyhGUxPLpuCUKebq[] tkOQWKtteNaCzUjghgxLglftOhIX()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerMapEnablerSettings : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation(rename = false)]
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

			internal ControllerMapEnabler.XTwrIptmbwHBVYncTDxfdoWrHeqsA FfZEpnWmAtykoDGvZseEkFgZjHeM()
			{
				return null;
			}

			private SDwFRPBdsaePJyhGUxPLpuCUKebq[] khhtZBsoZwhVEpSGfDlIiVkyyKfz()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class RuleSetMapping : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation(rename = false)]
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

			internal SDwFRPBdsaePJyhGUxPLpuCUKebq smJsxmtBVVXbNkxvEkgGGQZAXfGF()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class CreateControllerInfo
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private int _sourceId;

			[SerializeField]
			[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _startPlaying;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Mapping> _defaultJoystickMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Mapping> _defaultMouseMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Mapping> _defaultKeyboardMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Mapping> _defaultCustomControllerMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CreateControllerInfo> _startingCustomControllers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _assignMouseOnStart;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _assignKeyboardOnStart;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _excludeFromControllerAutoAssignment;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerMapLayoutManagerSettings _controllerMapLayoutManagerSettings;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public string key
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

		internal FEdxCQqwkVWtKwFsBQcMhWZcRKMK fDJnSeQkfgbQYgIyWSKdsCdUcMtgA()
		{
			return null;
		}
	}
}
