using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T XDnYQEdOYWyMGtYhWaCixrExGpEA;

		private bool ZXRNCxndQEHQlCSYgadpKcoQxYEM;

		private static Action<object, Predicate<T>> nEWnMdSvpFQIKtROApnwxCGmhZOx;

		private static Action<object, Predicate<T>> invokeDelegate => WdlfoUVOldEqdnNolFHmmTPfjURh;

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
			XDnYQEdOYWyMGtYhWaCixrExGpEA = arg0;
			try
			{
				Invoke(invokeDelegate);
				return ZXRNCxndQEHQlCSYgadpKcoQxYEM;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				return false;
			}
			finally
			{
				XDnYQEdOYWyMGtYhWaCixrExGpEA = default(T);
				ZXRNCxndQEHQlCSYgadpKcoQxYEM = false;
			}
		}

		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		private static void WdlfoUVOldEqdnNolFHmmTPfjURh(object P_0, Predicate<T> P_1)
		{
			if (P_1 != null && P_0 is SafePredicate<T> safePredicate)
			{
				safePredicate.ZXRNCxndQEHQlCSYgadpKcoQxYEM = P_1(safePredicate.XDnYQEdOYWyMGtYhWaCixrExGpEA);
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
