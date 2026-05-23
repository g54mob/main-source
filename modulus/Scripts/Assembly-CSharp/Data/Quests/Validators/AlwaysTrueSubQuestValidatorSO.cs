using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/AlwaysTrue", fileName = "AlwaysTrue", order = 3)]
	public class AlwaysTrueSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		public override bool IsValid()
		{
			return true;
		}

		public override void Reset()
		{
		}
	}
}
