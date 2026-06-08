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

			public YHTAmSgoHymgTIiCLrqYNhoUTqdP[] startingRuleSets;

			public StartingSettings(bool enabled, bool loadFromUserDataStore, YHTAmSgoHymgTIiCLrqYNhoUTqdP[] startingRuleSets)
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

			[Serialize(Name = "controllerSetSelector")]
			[SerializeField]
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
					goto IL_004d;
					IL_004d:
					int num;
					if (!value.hasControllerType)
					{
						Logger.LogError(string.Concat(value.type, " is not allowed. Each Controller Type has its own unique Layouts and a single Layout cannot be set for all Controller Types. ControllerSelector.type has been changed to ControllerSelector.Type.ControllerType."), requiredThreadSafety: true);
						num = -1073279498;
						goto IL_0010;
					}
					goto IL_0031;
					IL_000b:
					num = -1073279501;
					goto IL_0010;
					IL_0010:
					while (true)
					{
						switch (num ^ -1073279497)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0031;
						case 1:
							value.type = ControllerSetSelector.Type.ControllerType;
							num = -1073279499;
							continue;
						case 4:
							goto IL_004d;
						case 3:
							return;
						}
						break;
					}
					goto IL_000b;
					IL_0031:
					_controllerSetSelector = value;
					num = -1073279500;
					goto IL_0010;
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
					if (value >= 0)
					{
						goto IL_003b;
					}
					_categoryIds = EmptyObjects<int>.array;
					goto IL_005e;
					IL_007c:
					_categoryIds = new int[1];
					int num = -1257269104;
					goto IL_0016;
					IL_005e:
					_preInitCategoryNames = null;
					num = -1257269100;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -1257269103)
						{
						case 0:
							num = -1257269101;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							goto IL_005e;
						case 1:
							_categoryIds[0] = value;
							num = -1257269102;
							continue;
						case 4:
							goto IL_007c;
						case 5:
							return;
						}
						break;
					}
					goto IL_003b;
					IL_003b:
					if (_categoryIds != null)
					{
						int num2;
						if (_categoryIds.Length == 0)
						{
							num = -1257269099;
							num2 = num;
						}
						else
						{
							num = -1257269104;
							num2 = num;
						}
						goto IL_0016;
					}
					goto IL_007c;
				}
			}

			public int[] categoryIds
			{
				get
				{
					Initialize();
					int[] array = _categoryIds;
					if (array == null)
					{
						int[] array2 = default(int[]);
						while (true)
						{
							int num = -1398845933;
							while (true)
							{
								switch (num ^ -1398845935)
								{
								case 0:
									break;
								case 2:
									array2 = (_categoryIds = EmptyObjects<int>.array);
									num = -1398845936;
									continue;
								default:
									goto end_IL_0010;
								}
								break;
							}
							continue;
							end_IL_0010:
							break;
						}
						array = array2;
					}
					return array;
				}
				set
				{
					if (value == null)
					{
						value = EmptyObjects<int>.array;
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
					goto IL_0042;
					IL_0004:
					int num = 968311572;
					goto IL_0009;
					IL_0009:
					while (true)
					{
						switch (num ^ 0x39B74316)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							value = -1;
							num = 968311570;
							continue;
						case 1:
							_preInitLayoutName = null;
							num = 968311573;
							continue;
						case 4:
							goto IL_0042;
						case 3:
							return;
						}
						break;
					}
					goto IL_0004;
					IL_0042:
					_layoutId = value;
					num = 968311575;
					goto IL_0009;
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
							if (_preInitCategoryNames.Length > 0)
							{
								return _preInitCategoryNames[0];
							}
							goto IL_001a;
						}
						goto IL_0040;
					}
					Initialize();
					int num;
					int num2;
					if (_categoryIds == null)
					{
						num = -299945349;
						num2 = num;
					}
					else
					{
						num = -299945345;
						num2 = num;
					}
					goto IL_001f;
					IL_001a:
					num = -299945346;
					goto IL_001f;
					IL_0040:
					return null;
					IL_001f:
					while (true)
					{
						switch (num ^ -299945345)
						{
						case 2:
							break;
						case 1:
							goto IL_0040;
						case 4:
							return null;
						case 0:
							goto IL_0089;
						default:
							return "INVALID";
						}
						break;
						IL_0089:
						if (_categoryIds.Length != 0)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
							if (mapCategory != null)
							{
								return mapCategory.name;
							}
							num = -299945348;
						}
						else
						{
							num = -299945349;
						}
					}
					goto IL_001a;
				}
				set
				{
					if (!ReInput.isReady)
					{
						_preInitCategoryNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
						goto IL_0024;
					}
					goto IL_0076;
					IL_0029:
					int num;
					while (true)
					{
						switch (num ^ 0x5BE37D08)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0052;
						case 5:
							return;
						case 1:
							goto IL_0076;
						case 3:
							goto IL_0098;
						case 4:
							_categoryIds = EmptyObjects<int>.array;
							num = 1541635341;
							continue;
						case 6:
							return;
						}
						break;
					}
					goto IL_0024;
					IL_0098:
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
					if (mapCategoryId >= 0)
					{
						categoryId = mapCategoryId;
						return;
					}
					goto IL_0052;
					IL_0052:
					Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
					num = 1541635342;
					goto IL_0029;
					IL_0076:
					if (string.IsNullOrEmpty(value))
					{
						_preInitCategoryNames = null;
						_categoryIds = EmptyObjects<int>.array;
						return;
					}
					goto IL_0098;
					IL_0024:
					num = 1541635340;
					goto IL_0029;
				}
			}

			public string[] categoryNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (_preInitCategoryNames != null)
						{
							return _preInitCategoryNames;
						}
						goto IL_000f;
					}
					Initialize();
					if (_categoryIds == null)
					{
						return EmptyObjects<string>.array;
					}
					string[] array = new string[_categoryIds.Length];
					int num = 0;
					int num2 = 63522020;
					goto IL_0014;
					IL_000f:
					num2 = 63522022;
					goto IL_0014;
					IL_0014:
					while (true)
					{
						string[] array2;
						int num3;
						string obj;
						switch (num2 ^ 0x3C944E5)
						{
						case 2:
							break;
						case 3:
							return EmptyObjects<string>.array;
						case 0:
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[num]);
							array2 = array;
							num3 = num;
							obj = ((mapCategory != null) ? mapCategory.name : "INVALID");
							goto IL_008e;
						}
						default:
							if (num >= _categoryIds.Length)
							{
								return array;
							}
							goto case 0;
						}
						break;
						IL_008e:
						array2[num3] = obj;
						num++;
						num2 = 63522020;
					}
					goto IL_000f;
				}
				set
				{
					if (!ReInput.isReady)
					{
						goto IL_000a;
					}
					goto IL_011f;
					IL_000a:
					int num = -1712359818;
					goto IL_000f;
					IL_000f:
					int mapCategoryId = default(int);
					List<int> list = default(List<int>);
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -1712359824)
						{
						case 11:
							break;
						default:
							return;
						case 6:
							_preInitCategoryNames = ((value != null && value.Length > 0) ? value : null);
							_categoryIds = EmptyObjects<int>.array;
							return;
						case 8:
							if (mapCategoryId >= 0)
							{
								list.Add(mapCategoryId);
								num = -1712359814;
								continue;
							}
							goto case 0;
						case 7:
							list = new List<int>(value.Length);
							num2 = 0;
							num = -1712359819;
							continue;
						case 5:
							if (num2 >= value.Length)
							{
								_categoryIds = list.ToArray();
								num = -1712359815;
								continue;
							}
							goto case 2;
						case 1:
							_categoryIds = EmptyObjects<int>.array;
							return;
						case 0:
							Logger.LogWarning("Map Category \"" + value[num2] + "\" does not exist.");
							num = -1712359814;
							continue;
						case 2:
							if (!string.IsNullOrEmpty(value[num2]))
							{
								mapCategoryId = ReInput.mapping.GetMapCategoryId(value[num2]);
								num = -1712359816;
								continue;
							}
							goto case 10;
						case 10:
							num2++;
							num = -1712359819;
							continue;
						case 3:
							goto IL_011f;
						case 4:
							goto IL_013b;
						case 9:
							return;
						}
						break;
					}
					goto IL_000a;
					IL_013b:
					_preInitCategoryNames = null;
					num = -1712359823;
					goto IL_000f;
					IL_011f:
					if (value != null)
					{
						int num3;
						if (value.Length != 0)
						{
							num = -1712359817;
							num3 = num;
						}
						else
						{
							num = -1712359820;
							num3 = num;
						}
						goto IL_000f;
					}
					goto IL_013b;
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
						_preInitLayoutName = value;
						_layoutId = -1;
						return;
					}
					object[] array = default(object[]);
					while (true)
					{
						int num;
						if (string.IsNullOrEmpty(value))
						{
							_preInitLayoutName = null;
							num = -286389817;
							goto IL_001e;
						}
						goto IL_00aa;
						IL_001e:
						while (true)
						{
							switch (num ^ -286389821)
							{
							case 0:
								num = -286389824;
								continue;
							default:
								return;
							case 1:
								array = new object[4] { controllerSetSelector.controllerType, " Layout \"", value, "\" does not exist." };
								num = -286389818;
								continue;
							case 5:
								Logger.LogWarning(string.Concat(array));
								num = -286389823;
								continue;
							case 3:
								break;
							case 6:
								goto IL_00aa;
							case 4:
								_layoutId = -1;
								return;
							case 2:
								return;
							}
							break;
						}
						continue;
						IL_00aa:
						layoutId = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
						int num2;
						if (_layoutId < 0)
						{
							num = -286389822;
							num2 = num;
						}
						else
						{
							num = -286389823;
							num2 = num;
						}
						goto IL_001e;
					}
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
					int num2 = default(int);
					bool flag = default(bool);
					while (true)
					{
						int num = -1103763922;
						while (true)
						{
							switch (num ^ -1103763928)
							{
							case 2:
								break;
							case 3:
								num = -1103763928;
								continue;
							case 4:
								return false;
							case 1:
								num2++;
								num = -1103763928;
								continue;
							case 5:
								if (ReInput.mapping.GetMapCategory(_categoryIds[num2]) != null)
								{
									flag = true;
									num = -1103763927;
									continue;
								}
								goto case 1;
							case 6:
								if (_categoryIds != null)
								{
									if (_categoryIds.Length != 0)
									{
										if (!ReInput.isReady)
										{
											if (_categoryIds[0] >= 0)
											{
												return _layoutId >= 0;
											}
											return false;
										}
										flag = false;
										num = -1103763936;
									}
									else
									{
										num = -1103763924;
									}
									continue;
								}
								goto case 4;
							case 0:
							{
								int num3;
								if (num2 < _categoryIds.Length)
								{
									num = -1103763923;
									num3 = num;
								}
								else
								{
									num = -1103763921;
									num3 = num;
								}
								continue;
							}
							case 8:
								num2 = 0;
								num = -1103763925;
								continue;
							default:
								if (!flag)
								{
									return false;
								}
								return ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutId) != null;
							}
							break;
						}
					}
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
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				_tag = source._tag;
				_categoryIds = ArrayTools.ShallowCopy(source._categoryIds);
				_layoutId = source._layoutId;
				_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
				_preInitCategoryNames = ArrayTools.ShallowCopy(source._preInitCategoryNames);
				_preInitLayoutName = source._preInitLayoutName;
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
				while (_controllerSetSelector != null)
				{
					while (true)
					{
						IL_015e:
						int num;
						int num2;
						if (_categoryIds == null)
						{
							num = 941419093;
							num2 = num;
						}
						else
						{
							num = 941419092;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x381CEA5B)
							{
							case 12:
								num = 941419098;
								continue;
							default:
								return;
							case 1:
								break;
							case 4:
								if (!string.IsNullOrEmpty(_preInitCategoryNames[num3]))
								{
									int mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[num3]);
									if (mapCategoryId >= 0)
									{
										list.Add(mapCategoryId);
										num = 941419094;
										continue;
									}
									goto case 8;
								}
								goto case 10;
							case 14:
								_categoryIds = EmptyObjects<int>.array;
								num = 941419092;
								continue;
							case 8:
								Logger.LogWarning("Map Category \"" + _preInitCategoryNames[num3] + "\" does not exist.");
								num = 941419089;
								continue;
							case 13:
								num = 941419089;
								continue;
							case 0:
								_categoryIds = list.ToArray();
								num = 941419097;
								continue;
							case 6:
								num = 941419096;
								continue;
							case 9:
								_preInitLayoutName = null;
								num = 941419100;
								continue;
							case 10:
								num3++;
								num = 941419096;
								continue;
							case 2:
								_preInitCategoryNames = null;
								num = 941419102;
								continue;
							case 3:
								goto IL_013f;
							case 11:
								goto IL_015e;
							case 5:
								if (!string.IsNullOrEmpty(_preInitLayoutName))
								{
									layoutName = _preInitLayoutName;
									num = 941419090;
									continue;
								}
								return;
							case 15:
								if (_preInitCategoryNames != null && _preInitCategoryNames.Length != 0)
								{
									list = new List<int>(_preInitCategoryNames.Length);
									num3 = 0;
									num = 941419101;
									continue;
								}
								goto case 5;
							case 7:
								return;
							}
							break;
							IL_013f:
							int num4;
							if (num3 >= _preInitCategoryNames.Length)
							{
								num = 941419099;
								num4 = num;
							}
							else
							{
								num = 941419103;
								num4 = num;
							}
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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Preserve]
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
					while (true)
					{
						int num = -600400635;
						while (true)
						{
							switch (num ^ -600400636)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								goto IL_0024;
							case 0:
								return;
							}
							break;
							IL_0024:
							_rules[index] = value;
							num = -600400636;
						}
					}
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
						Rule result = _rules[i];
						while (true)
						{
							switch (-1483742850 ^ -1483742852)
							{
							case 0:
								break;
							default:
								goto end_IL_004a;
							case 1:
								goto end_IL_004a;
							case 2:
								return result;
							}
							continue;
							end_IL_004a:
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
					throw new ArgumentNullException("predicate");
				}
				int num2;
				while (true)
				{
					if (_rules == null)
					{
						int num = -802335143;
						while (true)
						{
							switch (num ^ -802335141)
							{
							case 0:
								num = -802335142;
								continue;
							case 1:
								break;
							default:
								goto IL_003b;
							}
							break;
						}
						continue;
					}
					num2 = _rules.Count;
					break;
					IL_003b:
					num2 = 0;
					break;
				}
				int num3 = num2;
				for (int num4 = num3 - 1; num4 >= 0; num4--)
				{
					try
					{
						if (predicate(_rules[num4]))
						{
							return _rules[num4];
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLast", exception);
					}
				}
				return null;
			}

			public int FindIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				while (true)
				{
					int num = ((_rules != null) ? _rules.Count : 0);
					int i = 0;
					int num2 = -1861054033;
					while (true)
					{
						switch (num2 ^ -1861054035)
						{
						case 0:
							goto IL_000e;
						case 1:
							break;
						default:
							for (; i < num; i++)
							{
								try
								{
									if (!predicate(_rules[i]))
									{
										continue;
									}
									int result = i;
									while (true)
									{
										switch (-1861054036 ^ -1861054035)
										{
										case 2:
											break;
										default:
											goto end_IL_0064;
										case 0:
											goto end_IL_0064;
										case 1:
											return result;
										}
										continue;
										end_IL_0064:
										break;
									}
								}
								catch (Exception exception)
								{
									while (true)
									{
										IL_008e:
										int num3 = -1861054033;
										while (true)
										{
											switch (num3 ^ -1861054035)
											{
											case 0:
												break;
											default:
												goto end_IL_0093;
											case 2:
												goto IL_00ac;
											case 1:
												goto end_IL_0093;
											}
											goto IL_008e;
											IL_00ac:
											ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindIndex", exception);
											num3 = -1861054036;
											continue;
											end_IL_0093:
											break;
										}
										break;
									}
								}
							}
							return -1;
						}
						break;
						IL_000e:
						num2 = -1861054036;
					}
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
							while (true)
							{
								switch (-268343780 ^ -268343779)
								{
								case 2:
									break;
								default:
									goto end_IL_003f;
								case 1:
									return num2;
								case 0:
									goto end_IL_003f;
								}
								continue;
								end_IL_003f:
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
				while (true)
				{
					int num = -1872897173;
					while (true)
					{
						switch (num ^ -1872897175)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						_rules.Add(item);
						num = -1872897176;
					}
				}
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
					while (true)
					{
						int num = 956482467;
						while (true)
						{
							switch (num ^ 0x3902C3A1)
							{
							case 0:
								break;
							case 2:
								value = new List<RuleSet>();
								num = 956482464;
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
			while (true)
			{
				int num = 681275099;
				while (true)
				{
					switch (num ^ 0x289B6EDA)
					{
					case 3:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (player != null)
						{
							num = 681275098;
							num2 = num;
						}
						else
						{
							num = 681275103;
							num2 = num;
						}
						continue;
					}
					case 2:
						_reInputId = ReInput.id;
						_player = player;
						_startingSettings = startingSettings;
						num = 681275102;
						continue;
					case 5:
						throw new ArgumentNullException("player");
					case 0:
						if (startingSettings == null)
						{
							throw new ArgumentNullException("startingSettings");
						}
						goto case 2;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public void Apply()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int count = default(int);
			ControllerMap controllerMap2 = default(ControllerMap);
			int num3 = default(int);
			Rule rule = default(Rule);
			IControllerMapStore controllerMapStore = default(IControllerMapStore);
			int num8 = default(int);
			RuleSet ruleSet = default(RuleSet);
			int count3 = default(int);
			int num7 = default(int);
			int count2 = default(int);
			ControllerMap controllerMap = default(ControllerMap);
			Controller current = default(Controller);
			int[] categoryIds = default(int[]);
			int num5 = default(int);
			while (true)
			{
				Action applyCalledEvent = _ApplyCalledEvent;
				int num = 79554732;
				while (true)
				{
					switch (num ^ 0x4BDE8AC)
					{
					case 5:
						num = 79554733;
						continue;
					case 7:
					{
						int num11;
						if (_ruleSets != null)
						{
							num = 79554734;
							num11 = num;
						}
						else
						{
							num = 79554735;
							num11 = num;
						}
						continue;
					}
					case 0:
						if (applyCalledEvent != null)
						{
							applyCalledEvent();
							num = 79554730;
							continue;
						}
						goto case 6;
					case 3:
						return;
					case 2:
						count = _ruleSets.Count;
						if (count == 0)
						{
							return;
						}
						goto default;
					case 1:
						break;
					case 6:
						if (!_enabled)
						{
							return;
						}
						goto case 7;
					default:
					{
						using (TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>())
						{
							List<ControllerMap> list = tList.list;
							using (TempListPool.TList<Controller> tList2 = TempListPool.GetTList<Controller>())
							{
								List<Controller> list2 = tList2.list;
								if (!list2.Contains(ReInput.controllers.Keyboard))
								{
									list2.Add(ReInput.controllers.Keyboard);
									goto IL_00ff;
								}
								goto IL_0268;
								IL_0219:
								_player.controllers.maps.GetAllMaps(list);
								int num2 = 79554727;
								goto IL_0104;
								IL_00ff:
								num2 = 79554733;
								goto IL_0104;
								IL_0104:
								while (true)
								{
									int num9;
									switch (num2 ^ 0x4BDE8AC)
									{
									case 4:
										break;
									case 6:
										controllerMap2 = list[num3];
										if (rule.controllerSetSelector.Matches(controllerMap2.controller) && ArrayTools.Contains(rule.categoryIds, controllerMap2.categoryId))
										{
											goto IL_0180;
										}
										goto case 7;
									case 8:
										controllerMapStore = ReInput.userDataStore as IControllerMapStore;
										num8 = 0;
										goto IL_0552;
									case 7:
										num3--;
										num2 = 79554732;
										continue;
									case 2:
										ruleSet = _ruleSets[num8];
										if (ruleSet != null && ruleSet.enabled)
										{
											count3 = ruleSet.Count;
											num7 = 0;
											num2 = 79554720;
											continue;
										}
										goto IL_0545;
									case 13:
										goto IL_0219;
									case 10:
										num3 = count2 - 1;
										num2 = 79554732;
										continue;
									case 3:
										if (rule.isValid)
										{
											count2 = list.Count;
											num2 = 79554726;
											continue;
										}
										goto IL_050d;
									case 1:
										goto IL_0268;
									case 11:
										list2.AddRange(_player.controllers.Controllers);
										num2 = 79554724;
										continue;
									case 5:
										rule = ruleSet[num7];
										if (rule != null)
										{
											num2 = 79554735;
											continue;
										}
										goto IL_050d;
									case 9:
										list.RemoveAt(num3);
										_player.controllers.maps.RemoveMap(controllerMap2.controllerType, controllerMap2.controllerId, controllerMap2.id);
										num2 = 79554731;
										continue;
									default:
									{
										if (num3 >= 0)
										{
											goto case 6;
										}
										using (IEnumerator<Controller> enumerator = _player.controllers.Controllers.GetEnumerator())
										{
											while (true)
											{
												IL_048f:
												if (enumerator.MoveNext())
												{
													goto IL_0360;
												}
												int num4 = 79554728;
												goto IL_0439;
												IL_03ad:
												controllerMap = _player.controllers.maps.GetMap(current, categoryIds[num5], rule.layoutId);
												int num6;
												if (controllerMap == null)
												{
													num6 = 79554732;
													goto IL_0338;
												}
												goto IL_047b;
												IL_0360:
												current = enumerator.Current;
												if (!rule.controllerSetSelector.Matches(current))
												{
													continue;
												}
												num6 = 79554734;
												goto IL_0338;
												IL_0434:
												num4 = 79554734;
												goto IL_0439;
												IL_0338:
												while (true)
												{
													switch (num6 ^ 0x4BDE8AC)
													{
													case 4:
														num6 = 79554729;
														continue;
													case 5:
														break;
													case 2:
														goto IL_0383;
													case 0:
														goto IL_039b;
													case 3:
														goto IL_03ad;
													default:
														goto IL_03e3;
													}
													break;
													IL_039b:
													if (_loadFromUserDataStore)
													{
														num6 = 79554733;
														continue;
													}
													goto IL_04c5;
												}
												goto IL_0360;
												IL_03e3:
												if (controllerMapStore != null)
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
														goto IL_0434;
													}
												}
												goto IL_04c5;
												IL_047b:
												num5++;
												num4 = 79554729;
												goto IL_0439;
												IL_0439:
												while (true)
												{
													switch (num4 ^ 0x4BDE8AC)
													{
													case 6:
														break;
													default:
														goto end_IL_048f;
													case 5:
														goto IL_0469;
													case 3:
														goto IL_047b;
													case 1:
														num4 = 79554735;
														continue;
													case 7:
														goto IL_048f;
													case 2:
														_player.controllers.maps.AddMap(current, controllerMap);
														num4 = 79554733;
														continue;
													case 0:
														goto IL_04c5;
													case 4:
														goto end_IL_048f;
													}
													break;
												}
												goto IL_0434;
												IL_0383:
												categoryIds = rule.categoryIds;
												num5 = 0;
												goto IL_0469;
												IL_0469:
												if (num5 < categoryIds.Length)
												{
													goto IL_03ad;
												}
												num4 = 79554731;
												goto IL_0439;
												IL_04c5:
												_player.controllers.maps.LoadMap(current.type, current.id, categoryIds[num5], rule.layoutId, startEnabled: true);
												num4 = 79554735;
												goto IL_0439;
												continue;
												end_IL_048f:
												break;
											}
										}
										goto IL_050d;
									}
									case 12:
										goto IL_0535;
										IL_0552:
										if (num8 >= count)
										{
											return;
										}
										goto case 2;
										IL_050d:
										num7++;
										goto IL_0513;
										IL_0513:
										num9 = 79554733;
										goto IL_0518;
										IL_0545:
										num8++;
										num9 = 79554735;
										goto IL_0518;
										IL_0518:
										switch (num9 ^ 0x4BDE8AC)
										{
										case 0:
											break;
										case 1:
											goto IL_0535;
										case 2:
											goto IL_0545;
										default:
											goto IL_0552;
										}
										goto IL_0513;
										IL_0535:
										if (num7 < count3)
										{
											goto case 5;
										}
										num9 = 79554734;
										goto IL_0518;
									}
									break;
									IL_0180:
									int num10;
									if (controllerMap2.layoutId == rule.layoutId)
									{
										num2 = 79554731;
										num10 = num2;
									}
									else
									{
										num2 = 79554725;
										num10 = num2;
									}
								}
								goto IL_00ff;
								IL_0268:
								if (!list2.Contains(ReInput.controllers.Mouse))
								{
									list2.Add(ReInput.controllers.Mouse);
									num2 = 79554721;
									goto IL_0104;
								}
								goto IL_0219;
							}
						}
					}
					}
					break;
				}
			}
		}

		public void LoadDefaults()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_007f;
			IL_000d:
			int num = 110686540;
			goto IL_0012;
			IL_0012:
			RuleSet controllerMapLayoutManagerRuleSetInstance = default(RuleSet);
			int num3 = default(int);
			List<RuleSet> list = default(List<RuleSet>);
			int num4 = default(int);
			while (true)
			{
				int num2;
				switch (num ^ 0x698F14F)
				{
				case 10:
					break;
				case 0:
					controllerMapLayoutManagerRuleSetInstance = ReInput.mapping.GetControllerMapLayoutManagerRuleSetInstance(_startingSettings.startingRuleSets[num3].id);
					if (controllerMapLayoutManagerRuleSetInstance == null)
					{
						Logger.LogError("Invalid Layout Manager Rule Set is assigned to Player. This should not be possible. If you are seeing this error, this is a sign of serialized data corruption, usually caused by a bad source control merge.");
						num = 110686539;
						continue;
					}
					goto case 5;
				case 1:
					goto IL_007f;
				case 4:
					num3++;
					num = 110686536;
					continue;
				case 5:
					controllerMapLayoutManagerRuleSetInstance.enabled = _startingSettings.startingRuleSets[num3].startEnabled;
					list.Add(controllerMapLayoutManagerRuleSetInstance);
					num = 110686539;
					continue;
				case 7:
					if (num3 < num4)
					{
						goto case 0;
					}
					if (_startingSettings != null)
					{
						_enabled = _startingSettings.enabled;
						_loadFromUserDataStore = _startingSettings.loadFromUserDataStore;
						num = 110686535;
						continue;
					}
					goto case 8;
				case 2:
					num2 = 0;
					goto IL_0123;
				case 8:
					_ruleSets = list;
					num = 110686537;
					continue;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 9:
					if (_startingSettings.startingRuleSets != null)
					{
						num2 = _startingSettings.startingRuleSets.Length;
						goto IL_0123;
					}
					num = 110686541;
					continue;
				default:
					{
						Apply();
						return;
					}
					IL_0123:
					num4 = num2;
					num3 = 0;
					num = 110686536;
					continue;
				}
				break;
			}
			goto IL_000d;
			IL_007f:
			list = new List<RuleSet>();
			int num5;
			if (_startingSettings != null)
			{
				num = 110686534;
				num5 = num;
			}
			else
			{
				num = 110686541;
				num5 = num;
			}
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
				return Export().ToXmlString(writeDocumentTag: true);
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
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
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
				while (true)
				{
					int num = 1471767499;
					while (true)
					{
						switch (num ^ 0x57B963CA)
						{
						case 0:
							break;
						case 1:
							goto IL_0057;
						default:
							return false;
						}
						break;
						IL_0057:
						Logger.LogError("Error importing " + GetType().Name + " data from XML. " + ex.Message);
						num = 1471767496;
					}
				}
			}
		}

		public bool ImportJson(string jsonString)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			try
			{
				Import(SerializedObject.FromJson(GetType(), jsonString));
				Apply();
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + GetType().Name + " data from JSON. " + ex.Message);
				return false;
			}
		}

		private SerializedObject Export()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			while (true)
			{
				int num = -527773835;
				while (true)
				{
					switch (num ^ -527773836)
					{
					case 2:
						break;
					case 1:
						goto IL_002b;
					default:
						return serializedObject;
					}
					break;
					IL_002b:
					ExportDataToSerializedObject(serializedObject);
					num = -527773836;
				}
			}
		}

		private void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
			if (serializedObject.xmlInfo == null)
			{
				goto IL_0008;
			}
			goto IL_003f;
			IL_0008:
			int num = 74779199;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x4750A3E)
				{
				case 3:
					break;
				case 1:
					serializedObject.xmlInfo = new SerializedObject.XmlInfo();
					num = 74779198;
					continue;
				case 0:
					goto IL_003f;
				default:
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
					});
					serializedObject.Add("enabled", _enabled);
					serializedObject.Add("loadFromUserDataStore", _loadFromUserDataStore);
					serializedObject.Add("ruleSets", _ruleSets);
					return;
				}
				break;
			}
			goto IL_0008;
			IL_003f:
			serializedObject.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				prefix = "xmlns",
				localName = "xsi",
				ns = null,
				value = "http://www.w3.org/2001/XMLSchema-instance"
			});
			num = 74779196;
			goto IL_000d;
		}

		private bool Import(SerializedObject serializedObject)
		{
			_enabled = false;
			_ruleSets = null;
			List<RuleSet> value = default(List<RuleSet>);
			while (true)
			{
				int num = 1873815378;
				while (true)
				{
					switch (num ^ 0x6FB02751)
					{
					case 0:
						break;
					case 3:
						serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
						serializedObject.TryGetDeserializedValueByRef("loadFromUserDataStore", ref _loadFromUserDataStore);
						value = new List<RuleSet>();
						num = 1873815376;
						continue;
					case 1:
						serializedObject.TryGetDeserializedValueByRef("ruleSets", ref value);
						num = 1873815379;
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
