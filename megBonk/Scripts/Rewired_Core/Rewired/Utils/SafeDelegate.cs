using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> GBOyThQoIjPTXtEZPWAyjurHTsvq;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		internal abstract void Clear();

		public abstract object Clone();
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class bqUgaHQLJmuOTzstpeFuwcCLWQzI
		{
			public readonly T fqhBNjbFPrdJTwZmXLUiPznWckzOA;

			public readonly object pIxiubKyALTzAiwcEyYaMvzLdHwf;

			public readonly object YwTrABROIumGlojyTdAbryUsGyeo;

			public readonly bool ldpSNPWzHvYnBxsQecaDKPKgwhUf;

			public bqUgaHQLJmuOTzstpeFuwcCLWQzI(T P_0)
			{
			}

			public bqUgaHQLJmuOTzstpeFuwcCLWQzI(bqUgaHQLJmuOTzstpeFuwcCLWQzI P_0)
			{
			}

			public bool RUttbrCfKwHYxyauekWKqfYKefug()
			{
				return false;
			}
		}

		private Action<Exception> qfUsPslikDPefdexjqshsFXUxRNn;

		private readonly List<bqUgaHQLJmuOTzstpeFuwcCLWQzI> BZCPwzxLQuDaWLdGUhSSWhxTSJsR;

		private readonly List<bqUgaHQLJmuOTzstpeFuwcCLWQzI> ZschuhHUoKDGcQbEAZJBfUZeObiw;

		internal override int Count => 0;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected SafeDelegate()
		{
		}

		protected SafeDelegate(Action<Exception> P_0)
		{
		}

		protected SafeDelegate(SafeDelegate<T> P_0)
		{
		}

		public void AddDelegate(T @delegate)
		{
		}

		public void RemoveDelegate(T @delegate)
		{
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
		}

		internal override void Clear()
		{
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
		}

		protected T GetCombinedDelegate()
		{
			return null;
		}

		private bool BCMAfLrTfaZmMLkFZQLAbjYWwFxT(T P_0)
		{
			return false;
		}

		private int GgYjHJtVjhhSpFPRWRKVRvDrMtrw(T P_0)
		{
			return 0;
		}

		private static Delegate miGOHPNFhIydUuwwmOIJnnyJTiRv(object P_0, Delegate P_1)
		{
			return null;
		}

		private static Delegate rTeBdEDgpZdSKUiBGNjxGoCJYYFGb(Delegate P_0, Delegate P_1)
		{
			return null;
		}

		private static int jMQPWAthsqKHeYNzyFAlvqDagaUP(Delegate P_0)
		{
			return 0;
		}

		private static List<Delegate> jTYiOSNDBnjcgBasVEiSfsKJlFRi(Delegate P_0)
		{
			return null;
		}
	}
}
