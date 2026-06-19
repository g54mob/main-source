using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientDeathDefinition : AdvisorTriggerDefinition
	{
		[Header("Patient Death")]
		[Tooltip("The number of days for which we care about a death")]
		public int NumDaysAfterDeath = 4;

		public float StaffSkillThreshold = 20f;

		public Sprite FatalIcon;

		public Sprite IneffectiveIcon;

		public LocalisedString HealthOtherText;

		public LocalisedString HealthHygieneText;

		public LocalisedString DiagnosisFatalText;

		public LocalisedString DiagnosisIneffectiveText;

		public LocalisedString StaffSkillFatalText;

		public LocalisedString StaffSkillIneffectiveText;

		public LocalisedString UpgradeFatalText;

		public LocalisedString UpgradeIneffectiveText;

		public LocalisedString OtherFatalText;

		public LocalisedString OtherIneffectiveText;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerPatientDeath(this);
		}
	}
}
