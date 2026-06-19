using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VIPAppraisalCriteriaRangesConfig
	{
		[InspectorMargin(10)]
		[InspectorHeader("Environment")]
		public float EnvironmentAttractivenessMin;

		public float EnvironmentAttractivenessMax;

		public float EnvironmentTemperatureMin;

		public float EnvironmentTemperatureSweetSpotMin;

		public float EnvironmentTemperatureSweetSpotMax;

		public float EnvironmentTemperatureMax;

		public float EnvironmentHygieneMin;

		public float EnvironmentHygieneMax;

		[InspectorMargin(10)]
		[InspectorHeader("Staff")]
		public float StaffHappinessMin;

		public float StaffHappinessMax;

		public float StaffEnergyMin;

		public float StaffEnergyMax;

		public float StaffRankQualificationMin;

		public float StaffRankQualificationMax;

		[InspectorMargin(10)]
		[InspectorHeader("Patient")]
		public float PatientHappinessMin;

		public float PatientHappinessMax;

		public float PatientHealthMin;

		public float PatientHealthMax;

		[InspectorMargin(10)]
		[InspectorHeader("Misc")]
		public float ItemMaintenanceMin;

		public float ItemMaintenanceMax;

		public float HospitalEcoRatingMin;

		public float HospitalEcoRatingMax;

		public float RoomPrestigeMin;

		public float RoomPrestigeMax;

		[InspectorMargin(10)]
		[InspectorHeader("Observation Location Weights")]
		public float CorridorObservationMultiplier;

		public float RoomObservationMultiplier;
	}
}
