using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[CreateAssetMenu(fileName = "new HideAnimationStack", menuName = "TMPEffects/Animations/Hide Animations/AnimationStack", order = -2147483648)]
	public class HideAnimationStackObject : TMPHideAnimation
	{
		[SerializeField]
		private HideAnimationStack stack;

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
