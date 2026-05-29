using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal static class TempListPool
	{
		private static class bibDuWqWRmQgMvZXYnDCMyeHmjn
		{
			private static ADictionary<Type, List<object>> rFXYpfVqIdKFbUWfMIfnOmOhVoZ;

			private static ADictionary<Type, List<object>> tLists => null;

			public static TList<T> ekQcglwEnwkUZhNGPjDNHFwrfTvK<T>(List<T> P_0)
			{
				return null;
			}

			public static void RMufudgtYZcASwtFtdHSCCaoSAic<T>(TList<T> P_0)
			{
			}

			public static void CKSoitBPjLqWpFGpwBNgDbvTrVm()
			{
			}

			public static void CKSoitBPjLqWpFGpwBNgDbvTrVm(Type P_0)
			{
			}
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
		internal interface ITListSetter<T>
		{
			void SetList(List<T> list);
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		internal sealed class TList<T> : IDisposable, ITListSetter<T>
		{
			private List<T> pBSJXwgNlTTyOSmIIhptQeyZcCmj;

			private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

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

			private void RMufudgtYZcASwtFtdHSCCaoSAic()
			{
			}

			private void TjPiwmxUfmALtZOIdCpwxczSCAq(List<T> P_0)
			{
			}

			void ITListSetter<T>.SetList(List<T> P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in TjPiwmxUfmALtZOIdCpwxczSCAq
				this.TjPiwmxUfmALtZOIdCpwxczSCAq(P_0);
			}

			private static void QBSrHbuirQTuiGtXZzWsdYcxswy()
			{
			}

			public static implicit operator List<T>(TList<T> obj)
			{
				return null;
			}
		}

		private const int bMPrixBdxsgFPYGZJYCiLMPZGLJ = 3;

		private const int bQiGYDGOqgdhJLzWlvJjQKuwOuAe = 10;

		private static ADictionary<Type, List<IList>> xllLLTWqwCKXbSDGFWYMEcTyhvW;

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
