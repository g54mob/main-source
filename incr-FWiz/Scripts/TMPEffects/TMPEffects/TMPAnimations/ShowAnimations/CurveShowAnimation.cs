using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
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
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override object GetNewCustomData()
		{
			return null;
		}
	}
}
