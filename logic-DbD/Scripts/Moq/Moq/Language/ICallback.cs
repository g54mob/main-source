using System;
using System.ComponentModel;
using Moq.Language.Flow;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallback : IFluentInterface
	{
		ICallbackResult Callback(InvocationAction action);

		ICallbackResult Callback(Delegate callback);

		ICallbackResult Callback(Action action);

		ICallbackResult Callback<T>(Action<T> action);

		ICallbackResult Callback<T1, T2>(Action<T1, T2> action);

		ICallbackResult Callback<T1, T2, T3>(Action<T1, T2, T3> action);

		ICallbackResult Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action);

		ICallbackResult Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action);
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICallback<TMock, TResult> : IFluentInterface where TMock : class
	{
		IReturnsThrows<TMock, TResult> Callback(InvocationAction action);

		IReturnsThrows<TMock, TResult> Callback(Delegate callback);

		IReturnsThrows<TMock, TResult> Callback(Action action);

		IReturnsThrows<TMock, TResult> Callback<T>(Action<T> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2>(Action<T1, T2> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3>(Action<T1, T2, T3> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action);

		IReturnsThrows<TMock, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action);
	}
}
