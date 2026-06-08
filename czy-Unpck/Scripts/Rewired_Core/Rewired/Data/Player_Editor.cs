using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Utils;
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
			[CustomObfuscation(rename = false)]
			[SerializeField]
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
				_enabled = enabled;
				_categoryId = categoryId;
				_layoutId = layoutId;
			}

			public void Clear()
			{
				_categoryId = 0;
				_layoutId = 0;
				_enabled = true;
			}

			public Mapping Clone()
			{
				return new Mapping(_enabled, _categoryId, _layoutId);
			}

			internal JLsTIMWCujkPTdzGdsSlKXwTnMp SpaplMYipxbuaSKPEuSEciQxjzi()
			{
				return new JLsTIMWCujkPTdzGdsSlKXwTnMp(_categoryId, _layoutId, _enabled);
			}
		}

		[Serializable]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ControllerMapLayoutManagerSettings : IDeepCloneable
		{
			[CustomObfuscation(rename = false)]
			[SerializeField]
			private bool _enabled = true;

			[CustomObfuscation(rename = false)]
			[SerializeField]
			private bool _loadFromUserDataStore = true;

			[CustomObfuscation(rename = false)]
			[SerializeField]
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
				while (true)
				{
					int num = 719701820;
					while (true)
					{
						switch (num ^ 0x2AE5C73D)
						{
						case 0:
							break;
						case 1:
							if (source != null)
							{
								goto IL_004b;
							}
							throw new ArgumentNullException("source");
						case 3:
							goto IL_004b;
						default:
							_ruleSets = MiscTools.DeepClone(source._ruleSets) ?? new List<RuleSetMapping>();
							return;
						}
						break;
						IL_004b:
						_enabled = source._enabled;
						_loadFromUserDataStore = source._loadFromUserDataStore;
						num = 719701823;
					}
				}
			}

			internal ControllerMapLayoutManager.StartingSettings VAqTUwRbJIeTdanGWWozEUgsoBs()
			{
				return new ControllerMapLayoutManager.StartingSettings(_enabled, _loadFromUserDataStore, CPdkArVgorHcUGVRXDnoMIKgkLQ());
			}

			private YHTAmSgoHymgTIiCLrqYNhoUTqdP[] CPdkArVgorHcUGVRXDnoMIKgkLQ()
			{
				List<YHTAmSgoHymgTIiCLrqYNhoUTqdP> list = new List<YHTAmSgoHymgTIiCLrqYNhoUTqdP>();
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = 560477344;
					while (true)
					{
						int num4;
						switch (num ^ 0x216834A5)
						{
						case 6:
							break;
						case 5:
							if (_ruleSets == null)
							{
								num = 560477350;
								continue;
							}
							num4 = _ruleSets.Count;
							goto IL_0091;
						case 4:
							num2++;
							num = 560477349;
							continue;
						case 2:
							num2 = 0;
							num = 560477349;
							continue;
						case 1:
							if (_ruleSets[num2] != null)
							{
								list.Add(_ruleSets[num2].jZoqlMcZnpkzhfAHhtkNLLReVqX());
								num = 560477345;
								continue;
							}
							goto case 4;
						case 3:
							num4 = 0;
							goto IL_0091;
						default:
							{
								if (num2 >= num3)
								{
									return list.ToArray();
								}
								goto case 1;
							}
							IL_0091:
							num3 = num4;
							num = 560477351;
							continue;
						}
						break;
					}
				}
			}

			private object hEZwsICCTkbnKIzILtxAEaqwNbdC()
			{
				return new ControllerMapLayoutManagerSettings(this);
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in hEZwsICCTkbnKIzILtxAEaqwNbdC
				return this.hEZwsICCTkbnKIzILtxAEaqwNbdC();
			}
		}

		[Serializable]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ControllerMapEnablerSettings : IDeepCloneable
		{
			[SerializeField]
			[CustomObfuscation(rename = false)]
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
				_ruleSets = new List<RuleSetMapping>();
				_enabled = true;
			}

			public ControllerMapEnablerSettings(ControllerMapEnablerSettings source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				_enabled = source._enabled;
				_ruleSets = MiscTools.DeepClone(source._ruleSets) ?? new List<RuleSetMapping>();
			}

			internal ControllerMapEnabler.DsPdjyUGWkefBITeOKEcuyqvmdo VAqTUwRbJIeTdanGWWozEUgsoBs()
			{
				return new ControllerMapEnabler.DsPdjyUGWkefBITeOKEcuyqvmdo(_enabled, CPdkArVgorHcUGVRXDnoMIKgkLQ());
			}

			private YHTAmSgoHymgTIiCLrqYNhoUTqdP[] CPdkArVgorHcUGVRXDnoMIKgkLQ()
			{
				List<YHTAmSgoHymgTIiCLrqYNhoUTqdP> list = new List<YHTAmSgoHymgTIiCLrqYNhoUTqdP>();
				int num = ((_ruleSets != null) ? _ruleSets.Count : 0);
				int num2 = 0;
				while (true)
				{
					int num3;
					int num4;
					if (num2 < num)
					{
						num3 = -1888218705;
						num4 = num3;
					}
					else
					{
						num3 = -1888218711;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ -1888218707)
						{
						case 3:
							num3 = -1888218705;
							continue;
						case 2:
							if (_ruleSets[num2] != null)
							{
								list.Add(_ruleSets[num2].jZoqlMcZnpkzhfAHhtkNLLReVqX());
								num3 = -1888218708;
								continue;
							}
							goto case 1;
						case 1:
							num2++;
							num3 = -1888218707;
							continue;
						case 0:
							break;
						default:
							return list.ToArray();
						}
						break;
					}
				}
			}

			private object hEZwsICCTkbnKIzILtxAEaqwNbdC()
			{
				return new ControllerMapEnablerSettings(this);
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in hEZwsICCTkbnKIzILtxAEaqwNbdC
				return this.hEZwsICCTkbnKIzILtxAEaqwNbdC();
			}
		}

		[Serializable]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class RuleSetMapping : IDeepCloneable
		{
			[CustomObfuscation(rename = false)]
			[SerializeField]
			private bool _enabled;

			[SerializeField]
			[CustomObfuscation(rename = false)]
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

			internal YHTAmSgoHymgTIiCLrqYNhoUTqdP jZoqlMcZnpkzhfAHhtkNLLReVqX()
			{
				return new YHTAmSgoHymgTIiCLrqYNhoUTqdP(_id, _enabled);
			}

			private object hEZwsICCTkbnKIzILtxAEaqwNbdC()
			{
				return new RuleSetMapping(this);
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in hEZwsICCTkbnKIzILtxAEaqwNbdC
				return this.hEZwsICCTkbnKIzILtxAEaqwNbdC();
			}
		}

		[Serializable]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class CreateControllerInfo
		{
			[CustomObfuscation(rename = false)]
			[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _startPlaying;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Mapping> _defaultJoystickMaps;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Mapping> _defaultMouseMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Mapping> _defaultKeyboardMaps;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Mapping> _defaultCustomControllerMaps;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CreateControllerInfo> _startingCustomControllers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _assignMouseOnStart;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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
				int num = 1976863144;
				while (true)
				{
					switch (num ^ 0x75D489AB)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						_defaultKeyboardMaps = new List<Mapping>();
						_defaultJoystickMaps = new List<Mapping>();
						_defaultMouseMaps = new List<Mapping>();
						_defaultCustomControllerMaps = new List<Mapping>();
						_startingCustomControllers = new List<CreateControllerInfo>();
						_excludeFromControllerAutoAssignment = false;
						_controllerMapLayoutManagerSettings = new ControllerMapLayoutManagerSettings();
						num = 1976863146;
						continue;
					case 1:
						_controllerMapEnablerSettings = new ControllerMapEnablerSettings();
						num = 1976863145;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public Player_Editor(Player_Editor source)
		{
			int num2 = default(int);
			int num9 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int num7 = default(int);
			while (true)
			{
				int num = -754325045;
				while (true)
				{
					switch (num ^ -754325055)
					{
					case 23:
						break;
					case 25:
					{
						int num13;
						if (num2 >= source._startingCustomControllers.Count)
						{
							num = -754325029;
							num13 = num;
						}
						else
						{
							num = -754325054;
							num13 = num;
						}
						continue;
					}
					case 12:
						num9 = 0;
						num = -754325048;
						continue;
					case 14:
						if (source._defaultCustomControllerMaps != null)
						{
							num3 = 0;
							num = -754325056;
							continue;
						}
						goto case 20;
					case 21:
						_defaultKeyboardMaps = new List<Mapping>();
						num = -754325033;
						continue;
					case 20:
						_startingCustomControllers = new List<CreateControllerInfo>();
						if (source._startingCustomControllers != null)
						{
							num2 = 0;
							num = -754325032;
							continue;
						}
						goto default;
					case 17:
					{
						int num11;
						if (num9 < source._defaultKeyboardMaps.Count)
						{
							num = -754325052;
							num11 = num;
						}
						else
						{
							num = -754325050;
							num11 = num;
						}
						continue;
					}
					case 5:
						_defaultKeyboardMaps.Add(source._defaultKeyboardMaps[num9].Clone());
						num9++;
						num = -754325040;
						continue;
					case 8:
					{
						int num6;
						if (num5 < source._defaultMouseMaps.Count)
						{
							num = -754325053;
							num6 = num;
						}
						else
						{
							num = -754325044;
							num6 = num;
						}
						continue;
					}
					case 1:
					{
						int num14;
						if (num3 < source._defaultCustomControllerMaps.Count)
						{
							num = -754325049;
							num14 = num;
						}
						else
						{
							num = -754325035;
							num14 = num;
						}
						continue;
					}
					case 13:
						_defaultCustomControllerMaps = new List<Mapping>();
						num = -754325041;
						continue;
					case 15:
						_defaultJoystickMaps.Add(source._defaultJoystickMaps[num7].Clone());
						num7++;
						num = -754325038;
						continue;
					case 24:
						num3++;
						num = -754325056;
						continue;
					case 9:
						num = -754325040;
						continue;
					case 0:
						num7 = 0;
						num = -754325051;
						continue;
					case 22:
					{
						int num12;
						if (source._defaultKeyboardMaps != null)
						{
							num = -754325043;
							num12 = num;
						}
						else
						{
							num = -754325050;
							num12 = num;
						}
						continue;
					}
					case 18:
						num2++;
						num = -754325032;
						continue;
					case 16:
					{
						int num10;
						if (source._defaultJoystickMaps != null)
						{
							num = -754325055;
							num10 = num;
						}
						else
						{
							num = -754325036;
							num10 = num;
						}
						continue;
					}
					case 19:
					{
						int num8;
						if (num7 >= source._defaultJoystickMaps.Count)
						{
							num = -754325036;
							num8 = num;
						}
						else
						{
							num = -754325042;
							num8 = num;
						}
						continue;
					}
					case 2:
						_defaultMouseMaps.Add(source._defaultMouseMaps[num5].Clone());
						num5++;
						num = -754325047;
						continue;
					case 11:
						num5 = 0;
						num = -754325047;
						continue;
					case 7:
					{
						_defaultMouseMaps = new List<Mapping>();
						int num4;
						if (source._defaultMouseMaps != null)
						{
							num = -754325046;
							num4 = num;
						}
						else
						{
							num = -754325044;
							num4 = num;
						}
						continue;
					}
					case 4:
						num = -754325038;
						continue;
					case 10:
						_id = source._id;
						_name = source._name;
						_descriptiveName = source._descriptiveName;
						_startPlaying = source._startPlaying;
						_defaultJoystickMaps = new List<Mapping>();
						num = -754325039;
						continue;
					case 6:
						_defaultCustomControllerMaps.Add(source._defaultCustomControllerMaps[num3].Clone());
						num = -754325031;
						continue;
					case 3:
						_startingCustomControllers.Add(new CreateControllerInfo(source._startingCustomControllers[num2]));
						num = -754325037;
						continue;
					default:
						_controllerMapLayoutManagerSettings = MiscTools.DeepClone(source._controllerMapLayoutManagerSettings) ?? new ControllerMapLayoutManagerSettings();
						_controllerMapEnablerSettings = MiscTools.DeepClone(source._controllerMapEnablerSettings) ?? new ControllerMapEnablerSettings();
						_assignMouseOnStart = source._assignMouseOnStart;
						_assignKeyboardOnStart = source._assignKeyboardOnStart;
						_excludeFromControllerAutoAssignment = source._excludeFromControllerAutoAssignment;
						return;
					}
					break;
				}
			}
		}

		public Player_Editor Clone()
		{
			return new Player_Editor(this);
		}

		internal NdAxeLDWXXGREuIaIVGNrwziLyY GdayHkNEleVQjMNyFALelYwfJLv()
		{
			JLsTIMWCujkPTdzGdsSlKXwTnMp[] array = null;
			if (_defaultJoystickMaps != null)
			{
				goto IL_000d;
			}
			goto IL_014d;
			IL_000d:
			int num = 1151206887;
			goto IL_0012;
			IL_0012:
			JLsTIMWCujkPTdzGdsSlKXwTnMp[] array4 = default(JLsTIMWCujkPTdzGdsSlKXwTnMp[]);
			int num5 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			JLsTIMWCujkPTdzGdsSlKXwTnMp[] array3 = default(JLsTIMWCujkPTdzGdsSlKXwTnMp[]);
			int num2 = default(int);
			JLsTIMWCujkPTdzGdsSlKXwTnMp[] array2 = default(JLsTIMWCujkPTdzGdsSlKXwTnMp[]);
			while (true)
			{
				switch (num ^ 0x449E05E0)
				{
				case 4:
					break;
				case 11:
					array4[num5] = _defaultMouseMaps[num5].SpaplMYipxbuaSKPEuSEciQxjzi();
					num5++;
					num = 1151206894;
					continue;
				case 12:
					num4++;
					num = 1151206890;
					continue;
				case 15:
					goto IL_009c;
				case 1:
					array[num3] = _defaultJoystickMaps[num3].SpaplMYipxbuaSKPEuSEciQxjzi();
					num3++;
					num = 1151206886;
					continue;
				case 0:
					array3[num2] = _defaultCustomControllerMaps[num2].SpaplMYipxbuaSKPEuSEciQxjzi();
					num = 1151206889;
					continue;
				case 3:
					array2[num4] = _defaultKeyboardMaps[num4].SpaplMYipxbuaSKPEuSEciQxjzi();
					num = 1151206892;
					continue;
				case 16:
					goto IL_012a;
				case 5:
					goto IL_014d;
				case 2:
					num3 = 0;
					num = 1151206886;
					continue;
				case 13:
					goto IL_0180;
				case 7:
					array = new JLsTIMWCujkPTdzGdsSlKXwTnMp[_defaultJoystickMaps.Count];
					num = 1151206882;
					continue;
				case 9:
					num2++;
					num = 1151206896;
					continue;
				case 6:
					goto IL_01d8;
				case 17:
					num = 1151206890;
					continue;
				case 10:
					goto IL_0204;
				case 14:
					goto IL_0226;
				default:
					goto IL_0249;
				}
				break;
				IL_0226:
				int num6;
				if (num5 < _defaultMouseMaps.Count)
				{
					num = 1151206891;
					num6 = num;
				}
				else
				{
					num = 1151206895;
					num6 = num;
				}
				continue;
				IL_01d8:
				int num7;
				if (num3 < _defaultJoystickMaps.Count)
				{
					num = 1151206881;
					num7 = num;
				}
				else
				{
					num = 1151206885;
					num7 = num;
				}
				continue;
				IL_012a:
				int num8;
				if (num2 >= _defaultCustomControllerMaps.Count)
				{
					num = 1151206888;
					num8 = num;
				}
				else
				{
					num = 1151206880;
					num8 = num;
				}
				continue;
				IL_0204:
				int num9;
				if (num4 >= _defaultKeyboardMaps.Count)
				{
					num = 1151206893;
					num9 = num;
				}
				else
				{
					num = 1151206883;
					num9 = num;
				}
			}
			goto IL_000d;
			IL_0180:
			array4 = null;
			if (_defaultMouseMaps != null)
			{
				array4 = new JLsTIMWCujkPTdzGdsSlKXwTnMp[_defaultMouseMaps.Count];
				num5 = 0;
				num = 1151206894;
				goto IL_0012;
			}
			goto IL_009c;
			IL_009c:
			array3 = null;
			if (_defaultCustomControllerMaps != null)
			{
				array3 = new JLsTIMWCujkPTdzGdsSlKXwTnMp[_defaultCustomControllerMaps.Count];
				num2 = 0;
				num = 1151206896;
				goto IL_0012;
			}
			goto IL_0249;
			IL_0249:
			return new NdAxeLDWXXGREuIaIVGNrwziLyY(array, array2, array4, array3);
			IL_014d:
			array2 = null;
			if (_defaultKeyboardMaps != null)
			{
				array2 = new JLsTIMWCujkPTdzGdsSlKXwTnMp[_defaultKeyboardMaps.Count];
				num4 = 0;
				num = 1151206897;
				goto IL_0012;
			}
			goto IL_0180;
		}
	}
}
