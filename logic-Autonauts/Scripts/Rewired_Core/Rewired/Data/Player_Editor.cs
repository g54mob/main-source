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

			[CustomObfuscation(rename = false)]
			[SerializeField]
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

			internal sNufmBgiDzHvGUEhwQNseOEOMqKD dRmfGFHoUfIslljwRANRrceeyeVO()
			{
				return new sNufmBgiDzHvGUEhwQNseOEOMqKD(_categoryId, _layoutId, _enabled);
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

			[CustomObfuscation(rename = false)]
			[SerializeField]
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
				while (true)
				{
					int num = -1935883175;
					while (true)
					{
						switch (num ^ -1935883176)
						{
						case 2:
							break;
						case 1:
						{
							int num2;
							if (source != null)
							{
								num = -1935883176;
								num2 = num;
							}
							else
							{
								num = -1935883173;
								num2 = num;
							}
							continue;
						}
						case 3:
							throw new ArgumentNullException("source");
						default:
							_enabled = source._enabled;
							_loadFromUserDataStore = source._loadFromUserDataStore;
							_ruleSets = MiscTools.DeepClone(source._ruleSets) ?? new List<RuleSetMapping>();
							return;
						}
						break;
					}
				}
			}

			internal ControllerMapLayoutManager.StartingSettings aiqbcfAlKIAlyjPCBVtoGAgqjnJO()
			{
				return new ControllerMapLayoutManager.StartingSettings(_enabled, _loadFromUserDataStore, fWxcZycbTdBUDBjgJQszGAeWdpxx());
			}

			private xARLMDSmNatmMHrqILZLrYZBlkK[] fWxcZycbTdBUDBjgJQszGAeWdpxx()
			{
				List<xARLMDSmNatmMHrqILZLrYZBlkK> list = new List<xARLMDSmNatmMHrqILZLrYZBlkK>();
				int num = ((_ruleSets != null) ? _ruleSets.Count : 0);
				int num2 = 0;
				while (num2 < num)
				{
					while (true)
					{
						int num3;
						if (_ruleSets[num2] != null)
						{
							list.Add(_ruleSets[num2].UvmcINWVElJkqSpigkHUBglvahw());
							num3 = -474044329;
							goto IL_0026;
						}
						goto IL_006f;
						IL_0026:
						while (true)
						{
							switch (num3 ^ -474044330)
							{
							case 3:
								num3 = -474044332;
								continue;
							case 2:
								break;
							case 1:
								goto IL_006f;
							default:
								goto end_IL_0043;
							}
							break;
						}
						continue;
						IL_006f:
						num2++;
						num3 = -474044330;
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
				return new ControllerMapLayoutManagerSettings(this);
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

			internal ControllerMapEnabler.euPDSnhapeLdIFbRcRtnHgEFqhjZ aiqbcfAlKIAlyjPCBVtoGAgqjnJO()
			{
				return new ControllerMapEnabler.euPDSnhapeLdIFbRcRtnHgEFqhjZ(_enabled, fWxcZycbTdBUDBjgJQszGAeWdpxx());
			}

			private xARLMDSmNatmMHrqILZLrYZBlkK[] fWxcZycbTdBUDBjgJQszGAeWdpxx()
			{
				List<xARLMDSmNatmMHrqILZLrYZBlkK> list = new List<xARLMDSmNatmMHrqILZLrYZBlkK>();
				int num = ((_ruleSets != null) ? _ruleSets.Count : 0);
				int num2 = 0;
				while (num2 < num)
				{
					while (true)
					{
						int num3;
						if (_ruleSets[num2] != null)
						{
							list.Add(_ruleSets[num2].UvmcINWVElJkqSpigkHUBglvahw());
							num3 = 792506999;
							goto IL_0026;
						}
						goto IL_006f;
						IL_0026:
						while (true)
						{
							switch (num3 ^ 0x2F3CB276)
							{
							case 0:
								num3 = 792506996;
								continue;
							case 2:
								break;
							case 1:
								goto IL_006f;
							default:
								goto end_IL_0043;
							}
							break;
						}
						continue;
						IL_006f:
						num2++;
						num3 = 792506997;
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

			internal xARLMDSmNatmMHrqILZLrYZBlkK UvmcINWVElJkqSpigkHUBglvahw()
			{
				return new xARLMDSmNatmMHrqILZLrYZBlkK(_id, _enabled);
			}

			object IDeepCloneable.DeepClone()
			{
				return new RuleSetMapping(this);
			}
		}

		[Serializable]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _assignKeyboardOnStart = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _excludeFromControllerAutoAssignment;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerMapLayoutManagerSettings _controllerMapLayoutManagerSettings;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
			_defaultKeyboardMaps = new List<Mapping>();
			_defaultJoystickMaps = new List<Mapping>();
			_defaultMouseMaps = new List<Mapping>();
			_defaultCustomControllerMaps = new List<Mapping>();
			_startingCustomControllers = new List<CreateControllerInfo>();
			_excludeFromControllerAutoAssignment = false;
			_controllerMapLayoutManagerSettings = new ControllerMapLayoutManagerSettings();
			_controllerMapEnablerSettings = new ControllerMapEnablerSettings();
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

		internal khKFGQdNkFnBHTxVFbmEvpDlEMj jbyopidUzyFqZzHMJudffEfyMKC()
		{
			sNufmBgiDzHvGUEhwQNseOEOMqKD[] array = null;
			int num = default(int);
			if (_defaultJoystickMaps != null)
			{
				array = new sNufmBgiDzHvGUEhwQNseOEOMqKD[_defaultJoystickMaps.Count];
				num = 0;
				goto IL_00e4;
			}
			goto IL_01ff;
			IL_002a:
			int num2;
			sNufmBgiDzHvGUEhwQNseOEOMqKD[] array4 = default(sNufmBgiDzHvGUEhwQNseOEOMqKD[]);
			int num4 = default(int);
			sNufmBgiDzHvGUEhwQNseOEOMqKD[] array3 = default(sNufmBgiDzHvGUEhwQNseOEOMqKD[]);
			int num5 = default(int);
			sNufmBgiDzHvGUEhwQNseOEOMqKD[] array2 = default(sNufmBgiDzHvGUEhwQNseOEOMqKD[]);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -38312878)
				{
				case 2:
					num2 = -38312876;
					continue;
				case 6:
					array[num] = _defaultJoystickMaps[num].dRmfGFHoUfIslljwRANRrceeyeVO();
					num++;
					num2 = -38312873;
					continue;
				case 11:
					array4[num4] = _defaultCustomControllerMaps[num4].dRmfGFHoUfIslljwRANRrceeyeVO();
					num2 = -38312878;
					continue;
				case 4:
					array3[num5] = _defaultKeyboardMaps[num5].dRmfGFHoUfIslljwRANRrceeyeVO();
					num5++;
					num2 = -38312868;
					continue;
				case 5:
					break;
				case 8:
					goto IL_0106;
				case 14:
					goto IL_0129;
				case 7:
					array4 = null;
					num2 = -38312877;
					continue;
				case 12:
					num5 = 0;
					num2 = -38312868;
					continue;
				case 16:
					goto IL_0164;
				case 0:
					num4++;
					num2 = -38312894;
					continue;
				case 1:
					if (_defaultCustomControllerMaps != null)
					{
						array4 = new sNufmBgiDzHvGUEhwQNseOEOMqKD[_defaultCustomControllerMaps.Count];
						num4 = 0;
						num2 = -38312894;
						continue;
					}
					goto default;
				case 15:
					goto IL_01c1;
				case 9:
					array2 = new sNufmBgiDzHvGUEhwQNseOEOMqKD[_defaultMouseMaps.Count];
					num3 = 0;
					num2 = -38312870;
					continue;
				case 17:
					goto IL_01ff;
				case 10:
					if (_defaultKeyboardMaps != null)
					{
						array3 = new sNufmBgiDzHvGUEhwQNseOEOMqKD[_defaultKeyboardMaps.Count];
						num2 = -38312866;
						continue;
					}
					goto IL_01c1;
				case 3:
					array2[num3] = _defaultMouseMaps[num3].dRmfGFHoUfIslljwRANRrceeyeVO();
					num3++;
					num2 = -38312870;
					continue;
				default:
					return new khKFGQdNkFnBHTxVFbmEvpDlEMj(array, array3, array2, array4);
				}
				break;
				IL_01c1:
				array2 = null;
				int num6;
				if (_defaultMouseMaps != null)
				{
					num2 = -38312869;
					num6 = num2;
				}
				else
				{
					num2 = -38312875;
					num6 = num2;
				}
				continue;
				IL_0129:
				int num7;
				if (num5 < _defaultKeyboardMaps.Count)
				{
					num2 = -38312874;
					num7 = num2;
				}
				else
				{
					num2 = -38312867;
					num7 = num2;
				}
				continue;
				IL_0106:
				int num8;
				if (num3 >= _defaultMouseMaps.Count)
				{
					num2 = -38312875;
					num8 = num2;
				}
				else
				{
					num2 = -38312879;
					num8 = num2;
				}
				continue;
				IL_0164:
				int num9;
				if (num4 >= _defaultCustomControllerMaps.Count)
				{
					num2 = -38312865;
					num9 = num2;
				}
				else
				{
					num2 = -38312871;
					num9 = num2;
				}
			}
			goto IL_00e4;
			IL_00e4:
			int num10;
			if (num >= _defaultJoystickMaps.Count)
			{
				num2 = -38312893;
				num10 = num2;
			}
			else
			{
				num2 = -38312876;
				num10 = num2;
			}
			goto IL_002a;
			IL_01ff:
			array3 = null;
			num2 = -38312872;
			goto IL_002a;
		}
	}
}
