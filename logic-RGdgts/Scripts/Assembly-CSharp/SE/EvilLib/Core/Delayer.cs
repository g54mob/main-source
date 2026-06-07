using System;
using System.Collections;
using UnityEngine;

namespace SE.EvilLib.Core
{
	public class Delayer : MonoBehaviour
	{
		public static AnimationCurve curveEaseInOut;

		public static Coroutine Frames(MonoBehaviour crExecutor, int frames, Action onWaitDone)
		{
			return null;
		}

		public static Coroutine Seconds(MonoBehaviour crExecutor, float seconds, Action onWaitDone)
		{
			return null;
		}

		public static Coroutine LerpFloat(MonoBehaviour crExecutor, float start, float end, float time, Action<float> onValueChange = null, Action onComplete = null)
		{
			return null;
		}

		private static IEnumerator CR_WaitFrames(int _frames, Action _onWaitDone, GameObject _goToDestroy)
		{
			return null;
		}

		private static IEnumerator CR_WaitSeconds(float _seconds, Action _onWaitDone, GameObject _goToDestroy)
		{
			return null;
		}

		private static IEnumerator CR_LerpFloat(float _from, float _to, float _timeTotal, Action<float> _onValueChange, Action _onComplete, GameObject _goToDestroy)
		{
			return null;
		}
	}
}
