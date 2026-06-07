using System;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SafePredicate<T> : SafeDelegate<Predicate<T>>
	{
		private T JlMCBZeMbvoncHXCRldnqnFCoRnV;

		private bool WUVarGVZeThYydwDSFAMxXirlbW;

		private static Action<object, Predicate<T>> JqkKvONojrNrQhtXccOtrbSsnZb;

		private static Action<object, Predicate<T>> invokeDelegate
		{
			get
			{
				return bpepNPWIUMvlIWByBwlQNAILiEgd;
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
			JlMCBZeMbvoncHXCRldnqnFCoRnV = arg0;
			try
			{
				Invoke(invokeDelegate);
				return WUVarGVZeThYydwDSFAMxXirlbW;
			}
			catch
			{
				Logger.LogError("Error invoking SafeDelegate base class.");
				return false;
			}
			finally
			{
				JlMCBZeMbvoncHXCRldnqnFCoRnV = default(T);
				while (true)
				{
					IL_0036:
					int num = -403646227;
					while (true)
					{
						switch (num ^ -403646228)
						{
						case 2:
							break;
						default:
							goto end_IL_003b;
						case 1:
							goto IL_0054;
						case 0:
							goto end_IL_003b;
						}
						goto IL_0036;
						IL_0054:
						WUVarGVZeThYydwDSFAMxXirlbW = false;
						num = -403646228;
						continue;
						end_IL_003b:
						break;
					}
					break;
				}
			}
		}

		public override object Clone()
		{
			return new SafePredicate<T>(this);
		}

		private static void bpepNPWIUMvlIWByBwlQNAILiEgd(object P_0, Predicate<T> P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				SafePredicate<T> safePredicate = P_0 as SafePredicate<T>;
				int num = 593154393;
				while (true)
				{
					switch (num ^ 0x235AD159)
					{
					case 2:
						num = 593154392;
						continue;
					case 4:
						return;
					case 0:
					{
						int num2;
						if (safePredicate == null)
						{
							num = 593154397;
							num2 = num;
						}
						else
						{
							num = 593154394;
							num2 = num;
						}
						continue;
					}
					case 1:
						break;
					default:
						safePredicate.WUVarGVZeThYydwDSFAMxXirlbW = P_1(safePredicate.JlMCBZeMbvoncHXCRldnqnFCoRnV);
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
			while (true)
			{
				int num = 743603351;
				while (true)
				{
					switch (num ^ 0x2C527C96)
					{
					case 0:
						break;
					case 1:
						goto IL_0029;
					default:
						return safePredicate;
					}
					break;
					IL_0029:
					safePredicate.AddDelegate(obj);
					num = 743603348;
				}
			}
		}
	}
}
