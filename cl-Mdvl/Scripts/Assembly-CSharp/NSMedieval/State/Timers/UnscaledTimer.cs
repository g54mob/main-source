using System;
using NSEipix.Base;
using NSMedieval.Serialization;

namespace NSMedieval.State.Timers
{
	[Serializable]
	[FVSerializableKey("UnscaledTimer", "")]
	public class UnscaledTimer : BaseTimer
	{
		public UnscaledTimer(float interval)
			: base(interval)
		{
			MonoSingleton<BaseTimerController<UnscaledTimer>>.Instance.AddTimer(this);
		}

		public UnscaledTimer(float interval, bool restartOnEnd)
			: base(interval)
		{
			SetRestartOnEnd(restartOnEnd);
			MonoSingleton<BaseTimerController<UnscaledTimer>>.Instance.AddTimer(this);
		}

		public UnscaledTimer(FVDeserializer deserializer)
			: base(deserializer)
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<BaseTimerController<UnscaledTimer>>.IsInstantiated())
			{
				MonoSingleton<BaseTimerController<UnscaledTimer>>.Instance.RemoveTimer(this);
			}
		}

		public void ResumeAddToTimerController()
		{
			base.Resume();
			MonoSingleton<BaseTimerController<UnscaledTimer>>.Instance.AddTimer(this);
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
			if (base.RemainingTime <= 0f)
			{
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
		}
	}
}
