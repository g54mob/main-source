using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;

namespace TMPEffects.TMPAnimations
{
	public interface ITMPAnimation : ITMPParameterValidator
	{
		void Animate(CharData cData, IAnimationContext context);

		void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		object GetNewCustomData();
	}
}
