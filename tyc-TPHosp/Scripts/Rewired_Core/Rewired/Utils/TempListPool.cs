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
		private static class UiAAtmaEzFHIRLcDjJJkQPPNiEGI
		{
			private static ADictionary<Type, List<object>> MLyqbVLCaYJbwqRldWOTKOhtMme;

			private static ADictionary<Type, List<object>> tLists
			{
				get
				{
					if (MLyqbVLCaYJbwqRldWOTKOhtMme == null)
					{
						return MLyqbVLCaYJbwqRldWOTKOhtMme = new ADictionary<Type, List<object>>();
					}
					return MLyqbVLCaYJbwqRldWOTKOhtMme;
				}
			}

			public static TList<T> PErbMByiRLpfURxMubXbNOTjLuS<T>(List<T> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				if (!tLists.ContainsKey(typeof(T)))
				{
					tLists.Add(typeof(T), new List<object>(3));
				}
				List<object> list = tLists[typeof(T)];
				if (list.Count == 0)
				{
					TList<T> tList = TList<T>.Create();
					((ITListSetter<T>)tList).SetList(P_0);
					return tList;
				}
				int index = list.Count - 1;
				TList<T> tList2 = list[index] as TList<T>;
				list.RemoveAt(index);
				((ITListSetter<T>)tList2).SetList(P_0);
				return tList2;
			}

			public static void qLBdWZkouayxVAYVKLQsIXRipEL<T>(TList<T> P_0)
			{
				if (P_0 != null)
				{
					if (!tLists.TryGetValue(typeof(T), out var value))
					{
						value = new List<object>(3);
						tLists.Add(typeof(T), value);
					}
					if (value.Count < 3)
					{
						ListTools.AddIfUnique(value, P_0);
					}
				}
			}

			public static void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				MLyqbVLCaYJbwqRldWOTKOhtMme = null;
			}

			public static void dLvQQBBPNcDLyfQfBHFGJrYJbsBD(Type P_0)
			{
				if ((object)P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				if (MLyqbVLCaYJbwqRldWOTKOhtMme != null && MLyqbVLCaYJbwqRldWOTKOhtMme.ContainsKey(P_0))
				{
					MLyqbVLCaYJbwqRldWOTKOhtMme.Remove(P_0);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> WGbffMyxRwMRJaYYpbgRACDXbfV;

			private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

			public List<T> list
			{
				get
				{
					if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
					{
						bWnZctiWLhaCryDporialyhjVMP();
					}
					return WGbffMyxRwMRJaYYpbgRACDXbfV;
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
				if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
				{
					qLBdWZkouayxVAYVKLQsIXRipEL();
					jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
				}
			}

			private void qLBdWZkouayxVAYVKLQsIXRipEL()
			{
				if (WGbffMyxRwMRJaYYpbgRACDXbfV != null)
				{
					Return(WGbffMyxRwMRJaYYpbgRACDXbfV);
				}
				WGbffMyxRwMRJaYYpbgRACDXbfV = null;
				UiAAtmaEzFHIRLcDjJJkQPPNiEGI.qLBdWZkouayxVAYVKLQsIXRipEL(this);
			}

			private void kimUjOflJVpEmhbMOCMKfkKSfpV(List<T> P_0)
			{
				WGbffMyxRwMRJaYYpbgRACDXbfV = P_0;
				jgbpvYJovPcfzmcAEJzdxdrBmcm = false;
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in kimUjOflJVpEmhbMOCMKfkKSfpV
				this.kimUjOflJVpEmhbMOCMKfkKSfpV(P_0);
			}

			private static void bWnZctiWLhaCryDporialyhjVMP()
			{
				throw new Exception("The TList has been disposed.");
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return obj.list;
			}
		}

		private const int ESqZuBBdDVBiSoxLwWIQPeoTLmy = 3;

		private const int EKPegjKOMHxCIEHEIrNLGUBgoTdy = 10;

		private static ADictionary<Type, List<IList>> ARMdXdYNQlvKcsZQyQewSfiigSj;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (ARMdXdYNQlvKcsZQyQewSfiigSj == null)
				{
					return ARMdXdYNQlvKcsZQyQewSfiigSj = new ADictionary<Type, List<IList>>();
				}
				return ARMdXdYNQlvKcsZQyQewSfiigSj;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return UiAAtmaEzFHIRLcDjJJkQPPNiEGI.PErbMByiRLpfURxMubXbNOTjLuS(Get<T>(capacity));
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
			ARMdXdYNQlvKcsZQyQewSfiigSj = null;
			UiAAtmaEzFHIRLcDjJJkQPPNiEGI.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}

		public static void Clear(Type listType)
		{
			if ((object)listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			if (ARMdXdYNQlvKcsZQyQewSfiigSj != null && ARMdXdYNQlvKcsZQyQewSfiigSj.ContainsKey(listType))
			{
				ARMdXdYNQlvKcsZQyQewSfiigSj.Remove(listType);
				UiAAtmaEzFHIRLcDjJJkQPPNiEGI.dLvQQBBPNcDLyfQfBHFGJrYJbsBD(listType);
			}
		}
	}
}
