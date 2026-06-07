using UnityEngine;

namespace UltimateReplay.Core
{
	internal sealed class ReplayTimer
	{
		private static float systemTimer;

		private float startTime = float.MinValue;

		private float interval = 1f;

		public float Interval
		{
			get
			{
				return interval;
			}
			set
			{
				interval = value;
			}
		}

		public float ElapsedSeconds => systemTimer - startTime;

		public ReplayTimer()
		{
		}

		public ReplayTimer(float interval)
		{
			this.interval = interval;
		}

		public static void Tick(bool fixedTime)
		{
			if (fixedTime)
			{
				systemTimer += Time.fixedDeltaTime;
			}
			else
			{
				systemTimer += Time.deltaTime;
			}
		}

		public bool HasElapsed()
		{
			return HasElapsed(interval);
		}

		public bool HasElapsed(float time)
		{
			if (systemTimer >= startTime + time)
			{
				Reset();
				return true;
			}
			return false;
		}

		public void Reset()
		{
			startTime = systemTimer;
		}
	}
}
