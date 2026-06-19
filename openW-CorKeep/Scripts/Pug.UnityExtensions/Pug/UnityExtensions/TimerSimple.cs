using UnityEngine;

namespace Pug.UnityExtensions
{
	public struct TimerSimple
	{
		public float lifespan;

		public bool unscaled;

		private float timerLastUpdate;

		private float timer;

		public bool isRunning { get; private set; }

		public float elapsedTime
		{
			get
			{
				Update();
				return timer;
			}
		}

		public float remainingTime => lifespan - elapsedTime;

		public bool isTimerElapsed => elapsedTime >= lifespan;

		public float elapsedRatio => elapsedTime / lifespan;

		public float invElapsedRatio => 1f - elapsedRatio;

		public float elapsedRatioLooping => Mathf.Repeat(elapsedRatio, 1f);

		public float elapsedRatioLoopingPingPong
		{
			get
			{
				float num = Mathf.Repeat(elapsedRatio, 1f);
				return 2f * ((num < 0.5f) ? num : (1f - num));
			}
		}

		public void SetTimer(float newTime)
		{
			timer = newTime;
		}

		public TimerSimple(float lifespan = 1f, bool unscaled = false, bool startTimer = false)
		{
			this.lifespan = lifespan;
			this.unscaled = unscaled;
			isRunning = false;
			timer = 0f;
			timerLastUpdate = 0f;
			if (startTimer)
			{
				Start();
			}
		}

		private void Update()
		{
			float num = (unscaled ? Time.unscaledTime : Time.time);
			if (isRunning)
			{
				timer += num - timerLastUpdate;
			}
			timerLastUpdate = num;
		}

		public void Stop()
		{
			isRunning = false;
		}

		public void Start(bool reset = true)
		{
			if (reset)
			{
				isRunning = false;
				timer = 0f;
			}
			Update();
			isRunning = true;
		}

		public void Start(float newLifespan, bool reset = true)
		{
			lifespan = newLifespan;
			Start(reset);
		}

		public void DelayedStart(float delay)
		{
			isRunning = false;
			timer = 0f - delay;
			Update();
			isRunning = true;
		}

		public void FastForward(float x)
		{
			timerLastUpdate -= x;
		}

		public static TimerSimple StartNew(float lifespan = 1f, bool unscaled = false)
		{
			return new TimerSimple(lifespan, unscaled, startTimer: true);
		}
	}
}
