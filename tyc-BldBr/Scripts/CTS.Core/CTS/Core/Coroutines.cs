using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public static class Coroutines
	{
		private abstract class WaitForSecondsPooled : CustomYieldInstruction
		{
			public float EndTime { get; set; }

			public override bool keepWaiting
			{
				get
				{
					if (GetTime() < EndTime)
					{
						return true;
					}
					Reset();
					return false;
				}
			}

			public override void Reset()
			{
				Stack<WaitForSecondsPooled> pool = GetPool();
				if (!pool.Contains(this))
				{
					pool.Push(this);
				}
			}

			protected abstract float GetTime();

			protected abstract Stack<WaitForSecondsPooled> GetPool();
		}

		private class WaitForScaledSeconds : WaitForSecondsPooled
		{
			protected override float GetTime()
			{
				return Time.time;
			}

			protected override Stack<WaitForSecondsPooled> GetPool()
			{
				return _waitForScaledSeconds;
			}
		}

		private class WaitForUnscaledSeconds : WaitForSecondsPooled
		{
			protected override float GetTime()
			{
				return Time.unscaledTime;
			}

			protected override Stack<WaitForSecondsPooled> GetPool()
			{
				return _waitForUnscaledSeconds;
			}
		}

		private class WaitForRealtimeSeconds : WaitForSecondsPooled
		{
			protected override float GetTime()
			{
				return Time.realtimeSinceStartup;
			}

			protected override Stack<WaitForSecondsPooled> GetPool()
			{
				return _waitForRealtimeSeconds;
			}
		}

		private static readonly WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

		private static readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

		private static readonly Stack<WaitForSecondsPooled> _waitForScaledSeconds = new Stack<WaitForSecondsPooled>();

		private static readonly Stack<WaitForSecondsPooled> _waitForUnscaledSeconds = new Stack<WaitForSecondsPooled>();

		private static readonly Stack<WaitForSecondsPooled> _waitForRealtimeSeconds = new Stack<WaitForSecondsPooled>();

		public static WaitForEndOfFrame WaitForEndOfFrame()
		{
			return _waitForEndOfFrame;
		}

		public static WaitForFixedUpdate WaitForFixedUpdate()
		{
			return _waitForFixedUpdate;
		}

		public static YieldInstruction WaitForNextFrame()
		{
			return null;
		}

		public static CustomYieldInstruction WaitForSeconds(float duration)
		{
			if (!_waitForScaledSeconds.TryPop(out var result))
			{
				result = new WaitForScaledSeconds();
			}
			result.EndTime = Time.time + duration;
			return result;
		}

		public static CustomYieldInstruction WaitForSecondsUnscaled(float duration)
		{
			if (!_waitForUnscaledSeconds.TryPop(out var result))
			{
				result = new WaitForUnscaledSeconds();
			}
			result.EndTime = Time.unscaledTime + duration;
			return result;
		}

		public static CustomYieldInstruction WaitForSecondsRealtime(float duration)
		{
			if (!_waitForRealtimeSeconds.TryPop(out var result))
			{
				result = new WaitForRealtimeSeconds();
			}
			result.EndTime = Time.realtimeSinceStartup + duration;
			return result;
		}
	}
}
