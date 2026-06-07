using System;
using R3;

namespace LitMotion
{
	public static class LitMotionR3Extensions
	{
		public static Observable<TValue> ToObservable<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Subject<TValue> subject = new Subject<TValue>();
			builder.SetCallbackData(subject, delegate(TValue x, Subject<TValue> subject2)
			{
				subject2.OnNext(x);
			});
			MotionBuilderBuffer<TValue, TOptions> buffer = builder.buffer;
			buffer.OnCompleteAction = (Action)Delegate.Combine(buffer.OnCompleteAction, (Action)delegate
			{
				subject.OnCompleted();
			});
			MotionBuilderBuffer<TValue, TOptions> buffer2 = builder.buffer;
			buffer2.OnCancelAction = (Action)Delegate.Combine(buffer2.OnCancelAction, (Action)delegate
			{
				subject.OnCompleted();
			});
			builder.ScheduleMotion();
			return subject;
		}

		public static MotionHandle BindToReactiveProperty<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder, ReactiveProperty<TValue> reactiveProperty) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Error.IsNull(reactiveProperty);
			return builder.Bind(reactiveProperty, delegate(TValue x, ReactiveProperty<TValue> target)
			{
				target.Value = x;
			});
		}
	}
}
