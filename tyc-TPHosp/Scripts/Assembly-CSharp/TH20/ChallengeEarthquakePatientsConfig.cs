using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeEarthquakePatientsConfig : ChallengeEarthquakeConfig
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

		public ChallengeEarthquakePatients.ActionOnFail ActionOnFail;

		public SirenCharacterComponentConfig SirenCharacterComponentConfig;

		public override Challenge CreateChallenge(Level level)
		{
			return new ChallengeEarthquakePatients(this, level);
		}
	}
}
