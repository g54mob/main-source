using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class CustomRuleLevelConfiguration : ScriptableObject
	{
		public List<CustomRuleData> defaultLevels;

		public List<CustomModeLevelProbabilities> probabilityByLevel;
	}
}
