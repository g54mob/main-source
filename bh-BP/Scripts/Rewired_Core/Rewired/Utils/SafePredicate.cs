using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T TMNIAnXMibFpEwJmdezWbCqccrwdA;

		private bool RkZTTOLhwzZZhBBmyjwliAvknhHZ;

		private static Action<object, Predicate<T>> jeWOmOagRiLUWqEyKaRwftJIoxVh;

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

		private static void OJzzxdnbTOxXvoSQrrIgcgCHDAShA(object P_0, Predicate<T> P_1)
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
