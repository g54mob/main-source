using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ShearAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Shear")]
	public class ShearAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class AnimData
		{
			public Wave wave;

			public OffsetBundle offset;
		}

		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		[AutoParameterBundle(null)]
		[SerializeField]
		private Wave wave;

		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		[AutoParameterBundle(null)]
		[SerializeField]
		private OffsetBundle offset;

		private void Animate(CharData cData, AnimData data, IAnimationContext context)
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
