using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[CreateAssetMenu(fileName = "new AnimationStack", menuName = "TMPEffects/Animations/Basic Animations/AnimationStack", order = -2147483648)]
	public class AnimationStackObject : TMPAnimation
	{
		[SerializeField]
		private BasicAnimationStack stack;

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
