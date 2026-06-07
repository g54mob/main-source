using System;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T LTMLCSyTDiDWDvgNZPXRXOTDyDLL;

		private bool RrQGtvaDjqnkoWTSGWBauCRFqOsd;

		private static Action<object, Predicate<T>> zbZeXdhXidZdJvnVooCpoLspSzsqA;

		private static Action<object, Predicate<T>> invokeDelegate => OqHsEvEgHQbcHntJbwdmMvuENlMA;

		public SafePredicate()
		{
		}

		public SafePredicate(Action<Exception> P_0)
			: base(P_0)
		{
		}

		protected SafePredicate(SafePredicate<T> P_0)
			: base((SafeDelegate<Predicate<T>>)P_0)
		{
		}

		public bool Invoke(T arg0)
		{
			LTMLCSyTDiDWDvgNZPXRXOTDyDLL = arg0;
			try
			{
				Invoke(invokeDelegate);
				return RrQGtvaDjqnkoWTSGWBauCRFqOsd;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				return false;
			}
			finally
			{
				LTMLCSyTDiDWDvgNZPXRXOTDyDLL = default(T);
				RrQGtvaDjqnkoWTSGWBauCRFqOsd = false;
			}
		}

		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		private static void OqHsEvEgHQbcHntJbwdmMvuENlMA(object P_0, Predicate<T> P_1)
		{
			if (P_1 != null && P_0 is SafePredicate<T> safePredicate)
			{
				safePredicate.RrQGtvaDjqnkoWTSGWBauCRFqOsd = P_1(safePredicate.LTMLCSyTDiDWDvgNZPXRXOTDyDLL);
			}
		}

		public static SafePredicate<T> operator +(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			if (eventList == null)
			{
				eventList = new SafePredicate<T>();
			}
			eventList.AddDelegate(predicate);
			return eventList;
		}

		public static SafePredicate<T> operator -(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(predicate);
			return eventList;
		}

		public static implicit operator Predicate<T>(SafePredicate<T> obj)
		{
			return obj?.GetCombinedDelegate();
		}

		public static implicit operator SafePredicate<T>(Predicate<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafePredicate<T> safePredicate = new SafePredicate<T>();
			safePredicate.AddDelegate(obj);
			return safePredicate;
		}
	}
}
