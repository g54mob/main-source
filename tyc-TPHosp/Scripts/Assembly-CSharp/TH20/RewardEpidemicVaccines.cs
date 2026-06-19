using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardEpidemicVaccines : IRewardChallenge
	{
		[SerializeField]
		private int _pricePerVaccine;

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
			return challengeEpidemic.NumberOfVaccines * _pricePerVaccine;
		}

		public override string Description(Objective objective)
		{
			if (objective.State == Objective.ObjectiveState.Undiscovered || objective.State == Objective.ObjectiveState.Active)
			{
				return LocalisedString.Replace(ScriptLocalization.Challenges.Epidemic_RewardVaccinesBonus_CS, "{[BONUS]}", StringUtils.FormatCurrency(_pricePerVaccine));
			}
			return LocalisedString.Replace(ScriptLocalization.Challenges.Epidemic_RewardVaccinesLeftBonus_CS, "{[BONUS]}", StringUtils.FormatCurrency(GetCashPrize(objective)));
		}
	}
}
