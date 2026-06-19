using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class TimerManager : MustCallDestroy, IGameEventsBase
	{
		[SerializeField]
		private readonly Dictionary<string, Timer> _timers = new Dictionary<string, Timer>();

		[SerializeField]
		private readonly List<string> _expiredTimers = new List<string>();

		[NonSerialized]
		private readonly List<Timer> _timersToRemove = new List<Timer>();

		[NonSerialized]
		public Action<Timer> OnTimerFinished;

		public void VerifyEvents()
		{
			OnTimerFinished.VerifyIsNull();
		}

		public void CreateTimer(string name, bool useScaledTime, bool isLooping, float timerLength)
		{
			if (!_timers.ContainsKey(name))
			{
				Timer value = new Timer(name, useScaledTime, timerLength, isLooping);
				_timers.Add(name, value);
			}
		}

		public void CreateTimerRandom(string name, bool useScaledTime, bool isLooping, float minLength, float maxLength, bool rerandomise)
		{
			if (!_timers.ContainsKey(name))
			{
				Timer value = new Timer(name, useScaledTime, minLength, maxLength, isLooping, rerandomise);
				_timers.Add(name, value);
			}
		}

		public void ExpireTimer(string name, bool immediately)
		{
			if (_timers.TryGetValue(name, out var value))
			{
				if (immediately)
				{
					ExpireTimerImmediately(value.Name);
				}
				else
				{
					value.ExpireOnFinish = true;
				}
			}
		}

		public Timer FindTimer(string name)
		{
			_timers.TryGetValue(name, out var value);
			return value;
		}

		public bool HasTimerExpired(string name)
		{
			return _expiredTimers.Contains(name);
		}

		public void Update(float deltaTime, float unscaledDeltaTime)
		{
			_timersToRemove.Clear();
			foreach (KeyValuePair<string, Timer> timer in _timers)
			{
				Timer value = timer.Value;
				value.TimeRemaining -= (value.UseScaledTime ? deltaTime : unscaledDeltaTime);
				if (!(value.TimeRemaining > 0f))
				{
					OnTimerFinished.InvokeSafe(value);
					if (value.ExpireOnFinish)
					{
						_timersToRemove.Add(value);
					}
					else
					{
						value.Reset();
					}
				}
			}
			for (int i = 0; i < _timersToRemove.Count; i++)
			{
				ExpireTimerImmediately(_timersToRemove[i].Name);
			}
		}

		private void ExpireTimerImmediately(string name)
		{
			_expiredTimers.Add(name);
			_timers.Remove(name);
		}
	}
}
