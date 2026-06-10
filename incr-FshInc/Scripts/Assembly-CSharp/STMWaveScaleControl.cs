using System;
using UnityEngine;

[Serializable]
public class STMWaveScaleControl
{
	public AnimationCurve curveX = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	public AnimationCurve curveY = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	[Range(0f, 1f)]
	[Tooltip("Timing offset compared to other waves.")]
	public float phase;

	[Tooltip("How fast the wave will move over time.")]
	public Vector2 speed = Vector2.zero;

	[Tooltip("Multiplier on the current wave value.")]
	public Vector2 strength = Vector2.zero;

	[Tooltip("Timing difference between letters.")]
	public Vector2 density = Vector2.zero;

	[Tooltip("Origin position of this animation.")]
	public Vector2 pivot = Vector2.zero;
}
