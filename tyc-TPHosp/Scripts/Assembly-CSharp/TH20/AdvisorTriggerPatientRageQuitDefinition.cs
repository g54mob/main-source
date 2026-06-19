using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientRageQuitDefinition : AdvisorTriggerDefinition
	{
		[Header("Patient Rage Quit")]
		[Tooltip("The number of days for which we care about a rage quit")]
		public int NumDaysAfterRageQuit = 4;

		public LocalisedString RageQuitWaitingMessage;

		public LocalisedString RageQuitFurtherDiagnosisMessage;

		public LocalisedString RageQuitZeroHappinessMessage;

		public LocalisedString RageQuitNoComplaintsMessage;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerPatientRageQuit(this);
		}
	}
}
