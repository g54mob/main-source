using System;
using UnityEngine;

[Serializable]
public class STMWaveRotationControl
{
	public AnimationCurve curveZ = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	[Range(0f, 1f)]
	[Tooltip("Timing offset compared to other waves.")]
	public float phase;

	[Tooltip("How fast the wave will move over time.")]
	public float speed;

	[Tooltip("Multiplier on the current wave value.")]
	public float strength;

	[Tooltip("Timing difference between letters.")]
	public float density;

	[Tooltip("Origin position of this animation.")]
	public Vector2 pivot = Vector2.zero;
}
