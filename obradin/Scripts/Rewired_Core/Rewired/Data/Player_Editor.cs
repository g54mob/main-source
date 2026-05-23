using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
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
					return _categoryId;
				}
				internal set
				{
					_categoryId = value;
				}
			}

			public int layoutId
			{
				get
				{
					return _layoutId;
				}
				internal set
				{
					_layoutId = value;
				}
			}

			public bool enabled
			{
				get
				{
					return _enabled;
				}
				internal set
				{
					_enabled = value;
				}
			}

			public Mapping()
			{
				Clear();
			}

			public Mapping(bool enabled, int categoryId, int layoutId)
			{
				while (true)
				{
					int num = 1776701804;
					while (true)
					{
						switch (num ^ 0x69E6516D)
						{
						case 2:
							break;
						case 1:
							goto IL_0024;
						default:
							_layoutId = layoutId;
							return;
						}
						break;
						IL_0024:
						_enabled = enabled;
						_categoryId = categoryId;
						num = 1776701805;
					}
				}
			}

			public void Clear()
			{
				_categoryId = 0;
				while (true)
				{
					int num = -1490803029;
					while (true)
					{
						switch (num ^ -1490803030)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							_enabled = true;
							return;
						}
						break;
						IL_0025:
						_layoutId = 0;
						num = -1490803030;
					}
				}
			}

			public Mapping Clone()
			{
				return new Mapping(_enabled, _categoryId, _layoutId);
			}

			internal LbyXjOIzPbSKtwNeSiJafzWOdxVB CviVPMMcUnBBALxnriLTePqaZlAh()
			{
				return new LbyXjOIzPbSKtwNeSiJafzWOdxVB(_categoryId, _layoutId, _enabled);
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerMapLayoutManagerSettings : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _enabled = true;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			private bool _loadFromUserDataStore = true;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			private List<RuleSetMapping> _ruleSets;

			public bool enabled
			{
				get
				{
					return _enabled;
				}
				set
				{
					_enabled = value;
				}
			}

			public bool loadFromUserDataStore
			{
				get
				{
					return _loadFromUserDataStore;
				}
				set
				{
					_loadFromUserDataStore = value;
				}
			}

			public List<RuleSetMapping> ruleSets
			{
				get
				{
					return _ruleSets;
				}
				set
				{
					_ruleSets = value ?? (_ruleSets = new List<RuleSetMapping>());
				}
			}

			public ControllerMapLayoutManagerSettings()
			{
				_ruleSets = new List<RuleSetMapping>();
				_enabled = true;
				_loadFromUserDataStore = true;
			}

			public ControllerMapLayoutManagerSettings(ControllerMapLayoutManagerSettings source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				_enabled = source._enabled;
				_loadFromUserDataStore = source._loadFromUserDataStore;
				_ruleSets = MiscTools.DeepClone(source._ruleSets) ?? new List<RuleSetMapping>();
			}

			internal ControllerMapLayoutManager.StartingSettings RDaWziREIKhWZlbRtZbglsspeWG()
			{
				return new ControllerMapLayoutManager.StartingSettings(_enabled, _loadFromUserDataStore, IsnxUxNdJfqpaVAralabxmofesy());
			}

			private IBXCWQaiuXApgrsayPNtUSrFqVH[] IsnxUxNdJfqpaVAralabxmofesy()
			{
				List<IBXCWQaiuXApgrsayPNtUSrFqVH> list = new List<IBXCWQaiuXApgrsayPNtUSrFqVH>();
				int num = ((_ruleSets != null) ? _ruleSets.Count : 0);
				int num2 = 0;
				while (num2 < num)
				{
					while (true)
					{
						int num3;
						int num4;
						if (_ruleSets[num2] == null)
						{
							num3 = -480686703;
							num4 = num3;
						}
						else
						{
							num3 = -480686698;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ -480686702)
							{
							case 0:
								num3 = -480686701;
								continue;
							case 1:
								break;
							case 3:
								num2++;
								num3 = -480686704;
								continue;
							case 4:
								list.Add(_ruleSets[num2].hiiFXAapUtNxBcWpELWWwSzbaAf());
								num3 = -480686703;
								continue;
							default:
								goto end_IL_0047;
							}
							break;
						}
						continue;
						end_IL_0047:
						break;
					}
				}
				return list.ToArray();
			}

			object IDeepCloneable.DeepClone()
			{
				return new ControllerMapLayoutManagerSettings(this);
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerMapEnablerSettings : IDeepCloneable
		{
			[CustomObfuscation(rename = false)]
			[SerializeField]
			private bool _enabled = true;

			[SerializeField]
			[CustomObfuscation(rename = false)]
			private List<RuleSetMapping> _ruleSets;

			public bool enabled
			{
				get
				{
					return _enabled;
				}
				set
				{
					_enabled = value;
				}
			}

			public List<RuleSetMapping> ruleSets
			{
				get
				{
					return _ruleSets;
				}
				set
				{
					_ruleSets = value ?? (_ruleSets = new List<RuleSetMapping>());
				}
			}

			public ControllerMapEnablerSettings()
			{
				while (true)
				{
					int num = 1757503600;
					while (true)
					{
						switch (num ^ 0x68C16071)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002b;
						case 0:
							return;
						}
						break;
						IL_002b:
						_ruleSets = new List<RuleSetMapping>();
						_enabled = true;
						num = 1757503601;
					}
				}
			}

			public ControllerMapEnablerSettings(ControllerMapEnablerSettings source)
			{
				while (true)
				{
					switch (0x77E158BD ^ 0x77E158BF)
					{
					case 0:
						continue;
					case 2:
						if (source == null)
						{
							throw new ArgumentNullException("source");
						}
						break;
					}
					break;
				}
				_enabled = source._enabled;
				_ruleSets = MiscTools.DeepClone(source._ruleSets) ?? new List<RuleSetMapping>();
			}

			internal ControllerMapEnabler.JUZYTaWfnqZOjNkWvtfvZbKqPkC RDaWziREIKhWZlbRtZbglsspeWG()
			{
				return new ControllerMapEnabler.JUZYTaWfnqZOjNkWvtfvZbKqPkC(_enabled, IsnxUxNdJfqpaVAralabxmofesy());
			}

			private IBXCWQaiuXApgrsayPNtUSrFqVH[] IsnxUxNdJfqpaVAralabxmofesy()
			{
				List<IBXCWQaiuXApgrsayPNtUSrFqVH> list = new List<IBXCWQaiuXApgrsayPNtUSrFqVH>();
				int num = ((_ruleSets != null) ? _ruleSets.Count : 0);
				int num2 = 0;
				while (num2 < num)
				{
					while (true)
					{
						int num3;
						if (_ruleSets[num2] != null)
						{
							list.Add(_ruleSets[num2].hiiFXAapUtNxBcWpELWWwSzbaAf());
							num3 = -1754031536;
							goto IL_0026;
						}
						goto IL_006f;
						IL_0026:
						while (true)
						{
							switch (num3 ^ -1754031533)
							{
							case 0:
								num3 = -1754031534;
								continue;
							case 1:
								break;
							case 3:
								goto IL_006f;
							default:
								goto end_IL_0043;
							}
							break;
						}
						continue;
						IL_006f:
						num2++;
						num3 = -1754031535;
						goto IL_0026;
						continue;
						end_IL_0043:
						break;
					}
				}
				return list.ToArray();
			}

			object IDeepCloneable.DeepClone()
			{
				return new ControllerMapEnablerSettings(this);
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

			[CustomObfuscation(rename = false)]
			[SerializeField]
			private int _id;

			public int id
			{
				get
				{
					return _id;
				}
				internal set
				{
					_id = value;
				}
			}

			public bool enabled
			{
				get
				{
					return _enabled;
				}
				internal set
				{
					_enabled = value;
				}
			}

			public RuleSetMapping()
			{
				Clear();
			}

			public RuleSetMapping(RuleSetMapping source)
				: this()
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				_enabled = source._enabled;
				_id = source._id;
			}

			public RuleSetMapping(bool enabled, int id)
			{
				_enabled = enabled;
				_id = id;
			}

			public void Clear()
			{
				_id = 0;
				_enabled = true;
			}

			public RuleSetMapping Clone()
			{
				return new RuleSetMapping(_enabled, _id);
			}

			internal IBXCWQaiuXApgrsayPNtUSrFqVH hiiFXAapUtNxBcWpELWWwSzbaAf()
			{
				return new IBXCWQaiuXApgrsayPNtUSrFqVH(_id, _enabled);
			}

			object IDeepCloneable.DeepClone()
			{
				return new RuleSetMapping(this);
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

			[CustomObfuscation(rename = false)]
			[SerializeField]
			private string _tag;

			public int sourceId
			{
				get
				{
					return _sourceId;
				}
				internal set
				{
					_sourceId = value;
				}
			}

			public string tag
			{
				get
				{
					return _tag;
				}
				internal set
				{
					_tag = value;
				}
			}

			public CreateControllerInfo()
			{
			}

			public CreateControllerInfo(int sourceId, string tag)
			{
				_sourceId = sourceId;
				_tag = tag;
			}

			public CreateControllerInfo(CreateControllerInfo source)
			{
				_sourceId = source._sourceId;
				_tag = source._tag;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _startPlaying;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Mapping> _defaultJoystickMaps;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Mapping> _defaultMouseMaps;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _assignKeyboardOnStart = true;

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
				return _id;
			}
			internal set
			{
				_id = value;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public string descriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			internal set
			{
				_descriptiveName = value;
			}
		}

		public bool startPlaying
		{
			get
			{
				return _startPlaying;
			}
			internal set
			{
				_startPlaying = value;
			}
		}

		public List<Mapping> defaultJoystickMaps
		{
			get
			{
				return _defaultJoystickMaps;
			}
			internal set
			{
				_defaultJoystickMaps = value;
			}
		}

		public List<Mapping> defaultMouseMaps
		{
			get
			{
				return _defaultMouseMaps;
			}
			internal set
			{
				_defaultMouseMaps = value;
			}
		}

		public List<Mapping> defaultKeyboardMaps
		{
			get
			{
				return _defaultKeyboardMaps;
			}
			internal set
			{
				_defaultKeyboardMaps = value;
			}
		}

		public List<Mapping> defaultCustomControllerMaps
		{
			get
			{
				return _defaultCustomControllerMaps;
			}
			internal set
			{
				_defaultCustomControllerMaps = value;
			}
		}

		public List<CreateControllerInfo> startingCustomControllers
		{
			get
			{
				return _startingCustomControllers;
			}
			internal set
			{
				_startingCustomControllers = value;
			}
		}

		public bool assignMouseOnStart
		{
			get
			{
				return _assignMouseOnStart;
			}
			internal set
			{
				_assignMouseOnStart = value;
			}
		}

		public bool assignKeyboardOnStart
		{
			get
			{
				return _assignKeyboardOnStart;
			}
			internal set
			{
				_assignKeyboardOnStart = value;
			}
		}

		public bool excludeFromControllerAutoAssignment
		{
			get
			{
				return _excludeFromControllerAutoAssignment;
			}
			internal set
			{
				_excludeFromControllerAutoAssignment = value;
			}
		}

		public ControllerMapLayoutManagerSettings controllerMapLayoutManagerSettings
		{
			get
			{
				return _controllerMapLayoutManagerSettings;
			}
			set
			{
				_controllerMapLayoutManagerSettings = value;
			}
		}

		public ControllerMapEnablerSettings controllerMapEnablerSettings
		{
			get
			{
				return _controllerMapEnablerSettings;
			}
			set
			{
				_controllerMapEnablerSettings = value;
			}
		}

		public Player_Editor()
		{
			while (true)
			{
				int num = 1067498061;
				while (true)
				{
					switch (num ^ 0x3FA0BA4C)
					{
					case 3:
						break;
					case 1:
						_defaultKeyboardMaps = new List<Mapping>();
						num = 1067498060;
						continue;
					case 0:
						_defaultJoystickMaps = new List<Mapping>();
						_defaultMouseMaps = new List<Mapping>();
						_defaultCustomControllerMaps = new List<Mapping>();
						num = 1067498062;
						continue;
					case 2:
						_startingCustomControllers = new List<CreateControllerInfo>();
						_excludeFromControllerAutoAssignment = false;
						_controllerMapLayoutManagerSettings = new ControllerMapLayoutManagerSettings();
						num = 1067498056;
						continue;
					default:
						_controllerMapEnablerSettings = new ControllerMapEnablerSettings();
						return;
					}
					break;
				}
			}
		}

		public Player_Editor(Player_Editor source)
		{
			_id = source._id;
			_name = source._name;
			_descriptiveName = source._descriptiveName;
			_startPlaying = source._startPlaying;
			_defaultJoystickMaps = new List<Mapping>();
			if (source._defaultJoystickMaps != null)
			{
				for (int i = 0; i < source._defaultJoystickMaps.Count; i++)
				{
					_defaultJoystickMaps.Add(source._defaultJoystickMaps[i].Clone());
				}
			}
			_defaultKeyboardMaps = new List<Mapping>();
			if (source._defaultKeyboardMaps != null)
			{
				for (int j = 0; j < source._defaultKeyboardMaps.Count; j++)
				{
					_defaultKeyboardMaps.Add(source._defaultKeyboardMaps[j].Clone());
				}
			}
			_defaultMouseMaps = new List<Mapping>();
			if (source._defaultMouseMaps != null)
			{
				for (int k = 0; k < source._defaultMouseMaps.Count; k++)
				{
					_defaultMouseMaps.Add(source._defaultMouseMaps[k].Clone());
				}
			}
			_defaultCustomControllerMaps = new List<Mapping>();
			if (source._defaultCustomControllerMaps != null)
			{
				for (int l = 0; l < source._defaultCustomControllerMaps.Count; l++)
				{
					_defaultCustomControllerMaps.Add(source._defaultCustomControllerMaps[l].Clone());
				}
			}
			_startingCustomControllers = new List<CreateControllerInfo>();
			if (source._startingCustomControllers != null)
			{
				for (int m = 0; m < source._startingCustomControllers.Count; m++)
				{
					_startingCustomControllers.Add(new CreateControllerInfo(source._startingCustomControllers[m]));
				}
			}
			_controllerMapLayoutManagerSettings = MiscTools.DeepClone(source._controllerMapLayoutManagerSettings) ?? new ControllerMapLayoutManagerSettings();
			_controllerMapEnablerSettings = MiscTools.DeepClone(source._controllerMapEnablerSettings) ?? new ControllerMapEnablerSettings();
			_assignMouseOnStart = source._assignMouseOnStart;
			_assignKeyboardOnStart = source._assignKeyboardOnStart;
			_excludeFromControllerAutoAssignment = source._excludeFromControllerAutoAssignment;
		}

		public Player_Editor Clone()
		{
			return new Player_Editor(this);
		}

		internal LDQPFPXQyLIyqtAUvmVCEbFpcBq SycpkkLkUewaZPGUqaerYpMkdXJB()
		{
			LbyXjOIzPbSKtwNeSiJafzWOdxVB[] array = null;
			LbyXjOIzPbSKtwNeSiJafzWOdxVB[] array2 = default(LbyXjOIzPbSKtwNeSiJafzWOdxVB[]);
			int num2 = default(int);
			LbyXjOIzPbSKtwNeSiJafzWOdxVB[] array4 = default(LbyXjOIzPbSKtwNeSiJafzWOdxVB[]);
			int num3 = default(int);
			int num6 = default(int);
			LbyXjOIzPbSKtwNeSiJafzWOdxVB[] array3 = default(LbyXjOIzPbSKtwNeSiJafzWOdxVB[]);
			int num5 = default(int);
			while (true)
			{
				int num = 843932939;
				while (true)
				{
					switch (num ^ 0x324D6502)
					{
					case 12:
						break;
					case 4:
						array2[num2] = _defaultKeyboardMaps[num2].CviVPMMcUnBBALxnriLTePqaZlAh();
						num2++;
						num = 843932944;
						continue;
					case 13:
						array4[num3] = _defaultCustomControllerMaps[num3].CviVPMMcUnBBALxnriLTePqaZlAh();
						num3++;
						num = 843932941;
						continue;
					case 2:
						array[num6] = _defaultJoystickMaps[num6].CviVPMMcUnBBALxnriLTePqaZlAh();
						num6++;
						num = 843932931;
						continue;
					case 18:
					{
						int num11;
						if (num2 < _defaultKeyboardMaps.Count)
						{
							num = 843932934;
							num11 = num;
						}
						else
						{
							num = 843932936;
							num11 = num;
						}
						continue;
					}
					case 5:
					{
						int num9;
						if (_defaultCustomControllerMaps != null)
						{
							num = 843932933;
							num9 = num;
						}
						else
						{
							num = 843932938;
							num9 = num;
						}
						continue;
					}
					case 17:
						num = 843932931;
						continue;
					case 14:
						array2 = new LbyXjOIzPbSKtwNeSiJafzWOdxVB[_defaultKeyboardMaps.Count];
						num = 843932937;
						continue;
					case 10:
						array3 = null;
						if (_defaultMouseMaps != null)
						{
							array3 = new LbyXjOIzPbSKtwNeSiJafzWOdxVB[_defaultMouseMaps.Count];
							num5 = 0;
							num = 843932932;
							continue;
						}
						goto case 16;
					case 6:
					{
						int num10;
						if (num5 < _defaultMouseMaps.Count)
						{
							num = 843932930;
							num10 = num;
						}
						else
						{
							num = 843932946;
							num10 = num;
						}
						continue;
					}
					case 9:
						if (_defaultJoystickMaps != null)
						{
							array = new LbyXjOIzPbSKtwNeSiJafzWOdxVB[_defaultJoystickMaps.Count];
							num6 = 0;
							num = 843932947;
							continue;
						}
						goto case 3;
					case 0:
						array3[num5] = _defaultMouseMaps[num5].CviVPMMcUnBBALxnriLTePqaZlAh();
						num5++;
						num = 843932932;
						continue;
					case 1:
					{
						int num7;
						if (num6 < _defaultJoystickMaps.Count)
						{
							num = 843932928;
							num7 = num;
						}
						else
						{
							num = 843932929;
							num7 = num;
						}
						continue;
					}
					case 7:
						array4 = new LbyXjOIzPbSKtwNeSiJafzWOdxVB[_defaultCustomControllerMaps.Count];
						num3 = 0;
						num = 843932941;
						continue;
					case 15:
					{
						int num4;
						if (num3 < _defaultCustomControllerMaps.Count)
						{
							num = 843932943;
							num4 = num;
						}
						else
						{
							num = 843932938;
							num4 = num;
						}
						continue;
					}
					case 16:
						array4 = null;
						num = 843932935;
						continue;
					case 3:
					{
						array2 = null;
						int num8;
						if (_defaultKeyboardMaps == null)
						{
							num = 843932936;
							num8 = num;
						}
						else
						{
							num = 843932940;
							num8 = num;
						}
						continue;
					}
					case 11:
						num2 = 0;
						num = 843932944;
						continue;
					default:
						return new LDQPFPXQyLIyqtAUvmVCEbFpcBq(array, array2, array3, array4);
					}
					break;
				}
			}
		}
	}
}
