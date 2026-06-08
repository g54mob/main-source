using System;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	[Serializable]
	public class CustomRuleData
	{
		public CustomRuleType ruleType;

		[FormerlySerializedAs("level")]
		public int value;

		public CustomRuleData(CustomRuleType ruleType, int value)
		{
			this.ruleType = ruleType;
			this.value = value;
		}
	}
}
