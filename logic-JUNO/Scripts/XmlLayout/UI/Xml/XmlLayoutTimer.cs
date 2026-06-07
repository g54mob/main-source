using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml
{
	public static class XmlLayoutTimer
	{
		private static Dictionary<float, WaitForSeconds> cachedDelays = new Dictionary<float, WaitForSeconds>();

		private static Dictionary<float, WaitForSecondsRealtime> cachedDelaysUnscaled = new Dictionary<float, WaitForSecondsRealtime>();

		private static XmlLayoutTimerComponent _timerComponent;

		private static XmlLayoutTimerComponent timerComponent
		{
			get
			{
				if (_timerComponent == null)
				{
					_timerComponent = UnityEngine.Object.FindObjectOfType<XmlLayoutTimerComponent>();
					if (_timerComponent == null)
					{
						GameObject gameObject = new GameObject("XmlLayoutTimer");
						_timerComponent = gameObject.AddComponent<XmlLayoutTimerComponent>();
						UnityEngine.Object.DontDestroyOnLoad(gameObject);
					}
				}
				return _timerComponent;
			}
		}

		public static bool IsFirstFrame => timerComponent.IsFirstFrame;

		public static WaitForSecondsRealtime GetWaitForSecondsRealtimeInstruction(float seconds)
		{
			if (!cachedDelaysUnscaled.ContainsKey(seconds))
			{
				cachedDelaysUnscaled.Add(seconds, new WaitForSecondsRealtime(seconds));
			}
			return cachedDelaysUnscaled[seconds];
		}

		public static WaitForSeconds GetWaitForSecondsInstruction(float seconds)
		{
			if (!cachedDelays.ContainsKey(seconds))
			{
				cachedDelays.Add(seconds, new WaitForSeconds(seconds));
			}
			return cachedDelays[seconds];
		}

		private static void EditorUpdate()
		{
		}

		public static void DelayedCall(float delay, Action action, MonoBehaviour actionTarget, bool forceEvenIfObjectIsInactive = false)
		{
			if (Application.isPlaying)
			{
				timerComponent.DelayedCall(delay, action, actionTarget, forceEvenIfObjectIsInactive);
			}
		}

		public static void AtEndOfFrame(Action action, MonoBehaviour actionTarget, bool forceEvenIfObjectIsInactive = false)
		{
			DelayedCall(0f, action, actionTarget, forceEvenIfObjectIsInactive);
		}
	}
}
