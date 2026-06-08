using System;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T TSedBQYUfMPQIWewxCsmKxLtZHU;

		private bool QkPKNYJZTNeoOcRhvEvLKCIgChkd;

		private static Action<object, Predicate<T>> BueOgWVzEtbtuoGvJZVuGDqrtjV;

		private static Action<object, Predicate<T>> invokeDelegate => noivHTQpdGHiePoAmAVHwawQMzC;

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
			TSedBQYUfMPQIWewxCsmKxLtZHU = arg0;
			try
			{
				Invoke(invokeDelegate);
				return QkPKNYJZTNeoOcRhvEvLKCIgChkd;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				return false;
			}
			finally
			{
				TSedBQYUfMPQIWewxCsmKxLtZHU = default(T);
				QkPKNYJZTNeoOcRhvEvLKCIgChkd = false;
			}
		}

		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		private static void noivHTQpdGHiePoAmAVHwawQMzC(object P_0, Predicate<T> P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (0x1F9A6EB1 ^ 0x1F9A6EB0)
					{
					case 2:
						break;
					case 1:
						return;
					case 3:
						goto end_IL_0003;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			SafePredicate<T> safePredicate = P_0 as SafePredicate<T>;
			if (safePredicate == null)
			{
				return;
			}
			goto IL_003f;
			IL_003f:
			safePredicate.QkPKNYJZTNeoOcRhvEvLKCIgChkd = P_1(safePredicate.TSedBQYUfMPQIWewxCsmKxLtZHU);
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
