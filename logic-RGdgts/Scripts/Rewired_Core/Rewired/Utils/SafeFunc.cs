using System;

namespace Rewired.Utils
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class SafeFunc<T, TResult> : SafeDelegate<Func<T, TResult>>
	{
		private T hbLihcaqzyiPPYHibtwglUIvpwkXA;

		private TResult okYNObtfgUHsThjzgGFNjGxALEPgA;

		private static Action<object, Func<T, TResult>> paxalbbuvifbrduxOpNoQoZPYCof;

		private static Action<object, Func<T, TResult>> invokeDelegate => null;

		public SafeFunc()
		{
		}

		public SafeFunc(Action<Exception> P_0)
		{
		}

		protected SafeFunc(SafeFunc<T, TResult> P_0)
		{
		}

		public TResult Invoke(T arg0)
		{
			return default(TResult);
		}

		public override object Clone()
		{
			return null;
		}

		private static void NZnspyinGFmRpItAdHqFcoBaglpEA(object P_0, Func<T, TResult> P_1)
		{
		}

		public static SafeFunc<T, TResult> operator +(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			return null;
		}

		public static SafeFunc<T, TResult> operator -(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			return null;
		}

		public static implicit operator Func<T, TResult>(SafeFunc<T, TResult> obj)
		{
			return null;
		}

		public static implicit operator SafeFunc<T, TResult>(Func<T, TResult> obj)
		{
			return null;
		}
	}
}
