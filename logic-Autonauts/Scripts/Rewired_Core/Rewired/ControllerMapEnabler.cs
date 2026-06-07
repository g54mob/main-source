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
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Rule : IDeepCloneable
		{
			[Serialize(Name = "tag")]
			[SerializeField]
			private string _tag;

			[SerializeField]
			[Serialize(Name = "enable")]
			private bool _enable;

			[SerializeField]
			[Serialize(Name = "categoryIds")]
			private int[] _categoryIds;

			[Serialize(Name = "layoutIds")]
			[SerializeField]
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
					while (true)
					{
						int num = -461005926;
						while (true)
						{
							int[] array;
							switch (num ^ -461005928)
							{
							case 0:
								break;
							case 2:
								array = _categoryIds;
								if (array == null)
								{
									goto IL_002d;
								}
								goto IL_0043;
							default:
								{
									array = (_categoryIds = EmptyObjects<int>.array);
									goto IL_0043;
								}
								IL_0043:
								return array;
							}
							break;
							IL_002d:
							num = -461005927;
						}
					}
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

			public int[] layoutIds
			{
				get
				{
					Initialize();
					return _layoutIds ?? (_layoutIds = EmptyObjects<int>.array);
				}
				set
				{
					if (value == null)
					{
						value = EmptyObjects<int>.array;
						goto IL_000a;
					}
					goto IL_0030;
					IL_0030:
					_layoutIds = value;
					_preInitLayoutNames = null;
					int num = 1922069766;
					goto IL_000f;
					IL_000a:
					num = 1922069760;
					goto IL_000f;
					IL_000f:
					while (true)
					{
						switch (num ^ 0x72907502)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0030;
						case 4:
							if (value == null)
							{
								goto IL_0048;
							}
							goto case 1;
						case 1:
							CheckNoControllerTypeError();
							num = 1922069761;
							continue;
						case 3:
							return;
						}
						break;
						IL_0048:
						int num2;
						if (value.Length <= 0)
						{
							num = 1922069761;
							num2 = num;
						}
						else
						{
							num = 1922069763;
							num2 = num;
						}
					}
					goto IL_000a;
				}
			}

			public int categoryId
			{
				get
				{
					Initialize();
					while (true)
					{
						int num = 1034410491;
						while (true)
						{
							switch (num ^ 0x3DA7D9FA)
							{
							case 0:
								break;
							case 1:
								if (_categoryIds != null)
								{
									if (_categoryIds.Length == 0)
									{
										goto IL_0036;
									}
									return categoryIds[0];
								}
								goto default;
							default:
								return -1;
							}
							break;
							IL_0036:
							num = 1034410488;
						}
					}
				}
				set
				{
					if (value < 0)
					{
						goto IL_0004;
					}
					goto IL_0063;
					IL_0004:
					int num = -1391543728;
					goto IL_0009;
					IL_0009:
					while (true)
					{
						switch (num ^ -1391543725)
						{
						case 2:
							break;
						case 1:
							goto IL_002e;
						case 0:
							_categoryIds[0] = value;
							num = -1391543721;
							continue;
						case 3:
							_categoryIds = EmptyObjects<int>.array;
							num = -1391543721;
							continue;
						case 5:
							goto IL_0063;
						default:
							_preInitCategoryNames = null;
							return;
						}
						break;
					}
					goto IL_0004;
					IL_0063:
					if (_categoryIds != null)
					{
						int num2;
						if (_categoryIds.Length == 0)
						{
							num = -1391543726;
							num2 = num;
						}
						else
						{
							num = -1391543725;
							num2 = num;
						}
						goto IL_0009;
					}
					goto IL_002e;
					IL_002e:
					_categoryIds = new int[1];
					num = -1391543725;
					goto IL_0009;
				}
			}

			public int layoutId
			{
				get
				{
					Initialize();
					while (true)
					{
						int num = 1701728638;
						while (true)
						{
							switch (num ^ 0x656E517C)
							{
							case 0:
								break;
							case 2:
								if (_layoutIds != null)
								{
									if (_layoutIds.Length == 0)
									{
										goto IL_0036;
									}
									return layoutIds[0];
								}
								goto default;
							default:
								return -1;
							}
							break;
							IL_0036:
							num = 1701728637;
						}
					}
				}
				set
				{
					if (value >= 0)
					{
						goto IL_003f;
					}
					_layoutIds = EmptyObjects<int>.array;
					goto IL_0083;
					IL_0062:
					_layoutIds = new int[1];
					int num = -1695468030;
					goto IL_0016;
					IL_0083:
					if (value >= 0)
					{
						CheckNoControllerTypeError();
						num = -1695468029;
						goto IL_0016;
					}
					goto IL_0075;
					IL_0075:
					_preInitLayoutNames = null;
					num = -1695468026;
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -1695468026)
						{
						case 6:
							num = -1695468025;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							goto IL_0062;
						case 5:
							goto IL_0075;
						case 3:
							goto IL_0083;
						case 4:
							_layoutIds[0] = value;
							num = -1695468027;
							continue;
						case 0:
							return;
						}
						break;
					}
					goto IL_003f;
					IL_003f:
					if (_layoutIds != null)
					{
						int num2;
						if (_layoutIds.Length != 0)
						{
							num = -1695468030;
							num2 = num;
						}
						else
						{
							num = -1695468028;
							num2 = num;
						}
						goto IL_0016;
					}
					goto IL_0062;
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
							num++;
							int num2 = -171310960;
							while (true)
							{
								switch (num2 ^ -171310958)
								{
								case 0:
									num2 = -171310957;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0060;
								}
								break;
							}
							continue;
							end_IL_0060:
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
					List<int> list = default(List<int>);
					int num3 = default(int);
					while (value != null)
					{
						int num;
						int num2;
						if (value.Length != 0)
						{
							num = -1500756985;
							num2 = num;
						}
						else
						{
							num = -1500756990;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1500756986)
							{
							case 5:
								num = -1500756978;
								continue;
							default:
								return;
							case 8:
								break;
							case 1:
								list = new List<int>(value.Length);
								num = -1500756991;
								continue;
							case 9:
								if (!string.IsNullOrEmpty(value[num3]))
								{
									int mapCategoryId = ReInput.mapping.GetMapCategoryId(value[num3]);
									if (mapCategoryId >= 0)
									{
										list.Add(mapCategoryId);
										num = -1500756986;
										continue;
									}
									goto case 3;
								}
								goto case 0;
							case 3:
								Logger.LogWarning("Map Category \"" + value[num3] + "\" does not exist.");
								num = -1500756986;
								continue;
							case 4:
								goto end_IL_0063;
							case 7:
								num3 = 0;
								num = -1500756992;
								continue;
							case 0:
								num3++;
								num = -1500756992;
								continue;
							case 6:
								if (num3 >= value.Length)
								{
									_categoryIds = list.ToArray();
									num = -1500756988;
									continue;
								}
								goto case 9;
							case 2:
								return;
							}
							break;
						}
						continue;
						end_IL_0063:
						break;
					}
					_preInitCategoryNames = null;
					_categoryIds = EmptyObjects<int>.array;
				}
			}

			public string[] layoutNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (_preInitLayoutNames != null)
						{
							return _preInitLayoutNames;
						}
						goto IL_000f;
					}
					Initialize();
					if (_layoutIds == null)
					{
						return EmptyObjects<string>.array;
					}
					string[] array = new string[_layoutIds.Length];
					int num = 0;
					int num2 = -1458098862;
					goto IL_0014;
					IL_000f:
					num2 = -1458098860;
					goto IL_0014;
					IL_0014:
					InputLayout layout = default(InputLayout);
					while (true)
					{
						switch (num2 ^ -1458098863)
						{
						case 4:
							break;
						case 5:
							return EmptyObjects<string>.array;
						case 1:
							layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutIds[num]);
							num2 = -1458098863;
							continue;
						case 3:
							num2 = -1458098861;
							continue;
						case 0:
							array[num] = ((layout != null) ? layout.name : "INVALID");
							num++;
							num2 = -1458098861;
							continue;
						default:
							if (num >= _layoutIds.Length)
							{
								return array;
							}
							goto case 1;
						}
						break;
					}
					goto IL_000f;
				}
				set
				{
					if (!ReInput.isReady)
					{
						if (value != null)
						{
							goto IL_000d;
						}
						goto IL_005d;
					}
					goto IL_0124;
					IL_0140:
					_preInitLayoutNames = null;
					_layoutIds = EmptyObjects<int>.array;
					return;
					IL_000d:
					int num = 1718121796;
					goto IL_0012;
					IL_0012:
					List<int> list = default(List<int>);
					int num2 = default(int);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ 0x66687542)
						{
						case 2:
							break;
						case 0:
							num = 1718121795;
							continue;
						case 3:
							goto IL_005d;
						case 5:
							list = new List<int>(value.Length);
							num2 = 0;
							num = 1718121800;
							continue;
						case 6:
							if (value.Length > 0)
							{
								CheckNoControllerTypeError();
								num = 1718121793;
								continue;
							}
							goto IL_005d;
						case 8:
							if (!string.IsNullOrEmpty(value[num2]))
							{
								num3 = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value[num2]);
								num = 1718121806;
								continue;
							}
							goto case 1;
						case 12:
							if (num3 >= 0)
							{
								list.Add(num3);
								num = 1718121794;
								continue;
							}
							goto case 4;
						case 4:
							Logger.LogWarning("Layout \"" + value[num2] + "\" does not exist.");
							num = 1718121795;
							continue;
						case 11:
							CheckNoControllerTypeError();
							num = 1718121799;
							continue;
						case 7:
							goto IL_0124;
						case 9:
							goto IL_0140;
						case 1:
							num2++;
							num = 1718121800;
							continue;
						default:
							if (num2 >= value.Length)
							{
								_layoutIds = list.ToArray();
								return;
							}
							goto case 8;
						}
						break;
					}
					goto IL_000d;
					IL_005d:
					_preInitLayoutNames = ((value != null && value.Length > 0) ? value : null);
					_layoutIds = EmptyObjects<int>.array;
					return;
					IL_0124:
					if (value != null)
					{
						int num4;
						if (value.Length != 0)
						{
							num = 1718121801;
							num4 = num;
						}
						else
						{
							num = 1718121803;
							num4 = num;
						}
						goto IL_0012;
					}
					goto IL_0140;
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
					InputMapCategory mapCategory = default(InputMapCategory);
					if (_categoryIds != null)
					{
						if (_categoryIds.Length == 0)
						{
							num = 1197562719;
						}
						else
						{
							mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
							num = 1197562718;
						}
						goto IL_001f;
					}
					goto IL_0074;
					IL_001a:
					num = 1197562716;
					goto IL_001f;
					IL_001f:
					while (true)
					{
						switch (num ^ 0x47615B5D)
						{
						case 0:
							break;
						case 1:
							goto IL_0040;
						case 3:
							goto IL_006a;
						case 2:
							goto IL_0074;
						default:
							return "INVALID";
						}
						break;
						IL_006a:
						if (mapCategory == null)
						{
							num = 1197562713;
							continue;
						}
						return mapCategory.name;
					}
					goto IL_001a;
					IL_0074:
					return null;
					IL_0040:
					return null;
				}
				set
				{
					if (!ReInput.isReady)
					{
						_preInitCategoryNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
						_categoryIds = EmptyObjects<int>.array;
						while (true)
						{
							switch (0x40D066C7 ^ 0x40D066C4)
							{
							case 0:
								break;
							case 1:
								goto end_IL_002f;
							case 4:
								goto IL_0074;
							case 3:
								return;
							default:
								goto IL_009e;
							}
							continue;
							end_IL_002f:
							break;
						}
						goto IL_0055;
					}
					goto IL_0074;
					IL_009e:
					Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
					return;
					IL_0055:
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
					if (mapCategoryId >= 0)
					{
						categoryId = mapCategoryId;
						return;
					}
					goto IL_009e;
					IL_0074:
					if (string.IsNullOrEmpty(value))
					{
						_preInitCategoryNames = null;
						_categoryIds = EmptyObjects<int>.array;
						return;
					}
					goto IL_0055;
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
						goto IL_0038;
					}
					Initialize();
					int num;
					if (_layoutIds != null)
					{
						if (_layoutIds.Length == 0)
						{
							num = 1622904092;
							goto IL_001f;
						}
						InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutIds[0]);
						if (layout == null)
						{
							return "INVALID";
						}
						return layout.name;
					}
					goto IL_0062;
					IL_001a:
					num = 1622904095;
					goto IL_001f;
					IL_0038:
					return null;
					IL_001f:
					switch (num ^ 0x60BB8D1E)
					{
					case 0:
						break;
					case 1:
						goto IL_0038;
					default:
						goto IL_0062;
					}
					goto IL_001a;
					IL_0062:
					return null;
				}
				set
				{
					if (!ReInput.isReady)
					{
						if (!string.IsNullOrEmpty(value))
						{
							CheckNoControllerTypeError();
							goto IL_0015;
						}
						goto IL_0046;
					}
					goto IL_0084;
					IL_00a9:
					CheckNoControllerTypeError();
					int num = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
					int num2;
					int num3;
					if (num >= 0)
					{
						num2 = -553688981;
						num3 = num2;
					}
					else
					{
						num2 = -553688980;
						num3 = num2;
					}
					goto IL_001a;
					IL_0046:
					_preInitLayoutNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
					_layoutIds = EmptyObjects<int>.array;
					return;
					IL_0015:
					num2 = -553688983;
					goto IL_001a;
					IL_001a:
					while (true)
					{
						switch (num2 ^ -553688984)
						{
						case 6:
							break;
						case 1:
							goto IL_0046;
						case 3:
							layoutId = num;
							num2 = -553688982;
							continue;
						case 0:
							goto IL_0084;
						case 5:
							goto IL_00a9;
						case 2:
							return;
						default:
							Logger.LogWarning("Map Layout \"" + value + "\" does not exist.");
							return;
						}
						break;
					}
					goto IL_0015;
					IL_0084:
					if (string.IsNullOrEmpty(value))
					{
						_preInitLayoutNames = null;
						_layoutIds = EmptyObjects<int>.array;
						return;
					}
					goto IL_00a9;
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
						goto IL_0014;
					}
					Initialize();
					int num = -2114166104;
					goto IL_0019;
					IL_0019:
					int num2 = default(int);
					bool flag2 = default(bool);
					int num4 = default(int);
					bool flag = default(bool);
					while (true)
					{
						switch (num ^ -2114166098)
						{
						case 8:
							break;
						case 14:
						{
							int num5;
							if (num2 < _categoryIds.Length)
							{
								num = -2114166101;
								num5 = num;
							}
							else
							{
								num = -2114166111;
								num5 = num;
							}
							continue;
						}
						case 5:
						{
							int num3;
							if (ReInput.mapping.GetMapCategory(_categoryIds[num2]) == null)
							{
								num = -2114166108;
								num3 = num;
							}
							else
							{
								num = -2114166099;
								num3 = num;
							}
							continue;
						}
						case 2:
							flag2 = true;
							num = -2114166103;
							continue;
						case 9:
							num2 = 0;
							num = -2114166112;
							continue;
						case 7:
							num4++;
							num = -2114166110;
							continue;
						case 4:
							return true;
						case 6:
							if (_categoryIds != null && _categoryIds.Length > 0)
							{
								num = -2114166098;
								continue;
							}
							goto IL_0151;
						case 0:
							flag = false;
							num = -2114166105;
							continue;
						case 11:
							num4 = 0;
							num = -2114166110;
							continue;
						case 10:
							num2++;
							num = -2114166112;
							continue;
						case 12:
							if (num4 < _layoutIds.Length)
							{
								goto case 13;
							}
							if (!flag2)
							{
								num = -2114166097;
								continue;
							}
							goto IL_01a5;
						case 3:
							flag = true;
							num = -2114166108;
							continue;
						case 15:
							if (!flag)
							{
								return false;
							}
							goto IL_0151;
						case 13:
						{
							int num6;
							if (ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutIds[num4]) != null)
							{
								num = -2114166100;
								num6 = num;
							}
							else
							{
								num = -2114166103;
								num6 = num;
							}
							continue;
						}
						default:
							{
								return false;
							}
							IL_01a5:
							return true;
							IL_0151:
							if (_layoutIds != null && _layoutIds.Length > 0)
							{
								flag2 = false;
								num = -2114166107;
								continue;
							}
							goto IL_01a5;
						}
						break;
					}
					goto IL_0014;
					IL_0014:
					num = -2114166102;
					goto IL_0019;
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
				while (true)
				{
					int num = -531233231;
					while (true)
					{
						switch (num ^ -531233228)
						{
						case 4:
							break;
						default:
							return;
						case 0:
							_preInitLayoutNames = ArrayTools.ShallowCopy(source._preInitLayoutNames);
							num = -531233226;
							continue;
						case 1:
							_preInitCategoryNames = ArrayTools.ShallowCopy(source._preInitCategoryNames);
							num = -531233228;
							continue;
						case 3:
							_tag = source._tag;
							_enable = source._enable;
							_categoryIds = ArrayTools.ShallowCopy(source._categoryIds);
							_layoutIds = ArrayTools.ShallowCopy(source._layoutIds);
							_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
							num = -531233227;
							continue;
						case 5:
							if (source == null)
							{
								throw new ArgumentNullException("source");
							}
							goto case 3;
						case 2:
							return;
						}
						break;
					}
				}
			}

			internal Rule(string tag, bool enabled, int[] categoryIds, int[] layoutIds, ControllerSetSelector controllerSetSelector)
			{
				while (true)
				{
					int num = 1938514814;
					while (true)
					{
						switch (num ^ 0x738B637F)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							_layoutIds = layoutIds;
							_controllerSetSelector = controllerSetSelector;
							return;
						}
						break;
						IL_0024:
						_tag = tag;
						_enable = enabled;
						_categoryIds = categoryIds;
						num = 1938514813;
					}
				}
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
				if (_layoutIds != null && _layoutIds.Length > 0)
				{
					goto IL_004a;
				}
				goto IL_0088;
				IL_004f:
				int num;
				while (true)
				{
					switch (num ^ 0x37F5E027)
					{
					case 0:
						break;
					case 3:
						goto IL_006c;
					case 1:
						return false;
					default:
						return false;
					}
					break;
					IL_006c:
					if (!ArrayTools.Contains(_layoutIds, map.layoutId))
					{
						num = 938860582;
						continue;
					}
					goto IL_0088;
				}
				goto IL_004a;
				IL_004a:
				num = 938860580;
				goto IL_004f;
				IL_0088:
				if (!_controllerSetSelector.Matches(map.controller))
				{
					num = 938860581;
					goto IL_004f;
				}
				return true;
			}

			private void Initialize()
			{
				if (!ReInput.isReady)
				{
					return;
				}
				int num4 = default(int);
				List<int> list = default(List<int>);
				int num3 = default(int);
				List<int> list2 = default(List<int>);
				int mapCategoryId = default(int);
				while (true)
				{
					int num;
					int num2;
					if (_controllerSetSelector == null)
					{
						num = -1356449274;
						num2 = num;
					}
					else
					{
						num = -1356449272;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1356449272)
						{
						case 12:
							num = -1356449253;
							continue;
						default:
							return;
						case 7:
							if (num4 >= _preInitCategoryNames.Length)
							{
								_categoryIds = list.ToArray();
								num = -1356449250;
								continue;
							}
							goto case 2;
						case 22:
							_preInitCategoryNames = null;
							num = -1356449269;
							continue;
						case 13:
							num = -1356449278;
							continue;
						case 6:
							num = -1356449267;
							continue;
						case 9:
						{
							if (string.IsNullOrEmpty(_preInitLayoutNames[num3]))
							{
								goto case 15;
							}
							int num6 = ReInput.mapping.GetLayoutId(_controllerSetSelector.controllerType, _preInitLayoutNames[num3]);
							if (num6 >= 0)
							{
								list2.Add(num6);
								num = -1356449273;
								continue;
							}
							goto case 8;
						}
						case 10:
							num4++;
							num = -1356449265;
							continue;
						case 0:
						{
							int num5;
							if (_categoryIds != null)
							{
								num = -1356449277;
								num5 = num;
							}
							else
							{
								num = -1356449252;
								num5 = num;
							}
							continue;
						}
						case 5:
							if (num3 >= _preInitLayoutNames.Length)
							{
								_layoutIds = list2.ToArray();
								_preInitLayoutNames = null;
								num = -1356449256;
								continue;
							}
							goto case 9;
						case 3:
							if (_preInitLayoutNames != null && _preInitLayoutNames.Length != 0)
							{
								CheckNoControllerTypeError();
								list2 = new List<int>(_preInitLayoutNames.Length);
								num = -1356449271;
								continue;
							}
							return;
						case 19:
							break;
						case 17:
							num = -1356449265;
							continue;
						case 14:
							return;
						case 2:
							if (!string.IsNullOrEmpty(_preInitCategoryNames[num4]))
							{
								mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[num4]);
								int num7;
								if (mapCategoryId >= 0)
								{
									num = -1356449268;
									num7 = num;
								}
								else
								{
									num = -1356449254;
									num7 = num;
								}
								continue;
							}
							goto case 10;
						case 15:
							num3++;
							num = -1356449267;
							continue;
						case 21:
							num4 = 0;
							num = -1356449255;
							continue;
						case 20:
							_categoryIds = EmptyObjects<int>.array;
							num = -1356449277;
							continue;
						case 18:
							Logger.LogWarning("Map Category \"" + _preInitCategoryNames[num4] + "\" does not exist.");
							num = -1356449278;
							continue;
						case 4:
							list.Add(mapCategoryId);
							num = -1356449275;
							continue;
						case 11:
							if (_preInitCategoryNames != null && _preInitCategoryNames.Length != 0)
							{
								list = new List<int>(_preInitCategoryNames.Length);
								num = -1356449251;
								continue;
							}
							goto case 3;
						case 8:
							Logger.LogWarning("Map Layout \"" + _preInitLayoutNames[num3] + "\" does not exist.");
							num = -1356449273;
							continue;
						case 1:
							num3 = 0;
							num = -1356449266;
							continue;
						case 16:
							return;
						}
						break;
					}
				}
			}

			private void CheckNoControllerTypeError()
			{
				if (_controllerSetSelector == null)
				{
					return;
				}
				while (!_controllerSetSelector.hasControllerType)
				{
					object[] array = new object[5];
					int num = 1725486302;
					while (true)
					{
						switch (num ^ 0x66D8D4DE)
						{
						case 4:
							num = 1725486301;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							Logger.LogWarning(string.Concat(array), true);
							num = 1725486300;
							continue;
						case 0:
							array[0] = "A Layout should not be set when using ";
							array[1] = typeof(ControllerSetSelector.Type).FullName;
							array[2] = ".";
							array[3] = _controllerSetSelector.type;
							array[4] = " because each Controller type has its own unique Layouts.";
							num = 1725486303;
							continue;
						case 2:
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
		[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class RuleSet : IDeepCloneable, IEnumerable, IList<Rule>, ICollection<Rule>, IEnumerable<Rule>
		{
			private const string className = "ControllerMapEnabler.RuleSet";

			[Serialize(Name = "enabled")]
			[SerializeField]
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
				while (true)
				{
					int num = ((_rules != null) ? _rules.Count : 0);
					int num2 = 0;
					int num3 = -544563525;
					while (true)
					{
						switch (num3 ^ -544563525)
						{
						case 2:
							goto IL_000e;
						case 1:
							break;
						default:
							while (true)
							{
								if (num2 < num)
								{
									try
									{
										if (predicate(_rules[num2]))
										{
											Rule result = _rules[num2];
											while (true)
											{
												switch (-544563526 ^ -544563525)
												{
												case 0:
													break;
												default:
													goto end_IL_006f;
												case 2:
													goto end_IL_006f;
												case 1:
													return result;
												}
												continue;
												end_IL_006f:
												break;
											}
										}
									}
									catch (Exception exception)
									{
										ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.Find", exception);
									}
									num2++;
									goto IL_00aa;
								}
								int num4 = -544563527;
								goto IL_00af;
								IL_00af:
								switch (num4 ^ -544563525)
								{
								case 0:
									break;
								case 1:
									continue;
								default:
									return null;
								}
								goto IL_00aa;
								IL_00aa:
								num4 = -544563526;
								goto IL_00af;
							}
						}
						break;
						IL_000e:
						num3 = -544563526;
					}
				}
			}

			public Rule FindLast(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int num3 = default(int);
				while (true)
				{
					int num = ((_rules != null) ? _rules.Count : 0);
					int num2 = -1021552984;
					while (true)
					{
						switch (num2 ^ -1021552982)
						{
						case 0:
							num2 = -1021552981;
							continue;
						case 1:
							break;
						case 2:
							num3 = num - 1;
							num2 = -1021552983;
							continue;
						default:
							while (num3 >= 0)
							{
								try
								{
									if (predicate(_rules[num3]))
									{
										Rule result = _rules[num3];
										while (true)
										{
											switch (-1021552981 ^ -1021552982)
											{
											case 0:
												break;
											default:
												goto end_IL_007c;
											case 2:
												goto end_IL_007c;
											case 1:
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
									ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLast", exception);
								}
								num3--;
							}
							return null;
						}
						break;
					}
				}
			}

			public int FindIndex(Predicate<Rule> predicate)
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
						int num = 258758484;
						while (true)
						{
							switch (num ^ 0xF6C5756)
							{
							case 0:
								num = 258758487;
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
				int num4 = 0;
				while (true)
				{
					if (num4 < num3)
					{
						try
						{
							if (predicate(_rules[num4]))
							{
								while (true)
								{
									switch (0xF6C5754 ^ 0xF6C5756)
									{
									case 0:
										break;
									default:
										goto end_IL_0062;
									case 2:
										return num4;
									case 1:
										goto end_IL_0062;
									}
									continue;
									end_IL_0062:
									break;
								}
							}
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindIndex", exception);
						}
						num4++;
						goto IL_009f;
					}
					int num5 = 258758484;
					goto IL_00a4;
					IL_00a4:
					switch (num5 ^ 0xF6C5756)
					{
					case 0:
						break;
					case 1:
						continue;
					default:
						return -1;
					}
					goto IL_009f;
					IL_009f:
					num5 = 258758487;
					goto IL_00a4;
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
								switch (0x39D3A65D ^ 0x39D3A65C)
								{
								case 0:
									break;
								default:
									goto end_IL_003f;
								case 1:
									return num2;
								case 2:
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
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLastIndex", exception);
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
				while (true)
				{
					int num = 388998330;
					while (true)
					{
						switch (num ^ 0x172FA4B8)
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
						_rules.CopyTo(array, arrayIndex);
						num = 388998329;
					}
				}
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

		internal class euPDSnhapeLdIFbRcRtnHgEFqhjZ
		{
			public bool appfMKaqLDaFygKwjlcapUkzJTZ;

			public xARLMDSmNatmMHrqILZLrYZBlkK[] yebXgEdIkiRFZVDlACCvMrzhgfg;

			public euPDSnhapeLdIFbRcRtnHgEFqhjZ(bool enabled, xARLMDSmNatmMHrqILZLrYZBlkK[] startingRuleSets)
			{
				while (true)
				{
					int num = -918666993;
					while (true)
					{
						switch (num ^ -918666994)
						{
						case 2:
							break;
						case 1:
							goto IL_0024;
						default:
							yebXgEdIkiRFZVDlACCvMrzhgfg = startingRuleSets;
							return;
						}
						break;
						IL_0024:
						appfMKaqLDaFygKwjlcapUkzJTZ = enabled;
						num = -918666994;
					}
				}
			}
		}

		private bool gmbIkkevNmPVGSTIwKcAwoPYANrc;

		private Player JIqiIfYNWcNgEfGpdhnEBWMXlMl;

		private euPDSnhapeLdIFbRcRtnHgEFqhjZ VvpVayscawyJzLgAFsufsYCxdZq;

		private readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

		private List<RuleSet> KaoFGMGunedDDSnxIUIkCGKwnxNS;

		public bool enabled
		{
			get
			{
				return gmbIkkevNmPVGSTIwKcAwoPYANrc;
			}
			set
			{
				gmbIkkevNmPVGSTIwKcAwoPYANrc = value;
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
				return KaoFGMGunedDDSnxIUIkCGKwnxNS;
			}
			set
			{
				if (value == null)
				{
					value = new List<RuleSet>();
				}
				KaoFGMGunedDDSnxIUIkCGKwnxNS = value;
			}
		}

		internal ControllerMapEnabler(Player player, euPDSnhapeLdIFbRcRtnHgEFqhjZ startingSettings)
		{
			if (player == null)
			{
				throw new ArgumentNullException("player");
			}
			if (startingSettings == null)
			{
				throw new ArgumentNullException("startingSettings");
			}
			SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
			JIqiIfYNWcNgEfGpdhnEBWMXlMl = player;
			VvpVayscawyJzLgAFsufsYCxdZq = startingSettings;
		}

		public void Apply()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return;
			}
			int count = default(int);
			int num5 = default(int);
			int count3 = default(int);
			int num6 = default(int);
			Rule rule = default(Rule);
			RuleSet ruleSet = default(RuleSet);
			int num4 = default(int);
			int count2 = default(int);
			while (gmbIkkevNmPVGSTIwKcAwoPYANrc)
			{
				while (true)
				{
					IL_0093:
					int num;
					int num2;
					if (KaoFGMGunedDDSnxIUIkCGKwnxNS != null)
					{
						num = 1583478578;
						num2 = num;
					}
					else
					{
						num = 1583478579;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x5E61F730)
						{
						case 0:
							num = 1583478577;
							continue;
						case 1:
							break;
						case 6:
							goto IL_005c;
						case 5:
							return;
						case 3:
							return;
						case 2:
							count = KaoFGMGunedDDSnxIUIkCGKwnxNS.Count;
							num = 1583478582;
							continue;
						case 7:
							goto IL_0093;
						default:
						{
							using (TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>())
							{
								List<ControllerMap> list = tList.list;
								JIqiIfYNWcNgEfGpdhnEBWMXlMl.controllers.maps.GetAllMaps(list);
								while (true)
								{
									int num3 = 1583478586;
									while (true)
									{
										switch (num3 ^ 0x5E61F730)
										{
										case 4:
											break;
										case 9:
										{
											int num8;
											if (num5 >= count3)
											{
												num3 = 1583478581;
												num8 = num3;
											}
											else
											{
												num3 = 1583478582;
												num8 = num3;
											}
											continue;
										}
										case 1:
										{
											ControllerMap controllerMap = list[num6];
											if (controllerMap.enabled != rule.enable && rule.Matches(controllerMap))
											{
												controllerMap.enabled = rule.enable;
												num3 = 1583478587;
												continue;
											}
											goto case 11;
										}
										case 8:
											num5++;
											num3 = 1583478585;
											continue;
										case 11:
											num6++;
											num3 = 1583478579;
											continue;
										case 2:
										{
											ruleSet = KaoFGMGunedDDSnxIUIkCGKwnxNS[num4];
											int num9;
											if (ruleSet != null)
											{
												num3 = 1583478576;
												num9 = num3;
											}
											else
											{
												num3 = 1583478581;
												num9 = num3;
											}
											continue;
										}
										case 5:
											num4++;
											num3 = 1583478583;
											continue;
										case 0:
											if (ruleSet.enabled)
											{
												count3 = ruleSet.Count;
												num5 = 0;
												num3 = 1583478585;
												continue;
											}
											goto case 5;
										case 3:
										{
											int num7;
											if (num6 >= count2)
											{
												num3 = 1583478584;
												num7 = num3;
											}
											else
											{
												num3 = 1583478577;
												num7 = num3;
											}
											continue;
										}
										case 10:
											count2 = list.Count;
											num4 = 0;
											num3 = 1583478583;
											continue;
										case 6:
											rule = ruleSet[num5];
											if (rule != null)
											{
												num6 = 0;
												num3 = 1583478579;
												continue;
											}
											goto case 8;
										default:
											if (num4 >= count)
											{
												return;
											}
											goto case 2;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_005c:
						int num10;
						if (count != 0)
						{
							num = 1583478580;
							num10 = num;
						}
						else
						{
							num = 1583478581;
							num10 = num;
						}
					}
					break;
				}
			}
		}

		public void LoadDefaults()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_0010;
			}
			goto IL_00a0;
			IL_0010:
			int num = -1030663329;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			int num3 = default(int);
			RuleSet controllerMapEnablerRuleSetInstance = default(RuleSet);
			List<RuleSet> list = default(List<RuleSet>);
			while (true)
			{
				switch (num ^ -1030663330)
				{
				case 2:
					break;
				case 0:
					goto IL_0045;
				case 3:
					if (num2 < num3)
					{
						goto case 7;
					}
					if (VvpVayscawyJzLgAFsufsYCxdZq != null)
					{
						gmbIkkevNmPVGSTIwKcAwoPYANrc = VvpVayscawyJzLgAFsufsYCxdZq.appfMKaqLDaFygKwjlcapUkzJTZ;
						num = -1030663336;
						continue;
					}
					goto default;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return;
				case 5:
					goto IL_00a0;
				case 4:
					controllerMapEnablerRuleSetInstance.enabled = VvpVayscawyJzLgAFsufsYCxdZq.yebXgEdIkiRFZVDlACCvMrzhgfg[num2].startEnabled;
					list.Add(controllerMapEnablerRuleSetInstance);
					num2++;
					num = -1030663331;
					continue;
				case 7:
					controllerMapEnablerRuleSetInstance = ReInput.mapping.GetControllerMapEnablerRuleSetInstance(VvpVayscawyJzLgAFsufsYCxdZq.yebXgEdIkiRFZVDlACCvMrzhgfg[num2].id);
					num = -1030663334;
					continue;
				default:
					KaoFGMGunedDDSnxIUIkCGKwnxNS = list;
					Apply();
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0045:
			int num4 = 0;
			goto IL_0055;
			IL_00a0:
			list = new List<RuleSet>();
			if (VvpVayscawyJzLgAFsufsYCxdZq == null)
			{
				goto IL_0045;
			}
			if (VvpVayscawyJzLgAFsufsYCxdZq.yebXgEdIkiRFZVDlACCvMrzhgfg != null)
			{
				num4 = VvpVayscawyJzLgAFsufsYCxdZq.yebXgEdIkiRFZVDlACCvMrzhgfg.Length;
				goto IL_0055;
			}
			num = -1030663330;
			goto IL_0015;
			IL_0055:
			num3 = num4;
			num2 = 0;
			num = -1030663331;
			goto IL_0015;
		}

		public string ToXmlString()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return string.Empty;
			}
			string result = default(string);
			try
			{
				result = LxAJUQVkKiSNqkaHsfsZAlQLTqTK().ToXmlString(true);
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_002f:
					int num = 1754567272;
					while (true)
					{
						switch (num ^ 0x68949269)
						{
						case 0:
							break;
						default:
							goto end_IL_0034;
						case 1:
							goto IL_004d;
						case 2:
							goto end_IL_0034;
						}
						goto IL_002f;
						IL_004d:
						Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
						result = string.Empty;
						num = 1754567275;
						continue;
						end_IL_0034:
						break;
					}
					break;
				}
			}
			return result;
		}

		public string ToJsonString()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return string.Empty;
			}
			try
			{
				return LxAJUQVkKiSNqkaHsfsZAlQLTqTK().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public bool ImportXml(string xmlString)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			bool result = default(bool);
			try
			{
				kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject.FromXml(GetType(), xmlString));
				Apply();
				result = true;
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_0039:
					int num = 227279544;
					while (true)
					{
						switch (num ^ 0xD8C02BB)
						{
						case 2:
							break;
						default:
							goto end_IL_003e;
						case 3:
							Logger.LogError("Error importing " + GetType().Name + " data from XML. " + ex.Message);
							num = 227279547;
							continue;
						case 0:
							result = false;
							num = 227279546;
							continue;
						case 1:
							goto end_IL_003e;
						}
						goto IL_0039;
						continue;
						end_IL_003e:
						break;
					}
					break;
				}
			}
			return result;
		}

		public bool ImportJson(string jsonString)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			try
			{
				kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject.FromJson(GetType(), jsonString));
				Apply();
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + GetType().Name + " data from JSON. " + ex.Message);
				return false;
			}
		}

		private SerializedObject LxAJUQVkKiSNqkaHsfsZAlQLTqTK()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			gyDRCyJXihwmsjCNUJfVsbvPOAC(serializedObject);
			return serializedObject;
		}

		private void gyDRCyJXihwmsjCNUJfVsbvPOAC(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0016;
			}
			goto IL_013d;
			IL_013d:
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			int num = -783257836;
			goto IL_001b;
			IL_0016:
			num = -783257838;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -783257834)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					P_0.Add("ruleSets", KaoFGMGunedDDSnxIUIkCGKwnxNS);
					num = -783257835;
					continue;
				case 2:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
					});
					P_0.Add("enabled", gmbIkkevNmPVGSTIwKcAwoPYANrc);
					num = -783257833;
					continue;
				case 4:
					goto IL_013d;
				case 3:
					return;
				}
				break;
			}
			goto IL_0016;
		}

		private bool kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject P_0)
		{
			gmbIkkevNmPVGSTIwKcAwoPYANrc = false;
			KaoFGMGunedDDSnxIUIkCGKwnxNS = null;
			P_0.TryGetDeserializedValueByRef("enabled", ref gmbIkkevNmPVGSTIwKcAwoPYANrc);
			List<RuleSet> value = new List<RuleSet>();
			while (true)
			{
				int num = -588012004;
				while (true)
				{
					switch (num ^ -588012003)
					{
					case 2:
						break;
					case 1:
						goto IL_0044;
					default:
						return true;
					}
					break;
					IL_0044:
					P_0.TryGetDeserializedValueByRef("ruleSets", ref value);
					KaoFGMGunedDDSnxIUIkCGKwnxNS = value;
					num = -588012003;
				}
			}
		}
	}
}
