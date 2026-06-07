using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LitMotion
{
	public struct MotionBuilder<TValue, TOptions, TAdapter> : IDisposable where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
	{
		internal ushort version;

		internal MotionBuilderBuffer<TValue, TOptions> buffer;

		internal MotionBuilder(MotionBuilderBuffer<TValue, TOptions> buffer)
		{
			this.buffer = buffer;
			version = buffer.Version;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithEase(Ease ease)
		{
			CheckEaseType(ease);
			CheckBuffer();
			buffer.Ease = ease;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithEase(AnimationCurve animationCurve)
		{
			CheckBuffer();
			buffer.AnimationCurve = animationCurve;
			buffer.Ease = Ease.CustomAnimationCurve;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithDelay(float delay, DelayType delayType = DelayType.FirstLoop, bool skipValuesDuringDelay = true)
		{
			CheckBuffer();
			buffer.Delay = delay;
			buffer.DelayType = delayType;
			buffer.SkipValuesDuringDelay = skipValuesDuringDelay;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithLoops(int loops, LoopType loopType = LoopType.Restart)
		{
			CheckBuffer();
			buffer.Loops = loops;
			buffer.LoopType = loopType;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithOptions(TOptions options)
		{
			CheckBuffer();
			buffer.Options = options;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithOnCancel(Action callback)
		{
			CheckBuffer();
			MotionBuilderBuffer<TValue, TOptions> motionBuilderBuffer = buffer;
			motionBuilderBuffer.OnCancelAction = (Action)Delegate.Combine(motionBuilderBuffer.OnCancelAction, callback);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithOnComplete(Action callback)
		{
			CheckBuffer();
			MotionBuilderBuffer<TValue, TOptions> motionBuilderBuffer = buffer;
			motionBuilderBuffer.OnCompleteAction = (Action)Delegate.Combine(motionBuilderBuffer.OnCompleteAction, callback);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithOnLoopComplete(Action<int> callback)
		{
			CheckBuffer();
			MotionBuilderBuffer<TValue, TOptions> motionBuilderBuffer = buffer;
			motionBuilderBuffer.OnLoopCompleteAction = (Action<int>)Delegate.Combine(motionBuilderBuffer.OnLoopCompleteAction, callback);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithCancelOnError(bool cancelOnError = true)
		{
			CheckBuffer();
			buffer.CancelOnError = cancelOnError;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithImmediateBind(bool immediateBind = true)
		{
			CheckBuffer();
			buffer.ImmediateBind = immediateBind;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithScheduler(IMotionScheduler scheduler)
		{
			CheckBuffer();
			buffer.Scheduler = scheduler;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionBuilder<TValue, TOptions, TAdapter> WithDebugName(string debugName)
		{
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle RunWithoutBinding()
		{
			CheckBuffer();
			return ScheduleMotion();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle Bind(Action<TValue> action)
		{
			CheckBuffer();
			SetCallbackData(action);
			return ScheduleMotion();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle Bind<TState>(TState state, Action<TValue, TState> action) where TState : class
		{
			CheckBuffer();
			SetCallbackData(state, action);
			return ScheduleMotion();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle Bind<TState0, TState1>(TState0 state0, TState1 state1, Action<TValue, TState0, TState1> action) where TState0 : class where TState1 : class
		{
			CheckBuffer();
			SetCallbackData(state0, state1, action);
			return ScheduleMotion();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MotionHandle Bind<TState0, TState1, TState2>(TState0 state0, TState1 state1, TState2 state2, Action<TValue, TState0, TState1, TState2> action) where TState0 : class where TState1 : class where TState2 : class
		{
			CheckBuffer();
			SetCallbackData(state0, state1, state2, action);
			return ScheduleMotion();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly MotionSettings<TValue, TOptions> ToMotionSettings()
		{
			CheckBuffer();
			return new MotionSettings<TValue, TOptions>
			{
				StartValue = buffer.StartValue,
				EndValue = buffer.EndValue,
				Duration = buffer.Duration,
				Options = buffer.Options,
				Ease = buffer.Ease,
				CustomEaseCurve = buffer.AnimationCurve,
				Delay = buffer.Delay,
				DelayType = buffer.DelayType,
				Loops = buffer.Loops,
				LoopType = buffer.LoopType,
				CancelOnError = buffer.CancelOnError,
				SkipValuesDuringDelay = buffer.SkipValuesDuringDelay,
				ImmediateBind = buffer.ImmediateBind,
				Scheduler = buffer.Scheduler
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal MotionHandle ScheduleMotion()
		{
			MotionHandle motionHandle = ((buffer.Scheduler != null) ? buffer.Scheduler.Schedule(ref this) : ((MotionScheduler.DefaultScheduler != MotionScheduler.Update) ? MotionScheduler.DefaultScheduler.Schedule(ref this) : MotionDispatcher.Schedule(ref this, PlayerLoopTiming.Update)));
			if (MotionDebugger.Enabled)
			{
				MotionDebugger.AddTracking(motionHandle, buffer.Scheduler);
			}
			Dispose();
			return motionHandle;
		}

		public void Dispose()
		{
			if (buffer != null)
			{
				MotionBuilderBuffer<TValue, TOptions>.Return(buffer);
				buffer = null;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal readonly void SetCallbackData(Action<TValue> action)
		{
			buffer.StateCount = 0;
			buffer.UpdateAction = action;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal readonly void SetCallbackData<TState>(TState state, Action<TValue, TState> action) where TState : class
		{
			buffer.StateCount = 1;
			buffer.State0 = state;
			buffer.UpdateAction = action;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal readonly void SetCallbackData<TState0, TState1>(TState0 state0, TState1 state1, Action<TValue, TState0, TState1> action) where TState0 : class where TState1 : class
		{
			buffer.StateCount = 2;
			buffer.State0 = state0;
			buffer.State1 = state1;
			buffer.UpdateAction = action;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal readonly void SetCallbackData<TState0, TState1, TState2>(TState0 state0, TState1 state1, TState2 state2, Action<TValue, TState0, TState1, TState2> action) where TState0 : class where TState1 : class where TState2 : class
		{
			buffer.StateCount = 3;
			buffer.State0 = state0;
			buffer.State1 = state1;
			buffer.State2 = state2;
			buffer.UpdateAction = action;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly void CheckBuffer()
		{
			if (buffer == null || buffer.Version != version)
			{
				throw new InvalidOperationException("MotionBuilder is either not initialized or has already run a Build (or Bind).");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private readonly void CheckEaseType(Ease ease)
		{
			if (ease == Ease.CustomAnimationCurve)
			{
				throw new ArgumentException($"Ease.{ease} cannot be specified directly.");
			}
		}
	}
}
