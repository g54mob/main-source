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
		private static class InuCBsCLQvbaGMtSTyWfUpCHavcfb
		{
			private static ADictionary<Type, List<object>> rtjooPolGsUxZGGYBqFppJVTWYVt;

			private static ADictionary<Type, List<object>> bSBMBQFJRYvkoHbpvjrghMIYgpUgb
			{
				get
				{
					if (rtjooPolGsUxZGGYBqFppJVTWYVt == null)
					{
						return rtjooPolGsUxZGGYBqFppJVTWYVt = new ADictionary<Type, List<object>>();
					}
					return rtjooPolGsUxZGGYBqFppJVTWYVt;
				}
			}

			public static TList<_0001> eDmJhjwicpgsrCJxJgupuZYnZDgmA<_0001>(List<_0001> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				if (!bSBMBQFJRYvkoHbpvjrghMIYgpUgb.ContainsKey(typeof(_0001)))
				{
					bSBMBQFJRYvkoHbpvjrghMIYgpUgb.Add(typeof(_0001), new List<object>(3));
				}
				List<object> list = bSBMBQFJRYvkoHbpvjrghMIYgpUgb[typeof(_0001)];
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

			public static void jeKrbEKBZYfOdckzyxnppYvXWRoMA<_0001>(TList<_0001> P_0)
			{
				if (P_0 != null)
				{
					if (!bSBMBQFJRYvkoHbpvjrghMIYgpUgb.TryGetValue(typeof(_0001), out var value))
					{
						value = new List<object>(3);
						bSBMBQFJRYvkoHbpvjrghMIYgpUgb.Add(typeof(_0001), value);
					}
					if (value.Count < 3)
					{
						ListTools.AddIfUnique(value, P_0);
					}
				}
			}

			public static void XBkiraiRmgKOKscHAcrexDEDfMyAA()
			{
				rtjooPolGsUxZGGYBqFppJVTWYVt = null;
			}

			public static void hDVxHGxiWfCfBdTsDbuZreDIFteHA(Type P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				if (rtjooPolGsUxZGGYBqFppJVTWYVt != null && rtjooPolGsUxZGGYBqFppJVTWYVt.ContainsKey(P_0))
				{
					rtjooPolGsUxZGGYBqFppJVTWYVt.Remove(P_0);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : ITListSetter<T>, IDisposable
		{
			private List<T> aKNGjBGuijnnUpXTRyIaSMtSXkwE;

			private bool kKYaFsaKvWaiwljTtoTfEZvgoUGI;

			public List<T> list
			{
				get
				{
					if (kKYaFsaKvWaiwljTtoTfEZvgoUGI)
					{
						jFzJUEZMNBvRVaRgEfzdDtMJdtPt();
					}
					return aKNGjBGuijnnUpXTRyIaSMtSXkwE;
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
				if (!kKYaFsaKvWaiwljTtoTfEZvgoUGI)
				{
					KoHapCkzVhDWRCIPCQDCCEIrzxLrA();
					kKYaFsaKvWaiwljTtoTfEZvgoUGI = true;
				}
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			private void KoHapCkzVhDWRCIPCQDCCEIrzxLrA()
			{
				if (aKNGjBGuijnnUpXTRyIaSMtSXkwE != null)
				{
					Return(aKNGjBGuijnnUpXTRyIaSMtSXkwE);
				}
				aKNGjBGuijnnUpXTRyIaSMtSXkwE = null;
				InuCBsCLQvbaGMtSTyWfUpCHavcfb.jeKrbEKBZYfOdckzyxnppYvXWRoMA(this);
			}

			private void GUmhIwceXtxhTKMDraJmKjGZcUTJ(List<T> P_0)
			{
				aKNGjBGuijnnUpXTRyIaSMtSXkwE = P_0;
				kKYaFsaKvWaiwljTtoTfEZvgoUGI = false;
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GUmhIwceXtxhTKMDraJmKjGZcUTJ
				this.GUmhIwceXtxhTKMDraJmKjGZcUTJ(P_0);
			}

			private static void jFzJUEZMNBvRVaRgEfzdDtMJdtPt()
			{
				throw new Exception("The TList has been disposed.");
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return obj.list;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		private const int TvXrmEPrHyajhNSaGXjvnMcHGtkX = 3;

		private const int EUWWjakSyHxcvYPoIHZDHHopapzJA = 10;

		private static ADictionary<Type, List<IList>> QjLuUnVUuAbbsIbUYDulMvmjVVVJ;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (QjLuUnVUuAbbsIbUYDulMvmjVVVJ == null)
				{
					return QjLuUnVUuAbbsIbUYDulMvmjVVVJ = new ADictionary<Type, List<IList>>();
				}
				return QjLuUnVUuAbbsIbUYDulMvmjVVVJ;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return InuCBsCLQvbaGMtSTyWfUpCHavcfb.eDmJhjwicpgsrCJxJgupuZYnZDgmA(Get<T>(capacity));
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
			QjLuUnVUuAbbsIbUYDulMvmjVVVJ = null;
			InuCBsCLQvbaGMtSTyWfUpCHavcfb.XBkiraiRmgKOKscHAcrexDEDfMyAA();
		}

		public static void Clear(Type listType)
		{
			if (listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			if (QjLuUnVUuAbbsIbUYDulMvmjVVVJ != null && QjLuUnVUuAbbsIbUYDulMvmjVVVJ.ContainsKey(listType))
			{
				QjLuUnVUuAbbsIbUYDulMvmjVVVJ.Remove(listType);
				InuCBsCLQvbaGMtSTyWfUpCHavcfb.hDVxHGxiWfCfBdTsDbuZreDIFteHA(listType);
			}
		}
	}
}
