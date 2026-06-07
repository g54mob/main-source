using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/NeverTrue", fileName = "NeverTrue", order = 4)]
	public class NeverTrueSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		public override bool IsValid()
		{
			return false;
		}

		public override void Reset()
		{
		}
	}
}
