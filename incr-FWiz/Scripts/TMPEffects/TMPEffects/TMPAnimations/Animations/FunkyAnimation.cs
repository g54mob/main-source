using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new FunkyAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Funky")]
	public class FunkyAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public float speed;

			public float squeezeFactor;

			public float amplitude;
		}

		[SerializeField]
		[AutoParameter("speed", new string[] { "sp", "s" })]
		[Tooltip("The speed at which the animation plays.\nAliases: speed, sp, s")]
		private float speed;

		[SerializeField]
		[AutoParameter("squeezefactor", new string[] { "squeeze", "sqz" })]
		[Tooltip("The percentage of its original size the text is squeezed to.\nAliases: squeezefactor, squeeze, sqz")]
		private float squeezeFactor;

		[SerializeField]
		[AutoParameter("amplitude", new string[] { "amp" })]
		[Tooltip("The amplitude the text pushes to the left / right.\nAliases: amplitude, amp")]
		private float amplitude;

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
