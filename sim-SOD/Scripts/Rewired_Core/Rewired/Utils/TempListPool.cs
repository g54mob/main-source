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
		private static class cpAhAhAqhQznEhsNKjmkDqFuzzn
		{
			private static ADictionary<Type, List<object>> sBkqiEnQkHFDrcEpOPfRVszGCPBP;

			private static ADictionary<Type, List<object>> tLists => null;

			public static TList<T> dsnJEQIUDCQBFjiYHOqphHRQCLrh<T>(List<T> P_0)
			{
				return null;
			}

			public static void CTGGwSmldVGUmDqfimzyHUXSyW<T>(TList<T> P_0)
			{
			}

			public static void DcbUeIfyTfvTrRQxceAMfGCsJNs()
			{
			}

			public static void DcbUeIfyTfvTrRQxceAMfGCsJNs(Type P_0)
			{
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> ghjvRRSxZjjKYYSVAMGRedLeMik;

			private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

			public List<T> list => null;

			public static TList<T> Create()
			{
				return null;
			}

			private TList()
			{
			}

			public void Dispose()
			{
			}

			private void CTGGwSmldVGUmDqfimzyHUXSyW()
			{
			}

			private void GEcMGRPxRCxNtJJAlDdAZTQjMSq(List<T> P_0)
			{
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GEcMGRPxRCxNtJJAlDdAZTQjMSq
				this.GEcMGRPxRCxNtJJAlDdAZTQjMSq(P_0);
			}

			private static void XAdGNeHEKetYqKKnBeQiGRdFYoax()
			{
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return null;
			}
		}

		private const int cUaKPCbVNWOYBYJXXSrYdIicETV = 3;

		private const int mRuwimtSUsMFpGXroDLiLUNuBI = 10;

		private static ADictionary<Type, List<IList>> qhIsbyoFImwLjYjUDTbawJiJlpO;

		private static ADictionary<Type, List<IList>> lists => null;

		public static TList<T> GetTList<T>()
		{
			return null;
		}

		public static TList<T> GetTList<T>(int capacity)
		{
			return null;
		}

		public static void ReturnTList<T>(TList<T> tList)
		{
		}

		public static List<T> Get<T>()
		{
			return null;
		}

		public static List<T> Get<T>(int capacity)
		{
			return null;
		}

		public static void Return<T>(List<T> list)
		{
		}

		public static void Return<T>(List<T> list1, List<T> list2)
		{
		}

		public static void Return<T>(List<T> list1, List<T> list2, List<T> list3)
		{
		}

		public static void Clear()
		{
		}

		public static void Clear(Type listType)
		{
		}
	}
}
