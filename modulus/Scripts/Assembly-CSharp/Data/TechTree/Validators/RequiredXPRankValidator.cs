using UnityEngine;

namespace Data.TechTree.Validators
{
	[CreateAssetMenu(menuName = "Tech Tree/Validators/Require XP Rank", fileName = "RequiredXPRankValidator")]
	public class RequiredXPRankValidator : AbstractTechTreeNodeValidator
	{
		[SerializeField]
		private int minRankRequired;

		[SerializeField]
		private RankConfigSO rankConfig;

		public int MinRankRequired => minRankRequired;

		public override bool CanBuy(TechTreeNodeSO node)
		{
			return rankConfig.GetCurrentRank() >= minRankRequired;
		}

		public override void Buy(TechTreeNodeSO node)
		{
		}
	}
}
