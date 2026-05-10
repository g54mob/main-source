using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "GroupedStatisticBonusFactory", menuName = "BBT/Passives/Grouped Statistic Bonus Factory")]
	public class GroupedStatisticBonusFactory : ScriptableObject
	{
		[field: SerializeField]
		public StatisticBonusFactory BonusPassive { get; private set; }

		[field: SerializeField]
		public StatisticBonusFactory MalusPassive { get; private set; }

		[field: SerializeField]
		[field: Range(0f, 100f)]
		public float BonusPassiveChances { get; private set; } = 50f;

		public StatisticBonusFactory SelectPassive()
		{
			if (!(Random.Range(0f, 100f) <= BonusPassiveChances))
			{
				return MalusPassive;
			}
			return BonusPassive;
		}
	}
}
