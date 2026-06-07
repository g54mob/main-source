using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class SafeAction : SafeDelegate<Action>
	{
		private static Action<object, Action> ikYtRZLMHameTpnFVdyPyuXtvvn;

		private static Action<object, Action> invokeDelegate => null;

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> exceptionHandler)
		{
		}

		private SafeAction(SafeAction source)
		{
		}

		public void Invoke()
		{
		}

		public override object Clone()
		{
			return null;
		}

		private static void GDMQTWYeuNSCHKUowlymUPDMUWs(object P_0, Action P_1)
		{
		}

		public static SafeAction operator +(SafeAction eventList, Action listener)
		{
			return null;
		}

		public static SafeAction operator -(SafeAction eventList, Action listener)
		{
			return null;
		}

		public static implicit operator Action(SafeAction obj)
		{
			return null;
		}

		public static implicit operator SafeAction(Action obj)
		{
			return null;
		}
	}
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
	{
		private T oDicIASdPayYpTCCoHhLbeURrFrc;

		private static Action<object, Action<T>> ikYtRZLMHameTpnFVdyPyuXtvvn;

		private static Action<object, Action<T>> invokeDelegate => null;

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> exceptionHandler)
		{
		}

		protected SafeAction(SafeAction<T> source)
		{
		}

		public void Invoke(T arg0)
		{
		}

		public override object Clone()
		{
			return null;
		}

		private static void GDMQTWYeuNSCHKUowlymUPDMUWs(object P_0, Action<T> P_1)
		{
		}

		public static SafeAction<T> operator +(SafeAction<T> eventList, Action<T> listener)
		{
			return null;
		}

		public static SafeAction<T> operator -(SafeAction<T> eventList, Action<T> listener)
		{
			return null;
		}

		public static implicit operator Action<T>(SafeAction<T> obj)
		{
			return null;
		}

		public static implicit operator SafeAction<T>(Action<T> obj)
		{
			return null;
		}
	}
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class SafeAction<T, T2> : SafeDelegate<Action<T, T2>>
	{
		private T oDicIASdPayYpTCCoHhLbeURrFrc;

		private T2 FtEjLZfeBECbhFPvsJNGEhHnzfH;

		private static Action<object, Action<T, T2>> ikYtRZLMHameTpnFVdyPyuXtvvn;

		private static Action<object, Action<T, T2>> invokeDelegate => null;

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> exceptionHandler)
		{
		}

		protected SafeAction(SafeAction<T, T2> source)
		{
		}

		public void Invoke(T arg0, T2 arg1)
		{
		}

		public override object Clone()
		{
			return null;
		}

		private static void GDMQTWYeuNSCHKUowlymUPDMUWs(object P_0, Action<T, T2> P_1)
		{
		}

		public static SafeAction<T, T2> operator +(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			return null;
		}

		public static SafeAction<T, T2> operator -(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			return null;
		}

		public static implicit operator Action<T, T2>(SafeAction<T, T2> obj)
		{
			return null;
		}

		public static implicit operator SafeAction<T, T2>(Action<T, T2> obj)
		{
			return null;
		}
	}
}
