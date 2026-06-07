using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafeFunc<T, TResult> : SafeDelegate<Func<T, TResult>>
	{
		private T mXGSIUaHrvnMVnQVxkdxIQLMtEk;

		private TResult llPkaNpxmTvlZPKOwGNYAfunclN;

		private static Action<object, Func<T, TResult>> oqaLTPhZpfixnNfWQutfMiAseLi;

		private static Action<object, Func<T, TResult>> invokeDelegate
		{
			get
			{
				return WnkfGGuhOIzQfspnxnpIgyMVtLb;
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
			mXGSIUaHrvnMVnQVxkdxIQLMtEk = arg0;
			TResult result = default(TResult);
			try
			{
				Invoke(invokeDelegate);
				result = llPkaNpxmTvlZPKOwGNYAfunclN;
			}
			catch
			{
				while (true)
				{
					IL_001c:
					int num = 1961565680;
					while (true)
					{
						switch (num ^ 0x74EB1DF2)
						{
						case 0:
							break;
						default:
							goto end_IL_0021;
						case 2:
							goto IL_003a;
						case 1:
							goto end_IL_0021;
						}
						goto IL_001c;
						IL_003a:
						Logger.LogError("Error invoking SafeFunc base class.");
						result = default(TResult);
						num = 1961565683;
						continue;
						end_IL_0021:
						break;
					}
					break;
				}
			}
			finally
			{
				mXGSIUaHrvnMVnQVxkdxIQLMtEk = default(T);
				llPkaNpxmTvlZPKOwGNYAfunclN = default(TResult);
			}
			return result;
		}

		public override object Clone()
		{
			return new SafeFunc<T, TResult>(this);
		}

		private static void WnkfGGuhOIzQfspnxnpIgyMVtLb(object P_0, Func<T, TResult> P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				SafeFunc<T, TResult> safeFunc = P_0 as SafeFunc<T, TResult>;
				int num = 1106870601;
				while (true)
				{
					switch (num ^ 0x41F98148)
					{
					case 3:
						num = 1106870602;
						continue;
					case 4:
						return;
					case 1:
					{
						int num2;
						if (safeFunc == null)
						{
							num = 1106870604;
							num2 = num;
						}
						else
						{
							num = 1106870600;
							num2 = num;
						}
						continue;
					}
					case 2:
						break;
					default:
						safeFunc.llPkaNpxmTvlZPKOwGNYAfunclN = P_1(safeFunc.mXGSIUaHrvnMVnQVxkdxIQLMtEk);
						return;
					}
					break;
				}
			}
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
				goto IL_0003;
			}
			eventList.RemoveDelegate(func);
			int num = -1555232062;
			goto IL_0008;
			IL_0008:
			switch (num ^ -1555232064)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
				return eventList;
			}
			goto IL_0003;
			IL_0003:
			num = -1555232063;
			goto IL_0008;
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
