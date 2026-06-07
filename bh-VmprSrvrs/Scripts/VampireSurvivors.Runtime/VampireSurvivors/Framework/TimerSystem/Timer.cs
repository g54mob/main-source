using System;
using UnityEngine;

namespace VampireSurvivors.Framework.TimerSystem
{
	public class Timer
	{
		protected static TimerManager _manager;

		protected readonly Action _onComplete;

		protected readonly Action<float> _onUpdate;

		protected float _startTime;

		protected float _lastUpdateTime;

		protected int _repeat;

		protected float? _timeElapsedBeforeCancel;

		protected float? _timeElapsedBeforePause;

		protected readonly MonoBehaviour _autoDestroyOwner;

		protected readonly bool _hasAutoDestroyOwner;

		protected bool _isOnlineTimer;

		protected bool _canPause;

		public float Duration { get; protected set; }

		public bool IsLooped { get; set; }

		public bool IsCompleted { get; protected set; }

		public bool UsesRealTime { get; protected set; }

		public bool IsPaused => false;

		public bool IsCancelled => false;

		public bool IsDone => false;

		public int RepeatCount => 0;

		protected bool IsOwnerDestroyed => false;

		public void Cancel()
		{
		}

		public void Complete(bool runAllRepeats = false)
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public float GetTimeElapsed()
		{
			return 0f;
		}

		public float GetTimeRemaining()
		{
			return 0f;
		}

		public float GetRatioComplete()
		{
			return 0f;
		}

		public float GetRatioRemaining()
		{
			return 0f;
		}

		public Timer(float duration, Action onComplete, Action<float> onUpdate, bool isLooped, bool usesRealTime, MonoBehaviour autoDestroyOwner, int repeat = 0, bool isMultiplayer = false, bool canPause = true)
		{
		}

		private void InitializeTime()
		{
		}

		private void AdjustStartTimeForOnlineDeSync()
		{
		}

		private float GetAdjustTime(float adjustTime)
		{
			return 0f;
		}

		protected float GetWorldTime()
		{
			return 0f;
		}

		protected float GetFireTime()
		{
			return 0f;
		}

		protected float GetTimeDelta()
		{
			return 0f;
		}

		public void Update()
		{
		}
	}
}
