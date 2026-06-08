using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction : SafeDelegate<Action>
	{
		private static Action<object, Action> BueOgWVzEtbtuoGvJZVuGDqrtjV;

		private static Action<object, Action> invokeDelegate => noivHTQpdGHiePoAmAVHwawQMzC;

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

		private static void noivHTQpdGHiePoAmAVHwawQMzC(object P_0, Action P_1)
		{
			P_1?.Invoke();
		}

		public static SafeAction operator +(SafeAction eventList, Action listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction();
				goto IL_000a;
			}
			goto IL_0028;
			IL_0028:
			eventList.AddDelegate(listener);
			int num = 2136517267;
			goto IL_000f;
			IL_000a:
			num = 2136517264;
			goto IL_000f;
			IL_000f:
			switch (num ^ 0x7F58AA91)
			{
			case 0:
				break;
			case 1:
				goto IL_0028;
			default:
				return eventList;
			}
			goto IL_000a;
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
			return obj?.GetCombinedDelegate();
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
	{
		private T TSedBQYUfMPQIWewxCsmKxLtZHU;

		private static Action<object, Action<T>> BueOgWVzEtbtuoGvJZVuGDqrtjV;

		private static Action<object, Action<T>> invokeDelegate => noivHTQpdGHiePoAmAVHwawQMzC;

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
			TSedBQYUfMPQIWewxCsmKxLtZHU = arg0;
			try
			{
				Invoke(invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			TSedBQYUfMPQIWewxCsmKxLtZHU = default(T);
		}

		public override object Clone()
		{
			return new SafeAction<T>(this);
		}

		private static void noivHTQpdGHiePoAmAVHwawQMzC(object P_0, Action<T> P_1)
		{
			if (P_1 != null && P_0 is SafeAction<T> safeAction)
			{
				P_1(safeAction.TSedBQYUfMPQIWewxCsmKxLtZHU);
			}
		}

		public static SafeAction<T> operator +(SafeAction<T> eventList, Action<T> listener)
		{
			if (eventList == null)
			{
				goto IL_0003;
			}
			goto IL_0033;
			IL_0003:
			int num = 743578700;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x2C521C4D)
				{
				case 0:
					break;
				case 1:
					eventList = new SafeAction<T>();
					num = 743578702;
					continue;
				case 3:
					goto IL_0033;
				default:
					return eventList;
				}
				break;
			}
			goto IL_0003;
			IL_0033:
			eventList.AddDelegate(listener);
			num = 743578703;
			goto IL_0008;
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
			return obj?.GetCombinedDelegate();
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
		private T TSedBQYUfMPQIWewxCsmKxLtZHU;

		private T2 oOyUFMpOWZPDEWSVucipsMmllol;

		private static Action<object, Action<T, T2>> BueOgWVzEtbtuoGvJZVuGDqrtjV;

		private static Action<object, Action<T, T2>> invokeDelegate => noivHTQpdGHiePoAmAVHwawQMzC;

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
			TSedBQYUfMPQIWewxCsmKxLtZHU = arg0;
			oOyUFMpOWZPDEWSVucipsMmllol = arg1;
			try
			{
				Invoke(invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			TSedBQYUfMPQIWewxCsmKxLtZHU = default(T);
			oOyUFMpOWZPDEWSVucipsMmllol = default(T2);
		}

		public override object Clone()
		{
			return new SafeAction<T, T2>(this);
		}

		private static void noivHTQpdGHiePoAmAVHwawQMzC(object P_0, Action<T, T2> P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				SafeAction<T, T2> safeAction = P_0 as SafeAction<T, T2>;
				int num;
				int num2;
				if (safeAction == null)
				{
					num = -213113649;
					num2 = num;
				}
				else
				{
					num = -213113652;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -213113651)
					{
					case 0:
						goto IL_0004;
					case 3:
						break;
					case 2:
						return;
					default:
						P_1(safeAction.TSedBQYUfMPQIWewxCsmKxLtZHU, safeAction.oOyUFMpOWZPDEWSVucipsMmllol);
						return;
					}
					break;
					IL_0004:
					num = -213113650;
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
			return obj?.GetCombinedDelegate();
		}

		public static implicit operator SafeAction<T, T2>(Action<T, T2> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeAction<T, T2> safeAction = new SafeAction<T, T2>();
			safeAction.AddDelegate(obj);
			return safeAction;
		}
	}
}
