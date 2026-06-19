using System;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class Fader
	{
		public enum FadeFunction
		{
			SmoothStep = 0,
			SmoothDerpLerp = 1,
			Sin = 2,
			Linear = 3,
			Pow = 4
		}

		public enum FadeDirection
		{
			In = 0,
			Out = 1,
			None = 2
		}

		public float delayFadeInTime;

		public float delayFadeOutTime;

		private float lastUpdateTimeStamp;

		private float from;

		private float to;

		private float fadeStartTimeStamp;

		private float fadeValue;

		private float fadeDuration;

		private FadeDirection fadeDirection = FadeDirection.None;

		public FadeFunction fadeFunction = FadeFunction.SmoothDerpLerp;

		public bool fractionalFading;

		private float v;

		private FadeFunction sin;

		public float GetFadeValue()
		{
			return fadeValue;
		}

		public float GetFadeDuration()
		{
			return fadeDuration;
		}

		public bool IsFading()
		{
			return fadeDirection != FadeDirection.None;
		}

		public bool IsFadingInOrHasFadedIn()
		{
			if (fadeDirection != FadeDirection.In)
			{
				return fadeValue >= 1f;
			}
			return true;
		}

		public bool IsFadingOutOrHasFadedOut()
		{
			if (fadeDirection != FadeDirection.Out)
			{
				return fadeValue <= 0f;
			}
			return true;
		}

		public Fader(float startFadeValue, FadeFunction _fadeFunction, float currentTime)
		{
			fadeDuration = float.PositiveInfinity;
			fadeFunction = _fadeFunction;
			fadeValue = startFadeValue;
			from = startFadeValue;
			to = startFadeValue;
			fadeStartTimeStamp = currentTime;
		}

		public Fader(float startFadeValue, FadeFunction _fadeFunction)
			: this(startFadeValue, _fadeFunction, 0f)
		{
		}

		private float GetDelayTime()
		{
			return fadeDirection switch
			{
				FadeDirection.In => delayFadeInTime, 
				FadeDirection.Out => delayFadeOutTime, 
				_ => 0f, 
			};
		}

		private float GetTotalDurationWithDelays()
		{
			return fadeDuration + GetDelayTime();
		}

		public float UpdateFadeValue(float currentTime)
		{
			if (fadeDirection == FadeDirection.None)
			{
				return fadeValue;
			}
			float num = currentTime - fadeStartTimeStamp;
			if (GetTotalDurationWithDelays() <= float.Epsilon || Mathf.Abs(from - to) < 0.0001f || num > GetTotalDurationWithDelays())
			{
				fadeDirection = FadeDirection.None;
				fadeValue = to;
				return fadeValue;
			}
			if (currentTime - lastUpdateTimeStamp <= Mathf.Epsilon)
			{
				return fadeValue;
			}
			lastUpdateTimeStamp = currentTime;
			if (num < GetDelayTime())
			{
				return from;
			}
			num -= GetDelayTime();
			currentTime -= GetDelayTime();
			float num2 = num / (fadeDuration + float.Epsilon);
			switch (fadeFunction)
			{
			case FadeFunction.SmoothDerpLerp:
				fadeValue = Mathf.Lerp(from, to, num2);
				break;
			case FadeFunction.SmoothStep:
				fadeValue = Mathf.SmoothStep(from, to, num2);
				break;
			case FadeFunction.Sin:
			{
				float num6 = (1f - Mathf.Cos(num2 * MathF.PI)) / 2f;
				float num7 = from * (1f - num6) + to * num6;
				fadeValue = num7;
				break;
			}
			case FadeFunction.Linear:
			{
				float num5 = from * (1f - num2) + to * num2;
				fadeValue = num5;
				break;
			}
			case FadeFunction.Pow:
			{
				float num3 = Mathf.Pow(num2, 10f);
				float num4 = from * (1f - num3) + to * num3;
				fadeValue = num4;
				break;
			}
			default:
				Debug.LogError("Unsupported fader.");
				fadeValue = to;
				break;
			}
			return fadeValue;
		}

		public FadeDirection GetFadeDirection()
		{
			return fadeDirection;
		}

		public void FadeToAlpha(float to, float fadeDuration, float currentTime)
		{
			FadeToAlpha(fadeValue, to, fadeDuration, currentTime);
		}

		public void FadeToAlpha(float from, float to, float fadeDuration, float currentTime)
		{
			if (fractionalFading)
			{
				fadeDuration *= Mathf.Abs(from - to);
			}
			this.fadeDuration = fadeDuration;
			this.from = from;
			this.to = to;
			if (Mathf.Abs(from - to) < 0.0001f)
			{
				fadeDirection = FadeDirection.None;
				fadeValue = to;
				return;
			}
			lastUpdateTimeStamp = (fadeStartTimeStamp = currentTime);
			if (from < to - float.Epsilon)
			{
				fadeDirection = FadeDirection.In;
			}
			else if (from > to + float.Epsilon)
			{
				fadeDirection = FadeDirection.Out;
			}
			else
			{
				fadeDirection = FadeDirection.None;
			}
			UpdateFadeValue(currentTime);
		}

		public void FadeIn(float fadeDuration, float currentTime)
		{
			FadeToAlpha(1f, fadeDuration, currentTime);
		}

		public void FadeOut(float fadeDuration, float currentTime)
		{
			FadeToAlpha(0f, fadeDuration, currentTime);
		}

		public void FadeIn(float from, float fadeDuration, float currentTime)
		{
			FadeToAlpha(from, 1f, fadeDuration, currentTime);
		}

		public void FadeOut(float from, float fadeDuration, float currentTime)
		{
			FadeToAlpha(from, 0f, fadeDuration, currentTime);
		}

		public void ReInit(float startFadeValue, FadeFunction fadeFunction, float currentTime)
		{
			this.fadeFunction = fadeFunction;
			fadeDirection = FadeDirection.None;
			fadeValue = startFadeValue;
			from = startFadeValue;
			to = startFadeValue;
			UpdateFadeValue(currentTime);
		}

		public void StopFading(float value)
		{
			from = value;
			to = value;
			fadeValue = value;
			fadeDirection = FadeDirection.None;
		}

		public void StopFading()
		{
			fadeValue = (to = from);
			fadeDirection = FadeDirection.None;
		}

		public void SetFadeValue(float v, bool stopFading = true)
		{
			to = (from = (fadeValue = v));
			if (stopFading)
			{
				fadeDirection = FadeDirection.None;
			}
		}
	}
}
