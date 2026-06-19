using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeSpecialPatientConfig : ChallengeConfig
	{
		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Special")]
		public int PatientCount = 1;

		public float PatientSpawnRate;

		[InspectorName("Diagnosis Complete %")]
		public float DiagnosisComplete;

		[InspectorName("Is Special Patient Name Plural")]
		public bool SpecialPatientNamePlural;

		public SharedInstance<IllnessDefinition>[] IllnessDefinition;

		public SharedInstance<ArrivalMethodDefinition> ArrivalMethod;

		public ChallengeSpecialPatient.ActionOnFail ActionOnFail;

		public SirenCharacterComponentConfig SirenCharacterComponentConfig;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeSpecialPatient(this, level);
		}

		public override string GetDescriptionString(Objective objective, IReward[] rewards)
		{
			ChallengeSpecialPatient challenge = objective as ChallengeSpecialPatient;
			IllnessDefinition instance = IllnessDefinition[0].Instance;
			bool flag = DiagnosisComplete < 100f;
			string text = (flag ? ScriptLocalization.Challenges_SubGoals.DiagnoseCurePatients_Goal_CS : ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllness_Goal_CS);
			LocalisationParams.Set("COUNT", PatientCount);
			text = LocalisationParams.Localise(ref text);
			text = text.Replace("{[ILLNESS]}", instance.Name.Translation);
			return LocalisedString.Replace(ScriptLocalization.Notification.PatientChallenge_ChallengeText_CS, new SubPair[5]
			{
				new SubPair("{[OBJECTIVE]}", text),
				new SubPair("{[TIMELIMIT]}", GetTimeLimitString()),
				new SubPair("{[ROOM]}", GetTreatmentRoomString(challenge, instance, flag)),
				new SubPair("{[REWARDS]}", GetRewardsString(objective, rewards)),
				new SubPair("\\n", "\n")
			});
		}

		private string GetTreatmentRoomString(ChallengeSpecialPatient challenge, IllnessDefinition illnessDefinition, bool diagnosisChallenge)
		{
			if (diagnosisChallenge)
			{
				return "";
			}
			string text = ScriptLocalization.Challenges.SpecialPatient_Room_Goal_CS;
			RoomDefinition treatmentRoom = illnessDefinition.GetTreatmentRoom(null, challenge.Level.ResearchManager);
			int value = challenge.Level.WorldState.CountRoomsOfType(treatmentRoom._type, includeClosed: true);
			LocalisationParams.Set("COUNT", value);
			text = LocalisationParams.Localise(ref text);
			return LocalisedString.Replace(text, "{[ROOM]}", treatmentRoom.GetLocalisedName());
		}
	}
}
