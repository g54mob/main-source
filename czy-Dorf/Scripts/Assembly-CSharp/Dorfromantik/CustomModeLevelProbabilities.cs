using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	[Serializable]
	public class CustomModeLevelProbabilities
	{
		public CustomRuleType ruleType;

		public List<float> probabilityByLevel;
	}
}
