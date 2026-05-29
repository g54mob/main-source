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

			public xARLMDSmNatmMHrqILZLrYZBlkK[] startingRuleSets;

			public StartingSettings(bool enabled, bool loadFromUserDataStore, xARLMDSmNatmMHrqILZLrYZBlkK[] startingRuleSets)
			{
				this.enabled = enabled;
				this.loadFromUserDataStore = loadFromUserDataStore;
				this.startingRuleSets = startingRuleSets;
			}
		}

		[Serializable]
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Rule : IDeepCloneable
		{
			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			[Serialize(Name = "categoryIds")]
			[SerializeField]
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
					goto IL_0031;
					IL_0031:
					int num;
					if (!value.hasControllerType)
					{
						Logger.LogError(string.Concat(value.type, " is not allowed. Each Controller Type has its own unique Layouts and a single Layout cannot be set for all Controller Types. ControllerSelector.type has been changed to ControllerSelector.Type.ControllerType."), true);
						num = 1874181378;
						goto IL_0010;
					}
					goto IL_0069;
					IL_000b:
					num = 1874181381;
					goto IL_0010;
					IL_0010:
					while (true)
					{
						switch (num ^ 0x6FB5BD01)
						{
						case 2:
							break;
						default:
							return;
						case 4:
							goto IL_0031;
						case 3:
							value.type = ControllerSetSelector.Type.ControllerType;
							num = 1874181377;
							continue;
						case 0:
							goto IL_0069;
						case 1:
							return;
						}
						break;
					}
					goto IL_000b;
					IL_0069:
					_controllerSetSelector = value;
					num = 1874181376;
					goto IL_0010;
				}
			}

			public int categoryId
			{
				get
				{
					Initialize();
					while (true)
					{
						int num = 1974337462;
						while (true)
						{
							switch (num ^ 0x75ADFFB7)
							{
							case 2:
								break;
							case 1:
							{
								int num2;
								if (_categoryIds == null)
								{
									num = 1974337460;
									num2 = num;
								}
								else
								{
									num = 1974337463;
									num2 = num;
								}
								continue;
							}
							case 0:
								if (_categoryIds.Length == 0)
								{
									num = 1974337460;
									continue;
								}
								return categoryIds[0];
							default:
								return -1;
							}
							break;
						}
					}
				}
				set
				{
					if (value >= 0)
					{
						goto IL_003b;
					}
					_categoryIds = EmptyObjects<int>.array;
					goto IL_005e;
					IL_003b:
					int num;
					if (_categoryIds != null)
					{
						int num2;
						if (_categoryIds.Length != 0)
						{
							num = -731837965;
							num2 = num;
						}
						else
						{
							num = -731837962;
							num2 = num;
						}
						goto IL_0016;
					}
					goto IL_007c;
					IL_005e:
					_preInitCategoryNames = null;
					num = -731837967;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -731837965)
						{
						case 4:
							num = -731837966;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							goto IL_005e;
						case 0:
							_categoryIds[0] = value;
							num = -731837968;
							continue;
						case 5:
							goto IL_007c;
						case 2:
							return;
						}
						break;
					}
					goto IL_003b;
					IL_007c:
					_categoryIds = new int[1];
					num = -731837965;
					goto IL_0016;
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
							int num = 1697706621;
							while (true)
							{
								switch (num ^ 0x6530F27C)
								{
								case 0:
									break;
								case 1:
									value = EmptyObjects<int>.array;
									num = 1697706622;
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
						goto IL_0004;
					}
					goto IL_0030;
					IL_0004:
					int num = -2121977437;
					goto IL_0009;
					IL_0009:
					while (true)
					{
						switch (num ^ -2121977438)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							value = -1;
							num = -2121977440;
							continue;
						case 2:
							goto IL_0030;
						case 3:
							return;
						}
						break;
					}
					goto IL_0004;
					IL_0030:
					_layoutId = value;
					_preInitLayoutName = null;
					num = -2121977439;
					goto IL_0009;
				}
			}

			public string categoryName
			{
				get
				{
					if (!ReInput.isReady)
					{
						goto IL_0007;
					}
					Initialize();
					int num;
					if (_categoryIds != null)
					{
						if (_categoryIds.Length == 0)
						{
							num = 1165260145;
							goto IL_000c;
						}
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
						if (mapCategory == null)
						{
							return "INVALID";
						}
						return mapCategory.name;
					}
					goto IL_006d;
					IL_006d:
					return null;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x45747570)
						{
						case 0:
							break;
						case 2:
							if (_preInitCategoryNames != null)
							{
								goto IL_0031;
							}
							goto case 3;
						case 3:
							return null;
						default:
							goto IL_006d;
						}
						break;
						IL_0031:
						if (_preInitCategoryNames.Length <= 0)
						{
							num = 1165260147;
							continue;
						}
						return _preInitCategoryNames[0];
					}
					goto IL_0007;
					IL_0007:
					num = 1165260146;
					goto IL_000c;
				}
				set
				{
					if (!ReInput.isReady)
					{
						_preInitCategoryNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
						_categoryIds = EmptyObjects<int>.array;
						goto IL_002f;
					}
					goto IL_007c;
					IL_002f:
					int num = 575145124;
					goto IL_0034;
					IL_0069:
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
					num = 575145121;
					goto IL_0034;
					IL_007c:
					if (string.IsNullOrEmpty(value))
					{
						_preInitCategoryNames = null;
						_categoryIds = EmptyObjects<int>.array;
						num = 575145123;
						goto IL_0034;
					}
					goto IL_0069;
					IL_0034:
					while (true)
					{
						switch (num ^ 0x224804A2)
						{
						case 2:
							break;
						case 6:
							return;
						case 4:
							goto IL_0069;
						case 0:
							goto IL_007c;
						case 7:
							categoryId = mapCategoryId;
							return;
						case 1:
							return;
						case 3:
							goto IL_00b4;
						default:
							Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
							return;
						}
						break;
						IL_00b4:
						int num2;
						if (mapCategoryId < 0)
						{
							num = 575145127;
							num2 = num;
						}
						else
						{
							num = 575145125;
							num2 = num;
						}
					}
					goto IL_002f;
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
							int num2 = -246691827;
							while (true)
							{
								switch (num2 ^ -246691827)
								{
								case 3:
									num2 = -246691828;
									continue;
								case 1:
									break;
								case 0:
									array[num] = ((mapCategory != null) ? mapCategory.name : "INVALID");
									num++;
									num2 = -246691825;
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
					while (value != null)
					{
						int num;
						int num2;
						if (value.Length != 0)
						{
							num = 562577465;
							num2 = num;
						}
						else
						{
							num = 562577458;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x2188403B)
							{
							case 0:
								num = 562577468;
								continue;
							case 1:
							{
								int mapCategoryId = ReInput.mapping.GetMapCategoryId(value[num3]);
								if (mapCategoryId >= 0)
								{
									list.Add(mapCategoryId);
									num = 562577471;
									continue;
								}
								goto case 3;
							}
							case 9:
								break;
							case 2:
								list = new List<int>(value.Length);
								num3 = 0;
								num = 562577469;
								continue;
							case 3:
								Logger.LogWarning("Map Category \"" + value[num3] + "\" does not exist.");
								num = 562577471;
								continue;
							case 6:
								num = 562577459;
								continue;
							case 5:
								goto IL_00e0;
							case 4:
								num3++;
								num = 562577459;
								continue;
							case 7:
								goto end_IL_002e;
							default:
								if (num3 >= value.Length)
								{
									_categoryIds = list.ToArray();
									return;
								}
								goto IL_00e0;
							}
							goto end_IL_010c;
							IL_00e0:
							int num4;
							if (string.IsNullOrEmpty(value[num3]))
							{
								num = 562577471;
								num4 = num;
							}
							else
							{
								num = 562577466;
								num4 = num;
							}
							continue;
							end_IL_002e:
							break;
						}
						continue;
						end_IL_010c:
						break;
					}
					_preInitCategoryNames = null;
					_categoryIds = EmptyObjects<int>.array;
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
					while (true)
					{
						int num = -1720047483;
						while (true)
						{
							switch (num ^ -1720047481)
							{
							case 0:
								break;
							case 2:
							{
								InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutId);
								if (layout == null)
								{
									goto IL_0051;
								}
								return layout.name;
							}
							default:
								return "INVALID";
							}
							break;
							IL_0051:
							num = -1720047482;
						}
					}
				}
				set
				{
					if (!ReInput.isReady)
					{
						goto IL_0007;
					}
					goto IL_0079;
					IL_0007:
					int num = -404509194;
					goto IL_000c;
					IL_000c:
					object[] array = default(object[]);
					while (true)
					{
						switch (num ^ -404509200)
						{
						case 5:
							break;
						default:
							return;
						case 7:
							array[1] = " Layout \"";
							array[2] = value;
							array[3] = "\" does not exist.";
							num = -404509200;
							continue;
						case 2:
							return;
						case 10:
							_preInitLayoutName = null;
							num = -404509191;
							continue;
						case 8:
							goto IL_0079;
						case 0:
							Logger.LogWarning(string.Concat(array));
							num = -404509196;
							continue;
						case 6:
							_preInitLayoutName = value;
							_layoutId = -1;
							num = -404509198;
							continue;
						case 1:
							layoutId = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
							num = -404509197;
							continue;
						case 9:
							_layoutId = -1;
							return;
						case 3:
							if (_layoutId < 0)
							{
								array = new object[4] { controllerSetSelector.controllerType, null, null, null };
								num = -404509193;
								continue;
							}
							return;
						case 4:
							return;
						}
						break;
					}
					goto IL_0007;
					IL_0079:
					int num2;
					if (!string.IsNullOrEmpty(value))
					{
						num = -404509199;
						num2 = num;
					}
					else
					{
						num = -404509190;
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
						goto IL_0008;
					}
					Initialize();
					int num;
					int num2;
					if (_categoryIds == null)
					{
						num = -1271048635;
						num2 = num;
					}
					else
					{
						num = -1271048633;
						num2 = num;
					}
					goto IL_000d;
					IL_0008:
					num = -1271048634;
					goto IL_000d;
					IL_000d:
					int num3 = default(int);
					bool flag = default(bool);
					while (true)
					{
						switch (num ^ -1271048637)
						{
						case 3:
							break;
						case 5:
							return false;
						case 8:
							num3++;
							num = -1271048637;
							continue;
						case 2:
							if (ReInput.mapping.GetMapCategory(_categoryIds[num3]) != null)
							{
								flag = true;
								num = -1271048629;
								continue;
							}
							goto case 8;
						case 4:
							if (_categoryIds.Length == 0)
							{
								num = -1271048635;
							}
							else if (ReInput.isReady)
							{
								flag = false;
								num3 = 0;
								num = -1271048637;
							}
							else
							{
								num = -1271048638;
							}
							continue;
						case 0:
						{
							int num4;
							if (num3 >= _categoryIds.Length)
							{
								num = -1271048636;
								num4 = num;
							}
							else
							{
								num = -1271048639;
								num4 = num;
							}
							continue;
						}
						case 1:
							if (_categoryIds[0] >= 0)
							{
								return _layoutId >= 0;
							}
							return false;
						case 6:
							return false;
						default:
							if (!flag)
							{
								return false;
							}
							return ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutId) != null;
						}
						break;
					}
					goto IL_0008;
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
					int num = 256934415;
					while (true)
					{
						switch (num ^ 0xF50820E)
						{
						case 0:
							break;
						case 1:
						{
							int num2;
							if (source == null)
							{
								num = 256934412;
								num2 = num;
							}
							else
							{
								num = 256934413;
								num2 = num;
							}
							continue;
						}
						case 2:
							throw new ArgumentNullException("source");
						default:
							_tag = source._tag;
							_categoryIds = ArrayTools.ShallowCopy(source._categoryIds);
							_layoutId = source._layoutId;
							_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
							_preInitCategoryNames = ArrayTools.ShallowCopy(source._preInitCategoryNames);
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
					goto IL_000a;
				}
				goto IL_0184;
				IL_000a:
				int num = 105159791;
				goto IL_000f;
				IL_000f:
				int num2 = default(int);
				List<int> list = default(List<int>);
				while (true)
				{
					switch (num ^ 0x6449C6B)
					{
					case 12:
						break;
					default:
						return;
					case 11:
						goto IL_0053;
					case 10:
						goto IL_0070;
					case 0:
						if (!string.IsNullOrEmpty(_preInitCategoryNames[num2]))
						{
							int mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[num2]);
							if (mapCategoryId >= 0)
							{
								list.Add(mapCategoryId);
								num = 105159786;
								continue;
							}
							goto case 7;
						}
						goto case 1;
					case 7:
						Logger.LogWarning("Map Category \"" + _preInitCategoryNames[num2] + "\" does not exist.");
						num = 105159786;
						continue;
					case 9:
						if (num2 >= _preInitCategoryNames.Length)
						{
							_categoryIds = list.ToArray();
							_preInitCategoryNames = null;
							num = 105159777;
							continue;
						}
						goto case 0;
					case 2:
						goto IL_011e;
					case 4:
						return;
					case 5:
						_preInitLayoutName = null;
						num = 105159784;
						continue;
					case 6:
						num = 105159778;
						continue;
					case 1:
						num2++;
						num = 105159778;
						continue;
					case 8:
						goto IL_0184;
					case 3:
						return;
					}
					break;
				}
				goto IL_000a;
				IL_011e:
				if (_preInitCategoryNames != null && _preInitCategoryNames.Length != 0)
				{
					list = new List<int>(_preInitCategoryNames.Length);
					num2 = 0;
					num = 105159789;
					goto IL_000f;
				}
				goto IL_0070;
				IL_0053:
				if (_categoryIds == null)
				{
					_categoryIds = EmptyObjects<int>.array;
					num = 105159785;
					goto IL_000f;
				}
				goto IL_011e;
				IL_0184:
				if (_controllerSetSelector == null)
				{
					return;
				}
				goto IL_0053;
				IL_0070:
				if (!string.IsNullOrEmpty(_preInitLayoutName))
				{
					layoutName = _preInitLayoutName;
					num = 105159790;
					goto IL_000f;
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

			[Serialize(Name = "enabled")]
			[SerializeField]
			private bool _enabled;

			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			[Serialize(Name = "rules")]
			[SerializeField]
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
				_enabled = enabled;
				_tag = tag;
				_rules = rules;
				CheckList();
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
					goto IL_0003;
				}
				goto IL_0037;
				IL_0003:
				int num = 133924476;
				goto IL_0008;
				IL_0008:
				int num2 = default(int);
				switch (num ^ 0x7FB867E)
				{
				case 0:
					break;
				case 2:
					throw new ArgumentNullException("predicate");
				case 1:
					goto IL_0037;
				default:
				{
					for (int i = 0; i < num2; i++)
					{
						try
						{
							if (!predicate(_rules[i]))
							{
								continue;
							}
							while (true)
							{
								switch (0x7FB867C ^ 0x7FB867E)
								{
								case 0:
									break;
								default:
									goto end_IL_006d;
								case 2:
									return _rules[i];
								case 1:
									goto end_IL_006d;
								}
								continue;
								end_IL_006d:
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
				}
				goto IL_0003;
				IL_0037:
				num2 = ((_rules != null) ? _rules.Count : 0);
				num = 133924477;
				goto IL_0008;
			}

			public Rule FindLast(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					goto IL_0003;
				}
				goto IL_0037;
				IL_0003:
				int num = 2052983651;
				goto IL_0008;
				IL_0008:
				int num2 = default(int);
				switch (num ^ 0x7A5E0B62)
				{
				case 0:
					break;
				case 1:
					throw new ArgumentNullException("predicate");
				case 3:
					goto IL_0037;
				default:
					while (num2 >= 0)
					{
						try
						{
							if (predicate(_rules[num2]))
							{
								Rule result = _rules[num2];
								while (true)
								{
									switch (0x7A5E0B60 ^ 0x7A5E0B62)
									{
									case 0:
										break;
									default:
										goto end_IL_007c;
									case 1:
										goto end_IL_007c;
									case 2:
										return result;
									}
									continue;
									end_IL_007c:
									break;
								}
							}
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLast", exception);
						}
						num2--;
					}
					return null;
				}
				goto IL_0003;
				IL_0037:
				int num3 = ((_rules != null) ? _rules.Count : 0);
				num2 = num3 - 1;
				num = 2052983648;
				goto IL_0008;
			}

			public int FindIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					while (true)
					{
						switch (0x18C16872 ^ 0x18C16870)
						{
						case 0:
							continue;
						case 2:
							throw new ArgumentNullException("predicate");
						}
						break;
					}
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
							switch (0x18C16871 ^ 0x18C16870)
							{
							case 0:
								break;
							default:
								goto end_IL_0062;
							case 1:
								return i;
							case 2:
								goto end_IL_0062;
							}
							continue;
							end_IL_0062:
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

			public int FindLastIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					goto IL_0003;
				}
				goto IL_0037;
				IL_0003:
				int num = -786639714;
				goto IL_0008;
				IL_0008:
				switch (num ^ -786639715)
				{
				case 0:
					break;
				case 3:
					throw new ArgumentNullException("predicate");
				case 1:
					goto IL_0037;
				default:
					goto IL_0046;
				}
				goto IL_0003;
				IL_0037:
				if (_rules == null)
				{
					num = -786639713;
					goto IL_0008;
				}
				int num2 = _rules.Count;
				goto IL_0054;
				IL_0046:
				num2 = 0;
				goto IL_0054;
				IL_0054:
				int num3 = num2;
				for (int num4 = num3 - 1; num4 >= 0; num4--)
				{
					try
					{
						if (predicate(_rules[num4]))
						{
							while (true)
							{
								switch (-786639713 ^ -786639715)
								{
								case 0:
									break;
								default:
									goto end_IL_006f;
								case 2:
									return num4;
								case 1:
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
				while (true)
				{
					int num = 201928889;
					while (true)
					{
						switch (num ^ 0xC0930BB)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							if (value)
							{
								goto IL_0028;
							}
							return;
						case 1:
							return;
						}
						break;
						IL_0028:
						Apply();
						num = 201928890;
					}
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
					while (true)
					{
						int num = -1008310124;
						while (true)
						{
							switch (num ^ -1008310122)
							{
							case 0:
								break;
							case 2:
								value = new List<RuleSet>();
								num = -1008310121;
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
				goto IL_001c;
			}
			goto IL_0096;
			IL_006d:
			int num;
			int num2;
			if (!_enabled)
			{
				num = 845036450;
				num2 = num;
			}
			else
			{
				num = 845036449;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = 845036451;
			goto IL_0021;
			IL_0021:
			int count = default(int);
			switch (num ^ 0x325E3BA7)
			{
			case 3:
				break;
			case 2:
				count = _ruleSets.Count;
				if (count == 0)
				{
					return;
				}
				goto default;
			case 5:
				return;
			case 7:
				goto IL_006d;
			case 6:
				if (_ruleSets == null)
				{
					return;
				}
				goto case 2;
			case 1:
				goto IL_0096;
			case 4:
				return;
			default:
			{
				TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>();
				try
				{
					List<ControllerMap> list = tList.list;
					TempListPool.TList<Controller> tList2 = TempListPool.GetTList<Controller>();
					try
					{
						List<Controller> list2 = tList2.list;
						if (!list2.Contains(ReInput.controllers.Keyboard))
						{
							list2.Add(ReInput.controllers.Keyboard);
							goto IL_00fc;
						}
						goto IL_0149;
						IL_0149:
						int num3;
						int num4;
						if (!list2.Contains(ReInput.controllers.Mouse))
						{
							num3 = 845036449;
							num4 = num3;
						}
						else
						{
							num3 = 845036455;
							num4 = num3;
						}
						goto IL_0101;
						IL_00fc:
						num3 = 845036454;
						goto IL_0101;
						IL_0101:
						ControllerMap controllerMap2 = default(ControllerMap);
						int num9 = default(int);
						Rule rule = default(Rule);
						RuleSet ruleSet = default(RuleSet);
						int num11 = default(int);
						int num10 = default(int);
						int count2 = default(int);
						int count3 = default(int);
						IControllerMapStore controllerMapStore = default(IControllerMapStore);
						ControllerMap controllerMap = default(ControllerMap);
						while (true)
						{
							int num12;
							switch (num3 ^ 0x325E3BA7)
							{
							case 10:
								break;
							case 1:
								goto IL_0149;
							case 5:
								controllerMap2 = list[num9];
								num3 = 845036452;
								continue;
							case 3:
								if (rule.controllerSetSelector.Matches(controllerMap2.controller) && ArrayTools.Contains(rule.categoryIds, controllerMap2.categoryId) && controllerMap2.layoutId != rule.layoutId)
								{
									list.RemoveAt(num9);
									_player.controllers.maps.RemoveMap(controllerMap2.controllerType, controllerMap2.controllerId, controllerMap2.id);
									num3 = 845036460;
									continue;
								}
								goto case 11;
							case 7:
								ruleSet = _ruleSets[num11];
								if (ruleSet != null && ruleSet.enabled)
								{
									num3 = 845036463;
									continue;
								}
								goto IL_0538;
							case 2:
								rule = ruleSet[num10];
								if (rule != null && rule.isValid)
								{
									count2 = list.Count;
									num3 = 845036462;
									continue;
								}
								goto IL_0500;
							case 6:
								list2.Add(ReInput.controllers.Mouse);
								num3 = 845036455;
								continue;
							case 11:
								num9--;
								num3 = 845036459;
								continue;
							case 13:
								num11 = 0;
								goto IL_0545;
							case 12:
								goto IL_0296;
							case 8:
								count3 = ruleSet.Count;
								num10 = 0;
								goto IL_0528;
							case 0:
								_player.controllers.maps.GetAllMaps(list);
								list2.AddRange(_player.controllers.Controllers);
								controllerMapStore = ReInput.userDataStore as IControllerMapStore;
								num3 = 845036458;
								continue;
							case 9:
								num9 = count2 - 1;
								num3 = 845036459;
								continue;
							default:
								{
									IEnumerator<Controller> enumerator = _player.controllers.Controllers.GetEnumerator();
									try
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
												int num6 = 845036454;
												while (true)
												{
													int num7;
													switch (num6 ^ 0x325E3BA7)
													{
													case 4:
														num6 = 845036452;
														continue;
													case 3:
														break;
													case 2:
														controllerMap = _player.controllers.maps.GetMap(current, categoryIds[num5], rule.layoutId);
														num6 = 845036455;
														continue;
													default:
														if (controllerMap == null)
														{
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
																	_player.controllers.maps.AddMap(current, controllerMap);
																	goto IL_04a2;
																}
															}
															goto IL_046b;
														}
														goto IL_04a2;
													case 1:
														goto IL_04af;
														IL_044a:
														while (true)
														{
															switch (num7 ^ 0x325E3BA7)
															{
															case 0:
																num7 = 845036454;
																continue;
															case 1:
																break;
															case 4:
																goto IL_04a2;
															case 2:
																goto IL_04af;
															default:
																goto end_IL_0360;
															}
															break;
														}
														goto IL_046b;
														IL_04af:
														if (num5 < categoryIds.Length)
														{
															goto case 2;
														}
														num7 = 845036452;
														goto IL_044a;
														IL_046b:
														_player.controllers.maps.LoadMap(current.type, current.id, categoryIds[num5], rule.layoutId, true);
														num7 = 845036451;
														goto IL_044a;
														IL_04a2:
														num5++;
														num7 = 845036453;
														goto IL_044a;
													}
													break;
												}
												continue;
												end_IL_0360:
												break;
											}
										}
									}
									finally
									{
										if (enumerator != null)
										{
											while (true)
											{
												IL_04d3:
												int num8 = 845036454;
												while (true)
												{
													switch (num8 ^ 0x325E3BA7)
													{
													case 2:
														break;
													default:
														goto end_IL_04d8;
													case 1:
														goto IL_04f1;
													case 0:
														goto end_IL_04d8;
													}
													goto IL_04d3;
													IL_04f1:
													enumerator.Dispose();
													num8 = 845036455;
													continue;
													end_IL_04d8:
													break;
												}
												break;
											}
										}
									}
									goto IL_0500;
								}
								IL_0500:
								num10++;
								goto IL_0506;
								IL_0506:
								num12 = 845036453;
								goto IL_050b;
								IL_0538:
								num11++;
								num12 = 845036452;
								goto IL_050b;
								IL_050b:
								switch (num12 ^ 0x325E3BA7)
								{
								case 0:
									break;
								case 2:
									goto IL_0528;
								case 1:
									goto IL_0538;
								default:
									goto IL_0545;
								}
								goto IL_0506;
								IL_0545:
								if (num11 >= count)
								{
									return;
								}
								goto case 7;
								IL_0528:
								if (num10 < count3)
								{
									goto case 2;
								}
								num12 = 845036454;
								goto IL_050b;
							}
							break;
							IL_0296:
							int num13;
							if (num9 < 0)
							{
								num3 = 845036451;
								num13 = num3;
							}
							else
							{
								num3 = 845036450;
								num13 = num3;
							}
						}
						goto IL_00fc;
					}
					finally
					{
						if (tList2 != null)
						{
							while (true)
							{
								IL_0553:
								int num14 = 845036454;
								while (true)
								{
									switch (num14 ^ 0x325E3BA7)
									{
									case 2:
										break;
									default:
										goto end_IL_0558;
									case 1:
										goto IL_0571;
									case 0:
										goto end_IL_0558;
									}
									goto IL_0553;
									IL_0571:
									((IDisposable)tList2).Dispose();
									num14 = 845036455;
									continue;
									end_IL_0558:
									break;
								}
								break;
							}
						}
					}
				}
				finally
				{
					if (tList != null)
					{
						while (true)
						{
							IL_0585:
							int num15 = 845036453;
							while (true)
							{
								switch (num15 ^ 0x325E3BA7)
								{
								case 0:
									break;
								default:
									goto end_IL_058a;
								case 2:
									goto IL_05a3;
								case 1:
									goto end_IL_058a;
								}
								goto IL_0585;
								IL_05a3:
								((IDisposable)tList).Dispose();
								num15 = 845036454;
								continue;
								end_IL_058a:
								break;
							}
							break;
						}
					}
				}
			}
			}
			goto IL_001c;
			IL_0096:
			Action applyCalledEvent = _ApplyCalledEvent;
			if (applyCalledEvent != null)
			{
				applyCalledEvent();
				num = 845036448;
				goto IL_0021;
			}
			goto IL_006d;
		}

		public void LoadDefaults()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0060;
			IL_000d:
			int num = -1096186094;
			goto IL_0012;
			IL_0012:
			List<RuleSet> list = default(List<RuleSet>);
			int num2 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num3;
				switch (num ^ -1096186096)
				{
				case 0:
					break;
				default:
					return;
				case 10:
					_ruleSets = list;
					num = -1096186088;
					continue;
				case 7:
					goto IL_0060;
				case 3:
					goto IL_006d;
				case 8:
					Apply();
					num = -1096186091;
					continue;
				case 4:
					if (_startingSettings != null)
					{
						_enabled = _startingSettings.enabled;
						_loadFromUserDataStore = _startingSettings.loadFromUserDataStore;
						num = -1096186086;
						continue;
					}
					goto case 10;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 1:
					num3 = 0;
					goto IL_00ea;
				case 11:
					goto IL_00f7;
				case 9:
					if (_startingSettings.startingRuleSets != null)
					{
						num3 = _startingSettings.startingRuleSets.Length;
						goto IL_00ea;
					}
					num = -1096186095;
					continue;
				case 6:
				{
					RuleSet controllerMapLayoutManagerRuleSetInstance = ReInput.mapping.GetControllerMapLayoutManagerRuleSetInstance(_startingSettings.startingRuleSets[num2].id);
					controllerMapLayoutManagerRuleSetInstance.enabled = _startingSettings.startingRuleSets[num2].startEnabled;
					list.Add(controllerMapLayoutManagerRuleSetInstance);
					num2++;
					num = -1096186093;
					continue;
				}
				case 5:
					return;
					IL_00ea:
					num4 = num3;
					num2 = 0;
					num = -1096186093;
					continue;
				}
				break;
				IL_00f7:
				int num5;
				if (_startingSettings != null)
				{
					num = -1096186087;
					num5 = num;
				}
				else
				{
					num = -1096186095;
					num5 = num;
				}
				continue;
				IL_006d:
				int num6;
				if (num2 >= num4)
				{
					num = -1096186092;
					num6 = num;
				}
				else
				{
					num = -1096186090;
					num6 = num;
				}
			}
			goto IL_000d;
			IL_0060:
			list = new List<RuleSet>();
			num = -1096186085;
			goto IL_0012;
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
				while (true)
				{
					int num = -1013983746;
					while (true)
					{
						switch (num ^ -1013983745)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return string.Empty;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = -1013983745;
					}
				}
			}
			string result = default(string);
			try
			{
				result = Export().ToJsonString();
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_0053:
					int num2 = -1013983746;
					while (true)
					{
						switch (num2 ^ -1013983745)
						{
						case 2:
							break;
						default:
							goto end_IL_0058;
						case 1:
							Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
							num2 = -1013983745;
							continue;
						case 0:
							result = string.Empty;
							num2 = -1013983748;
							continue;
						case 3:
							goto end_IL_0058;
						}
						goto IL_0053;
						continue;
						end_IL_0058:
						break;
					}
					break;
				}
			}
			return result;
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
					int num = -1582044784;
					while (true)
					{
						switch (num ^ -1582044783)
						{
						case 0:
							break;
						default:
							goto end_IL_0063;
						case 1:
							goto IL_007c;
						case 2:
							goto end_IL_0063;
						}
						goto IL_005e;
						IL_007c:
						result = false;
						num = -1582044781;
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
			ExportDataToSerializedObject(serializedObject);
			return serializedObject;
		}

		private void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
			if (serializedObject.xmlInfo == null)
			{
				serializedObject.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0013;
			}
			goto IL_0038;
			IL_0038:
			serializedObject.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			int num = 699799690;
			goto IL_0018;
			IL_0013:
			num = 699799688;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ 0x29B61889)
				{
				case 2:
					break;
				case 1:
					goto IL_0038;
				case 3:
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
					num = 699799689;
					continue;
				default:
					serializedObject.Add("enabled", _enabled);
					serializedObject.Add("loadFromUserDataStore", _loadFromUserDataStore);
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
				int num = 1332210077;
				while (true)
				{
					switch (num ^ 0x4F67E99C)
					{
					case 3:
						break;
					case 0:
						serializedObject.TryGetDeserializedValueByRef("ruleSets", ref value);
						num = 1332210072;
						continue;
					case 2:
						serializedObject.TryGetDeserializedValueByRef("loadFromUserDataStore", ref _loadFromUserDataStore);
						value = new List<RuleSet>();
						num = 1332210076;
						continue;
					case 1:
						_ruleSets = null;
						serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
						num = 1332210078;
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
