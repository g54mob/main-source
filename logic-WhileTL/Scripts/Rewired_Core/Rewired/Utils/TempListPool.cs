using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class TempListPool
	{
		private static class oeYjZccYbqTjyprxVmYhGgalkWmJA
		{
			private static ADictionary<Type, List<object>> yocutFfzunDtXGePTdNOiVONVuAp;

			private static ADictionary<Type, List<object>> quadIhoqhhHTeiVFZTApHHAhaUfv
			{
				get
				{
					if (yocutFfzunDtXGePTdNOiVONVuAp == null)
					{
						return yocutFfzunDtXGePTdNOiVONVuAp = new ADictionary<Type, List<object>>();
					}
					return yocutFfzunDtXGePTdNOiVONVuAp;
				}
			}

			public static TList<_0001> xhtcFTAIFkbVrsngWfYqcfcFHwyJc<_0001>(List<_0001> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				if (!quadIhoqhhHTeiVFZTApHHAhaUfv.ContainsKey(typeof(_0001)))
				{
					quadIhoqhhHTeiVFZTApHHAhaUfv.Add(typeof(_0001), new List<object>(3));
				}
				List<object> list = quadIhoqhhHTeiVFZTApHHAhaUfv[typeof(_0001)];
				if (list.Count == 0)
				{
					TList<_0001> tList = TList<_0001>.Create();
					((ITListSetter<_0001>)tList).SetList(P_0);
					return tList;
				}
				int index = list.Count - 1;
				TList<_0001> obj = list[index] as TList<_0001>;
				list.RemoveAt(index);
				((ITListSetter<_0001>)obj).SetList(P_0);
				return obj;
			}

			public static void KQXBUVQVyDLesmXxgIlxmsmKfXnj<_0001>(TList<_0001> P_0)
			{
				if (P_0 != null)
				{
					if (!quadIhoqhhHTeiVFZTApHHAhaUfv.TryGetValue(typeof(_0001), out var value))
					{
						value = new List<object>(3);
						quadIhoqhhHTeiVFZTApHHAhaUfv.Add(typeof(_0001), value);
					}
					if (value.Count < 3)
					{
						ListTools.AddIfUnique(value, P_0);
					}
				}
			}

			public static void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
				yocutFfzunDtXGePTdNOiVONVuAp = null;
			}

			public static void HnrFpPpHGPbrJRZcbYcTrFvnwjvi(Type P_0)
			{
				if ((object)P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				if (yocutFfzunDtXGePTdNOiVONVuAp != null && yocutFfzunDtXGePTdNOiVONVuAp.ContainsKey(P_0))
				{
					yocutFfzunDtXGePTdNOiVONVuAp.Remove(P_0);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> yStgeWABMBrpmQklPqcEgwUnhfhE;

			private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

			public List<T> list
			{
				get
				{
					if (JChPmMbeaoLOGQvosPYqDDInSiCs)
					{
						ZkveAxWjMIIKKYBLUZsbPOSRRDho();
					}
					return yStgeWABMBrpmQklPqcEgwUnhfhE;
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
				if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
				{
					KQXBUVQVyDLesmXxgIlxmsmKfXnj();
					JChPmMbeaoLOGQvosPYqDDInSiCs = true;
				}
			}

			private void KQXBUVQVyDLesmXxgIlxmsmKfXnj()
			{
				if (yStgeWABMBrpmQklPqcEgwUnhfhE != null)
				{
					Return(yStgeWABMBrpmQklPqcEgwUnhfhE);
				}
				yStgeWABMBrpmQklPqcEgwUnhfhE = null;
				oeYjZccYbqTjyprxVmYhGgalkWmJA.KQXBUVQVyDLesmXxgIlxmsmKfXnj(this);
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				yStgeWABMBrpmQklPqcEgwUnhfhE = P_0;
				JChPmMbeaoLOGQvosPYqDDInSiCs = false;
			}

			private static void ZkveAxWjMIIKKYBLUZsbPOSRRDho()
			{
				throw new Exception("The TList has been disposed.");
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return obj.list;
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		private const int wJqCYBjmZceMjGtlWbFJenHrDmEjb = 3;

		private const int uuHAdvogYaSijhIimAOKjkyQtBDJA = 10;

		private static ADictionary<Type, List<IList>> yvMtataMGIZDTSTqKcXdynNUCWVv;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (yvMtataMGIZDTSTqKcXdynNUCWVv == null)
				{
					return yvMtataMGIZDTSTqKcXdynNUCWVv = new ADictionary<Type, List<IList>>();
				}
				return yvMtataMGIZDTSTqKcXdynNUCWVv;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return oeYjZccYbqTjyprxVmYhGgalkWmJA.xhtcFTAIFkbVrsngWfYqcfcFHwyJc(Get<T>(capacity));
		}

		public static void ReturnTList<T>(TList<T> tList)
		{
			tList?.Dispose();
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
			}
			if (!lists.ContainsKey(typeof(T)))
			{
				lists.Add(typeof(T), new List<IList>(3));
			}
			List<IList> list = lists[typeof(T)];
			if (list.Count == 0)
			{
				return new List<T>((capacity == 0) ? 10 : capacity);
			}
			if (capacity > 0)
			{
				int count = list.Count;
				int num = -1;
				int index = -1;
				List<T> list2;
				for (int i = 0; i < count; i++)
				{
					list2 = list[i] as List<T>;
					int capacity2 = list2.Capacity;
					if (capacity2 > num)
					{
						num = capacity2;
						index = i;
					}
					if (capacity2 >= capacity)
					{
						list.RemoveAt(i);
						return list2;
					}
				}
				list2 = list[index] as List<T>;
				list.RemoveAt(index);
				return list2;
			}
			int index2 = list.Count - 1;
			IList list3 = list[index2];
			list.RemoveAt(index2);
			return list3 as List<T>;
		}

		public static void Return<T>(List<T> list)
		{
			if (list != null)
			{
				list.Clear();
				if (!lists.TryGetValue(typeof(T), out var value))
				{
					value = new List<IList>(3);
					lists.Add(typeof(T), value);
				}
				if (value.Count < 3)
				{
					ListTools.AddIfUnique(value, list);
				}
			}
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
			yvMtataMGIZDTSTqKcXdynNUCWVv = null;
			oeYjZccYbqTjyprxVmYhGgalkWmJA.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
		}

		public static void Clear(Type listType)
		{
			if ((object)listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			if (yvMtataMGIZDTSTqKcXdynNUCWVv != null && yvMtataMGIZDTSTqKcXdynNUCWVv.ContainsKey(listType))
			{
				yvMtataMGIZDTSTqKcXdynNUCWVv.Remove(listType);
				oeYjZccYbqTjyprxVmYhGgalkWmJA.HnrFpPpHGPbrJRZcbYcTrFvnwjvi(listType);
			}
		}
	}
}
