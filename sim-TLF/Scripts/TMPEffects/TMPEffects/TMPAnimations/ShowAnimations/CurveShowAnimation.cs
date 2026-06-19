using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Modifiers;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[CreateAssetMenu(fileName = "new CurveShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Curve")]
	public class CurveShowAnimation : TMPShowAnimation
	{
		public TMPAnimation animation;

		public AnimationCurve curve;

		public float duration;

		public override void Animate(CharData cData, IAnimationContext context)
		{
			if (!(animation == null))
			{
				float num = context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData);
				float num2 = curve.Evaluate(num / duration);
				if (num > duration)
				{
					context.FinishAnimation(cData);
					return;
				}
				animation.Animate(cData, context);
				CharDataModifiers.LerpCharacterModifiersUnclamped(cData, cData.CharacterModifiers, 1f - num2, cData.CharacterModifiers);
				CharDataModifiers.LerpMeshModifiersUnclamped(cData, cData.MeshModifiers, 1f - num2, cData.MeshModifiers);
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (animation == null)
			{
				return false;
			}
			return animation.ValidateParameters(parameters, keywordDatabase);
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (!(animation == null))
			{
				animation.SetParameters(customData, parameters, keywordDatabase);
			}
		}

		public override object GetNewCustomData()
		{
			if (animation == null)
			{
				return null;
			}
			return animation.GetNewCustomData();
		}
	}
}
