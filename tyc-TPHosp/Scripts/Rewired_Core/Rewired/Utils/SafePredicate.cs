using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T BeRykoKbnRgpslCIPabtwVrJXcM;

		private bool UcAJCtGRirMWibBPAKSAGqCHuYjx;

		private static Action<object, Predicate<T>> XJrypfBzlTPJARAReZgjorcrvIU;

		private static Action<object, Predicate<T>> invokeDelegate => pIncveKGAgbWQiiPNjWYIyXClBY;

		public SafePredicate()
		{
		}

		public SafePredicate(Action<Exception> exceptionHandler)
			: base(exceptionHandler)
		{
		}

		protected SafePredicate(SafePredicate<T> source)
			: base((SafeDelegate<Predicate<T>>)source)
		{
		}

		public bool Invoke(T arg0)
		{
			BeRykoKbnRgpslCIPabtwVrJXcM = arg0;
			try
			{
				Invoke(invokeDelegate);
				return UcAJCtGRirMWibBPAKSAGqCHuYjx;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				return false;
			}
			finally
			{
				BeRykoKbnRgpslCIPabtwVrJXcM = default(T);
				UcAJCtGRirMWibBPAKSAGqCHuYjx = false;
			}
		}

		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		private static void pIncveKGAgbWQiiPNjWYIyXClBY(object P_0, Predicate<T> P_1)
		{
			if (P_1 != null && P_0 is SafePredicate<T> safePredicate)
			{
				safePredicate.UcAJCtGRirMWibBPAKSAGqCHuYjx = P_1(safePredicate.BeRykoKbnRgpslCIPabtwVrJXcM);
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
