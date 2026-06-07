using System;
using UnityEngine;

namespace Brewery.Face
{
	[CreateAssetMenu(menuName = "Brewery/Face/Face State Reaction Set", order = 111)]
	public class FaceStateReactionSet : ScriptableObject
	{
		[Serializable]
		public class Rule
		{
			[Tooltip("Must match an IFaceStateProbe.ProbeId on the character.")]
			public string probeId;

			[Tooltip("Network-replicated identifier for this mood. Choose None to make the rule LOCAL-ONLY (will not appear on remote viewers). Any other value is transmitted via FaceMoodNetworkSync so remote players see the same face reactions.")]
			public FaceMood mood;

			[Tooltip("FaceExpression to play while the probe is above the threshold.")]
			public FaceExpression expression;

			[Tooltip("Higher numbers run later in the source order (visual priority is purely additive).")]
			public int priority;

			[Tooltip("Probe value must exceed this for the expression to activate.")]
			[Range(0f, 1f)]
			public float threshold;

			[Tooltip("Remaps the raw probe 0..1 value into the intensity multiplier applied to the expression.")]
			public AnimationCurve intensityRemap;

			[Tooltip("Play mode used by the underlying FaceExpressionPlayer.")]
			public FaceExpressionPlayMode playMode;
		}

		public Rule[] rules;
	}
}
