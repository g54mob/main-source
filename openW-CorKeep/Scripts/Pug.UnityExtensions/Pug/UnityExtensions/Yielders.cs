using System.Collections.Generic;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class Yielders
	{
		private class WaitForSecondsRealtime_Reusable : CustomYieldInstruction
		{
			private float waitTime = -1f;

			private bool _keepWaiting;

			public override bool keepWaiting
			{
				get
				{
					if (!_keepWaiting)
					{
						Debug.LogWarning("keepWaiting on stale WaitForSecondsRealtime_Reusable!");
						return false;
					}
					_keepWaiting = (double)Time.realtimeSinceStartup < (double)waitTime;
					if (!_keepWaiting)
					{
						cachedWaitForSecondsRealtime.Push(this);
					}
					return _keepWaiting;
				}
			}

			public void Recycle(float time)
			{
				waitTime = Time.realtimeSinceStartup + time;
				_keepWaiting = true;
			}
		}

		private static readonly int WFSRT_INITIAL_CAPACITY;

		private static readonly WaitForEndOfFrame cachedWaitForEndOfFrame;

		private static readonly WaitForFixedUpdate cachedWaitForFixedUpdate;

		private static readonly Dictionary<float, WaitForSeconds> cachedWaitForSeconds;

		private static readonly Stack<WaitForSecondsRealtime_Reusable> cachedWaitForSecondsRealtime;

		public static void Init()
		{
		}

		static Yielders()
		{
			WFSRT_INITIAL_CAPACITY = 16;
			cachedWaitForEndOfFrame = new WaitForEndOfFrame();
			cachedWaitForFixedUpdate = new WaitForFixedUpdate();
			cachedWaitForSeconds = new Dictionary<float, WaitForSeconds>(128);
			cachedWaitForSecondsRealtime = new Stack<WaitForSecondsRealtime_Reusable>(WFSRT_INITIAL_CAPACITY);
			for (int i = 0; i < WFSRT_INITIAL_CAPACITY; i++)
			{
				cachedWaitForSecondsRealtime.Push(new WaitForSecondsRealtime_Reusable());
			}
			cachedWaitForSeconds[0f] = new WaitForSeconds(0f);
			PreallocWaitForSeconds(1f, 60f);
			PreallocWaitForSeconds(2f, 30f);
			PreallocWaitForSeconds(3f, 10f);
			PreallocWaitForSeconds(4f, 10f);
			PreallocWaitForSeconds(5f, 10f);
			PreallocWaitForSeconds(8f, 10f);
			PreallocWaitForSeconds(10f, 10f);
			PreallocWaitForSeconds(12f, 1f);
			PreallocWaitForSeconds(15f, 1f);
			PreallocWaitForSeconds(20f, 1f);
			PreallocWaitForSeconds(25f, 1f);
			PreallocWaitForSeconds(30f, 1f);
			PreallocWaitForSeconds(40f, 1f);
			PreallocWaitForSeconds(60f, 3f);
			PreallocWaitForSeconds(100f, 1f);
		}

		private static void PreallocWaitForSeconds(float divider, float max)
		{
			int num = 1;
			float num2;
			do
			{
				num2 = (float)num / divider;
				cachedWaitForSeconds[num2] = new WaitForSeconds(num2);
				num++;
			}
			while (num2 < max);
		}

		public static CustomYieldInstruction PauseUnscaled(float t)
		{
			WaitForSecondsRealtime_Reusable waitForSecondsRealtime_Reusable = ((cachedWaitForSecondsRealtime.Count > 0) ? cachedWaitForSecondsRealtime.Pop() : new WaitForSecondsRealtime_Reusable());
			waitForSecondsRealtime_Reusable.Recycle(t);
			return waitForSecondsRealtime_Reusable;
		}

		public static WaitForSeconds Pause(float t)
		{
			if (!cachedWaitForSeconds.TryGetValue(t, out var value))
			{
				value = new WaitForSeconds(t);
				cachedWaitForSeconds[t] = value;
			}
			return value;
		}

		public static WaitForEndOfFrame WaitForEndOfFrame()
		{
			return cachedWaitForEndOfFrame;
		}

		public static WaitForFixedUpdate WaitForFixedUpdate()
		{
			return cachedWaitForFixedUpdate;
		}

		public static int GetUsage()
		{
			return cachedWaitForSecondsRealtime.Count + cachedWaitForSeconds.Count;
		}
	}
}
