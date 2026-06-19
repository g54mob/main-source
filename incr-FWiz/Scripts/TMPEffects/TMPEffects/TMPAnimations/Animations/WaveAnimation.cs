using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new WaveAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Wave")]
	public class WaveAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public OffsetBundle offsetProvider;

			public Wave wave;
		}

		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		[SerializeField]
		[AutoParameterBundle(null)]
		private OffsetBundle offsetProvider;

		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		[SerializeField]
		[AutoParameterBundle(null)]
		private Wave wave;

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
