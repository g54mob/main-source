using UnityEngine;

namespace Brewery.Face
{
	[CreateAssetMenu(menuName = "Brewery/Face/Face Expression", order = 110)]
	public class FaceExpression : ScriptableObject
	{
		[Header("Identity")]
		public string displayName;

		[Header("Static Pose (always applied)")]
		[Tooltip("Blendshape weights held for the lifetime of the expression. Use FaceBlendshape constants for the names.")]
		public FacePose basePose;

		[Header("Optional Animated Layer")]
		[Tooltip("Optional curve-driven blendshapes (only used in OneShot/Loop play modes).")]
		public FacePose animated;

		[Tooltip("One curve per entry in 'animated'. Each curve evaluates 0..1 over expressionDuration.")]
		public AnimationCurve[] animatedCurves;

		[Header("Timing")]
		[Tooltip("Length of one OneShot/Loop cycle, in seconds.")]
		public float duration;

		[Header("Envelope")]
		[Tooltip("Master intensity multiplier (0..1).")]
		[Range(0f, 1f)]
		public float intensity;
	}
}
