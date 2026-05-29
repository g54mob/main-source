using System;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SafeAction : SafeDelegate<Action>
	{
		private static Action<object, Action> oqaLTPhZpfixnNfWQutfMiAseLi;

		private static Action<object, Action> invokeDelegate
		{
			get
			{
				return WnkfGGuhOIzQfspnxnpIgyMVtLb;
			}
		}

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> exceptionHandler)
			: base(exceptionHandler)
		{
		}

		private SafeAction(SafeAction source)
			: base((SafeDelegate<Action>)source)
		{
		}

		public void Invoke()
		{
			try
			{
				Invoke(invokeDelegate);
			}
			catch (Exception ex)
			{
				Logger.LogError("Error invoking SafeAction base class.\n" + ex);
			}
		}

		public override object Clone()
		{
			return new SafeAction(this);
		}

		private static void WnkfGGuhOIzQfspnxnpIgyMVtLb(object P_0, Action P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (-2099418736 ^ -2099418735)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			P_1();
		}

		public static SafeAction operator +(SafeAction eventList, Action listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction();
			}
			eventList.AddDelegate(listener);
			return eventList;
		}

		public static SafeAction operator -(SafeAction eventList, Action listener)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(listener);
			return eventList;
		}

		public static implicit operator Action(SafeAction obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		public static implicit operator SafeAction(Action obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeAction safeAction = new SafeAction();
			safeAction.AddDelegate(obj);
			return safeAction;
		}
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
	{
		private T mXGSIUaHrvnMVnQVxkdxIQLMtEk;

		private static Action<object, Action<T>> oqaLTPhZpfixnNfWQutfMiAseLi;

		private static Action<object, Action<T>> invokeDelegate
		{
			get
			{
				return WnkfGGuhOIzQfspnxnpIgyMVtLb;
			}
		}

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> exceptionHandler)
			: base(exceptionHandler)
		{
		}

		protected SafeAction(SafeAction<T> source)
			: base((SafeDelegate<Action<T>>)source)
		{
		}

		public void Invoke(T arg0)
		{
			mXGSIUaHrvnMVnQVxkdxIQLMtEk = arg0;
			try
			{
				Invoke(invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			mXGSIUaHrvnMVnQVxkdxIQLMtEk = default(T);
		}

		public override object Clone()
		{
			return new SafeAction<T>(this);
		}

		private static void WnkfGGuhOIzQfspnxnpIgyMVtLb(object P_0, Action<T> P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				SafeAction<T> safeAction = P_0 as SafeAction<T>;
				if (safeAction == null)
				{
					break;
				}
				while (true)
				{
					IL_0038:
					P_1(safeAction.mXGSIUaHrvnMVnQVxkdxIQLMtEk);
					int num = 1739531455;
					while (true)
					{
						switch (num ^ 0x67AF24BE)
						{
						case 0:
							num = 1739531453;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							goto IL_0038;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		public static SafeAction<T> operator +(SafeAction<T> eventList, Action<T> listener)
		{
			if (eventList == null)
			{
				while (true)
				{
					int num = -1745565471;
					while (true)
					{
						switch (num ^ -1745565469)
						{
						case 0:
							break;
						case 2:
							eventList = new SafeAction<T>();
							num = -1745565470;
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
			eventList.AddDelegate(listener);
			return eventList;
		}

		public static SafeAction<T> operator -(SafeAction<T> eventList, Action<T> listener)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(listener);
			return eventList;
		}

		public static implicit operator Action<T>(SafeAction<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		public static implicit operator SafeAction<T>(Action<T> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeAction<T> safeAction = new SafeAction<T>();
			safeAction.AddDelegate(obj);
			return safeAction;
		}
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SafeAction<T, T2> : SafeDelegate<Action<T, T2>>
	{
		private T mXGSIUaHrvnMVnQVxkdxIQLMtEk;

		private T2 RNmGhXRhdHFIVhAqdUVekKKkmaE;

		private static Action<object, Action<T, T2>> oqaLTPhZpfixnNfWQutfMiAseLi;

		private static Action<object, Action<T, T2>> invokeDelegate
		{
			get
			{
				return WnkfGGuhOIzQfspnxnpIgyMVtLb;
			}
		}

		public SafeAction()
		{
		}

		public SafeAction(Action<Exception> exceptionHandler)
			: base(exceptionHandler)
		{
		}

		protected SafeAction(SafeAction<T, T2> source)
			: base((SafeDelegate<Action<T, T2>>)source)
		{
		}

		public void Invoke(T arg0, T2 arg1)
		{
			mXGSIUaHrvnMVnQVxkdxIQLMtEk = arg0;
			RNmGhXRhdHFIVhAqdUVekKKkmaE = arg1;
			try
			{
				Invoke(invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			mXGSIUaHrvnMVnQVxkdxIQLMtEk = default(T);
			RNmGhXRhdHFIVhAqdUVekKKkmaE = default(T2);
		}

		public override object Clone()
		{
			return new SafeAction<T, T2>(this);
		}

		private static void WnkfGGuhOIzQfspnxnpIgyMVtLb(object P_0, Action<T, T2> P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				SafeAction<T, T2> safeAction = P_0 as SafeAction<T, T2>;
				int num = -660421660;
				while (true)
				{
					switch (num ^ -660421659)
					{
					case 0:
						goto IL_0004;
					case 3:
						break;
					case 1:
						if (safeAction == null)
						{
							return;
						}
						goto default;
					default:
						P_1(safeAction.mXGSIUaHrvnMVnQVxkdxIQLMtEk, safeAction.RNmGhXRhdHFIVhAqdUVekKKkmaE);
						return;
					}
					break;
					IL_0004:
					num = -660421658;
				}
			}
		}

		public static SafeAction<T, T2> operator +(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction<T, T2>();
			}
			eventList.AddDelegate(listener);
			return eventList;
		}

		public static SafeAction<T, T2> operator -(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(listener);
			return eventList;
		}

		public static implicit operator Action<T, T2>(SafeAction<T, T2> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		public static implicit operator SafeAction<T, T2>(Action<T, T2> obj)
		{
			if (obj == null)
			{
				goto IL_0003;
			}
			SafeAction<T, T2> safeAction = new SafeAction<T, T2>();
			safeAction.AddDelegate(obj);
			int num = 987457082;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x3ADB663B)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return safeAction;
			}
			goto IL_0003;
			IL_0003:
			num = 987457081;
			goto IL_0008;
		}
	}
}
