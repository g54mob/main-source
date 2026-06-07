using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace R3
{
	internal sealed class FrameTimer : ITimer, IDisposable, IAsyncDisposable, IFrameRunnerWorkItem
	{
		private enum RunningState
		{
			Stop = 0,
			RunningDueTime = 1,
			RunningPeriod = 2,
			ChangeRequested = 3
		}

		private readonly TimerCallback callback;

		private readonly object state;

		private readonly UnityFrameProvider frameProvider;

		private readonly TimeKind timeKind;

		private readonly object gate = new object();

		private TimeSpan dueTime;

		private TimeSpan period;

		private RunningState runningState;

		private float elapsed;

		private bool isDisposed;

		private long lastTimestamp;

		public FrameTimer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period, UnityFrameProvider frameProvider, TimeKind timeKind)
		{
			this.callback = callback;
			this.state = state;
			this.dueTime = dueTime;
			this.period = period;
			this.frameProvider = frameProvider;
			this.timeKind = timeKind;
			Change(dueTime, period);
		}

		public bool Change(TimeSpan dueTime, TimeSpan period)
		{
			if (isDisposed)
			{
				return false;
			}
			lock (gate)
			{
				this.dueTime = dueTime;
				this.period = period;
				if (dueTime == Timeout.InfiniteTimeSpan && runningState == RunningState.Stop)
				{
					return true;
				}
				if (runningState == RunningState.Stop)
				{
					frameProvider.Register(this);
				}
				runningState = RunningState.ChangeRequested;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float GetDeltaTime()
		{
			if (frameProvider.PlayerLoopTiming == PlayerLoopTiming.FixedUpdate)
			{
				switch (timeKind)
				{
				case TimeKind.Time:
					return Time.fixedDeltaTime;
				case TimeKind.UnscaledTime:
					return Time.fixedUnscaledDeltaTime;
				}
			}
			else
			{
				switch (timeKind)
				{
				case TimeKind.Time:
					return Time.deltaTime;
				case TimeKind.UnscaledTime:
					return Time.unscaledDeltaTime;
				}
			}
			long timestamp = TimeProvider.System.GetTimestamp();
			TimeSpan elapsedTime = TimeProvider.System.GetElapsedTime(lastTimestamp, timestamp);
			lastTimestamp = timestamp;
			return (float)elapsedTime.TotalSeconds;
		}

		bool IFrameRunnerWorkItem.MoveNext(long frameCount)
		{
			if (isDisposed)
			{
				return false;
			}
			RunningState runningState;
			TimeSpan timeSpan;
			TimeSpan timeSpan2;
			lock (gate)
			{
				runningState = this.runningState;
				if (runningState == RunningState.ChangeRequested)
				{
					elapsed = 0f;
					if (dueTime == Timeout.InfiniteTimeSpan)
					{
						this.runningState = RunningState.Stop;
						return false;
					}
					runningState = (this.runningState = RunningState.RunningDueTime);
				}
				timeSpan = period;
				timeSpan2 = dueTime;
			}
			elapsed += GetDeltaTime();
			try
			{
				if (runningState == RunningState.RunningDueTime)
				{
					float num = (float)timeSpan2.TotalSeconds;
					if (elapsed >= num)
					{
						callback(state);
						elapsed = 0f;
						if (period == Timeout.InfiniteTimeSpan)
						{
							return ChangeState(RunningState.Stop);
						}
						return ChangeState(RunningState.RunningPeriod);
					}
					return true;
				}
				float num2 = (float)timeSpan.TotalSeconds;
				if (elapsed >= num2)
				{
					callback(state);
					elapsed = 0f;
				}
				return ChangeState(RunningState.RunningPeriod);
			}
			catch (Exception obj)
			{
				ObservableSystem.GetUnhandledExceptionHandler()(obj);
				return ChangeState(RunningState.Stop);
			}
		}

		private bool ChangeState(RunningState state)
		{
			lock (gate)
			{
				if (runningState == RunningState.ChangeRequested)
				{
					return true;
				}
				if (state == RunningState.RunningPeriod)
				{
					runningState = state;
					return true;
				}
				runningState = state;
				return false;
			}
		}

		public void Dispose()
		{
			Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
			isDisposed = true;
		}

		public ValueTask DisposeAsync()
		{
			Dispose();
			return default(ValueTask);
		}
	}
}
