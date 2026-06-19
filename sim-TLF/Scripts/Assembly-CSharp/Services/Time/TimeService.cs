using System;
using Pinwheel.Jupiter;
using UnityEngine;
using Zenject;

namespace Services.Time
{
	public class TimeService : ITimeService, IInitializable, ITickable
	{
		private readonly JDayNightCycle _cycle;

		private float _lastTime;

		public float CurrentTime => _cycle.Time;

		public float TimeIncrement => _cycle.TimeIncrement;

		public bool AutoTimeIncrement => _cycle.AutoTimeIncrement;

		public event Action<float> OnTimeChanged;

		public TimeService(JDayNightCycle cycle)
		{
			_cycle = cycle;
		}

		public void Initialize()
		{
			_lastTime = _cycle.Time;
		}

		public void Tick()
		{
			if (!(Mathf.Abs(_cycle.Time - _lastTime) < 0.001f))
			{
				_lastTime = _cycle.Time;
				this.OnTimeChanged?.Invoke(_cycle.Time);
			}
		}

		public void SetTime(float time)
		{
			_cycle.Time = Mathf.Clamp(time, 0f, 24f);
			this.OnTimeChanged?.Invoke(_cycle.Time);
		}

		public void SetTimeIncrement(float increment)
		{
			_cycle.TimeIncrement = Mathf.Max(0f, increment);
		}

		public void SetAutoTimeIncrement(bool auto)
		{
			_cycle.AutoTimeIncrement = auto;
		}
	}
}
