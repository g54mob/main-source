using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new FadeHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Fade")]
	public class FadeHideAnimation : TMPHideAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public float targetOpacity;

			public Vector3 anchor;

			public Vector3 direction;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for fading out.\nAliases: curve, crv, c")]
		private AnimationCurve curve;

		[SerializeField]
		[AutoParameter("targetopacity", new string[] { "targetop", "target" })]
		[Tooltip("The opacity that is faded out to.\nAliases: targetopacity, targetop, target")]
		private float targetOpacity;

		[SerializeField]
		[AutoParameter("anchor", new string[] { "anc", "a" })]
		[Tooltip("The anchor that is faded out from.\nAliases: anchor, anc, a")]
		private Vector3 anchor;

		[SerializeField]
		[AutoParameter("direction", new string[] { "dir" })]
		[Tooltip("The direction used for fading out.\nAliases: direction, dir")]
		private Vector3 direction;

		private void FadeOut(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
		}

		private void FixAnchor(ref Vector2 v)
		{
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
		}

		public override object GetNewCustomData()
		{
			return null;
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
