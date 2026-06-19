using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafeFunc<T, TResult> : SafeDelegate<Func<T, TResult>>
	{
		private T lUHABudABhOgMImiZGhEymXEMwESA;

		private TResult dFqhohiLbdIinoSOUBzFcrXJTiFec;

		private static Action<object, Func<T, TResult>> xFUsLPzoOJIdKXyTTFqUMBiIijSfA;

		private static Action<object, Func<T, TResult>> invokeDelegate => fCZwSMXYxAsGuYsDtvYIZUEzKeYi;

		public SafeFunc()
		{
		}

		public SafeFunc(Action<Exception> P_0)
			: base(P_0)
		{
		}

		protected SafeFunc(SafeFunc<T, TResult> P_0)
			: base((SafeDelegate<Func<T, TResult>>)P_0)
		{
		}

		public TResult Invoke(T arg0)
		{
			lUHABudABhOgMImiZGhEymXEMwESA = arg0;
			try
			{
				Invoke(invokeDelegate);
				return dFqhohiLbdIinoSOUBzFcrXJTiFec;
			}
			catch
			{
				Logger.LogError("Error invoking SafeFunc base class.");
				return default(TResult);
			}
			finally
			{
				lUHABudABhOgMImiZGhEymXEMwESA = default(T);
				dFqhohiLbdIinoSOUBzFcrXJTiFec = default(TResult);
			}
		}

		public override object Clone()
		{
			return new SafeFunc<T, TResult>(this);
		}

		private static void fCZwSMXYxAsGuYsDtvYIZUEzKeYi(object P_0, Func<T, TResult> P_1)
		{
			if (P_1 != null && P_0 is SafeFunc<T, TResult> safeFunc)
			{
				safeFunc.dFqhohiLbdIinoSOUBzFcrXJTiFec = P_1(safeFunc.lUHABudABhOgMImiZGhEymXEMwESA);
			}
		}

		public static SafeFunc<T, TResult> operator +(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			if (eventList == null)
			{
				eventList = new SafeFunc<T, TResult>();
			}
			eventList.AddDelegate(func);
			return eventList;
		}

		public static SafeFunc<T, TResult> operator -(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(func);
			return eventList;
		}

		public static implicit operator Func<T, TResult>(SafeFunc<T, TResult> obj)
		{
			return obj?.GetCombinedDelegate();
		}

		public static implicit operator SafeFunc<T, TResult>(Func<T, TResult> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeFunc<T, TResult> safeFunc = new SafeFunc<T, TResult>();
			safeFunc.AddDelegate(obj);
			return safeFunc;
		}
	}
}
