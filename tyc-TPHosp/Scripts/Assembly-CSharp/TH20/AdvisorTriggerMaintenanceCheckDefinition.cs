using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMaintenanceCheckDefinition : AdvisorTriggerDefinition
	{
		[Header("Maintenance Check")]
		[Tooltip("The maintenance job types that we care about a rage quit")]
		public JobMaintenance.JobDescription MaintenanceType = JobMaintenance.JobDescription.BlockedToilet;

		[Tooltip("The message to display when player has no janitors")]
		public LocalisedString NoJanitorsMessageLocalised;

		[Tooltip("Show an instant message if one of this type is not functional (used for Broken Machines)")]
		public bool ShowInstantMessage;

		[Tooltip("Should the message format the message to show which machines is broken (used for Broken Machines)")]
		public bool FormatStringWithBrokenItemName;

		[Tooltip("Number of jobs of this type per janitor to trigger a low priority message")]
		public float JobsPerJanitorLowPri = 3f;

		[Tooltip("Number of jobs of this type per janitor to trigger a medium priority message")]
		public float JobsPerJanitorMedPri = 4f;

		[Tooltip("Number of jobs of this type per janitor to trigger a high priority message")]
		public float JobsPerJanitorHiPri = 5f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerMaintenanceCheck(this);
		}
	}
}
