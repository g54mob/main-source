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
		private static class GUGpnwyaASMHpDkoNMNXZXjUwvNv
		{
			private static ADictionary<Type, List<object>> xIPDGHkLQBiGyiswdBYBbHmVCAqBB;

			private static ADictionary<Type, List<object>> tpbFxEirHdBPXglTzbyUcabcBtxrb => null;

			public static TList<_0001> gcYVRfBsiOlJUnKFRbpNvzziuFHO<_0001>(List<_0001> P_0)
			{
				return null;
			}

			public static void bdodVOGtTrarKnKNacsTYyGWzXDn<_0001>(TList<_0001> P_0)
			{
			}

			public static void FdWAAkTgSDhobApJGmCEPduQUSHD()
			{
			}

			public static void zsdHrSWASCUyaVUGXlTlPmfLvRTC(Type P_0)
			{
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal sealed class TList<T> : ITListSetter<T>, IDisposable
		{
			private List<T> eUxoBtdgLIShSZzaJtYkiQLvZFYA;

			private bool wQujysFjPtJyNTnQtnNFeOJruSfC;

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

			private void UCtuXKOmBElnumJtQiUicUzwhgsJ()
			{
			}

			private void WLGFSmJbXUUxgugnredIknbIRmeS(List<T> P_0)
			{
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in WLGFSmJbXUUxgugnredIknbIRmeS
				this.WLGFSmJbXUUxgugnredIknbIRmeS(P_0);
			}

			private static void fFNVsGcMLebksBCKIxoJdfrGkpueA()
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

		private const int FHfAIGekFLSUAbdEjYaXcXZfCvPcc = 3;

		private const int GlmgPmPjwcrHGmYCASYxjxXmvqAk = 10;

		private static ADictionary<Type, List<IList>> MheCfBaixWAXWwiEPbROgXsKZwZ;

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
