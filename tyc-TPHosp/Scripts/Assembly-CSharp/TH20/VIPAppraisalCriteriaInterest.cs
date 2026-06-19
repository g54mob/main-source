using System;
using FullInspector;

namespace TH20
{
	[Serializable]
	public class VIPAppraisalCriteriaInterest
	{
		[InspectorHeader("Environment")]
		[InspectorName("Environment Attractiveness (average area) (-1 to 1)")]
		public float EnvironmentAttractiveness;

		[InspectorName("Environment Temperature (average area) (-1 to 1)")]
		public float EnvironmentTemperature;

		[InspectorName("Environment Hygiene (average area) (-1 to 1)")]
		public float EnvironmentHygiene;

		[InspectorHeader("Staff")]
		[InspectorName("Staff Happiness (-1 to 1)")]
		public float StaffHappiness;

		[InspectorName("Staff Energy (-1 to 1)")]
		public float StaffEnergy;

		[InspectorName("Staff Rank Qualification (-1 to 1)")]
		public float StaffRankQualification;

		[InspectorName("Staff Got Fired (1:True)")]
		public float StaffGotFired;

		[InspectorHeader("Patient")]
		[InspectorName("Patient Happiness (-1 to 1)")]
		public float PatientHappiness;

		[InspectorName("Patient Health (-1 to 1)")]
		public float PatientHealth;

		[InspectorName("Patient Rage Quitting (1:True)")]
		public float PatientRageQuitting;

		[InspectorName("Patient Is Dead (1:True)")]
		public float PatientIsDead;

		[InspectorName("Patient Is Cured (1:True)")]
		public float PatientIsCured;

		[InspectorName("Patient Treatment Ineffective (1:True)")]
		public float PatientTreatmentIneffective;

		[InspectorHeader("Room")]
		[InspectorName("Room Understaffed (1:True)")]
		public float RoomUnderstaffed;

		[InspectorName("Item Maintenance (-1 to 1)")]
		public float ItemMaintenance;

		[InspectorName("Waste Item (0:False 1:True)")]
		public float WasteItems;

		[InspectorName("Room Prestige (-1 to 1)")]
		public float RoomPrestige;

		[InspectorHeader("Misc")]
		[InspectorName("Tour Too Short (1:True)")]
		public float TourTooShort;

		[InspectorName("Hospital Eco Rating (-3.0 to 3.0)")]
		public float HospitalEcoRating;
	}
}
