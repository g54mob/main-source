using System.Collections.Generic;
using TMPEffects.Databases;

namespace TMPEffects.Parameters
{
	public interface ITMPParameterValidator
	{
		bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);
	}
}
