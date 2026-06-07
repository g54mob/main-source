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
		private static class WqjpOeQHBFSTDrmLzqtiJnaIDFOs
		{
			private static ADictionary<Type, List<object>> jZmDfRIbRYOUKxIHvNmyaVdEswpYA;

			private static ADictionary<Type, List<object>> pYYaYOOjKohRnXUyHvAhgDqRwZir
			{
				get
				{
					if (jZmDfRIbRYOUKxIHvNmyaVdEswpYA == null)
					{
						return jZmDfRIbRYOUKxIHvNmyaVdEswpYA = new ADictionary<Type, List<object>>();
					}
					return jZmDfRIbRYOUKxIHvNmyaVdEswpYA;
				}
			}

			public static TList<_0001> sJryoxlljHUVwTGcpjTonVaiAhEGA<_0001>(List<_0001> P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("list");
				}
				if (!pYYaYOOjKohRnXUyHvAhgDqRwZir.ContainsKey(typeof(_0001)))
				{
					pYYaYOOjKohRnXUyHvAhgDqRwZir.Add(typeof(_0001), new List<object>(3));
				}
				List<object> list = pYYaYOOjKohRnXUyHvAhgDqRwZir[typeof(_0001)];
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

			public static void rKPFsEiVQodpcTqqKzYwQiDEppOEA<_0001>(TList<_0001> P_0)
			{
				if (P_0 != null)
				{
					if (!pYYaYOOjKohRnXUyHvAhgDqRwZir.TryGetValue(typeof(_0001), out var value))
					{
						value = new List<object>(3);
						pYYaYOOjKohRnXUyHvAhgDqRwZir.Add(typeof(_0001), value);
					}
					if (value.Count < 3)
					{
						ListTools.AddIfUnique(value, P_0);
					}
				}
			}

			public static void TxZnuSvbOUbBhuCyEYbmNaCniOfA()
			{
				jZmDfRIbRYOUKxIHvNmyaVdEswpYA = null;
			}

			public static void lhIysCyXSNKTYrrBrHCsNtfTHMXc(Type P_0)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("listType");
				}
				if (jZmDfRIbRYOUKxIHvNmyaVdEswpYA != null && jZmDfRIbRYOUKxIHvNmyaVdEswpYA.ContainsKey(P_0))
				{
					jZmDfRIbRYOUKxIHvNmyaVdEswpYA.Remove(P_0);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : ITListSetter<T>, IDisposable
		{
			private List<T> sDQRJuRlnROFWhQolPznyRWHjGSB;

			private bool yNTKycfcScFwlpQNRVDeygZtMnoG;

			public List<T> list
			{
				get
				{
					if (yNTKycfcScFwlpQNRVDeygZtMnoG)
					{
						vcmyVQOfOnHkEGihuBQqslwWPVdaA();
					}
					return sDQRJuRlnROFWhQolPznyRWHjGSB;
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
				if (!yNTKycfcScFwlpQNRVDeygZtMnoG)
				{
					CHAnyAutALurWKHSqZoHaVsgRZrL();
					yNTKycfcScFwlpQNRVDeygZtMnoG = true;
				}
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			private void CHAnyAutALurWKHSqZoHaVsgRZrL()
			{
				if (sDQRJuRlnROFWhQolPznyRWHjGSB != null)
				{
					Return(sDQRJuRlnROFWhQolPznyRWHjGSB);
				}
				sDQRJuRlnROFWhQolPznyRWHjGSB = null;
				WqjpOeQHBFSTDrmLzqtiJnaIDFOs.rKPFsEiVQodpcTqqKzYwQiDEppOEA(this);
			}

			private void WrncSulgQReSSUSQPaHvaheQhYnz(List<T> P_0)
			{
				sDQRJuRlnROFWhQolPznyRWHjGSB = P_0;
				yNTKycfcScFwlpQNRVDeygZtMnoG = false;
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in WrncSulgQReSSUSQPaHvaheQhYnz
				this.WrncSulgQReSSUSQPaHvaheQhYnz(P_0);
			}

			private static void vcmyVQOfOnHkEGihuBQqslwWPVdaA()
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

		private const int HBSHlOfAASjGseDjiuUcqJYCWBUlc = 3;

		private const int EyLgqcnqxfkHuQvdsAsIlnSsdNLdA = 10;

		private static ADictionary<Type, List<IList>> UMOjGpKnbuGfpQFZiLHgwnEedibK;

		private static ADictionary<Type, List<IList>> lists
		{
			get
			{
				if (UMOjGpKnbuGfpQFZiLHgwnEedibK == null)
				{
					return UMOjGpKnbuGfpQFZiLHgwnEedibK = new ADictionary<Type, List<IList>>();
				}
				return UMOjGpKnbuGfpQFZiLHgwnEedibK;
			}
		}

		public static TList<T> GetTList<T>()
		{
			return GetTList<T>(0);
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return WqjpOeQHBFSTDrmLzqtiJnaIDFOs.sJryoxlljHUVwTGcpjTonVaiAhEGA(Get<T>(capacity));
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
			UMOjGpKnbuGfpQFZiLHgwnEedibK = null;
			WqjpOeQHBFSTDrmLzqtiJnaIDFOs.TxZnuSvbOUbBhuCyEYbmNaCniOfA();
		}

		public static void Clear(Type listType)
		{
			if (listType == null)
			{
				throw new ArgumentNullException("listType");
			}
			if (UMOjGpKnbuGfpQFZiLHgwnEedibK != null && UMOjGpKnbuGfpQFZiLHgwnEedibK.ContainsKey(listType))
			{
				UMOjGpKnbuGfpQFZiLHgwnEedibK.Remove(listType);
				WqjpOeQHBFSTDrmLzqtiJnaIDFOs.lhIysCyXSNKTYrrBrHCsNtfTHMXc(listType);
			}
		}
	}
}
