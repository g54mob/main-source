using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new SpreadHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Spread")]
	public class SpreadHideAnimation : TMPHideAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public TMPParameterTypes.TypedVector2 anchor;

			public Vector3 direction;

			public float startPercentage;

			public float targetPercentage;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the percentages.\nAliases: curve, crv, c")]
		private AnimationCurve curve;

		[SerializeField]
		[AutoParameter("anchor", new string[] { "anc", "a" })]
		[Tooltip("The anchor from where the character spreads.\nAliases: anchor, anc, a")]
		private TMPParameterTypes.TypedVector2 anchor;

		[SerializeField]
		[AutoParameter("direction", new string[] { "dir" })]
		[Tooltip("The direction in which the character spreads.\nAliases: direction, dir")]
		private Vector3 direction;

		[SerializeField]
		[AutoParameter("startpercentage", new string[] { "start" })]
		[Tooltip("The start percentage of the spread, 0 being fully hidden.\nAliases: startpercentage, start")]
		private float startPercentage;

		[SerializeField]
		[AutoParameter("targetpercentage", new string[] { "target" })]
		[Tooltip("The target percentage of the spread, 1 being fully shown.\nAliases: targetpercentage, target")]
		private float targetPercentage;

		private void Grow(CharData cData, IAnimationContext context, AutoParametersData d, float t)
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
