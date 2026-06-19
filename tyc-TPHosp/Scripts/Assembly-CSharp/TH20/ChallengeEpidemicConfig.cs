using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeEpidemicConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Epidemic Config")]
		public int NumberOfVaccines;

		public int NumberOfPeopleInitiallyInfected;

		public int NumberAllowedToLeaveHospital;

		public SharedInstance<CharacterStatusEffectDefinition> InfectionStatusEffect;

		public LocalisedString AdvisorMessageInfectedLeftHospital;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeEpidemic(this, level);
		}

		public override string GetDescriptionString(Objective objective, IReward[] rewards)
		{
			string replace = "\n" + RewardUtils.GetFullRewardString(objective, rewards);
			string replace2 = LocalisedString.Replace(ScriptLocalization.Challenges.Epidemic_Goal_CS, new SubPair[2]
			{
				new SubPair("{[INFECTED]}", NumberOfPeopleInitiallyInfected),
				new SubPair("{[VACCINES]}", NumberOfVaccines)
			});
			return LocalisedString.Replace(ScriptLocalization.Notification.StaffChallenge_ChallengeText_CS, new SubPair[4]
			{
				new SubPair("{[OBJECTIVE]}", replace2),
				new SubPair("{[TIMELIMIT]}", GetTimeLimitString()),
				new SubPair("{[REWARDS]}", replace),
				new SubPair("\\n", "\n")
			});
		}
	}
}
