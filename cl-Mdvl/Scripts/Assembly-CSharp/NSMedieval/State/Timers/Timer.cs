using System;
using NSEipix.Base;
using NSMedieval.Serialization;

namespace NSMedieval.State.Timers
{
	[Serializable]
	[FVSerializableKey("Timer", "")]
	public class Timer : BaseTimer
	{
		public Timer(float interval)
			: base(interval)
		{
			MonoSingleton<BaseTimerController<Timer>>.Instance.AddTimer(this);
		}

		public Timer(float interval, bool restartOnEnd)
			: base(interval)
		{
			SetRestartOnEnd(restartOnEnd);
			MonoSingleton<BaseTimerController<Timer>>.Instance.AddTimer(this);
		}

		public Timer(FVDeserializer deserializer)
			: base(deserializer)
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<BaseTimerController<Timer>>.IsInstantiated())
			{
				MonoSingleton<BaseTimerController<Timer>>.Instance.RemoveTimer(this);
			}
		}

		public void ResumeAddToTimerController()
		{
			base.Resume();
			MonoSingleton<BaseTimerController<Timer>>.Instance.AddTimer(this);
		}

		public override void ForceComplete()
		{
			base.ForceComplete();
			TimerEnded();
			if (!base.RestartOnEnd)
			{
				paused = true;
			}
			else
			{
				RestartTimer();
			}
		}

		public override void OnTimeTick(float deltaTime)
		{
			if (deltaTime <= 0f)
			{
				return;
			}
			SubtractFromRemainingTime(base.TickSpeed * deltaTime);
			TickTimer(base.RemainingTime);
			if (!(base.RemainingTime <= 0f))
			{
				return;
			}
			TimerEnded();
			if (paused || base.RemainingTime != base.TotalTime)
			{
				if (!base.RestartOnEnd)
				{
					paused = true;
				}
				else
				{
					RestartTimer();
				}
			}
		}
	}
}
