using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafeFunc<T, TResult> : SafeDelegate<Func<T, TResult>>
	{
		private T JlMCBZeMbvoncHXCRldnqnFCoRnV;

		private TResult WUVarGVZeThYydwDSFAMxXirlbW;

		private static Action<object, Func<T, TResult>> JqkKvONojrNrQhtXccOtrbSsnZb;

		private static Action<object, Func<T, TResult>> invokeDelegate
		{
			get
			{
				return bpepNPWIUMvlIWByBwlQNAILiEgd;
			}
		}

		public SafeFunc()
		{
		}

		public SafeFunc(Action<Exception> exceptionHandler)
			: base(exceptionHandler)
		{
		}

		protected SafeFunc(SafeFunc<T, TResult> source)
			: base((SafeDelegate<Func<T, TResult>>)source)
		{
		}

		public TResult Invoke(T arg0)
		{
			JlMCBZeMbvoncHXCRldnqnFCoRnV = arg0;
			try
			{
				Invoke(invokeDelegate);
				return WUVarGVZeThYydwDSFAMxXirlbW;
			}
			catch
			{
				Logger.LogError("Error invoking SafeFunc base class.");
				return default(TResult);
			}
			finally
			{
				JlMCBZeMbvoncHXCRldnqnFCoRnV = default(T);
				WUVarGVZeThYydwDSFAMxXirlbW = default(TResult);
			}
		}

		public override object Clone()
		{
			return new SafeFunc<T, TResult>(this);
		}

		private static void bpepNPWIUMvlIWByBwlQNAILiEgd(object P_0, Func<T, TResult> P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (0x3AF0EEA3 ^ 0x3AF0EEA2)
					{
					case 3:
						break;
					case 1:
						return;
					case 0:
						goto end_IL_0003;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			SafeFunc<T, TResult> safeFunc = P_0 as SafeFunc<T, TResult>;
			if (safeFunc == null)
			{
				return;
			}
			goto IL_003f;
			IL_003f:
			safeFunc.WUVarGVZeThYydwDSFAMxXirlbW = P_1(safeFunc.JlMCBZeMbvoncHXCRldnqnFCoRnV);
		}

		public static SafeFunc<T, TResult> operator +(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			if (eventList == null)
			{
				eventList = new SafeFunc<T, TResult>();
			}
			eventList.AddDelegate(func);
			return eventList;
		}

		public static SafeFunc<T, TResult> operator -(SafeFunc<T, TResult> eventList, Func<T, TResult> func)
		{
			if (eventList == null)
			{
				return null;
			}
			eventList.RemoveDelegate(func);
			return eventList;
		}

		public static implicit operator Func<T, TResult>(SafeFunc<T, TResult> obj)
		{
			if (obj == null)
			{
				return null;
			}
			return obj.GetCombinedDelegate();
		}

		public static implicit operator SafeFunc<T, TResult>(Func<T, TResult> obj)
		{
			if (obj == null)
			{
				return null;
			}
			SafeFunc<T, TResult> safeFunc = new SafeFunc<T, TResult>();
			safeFunc.AddDelegate(obj);
			return safeFunc;
		}
	}
}
