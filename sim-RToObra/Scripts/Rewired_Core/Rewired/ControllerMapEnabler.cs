using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	public sealed class ControllerMapEnabler
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Preserve]
		public sealed class Rule : IDeepCloneable
		{
			[Serialize(Name = "tag")]
			[SerializeField]
			private string _tag;

			[SerializeField]
			[Serialize(Name = "enable")]
			private bool _enable;

			[Serialize(Name = "categoryIds")]
			[SerializeField]
			private int[] _categoryIds;

			[SerializeField]
			[Serialize(Name = "layoutIds")]
			private int[] _layoutIds;

			[SerializeField]
			[Serialize(Name = "controllerSetSelector")]
			private ControllerSetSelector _controllerSetSelector;

			[NonSerialized]
			private string[] _preInitCategoryNames;

			[NonSerialized]
			private string[] _preInitLayoutNames;

			internal bool appliesToAllLayouts
			{
				get
				{
					if (_layoutIds != null)
					{
						return _layoutIds.Length == 0;
					}
					return true;
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

			public bool enable
			{
				get
				{
					return _enable;
				}
				set
				{
					_enable = value;
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
					}
					_controllerSetSelector = value;
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
						goto IL_0003;
					}
					goto IL_0033;
					IL_0003:
					int num = -1153375716;
					goto IL_0008;
					IL_0008:
					while (true)
					{
						switch (num ^ -1153375714)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							value = EmptyObjects<int>.array;
							num = -1153375713;
							continue;
						case 1:
							goto IL_0033;
						case 3:
							return;
						}
						break;
					}
					goto IL_0003;
					IL_0033:
					_categoryIds = value;
					_preInitCategoryNames = null;
					num = -1153375715;
					goto IL_0008;
				}
			}

			public int[] layoutIds
			{
				get
				{
					Initialize();
					while (true)
					{
						int num = 1312631556;
						while (true)
						{
							int[] array;
							switch (num ^ 0x4E3D2B05)
							{
							case 0:
								break;
							case 1:
								array = _layoutIds;
								if (array == null)
								{
									goto IL_002d;
								}
								goto IL_0043;
							default:
								{
									array = (_layoutIds = EmptyObjects<int>.array);
									goto IL_0043;
								}
								IL_0043:
								return array;
							}
							break;
							IL_002d:
							num = 1312631559;
						}
					}
				}
				set
				{
					if (value == null)
					{
						goto IL_0003;
					}
					goto IL_0036;
					IL_0003:
					int num = -118078156;
					goto IL_0008;
					IL_0008:
					while (true)
					{
						switch (num ^ -118078155)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0029;
						case 4:
							goto IL_0036;
						case 1:
							value = EmptyObjects<int>.array;
							num = -118078159;
							continue;
						case 3:
							return;
						}
						break;
					}
					goto IL_0003;
					IL_0029:
					CheckNoControllerTypeError();
					num = -118078154;
					goto IL_0008;
					IL_0036:
					_layoutIds = value;
					_preInitLayoutNames = null;
					if (value == null)
					{
						int num2;
						if (value.Length <= 0)
						{
							num = -118078154;
							num2 = num;
						}
						else
						{
							num = -118078153;
							num2 = num;
						}
						goto IL_0008;
					}
					goto IL_0029;
				}
			}

			public int categoryId
			{
				get
				{
					Initialize();
					if (_categoryIds != null)
					{
						while (true)
						{
							int num = -857492376;
							while (true)
							{
								switch (num ^ -857492374)
								{
								case 0:
									break;
								case 2:
									goto IL_002c;
								default:
									goto end_IL_000e;
								}
								break;
								IL_002c:
								if (_categoryIds.Length == 0)
								{
									num = -857492373;
									continue;
								}
								return categoryIds[0];
							}
							continue;
							end_IL_000e:
							break;
						}
					}
					return -1;
				}
				set
				{
					if (value < 0)
					{
						_categoryIds = EmptyObjects<int>.array;
					}
					else
					{
						while (true)
						{
							IL_005a:
							int num;
							if (_categoryIds != null)
							{
								int num2;
								if (_categoryIds.Length != 0)
								{
									num = 1136807665;
									num2 = num;
								}
								else
								{
									num = 1136807667;
									num2 = num;
								}
								goto IL_0016;
							}
							goto IL_0047;
							IL_0016:
							while (true)
							{
								switch (num ^ 0x43C24EF3)
								{
								case 4:
									num = 1136807666;
									continue;
								case 2:
									_categoryIds[0] = value;
									num = 1136807664;
									continue;
								case 0:
									break;
								case 1:
									goto IL_005a;
								default:
									goto end_IL_005a;
								}
								break;
							}
							goto IL_0047;
							IL_0047:
							_categoryIds = new int[1];
							num = 1136807665;
							goto IL_0016;
							continue;
							end_IL_005a:
							break;
						}
					}
					_preInitCategoryNames = null;
				}
			}

			public int layoutId
			{
				get
				{
					Initialize();
					if (_layoutIds == null || _layoutIds.Length == 0)
					{
						return -1;
					}
					return layoutIds[0];
				}
				set
				{
					if (value >= 0)
					{
						goto IL_003b;
					}
					_layoutIds = EmptyObjects<int>.array;
					goto IL_0081;
					IL_003b:
					int num;
					if (_layoutIds != null)
					{
						int num2;
						if (_layoutIds.Length == 0)
						{
							num = -664131606;
							num2 = num;
						}
						else
						{
							num = -664131605;
							num2 = num;
						}
						goto IL_0016;
					}
					goto IL_005e;
					IL_0081:
					if (value >= 0)
					{
						CheckNoControllerTypeError();
						num = -664131601;
						goto IL_0016;
					}
					goto IL_0092;
					IL_005e:
					_layoutIds = new int[1];
					num = -664131605;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -664131602)
						{
						case 0:
							num = -664131604;
							continue;
						case 2:
							break;
						case 4:
							goto IL_005e;
						case 5:
							_layoutIds[0] = value;
							num = -664131603;
							continue;
						case 3:
							goto IL_0081;
						default:
							goto IL_0092;
						}
						break;
					}
					goto IL_003b;
					IL_0092:
					_preInitLayoutNames = null;
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
					string[] array = default(string[]);
					int num2 = default(int);
					InputMapCategory mapCategory = default(InputMapCategory);
					while (true)
					{
						int num = -1589242299;
						while (true)
						{
							switch (num ^ -1589242300)
							{
							case 3:
								break;
							case 1:
								if (_categoryIds == null)
								{
									return EmptyObjects<string>.array;
								}
								array = new string[_categoryIds.Length];
								num2 = 0;
								num = -1589242303;
								continue;
							case 0:
								mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[num2]);
								num = -1589242298;
								continue;
							case 5:
							{
								int num3;
								if (num2 < _categoryIds.Length)
								{
									num = -1589242300;
									num3 = num;
								}
								else
								{
									num = -1589242304;
									num3 = num;
								}
								continue;
							}
							case 2:
								array[num2] = ((mapCategory != null) ? mapCategory.name : "INVALID");
								num2++;
								num = -1589242303;
								continue;
							default:
								return array;
							}
							break;
						}
					}
				}
				set
				{
					if (!ReInput.isReady)
					{
						goto IL_000a;
					}
					goto IL_00f1;
					IL_000a:
					int num = 1999260281;
					goto IL_000f;
					IL_000f:
					int num2 = default(int);
					List<int> list = default(List<int>);
					while (true)
					{
						switch (num ^ 0x772A4A71)
						{
						case 4:
							break;
						default:
							return;
						case 0:
							if (num2 >= value.Length)
							{
								_categoryIds = list.ToArray();
								num = 1999260275;
								continue;
							}
							goto case 5;
						case 5:
							if (!string.IsNullOrEmpty(value[num2]))
							{
								int mapCategoryId = ReInput.mapping.GetMapCategoryId(value[num2]);
								if (mapCategoryId >= 0)
								{
									list.Add(mapCategoryId);
									num = 1999260274;
									continue;
								}
								goto case 9;
							}
							goto case 3;
						case 7:
							return;
						case 9:
							Logger.LogWarning("Map Category \"" + value[num2] + "\" does not exist.");
							num = 1999260274;
							continue;
						case 6:
							list = new List<int>(value.Length);
							num2 = 0;
							num = 1999260273;
							continue;
						case 1:
							goto IL_00d5;
						case 10:
							goto IL_00f1;
						case 3:
							num2++;
							num = 1999260273;
							continue;
						case 8:
							_preInitCategoryNames = ((value != null && value.Length > 0) ? value : null);
							_categoryIds = EmptyObjects<int>.array;
							return;
						case 2:
							return;
						}
						break;
					}
					goto IL_000a;
					IL_00f1:
					if (value != null)
					{
						int num3;
						if (value.Length == 0)
						{
							num = 1999260272;
							num3 = num;
						}
						else
						{
							num = 1999260279;
							num3 = num;
						}
						goto IL_000f;
					}
					goto IL_00d5;
					IL_00d5:
					_preInitCategoryNames = null;
					_categoryIds = EmptyObjects<int>.array;
					num = 1999260278;
					goto IL_000f;
				}
			}

			public string[] layoutNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						goto IL_000a;
					}
					Initialize();
					int num = 1683632374;
					goto IL_000f;
					IL_000f:
					string[] array = default(string[]);
					int num2 = default(int);
					InputLayout layout = default(InputLayout);
					while (true)
					{
						switch (num ^ 0x645A30F2)
						{
						case 6:
							break;
						case 0:
							array[num2] = ((layout != null) ? layout.name : "INVALID");
							num2++;
							num = 1683632368;
							continue;
						case 4:
							if (_layoutIds == null)
							{
								return EmptyObjects<string>.array;
							}
							array = new string[_layoutIds.Length];
							num = 1683632375;
							continue;
						case 1:
							if (_preInitLayoutNames == null)
							{
								return EmptyObjects<string>.array;
							}
							return _preInitLayoutNames;
						case 3:
							layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutIds[num2]);
							num = 1683632370;
							continue;
						case 5:
							num2 = 0;
							num = 1683632368;
							continue;
						default:
							if (num2 >= _layoutIds.Length)
							{
								return array;
							}
							goto case 3;
						}
						break;
					}
					goto IL_000a;
					IL_000a:
					num = 1683632371;
					goto IL_000f;
				}
				set
				{
					if (!ReInput.isReady)
					{
						goto IL_000a;
					}
					goto IL_0174;
					IL_000a:
					int num = -1922151988;
					goto IL_000f;
					IL_000f:
					int num2 = default(int);
					List<int> list = default(List<int>);
					while (true)
					{
						switch (num ^ -1922151989)
						{
						case 8:
							break;
						default:
							return;
						case 2:
							_layoutIds = EmptyObjects<int>.array;
							return;
						case 3:
						{
							int num3 = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value[num2]);
							if (num3 >= 0)
							{
								list.Add(num3);
								num = -1922151987;
								continue;
							}
							goto case 12;
						}
						case 1:
							CheckNoControllerTypeError();
							num = -1922151995;
							continue;
						case 9:
							goto IL_00b0;
						case 11:
							goto IL_00ce;
						case 6:
							num = -1922151996;
							continue;
						case 14:
							list = new List<int>(value.Length);
							num2 = 0;
							num = -1922151994;
							continue;
						case 12:
							Logger.LogWarning("Layout \"" + value[num2] + "\" does not exist.");
							num = -1922151996;
							continue;
						case 15:
							num2++;
							num = -1922151994;
							continue;
						case 10:
							_preInitLayoutNames = ((value != null && value.Length > 0) ? value : null);
							_layoutIds = EmptyObjects<int>.array;
							num = -1922151986;
							continue;
						case 13:
							if (num2 >= value.Length)
							{
								_layoutIds = list.ToArray();
								num = -1922151985;
								continue;
							}
							goto IL_00b0;
						case 0:
							goto IL_0174;
						case 7:
							if (value != null && value.Length > 0)
							{
								CheckNoControllerTypeError();
								num = -1922151999;
								continue;
							}
							goto case 10;
						case 5:
							return;
						case 4:
							return;
						}
						break;
						IL_00b0:
						int num4;
						if (!string.IsNullOrEmpty(value[num2]))
						{
							num = -1922151992;
							num4 = num;
						}
						else
						{
							num = -1922151996;
							num4 = num;
						}
					}
					goto IL_000a;
					IL_0174:
					if (value != null)
					{
						int num5;
						if (value.Length != 0)
						{
							num = -1922151990;
							num5 = num;
						}
						else
						{
							num = -1922152000;
							num5 = num;
						}
						goto IL_000f;
					}
					goto IL_00ce;
					IL_00ce:
					_preInitLayoutNames = null;
					num = -1922151991;
					goto IL_000f;
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
							goto IL_000f;
						}
						goto IL_0063;
					}
					Initialize();
					InputMapCategory mapCategory = default(InputMapCategory);
					int num;
					if (_categoryIds != null)
					{
						if (_categoryIds.Length != 0)
						{
							mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
							num = -192980214;
						}
						else
						{
							num = -192980215;
						}
						goto IL_0014;
					}
					goto IL_0047;
					IL_0014:
					while (true)
					{
						switch (num ^ -192980214)
						{
						case 4:
							break;
						case 2:
							goto IL_0035;
						case 3:
							goto IL_0047;
						case 1:
							goto IL_0063;
						default:
							goto IL_008d;
						}
						break;
						IL_0035:
						if (_preInitCategoryNames.Length <= 0)
						{
							num = -192980213;
							continue;
						}
						return _preInitCategoryNames[0];
					}
					goto IL_000f;
					IL_0063:
					return null;
					IL_008d:
					if (mapCategory == null)
					{
						return "INVALID";
					}
					return mapCategory.name;
					IL_0047:
					return null;
					IL_000f:
					num = -192980216;
					goto IL_0014;
				}
				set
				{
					if (!ReInput.isReady)
					{
						_preInitCategoryNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
						goto IL_0024;
					}
					goto IL_0079;
					IL_0029:
					int num;
					while (true)
					{
						switch (num ^ -676418333)
						{
						case 6:
							break;
						default:
							return;
						case 0:
							goto IL_0052;
						case 2:
							return;
						case 3:
							goto IL_0079;
						case 1:
							_categoryIds = EmptyObjects<int>.array;
							num = -676418335;
							continue;
						case 5:
							goto IL_00b0;
						case 4:
							return;
						}
						break;
					}
					goto IL_0024;
					IL_0052:
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
					if (mapCategoryId >= 0)
					{
						categoryId = mapCategoryId;
						return;
					}
					goto IL_00b0;
					IL_0079:
					if (string.IsNullOrEmpty(value))
					{
						_preInitCategoryNames = null;
						_categoryIds = EmptyObjects<int>.array;
						return;
					}
					goto IL_0052;
					IL_00b0:
					Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
					num = -676418329;
					goto IL_0029;
					IL_0024:
					num = -676418334;
					goto IL_0029;
				}
			}

			public string layoutName
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (_preInitLayoutNames != null)
						{
							if (_preInitLayoutNames.Length > 0)
							{
								return _preInitLayoutNames[0];
							}
							goto IL_001a;
						}
						goto IL_0040;
					}
					Initialize();
					int num = 1882784590;
					goto IL_001f;
					IL_001a:
					num = 1882784587;
					goto IL_001f;
					IL_0040:
					return null;
					IL_001f:
					while (true)
					{
						switch (num ^ 0x7039034A)
						{
						case 2:
							break;
						case 1:
							goto IL_0040;
						case 3:
							return null;
						case 4:
							if (_layoutIds == null)
							{
								goto case 3;
							}
							goto IL_008a;
						default:
							return "INVALID";
						}
						break;
						IL_008a:
						if (_layoutIds.Length != 0)
						{
							InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutIds[0]);
							if (layout != null)
							{
								return layout.name;
							}
							num = 1882784586;
						}
						else
						{
							num = 1882784585;
						}
					}
					goto IL_001a;
				}
				set
				{
					if (!ReInput.isReady)
					{
						if (!string.IsNullOrEmpty(value))
						{
							goto IL_0012;
						}
						goto IL_0073;
					}
					goto IL_00b8;
					IL_00ed:
					CheckNoControllerTypeError();
					int num = -886930160;
					goto IL_0017;
					IL_0012:
					num = -886930156;
					goto IL_0017;
					IL_0017:
					int num2 = default(int);
					while (true)
					{
						switch (num ^ -886930158)
						{
						case 0:
							break;
						case 2:
							goto IL_0047;
						case 1:
							goto IL_0073;
						case 5:
							layoutId = num2;
							return;
						case 7:
							goto IL_00b8;
						case 6:
							CheckNoControllerTypeError();
							num = -886930157;
							continue;
						case 4:
							goto IL_00ed;
						default:
							Logger.LogWarning("Map Layout \"" + value + "\" does not exist.");
							return;
						}
						break;
						IL_0047:
						num2 = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
						int num3;
						if (num2 < 0)
						{
							num = -886930159;
							num3 = num;
						}
						else
						{
							num = -886930153;
							num3 = num;
						}
					}
					goto IL_0012;
					IL_0073:
					_preInitLayoutNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
					_layoutIds = EmptyObjects<int>.array;
					return;
					IL_00b8:
					if (string.IsNullOrEmpty(value))
					{
						_preInitLayoutNames = null;
						_layoutIds = EmptyObjects<int>.array;
						return;
					}
					goto IL_00ed;
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
					if (!ReInput.isReady)
					{
						return true;
					}
					Initialize();
					if (_categoryIds != null && _categoryIds.Length > 0)
					{
						goto IL_0032;
					}
					goto IL_0111;
					IL_0136:
					return true;
					IL_0037:
					int num;
					int num3 = default(int);
					bool flag = default(bool);
					int num2 = default(int);
					bool flag2 = default(bool);
					while (true)
					{
						switch (num ^ 0x606405D5)
						{
						case 6:
							break;
						case 8:
							num3++;
							num = 1617167826;
							continue;
						case 5:
							if (ReInput.mapping.GetMapCategory(_categoryIds[num3]) != null)
							{
								flag = true;
								num = 1617167837;
								continue;
							}
							goto case 8;
						case 4:
							if (ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutIds[num2]) != null)
							{
								flag2 = true;
								num = 1617167828;
								continue;
							}
							goto case 1;
						case 9:
							goto IL_00c2;
						case 3:
							flag = false;
							num3 = 0;
							num = 1617167826;
							continue;
						case 7:
							if (num3 < _categoryIds.Length)
							{
								goto case 5;
							}
							goto IL_00f4;
						case 1:
							num2++;
							num = 1617167831;
							continue;
						case 0:
							return false;
						default:
							if (num2 < _layoutIds.Length)
							{
								goto case 4;
							}
							goto IL_0131;
						}
						break;
						IL_0131:
						if (!flag2)
						{
							return false;
						}
						goto IL_0136;
						IL_00c2:
						if (_layoutIds.Length > 0)
						{
							flag2 = false;
							num2 = 0;
							num = 1617167831;
							continue;
						}
						goto IL_0136;
						IL_00f4:
						if (!flag)
						{
							num = 1617167829;
							continue;
						}
						goto IL_0111;
					}
					goto IL_0032;
					IL_0111:
					if (_layoutIds != null)
					{
						num = 1617167836;
						goto IL_0037;
					}
					goto IL_0136;
					IL_0032:
					num = 1617167830;
					goto IL_0037;
				}
			}

			public Rule()
			{
				_enable = true;
				_categoryIds = EmptyObjects<int>.array;
				_layoutIds = EmptyObjects<int>.array;
				_controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
			}

			public Rule(Rule source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				_tag = source._tag;
				_enable = source._enable;
				_categoryIds = ArrayTools.ShallowCopy(source._categoryIds);
				_layoutIds = ArrayTools.ShallowCopy(source._layoutIds);
				_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
				_preInitCategoryNames = ArrayTools.ShallowCopy(source._preInitCategoryNames);
				_preInitLayoutNames = ArrayTools.ShallowCopy(source._preInitLayoutNames);
			}

			internal Rule(string tag, bool enabled, int[] categoryIds, int[] layoutIds, ControllerSetSelector controllerSetSelector)
			{
				_tag = tag;
				_enable = enabled;
				_categoryIds = categoryIds;
				_layoutIds = layoutIds;
				_controllerSetSelector = controllerSetSelector;
			}

			internal bool Matches(ControllerMap map)
			{
				if (map == null)
				{
					return false;
				}
				if (!isValid)
				{
					return false;
				}
				if (_categoryIds != null && _categoryIds.Length > 0 && !ArrayTools.Contains(_categoryIds, map.categoryId))
				{
					return false;
				}
				if (_layoutIds != null)
				{
					while (true)
					{
						int num = 866868071;
						while (true)
						{
							switch (num ^ 0x33AB5B66)
							{
							case 0:
								break;
							case 1:
								goto IL_005d;
							default:
								goto IL_006f;
							}
							break;
							IL_006f:
							if (ArrayTools.Contains(_layoutIds, map.layoutId))
							{
								goto end_IL_003f;
							}
							return false;
							IL_005d:
							if (_layoutIds.Length <= 0)
							{
								goto end_IL_003f;
							}
							num = 866868068;
						}
						continue;
						end_IL_003f:
						break;
					}
				}
				if (!_controllerSetSelector.Matches(map.controller))
				{
					return false;
				}
				return true;
			}

			private void Initialize()
			{
				if (!ReInput.isReady)
				{
					goto IL_0007;
				}
				goto IL_007f;
				IL_0007:
				int num = -236231070;
				goto IL_000c;
				IL_000c:
				int mapCategoryId = default(int);
				List<int> list2 = default(List<int>);
				int num3 = default(int);
				int num2 = default(int);
				List<int> list = default(List<int>);
				while (true)
				{
					switch (num ^ -236231057)
					{
					case 14:
						break;
					default:
						return;
					case 16:
						num = -236231065;
						continue;
					case 9:
						goto IL_007f;
					case 10:
						if (mapCategoryId >= 0)
						{
							list2.Add(mapCategoryId);
							num = -236231069;
							continue;
						}
						goto case 2;
					case 3:
						num3++;
						num = -236231072;
						continue;
					case 2:
						Logger.LogWarning("Map Category \"" + _preInitCategoryNames[num3] + "\" does not exist.");
						num = -236231060;
						continue;
					case 18:
						if (!string.IsNullOrEmpty(_preInitCategoryNames[num3]))
						{
							mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[num3]);
							num = -236231067;
							continue;
						}
						goto case 3;
					case 7:
						goto IL_010a;
					case 19:
						Logger.LogWarning("Map Layout \"" + _preInitLayoutNames[num2] + "\" does not exist.");
						num = -236231058;
						continue;
					case 6:
						num = -236231072;
						continue;
					case 17:
					{
						int num4 = ReInput.mapping.GetLayoutId(_controllerSetSelector.controllerType, _preInitLayoutNames[num2]);
						if (num4 >= 0)
						{
							list.Add(num4);
							num = -236231045;
							continue;
						}
						goto case 19;
					}
					case 4:
						if (_preInitCategoryNames != null && _preInitCategoryNames.Length != 0)
						{
							list2 = new List<int>(_preInitCategoryNames.Length);
							num3 = 0;
							num = -236231063;
							continue;
						}
						goto IL_010a;
					case 22:
						goto IL_01cd;
					case 12:
						num = -236231060;
						continue;
					case 21:
						CheckNoControllerTypeError();
						list = new List<int>(_preInitLayoutNames.Length);
						num2 = 0;
						num = -236231041;
						continue;
					case 1:
						num2++;
						num = -236231065;
						continue;
					case 15:
						if (num3 >= _preInitCategoryNames.Length)
						{
							_categoryIds = list2.ToArray();
							_preInitCategoryNames = null;
							num = -236231064;
							continue;
						}
						goto case 18;
					case 5:
						goto IL_024f;
					case 20:
						num = -236231058;
						continue;
					case 11:
						_categoryIds = EmptyObjects<int>.array;
						num = -236231061;
						continue;
					case 8:
						if (num2 >= _preInitLayoutNames.Length)
						{
							_layoutIds = list.ToArray();
							_preInitLayoutNames = null;
							num = -236231057;
							continue;
						}
						goto IL_024f;
					case 13:
						return;
					case 0:
						return;
					}
					break;
					IL_024f:
					int num5;
					if (string.IsNullOrEmpty(_preInitLayoutNames[num2]))
					{
						num = -236231058;
						num5 = num;
					}
					else
					{
						num = -236231042;
						num5 = num;
					}
					continue;
					IL_010a:
					if (_preInitLayoutNames != null)
					{
						int num6;
						if (_preInitLayoutNames.Length == 0)
						{
							num = -236231057;
							num6 = num;
						}
						else
						{
							num = -236231046;
							num6 = num;
						}
						continue;
					}
					return;
				}
				goto IL_0007;
				IL_01cd:
				int num7;
				if (_categoryIds != null)
				{
					num = -236231061;
					num7 = num;
				}
				else
				{
					num = -236231068;
					num7 = num;
				}
				goto IL_000c;
				IL_007f:
				if (_controllerSetSelector == null)
				{
					return;
				}
				goto IL_01cd;
			}

			private void CheckNoControllerTypeError()
			{
				if (_controllerSetSelector == null)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 1855139233;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x6E932DA0)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0032;
				case 0:
					return;
				}
				goto IL_0008;
				IL_0032:
				if (!_controllerSetSelector.hasControllerType)
				{
					Logger.LogWarning(string.Concat("A Layout should not be set when using ", typeof(ControllerSetSelector.Type).FullName, ".", _controllerSetSelector.type, " because each Controller type has its own unique Layouts."), true);
					num = 1855139232;
					goto IL_000d;
				}
			}

			object IDeepCloneable.DeepClone()
			{
				return new Rule(this);
			}
		}

		[Serializable]
		[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Preserve]
		public sealed class RuleSet : IDeepCloneable, IEnumerable, IList<Rule>, ICollection<Rule>, IEnumerable<Rule>
		{
			private const string className = "ControllerMapEnabler.RuleSet";

			[SerializeField]
			[Serialize(Name = "enabled")]
			private bool _enabled;

			[SerializeField]
			[Serialize(Name = "tag")]
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
						int num = 797167698;
						while (true)
						{
							switch (num ^ 0x2F83D050)
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
							_rules[index] = value;
							num = 797167697;
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
				while (true)
				{
					int num = -399453976;
					while (true)
					{
						switch (num ^ -399453975)
						{
						case 2:
							break;
						case 1:
						{
							int num2;
							if (source != null)
							{
								num = -399453971;
								num2 = num;
							}
							else
							{
								num = -399453974;
								num2 = num;
							}
							continue;
						}
						case 4:
							_enabled = source._enabled;
							num = -399453975;
							continue;
						case 3:
							throw new ArgumentNullException("source");
						default:
							_tag = source._tag;
							_rules = MiscTools.DeepClone(source._rules);
							CheckList();
							return;
						}
						break;
					}
				}
			}

			public Rule Find(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				while (true)
				{
					int num = ((_rules != null) ? _rules.Count : 0);
					int num2 = 743184786;
					while (true)
					{
						switch (num2 ^ 0x2C4C1993)
						{
						case 0:
							goto IL_000e;
						case 2:
							break;
						default:
						{
							for (int i = 0; i < num; i++)
							{
								try
								{
									if (predicate(_rules[i]))
									{
										return _rules[i];
									}
								}
								catch (Exception exception)
								{
									while (true)
									{
										IL_0074:
										int num3 = 743184785;
										while (true)
										{
											switch (num3 ^ 0x2C4C1993)
											{
											case 0:
												break;
											default:
												goto end_IL_0079;
											case 2:
												goto IL_0092;
											case 1:
												goto end_IL_0079;
											}
											goto IL_0074;
											IL_0092:
											ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.Find", exception);
											num3 = 743184786;
											continue;
											end_IL_0079:
											break;
										}
										break;
									}
								}
							}
							return null;
						}
						}
						break;
						IL_000e:
						num2 = 743184785;
					}
				}
			}

			public Rule FindLast(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					while (true)
					{
						switch (-1504747585 ^ -1504747586)
						{
						case 2:
							continue;
						case 1:
							throw new ArgumentNullException("predicate");
						}
						break;
					}
				}
				int num = ((_rules != null) ? _rules.Count : 0);
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					try
					{
						if (predicate(_rules[num2]))
						{
							return _rules[num2];
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLast", exception);
					}
				}
				return null;
			}

			public int FindIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					while (true)
					{
						switch (-640617600 ^ -640617599)
						{
						case 2:
							continue;
						case 1:
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
						int result = i;
						while (true)
						{
							switch (-640617600 ^ -640617599)
							{
							case 0:
								break;
							default:
								goto end_IL_0064;
							case 2:
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
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindIndex", exception);
					}
				}
				return -1;
			}

			public int FindLastIndex(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				while (true)
				{
					int num = ((_rules != null) ? _rules.Count : 0);
					int num2 = num - 1;
					int num3 = 1866051624;
					while (true)
					{
						switch (num3 ^ 0x6F39B029)
						{
						case 0:
							goto IL_000e;
						case 2:
							break;
						default:
							while (true)
							{
								if (num2 >= 0)
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
										ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLastIndex", exception);
									}
									num2--;
									goto IL_007c;
								}
								int num4 = 1866051627;
								goto IL_0081;
								IL_0081:
								switch (num4 ^ 0x6F39B029)
								{
								case 0:
									break;
								case 1:
									continue;
								default:
									return -1;
								}
								goto IL_007c;
								IL_007c:
								num4 = 1866051624;
								goto IL_0081;
							}
						}
						break;
						IL_000e:
						num3 = 1866051627;
					}
				}
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

		internal class JUZYTaWfnqZOjNkWvtfvZbKqPkC
		{
			public bool HrjcqFAgRRaZLGApNJxkDOsvjGCj;

			public IBXCWQaiuXApgrsayPNtUSrFqVH[] RtJELTFcmewuelgbgQphxlidefQ;

			public JUZYTaWfnqZOjNkWvtfvZbKqPkC(bool enabled, IBXCWQaiuXApgrsayPNtUSrFqVH[] startingRuleSets)
			{
				HrjcqFAgRRaZLGApNJxkDOsvjGCj = enabled;
				RtJELTFcmewuelgbgQphxlidefQ = startingRuleSets;
			}
		}

		private bool PAfqntGWZaNgzmZFIOyQPuJGOCq;

		private Player wVmxupsXoTmxeBeKFxYheQCHgkk;

		private JUZYTaWfnqZOjNkWvtfvZbKqPkC gsnFfbHUowjcMozBbVutOVOnzWrp;

		private readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		private List<RuleSet> fmkyPPQwfusueTmcunGmhZCqgqU;

		public bool enabled
		{
			get
			{
				return PAfqntGWZaNgzmZFIOyQPuJGOCq;
			}
			set
			{
				PAfqntGWZaNgzmZFIOyQPuJGOCq = value;
				if (value)
				{
					Apply();
				}
			}
		}

		public List<RuleSet> ruleSets
		{
			get
			{
				return fmkyPPQwfusueTmcunGmhZCqgqU;
			}
			set
			{
				if (value == null)
				{
					value = new List<RuleSet>();
				}
				fmkyPPQwfusueTmcunGmhZCqgqU = value;
			}
		}

		internal ControllerMapEnabler(Player player, JUZYTaWfnqZOjNkWvtfvZbKqPkC startingSettings)
		{
			if (player == null)
			{
				throw new ArgumentNullException("player");
			}
			if (startingSettings == null)
			{
				throw new ArgumentNullException("startingSettings");
			}
			znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
			wVmxupsXoTmxeBeKFxYheQCHgkk = player;
			gsnFfbHUowjcMozBbVutOVOnzWrp = startingSettings;
		}

		public void Apply()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return;
			}
			int count = default(int);
			int count3 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			Rule rule = default(Rule);
			while (true)
			{
				int num;
				int num2;
				if (PAfqntGWZaNgzmZFIOyQPuJGOCq)
				{
					num = 646378056;
					num2 = num;
				}
				else
				{
					num = 646378062;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x2686F24A)
					{
					case 3:
						goto IL_001a;
					case 1:
						break;
					case 5:
						count = fmkyPPQwfusueTmcunGmhZCqgqU.Count;
						if (count == 0)
						{
							return;
						}
						goto default;
					case 4:
						return;
					case 2:
						if (fmkyPPQwfusueTmcunGmhZCqgqU == null)
						{
							return;
						}
						goto case 5;
					default:
					{
						using (TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>())
						{
							List<ControllerMap> list = tList.list;
							wVmxupsXoTmxeBeKFxYheQCHgkk.controllers.maps.GetAllMaps(list);
							int count2 = list.Count;
							int num3 = 0;
							while (num3 < count)
							{
								while (true)
								{
									IL_016f:
									RuleSet ruleSet = fmkyPPQwfusueTmcunGmhZCqgqU[num3];
									int num5;
									if (ruleSet != null && ruleSet.enabled)
									{
										count3 = ruleSet.Count;
										num4 = 0;
										num5 = 646378050;
										goto IL_00c4;
									}
									goto IL_0104;
									IL_0104:
									num3++;
									num5 = 646378056;
									goto IL_00c4;
									IL_00c4:
									while (true)
									{
										switch (num5 ^ 0x2686F24A)
										{
										case 11:
											num5 = 646378057;
											continue;
										case 10:
											break;
										case 8:
											num5 = 646378063;
											continue;
										case 6:
										{
											ControllerMap controllerMap = list[num6];
											if (controllerMap.enabled != rule.enable && rule.Matches(controllerMap))
											{
												controllerMap.enabled = rule.enable;
												num5 = 646378051;
												continue;
											}
											goto case 9;
										}
										case 5:
											goto IL_0155;
										case 3:
											goto IL_016f;
										case 9:
											num6++;
											num5 = 646378061;
											continue;
										case 0:
											num4++;
											num5 = 646378063;
											continue;
										case 4:
											rule = ruleSet[num4];
											num5 = 646378059;
											continue;
										case 7:
											goto IL_01d9;
										case 1:
											if (rule != null)
											{
												num6 = 0;
												num5 = 646378061;
												continue;
											}
											goto case 0;
										default:
											goto end_IL_016f;
										}
										break;
										IL_01d9:
										int num7;
										if (num6 >= count2)
										{
											num5 = 646378058;
											num7 = num5;
										}
										else
										{
											num5 = 646378060;
											num7 = num5;
										}
										continue;
										IL_0155:
										int num8;
										if (num4 < count3)
										{
											num5 = 646378062;
											num8 = num5;
										}
										else
										{
											num5 = 646378048;
											num8 = num5;
										}
									}
									goto IL_0104;
									continue;
									end_IL_016f:
									break;
								}
							}
							return;
						}
					}
					}
					break;
					IL_001a:
					num = 646378059;
				}
			}
		}

		public void LoadDefaults()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_001c;
			}
			goto IL_00d6;
			IL_00d6:
			List<RuleSet> list = new List<RuleSet>();
			int num = -1043433495;
			goto IL_0021;
			IL_001c:
			num = -1043433490;
			goto IL_0021;
			IL_0021:
			int num2 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num3;
				switch (num ^ -1043433492)
				{
				case 10:
					break;
				case 6:
					PAfqntGWZaNgzmZFIOyQPuJGOCq = gsnFfbHUowjcMozBbVutOVOnzWrp.HrjcqFAgRRaZLGApNJxkDOsvjGCj;
					num = -1043433499;
					continue;
				case 0:
					goto IL_0075;
				case 7:
					num2++;
					num = -1043433492;
					continue;
				case 2:
					return;
				case 1:
					goto IL_009d;
				case 3:
					num3 = 0;
					goto IL_00c9;
				case 8:
					goto IL_00d6;
				case 5:
					if (gsnFfbHUowjcMozBbVutOVOnzWrp == null)
					{
						goto case 3;
					}
					if (gsnFfbHUowjcMozBbVutOVOnzWrp.RtJELTFcmewuelgbgQphxlidefQ != null)
					{
						num3 = gsnFfbHUowjcMozBbVutOVOnzWrp.RtJELTFcmewuelgbgQphxlidefQ.Length;
						goto IL_00c9;
					}
					num = -1043433489;
					continue;
				case 4:
				{
					RuleSet controllerMapEnablerRuleSetInstance = ReInput.mapping.GetControllerMapEnablerRuleSetInstance(gsnFfbHUowjcMozBbVutOVOnzWrp.RtJELTFcmewuelgbgQphxlidefQ[num2].id);
					controllerMapEnablerRuleSetInstance.enabled = gsnFfbHUowjcMozBbVutOVOnzWrp.RtJELTFcmewuelgbgQphxlidefQ[num2].startEnabled;
					list.Add(controllerMapEnablerRuleSetInstance);
					num = -1043433493;
					continue;
				}
				default:
					{
						fmkyPPQwfusueTmcunGmhZCqgqU = list;
						Apply();
						return;
					}
					IL_00c9:
					num4 = num3;
					num2 = 0;
					num = -1043433492;
					continue;
				}
				break;
				IL_009d:
				int num5;
				if (gsnFfbHUowjcMozBbVutOVOnzWrp != null)
				{
					num = -1043433494;
					num5 = num;
				}
				else
				{
					num = -1043433499;
					num5 = num;
				}
				continue;
				IL_0075:
				int num6;
				if (num2 < num4)
				{
					num = -1043433496;
					num6 = num;
				}
				else
				{
					num = -1043433491;
					num6 = num;
				}
			}
			goto IL_001c;
		}

		public string ToXmlString()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return string.Empty;
			}
			try
			{
				return wGWQXZtIQyRkZMrIKWqTSlWZlQY().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return string.Empty;
			}
			try
			{
				return wGWQXZtIQyRkZMrIKWqTSlWZlQY().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public bool ImportXml(string xmlString)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = -1755516074;
					while (true)
					{
						switch (num ^ -1755516073)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						num = -1755516073;
					}
				}
			}
			bool result = default(bool);
			try
			{
				DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject.FromXml(GetType(), xmlString));
				Apply();
				result = true;
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_005e:
					int num2 = -1755516076;
					while (true)
					{
						switch (num2 ^ -1755516073)
						{
						case 2:
							break;
						default:
							goto end_IL_0063;
						case 3:
							Logger.LogError("Error importing " + GetType().Name + " data from XML. " + ex.Message);
							num2 = -1755516073;
							continue;
						case 0:
							result = false;
							num2 = -1755516074;
							continue;
						case 1:
							goto end_IL_0063;
						}
						goto IL_005e;
						continue;
						end_IL_0063:
						break;
					}
					break;
				}
			}
			return result;
		}

		public bool ImportJson(string jsonString)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			bool result = default(bool);
			try
			{
				DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject.FromJson(GetType(), jsonString));
				while (true)
				{
					IL_002e:
					int num = 1623152286;
					while (true)
					{
						switch (num ^ 0x60BF569F)
						{
						case 0:
							break;
						default:
							goto end_IL_0033;
						case 1:
							goto IL_004c;
						case 2:
							goto end_IL_0033;
						}
						goto IL_002e;
						IL_004c:
						Apply();
						result = true;
						num = 1623152285;
						continue;
						end_IL_0033:
						break;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + GetType().Name + " data from JSON. " + ex.Message);
				result = false;
			}
			return result;
		}

		private SerializedObject wGWQXZtIQyRkZMrIKWqTSlWZlQY()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			XCLdYnlxuxGFTDRYaqjNPanRONP(serializedObject);
			return serializedObject;
		}

		private void XCLdYnlxuxGFTDRYaqjNPanRONP(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				goto IL_000b;
			}
			goto IL_00f0;
			IL_000b:
			int num = -1575457822;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -1575457817)
				{
				case 4:
					break;
				default:
					return;
				case 3:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
					});
					P_0.Add("enabled", PAfqntGWZaNgzmZFIOyQPuJGOCq);
					P_0.Add("ruleSets", fmkyPPQwfusueTmcunGmhZCqgqU);
					num = -1575457818;
					continue;
				case 0:
					goto IL_00f0;
				case 5:
					P_0.xmlInfo = new SerializedObject.XmlInfo();
					num = -1575457817;
					continue;
				case 2:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					num = -1575457820;
					continue;
				case 1:
					return;
				}
				break;
			}
			goto IL_000b;
			IL_00f0:
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			num = -1575457819;
			goto IL_0010;
		}

		private bool DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject P_0)
		{
			PAfqntGWZaNgzmZFIOyQPuJGOCq = false;
			fmkyPPQwfusueTmcunGmhZCqgqU = null;
			P_0.TryGetDeserializedValueByRef("enabled", ref PAfqntGWZaNgzmZFIOyQPuJGOCq);
			List<RuleSet> value = new List<RuleSet>();
			P_0.TryGetDeserializedValueByRef("ruleSets", ref value);
			fmkyPPQwfusueTmcunGmhZCqgqU = value;
			return true;
		}
	}
}
