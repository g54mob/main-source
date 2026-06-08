using System;
using System.Linq.Expressions;
using NSubstitute.Core.Arguments;

namespace NSubstitute
{
	public static class Arg
	{
		public static class Compat
		{
			public static T Any<T>()
			{
				return Arg.Any<T>();
			}

			public static T Is<T>(T value)
			{
				return Arg.Is(value);
			}

			public static T Is<T>(Expression<Predicate<T>> predicate)
			{
				return Arg.Is(predicate);
			}

			public static Action Invoke()
			{
				return Arg.Invoke();
			}

			public static Action<T> Invoke<T>(T arg)
			{
				return Arg.Invoke(arg);
			}

			public static Action<T1, T2> Invoke<T1, T2>(T1 arg1, T2 arg2)
			{
				return Arg.Invoke(arg1, arg2);
			}

			public static Action<T1, T2, T3> Invoke<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
			{
				return Arg.Invoke(arg1, arg2, arg3);
			}

			public static Action<T1, T2, T3, T4> Invoke<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
			{
				return Arg.Invoke(arg1, arg2, arg3, arg4);
			}

			public static TDelegate InvokeDelegate<TDelegate>(params object[] arguments)
			{
				return Arg.InvokeDelegate<TDelegate>(arguments);
			}

			public static T Do<T>(Action<T> useArgument)
			{
				return Arg.Do(useArgument);
			}
		}

		public static ref T Any<T>()
		{
			return ref ArgumentMatcher.Enqueue<T>(new AnyArgumentMatcher(typeof(T)));
		}

		public static ref T Is<T>(T value)
		{
			return ref ArgumentMatcher.Enqueue<T>(new EqualsArgumentMatcher(value));
		}

		public static ref T Is<T>(Expression<Predicate<T>> predicate)
		{
			return ref ArgumentMatcher.Enqueue<T>(new ExpressionArgumentMatcher<T>(predicate));
		}

		public static ref Action Invoke()
		{
			return ref ArgumentMatcher.Enqueue<Action>(new AnyArgumentMatcher(typeof(Action)), InvokeDelegateAction());
		}

		public static ref Action<T> Invoke<T>(T arg)
		{
			return ref ArgumentMatcher.Enqueue<Action<T>>(new AnyArgumentMatcher(typeof(Action<T>)), InvokeDelegateAction(arg));
		}

		public static ref Action<T1, T2> Invoke<T1, T2>(T1 arg1, T2 arg2)
		{
			return ref ArgumentMatcher.Enqueue<Action<T1, T2>>(new AnyArgumentMatcher(typeof(Action<T1, T2>)), InvokeDelegateAction(arg1, arg2));
		}

		public static ref Action<T1, T2, T3> Invoke<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
		{
			return ref ArgumentMatcher.Enqueue<Action<T1, T2, T3>>(new AnyArgumentMatcher(typeof(Action<T1, T2, T3>)), InvokeDelegateAction(arg1, arg2, arg3));
		}

		public static ref Action<T1, T2, T3, T4> Invoke<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return ref ArgumentMatcher.Enqueue<Action<T1, T2, T3, T4>>(new AnyArgumentMatcher(typeof(Action<T1, T2, T3, T4>)), InvokeDelegateAction(arg1, arg2, arg3, arg4));
		}

		public static ref TDelegate InvokeDelegate<TDelegate>(params object[] arguments)
		{
			return ref ArgumentMatcher.Enqueue<TDelegate>(new AnyArgumentMatcher(typeof(TDelegate)), InvokeDelegateAction(arguments));
		}

		public static ref T Do<T>(Action<T> useArgument)
		{
			return ref ArgumentMatcher.Enqueue<T>(new AnyArgumentMatcher(typeof(T)), delegate(object? x)
			{
				useArgument((T)x);
			});
		}

		private static Action<object> InvokeDelegateAction(params object[] arguments)
		{
			return delegate(object x)
			{
				((Delegate)x).DynamicInvoke(arguments);
			};
		}
	}
}
