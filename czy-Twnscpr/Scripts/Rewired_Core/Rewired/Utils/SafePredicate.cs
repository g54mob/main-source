using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T oDicIASdPayYpTCCoHhLbeURrFrc;

		private bool dHbEuRERMOrzhzINxGQmegtmHvOg;

		private static Action<object, Predicate<T>> ikYtRZLMHameTpnFVdyPyuXtvvn;

		private static Action<object, Predicate<T>> invokeDelegate => null;

		public SafePredicate()
		{
		}

		public SafePredicate(Action<Exception> exceptionHandler)
		{
		}

		protected SafePredicate(SafePredicate<T> source)
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

		private static void GDMQTWYeuNSCHKUowlymUPDMUWs(object P_0, Predicate<T> P_1)
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
