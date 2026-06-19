using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[CreateAssetMenu(fileName = "new HideAnimationStack", menuName = "TMPEffects/Animations/Hide Animations/AnimationStack", order = int.MinValue)]
	public class HideAnimationStackObject : TMPHideAnimation
	{
		[SerializeField]
		private HideAnimationStack stack;

		public override void Animate(CharData cData, IAnimationContext context)
		{
			stack.Animate(cData, context);
		}

		public override object GetNewCustomData()
		{
			return stack.GetNewCustomData();
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			stack.SetParameters(customData, parameters, keywordDatabase);
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return stack.ValidateParameters(parameters, keywordDatabase);
		}
	}
}
