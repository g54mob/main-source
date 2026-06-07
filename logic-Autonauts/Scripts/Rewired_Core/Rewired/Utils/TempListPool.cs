using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class TempListPool
	{
		private static class drZTaYYSbfIsgBmIBDXmfonMJseX
		{
			private static ADictionary<Type, List<object>> lBnjWhAlsuIMPduoFaIDjoVJmAUm;

			private static ADictionary<Type, List<object>> tLists
			{
				get
				{
					if (lBnjWhAlsuIMPduoFaIDjoVJmAUm == null)
					{
						return lBnjWhAlsuIMPduoFaIDjoVJmAUm = new ADictionary<Type, List<object>>();
					}
					return lBnjWhAlsuIMPduoFaIDjoVJmAUm;
				}
			}

			public static TList<T> ovuvgpGKLrTGtZJVYkHrzqjgEIoi<T>(List<T> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				TList<T> tList2 = default(TList<T>);
				TList<T> tList = default(TList<T>);
				while (true)
				{
					int num;
					if (!tLists.ContainsKey(typeof(T)))
					{
						tLists.Add(typeof(T), new List<object>(3));
						num = -1323365377;
						goto IL_0013;
					}
					goto IL_006e;
					IL_0013:
					while (true)
					{
						switch (num ^ -1323365377)
						{
						case 2:
							num = -1323365381;
							continue;
						case 4:
							break;
						case 0:
							goto IL_006e;
						case 1:
							((ITListSetter<T>)tList2).SetList(P_0);
							return tList2;
						default:
							return tList;
						}
						break;
					}
					continue;
					IL_006e:
					List<object> list = tLists[typeof(T)];
					if (list.Count == 0)
					{
						tList2 = TList<T>.Create();
						num = -1323365378;
					}
					else
					{
						int index = list.Count - 1;
						tList = list[index] as TList<T>;
						list.RemoveAt(index);
						((ITListSetter<T>)tList).SetList(P_0);
						num = -1323365380;
					}
					goto IL_0013;
				}
			}

			public static void BbMgihKqiMGkyIaUydDakLxhTFj<T>(TList<T> P_0)
			{
				if (P_0 == null)
				{
					goto IL_0003;
				}
				goto IL_004b;
				IL_0003:
				int num = -1708534583;
				goto IL_0008;
				IL_0008:
				List<object> value = default(List<object>);
				while (true)
				{
					switch (num ^ -1708534584)
					{
					case 3:
						break;
					case 2:
						goto IL_0031;
					case 6:
						goto IL_004b;
					case 0:
						return;
					case 1:
						return;
					case 5:
						value = new List<object>(3);
						tLists.Add(typeof(T), value);
						num = -1708534582;
						continue;
					default:
						ListTools.AddIfUnique(value, P_0);
						return;
					}
					break;
					IL_0031:
					int num2;
					if (value.Count < 3)
					{
						num = -1708534580;
						num2 = num;
					}
					else
					{
						num = -1708534584;
						num2 = num;
					}
				}
				goto IL_0003;
				IL_004b:
				int num3;
				if (tLists.TryGetValue(typeof(T), out value))
				{
					num = -1708534582;
					num3 = num;
				}
				else
				{
					num = -1708534579;
					num3 = num;
				}
				goto IL_0008;
			}

			public static void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				lBnjWhAlsuIMPduoFaIDjoVJmAUm = null;
			}

			public static void QYwkAfdRMMgAPnyPzHFUdcsKUPp(Type P_0)
			{
				if ((object)P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				while (true)
				{
					int num;
					int num2;
					if (lBnjWhAlsuIMPduoFaIDjoVJmAUm != null)
					{
						num = -1478853323;
						num2 = num;
					}
					else
					{
						num = -1478853328;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1478853328)
						{
						case 4:
							num = -1478853325;
							continue;
						default:
							return;
						case 2:
							lBnjWhAlsuIMPduoFaIDjoVJmAUm.Remove(P_0);
							num = -1478853327;
							continue;
						case 0:
							return;
						case 5:
							if (!lBnjWhAlsuIMPduoFaIDjoVJmAUm.ContainsKey(P_0))
							{
								return;
							}
							goto case 2;
						case 3:
							break;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> nRmHtmCTLMujsmHWTvkVqllSHbd;

			private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

			public List<T> list
			{
				get
				{
					if (QQqHByfwytAJSuMZiCPjJlZYHKG)
					{
						SNyPbDUOOVTNKcOaKHdoPJLaHzv();
					}
					return nRmHtmCTLMujsmHWTvkVqllSHbd;
				}
			}

			public static TList<T> Create()
			{
				return new TList<T>();
			}

			private TList()
			{
			}

			public void Dispose()
			{
				if (QQqHByfwytAJSuMZiCPjJlZYHKG)
				{
					return;
				}
				while (true)
				{
					BbMgihKqiMGkyIaUydDakLxhTFj();
					int num = -772166983;
					while (true)
					{
						switch (num ^ -772166983)
						{
						case 2:
							goto IL_0009;
						case 1:
							break;
						default:
							QQqHByfwytAJSuMZiCPjJlZYHKG = true;
							return;
						}
						break;
						IL_0009:
						num = -772166984;
					}
				}
			}

			private void BbMgihKqiMGkyIaUydDakLxhTFj()
			{
				if (nRmHtmCTLMujsmHWTvkVqllSHbd != null)
				{
					Return(nRmHtmCTLMujsmHWTvkVqllSHbd);
				}
				nRmHtmCTLMujsmHWTvkVqllSHbd = null;
				drZTaYYSbfIsgBmIBDXmfonMJseX.BbMgihKqiMGkyIaUydDakLxhTFj(this);
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				nRmHtmCTLMujsmHWTvkVqllSHbd = P_0;
				QQqHByfwytAJSuMZiCPjJlZYHKG = false;
			}

			private static void SNyPbDUOOVTNKcOaKHdoPJLaHzv()
			{
				throw new Exception("The TList has been disposed.");
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return obj.list;
			}
		}

		private const int hHvxbrtGVzQPvgKYAqWAvrAWgUO = 3;

		private const int lEAQnRyQMnxmzFBDwHPBmdlvcjZk = 10;

		private static ADictionary<Type, List<IList>> dYHfNBGmKPkSNeyTYqEsfgSxksHI;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (dYHfNBGmKPkSNeyTYqEsfgSxksHI == null)
				{
					return dYHfNBGmKPkSNeyTYqEsfgSxksHI = new ADictionary<Type, List<IList>>();
				}
				return dYHfNBGmKPkSNeyTYqEsfgSxksHI;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return drZTaYYSbfIsgBmIBDXmfonMJseX.ovuvgpGKLrTGtZJVYkHrzqjgEIoi(Get<T>(capacity));
		}

		public static void ReturnTList<T>(TList<T> tList)
		{
			if (tList == null)
			{
				while (true)
				{
					switch (-421004620 ^ -421004619)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			tList.Dispose();
		}

		public static List<T> Get<T>()
		{
			return Get<T>(0);
		}

		public static List<T> Get<T>(int capacity)
		{
			if (capacity < 0)
			{
				capacity = 0;
				goto IL_000a;
			}
			goto IL_0127;
			IL_0161:
			List<IList> list = lists[typeof(T)];
			int count = default(int);
			int num = default(int);
			int index = default(int);
			int num2 = default(int);
			int num3;
			int index2 = default(int);
			if (list.Count != 0)
			{
				if (capacity > 0)
				{
					count = list.Count;
					num = -1;
					index = -1;
					num2 = 0;
					num3 = -490633205;
				}
				else
				{
					index2 = list.Count - 1;
					num3 = -490633210;
				}
			}
			else
			{
				num3 = -490633206;
			}
			goto IL_000f;
			IL_000a:
			num3 = -490633216;
			goto IL_000f;
			IL_000f:
			int capacity2 = default(int);
			List<T> list3 = default(List<T>);
			IList list2 = default(IList);
			while (true)
			{
				switch (num3 ^ -490633215)
				{
				case 6:
					break;
				case 11:
					return new List<T>((capacity == 0) ? 10 : capacity);
				case 2:
					num = capacity2;
					index = num2;
					num3 = -490633214;
					continue;
				case 3:
					goto IL_0093;
				case 5:
					if (num2 >= count)
					{
						list3 = list[index] as List<T>;
						list.RemoveAt(index);
						num3 = -490633207;
						continue;
					}
					goto case 9;
				case 9:
					list3 = list[num2] as List<T>;
					capacity2 = list3.Capacity;
					num3 = -490633215;
					continue;
				case 8:
					return list3;
				case 0:
					goto IL_010d;
				case 1:
					goto IL_0127;
				case 4:
					goto IL_0161;
				case 10:
					num3 = -490633212;
					continue;
				case 7:
					list2 = list[index2];
					num3 = -490633203;
					continue;
				default:
					list.RemoveAt(index2);
					return list2 as List<T>;
				}
				break;
				IL_010d:
				int num4;
				if (capacity2 <= num)
				{
					num3 = -490633214;
					num4 = num3;
				}
				else
				{
					num3 = -490633213;
					num4 = num3;
				}
				continue;
				IL_0093:
				if (capacity2 >= capacity)
				{
					list.RemoveAt(num2);
					return list3;
				}
				num2++;
				num3 = -490633212;
			}
			goto IL_000a;
			IL_0127:
			if (!lists.ContainsKey(typeof(T)))
			{
				lists.Add(typeof(T), new List<IList>(3));
				num3 = -490633211;
				goto IL_000f;
			}
			goto IL_0161;
		}

		public static void Return<T>(List<T> list)
		{
			if (list == null)
			{
				goto IL_0006;
			}
			goto IL_0088;
			IL_0006:
			int num = -693753128;
			goto IL_000b;
			IL_000b:
			List<IList> value = default(List<IList>);
			while (true)
			{
				switch (num ^ -693753124)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					return;
				case 6:
					if (value.Count >= 3)
					{
						return;
					}
					goto case 1;
				case 5:
					if (!lists.TryGetValue(typeof(T), out value))
					{
						value = new List<IList>(3);
						lists.Add(typeof(T), value);
						num = -693753126;
						continue;
					}
					goto case 6;
				case 3:
					goto IL_0088;
				case 1:
					ListTools.AddIfUnique(value, list);
					num = -693753122;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_0006;
			IL_0088:
			list.Clear();
			num = -693753127;
			goto IL_000b;
		}

		public static void Return<T>(List<T> list1, List<T> list2)
		{
			Return(list1);
			Return(list2);
		}

		public static void Return<T>(List<T> list1, List<T> list2, List<T> list3)
		{
			Return(list1);
			Return(list2);
			Return(list3);
		}

		public static void Clear()
		{
			dYHfNBGmKPkSNeyTYqEsfgSxksHI = null;
			drZTaYYSbfIsgBmIBDXmfonMJseX.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
		}

		public static void Clear(Type listType)
		{
			if ((object)listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			while (true)
			{
				int num;
				int num2;
				if (dYHfNBGmKPkSNeyTYqEsfgSxksHI == null)
				{
					num = -442203578;
					num2 = num;
				}
				else
				{
					num = -442203582;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -442203584)
					{
					case 3:
						num = -442203583;
						continue;
					default:
						return;
					case 5:
						return;
					case 6:
						return;
					case 0:
						dYHfNBGmKPkSNeyTYqEsfgSxksHI.Remove(listType);
						drZTaYYSbfIsgBmIBDXmfonMJseX.QYwkAfdRMMgAPnyPzHFUdcsKUPp(listType);
						num = -442203580;
						continue;
					case 2:
					{
						int num3;
						if (dYHfNBGmKPkSNeyTYqEsfgSxksHI.ContainsKey(listType))
						{
							num = -442203584;
							num3 = num;
						}
						else
						{
							num = -442203579;
							num3 = num;
						}
						continue;
					}
					case 1:
						break;
					case 4:
						return;
					}
					break;
				}
			}
		}
	}
}
