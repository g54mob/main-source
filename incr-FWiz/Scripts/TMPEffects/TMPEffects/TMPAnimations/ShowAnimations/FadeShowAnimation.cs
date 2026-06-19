using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new FadeShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Built-in/Fade")]
	public class FadeShowAnimation : TMPShowAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public float startOpacity;

			public Vector3 anchor;

			public Vector3 direction;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully show the character.\nAliases: duration, dur, d")]
		private float duration;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for fading in.\nAliases: curve, crv, c")]
		private AnimationCurve curve;

		[SerializeField]
		[AutoParameter("startopacity", new string[] { "startop", "start" })]
		[Tooltip("The opacity that is faded in from.\nAliases: startopacity, startop, start")]
		private float startOpacity;

		[SerializeField]
		[AutoParameter("anchor", new string[] { "anc", "a" })]
		[Tooltip("The anchor that is faded in from.\nAliases: anchor, anc, a")]
		private Vector3 anchor;

		[SerializeField]
		[AutoParameter("direction", new string[] { "dir" })]
		[Tooltip("The direction used for fading in.\nAliases: direction, dir")]
		private Vector3 direction;

		private void FadeIn(CharData cData, IAnimationContext context, AutoParametersData d, float t)
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
