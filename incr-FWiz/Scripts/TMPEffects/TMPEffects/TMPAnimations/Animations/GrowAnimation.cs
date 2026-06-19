using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new GrowAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Grow")]
	public class GrowAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public float maxScale;

			public float minScale;

			public Wave wave;

			public OffsetBundle offsetProvider;
		}

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle offsetProvider;

		[SerializeField]
		[AutoParameter("maxscale", new string[] { "maxscl", "max" })]
		[Tooltip("The maximum scale to grow to.\nAliases: maxscale, maxscl, max")]
		private float maxScale;

		[SerializeField]
		[AutoParameter("minscale", new string[] { "minscl", "min" })]
		[Tooltip("The minimum scale to shrink to.\nAliases: minscale, minscl, min")]
		private float minScale;

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
