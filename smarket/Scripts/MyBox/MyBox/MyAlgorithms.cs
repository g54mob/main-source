using System;
using JetBrains.Annotations;

namespace MyBox
{
	[PublicAPI]
	public static class MyAlgorithms
	{
		public static T Cast<T>(this IConvertible source)
		{
			return default(T);
		}

		public static bool Is<T>(this object source)
		{
			return false;
		}

		public static T As<T>(this object source) where T : class
		{
			return null;
		}

		public static T Pipe<T>(this T argument, Action<T> action)
		{
			return default(T);
		}

		public static TResult Pipe<T, TResult>(this T argument, Func<T, TResult> function)
		{
			return default(TResult);
		}

		public static T PipeKeep<T, TResult>(this T argument, Func<T, TResult> function)
		{
			return default(T);
		}
	}
}
