using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientAttributeCheckDefinition : AdvisorTriggerDefinition
	{
		[Header("Patient Attribute Check")]
		[Tooltip("The patient attribute we are checking")]
		public CharacterAttributes.Type Attribute;

		[Tooltip("Minimum number of patients before we bother checking this attribute...")]
		public int MinPatientThreshold = 8;

		[Tooltip("If we are looking for the attribute to be 'LessThan' or 'GreaterThan' the 'Count Threshold'")]
		public bool LessThan;

		[Tooltip("The Count Threshold is the percentage the attribute must be 'LessThan' or 'GreaterThan' to be counted")]
		public float CountThreshold = 70f;

		[Tooltip("If count makes up over this percentage then trigger a low priority message")]
		public float LowPriPercentage = 0.3f;

		[Tooltip("If count makes up over this percentage then trigger a medium priority message")]
		public float MedPriPercentage = 0.45f;

		[Tooltip("If count makes up over this percentage then trigger a high priority message")]
		public float HighPriPercentage = 0.6f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerPatientAttributeCheck(this);
		}
	}
}
