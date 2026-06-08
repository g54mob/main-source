using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SafeFunc<T, TResult> : SafeDelegate<Func<T, TResult>>
	{
		private T TSedBQYUfMPQIWewxCsmKxLtZHU;

		private TResult QkPKNYJZTNeoOcRhvEvLKCIgChkd;

		private static Action<object, Func<T, TResult>> BueOgWVzEtbtuoGvJZVuGDqrtjV;

		private static Action<object, Func<T, TResult>> invokeDelegate => noivHTQpdGHiePoAmAVHwawQMzC;

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
			TSedBQYUfMPQIWewxCsmKxLtZHU = arg0;
			try
			{
				Invoke(invokeDelegate);
				return QkPKNYJZTNeoOcRhvEvLKCIgChkd;
			}
			catch
			{
				Logger.LogError("Error invoking SafeFunc base class.");
				return default(TResult);
			}
			finally
			{
				TSedBQYUfMPQIWewxCsmKxLtZHU = default(T);
				QkPKNYJZTNeoOcRhvEvLKCIgChkd = default(TResult);
			}
		}

		public override object Clone()
		{
			return new SafeFunc<T, TResult>(this);
		}

		private static void noivHTQpdGHiePoAmAVHwawQMzC(object P_0, Func<T, TResult> P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (-672216822 ^ -672216821)
					{
					case 0:
						break;
					case 1:
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
			SafeFunc<T, TResult> safeFunc = P_0 as SafeFunc<T, TResult>;
			if (safeFunc == null)
			{
				return;
			}
			goto IL_003f;
			IL_003f:
			safeFunc.QkPKNYJZTNeoOcRhvEvLKCIgChkd = P_1(safeFunc.TSedBQYUfMPQIWewxCsmKxLtZHU);
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
			int num = 265469357;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0xFD2BDAF)
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
			num = 265469358;
			goto IL_0008;
		}

		public static implicit operator Func<T, TResult>(SafeFunc<T, TResult> obj)
		{
			return obj?.GetCombinedDelegate();
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
