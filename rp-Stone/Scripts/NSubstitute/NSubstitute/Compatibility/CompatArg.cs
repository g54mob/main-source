using System;
using System.Linq.Expressions;

namespace NSubstitute.Compatibility
{
	public class CompatArg
	{
		public static readonly CompatArg Instance = new CompatArg();

		private CompatArg()
		{
		}

		public T Any<T>()
		{
			return Arg.Any<T>();
		}

		public T Is<T>(T value)
		{
			return Arg.Is(value);
		}

		public T Is<T>(Expression<Predicate<T>> predicate)
		{
			return Arg.Is(predicate);
		}

		public Action Invoke()
		{
			return Arg.Invoke();
		}

		public Action<T> Invoke<T>(T arg)
		{
			return Arg.Invoke(arg);
		}

		public Action<T1, T2> Invoke<T1, T2>(T1 arg1, T2 arg2)
		{
			return Arg.Invoke(arg1, arg2);
		}

		public Action<T1, T2, T3> Invoke<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
		{
			return Arg.Invoke(arg1, arg2, arg3);
		}

		public Action<T1, T2, T3, T4> Invoke<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return Arg.Invoke(arg1, arg2, arg3, arg4);
		}

		public TDelegate InvokeDelegate<TDelegate>(params object[] arguments)
		{
			return Arg.InvokeDelegate<TDelegate>(arguments);
		}

		public T Do<T>(Action<T> useArgument)
		{
			return Arg.Do(useArgument);
		}
	}
}
