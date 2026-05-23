using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	public sealed class ControllerMapLayoutManager
	{
		internal class StartingSettings
		{
			public bool enabled;

			public bool loadFromUserDataStore;

			public IBXCWQaiuXApgrsayPNtUSrFqVH[] startingRuleSets;

			public StartingSettings(bool enabled, bool loadFromUserDataStore, IBXCWQaiuXApgrsayPNtUSrFqVH[] startingRuleSets)
			{
				this.enabled = enabled;
				this.loadFromUserDataStore = loadFromUserDataStore;
				this.startingRuleSets = startingRuleSets;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Preserve]
		public sealed class Rule : IDeepCloneable
		{
			[Serialize(Name = "tag")]
			[SerializeField]
			private string _tag;

			[SerializeField]
			[Serialize(Name = "categoryIds")]
			private int[] _categoryIds;

			[SerializeField]
			[Serialize(Name = "layoutId")]
			private int _layoutId;

			[SerializeField]
			[Serialize(Name = "controllerSetSelector")]
			private ControllerSetSelector _controllerSetSelector;

			[NonSerialized]
			private string[] _preInitCategoryNames;

			[NonSerialized]
			private string _preInitLayoutName;

			public string tag
			{
				get
				{
					return _tag;
				}
				set
				{
					_tag = value;
				}
			}

			public ControllerSetSelector controllerSetSelector
			{
				get
				{
					return _controllerSetSelector ?? (_controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType));
				}
				set
				{
					if (value == null)
					{
						value = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
						goto IL_000b;
					}
					goto IL_0029;
					IL_005a:
					_controllerSetSelector = value;
					return;
					IL_000b:
					int num = 1174829221;
					goto IL_0010;
					IL_0010:
					switch (num ^ 0x460678A7)
					{
					case 0:
						break;
					case 2:
						goto IL_0029;
					default:
						goto IL_005a;
					}
					goto IL_000b;
					IL_0029:
					if (!value.hasControllerType)
					{
						Logger.LogError(string.Concat(value.type, " is not allowed. Each Controller Type has its own unique Layouts and a single Layout cannot be set for all Controller Types. ControllerSelector.type has been changed to ControllerSelector.Type.ControllerType."), true);
						value.type = ControllerSetSelector.Type.ControllerType;
						num = 1174829222;
						goto IL_0010;
					}
					goto IL_005a;
				}
			}

			public int categoryId
			{
				get
				{
					Initialize();
					if (_categoryIds == null || _categoryIds.Length == 0)
					{
						return -1;
					}
					return categoryIds[0];
				}
				set
				{
					if (value < 0)
					{
						goto IL_0004;
					}
					goto IL_005c;
					IL_0004:
					int num = 1117748607;
					goto IL_0009;
					IL_0009:
					while (true)
					{
						switch (num ^ 0x429F7D7B)
						{
						case 2:
							break;
						case 5:
							_categoryIds[0] = value;
							num = 1117748603;
							continue;
						case 3:
							num = 1117748603;
							continue;
						case 1:
							goto IL_0049;
						case 6:
							goto IL_005c;
						case 4:
							_categoryIds = EmptyObjects<int>.array;
							num = 1117748600;
							continue;
						default:
							_preInitCategoryNames = null;
							return;
						}
						break;
					}
					goto IL_0004;
					IL_0049:
					_categoryIds = new int[1];
					num = 1117748606;
					goto IL_0009;
					IL_005c:
					if (_categoryIds != null)
					{
						int num2;
						if (_categoryIds.Length == 0)
						{
							num = 1117748602;
							num2 = num;
						}
						else
						{
							num = 1117748606;
							num2 = num;
						}
						goto IL_0009;
					}
					goto IL_0049;
				}
			}

			public int[] categoryIds
			{
				get
				{
					Initialize();
					return _categoryIds ?? (_categoryIds = EmptyObjects<int>.array);
				}
				set
				{
					if (value == null)
					{
						while (true)
						{
							int num = -1572836362;
							while (true)
							{
								switch (num ^ -1572836364)
								{
								case 0:
									break;
								case 2:
									value = EmptyObjects<int>.array;
									num = -1572836363;
									continue;
								default:
									goto end_IL_0003;
								}
								break;
							}
							continue;
							end_IL_0003:
							break;
						}
					}
					_categoryIds = value;
					_preInitCategoryNames = null;
				}
			}

			public int layoutId
			{
				get
				{
					Initialize();
					return _layoutId;
				}
				set
				{
					if (value < 0)
					{
						value = -1;
					}
					_layoutId = value;
					_preInitLayoutName = null;
				}
			}

			public string categoryName
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (_preInitCategoryNames != null)
						{
							goto IL_0012;
						}
						goto IL_0083;
					}
					Initialize();
					int num = 1450128206;
					goto IL_0017;
					IL_0083:
					return null;
					IL_009e:
					InputMapCategory mapCategory = default(InputMapCategory);
					if (mapCategory == null)
					{
						return "INVALID";
					}
					return mapCategory.name;
					IL_0012:
					num = 1450128207;
					goto IL_0017;
					IL_0017:
					while (true)
					{
						switch (num ^ 0x566F334D)
						{
						case 5:
							break;
						case 3:
							if (_categoryIds != null)
							{
								goto IL_0044;
							}
							goto case 1;
						case 1:
							return null;
						case 2:
							goto IL_0071;
						case 4:
							goto IL_0083;
						default:
							goto IL_009e;
						}
						break;
						IL_0071:
						if (_preInitCategoryNames.Length <= 0)
						{
							num = 1450128201;
							continue;
						}
						return _preInitCategoryNames[0];
						IL_0044:
						if (_categoryIds.Length == 0)
						{
							num = 1450128204;
							continue;
						}
						mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
						num = 1450128205;
					}
					goto IL_0012;
				}
				set
				{
					if (!ReInput.isReady)
					{
						goto IL_000a;
					}
					goto IL_009b;
					IL_000a:
					int num = 1823794229;
					goto IL_000f;
					IL_000f:
					int mapCategoryId = default(int);
					while (true)
					{
						switch (num ^ 0x6CB4E433)
						{
						case 7:
							break;
						case 6:
							_preInitCategoryNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
							num = 1823794227;
							continue;
						case 0:
							_categoryIds = EmptyObjects<int>.array;
							return;
						case 4:
							categoryId = mapCategoryId;
							return;
						case 1:
							_categoryIds = EmptyObjects<int>.array;
							return;
						case 3:
							goto IL_009b;
						case 5:
							goto IL_00b4;
						default:
							Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
							return;
						}
						break;
					}
					goto IL_000a;
					IL_009b:
					if (string.IsNullOrEmpty(value))
					{
						_preInitCategoryNames = null;
						num = 1823794226;
						goto IL_000f;
					}
					goto IL_00b4;
					IL_00b4:
					mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
					int num2;
					if (mapCategoryId < 0)
					{
						num = 1823794225;
						num2 = num;
					}
					else
					{
						num = 1823794231;
						num2 = num;
					}
					goto IL_000f;
				}
			}

			public string[] categoryNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (_preInitCategoryNames == null)
						{
							return EmptyObjects<string>.array;
						}
						return _preInitCategoryNames;
					}
					Initialize();
					if (_categoryIds == null)
					{
						return EmptyObjects<string>.array;
					}
					string[] array = new string[_categoryIds.Length];
					int num = 0;
					while (num < _categoryIds.Length)
					{
						while (true)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[num]);
							array[num] = ((mapCategory != null) ? mapCategory.name : "INVALID");
							int num2 = -844789987;
							while (true)
							{
								switch (num2 ^ -844789986)
								{
								case 0:
									num2 = -844789985;
									continue;
								case 1:
									break;
								case 3:
									num++;
									num2 = -844789988;
									continue;
								default:
									goto end_IL_0064;
								}
								break;
							}
							continue;
							end_IL_0064:
							break;
						}
					}
					return array;
				}
				set
				{
					if (!ReInput.isReady)
					{
						_preInitCategoryNames = ((value != null && value.Length > 0) ? value : null);
						_categoryIds = EmptyObjects<int>.array;
						return;
					}
					int num3 = default(int);
					List<int> list = default(List<int>);
					while (true)
					{
						int num;
						if (value != null)
						{
							int num2;
							if (value.Length != 0)
							{
								num = -1446820837;
								num2 = num;
							}
							else
							{
								num = -1446820835;
								num2 = num;
							}
							goto IL_002b;
						}
						goto IL_0078;
						IL_002b:
						while (true)
						{
							switch (num ^ -1446820838)
							{
							case 0:
								num = -1446820839;
								continue;
							case 3:
								break;
							case 7:
								goto IL_0078;
							case 2:
								Logger.LogWarning("Map Category \"" + value[num3] + "\" does not exist.");
								num = -1446820846;
								continue;
							case 4:
								_categoryIds = EmptyObjects<int>.array;
								return;
							case 8:
								num3++;
								num = -1446820833;
								continue;
							case 1:
								list = new List<int>(value.Length);
								num3 = 0;
								num = -1446820833;
								continue;
							case 6:
								if (!string.IsNullOrEmpty(value[num3]))
								{
									int mapCategoryId = ReInput.mapping.GetMapCategoryId(value[num3]);
									if (mapCategoryId >= 0)
									{
										list.Add(mapCategoryId);
										num = -1446820846;
										continue;
									}
									goto case 2;
								}
								goto case 8;
							default:
								if (num3 >= value.Length)
								{
									_categoryIds = list.ToArray();
									return;
								}
								goto case 6;
							}
							break;
						}
						continue;
						IL_0078:
						_preInitCategoryNames = null;
						num = -1446820834;
						goto IL_002b;
					}
				}
			}

			public string layoutName
			{
				get
				{
					if (!ReInput.isReady)
					{
						return _preInitLayoutName;
					}
					Initialize();
					InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutId);
					if (layout == null)
					{
						return "INVALID";
					}
					return layout.name;
				}
				set
				{
					if (!ReInput.isReady)
					{
						goto IL_0007;
					}
					goto IL_003c;
					IL_0007:
					int num = 638314802;
					goto IL_000c;
					IL_000c:
					object[] array = default(object[]);
					while (true)
					{
						switch (num ^ 0x260BE937)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_003c;
						case 3:
							array[0] = controllerSetSelector.controllerType;
							array[1] = " Layout \"";
							array[2] = value;
							array[3] = "\" does not exist.";
							Logger.LogWarning(string.Concat(array));
							num = 638314800;
							continue;
						case 5:
							_preInitLayoutName = value;
							_layoutId = -1;
							num = 638314803;
							continue;
						case 1:
							layoutId = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
							if (_layoutId < 0)
							{
								array = new object[4];
								num = 638314804;
								continue;
							}
							return;
						case 4:
							return;
						case 6:
							_preInitLayoutName = null;
							_layoutId = -1;
							return;
						case 7:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_003c:
					int num2;
					if (string.IsNullOrEmpty(value))
					{
						num = 638314801;
						num2 = num;
					}
					else
					{
						num = 638314806;
						num2 = num;
					}
					goto IL_000c;
				}
			}

			internal bool isValid
			{
				get
				{
					if (_controllerSetSelector == null)
					{
						return false;
					}
					Initialize();
					if (_categoryIds != null)
					{
						int num2 = default(int);
						bool flag = default(bool);
						while (true)
						{
							int num = 538447594;
							while (true)
							{
								switch (num ^ 0x20180EEB)
								{
								case 3:
									break;
								case 0:
									if (ReInput.mapping.GetMapCategory(_categoryIds[num2]) != null)
									{
										flag = true;
										num = 538447599;
										continue;
									}
									goto case 4;
								case 6:
									goto end_IL_0018;
								case 1:
									goto IL_0073;
								case 4:
									num2++;
									num = 538447593;
									continue;
								case 5:
									goto IL_008f;
								default:
									if (num2 < _categoryIds.Length)
									{
										goto case 0;
									}
									goto IL_00c2;
								}
								break;
								IL_0073:
								if (_categoryIds.Length != 0)
								{
									if (!ReInput.isReady)
									{
										num = 538447598;
										continue;
									}
									flag = false;
									num2 = 0;
									num = 538447593;
								}
								else
								{
									num = 538447597;
								}
							}
							continue;
							IL_008f:
							if (_categoryIds[0] >= 0)
							{
								return _layoutId >= 0;
							}
							return false;
							IL_00c2:
							if (!flag)
							{
								return false;
							}
							return ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutId) != null;
							continue;
							end_IL_0018:
							break;
						}
					}
					return false;
				}
			}

			public Rule()
			{
				_categoryIds = EmptyObjects<int>.array;
				_layoutId = -1;
				_controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
			}

			public Rule(Rule source)
			{
				while (true)
				{
					int num = 1226554766;
					while (true)
					{
						switch (num ^ 0x491BBD8A)
						{
						case 0:
							break;
						case 4:
							if (source == null)
							{
								throw new ArgumentNullException("source");
							}
							goto case 3;
						case 3:
							_tag = source._tag;
							_categoryIds = ArrayTools.ShallowCopy(source._categoryIds);
							_layoutId = source._layoutId;
							num = 1226554760;
							continue;
						case 1:
							_preInitCategoryNames = ArrayTools.ShallowCopy(source._preInitCategoryNames);
							num = 1226554767;
							continue;
						case 2:
							_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
							num = 1226554763;
							continue;
						default:
							_preInitLayoutName = source._preInitLayoutName;
							return;
						}
						break;
					}
				}
			}

			internal Rule(string tag, int[] categoryIds, int layoutId, ControllerSetSelector controllerSetSelector)
			{
				_tag = tag;
				_categoryIds = categoryIds;
				_layoutId = layoutId;
				_controllerSetSelector = controllerSetSelector;
			}

			private void Initialize()
			{
				if (!ReInput.isReady)
				{
					return;
				}
				int num3 = default(int);
				List<int> list = default(List<int>);
				while (true)
				{
					int num;
					int num2;
					if (_controllerSetSelector != null)
					{
						num = -1046771125;
						num2 = num;
					}
					else
					{
						num = -1046771131;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1046771135)
						{
						case 7:
							num = -1046771124;
							continue;
						default:
							return;
						case 2:
							if (!string.IsNullOrEmpty(_preInitCategoryNames[num3]))
							{
								int mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[num3]);
								if (mapCategoryId >= 0)
								{
									list.Add(mapCategoryId);
									num = -1046771136;
									continue;
								}
								goto case 3;
							}
							goto case 1;
						case 4:
							return;
						case 6:
							if (!string.IsNullOrEmpty(_preInitLayoutName))
							{
								layoutName = _preInitLayoutName;
								_preInitLayoutName = null;
								num = -1046771128;
								continue;
							}
							return;
						case 10:
						{
							int num5;
							if (_categoryIds != null)
							{
								num = -1046771126;
								num5 = num;
							}
							else
							{
								num = -1046771123;
								num5 = num;
							}
							continue;
						}
						case 8:
							if (_preInitCategoryNames.Length != 0)
							{
								list = new List<int>(_preInitCategoryNames.Length);
								num = -1046771132;
								continue;
							}
							goto case 6;
						case 12:
							_categoryIds = EmptyObjects<int>.array;
							num = -1046771126;
							continue;
						case 13:
							break;
						case 3:
							Logger.LogWarning("Map Category \"" + _preInitCategoryNames[num3] + "\" does not exist.");
							num = -1046771136;
							continue;
						case 1:
							num3++;
							num = -1046771135;
							continue;
						case 0:
							if (num3 >= _preInitCategoryNames.Length)
							{
								_categoryIds = list.ToArray();
								num = -1046771121;
								continue;
							}
							goto case 2;
						case 11:
						{
							int num4;
							if (_preInitCategoryNames != null)
							{
								num = -1046771127;
								num4 = num;
							}
							else
							{
								num = -1046771129;
								num4 = num;
							}
							continue;
						}
						case 14:
							_preInitCategoryNames = null;
							num = -1046771129;
							continue;
						case 5:
							num3 = 0;
							num = -1046771135;
							continue;
						case 9:
							return;
						}
						break;
					}
				}
			}

			object IDeepCloneable.DeepClone()
			{
				return new Rule(this);
			}
		}

		[Serializable]
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
		public sealed class RuleSet : IDeepCloneable, IEnumerable, IList<Rule>, ICollection<Rule>, IEnumerable<Rule>
		{
			private const string className = "ControllerMapLayoutManager.RuleSet";

			[SerializeField]
			[Serialize(Name = "enabled")]
			private bool _enabled;

			[Serialize(Name = "tag")]
			[SerializeField]
			private string _tag;

			[SerializeField]
			[Serialize(Name = "rules")]
			private List<Rule> _rules;

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

			public string tag
			{
				get
				{
					return _tag;
				}
				set
				{
					_tag = value;
				}
			}

			public List<Rule> rules
			{
				get
				{
					return _rules;
				}
				set
				{
					_rules = value;
					CheckList();
				}
			}

			public Rule this[int index]
			{
				get
				{
					CheckList();
					return _rules[index];
				}
				set
				{
					CheckList();
					_rules[index] = value;
				}
			}

			public int Count
			{
				get
				{
					CheckList();
					return _rules.Count;
				}
			}

			bool ICollection<Rule>.IsReadOnly
			{
				get
				{
					CheckList();
					return ((ICollection<Rule>)_rules).IsReadOnly;
				}
			}

			internal RuleSet(bool enabled, string tag, List<Rule> rules)
				: this()
			{
				while (true)
				{
					int num = -1058139056;
					while (true)
					{
						switch (num ^ -1058139055)
						{
						case 2:
							break;
						case 1:
							_enabled = enabled;
							num = -1058139055;
							continue;
						case 0:
							_tag = tag;
							_rules = rules;
							num = -1058139054;
							continue;
						default:
							CheckList();
							return;
						}
						break;
					}
				}
			}

			public RuleSet()
			{
				_enabled = true;
				_rules = new List<Rule>();
			}

			public RuleSet(RuleSet source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				_enabled = source._enabled;
				_tag = source._tag;
				_rules = MiscTools.DeepClone(source._rules);
				CheckList();
			}

			public Rule Find(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int num = ((_rules != null) ? _rules.Count : 0);
				for (int i = 0; i < num; i++)
				{
					try
					{
						if (!predicate(_rules[i]))
						{
							continue;
						}
						while (true)
						{
							switch (-1464214463 ^ -1464214464)
							{
							case 2:
								break;
							default:
								goto end_IL_003d;
							case 1:
								return _rules[i];
							case 0:
								goto end_IL_003d;
							}
							continue;
							end_IL_003d:
							break;
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.Find", exception);
					}
				}
				return null;
			}

			public Rule FindLast(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					goto IL_0003;
				}
				goto IL_0037;
				IL_0003:
				int num = -1708836903;
				goto IL_0008;
				IL_0008:
				switch (num ^ -1708836904)
				{
				case 0:
					break;
				case 1:
					throw new ArgumentNullException("predicate");
				case 3:
					goto IL_0037;
				default:
					goto IL_0046;
				}
				goto IL_0003;
				IL_0054:
				int num3;
				int num2 = num3;
				for (int num4 = num2 - 1; num4 >= 0; num4--)
				{
					try
					{
						if (predicate(_rules[num4]))
						{
							while (true)
							{
								switch (-1708836903 ^ -1708836904)
								{
								case 2:
									break;
								default:
									goto end_IL_006f;
								case 1:
									return _rules[num4];
								case 0:
									goto end_IL_006f;
								}
								continue;
								end_IL_006f:
								break;
							}
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLast", exception);
					}
				}
				return null;
				IL_0037:
				if (_rules == null)
				{
					num = -1708836902;
					goto IL_0008;
				}
				num3 = _rules.Count;
				goto IL_0054;
				IL_0046:
				num3 = 0;
				goto IL_0054;
			}

			public int FindIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int i = default(int);
				int num3 = default(int);
				while (true)
				{
					int num;
					if (_rules == null)
					{
						num = -30790125;
						goto IL_0013;
					}
					int num2 = _rules.Count;
					goto IL_0051;
					IL_0013:
					while (true)
					{
						switch (num ^ -30790125)
						{
						case 2:
							num = -30790126;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0043;
						case 4:
							i = 0;
							num = -30790128;
							continue;
						default:
							for (; i < num3; i++)
							{
								try
								{
									if (!predicate(_rules[i]))
									{
										continue;
									}
									while (true)
									{
										switch (-30790126 ^ -30790125)
										{
										case 0:
											break;
										default:
											goto end_IL_0078;
										case 1:
											return i;
										case 2:
											goto end_IL_0078;
										}
										continue;
										end_IL_0078:
										break;
									}
								}
								catch (Exception exception)
								{
									ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindIndex", exception);
								}
							}
							return -1;
						}
						break;
					}
					continue;
					IL_0043:
					num2 = 0;
					goto IL_0051;
					IL_0051:
					num3 = num2;
					num = -30790121;
					goto IL_0013;
				}
			}

			public int FindLastIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int num = ((_rules != null) ? _rules.Count : 0);
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					try
					{
						if (predicate(_rules[num2]))
						{
							return num2;
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLastIndex", exception);
					}
				}
				return -1;
			}

			public int IndexOf(Rule item)
			{
				CheckList();
				return _rules.Count;
			}

			public void Insert(int index, Rule item)
			{
				CheckList();
				_rules.Insert(index, item);
			}

			public void RemoveAt(int index)
			{
				CheckList();
				_rules.RemoveAt(index);
			}

			public void Add(Rule item)
			{
				CheckList();
				_rules.Add(item);
			}

			public void Clear()
			{
				CheckList();
				_rules.Clear();
			}

			public bool Contains(Rule item)
			{
				CheckList();
				return _rules.Contains(item);
			}

			public void CopyTo(Rule[] array, int arrayIndex)
			{
				CheckList();
				_rules.CopyTo(array, arrayIndex);
			}

			public bool Remove(Rule item)
			{
				CheckList();
				return _rules.Remove(item);
			}

			public IEnumerator<Rule> GetEnumerator()
			{
				CheckList();
				return _rules.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				CheckList();
				return _rules.GetEnumerator();
			}

			object IDeepCloneable.DeepClone()
			{
				return new RuleSet(this);
			}

			private void CheckList()
			{
				if (_rules == null)
				{
					_rules = new List<Rule>();
				}
			}
		}

		private bool _enabled;

		private bool _loadFromUserDataStore = true;

		private Player _player;

		private StartingSettings _startingSettings;

		private readonly int _reInputId;

		private List<RuleSet> _ruleSets;

		private Action _ApplyCalledEvent;

		public bool enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
				if (value)
				{
					Apply();
				}
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

		public List<RuleSet> ruleSets
		{
			get
			{
				return _ruleSets;
			}
			set
			{
				if (value == null)
				{
					value = new List<RuleSet>();
				}
				_ruleSets = value;
			}
		}

		internal event Action ApplyCalledEvent
		{
			add
			{
				_ApplyCalledEvent = (Action)Delegate.Combine(_ApplyCalledEvent, value);
			}
			remove
			{
				_ApplyCalledEvent = (Action)Delegate.Remove(_ApplyCalledEvent, value);
			}
		}

		internal ControllerMapLayoutManager(Player player, StartingSettings startingSettings)
		{
			if (player == null)
			{
				throw new ArgumentNullException("player");
			}
			if (startingSettings == null)
			{
				throw new ArgumentNullException("startingSettings");
			}
			_reInputId = ReInput.id;
			_player = player;
			_startingSettings = startingSettings;
		}

		public void Apply()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int count = default(int);
			while (true)
			{
				Action applyCalledEvent = _ApplyCalledEvent;
				if (applyCalledEvent != null)
				{
					applyCalledEvent();
					int num = -509993333;
					while (true)
					{
						switch (num ^ -509993336)
						{
						case 5:
							num = -509993335;
							continue;
						case 1:
							break;
						case 4:
							goto IL_005b;
						case 2:
							goto IL_0072;
						case 3:
							goto IL_0082;
						default:
							goto end_IL_0044;
						}
						break;
					}
					continue;
				}
				goto IL_0082;
				IL_0072:
				if (_ruleSets == null)
				{
					return;
				}
				goto IL_005b;
				IL_005b:
				count = _ruleSets.Count;
				if (count != 0)
				{
					break;
				}
				return;
				IL_0082:
				if (!_enabled)
				{
					return;
				}
				goto IL_0072;
				continue;
				end_IL_0044:
				break;
			}
			using (TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>())
			{
				List<ControllerMap> list = tList.list;
				TempListPool.TList<Controller> tList2 = TempListPool.GetTList<Controller>();
				try
				{
					List<Controller> list2 = tList2.list;
					if (!list2.Contains(ReInput.controllers.Keyboard))
					{
						list2.Add(ReInput.controllers.Keyboard);
						goto IL_00d6;
					}
					goto IL_0244;
					IL_0244:
					int num2;
					int num3;
					if (list2.Contains(ReInput.controllers.Mouse))
					{
						num2 = -509993342;
						num3 = num2;
					}
					else
					{
						num2 = -509993336;
						num3 = num2;
					}
					goto IL_00db;
					IL_00d6:
					num2 = -509993332;
					goto IL_00db;
					IL_00db:
					int num4 = default(int);
					int num10 = default(int);
					IControllerMapStore controllerMapStore = default(IControllerMapStore);
					int num8 = default(int);
					Rule rule = default(Rule);
					RuleSet ruleSet = default(RuleSet);
					int count2 = default(int);
					ControllerMap controllerMap = default(ControllerMap);
					while (true)
					{
						int num9;
						switch (num2 ^ -509993336)
						{
						case 5:
							break;
						case 7:
							num4--;
							num2 = -509993344;
							continue;
						case 10:
							_player.controllers.maps.GetAllMaps(list);
							list2.AddRange(_player.controllers.Controllers);
							num2 = -509993343;
							continue;
						case 3:
							num10 = 0;
							goto IL_04bb;
						case 9:
							controllerMapStore = ReInput.userDataStore as IControllerMapStore;
							num8 = 0;
							goto IL_04d8;
						case 1:
							if (rule != null && rule.isValid)
							{
								int count3 = list.Count;
								num4 = count3 - 1;
								num2 = -509993344;
								continue;
							}
							goto IL_0493;
						case 11:
						{
							ControllerMap controllerMap2 = list[num4];
							if (rule.controllerSetSelector.Matches(controllerMap2.controller) && ArrayTools.Contains(rule.categoryIds, controllerMap2.categoryId) && controllerMap2.layoutId != rule.layoutId)
							{
								list.RemoveAt(num4);
								_player.controllers.maps.RemoveMap(controllerMap2.controllerType, controllerMap2.controllerId, controllerMap2.id);
								num2 = -509993329;
								continue;
							}
							goto case 7;
						}
						case 4:
							goto IL_0244;
						case 6:
							ruleSet = _ruleSets[num8];
							if (ruleSet != null && ruleSet.enabled)
							{
								count2 = ruleSet.Count;
								num2 = -509993333;
								continue;
							}
							goto IL_04cb;
						case 0:
							list2.Add(ReInput.controllers.Mouse);
							num2 = -509993342;
							continue;
						case 2:
							rule = ruleSet[num10];
							num2 = -509993335;
							continue;
						default:
							{
								if (num4 >= 0)
								{
									goto case 11;
								}
								using (IEnumerator<Controller> enumerator = _player.controllers.Controllers.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											Controller current = enumerator.Current;
											if (!rule.controllerSetSelector.Matches(current))
											{
												break;
											}
											int[] categoryIds = rule.categoryIds;
											int num5 = 0;
											while (true)
											{
												IL_0464:
												if (num5 < categoryIds.Length)
												{
													while (true)
													{
														IL_034a:
														controllerMap = _player.controllers.maps.GetMap(current, categoryIds[num5], rule.layoutId);
														int num6 = -509993334;
														while (true)
														{
															switch (num6 ^ -509993336)
															{
															case 3:
																num6 = -509993335;
																continue;
															case 1:
																break;
															case 0:
																goto IL_034a;
															default:
																goto IL_0376;
															}
															break;
														}
														break;
													}
													break;
												}
												int num7 = -509993334;
												goto IL_03d8;
												IL_040a:
												_player.controllers.maps.LoadMap(current.type, current.id, categoryIds[num5], rule.layoutId, true);
												num7 = -509993335;
												goto IL_03d8;
												IL_03d3:
												num7 = -509993332;
												goto IL_03d8;
												IL_0376:
												if (controllerMap != null)
												{
													goto IL_03fd;
												}
												if (_loadFromUserDataStore && controllerMapStore != null)
												{
													try
													{
														controllerMap = controllerMapStore.LoadControllerMap(_player.id, current.identifier, categoryIds[num5], rule.layoutId);
													}
													catch (Exception exception)
													{
														ReInput.HandleExternalInterfaceException(typeof(ControllerMapLayoutManager).Name, exception);
													}
													if (controllerMap != null)
													{
														goto IL_03d3;
													}
												}
												goto IL_040a;
												IL_03fd:
												num5++;
												num7 = -509993333;
												goto IL_03d8;
												IL_03d8:
												while (true)
												{
													switch (num7 ^ -509993336)
													{
													case 5:
														break;
													case 1:
														goto IL_03fd;
													case 0:
														goto IL_040a;
													case 4:
														_player.controllers.maps.AddMap(current, controllerMap);
														num7 = -509993335;
														continue;
													case 3:
														goto IL_0464;
													default:
														goto end_IL_0316;
													}
													break;
												}
												goto IL_03d3;
											}
											continue;
											end_IL_0316:
											break;
										}
									}
								}
								goto IL_0493;
							}
							IL_04d8:
							if (num8 >= count)
							{
								return;
							}
							goto case 6;
							IL_04cb:
							num8++;
							num9 = -509993333;
							goto IL_049e;
							IL_0499:
							num9 = -509993334;
							goto IL_049e;
							IL_0493:
							num10++;
							goto IL_0499;
							IL_04bb:
							if (num10 < count2)
							{
								goto case 2;
							}
							num9 = -509993335;
							goto IL_049e;
							IL_049e:
							switch (num9 ^ -509993336)
							{
							case 0:
								break;
							case 2:
								goto IL_04bb;
							case 1:
								goto IL_04cb;
							default:
								goto IL_04d8;
							}
							goto IL_0499;
						}
						break;
					}
					goto IL_00d6;
				}
				finally
				{
					if (tList2 != null)
					{
						while (true)
						{
							IL_04e6:
							int num11 = -509993334;
							while (true)
							{
								switch (num11 ^ -509993336)
								{
								case 0:
									break;
								default:
									goto end_IL_04eb;
								case 2:
									goto IL_0504;
								case 1:
									goto end_IL_04eb;
								}
								goto IL_04e6;
								IL_0504:
								((IDisposable)tList2).Dispose();
								num11 = -509993335;
								continue;
								end_IL_04eb:
								break;
							}
							break;
						}
					}
				}
			}
		}

		public void LoadDefaults()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num3 = default(int);
			int num4 = default(int);
			RuleSet controllerMapLayoutManagerRuleSetInstance = default(RuleSet);
			while (true)
			{
				List<RuleSet> list = new List<RuleSet>();
				if (_startingSettings == null)
				{
					goto IL_00db;
				}
				int num;
				if (_startingSettings.startingRuleSets == null)
				{
					num = 1869699733;
					goto IL_0022;
				}
				int num2 = _startingSettings.startingRuleSets.Length;
				goto IL_00eb;
				IL_00db:
				num2 = 0;
				goto IL_00eb;
				IL_00eb:
				num3 = num2;
				num4 = 0;
				num = 1869699737;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ 0x6F715A90)
					{
					case 0:
						num = 1869699730;
						continue;
					case 6:
						_ruleSets = list;
						num = 1869699729;
						continue;
					case 4:
						list.Add(controllerMapLayoutManagerRuleSetInstance);
						num4++;
						num = 1869699737;
						continue;
					case 8:
						controllerMapLayoutManagerRuleSetInstance = ReInput.mapping.GetControllerMapLayoutManagerRuleSetInstance(_startingSettings.startingRuleSets[num4].id);
						num = 1869699731;
						continue;
					case 2:
						break;
					case 9:
						goto IL_00c3;
					case 5:
						goto IL_00db;
					case 7:
						if (_startingSettings != null)
						{
							_enabled = _startingSettings.enabled;
							_loadFromUserDataStore = _startingSettings.loadFromUserDataStore;
							num = 1869699734;
							continue;
						}
						goto case 6;
					case 3:
						controllerMapLayoutManagerRuleSetInstance.enabled = _startingSettings.startingRuleSets[num4].startEnabled;
						num = 1869699732;
						continue;
					default:
						Apply();
						return;
					}
					break;
					IL_00c3:
					int num5;
					if (num4 >= num3)
					{
						num = 1869699735;
						num5 = num;
					}
					else
					{
						num = 1869699736;
						num5 = num;
					}
				}
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			try
			{
				return Export().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			try
			{
				return Export().ToJsonString();
			}
			catch (Exception ex)
			{
				while (true)
				{
					int num = 1972666763;
					while (true)
					{
						switch (num ^ 0x7594818A)
						{
						case 2:
							break;
						case 1:
							goto IL_004c;
						default:
							return string.Empty;
						}
						break;
						IL_004c:
						Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
						num = 1972666762;
					}
				}
			}
		}

		public bool ImportXml(string xmlString)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			try
			{
				Import(SerializedObject.FromXml(GetType(), xmlString));
				Apply();
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + GetType().Name + " data from XML. " + ex.Message);
				return false;
			}
		}

		public bool ImportJson(string jsonString)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			bool result = default(bool);
			try
			{
				Import(SerializedObject.FromJson(GetType(), jsonString));
				Apply();
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + GetType().Name + " data from JSON. " + ex.Message);
				while (true)
				{
					IL_005e:
					int num = 1937009359;
					while (true)
					{
						switch (num ^ 0x73746ACE)
						{
						case 2:
							break;
						default:
							goto end_IL_0063;
						case 1:
							goto IL_007c;
						case 0:
							goto end_IL_0063;
						}
						goto IL_005e;
						IL_007c:
						result = false;
						num = 1937009358;
						continue;
						end_IL_0063:
						break;
					}
					break;
				}
			}
			return result;
		}

		private SerializedObject Export()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			while (true)
			{
				int num = -1083548222;
				while (true)
				{
					switch (num ^ -1083548224)
					{
					case 0:
						break;
					case 2:
						goto IL_002b;
					default:
						return serializedObject;
					}
					break;
					IL_002b:
					ExportDataToSerializedObject(serializedObject);
					num = -1083548223;
				}
			}
		}

		private void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
			if (serializedObject.xmlInfo == null)
			{
				serializedObject.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0013;
			}
			goto IL_0040;
			IL_0040:
			serializedObject.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			int num = 1438305341;
			goto IL_0018;
			IL_0013:
			num = 1438305340;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ 0x55BACC38)
				{
				case 0:
					break;
				case 4:
					goto IL_0040;
				case 3:
					serializedObject.Add("loadFromUserDataStore", _loadFromUserDataStore);
					num = 1438305338;
					continue;
				case 5:
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
					});
					num = 1438305337;
					continue;
				case 1:
					serializedObject.Add("enabled", _enabled);
					num = 1438305339;
					continue;
				default:
					serializedObject.Add("ruleSets", _ruleSets);
					return;
				}
				break;
			}
			goto IL_0013;
		}

		private bool Import(SerializedObject serializedObject)
		{
			_enabled = false;
			List<RuleSet> value = default(List<RuleSet>);
			while (true)
			{
				int num = -66366366;
				while (true)
				{
					switch (num ^ -66366368)
					{
					case 0:
						break;
					case 2:
						_ruleSets = null;
						serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
						serializedObject.TryGetDeserializedValueByRef("loadFromUserDataStore", ref _loadFromUserDataStore);
						value = new List<RuleSet>();
						num = -66366365;
						continue;
					case 3:
						serializedObject.TryGetDeserializedValueByRef("ruleSets", ref value);
						num = -66366367;
						continue;
					default:
						_ruleSets = value;
						return true;
					}
					break;
				}
			}
		}
	}
}
