using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction : SafeDelegate<Action>
	{
		private static Action<object, Action> nFZEjgzQaBYUQPEgUdjkaXIFgBeD;

		private static Action<object, Action> invokeDelegate => null;

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> P_0)
		{
		}

		private SafeAction(SafeAction P_0)
		{
		}

		public void Invoke()
		{
		}

		public override object Clone()
		{
			return null;
		}

		private static void TuaTPooxlDAXZvGuVPJdWFCFPNYi(object P_0, Action P_1)
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
	{
		private T qYueUYeJOpvMCDpBgHKvYbmqfIFbb;

		private static Action<object, Action<T>> IwAtXfiDzrvhbzGFlzFPmJwCFlHR;

		private static Action<object, Action<T>> invokeDelegate => null;

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> P_0)
		{
		}

		protected SafeAction(SafeAction<T> P_0)
		{
		}

		public void Invoke(T arg0)
		{
		}

		public override object Clone()
		{
			return null;
		}

		private static void IJlDrVfZUBdBCtNzqZypucGImRLFA(object P_0, Action<T> P_1)
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T, T2> : SafeDelegate<Action<T, T2>>
	{
		private T eatuxFZUneiIgEhUytDQppdTWeUL;

		private T2 XYvoLochKkdedMRocHlHcVJjjRJP;

		private static Action<object, Action<T, T2>> GkvMEojzuffqKAPAkbJXxwWsKdOd;

		private static Action<object, Action<T, T2>> invokeDelegate => null;

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> P_0)
		{
		}

		protected SafeAction(SafeAction<T, T2> P_0)
		{
		}

		public void Invoke(T arg0, T2 arg1)
		{
		}

		public override object Clone()
		{
			return null;
		}

		private static void pZBwXlMOFMTnODlobCaEmxdaaZHt(object P_0, Action<T, T2> P_1)
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
