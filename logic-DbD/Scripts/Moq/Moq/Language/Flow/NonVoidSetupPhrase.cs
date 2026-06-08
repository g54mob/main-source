using System;

namespace Moq.Language.Flow
{
	internal class NonVoidSetupPhrase<T, TResult> : SetupPhrase, ISetup<T, TResult>, ICallback<T, TResult>, IFluentInterface, IReturnsThrows<T, TResult>, IReturns<T, TResult>, IThrows, IVerifies, ISetupGetter<T, TResult>, ICallbackGetter<T, TResult>, IReturnsThrowsGetter<T, TResult>, IReturnsGetter<T, TResult>, IReturnsResult<T>, ICallback, IOccurrence, IRaise<T> where T : class
	{
		public NonVoidSetupPhrase(MethodCall setup)
			: base(setup)
		{
		}

		public new IReturnsThrows<T, TResult> Callback(InvocationAction action)
		{
			base.Setup.SetCallbackBehavior(action.Action);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback(Delegate callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		IReturnsThrowsGetter<T, TResult> ICallbackGetter<T, TResult>.Callback(Action callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback(Action callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1>(Action<T1> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2>(Action<T1, T2> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3>(Action<T1, T2, T3> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsThrows<T, TResult> Callback<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> callback)
		{
			base.Setup.SetCallbackBehavior(callback);
			return this;
		}

		public new IReturnsResult<T> CallBase()
		{
			base.Setup.SetCallBaseBehavior();
			return this;
		}

		public IVerifies Raises(Action<T> eventExpression, EventArgs args)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, (Func<EventArgs>)(() => args));
			return this;
		}

		public IVerifies Raises(Action<T> eventExpression, Func<EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises(Action<T> eventExpression, params object[] args)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, args);
			return this;
		}

		public IVerifies Raises<T1>(Action<T> eventExpression, Func<T1, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2>(Action<T> eventExpression, Func<T1, T2, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3>(Action<T> eventExpression, Func<T1, T2, T3, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4>(Action<T> eventExpression, Func<T1, T2, T3, T4, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IVerifies Raises<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T> eventExpression, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, EventArgs> func)
		{
			base.Setup.SetRaiseEventBehavior(eventExpression, func);
			return this;
		}

		public IReturnsResult<T> Returns(TResult value)
		{
			base.Setup.SetReturnValueBehavior(value);
			return this;
		}

		public IReturnsResult<T> Returns(InvocationFunc valueFunction)
		{
			base.Setup.SetReturnComputedValueBehavior(valueFunction.Func);
			return this;
		}

		public IReturnsResult<T> Returns(Delegate valueFunction)
		{
			base.Setup.SetReturnComputedValueBehavior(valueFunction);
			return this;
		}

		public IReturnsResult<T> Returns(Func<TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1>(Func<T1, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2>(Func<T1, T2, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3>(Func<T1, T2, T3, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4>(Func<T1, T2, T3, T4, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		public IReturnsResult<T> Returns<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> valueExpression)
		{
			base.Setup.SetReturnComputedValueBehavior(valueExpression);
			return this;
		}

		Type IFluentInterface.GetType()
		{
			return GetType();
		}
	}
}
