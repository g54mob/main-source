using System;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Tools
{
	public static class TimerHelper
	{
		public static Timer RegisterSecs(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0, bool isOnlineTimer = false, bool canPause = true)
		{
			return null;
		}

		public static Timer RegisterMillis(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0, bool isOnlineTimer = false)
		{
			return null;
		}

		public static Timer RegisterSecsUI(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
		{
			return null;
		}

		public static Timer RegisterMillisUI(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
		{
			return null;
		}

		public static Timer RegisterSecsAutomation(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
		{
			return null;
		}

		public static Timer RegisterMillisAutomation(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0)
		{
			return null;
		}
	}
}
