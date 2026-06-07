using UnityEngine;

namespace MoreMountains.Tools
{
	public struct MMFadeInEvent
	{
		public int ID;

		public float Duration;

		public MMTweenType Curve;

		public bool IgnoreTimeScale;

		public Vector3 WorldPosition;

		private static MMFadeInEvent e;

		public MMFadeInEvent(float duration, MMTweenType tween, int id = 0, bool ignoreTimeScale = true, Vector3 worldPosition = default(Vector3))
		{
			ID = id;
			Duration = duration;
			Curve = tween;
			IgnoreTimeScale = ignoreTimeScale;
			WorldPosition = worldPosition;
		}

		public static void Trigger(float duration, MMTweenType tween, int id = 0, bool ignoreTimeScale = true, Vector3 worldPosition = default(Vector3))
		{
			e.ID = id;
			e.Duration = duration;
			e.Curve = tween;
			e.IgnoreTimeScale = ignoreTimeScale;
			e.WorldPosition = worldPosition;
			MMEventManager.TriggerEvent(e);
		}
	}
}
