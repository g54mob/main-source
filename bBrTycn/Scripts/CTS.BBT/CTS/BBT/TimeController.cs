using System;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT
{
	[DefaultExecutionOrder(-100)]
	public class TimeController : MonoSingleton<TimeController>, ILockable
	{
		[SerializeField]
		private TimeControllerData _timeControllerData;

		private ETimeModes _timeMode = ETimeModes.Normal;

		private float _gameScale = 1f;

		[SerializeField]
		[Range(0f, 4f)]
		private float _testScale = 1f;

		[field: SerializeField]
		public float _dayDurationInSeconds { get; private set; } = 5f;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public ETimeModes TimeMode
		{
			get
			{
				return _timeMode;
			}
			set
			{
				if (value != _timeMode && _timeControllerData.TimeModesScales.ContainsKey(value))
				{
					_timeMode = value;
					GameScale = _timeControllerData.TimeModesScales[value];
					TimeController.TimeModeChanged?.Invoke(value);
				}
			}
		}

		public float GameScale
		{
			get
			{
				return _gameScale;
			}
			private set
			{
				float num = Math.Max(0f, value);
				if (_gameScale != num)
				{
					_gameScale = num;
					if (ObjectLock.IsUnlocked())
					{
						ChangeScale(_gameScale);
					}
				}
			}
		}

		public static event Action<float> OnTimeScaleChanged;

		public static event Action<ETimeModes> TimeModeChanged;

		public int DaysSecondsConvertion(float seconds)
		{
			return (int)(seconds / _dayDurationInSeconds);
		}

		public int DaysMinutesConvertion(float minutes)
		{
			return DaysSecondsConvertion(minutes * 60f);
		}

		protected override void SingletonAwake()
		{
			_gameScale = Time.timeScale;
		}

		protected override void OnSingletonDestroy()
		{
			Time.timeScale = 1f;
		}

		void ILockable.OnLocked()
		{
			ChangeScale(0f);
		}

		void ILockable.OnUnlocked()
		{
			ChangeScale(_gameScale);
		}

		private static void ChangeScale(float p_scale)
		{
			Time.timeScale = p_scale;
			TimeController.OnTimeScaleChanged?.Invoke(Time.timeScale);
		}

		private void OnValidate()
		{
			if (Application.isPlaying)
			{
				ChangeScale(_testScale);
			}
		}
	}
}
