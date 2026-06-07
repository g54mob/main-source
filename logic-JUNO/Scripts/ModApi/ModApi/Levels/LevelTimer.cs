using System;
using ModApi.Flight;
using UnityEngine;

namespace ModApi.Levels
{
	public class LevelTimer
	{
		private double _seconds;

		public TimeSpan Elapsed => new TimeSpan((long)(_seconds * 10000000.0));

		public double ElapsedMilliseconds => _seconds * 0.001;

		public double ElapsedSeconds => _seconds;

		public bool IsRunning { get; private set; }

		public bool UseUnscaledTime { get; private set; }

		internal LevelTimer()
		{
		}

		public void Reset()
		{
			IsRunning = false;
			_seconds = 0.0;
		}

		public void Start(bool useUnscaledTime = false)
		{
			UseUnscaledTime = useUnscaledTime;
			IsRunning = true;
			_seconds = 0.0;
		}

		public void Stop()
		{
			IsRunning = false;
		}

		internal void Update()
		{
			if (!IsRunning)
			{
				return;
			}
			if (UseUnscaledTime)
			{
				_seconds += Time.unscaledDeltaTime;
				return;
			}
			ITimeManager timeManager = Game.Instance.FlightScene?.TimeManager;
			if (timeManager == null)
			{
				_seconds += Time.deltaTime;
			}
			else if (!timeManager.Paused)
			{
				_seconds += timeManager.DeltaTime;
			}
		}
	}
}
