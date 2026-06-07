using System;
using UnityEngine;

namespace VampireSurvivors.Framework.TimerSystem
{
	public class Timers
	{
		protected static TimerManagerGame _managerGame;

		protected static TimerManagerUI _managerUI;

		protected static TimerManagerAutomation _managerAutomation;

		public static Timer Register(float duration, Action onComplete, Action<float> onUpdate = null, bool isLooped = false, bool useRealTime = false, MonoBehaviour autoDestroyOwner = null, int repeat = 0, TimerType type = TimerType.GAME, bool isOnlineTimer = false, bool canPause = true)
		{
			return null;
		}

		public static void InitManagers()
		{
		}

		public static void Cancel(Timer timer)
		{
		}

		public static void Pause(Timer timer)
		{
		}

		public static void Resume(Timer timer)
		{
		}

		public static void CancelAllRegisteredTimers()
		{
		}

		public static void PauseAllRegisteredTimers()
		{
		}

		public static void ResumeAllRegisteredTimers()
		{
		}
	}
}
