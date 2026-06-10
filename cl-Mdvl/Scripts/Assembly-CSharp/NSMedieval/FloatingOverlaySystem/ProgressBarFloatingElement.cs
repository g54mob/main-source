using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.State.Timers;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public abstract class ProgressBarFloatingElement : FloatingElementBase
	{
		[SerializeField]
		private float flashEffectDuration = 0.6f;

		[SerializeField]
		private GameObject flashEffectBackground;

		private Timer timer;

		private bool isInverted;

		public float Value { get; private set; }

		public Timer Timer => timer;

		public void Setup(float value, bool isInverted = false)
		{
			Value = value;
			this.isInverted = isInverted;
			OnSetup();
		}

		public void Setup(Timer timer, bool isInverted = false)
		{
			this.timer = timer;
			Value = 0f;
			this.isInverted = isInverted;
			this.timer.TimerTick += OnTimerTick;
			OnSetup();
		}

		public override void Dispose()
		{
			base.Dispose();
			timer?.Dispose();
			timer = null;
		}

		public void SetIsInverted(bool isInverted)
		{
			this.isInverted = isInverted;
		}

		public void SetValue(float value)
		{
			if (timer != null)
			{
				Log.Error("This should never happen. You are doing something wrong gani :)", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\Elements\\ProgressBarFloatingElement.cs");
				return;
			}
			value = Mathf.Clamp(value, 0f, 1f);
			UpdateValue(value);
		}

		public void FlashEffect()
		{
			if (flashEffectBackground == null || flashEffectBackground.activeSelf || flashEffectDuration <= 0f)
			{
				return;
			}
			flashEffectBackground.SetActive(value: true);
			MonoSingleton<TaskController>.Instance.WaitFor(flashEffectDuration).Then(delegate
			{
				if (!(this == null) && !(flashEffectBackground == null))
				{
					flashEffectBackground.SetActive(value: false);
				}
			});
		}

		protected virtual void OnSetup()
		{
		}

		protected virtual void OnValueUpdated()
		{
		}

		private void UpdateValue(float newValue)
		{
			Value = newValue;
			OnValueUpdated();
		}

		private void OnTimerTick(float remainingTime)
		{
			float num = remainingTime / timer.TotalTime;
			if (isInverted)
			{
				num = 1f - num;
			}
			UpdateValue(num);
		}
	}
}
