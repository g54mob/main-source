using System;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AudioSourceTime : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private bool IsForIA;

		private Action<float> _onTimeScaleChanged;

		public bool IsPausing { get; private set; }

		private void Awake()
		{
			_onTimeScaleChanged = delegate(float timeScale)
			{
				TimeChange(timeScale);
			};
		}

		private void OnDisable()
		{
			TimeController.OnTimeScaleChanged -= _onTimeScaleChanged;
		}

		private void OnDestroy()
		{
			TimeController.OnTimeScaleChanged -= _onTimeScaleChanged;
		}

		public void Pausing(bool Ispausing)
		{
			IsPausing = Ispausing;
		}

		public void SubscribeEvent()
		{
			TimeController.OnTimeScaleChanged -= _onTimeScaleChanged;
			TimeController.OnTimeScaleChanged += _onTimeScaleChanged;
			if (MonoSingleton<TimeController>.Instance.TimeMode != ETimeModes.Pause)
			{
				_audioSource.UnPause();
				Pausing(Ispausing: false);
				_audioSource.pitch = MonoSingleton<TimeController>.Instance.GameScale;
			}
		}

		public void UnsubscribeEvent()
		{
			TimeController.OnTimeScaleChanged -= _onTimeScaleChanged;
		}

		private void TimeChange(float obj)
		{
			if (!(_audioSource == null) && MonoSingleton<TimeController>.InstanceExists())
			{
				if (MonoSingleton<TimeController>.Instance.TimeMode == ETimeModes.Pause || obj == 0f)
				{
					_audioSource.Pause();
					Pausing(Ispausing: true);
				}
				else
				{
					_audioSource.UnPause();
					Pausing(Ispausing: false);
					_audioSource.pitch = MonoSingleton<TimeController>.Instance.GameScale;
				}
			}
		}
	}
}
