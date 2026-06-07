using System;
using UnityEngine;

namespace UI.ThreeDimensional
{
	public static class UIObject3DTimer
	{
		private static UIObject3DTimerComponent _timerComponent;

		private static UIObject3DTimerComponent timerComponent => null;

		public static bool IsFirstFrame => false;

		private static bool IsQuitting { get; set; }

		[RuntimeInitializeOnLoadMethod]
		public static void OnLoad()
		{
		}

		public static WaitForSecondsRealtime GetWaitForSecondsRealtimeInstruction(float seconds)
		{
			return null;
		}

		public static WaitForSeconds GetWaitForSecondsInstruction(float seconds)
		{
			return null;
		}

		private static void EditorUpdate()
		{
		}

		public static void DelayedCall(float delay, Action action, MonoBehaviour actionTarget, bool forceEvenIfObjectIsInactive = false)
		{
		}

		public static void AtEndOfFrame(Action action, MonoBehaviour actionTarget, bool forceEvenIfObjectIsInactive = false)
		{
		}
	}
}
