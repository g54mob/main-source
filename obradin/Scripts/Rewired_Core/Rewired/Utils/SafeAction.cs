using System;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SafeAction : SafeDelegate<Action>
	{
		private static Action<object, Action> JqkKvONojrNrQhtXccOtrbSsnZb;

		private static Action<object, Action> invokeDelegate
		{
			get
			{
				return bpepNPWIUMvlIWByBwlQNAILiEgd;
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

		private static void bpepNPWIUMvlIWByBwlQNAILiEgd(object P_0, Action P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (0x24385BBB ^ 0x24385BBA)
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
				while (true)
				{
					int num = 944563134;
					while (true)
					{
						switch (num ^ 0x384CE3BC)
						{
						case 0:
							break;
						case 2:
							eventList = new SafeAction();
							num = 944563133;
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T> : SafeDelegate<Action<T>>
	{
		private T JlMCBZeMbvoncHXCRldnqnFCoRnV;

		private static Action<object, Action<T>> JqkKvONojrNrQhtXccOtrbSsnZb;

		private static Action<object, Action<T>> invokeDelegate
		{
			get
			{
				return bpepNPWIUMvlIWByBwlQNAILiEgd;
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
			JlMCBZeMbvoncHXCRldnqnFCoRnV = arg0;
			try
			{
				Invoke(invokeDelegate);
			}
			catch
			{
				while (true)
				{
					IL_0015:
					int num = 384702789;
					while (true)
					{
						switch (num ^ 0x16EE1944)
						{
						case 2:
							break;
						default:
							goto end_IL_001a;
						case 1:
							goto IL_0033;
						case 0:
							goto end_IL_001a;
						}
						goto IL_0015;
						IL_0033:
						Logger.LogError("Error invoking SafeAction base class.");
						num = 384702788;
						continue;
						end_IL_001a:
						break;
					}
					break;
				}
			}
			JlMCBZeMbvoncHXCRldnqnFCoRnV = default(T);
		}

		public override object Clone()
		{
			return new SafeAction<T>(this);
		}

		private static void bpepNPWIUMvlIWByBwlQNAILiEgd(object P_0, Action<T> P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (-1210397850 ^ -1210397851)
					{
					case 0:
						break;
					case 3:
						return;
					case 2:
						goto end_IL_0003;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			SafeAction<T> safeAction = P_0 as SafeAction<T>;
			if (safeAction == null)
			{
				return;
			}
			goto IL_003f;
			IL_003f:
			P_1(safeAction.JlMCBZeMbvoncHXCRldnqnFCoRnV);
		}

		public static SafeAction<T> operator +(SafeAction<T> eventList, Action<T> listener)
		{
			if (eventList == null)
			{
				eventList = new SafeAction<T>();
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class SafeAction<T, T2> : SafeDelegate<Action<T, T2>>
	{
		private T JlMCBZeMbvoncHXCRldnqnFCoRnV;

		private T2 askLmAnqrVbdmTivVQZiZpCimnN;

		private static Action<object, Action<T, T2>> JqkKvONojrNrQhtXccOtrbSsnZb;

		private static Action<object, Action<T, T2>> invokeDelegate
		{
			get
			{
				return bpepNPWIUMvlIWByBwlQNAILiEgd;
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
			JlMCBZeMbvoncHXCRldnqnFCoRnV = arg0;
			askLmAnqrVbdmTivVQZiZpCimnN = arg1;
			try
			{
				Invoke(invokeDelegate);
			}
			catch
			{
				Logger.LogError("Error invoking SafeAction base class.");
			}
			JlMCBZeMbvoncHXCRldnqnFCoRnV = default(T);
			askLmAnqrVbdmTivVQZiZpCimnN = default(T2);
		}

		public override object Clone()
		{
			return new SafeAction<T, T2>(this);
		}

		private static void bpepNPWIUMvlIWByBwlQNAILiEgd(object P_0, Action<T, T2> P_1)
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
					num = -1679727658;
					num2 = num;
				}
				else
				{
					num = -1679727660;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1679727660)
					{
					case 3:
						goto IL_0004;
					case 1:
						break;
					case 2:
						return;
					default:
						P_1(safeAction.JlMCBZeMbvoncHXCRldnqnFCoRnV, safeAction.askLmAnqrVbdmTivVQZiZpCimnN);
						return;
					}
					break;
					IL_0004:
					num = -1679727659;
				}
			}
		}

		public static SafeAction<T, T2> operator +(SafeAction<T, T2> eventList, Action<T, T2> listener)
		{
			if (eventList == null)
			{
				while (true)
				{
					int num = 629917072;
					while (true)
					{
						switch (num ^ 0x258BC591)
						{
						case 2:
							break;
						case 1:
							eventList = new SafeAction<T, T2>();
							num = 629917073;
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
				return null;
			}
			SafeAction<T, T2> safeAction = new SafeAction<T, T2>();
			safeAction.AddDelegate(obj);
			return safeAction;
		}
	}
}
