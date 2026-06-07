using System;
using UnityEngine;

[Serializable]
public class UITween
{
	[Tooltip("Type of this UITween.")]
	public UITweener.Type Type;

	[Tooltip("Target position to move to.")]
	public Vector2 TargetPosition = Vector2.zero;

	[Tooltip("Duration for the tween.")]
	public float Duration = 1f;

	[Tooltip("Curve for tween to follow.")]
	public AnimationCurve Curve;
}
