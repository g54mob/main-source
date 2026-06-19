using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardEpidemicCured : IRewardChallenge
	{
		[SerializeField]
		private int _pricePerPerson;

		public override void Apply(Objective objective, Level level)
		{
			level.FinanceManager.OnMoneyAwarded.InvokeSafe(GetCashPrize(objective));
		}

		public override int GetCashPrize(Objective objective)
		{
			if (!(objective is ChallengeEpidemic challengeEpidemic))
			{
				return 0;
			}
			return challengeEpidemic.NumberCured * _pricePerPerson;
		}

		public override string Description(Objective objective)
		{
			if (objective.State == Objective.ObjectiveState.Undiscovered || objective.State == Objective.ObjectiveState.Active)
			{
				return LocalisedString.Replace(ScriptLocalization.Challenges.Epidemic_RewardCuredBonusPerPerson_CS, "{[BONUS]}", StringUtils.FormatCurrency(_pricePerPerson));
			}
			return LocalisedString.Replace(ScriptLocalization.Challenges.Epidemic_RewardCuredBonus_CS, "{[BONUS]}", StringUtils.FormatCurrency(GetCashPrize(objective)));
		}
	}
}
