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
		private static class XvTrxazAiJqVxbevybObJrlwfLAK
		{
			private static ADictionary<Type, List<object>> qAMCLvOyHMbhyMjpuganPmfaCzpD;

			private static ADictionary<Type, List<object>> safAPpxXuqFiZUxYYkzypttduvb => null;

			public static TList<_0001> dQLNHlMDADwKUTESqLFjvBdMKXAM<_0001>(List<_0001> P_0)
			{
				return null;
			}

			public static void iPvLGEclAkEkIuSWJSbRcQhsHgEe<_0001>(TList<_0001> P_0)
			{
			}

			public static void AQZDCaAAIInSdHgmrmEcdLzkiIQFc()
			{
			}

			public static void oruSFCNJyBftukjBoqJVgXiAdxQDc(Type P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal sealed class TList<T> : ITListSetter<T>, IDisposable
		{
			private List<T> xHqCoNgaEVmlpbxukxFsmuUfjDIdb;

			private bool hzbufaABHmcgPItiYRBtuxARGwuy;

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

			private void TQiFzGVajNAluKFehasUyJzQzyjE()
			{
			}

			private void RHPJBmUKtVahcEWwYZTowBbwEmlU(List<T> P_0)
			{
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in RHPJBmUKtVahcEWwYZTowBbwEmlU
				this.RHPJBmUKtVahcEWwYZTowBbwEmlU(P_0);
			}

			private static void oWGcHIljfxRCmkWTzMLrjnxypInG()
			{
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		private const int WKyKGKlvHEbxULZLbWrvBHemhFUe = 3;

		private const int FbzcFwOWKhGsKGRFvorDjFZAjSLm = 10;

		private static ADictionary<Type, List<IList>> ZAmHMlelUaXnDoAtnKXroqRSiVrVA;

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
