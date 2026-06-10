using UnityEngine;

namespace MoreMountains.Tools
{
	public struct MMFadeEvent
	{
		public int ID;

		public float Duration;

		public float TargetAlpha;

		public MMTweenType Curve;

		public bool IgnoreTimeScale;

		public Vector3 WorldPosition;

		private static MMFadeEvent e;

		public MMFadeEvent(float duration, float targetAlpha, MMTweenType tween, int id = 0, bool ignoreTimeScale = true, Vector3 worldPosition = default(Vector3))
		{
			ID = id;
			Duration = duration;
			TargetAlpha = targetAlpha;
			Curve = tween;
			IgnoreTimeScale = ignoreTimeScale;
			WorldPosition = worldPosition;
		}

		public static void Trigger(float duration, float targetAlpha)
		{
			Trigger(duration, targetAlpha, new MMTweenType(MMTween.MMTweenCurve.EaseInCubic, "", ""));
		}

		public static void Trigger(float duration, float targetAlpha, MMTweenType tween, int id = 0, bool ignoreTimeScale = true, Vector3 worldPosition = default(Vector3))
		{
			e.ID = id;
			e.Duration = duration;
			e.TargetAlpha = targetAlpha;
			e.Curve = tween;
			e.IgnoreTimeScale = ignoreTimeScale;
			e.WorldPosition = worldPosition;
			MMEventManager.TriggerEvent(e);
		}
	}
}
