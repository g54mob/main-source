using System;
using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[TaskDescription("Wait a specified amount of time using the TimerManager.  This is Save/Load safe, but be sure to consider how it'll work on load")]
	[TaskCategory(" TH20/Timer")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	public class WaitNamed : LevelAction
	{
		public string TimerName;

		public float TimerLength;

		public bool UseScaledTimer = true;

		public bool IsLooping;

		public bool IsRandom;

		public float MinLength;

		public float MaxLength;

		public bool RerandomiseOnReset;

		private bool _loopingTimerFinished;

		public override void OnStart()
		{
			base.OnStart();
			if (!base.Owner.Level.TimerManager.HasTimerExpired(TimerName))
			{
				if (IsLooping)
				{
					_loopingTimerFinished = false;
					TimerManager timerManager = base.Owner.Level.TimerManager;
					timerManager.OnTimerFinished = (Action<Timer>)Delegate.Combine(timerManager.OnTimerFinished, new Action<Timer>(OnTimerFinished));
				}
				if (IsRandom)
				{
					base.Owner.Level.TimerManager.CreateTimerRandom(TimerName, UseScaledTimer, IsLooping, MinLength, MaxLength, RerandomiseOnReset);
				}
				else
				{
					base.Owner.Level.TimerManager.CreateTimer(TimerName, UseScaledTimer, IsLooping, TimerLength);
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (base.Owner.Level.TimerManager.HasTimerExpired(TimerName))
			{
				return TaskStatus.Success;
			}
			if (_loopingTimerFinished)
			{
				_loopingTimerFinished = false;
				return TaskStatus.Success;
			}
			if (base.Owner.Level.TimerManager.FindTimer(TimerName) == null)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			if (IsLooping)
			{
				TimerManager timerManager = base.Owner.Level.TimerManager;
				timerManager.OnTimerFinished = (Action<Timer>)Delegate.Remove(timerManager.OnTimerFinished, new Action<Timer>(OnTimerFinished));
			}
		}

		private void OnTimerFinished(Timer timer)
		{
			if (timer.Name.Equals(TimerName))
			{
				_loopingTimerFinished = true;
			}
		}
	}
}
