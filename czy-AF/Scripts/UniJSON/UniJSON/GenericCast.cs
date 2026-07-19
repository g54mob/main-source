using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace UniJSON
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct GenericCast<S, T>
	{
		private delegate T CastFunc(S value);

		private delegate Func<T> ConstFuncCreator(S value);

		private static CastFunc s_cast;

		private static ConstFuncCreator s_const;

		public static T Null()
		{
			if (typeof(T).IsClass)
			{
				return default(T);
			}
			throw new MsgPackTypeException("can not null");
		}

		public static Func<T> Const(S value)
		{
			if (s_const == null)
			{
				s_const = GenericCast.CreateConst<S, T>().Invoke;
			}
			return s_const(value);
		}

		public static T Cast(S value)
		{
			if (s_cast == null)
			{
				s_cast = GenericCast.CreateCast<S, T>().Invoke;
			}
			return s_cast(value);
		}
	}
	internal static class GenericCast
	{
		public static Func<S, T> CreateCast<S, T>()
		{
			MethodInfo method = ConcreteCast.GetMethod(typeof(S), typeof(T));
			if (method == null)
			{
				return (S s) => (T)(object)s;
			}
			return GenericInvokeCallFactory.StaticFunc<S, T>(method);
		}

		public static Func<S, Func<T>> CreateConst<S, T>()
		{
			Func<S, T> cast = CreateCast<S, T>();
			return (S s) => () => cast(s);
		}
	}
}
