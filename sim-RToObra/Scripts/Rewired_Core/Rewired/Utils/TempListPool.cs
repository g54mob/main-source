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
		private static class IoTDbBaedtuNVutRxBPsdXpMhnhG
		{
			private static ADictionary<Type, List<object>> EEjZBqDCqeLbqANlnWSJTeXudZPe;

			private static ADictionary<Type, List<object>> tLists
			{
				get
				{
					if (EEjZBqDCqeLbqANlnWSJTeXudZPe == null)
					{
						return EEjZBqDCqeLbqANlnWSJTeXudZPe = new ADictionary<Type, List<object>>();
					}
					return EEjZBqDCqeLbqANlnWSJTeXudZPe;
				}
			}

			public static TList<T> DSaFdqDaHtazMxrEgzJvIYlkcFrb<T>(List<T> P_0)
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
						num = 1684000033;
						goto IL_0013;
					}
					goto IL_00a9;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x645FCD22)
						{
						case 0:
							num = 1684000032;
							continue;
						case 2:
							break;
						case 5:
							((ITListSetter<T>)tList2).SetList(P_0);
							num = 1684000035;
							continue;
						case 1:
							return tList2;
						case 3:
							goto IL_00a9;
						default:
							((ITListSetter<T>)tList).SetList(P_0);
							return tList;
						}
						break;
					}
					continue;
					IL_00a9:
					List<object> list = tLists[typeof(T)];
					if (list.Count != 0)
					{
						int index = list.Count - 1;
						tList = list[index] as TList<T>;
						list.RemoveAt(index);
						num = 1684000038;
					}
					else
					{
						tList2 = TList<T>.Create();
						num = 1684000039;
					}
					goto IL_0013;
				}
			}

			public static void uFWhGisiuQhxPuXVQLWsVdhrJMi<T>(TList<T> P_0)
			{
				if (P_0 == null)
				{
					goto IL_0003;
				}
				goto IL_0057;
				IL_0003:
				int num = 133242802;
				goto IL_0008;
				IL_0008:
				List<object> value = default(List<object>);
				switch (num ^ 0x7F11FB7)
				{
				case 0:
					break;
				case 4:
					goto IL_002d;
				case 2:
					return;
				case 5:
					return;
				case 3:
					goto IL_0057;
				default:
					ListTools.AddIfUnique(value, P_0);
					return;
				}
				goto IL_0003;
				IL_0057:
				if (!tLists.TryGetValue(typeof(T), out value))
				{
					value = new List<object>(3);
					tLists.Add(typeof(T), value);
					num = 133242803;
					goto IL_0008;
				}
				goto IL_002d;
				IL_002d:
				int num2;
				if (value.Count < 3)
				{
					num = 133242806;
					num2 = num;
				}
				else
				{
					num = 133242805;
					num2 = num;
				}
				goto IL_0008;
			}

			public static void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				EEjZBqDCqeLbqANlnWSJTeXudZPe = null;
			}

			public static void nympziBLtYDUiPlWNRoEGqbSPfa(Type P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				while (EEjZBqDCqeLbqANlnWSJTeXudZPe != null)
				{
					while (true)
					{
						IL_0043:
						int num;
						int num2;
						if (!EEjZBqDCqeLbqANlnWSJTeXudZPe.ContainsKey(P_0))
						{
							num = 1233831960;
							num2 = num;
						}
						else
						{
							num = 1233831961;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x498AC81A)
							{
							case 0:
								num = 1233831963;
								continue;
							case 1:
								break;
							case 4:
								goto IL_0043;
							case 2:
								return;
							default:
								EEjZBqDCqeLbqANlnWSJTeXudZPe.Remove(P_0);
								return;
							}
							break;
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
			private List<T> WHeApkgLGAZTtUIEfvfXHvQYCck;

			private bool vsurYtRlepcrpAzAENwjqjJEZPT;

			public List<T> list
			{
				get
				{
					if (vsurYtRlepcrpAzAENwjqjJEZPT)
					{
						jViguIyFIJVqrKtnyIzyqbNafsmi();
					}
					return WHeApkgLGAZTtUIEfvfXHvQYCck;
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
				if (vsurYtRlepcrpAzAENwjqjJEZPT)
				{
					return;
				}
				while (true)
				{
					uFWhGisiuQhxPuXVQLWsVdhrJMi();
					vsurYtRlepcrpAzAENwjqjJEZPT = true;
					int num = -1902033229;
					while (true)
					{
						switch (num ^ -1902033229)
						{
						case 2:
							goto IL_0009;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_0009:
						num = -1902033230;
					}
				}
			}

			private void uFWhGisiuQhxPuXVQLWsVdhrJMi()
			{
				if (WHeApkgLGAZTtUIEfvfXHvQYCck != null)
				{
					Return(WHeApkgLGAZTtUIEfvfXHvQYCck);
				}
				WHeApkgLGAZTtUIEfvfXHvQYCck = null;
				IoTDbBaedtuNVutRxBPsdXpMhnhG.uFWhGisiuQhxPuXVQLWsVdhrJMi(this);
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				WHeApkgLGAZTtUIEfvfXHvQYCck = P_0;
				vsurYtRlepcrpAzAENwjqjJEZPT = false;
			}

			private static void jViguIyFIJVqrKtnyIzyqbNafsmi()
			{
				throw new Exception("The TList has been disposed.");
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return obj.list;
			}
		}

		private const int UZnEsmcDVdncIfGPKuOSjMMTSTRK = 3;

		private const int IEGVLCGjQvGEMziQAVLPTXlfSkI = 10;

		private static ADictionary<Type, List<IList>> GlHXISOwULkhoAuMeVCqPMYrjfA;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (GlHXISOwULkhoAuMeVCqPMYrjfA == null)
				{
					return GlHXISOwULkhoAuMeVCqPMYrjfA = new ADictionary<Type, List<IList>>();
				}
				return GlHXISOwULkhoAuMeVCqPMYrjfA;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return IoTDbBaedtuNVutRxBPsdXpMhnhG.DSaFdqDaHtazMxrEgzJvIYlkcFrb(Get<T>(capacity));
		}

		public static void ReturnTList<T>(TList<T> tList)
		{
			if (tList != null)
			{
				tList.Dispose();
			}
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
			goto IL_00d0;
			IL_00d0:
			int num;
			if (!lists.ContainsKey(typeof(T)))
			{
				lists.Add(typeof(T), new List<IList>(3));
				num = -885867447;
				goto IL_000f;
			}
			goto IL_0199;
			IL_000a:
			num = -885867441;
			goto IL_000f;
			IL_000f:
			List<IList> list2 = default(List<IList>);
			int index2 = default(int);
			List<T> list3 = default(List<T>);
			int num3 = default(int);
			int capacity2 = default(int);
			int num2 = default(int);
			int count = default(int);
			int index = default(int);
			while (true)
			{
				switch (num ^ -885867442)
				{
				case 8:
					break;
				case 4:
					num = -885867442;
					continue;
				case 14:
					return new List<T>((capacity == 0) ? 10 : capacity);
				case 11:
					list2.RemoveAt(index2);
					return list3;
				case 13:
					num3 = capacity2;
					num = -885867452;
					continue;
				case 6:
					goto IL_00b6;
				case 1:
					goto IL_00d0;
				case 0:
					if (num2 >= count)
					{
						list3 = list2[index2] as List<T>;
						num = -885867451;
						continue;
					}
					goto case 9;
				case 5:
					num2 = 0;
					num = -885867446;
					continue;
				case 3:
					goto IL_0137;
				case 10:
					index2 = num2;
					num = -885867443;
					continue;
				case 9:
					list3 = list2[num2] as List<T>;
					capacity2 = list3.Capacity;
					num = -885867448;
					continue;
				case 2:
					goto IL_0184;
				case 7:
					goto IL_0199;
				default:
				{
					IList list = list2[index];
					list2.RemoveAt(index);
					return list as List<T>;
				}
				}
				break;
				IL_0184:
				if (list2.Count != 0)
				{
					if (capacity > 0)
					{
						count = list2.Count;
						num3 = -1;
						index2 = -1;
						num = -885867445;
					}
					else
					{
						index = list2.Count - 1;
						num = -885867454;
					}
				}
				else
				{
					num = -885867456;
				}
				continue;
				IL_0137:
				if (capacity2 >= capacity)
				{
					list2.RemoveAt(num2);
					return list3;
				}
				num2++;
				num = -885867442;
				continue;
				IL_00b6:
				int num4;
				if (capacity2 <= num3)
				{
					num = -885867443;
					num4 = num;
				}
				else
				{
					num = -885867453;
					num4 = num;
				}
			}
			goto IL_000a;
			IL_0199:
			list2 = lists[typeof(T)];
			num = -885867444;
			goto IL_000f;
		}

		public static void Return<T>(List<T> list)
		{
			if (list == null)
			{
				goto IL_0003;
			}
			goto IL_0047;
			IL_0003:
			int num = -1699002623;
			goto IL_0008;
			IL_0008:
			List<IList> value = default(List<IList>);
			while (true)
			{
				switch (num ^ -1699002617)
				{
				case 3:
					break;
				default:
					return;
				case 7:
					ListTools.AddIfUnique(value, list);
					num = -1699002618;
					continue;
				case 2:
					goto IL_0047;
				case 6:
					return;
				case 4:
					goto IL_007b;
				case 0:
					return;
				case 5:
					lists.Add(typeof(T), value);
					num = -1699002621;
					continue;
				case 1:
					return;
				}
				break;
			}
			goto IL_0003;
			IL_0047:
			list.Clear();
			if (!lists.TryGetValue(typeof(T), out value))
			{
				value = new List<IList>(3);
				num = -1699002622;
				goto IL_0008;
			}
			goto IL_007b;
			IL_007b:
			int num2;
			if (value.Count < 3)
			{
				num = -1699002624;
				num2 = num;
			}
			else
			{
				num = -1699002617;
				num2 = num;
			}
			goto IL_0008;
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
			GlHXISOwULkhoAuMeVCqPMYrjfA = null;
			IoTDbBaedtuNVutRxBPsdXpMhnhG.nympziBLtYDUiPlWNRoEGqbSPfa();
		}

		public static void Clear(Type listType)
		{
			if (listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			while (GlHXISOwULkhoAuMeVCqPMYrjfA != null)
			{
				while (true)
				{
					int num;
					int num2;
					if (!GlHXISOwULkhoAuMeVCqPMYrjfA.ContainsKey(listType))
					{
						num = 1041662193;
						num2 = num;
					}
					else
					{
						num = 1041662199;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x3E1680F3)
						{
						case 3:
							num = 1041662194;
							continue;
						case 2:
							return;
						case 0:
							break;
						case 1:
							goto end_IL_003c;
						default:
							GlHXISOwULkhoAuMeVCqPMYrjfA.Remove(listType);
							IoTDbBaedtuNVutRxBPsdXpMhnhG.nympziBLtYDUiPlWNRoEGqbSPfa(listType);
							return;
						}
						break;
					}
					continue;
					end_IL_003c:
					break;
				}
			}
		}
	}
}
