using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Controls3D
{
	public static class GuidancePulse3D
	{
		private struct PulseState
		{
			public int tweenId;

			public Vector3 originalScale;
		}

		private const float DefaultScale = 1.15f;

		private const float DefaultDuration = 0.5f;

		private static readonly Dictionary<GameObject, PulseState> activePulses;

		public static void Start(GameObject go, float pulsateScale = 1.15f, float pulsateDuration = 0.5f, Vector3 baseScale = default(Vector3))
		{
		}

		public static void Stop(GameObject go)
		{
		}

		public static bool IsPulsing(GameObject go)
		{
			return false;
		}

		public static void StopAll()
		{
		}
	}
}
