using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new GrowShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Built-in/Grow")]
	public class GrowShowAnimation : TMPShowAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public Vector3 startScale;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully show the character.\nAliases: duration, dur, d")]
		private float duration;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the scales.\nAliases: curve, crv, c")]
		private AnimationCurve curve;

		[SerializeField]
		[AutoParameter("startscale", new string[] { "startscl", "start" })]
		[Tooltip("The scale to start growing to the initial scale from.\nAliases: startscale, startscl, start")]
		private Vector3 startScale;

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
