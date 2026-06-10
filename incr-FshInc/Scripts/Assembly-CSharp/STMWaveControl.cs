using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class STMWaveControl
{
	public AnimationCurve curveX = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	public AnimationCurve curveY = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	public AnimationCurve curveZ = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	public AnimationCurve multiOverTime = new AnimationCurve(new Keyframe(0f, 1f, 0f, 0f), new Keyframe(1f, 1f, 0f, 0f));

	[FormerlySerializedAs("offset")]
	[Range(0f, 1f)]
	[Tooltip("Timing offset compared to other waves.")]
	public float phase;

	[Tooltip("How fast the wave will move over time.")]
	public Vector3 speed = Vector3.zero;

	[Tooltip("Multiplier on the current wave value.")]
	public Vector3 strength = Vector3.zero;

	[Tooltip("Timing difference between letters.")]
	public Vector3 density = Vector3.zero;
}
