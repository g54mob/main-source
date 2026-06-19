using System;
using UnityEngine;

namespace Minigames.Core
{
	public class ProgressTracker
	{
		private AnimationCurve _progressCurve;

		private float _totalRotation;

		private float _currentProgress;

		public float Progress => _currentProgress;

		public float TotalRotation => _totalRotation;

		public event Action<float> OnProgressChanged;

		public event Action OnCompleted;

		public event Action OnTightened;

		public ProgressTracker(AnimationCurve progressCurve)
		{
			_progressCurve = progressCurve;
			_totalRotation = 0f;
			_currentProgress = 0f;
		}

		public void SetProgress(float progress)
		{
			_currentProgress = Mathf.Clamp(progress, 0f, 2f);
			_totalRotation = FindRotationForProgress(_currentProgress);
			this.OnProgressChanged?.Invoke(_currentProgress);
			if (_currentProgress >= 2f)
			{
				this.OnCompleted?.Invoke();
			}
		}

		public void AddRotation(float angleDelta)
		{
			if (angleDelta > 0f)
			{
				_totalRotation += Mathf.Abs(angleDelta);
			}
			else
			{
				_totalRotation -= Mathf.Abs(angleDelta);
				_totalRotation = Mathf.Max(0f, _totalRotation);
			}
			UpdateProgress();
		}

		private void UpdateProgress()
		{
			float time = _totalRotation / 360f;
			_currentProgress = Mathf.Clamp(_progressCurve.Evaluate(time), 0f, 2f);
			this.OnProgressChanged?.Invoke(_currentProgress);
			if (_currentProgress >= 2f)
			{
				this.OnCompleted?.Invoke();
			}
		}

		private float FindRotationForProgress(float targetProgress)
		{
			if (targetProgress <= 0f)
			{
				return 0f;
			}
			float num = 0f;
			float num2 = 3600f;
			float num3 = 0.01f;
			while (num2 - num > num3)
			{
				float num4 = (num + num2) / 2f;
				float time = num4 / 360f;
				if (_progressCurve.Evaluate(time) < targetProgress)
				{
					num = num4;
				}
				else
				{
					num2 = num4;
				}
			}
			return (num + num2) / 2f;
		}

		public void Reset()
		{
			_totalRotation = 0f;
			_currentProgress = 0f;
			this.OnProgressChanged?.Invoke(_currentProgress);
		}
	}
}
