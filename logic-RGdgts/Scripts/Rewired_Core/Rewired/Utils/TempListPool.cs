using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal static class TempListPool
	{
		private static class oeYjZccYbqTjyprxVmYhGgalkWmJA
		{
			private static ADictionary<Type, List<object>> yocutFfzunDtXGePTdNOiVONVuAp;

			private static ADictionary<Type, List<object>> quadIhoqhhHTeiVFZTApHHAhaUfv => null;

			public static TList<_0001> xhtcFTAIFkbVrsngWfYqcfcFHwyJc<_0001>(List<_0001> P_0)
			{
				return null;
			}

			public static void KQXBUVQVyDLesmXxgIlxmsmKfXnj<_0001>(TList<_0001> P_0)
			{
			}

			public static void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
			}

			public static void HnrFpPpHGPbrJRZcbYcTrFvnwjvi(Type P_0)
			{
			}
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> yStgeWABMBrpmQklPqcEgwUnhfhE;

			private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

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

			private void KQXBUVQVyDLesmXxgIlxmsmKfXnj()
			{
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
			}

			private static void ZkveAxWjMIIKKYBLUZsbPOSRRDho()
			{
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return null;
			}
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		private const int wJqCYBjmZceMjGtlWbFJenHrDmEjb = 3;

		private const int uuHAdvogYaSijhIimAOKjkyQtBDJA = 10;

		private static ADictionary<Type, List<IList>> yvMtataMGIZDTSTqKcXdynNUCWVv;

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
