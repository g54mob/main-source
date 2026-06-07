using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T mXGSIUaHrvnMVnQVxkdxIQLMtEk;

		private bool llPkaNpxmTvlZPKOwGNYAfunclN;

		private static Action<object, Predicate<T>> oqaLTPhZpfixnNfWQutfMiAseLi;

		private static Action<object, Predicate<T>> invokeDelegate
		{
			get
			{
				return WnkfGGuhOIzQfspnxnpIgyMVtLb;
			}
		}

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
			mXGSIUaHrvnMVnQVxkdxIQLMtEk = arg0;
			try
			{
				Invoke(invokeDelegate);
				return llPkaNpxmTvlZPKOwGNYAfunclN;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				return false;
			}
			finally
			{
				mXGSIUaHrvnMVnQVxkdxIQLMtEk = default(T);
				llPkaNpxmTvlZPKOwGNYAfunclN = false;
			}
		}

		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		private static void WnkfGGuhOIzQfspnxnpIgyMVtLb(object P_0, Predicate<T> P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				SafePredicate<T> safePredicate = P_0 as SafePredicate<T>;
				int num = 2085456690;
				while (true)
				{
					switch (num ^ 0x7C4D8B31)
					{
					case 4:
						num = 2085456688;
						continue;
					case 1:
						break;
					case 3:
					{
						int num2;
						if (safePredicate != null)
						{
							num = 2085456691;
							num2 = num;
						}
						else
						{
							num = 2085456689;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					default:
						safePredicate.llPkaNpxmTvlZPKOwGNYAfunclN = P_1(safePredicate.mXGSIUaHrvnMVnQVxkdxIQLMtEk);
						return;
					}
					break;
				}
			}
		}

		public static SafePredicate<T> operator +(SafePredicate<T> eventList, Predicate<T> predicate)
		{
			if (eventList == null)
			{
				while (true)
				{
					int num = -1366427795;
					while (true)
					{
						switch (num ^ -1366427793)
						{
						case 0:
							break;
						case 2:
							eventList = new SafePredicate<T>();
							num = -1366427794;
							continue;
						default:
							goto end_IL_0003;
						}
						break;
					}
					continue;
					end_IL_0003:
					break;
				}
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
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
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
