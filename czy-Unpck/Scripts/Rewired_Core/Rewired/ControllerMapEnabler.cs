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

			[SerializeField]
			[Serialize(Name = "categoryIds")]
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
						goto IL_0003;
					}
					goto IL_0034;
					IL_0003:
					int num = -1449100641;
					goto IL_0008;
					IL_0008:
					while (true)
					{
						switch (num ^ -1449100642)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							value = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
							num = -1449100644;
							continue;
						case 2:
							goto IL_0034;
						case 0:
							return;
						}
						break;
					}
					goto IL_0003;
					IL_0034:
					_controllerSetSelector = value;
					num = -1449100642;
					goto IL_0008;
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
						value = EmptyObjects<int>.array;
						goto IL_000a;
					}
					goto IL_0028;
					IL_0028:
					_categoryIds = value;
					int num = -1682068656;
					goto IL_000f;
					IL_000a:
					num = -1682068653;
					goto IL_000f;
					IL_000f:
					switch (num ^ -1682068655)
					{
					case 0:
						break;
					case 2:
						goto IL_0028;
					default:
						_preInitCategoryNames = null;
						return;
					}
					goto IL_000a;
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
						goto IL_0003;
					}
					goto IL_0060;
					IL_0003:
					int num = -1707112949;
					goto IL_0008;
					IL_0008:
					while (true)
					{
						switch (num ^ -1707112945)
						{
						case 0:
							break;
						default:
							return;
						case 4:
							value = EmptyObjects<int>.array;
							num = -1707112948;
							continue;
						case 1:
							goto IL_003f;
						case 6:
							CheckNoControllerTypeError();
							num = -1707112950;
							continue;
						case 3:
							goto IL_0060;
						case 2:
							goto IL_0075;
						case 5:
							return;
						}
						break;
						IL_0075:
						int num2;
						if (value.Length <= 0)
						{
							num = -1707112950;
							num2 = num;
						}
						else
						{
							num = -1707112951;
							num2 = num;
						}
						continue;
						IL_003f:
						int num3;
						if (value != null)
						{
							num = -1707112951;
							num3 = num;
						}
						else
						{
							num = -1707112947;
							num3 = num;
						}
					}
					goto IL_0003;
					IL_0060:
					_layoutIds = value;
					_preInitLayoutNames = null;
					num = -1707112946;
					goto IL_0008;
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
						goto IL_0070;
					}
					_categoryIds = EmptyObjects<int>.array;
					goto IL_0099;
					IL_0070:
					int num;
					int num2;
					if (_categoryIds != null)
					{
						num = -672633203;
						num2 = num;
					}
					else
					{
						num = -672633206;
						num2 = num;
					}
					goto IL_0019;
					IL_0099:
					_preInitCategoryNames = null;
					num = -672633208;
					goto IL_0019;
					IL_0019:
					while (true)
					{
						switch (num ^ -672633202)
						{
						case 2:
							num = -672633201;
							continue;
						default:
							return;
						case 4:
							_categoryIds = new int[1];
							num = -672633205;
							continue;
						case 3:
							break;
						case 1:
							goto end_IL_0019;
						case 5:
							_categoryIds[0] = value;
							num = -672633202;
							continue;
						case 0:
							goto IL_0099;
						case 6:
							return;
						}
						int num3;
						if (_categoryIds.Length != 0)
						{
							num = -672633205;
							num3 = num;
						}
						else
						{
							num = -672633206;
							num3 = num;
						}
						continue;
						end_IL_0019:
						break;
					}
					goto IL_0070;
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
						goto IL_0062;
					}
					_layoutIds = EmptyObjects<int>.array;
					goto IL_007b;
					IL_00aa:
					_preInitLayoutNames = null;
					return;
					IL_007b:
					int num;
					if (value >= 0)
					{
						CheckNoControllerTypeError();
						num = -828696755;
						goto IL_0016;
					}
					goto IL_00aa;
					IL_0062:
					int num2;
					if (_layoutIds == null)
					{
						num = -828696760;
						num2 = num;
					}
					else
					{
						num = -828696758;
						num2 = num;
					}
					goto IL_0016;
					IL_0016:
					while (true)
					{
						switch (num ^ -828696757)
						{
						case 5:
							num = -828696759;
							continue;
						case 3:
							_layoutIds = new int[1];
							num = -828696757;
							continue;
						case 0:
							_layoutIds[0] = value;
							num = -828696753;
							continue;
						case 2:
							break;
						case 4:
							goto IL_007b;
						case 1:
							goto IL_008c;
						default:
							goto IL_00aa;
						}
						break;
						IL_008c:
						int num3;
						if (_layoutIds.Length == 0)
						{
							num = -828696760;
							num3 = num;
						}
						else
						{
							num = -828696757;
							num3 = num;
						}
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
						goto IL_0007;
					}
					Initialize();
					if (_categoryIds == null)
					{
						return EmptyObjects<string>.array;
					}
					string[] array = new string[_categoryIds.Length];
					int num = 0;
					int num2 = -1148557791;
					goto IL_000c;
					IL_0007:
					num2 = -1148557789;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						switch (num2 ^ -1148557790)
						{
						case 2:
							break;
						case 1:
							if (_preInitCategoryNames == null)
							{
								return EmptyObjects<string>.array;
							}
							return _preInitCategoryNames;
						case 3:
						{
							int num3;
							if (num < _categoryIds.Length)
							{
								num2 = -1148557790;
								num3 = num2;
							}
							else
							{
								num2 = -1148557786;
								num3 = num2;
							}
							continue;
						}
						case 0:
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[num]);
							array[num] = ((mapCategory != null) ? mapCategory.name : "INVALID");
							num++;
							num2 = -1148557791;
							continue;
						}
						default:
							return array;
						}
						break;
					}
					goto IL_0007;
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
					int mapCategoryId = default(int);
					while (true)
					{
						int num;
						int num2;
						if (value != null)
						{
							num = -1108716261;
							num2 = num;
						}
						else
						{
							num = -1108716265;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1108716271)
							{
							case 5:
								num = -1108716267;
								continue;
							case 12:
								Logger.LogWarning("Map Category \"" + value[num3] + "\" does not exist.");
								num = -1108716262;
								continue;
							case 8:
								list = new List<int>(value.Length);
								num = -1108716269;
								continue;
							case 3:
								if (!string.IsNullOrEmpty(value[num3]))
								{
									mapCategoryId = ReInput.mapping.GetMapCategoryId(value[num3]);
									num = -1108716271;
									continue;
								}
								goto case 11;
							case 4:
								break;
							case 6:
								_preInitCategoryNames = null;
								num = -1108716264;
								continue;
							case 0:
							{
								int num5;
								if (mapCategoryId >= 0)
								{
									num = -1108716272;
									num5 = num;
								}
								else
								{
									num = -1108716259;
									num5 = num;
								}
								continue;
							}
							case 10:
							{
								int num4;
								if (value.Length != 0)
								{
									num = -1108716263;
									num4 = num;
								}
								else
								{
									num = -1108716265;
									num4 = num;
								}
								continue;
							}
							case 1:
								list.Add(mapCategoryId);
								num = -1108716262;
								continue;
							case 9:
								_categoryIds = EmptyObjects<int>.array;
								return;
							case 11:
								num3++;
								num = -1108716266;
								continue;
							case 2:
								num3 = 0;
								num = -1108716266;
								continue;
							default:
								if (num3 >= value.Length)
								{
									_categoryIds = list.ToArray();
									return;
								}
								goto case 3;
							}
							break;
						}
					}
				}
			}

			public string[] layoutNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						goto IL_0007;
					}
					Initialize();
					if (_layoutIds == null)
					{
						return EmptyObjects<string>.array;
					}
					string[] array = new string[_layoutIds.Length];
					int num = 0;
					int num2 = -718154314;
					goto IL_000c;
					IL_0007:
					num2 = -718154316;
					goto IL_000c;
					IL_000c:
					while (true)
					{
						string[] array2;
						int num3;
						string obj;
						switch (num2 ^ -718154313)
						{
						case 2:
							break;
						case 3:
							if (_preInitLayoutNames == null)
							{
								return EmptyObjects<string>.array;
							}
							return _preInitLayoutNames;
						case 0:
						{
							InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutIds[num]);
							array2 = array;
							num3 = num;
							obj = ((layout != null) ? layout.name : "INVALID");
							goto IL_0099;
						}
						default:
							if (num >= _layoutIds.Length)
							{
								return array;
							}
							goto case 0;
						}
						break;
						IL_0099:
						array2[num3] = obj;
						num++;
						num2 = -718154314;
					}
					goto IL_0007;
				}
				set
				{
					if (ReInput.isReady)
					{
						goto IL_00c4;
					}
					if (value != null)
					{
						goto IL_0010;
					}
					goto IL_0137;
					IL_00c4:
					int num;
					if (value != null)
					{
						int num2;
						if (value.Length != 0)
						{
							num = -2005032873;
							num2 = num;
						}
						else
						{
							num = -2005032866;
							num2 = num;
						}
						goto IL_0015;
					}
					goto IL_006e;
					IL_0010:
					num = -2005032867;
					goto IL_0015;
					IL_0015:
					int num4 = default(int);
					List<int> list = default(List<int>);
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -2005032868)
						{
						case 12:
							break;
						case 11:
							CheckNoControllerTypeError();
							num = -2005032869;
							continue;
						case 2:
							goto IL_006e;
						case 4:
							_layoutIds = EmptyObjects<int>.array;
							return;
						case 9:
							if (num4 >= 0)
							{
								list.Add(num4);
								num = -2005032871;
								continue;
							}
							goto case 0;
						case 5:
							num3++;
							num = -2005032879;
							continue;
						case 14:
							goto IL_00c4;
						case 8:
							num4 = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value[num3]);
							num = -2005032875;
							continue;
						case 6:
							goto IL_0103;
						case 1:
							if (value.Length > 0)
							{
								CheckNoControllerTypeError();
								num = -2005032874;
								continue;
							}
							goto IL_0137;
						case 10:
							goto IL_0137;
						case 3:
							num3 = 0;
							num = -2005032879;
							continue;
						case 7:
							list = new List<int>(value.Length);
							num = -2005032865;
							continue;
						case 0:
							Logger.LogWarning("Layout \"" + value[num3] + "\" does not exist.");
							num = -2005032871;
							continue;
						default:
							if (num3 >= value.Length)
							{
								_layoutIds = list.ToArray();
								return;
							}
							goto IL_0103;
						}
						break;
						IL_0103:
						int num5;
						if (string.IsNullOrEmpty(value[num3]))
						{
							num = -2005032871;
							num5 = num;
						}
						else
						{
							num = -2005032876;
							num5 = num;
						}
					}
					goto IL_0010;
					IL_006e:
					_preInitLayoutNames = null;
					_layoutIds = EmptyObjects<int>.array;
					return;
					IL_0137:
					_preInitLayoutNames = ((value != null && value.Length > 0) ? value : null);
					num = -2005032872;
					goto IL_0015;
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
						goto IL_0038;
					}
					Initialize();
					int num;
					if (_categoryIds != null)
					{
						if (_categoryIds.Length == 0)
						{
							num = 1497191145;
							goto IL_001f;
						}
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
						if (mapCategory == null)
						{
							return "INVALID";
						}
						return mapCategory.name;
					}
					goto IL_0062;
					IL_001a:
					num = 1497191146;
					goto IL_001f;
					IL_0038:
					return null;
					IL_001f:
					switch (num ^ 0x593D52E8)
					{
					case 0:
						break;
					case 2:
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
						_preInitCategoryNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
						_categoryIds = EmptyObjects<int>.array;
						return;
					}
					int mapCategoryId = default(int);
					while (true)
					{
						int num;
						int num2;
						if (string.IsNullOrEmpty(value))
						{
							num = 1540284106;
							num2 = num;
						}
						else
						{
							num = 1540284105;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x5BCEDECF)
							{
							case 0:
								num = 1540284107;
								continue;
							case 4:
								break;
							case 1:
								categoryId = mapCategoryId;
								num = 1540284108;
								continue;
							case 5:
								_preInitCategoryNames = null;
								_categoryIds = EmptyObjects<int>.array;
								return;
							case 3:
								return;
							case 6:
							{
								mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
								int num3;
								if (mapCategoryId >= 0)
								{
									num = 1540284110;
									num3 = num;
								}
								else
								{
									num = 1540284109;
									num3 = num;
								}
								continue;
							}
							default:
								Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
								return;
							}
							break;
						}
					}
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
							goto IL_0012;
						}
						goto IL_0091;
					}
					Initialize();
					int num = 1714634668;
					goto IL_0017;
					IL_0091:
					return null;
					IL_0017:
					while (true)
					{
						switch (num ^ 0x66333FAD)
						{
						case 2:
							break;
						case 1:
							if (_layoutIds != null)
							{
								goto IL_0044;
							}
							goto case 3;
						case 3:
							return null;
						case 5:
							goto IL_007f;
						case 0:
							goto IL_0091;
						default:
							return "INVALID";
						}
						break;
						IL_007f:
						if (_preInitLayoutNames.Length <= 0)
						{
							num = 1714634669;
							continue;
						}
						return _preInitLayoutNames[0];
						IL_0044:
						if (_layoutIds.Length == 0)
						{
							num = 1714634670;
							continue;
						}
						InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutIds[0]);
						if (layout == null)
						{
							num = 1714634665;
							continue;
						}
						return layout.name;
					}
					goto IL_0012;
					IL_0012:
					num = 1714634664;
					goto IL_0017;
				}
				set
				{
					if (!ReInput.isReady)
					{
						if (!string.IsNullOrEmpty(value))
						{
							CheckNoControllerTypeError();
							goto IL_0018;
						}
						goto IL_008f;
					}
					goto IL_00b6;
					IL_008f:
					_preInitLayoutNames = ((!string.IsNullOrEmpty(value)) ? new string[1] { value } : null);
					int num = -1556493181;
					goto IL_001d;
					IL_00b6:
					int num2;
					if (!string.IsNullOrEmpty(value))
					{
						num = -1556493170;
						num2 = num;
					}
					else
					{
						num = -1556493169;
						num2 = num;
					}
					goto IL_001d;
					IL_0018:
					num = -1556493179;
					goto IL_001d;
					IL_001d:
					int num3 = default(int);
					while (true)
					{
						switch (num ^ -1556493177)
						{
						case 0:
							break;
						case 8:
							_preInitLayoutNames = null;
							num = -1556493183;
							continue;
						case 1:
							return;
						case 9:
							CheckNoControllerTypeError();
							num3 = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
							num = -1556493184;
							continue;
						case 2:
							goto IL_008f;
						case 3:
							goto IL_00b6;
						case 4:
							_layoutIds = EmptyObjects<int>.array;
							num = -1556493178;
							continue;
						case 6:
							_layoutIds = EmptyObjects<int>.array;
							return;
						case 7:
							if (num3 >= 0)
							{
								layoutId = num3;
								return;
							}
							goto default;
						default:
							Logger.LogWarning("Map Layout \"" + value + "\" does not exist.");
							return;
						}
						break;
					}
					goto IL_0018;
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
					bool flag = default(bool);
					if (_categoryIds != null && _categoryIds.Length > 0)
					{
						flag = false;
						goto IL_0034;
					}
					goto IL_00b6;
					IL_0039:
					int num;
					int num2 = default(int);
					int num3 = default(int);
					bool flag2 = default(bool);
					while (true)
					{
						switch (num ^ 0xE0F702)
						{
						case 9:
							break;
						case 6:
							num2 = 0;
							num = 14743301;
							continue;
						case 4:
							if (ReInput.mapping.GetMapCategory(_categoryIds[num3]) != null)
							{
								flag = true;
								num = 14743303;
								continue;
							}
							goto case 5;
						case 5:
							num3++;
							num = 14743296;
							continue;
						case 2:
							if (num3 < _categoryIds.Length)
							{
								goto case 4;
							}
							goto IL_00b1;
						case 10:
							num2++;
							num = 14743301;
							continue;
						case 0:
							flag2 = false;
							num = 14743300;
							continue;
						case 8:
							num3 = 0;
							num = 14743296;
							continue;
						case 3:
							if (ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutIds[num2]) != null)
							{
								flag2 = true;
								num = 14743304;
								continue;
							}
							goto case 10;
						case 7:
							if (num2 < _layoutIds.Length)
							{
								goto case 3;
							}
							goto IL_0132;
						default:
							return false;
						}
						break;
						IL_0132:
						if (!flag2)
						{
							num = 14743299;
							continue;
						}
						goto IL_0141;
					}
					goto IL_0034;
					IL_00b1:
					if (!flag)
					{
						return false;
					}
					goto IL_00b6;
					IL_00b6:
					if (_layoutIds != null && _layoutIds.Length > 0)
					{
						num = 14743298;
						goto IL_0039;
					}
					goto IL_0141;
					IL_0141:
					return true;
					IL_0034:
					num = 14743306;
					goto IL_0039;
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
				if (_layoutIds != null && _layoutIds.Length > 0 && !ArrayTools.Contains(_layoutIds, map.layoutId))
				{
					return false;
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
					return;
				}
				int num3 = default(int);
				int num4 = default(int);
				List<int> list2 = default(List<int>);
				List<int> list = default(List<int>);
				while (true)
				{
					int num;
					int num2;
					if (_controllerSetSelector != null)
					{
						num = 1395999881;
						num2 = num;
					}
					else
					{
						num = 1395999880;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x53354484)
						{
						case 3:
							num = 1395999878;
							continue;
						default:
							return;
						case 13:
						{
							int num5;
							if (_categoryIds != null)
							{
								num = 1395999877;
								num5 = num;
							}
							else
							{
								num = 1395999882;
								num5 = num;
							}
							continue;
						}
						case 17:
							num3++;
							num = 1395999892;
							continue;
						case 14:
							_categoryIds = EmptyObjects<int>.array;
							num = 1395999877;
							continue;
						case 2:
							break;
						case 5:
							Logger.LogWarning("Map Layout \"" + _preInitLayoutNames[num4] + "\" does not exist.");
							num = 1395999885;
							continue;
						case 10:
							num4 = 0;
							num = 1395999884;
							continue;
						case 0:
							if (_preInitLayoutNames != null && _preInitLayoutNames.Length != 0)
							{
								CheckNoControllerTypeError();
								list2 = new List<int>(_preInitLayoutNames.Length);
								num = 1395999886;
								continue;
							}
							return;
						case 8:
							if (num4 >= _preInitLayoutNames.Length)
							{
								_layoutIds = list2.ToArray();
								_preInitLayoutNames = null;
								num = 1395999874;
								continue;
							}
							goto case 11;
						case 12:
							return;
						case 11:
							if (!string.IsNullOrEmpty(_preInitLayoutNames[num4]))
							{
								int num7 = ReInput.mapping.GetLayoutId(_controllerSetSelector.controllerType, _preInitLayoutNames[num4]);
								if (num7 >= 0)
								{
									list2.Add(num7);
									num = 1395999885;
									continue;
								}
								goto case 5;
							}
							goto case 9;
						case 9:
							num4++;
							num = 1395999884;
							continue;
						case 16:
							if (num3 >= _preInitCategoryNames.Length)
							{
								_categoryIds = list.ToArray();
								_preInitCategoryNames = null;
								num = 1395999876;
								continue;
							}
							goto case 7;
						case 4:
						{
							int mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[num3]);
							if (mapCategoryId >= 0)
							{
								list.Add(mapCategoryId);
								num = 1395999893;
								continue;
							}
							goto case 15;
						}
						case 7:
						{
							int num6;
							if (string.IsNullOrEmpty(_preInitCategoryNames[num3]))
							{
								num = 1395999893;
								num6 = num;
							}
							else
							{
								num = 1395999872;
								num6 = num;
							}
							continue;
						}
						case 1:
							if (_preInitCategoryNames != null && _preInitCategoryNames.Length != 0)
							{
								list = new List<int>(_preInitCategoryNames.Length);
								num3 = 0;
								num = 1395999892;
								continue;
							}
							goto case 0;
						case 15:
							Logger.LogWarning("Map Category \"" + _preInitCategoryNames[num3] + "\" does not exist.");
							num = 1395999893;
							continue;
						case 6:
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
					goto IL_000b;
				}
				goto IL_00b2;
				IL_000b:
				int num = -945075021;
				goto IL_0010;
				IL_0010:
				object[] array = default(object[]);
				while (true)
				{
					switch (num ^ -945075019)
					{
					case 2:
						break;
					default:
						return;
					case 0:
						array = new object[5];
						num = -945075023;
						continue;
					case 3:
						array[1] = typeof(ControllerSetSelector.Type).FullName;
						array[2] = ".";
						array[3] = _controllerSetSelector.type;
						array[4] = " because each Controller type has its own unique Layouts.";
						Logger.LogWarning(string.Concat(array), requiredThreadSafety: true);
						num = -945075020;
						continue;
					case 4:
						array[0] = "A Layout should not be set when using ";
						num = -945075018;
						continue;
					case 6:
						return;
					case 5:
						goto IL_00b2;
					case 1:
						return;
					}
					break;
				}
				goto IL_000b;
				IL_00b2:
				int num2;
				if (_controllerSetSelector.hasControllerType)
				{
					num = -945075020;
					num2 = num;
				}
				else
				{
					num = -945075019;
					num2 = num;
				}
				goto IL_0010;
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
					goto IL_0003;
				}
				goto IL_0032;
				IL_0003:
				int num = 1452282504;
				goto IL_0008;
				IL_0008:
				int i = default(int);
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x5690128C)
					{
					case 3:
						break;
					case 2:
						i = 0;
						num = 1452282509;
						continue;
					case 0:
						goto IL_0032;
					case 4:
						throw new ArgumentNullException("predicate");
					default:
						for (; i < num2; i++)
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
									switch (0x5690128D ^ 0x5690128C)
									{
									case 0:
										break;
									default:
										goto end_IL_0088;
									case 2:
										goto end_IL_0088;
									case 1:
										return result;
									}
									continue;
									end_IL_0088:
									break;
								}
							}
							catch (Exception exception)
							{
								while (true)
								{
									IL_00b2:
									int num3 = 1452282510;
									while (true)
									{
										switch (num3 ^ 0x5690128C)
										{
										case 0:
											break;
										default:
											goto end_IL_00b7;
										case 2:
											goto IL_00d0;
										case 1:
											goto end_IL_00b7;
										}
										goto IL_00b2;
										IL_00d0:
										ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.Find", exception);
										num3 = 1452282509;
										continue;
										end_IL_00b7:
										break;
									}
									break;
								}
							}
						}
						return null;
					}
					break;
				}
				goto IL_0003;
				IL_0032:
				num2 = ((_rules != null) ? _rules.Count : 0);
				num = 1452282510;
				goto IL_0008;
			}

			public Rule FindLast(Predicate<Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int num4 = default(int);
				while (true)
				{
					int num;
					if (_rules == null)
					{
						num = 1390431455;
						goto IL_0013;
					}
					int num2 = _rules.Count;
					goto IL_004d;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x52E04CDC)
						{
						case 0:
							num = 1390431453;
							continue;
						case 1:
							break;
						case 3:
							goto IL_003f;
						default:
						{
							for (int num3 = num4 - 1; num3 >= 0; num3--)
							{
								try
								{
									if (predicate(_rules[num3]))
									{
										while (true)
										{
											switch (0x52E04CDD ^ 0x52E04CDC)
											{
											case 2:
												break;
											default:
												goto end_IL_006f;
											case 1:
												return _rules[num3];
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
									ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLast", exception);
								}
							}
							return null;
						}
						}
						break;
					}
					continue;
					IL_003f:
					num2 = 0;
					goto IL_004d;
					IL_004d:
					num4 = num2;
					num = 1390431454;
					goto IL_0013;
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
						int num = 1696956566;
						while (true)
						{
							switch (num ^ 0x65258097)
							{
							case 0:
								num = 1696956565;
								continue;
							case 2:
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
				for (int i = 0; i < num3; i++)
				{
					try
					{
						if (predicate(_rules[i]))
						{
							return i;
						}
					}
					catch (Exception exception)
					{
						while (true)
						{
							IL_0069:
							int num4 = 1696956566;
							while (true)
							{
								switch (num4 ^ 0x65258097)
								{
								case 0:
									break;
								default:
									goto end_IL_006e;
								case 1:
									goto IL_0087;
								case 2:
									goto end_IL_006e;
								}
								goto IL_0069;
								IL_0087:
								ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindIndex", exception);
								num4 = 1696956565;
								continue;
								end_IL_006e:
								break;
							}
							break;
						}
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
					int num2 = 1098945306;
					while (true)
					{
						switch (num2 ^ 0x4180931A)
						{
						case 2:
							goto IL_000e;
						case 1:
							break;
						default:
						{
							for (int num3 = num - 1; num3 >= 0; num3--)
							{
								try
								{
									if (predicate(_rules[num3]))
									{
										return num3;
									}
								}
								catch (Exception exception)
								{
									ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLastIndex", exception);
								}
							}
							return -1;
						}
						}
						break;
						IL_000e:
						num2 = 1098945307;
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
				while (true)
				{
					int num = 1118340863;
					while (true)
					{
						switch (num ^ 0x42A886FE)
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
						_rules.Insert(index, item);
						num = 1118340862;
					}
				}
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

		internal class DsPdjyUGWkefBITeOKEcuyqvmdo
		{
			public bool HtdGURQdmZAxbFNRsWOhkrWwBOyf;

			public YHTAmSgoHymgTIiCLrqYNhoUTqdP[] BLdEkNHLHeSIQVaWHixkCGNujuTC;

			public DsPdjyUGWkefBITeOKEcuyqvmdo(bool enabled, YHTAmSgoHymgTIiCLrqYNhoUTqdP[] startingRuleSets)
			{
				HtdGURQdmZAxbFNRsWOhkrWwBOyf = enabled;
				BLdEkNHLHeSIQVaWHixkCGNujuTC = startingRuleSets;
			}
		}

		private bool FnzJwrQpikWfZbmfjZhFwutJGAA;

		private Player gPwfZkeassnAZjQOgQSROFcEjaCL;

		private DsPdjyUGWkefBITeOKEcuyqvmdo eOdTdCKRseUaVkxDGRwhqiKkSJH;

		private readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		private List<RuleSet> rtozYLCKUuGiEQUODfCbMkcrsVi;

		public bool enabled
		{
			get
			{
				return FnzJwrQpikWfZbmfjZhFwutJGAA;
			}
			set
			{
				FnzJwrQpikWfZbmfjZhFwutJGAA = value;
				if (!value)
				{
					return;
				}
				while (true)
				{
					int num = 1772757799;
					while (true)
					{
						switch (num ^ 0x69AA2325)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0028;
						case 1:
							return;
						}
						break;
						IL_0028:
						Apply();
						num = 1772757796;
					}
				}
			}
		}

		public List<RuleSet> ruleSets
		{
			get
			{
				return rtozYLCKUuGiEQUODfCbMkcrsVi;
			}
			set
			{
				if (value == null)
				{
					value = new List<RuleSet>();
				}
				rtozYLCKUuGiEQUODfCbMkcrsVi = value;
			}
		}

		internal ControllerMapEnabler(Player player, DsPdjyUGWkefBITeOKEcuyqvmdo startingSettings)
		{
			if (player == null)
			{
				throw new ArgumentNullException("player");
			}
			if (startingSettings == null)
			{
				throw new ArgumentNullException("startingSettings");
			}
			vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
			gPwfZkeassnAZjQOgQSROFcEjaCL = player;
			eOdTdCKRseUaVkxDGRwhqiKkSJH = startingSettings;
		}

		public void Apply()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			goto IL_009f;
			IL_0086:
			int num;
			int num2;
			if (rtozYLCKUuGiEQUODfCbMkcrsVi == null)
			{
				num = -1223851767;
				num2 = num;
			}
			else
			{
				num = -1223851762;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -1223851765;
			goto IL_0021;
			IL_0021:
			int num8 = default(int);
			int num6 = default(int);
			int count2 = default(int);
			Rule rule = default(Rule);
			RuleSet ruleSet = default(RuleSet);
			int count3 = default(int);
			int num4 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ -1223851761)
				{
				case 3:
					break;
				case 4:
					return;
				case 1:
					goto IL_0056;
				case 5:
					return;
				case 6:
					return;
				case 2:
					goto IL_0086;
				case 0:
					goto IL_009f;
				default:
				{
					using (TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>())
					{
						List<ControllerMap> list = tList.list;
						while (true)
						{
							int num3 = -1223851762;
							while (true)
							{
								switch (num3 ^ -1223851761)
								{
								case 5:
									break;
								default:
									return;
								case 3:
									num8++;
									num3 = -1223851769;
									continue;
								case 6:
								{
									int num7;
									if (num6 >= count2)
									{
										num3 = -1223851776;
										num7 = num3;
									}
									else
									{
										num3 = -1223851768;
										num7 = num3;
									}
									continue;
								}
								case 10:
									num3 = -1223851767;
									continue;
								case 7:
									rule = ruleSet[num6];
									if (rule != null)
									{
										num8 = 0;
										num3 = -1223851770;
										continue;
									}
									goto case 4;
								case 1:
									gPwfZkeassnAZjQOgQSROFcEjaCL.controllers.maps.GetAllMaps(list);
									count3 = list.Count;
									num4 = 0;
									num3 = -1223851761;
									continue;
								case 8:
								{
									int num9;
									if (num8 >= count3)
									{
										num3 = -1223851765;
										num9 = num3;
									}
									else
									{
										num3 = -1223851774;
										num9 = num3;
									}
									continue;
								}
								case 9:
									num3 = -1223851769;
									continue;
								case 15:
									num4++;
									num3 = -1223851773;
									continue;
								case 11:
									ruleSet = rtozYLCKUuGiEQUODfCbMkcrsVi[num4];
									if (ruleSet != null && ruleSet.enabled)
									{
										count2 = ruleSet.Count;
										num3 = -1223851763;
										continue;
									}
									goto case 15;
								case 0:
									num3 = -1223851773;
									continue;
								case 13:
								{
									ControllerMap controllerMap = list[num8];
									if (controllerMap.enabled != rule.enable && rule.Matches(controllerMap))
									{
										controllerMap.enabled = rule.enable;
										num3 = -1223851764;
										continue;
									}
									goto case 3;
								}
								case 2:
									num6 = 0;
									num3 = -1223851771;
									continue;
								case 4:
									num6++;
									num3 = -1223851767;
									continue;
								case 12:
								{
									int num5;
									if (num4 >= count)
									{
										num3 = -1223851775;
										num5 = num3;
									}
									else
									{
										num3 = -1223851772;
										num5 = num3;
									}
									continue;
								}
								case 14:
									return;
								}
								break;
							}
						}
					}
				}
				}
				break;
				IL_0056:
				count = rtozYLCKUuGiEQUODfCbMkcrsVi.Count;
				int num10;
				if (count == 0)
				{
					num = -1223851766;
					num10 = num;
				}
				else
				{
					num = -1223851768;
					num10 = num;
				}
			}
			goto IL_001c;
			IL_009f:
			if (!FnzJwrQpikWfZbmfjZhFwutJGAA)
			{
				return;
			}
			goto IL_0086;
		}

		public void LoadDefaults()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			int num3 = default(int);
			int num4 = default(int);
			RuleSet controllerMapEnablerRuleSetInstance = default(RuleSet);
			while (true)
			{
				List<RuleSet> list = new List<RuleSet>();
				if (eOdTdCKRseUaVkxDGRwhqiKkSJH == null)
				{
					goto IL_0130;
				}
				int num;
				if (eOdTdCKRseUaVkxDGRwhqiKkSJH.BLdEkNHLHeSIQVaWHixkCGNujuTC == null)
				{
					num = 70532738;
					goto IL_0022;
				}
				int num2 = eOdTdCKRseUaVkxDGRwhqiKkSJH.BLdEkNHLHeSIQVaWHixkCGNujuTC.Length;
				goto IL_0140;
				IL_0130:
				num2 = 0;
				goto IL_0140;
				IL_0140:
				num3 = num2;
				num4 = 0;
				num = 70532744;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ 0x4343E88)
					{
					case 7:
						num = 70532747;
						continue;
					default:
						return;
					case 8:
						rtozYLCKUuGiEQUODfCbMkcrsVi = list;
						Apply();
						num = 70532748;
						continue;
					case 2:
						if (eOdTdCKRseUaVkxDGRwhqiKkSJH != null)
						{
							FnzJwrQpikWfZbmfjZhFwutJGAA = eOdTdCKRseUaVkxDGRwhqiKkSJH.HtdGURQdmZAxbFNRsWOhkrWwBOyf;
							num = 70532736;
							continue;
						}
						goto case 8;
					case 9:
						num4++;
						num = 70532744;
						continue;
					case 5:
						break;
					case 11:
						list.Add(controllerMapEnablerRuleSetInstance);
						num = 70532737;
						continue;
					case 12:
						controllerMapEnablerRuleSetInstance = ReInput.mapping.GetControllerMapEnablerRuleSetInstance(eOdTdCKRseUaVkxDGRwhqiKkSJH.BLdEkNHLHeSIQVaWHixkCGNujuTC[num4].id);
						num = 70532749;
						continue;
					case 3:
						goto end_IL_0022;
					case 1:
						Logger.LogError("Invalid Map Enabler Manager Rule Set is assigned to Player. This should not be possible. If you are seeing this error, this is a sign of serialized data corruption, usually caused by a bad source control merge.");
						num = 70532737;
						continue;
					case 10:
						goto IL_0130;
					case 0:
						goto IL_014d;
					case 6:
						controllerMapEnablerRuleSetInstance.enabled = eOdTdCKRseUaVkxDGRwhqiKkSJH.BLdEkNHLHeSIQVaWHixkCGNujuTC[num4].startEnabled;
						num = 70532739;
						continue;
					case 4:
						return;
					}
					int num5;
					if (controllerMapEnablerRuleSetInstance == null)
					{
						num = 70532745;
						num5 = num;
					}
					else
					{
						num = 70532750;
						num5 = num;
					}
					continue;
					IL_014d:
					int num6;
					if (num4 >= num3)
					{
						num = 70532746;
						num6 = num;
					}
					else
					{
						num = 70532740;
						num6 = num;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return string.Empty;
			}
			try
			{
				return mtMtVVrohwWTxFPivXmGbDyGevo().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return string.Empty;
			}
			try
			{
				return mtMtVVrohwWTxFPivXmGbDyGevo().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public bool ImportXml(string xmlString)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			try
			{
				FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = 1429131949;
					while (true)
					{
						switch (num ^ 0x552ED2AC)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = 1429131950;
					}
				}
			}
			try
			{
				FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject.FromJson(GetType(), jsonString));
				Apply();
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + GetType().Name + " data from JSON. " + ex.Message);
				return false;
			}
		}

		private SerializedObject mtMtVVrohwWTxFPivXmGbDyGevo()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			JcTmuzzUPdkdhEZeDhOUstVShFv(serializedObject);
			return serializedObject;
		}

		private void JcTmuzzUPdkdhEZeDhOUstVShFv(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0013;
			}
			goto IL_0034;
			IL_0034:
			P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
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
			int num = 272438647;
			goto IL_0018;
			IL_0013:
			num = 272438644;
			goto IL_0018;
			IL_0018:
			switch (num ^ 0x103D1576)
			{
			case 0:
				break;
			case 2:
				goto IL_0034;
			default:
				P_0.Add("enabled", FnzJwrQpikWfZbmfjZhFwutJGAA);
				P_0.Add("ruleSets", rtozYLCKUuGiEQUODfCbMkcrsVi);
				return;
			}
			goto IL_0013;
		}

		private bool FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			FnzJwrQpikWfZbmfjZhFwutJGAA = false;
			List<RuleSet> value = default(List<RuleSet>);
			while (true)
			{
				int num = 1040260536;
				while (true)
				{
					switch (num ^ 0x3E011DBA)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						rtozYLCKUuGiEQUODfCbMkcrsVi = value;
						return true;
					}
					break;
					IL_0025:
					rtozYLCKUuGiEQUODfCbMkcrsVi = null;
					P_0.TryGetDeserializedValueByRef("enabled", ref FnzJwrQpikWfZbmfjZhFwutJGAA);
					value = new List<RuleSet>();
					P_0.TryGetDeserializedValueByRef("ruleSets", ref value);
					num = 1040260539;
				}
			}
		}
	}
}
