using FullInspector;

namespace TH20
{
	public class RivalAmbulanceDepartmentDefinition : AmbulanceDepartmentDefinition
	{
		public SharedInstance<RivalFoundationDefinition> RivalFoundationDefinition;

		public int MaxSimultaneousDispatches;

		public int MinSecondsAmbulanceLeftIdle;

		public int MaxSecondsAmbulanceLeftIdle;

		[InspectorRange(-1f, 1f)]
		public float CureRateBonusPercentage;

		[InspectorDivider]
		[InspectorHeader("Preferences when responding to ambulance emergencies (favor less - favor more)")]
		[InspectorRange(0f, 2f)]
		public int Severity;

		[InspectorRange(0f, 2f)]
		public int Distance;

		[InspectorRange(0f, 2f)]
		public int PatientCount;

		[InspectorRange(0f, 2f)]
		[InspectorTooltip("More aggression means more likely to respond to emergencies the player has responded to")]
		public int Aggression;

		[InspectorRange(0f, 2f)]
		[InspectorTooltip("More focus means more likely send multiple ambulances to one emergency even when others are available")]
		public int Focus;
	}
}
