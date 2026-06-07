using System;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T NMhsbAEbUzFBfNCevyvyHbKJASKbA;

		private bool HrIxpGoWbBnAwZwqCuXmBFZBQbaA;

		private static Action<object, Predicate<T>> dichylipniIxxvPoCFuUFZvErVlGc;

		private static Action<object, Predicate<T>> invokeDelegate => null;

		public SafePredicate()
		{
		}

		public SafePredicate(Action<Exception> P_0)
		{
		}

		protected SafePredicate(SafePredicate<T> P_0)
		{
		}

		public bool Invoke(T arg0)
		{
			return false;
		}

		public override object Clone()
		{
			return null;
		}

		private static void YFTHbEivUUjLWDAUxWTGSevyxJeD(object P_0, Predicate<T> P_1)
		{
		}

		public static SafePredicate<T> operator +(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			return null;
		}

		public static SafePredicate<T> operator -(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			return null;
		}

		public static implicit operator Predicate<T>(SafePredicate<T> obj)
		{
			return null;
		}

		public static implicit operator SafePredicate<T>(Predicate<T> obj)
		{
			return null;
		}
	}
}
