using System;
using UnityEngine;

namespace DigitalRuby.Tween
{
	public class Tween<T> : ITween<T>, ITween where T : struct
	{
		private readonly Func<ITween<T>, T, T, float, T> lerpFunc;

		private float currentTime;

		private float duration;

		private Func<float, float> scaleFunc;

		private Action<ITween<T>> progressCallback;

		private Action<ITween<T>> completionCallback;

		private TweenState state;

		private T start;

		private T end;

		private T value;

		public object Key { get; set; }

		public float CurrentTime
		{
			get
			{
				return currentTime;
			}
		}

		public float Duration
		{
			get
			{
				return duration;
			}
		}

		public TweenState State
		{
			get
			{
				return state;
			}
		}

		public T StartValue
		{
			get
			{
				return start;
			}
		}

		public T EndValue
		{
			get
			{
				return end;
			}
		}

		public T CurrentValue
		{
			get
			{
				return value;
			}
		}

		public float Delay { get; set; }

		public GameObject GameObject { get; set; }

		public Renderer Renderer { get; set; }

		public bool ForceUpdate { get; set; }

		public float CurrentProgress { get; private set; }

		public Tween(Func<ITween<T>, T, T, float, T> lerpFunc)
		{
			this.lerpFunc = lerpFunc;
			state = TweenState.Stopped;
		}

		public void Start(T start, T end, float duration, Func<float, float> scaleFunc, Action<ITween<T>> progress, Action<ITween<T>> completion = null)
		{
			if (duration <= 0f)
			{
				value = end;
				if (progress != null)
				{
					progress(this);
				}
				if (completion != null)
				{
					completion(this);
				}
			}
			else
			{
				scaleFunc = scaleFunc ?? TweenScaleFunctions.Linear;
				currentTime = 0f;
				this.duration = duration;
				this.scaleFunc = scaleFunc;
				progressCallback = progress;
				completionCallback = completion;
				state = TweenState.Running;
				this.start = start;
				this.end = end;
				UpdateValue();
			}
		}

		public void Pause()
		{
			if (state == TweenState.Running)
			{
				state = TweenState.Paused;
			}
		}

		public void Resume()
		{
			if (state == TweenState.Paused)
			{
				state = TweenState.Running;
			}
		}

		public void Stop(TweenStopBehavior stopBehavior)
		{
			if (state == TweenState.Stopped)
			{
				return;
			}
			state = TweenState.Stopped;
			if (stopBehavior == TweenStopBehavior.Complete)
			{
				currentTime = duration;
				UpdateValue();
				if (completionCallback != null)
				{
					completionCallback(this);
					completionCallback = null;
				}
			}
		}

		public bool Update(float elapsedTime)
		{
			if (state == TweenState.Running)
			{
				if (Delay > 0f)
				{
					float delay = Delay;
					if ((Delay -= elapsedTime) >= 0f)
					{
						return false;
					}
					elapsedTime -= delay;
				}
				currentTime += elapsedTime;
				if (currentTime >= duration)
				{
					Stop(TweenStopBehavior.Complete);
					return true;
				}
				UpdateValue();
				return false;
			}
			return state == TweenState.Stopped;
		}

		private void UpdateValue()
		{
			if (Renderer == null || Renderer.isVisible || ForceUpdate)
			{
				CurrentProgress = scaleFunc(currentTime / duration);
				value = lerpFunc(this, start, end, CurrentProgress);
				if (progressCallback != null)
				{
					progressCallback(this);
				}
			}
		}
	}
}
