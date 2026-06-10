using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State.Timers;

namespace NSMedieval
{
	public abstract class BaseTimerController<T> : MonoSingleton<BaseTimerController<T>> where T : BaseTimer
	{
		[NonSerialized]
		private HashSet<T> timers;

		[NonSerialized]
		private List<T> timersAddedDuringTick;

		[NonSerialized]
		private List<T> timersRemovedDuringTick;

		private bool isTickingTimers;

		private readonly object lockObject = new object();

		protected abstract int InitialSetCapacity { get; }

		public void AddTimer(T timer)
		{
			lock (lockObject)
			{
				if (isTickingTimers)
				{
					timersAddedDuringTick.Add(timer);
				}
				else
				{
					timers.Add(timer);
				}
			}
		}

		public void RemoveTimer(T timer)
		{
			lock (lockObject)
			{
				if (isTickingTimers)
				{
					timersRemovedDuringTick.Add(timer);
				}
				else
				{
					timers.Remove(timer);
				}
			}
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnSceneLeaving;
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnSceneLeaving;
			lock (lockObject)
			{
				timers = new HashSet<T>(30000);
				timersAddedDuringTick = new List<T>(25);
				timersRemovedDuringTick = new List<T>(25);
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnSceneLeaving;
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnSceneLeaving;
			}
			base.OnDestroy();
			lock (lockObject)
			{
				StopAllTimers();
				timers?.Clear();
				timersRemovedDuringTick?.Clear();
				timersAddedDuringTick?.Clear();
				timers = null;
				timersRemovedDuringTick = null;
				timersAddedDuringTick = null;
			}
		}

		private void OnSceneLeaving()
		{
			lock (lockObject)
			{
				StopAllTimers();
				timers.Clear();
				timersAddedDuringTick.Clear();
				timersRemovedDuringTick.Clear();
			}
		}

		private void StopAllTimers()
		{
			if (timers != null)
			{
				foreach (T timer in timers)
				{
					timer.StopAndDetachCallbacks();
				}
			}
			if (timersAddedDuringTick != null)
			{
				foreach (T item in timersAddedDuringTick)
				{
					item.StopAndDetachCallbacks();
				}
			}
			if (timersRemovedDuringTick == null)
			{
				return;
			}
			foreach (T item2 in timersRemovedDuringTick)
			{
				item2.StopAndDetachCallbacks();
			}
		}

		protected abstract float GetDeltaTime();

		protected virtual void Update()
		{
			if (!MonoSingleton<BaseTimerController<T>>.IsInstantiated())
			{
				return;
			}
			float deltaTime = GetDeltaTime();
			isTickingTimers = true;
			lock (lockObject)
			{
				foreach (T timer in timers)
				{
					if (!timer.Paused && !timer.Completed)
					{
						timer.OnTimeTick(deltaTime);
					}
				}
				isTickingTimers = false;
				if (timersAddedDuringTick.Count > 0)
				{
					timers.UnionWith(timersAddedDuringTick);
					timersAddedDuringTick.Clear();
				}
				if (timersRemovedDuringTick.Count > 0)
				{
					timers.ExceptWith(timersRemovedDuringTick);
					timersRemovedDuringTick.Clear();
				}
			}
		}
	}
}
