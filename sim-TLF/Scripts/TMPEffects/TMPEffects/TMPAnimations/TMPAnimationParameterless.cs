using System.Collections.Generic;
using TMPEffects.Databases;

namespace TMPEffects.TMPAnimations
{
	public abstract class TMPAnimationParameterless : TMPAnimation
	{
		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return true;
		}
	}
}
