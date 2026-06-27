using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute.ClearExtensions;
using NSubstitute.Core;
using NSubstitute.Exceptions;
using NSubstitute.ReceivedExtensions;

namespace NSubstitute
{
	public static class SubstituteExtensions
	{
		public static T Received<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return substitute.Received(Quantity.AtLeastOne());
		}

		public static T Received<T>(this T substitute, int requiredNumberOfCalls) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return substitute.Received(Quantity.Exactly(requiredNumberOfCalls));
		}

		public static T DidNotReceive<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return substitute.Received(Quantity.None());
		}

		public static T ReceivedWithAnyArgs<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return substitute.ReceivedWithAnyArgs(Quantity.AtLeastOne());
		}

		public static T ReceivedWithAnyArgs<T>(this T substitute, int requiredNumberOfCalls) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return substitute.ReceivedWithAnyArgs(Quantity.Exactly(requiredNumberOfCalls));
		}

		public static T DidNotReceiveWithAnyArgs<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return substitute.ReceivedWithAnyArgs(Quantity.None());
		}

		public static IEnumerable<ICall> ReceivedCalls<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return SubstitutionContext.Current.GetCallRouterFor(substitute).ReceivedCalls();
		}

		public static void ClearReceivedCalls<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			substitute.ClearSubstitute(ClearOptions.ReceivedCalls);
		}

		public static ConfiguredCall Returns<T>(this T value, T returnThis, params T[] returnThese)
		{
			return ConfigureReturn(MatchArgs.AsSpecifiedInCall, returnThis, returnThese);
		}

		public static ConfiguredCall Returns<T>(this T value, Func<CallInfo, T> returnThis, params Func<CallInfo, T>[] returnThese)
		{
			return ConfigureReturn(MatchArgs.AsSpecifiedInCall, returnThis, returnThese);
		}

		public static ConfiguredCall ReturnsForAnyArgs<T>(this T value, T returnThis, params T[] returnThese)
		{
			return ConfigureReturn(MatchArgs.Any, returnThis, returnThese);
		}

		public static ConfiguredCall ReturnsForAnyArgs<T>(this T value, Func<CallInfo, T> returnThis, params Func<CallInfo, T>[] returnThese)
		{
			return ConfigureReturn(MatchArgs.Any, returnThis, returnThese);
		}

		private static ConfiguredCall ConfigureReturn<T>(MatchArgs matchArgs, T? returnThis, T?[]? returnThese)
		{
			IReturn value;
			if (returnThese == null || returnThese.Length == 0)
			{
				value = new ReturnValue(returnThis);
			}
			else
			{
				int num = 0;
				T[] array = new T[1 + returnThese.Length];
				array[num] = returnThis;
				num++;
				foreach (T val in returnThese)
				{
					array[num] = val;
					num++;
				}
				value = new ReturnMultipleValues<T>(array);
			}
			return SubstitutionContext.Current.ThreadContext.LastCallShouldReturn(value, matchArgs);
		}

		private static ConfiguredCall ConfigureReturn<T>(MatchArgs matchArgs, Func<CallInfo, T?> returnThis, Func<CallInfo, T?>[]? returnThese)
		{
			IReturn value;
			if (returnThese == null || returnThese.Length == 0)
			{
				value = new ReturnValueFromFunc<T>(returnThis);
			}
			else
			{
				int num = 0;
				Func<CallInfo, T>[] array = new Func<CallInfo, T>[1 + returnThese.Length];
				array[num] = returnThis;
				num++;
				foreach (Func<CallInfo, T> func in returnThese)
				{
					array[num] = func;
					num++;
				}
				value = new ReturnMultipleFuncsValues<T>(array);
			}
			return SubstitutionContext.Current.ThreadContext.LastCallShouldReturn(value, matchArgs);
		}

		public static ConfiguredCall Returns<T>(this Task<T> value, T returnThis, params T[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			Task<T> returnThis2 = CompletedTask(returnThis);
			Task<T>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(CompletedTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.AsSpecifiedInCall, returnThis2, returnThese2);
		}

		public static ConfiguredCall Returns<T>(this Task<T> value, Func<CallInfo, T> returnThis, params Func<CallInfo, T>[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			Func<CallInfo, Task<T>> returnThis2 = WrapFuncInTask(returnThis);
			Func<CallInfo, Task<T>>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(WrapFuncInTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.AsSpecifiedInCall, returnThis2, returnThese2);
		}

		public static ConfiguredCall ReturnsForAnyArgs<T>(this Task<T> value, T returnThis, params T[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			Task<T> returnThis2 = CompletedTask(returnThis);
			Task<T>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(CompletedTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.Any, returnThis2, returnThese2);
		}

		public static ConfiguredCall ReturnsForAnyArgs<T>(this Task<T> value, Func<CallInfo, T> returnThis, params Func<CallInfo, T>[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			Func<CallInfo, Task<T>> returnThis2 = WrapFuncInTask(returnThis);
			Func<CallInfo, Task<T>>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(WrapFuncInTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.Any, returnThis2, returnThese2);
		}

		private static void ReThrowOnNSubstituteFault<T>(Task<T?> task)
		{
			if (task.IsFaulted && task.Exception.InnerExceptions.FirstOrDefault() is SubstituteException)
			{
				task.GetAwaiter().GetResult();
			}
		}

		private static Task<T?> CompletedTask<T>(T? result)
		{
			return Task.FromResult(result);
		}

		private static Func<CallInfo, Task<T?>> WrapFuncInTask<T>(Func<CallInfo, T> returnThis)
		{
			return (CallInfo x) => CompletedTask(returnThis(x));
		}

		public static ConfiguredCall Returns<T>(this ValueTask<T> value, T returnThis, params T[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			ValueTask<T> returnThis2 = CompletedValueTask(returnThis);
			ValueTask<T>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(CompletedValueTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.AsSpecifiedInCall, returnThis2, returnThese2);
		}

		public static ConfiguredCall Returns<T>(this ValueTask<T> value, Func<CallInfo, T> returnThis, params Func<CallInfo, T>[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			Func<CallInfo, ValueTask<T>> returnThis2 = WrapFuncInValueTask(returnThis);
			Func<CallInfo, ValueTask<T>>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(WrapFuncInValueTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.AsSpecifiedInCall, returnThis2, returnThese2);
		}

		public static ConfiguredCall ReturnsForAnyArgs<T>(this ValueTask<T> value, T returnThis, params T[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			ValueTask<T> returnThis2 = CompletedValueTask(returnThis);
			ValueTask<T>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(CompletedValueTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.Any, returnThis2, returnThese2);
		}

		public static ConfiguredCall ReturnsForAnyArgs<T>(this ValueTask<T> value, Func<CallInfo, T> returnThis, params Func<CallInfo, T>[] returnThese)
		{
			ReThrowOnNSubstituteFault(value);
			Func<CallInfo, ValueTask<T>> returnThis2 = WrapFuncInValueTask(returnThis);
			Func<CallInfo, ValueTask<T>>[] returnThese2 = ((returnThese.Length != 0) ? returnThese.Select(WrapFuncInValueTask).ToArray() : null);
			return ConfigureReturn(MatchArgs.Any, returnThis2, returnThese2);
		}

		private static void ReThrowOnNSubstituteFault<T>(ValueTask<T?> task)
		{
			if (task.IsFaulted && task.AsTask().Exception.InnerExceptions.FirstOrDefault() is SubstituteException)
			{
				task.GetAwaiter().GetResult();
			}
		}

		private static ValueTask<T?> CompletedValueTask<T>(T? result)
		{
			return new ValueTask<T>(result);
		}

		private static Func<CallInfo, ValueTask<T?>> WrapFuncInValueTask<T>(Func<CallInfo, T> returnThis)
		{
			return (CallInfo x) => CompletedValueTask(returnThis(x));
		}

		public static WhenCalled<T> When<T>(this T substitute, Action<T> substituteCall) where T : class
		{
			return MakeWhenCalled(substitute, substituteCall, MatchArgs.AsSpecifiedInCall);
		}

		public static WhenCalled<T> WhenForAnyArgs<T>(this T substitute, Action<T> substituteCall) where T : class
		{
			return MakeWhenCalled(substitute, substituteCall, MatchArgs.Any);
		}

		private static WhenCalled<TSubstitute> MakeWhenCalled<TSubstitute>(TSubstitute? substitute, Action<TSubstitute> action, MatchArgs matchArgs)
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			return new WhenCalled<TSubstitute>(SubstitutionContext.Current, substitute, action, matchArgs);
		}

		public static WhenCalled<T> When<T>(this T substitute, Func<T, Task> substituteCall) where T : class
		{
			return MakeWhenCalled(substitute, delegate(T x)
			{
				substituteCall(x);
			}, MatchArgs.AsSpecifiedInCall);
		}

		public static WhenCalled<T> WhenForAnyArgs<T>(this T substitute, Func<T, Task> substituteCall) where T : class
		{
			return MakeWhenCalled(substitute, delegate(T x)
			{
				substituteCall(x);
			}, MatchArgs.Any);
		}

		public static WhenCalled<TSubstitute> When<TSubstitute, TResult>(this TSubstitute substitute, Func<TSubstitute, ValueTask<TResult>> substituteCall) where TSubstitute : class
		{
			return MakeWhenCalled(substitute, delegate(TSubstitute x)
			{
				substituteCall(x);
			}, MatchArgs.AsSpecifiedInCall);
		}

		public static WhenCalled<TSubstitute> WhenForAnyArgs<TSubstitute, TResult>(this TSubstitute substitute, Func<TSubstitute, ValueTask<TResult>> substituteCall) where TSubstitute : class
		{
			return MakeWhenCalled(substitute, delegate(TSubstitute x)
			{
				substituteCall(x);
			}, MatchArgs.Any);
		}
	}
}
