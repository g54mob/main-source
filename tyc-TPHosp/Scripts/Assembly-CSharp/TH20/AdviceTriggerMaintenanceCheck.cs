using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerMaintenanceCheck : AdviceTrigger
	{
		private string _outMessage;

		[InspectorMargin(8)]
		[InspectorHeader("Maintenance Check")]
		[InspectorTooltip("The maintenance job types that we care about a rage quit")]
		[SerializeField]
		private JobMaintenance.JobDescription _maintenanceType = JobMaintenance.JobDescription.BlockedToilet;

		[InspectorTooltip("The message to display when player has no janitors")]
		[FullInspector.InspectorName("No Janitors Message")]
		[SerializeField]
		private LocalisedString _noJanitorsMessageLocalised;

		[InspectorTooltip("Show an instant message if one of this type is not functional (used for Broken Machines)")]
		[SerializeField]
		private bool _showInstantMessage;

		[InspectorTooltip("Should the message format the message to show which machines is broken (used for Broken Machines)")]
		[SerializeField]
		private bool _formatStringWithBrokenItemName;

		[InspectorTooltip("Number of jobs of this type per janitor to trigger a low priority message")]
		[SerializeField]
		private float _jobsPerJanitorLowPri = 3f;

		[InspectorTooltip("Number of jobs of this type per janitor to trigger a medium priority message")]
		[SerializeField]
		private float _jobsPerJanitorMedPri = 4f;

		[InspectorTooltip("Number of jobs of this type per janitor to trigger a high priority message")]
		[SerializeField]
		private float _jobsPerJanitorHiPri = 5f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.Definition._type == StaffDefinition.Type.Janitor)
				{
					num++;
				}
			}
			int num2 = 0;
			foreach (Job allJob in Level.StaffWorkScheduler.AllJobs)
			{
				if (allJob is JobMaintenance jobMaintenance && !jobMaintenance.Item.IsFunctional() && jobMaintenance.Item.Definition.MaintenanceDescription == _maintenanceType)
				{
					num2++;
					if (_showInstantMessage)
					{
						_outMessage = BuildMessage(jobMaintenance.Item, num);
						return Advisor.PriorityLevel.VeryHigh;
					}
				}
			}
			if (num <= 0)
			{
				if ((float)num2 >= _jobsPerJanitorLowPri)
				{
					_outMessage = BuildMessage(null, num);
					return Advisor.PriorityLevel.VeryHigh;
				}
				return Advisor.PriorityLevel.DontShow;
			}
			float num3 = (float)num2 / (float)num;
			if (num3 < _jobsPerJanitorLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			_outMessage = BuildMessage(null, num);
			if (num3 < _jobsPerJanitorMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 < _jobsPerJanitorHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}

		private string BuildMessage(RoomItem item, int numJanitors)
		{
			if (item != null && _formatStringWithBrokenItemName)
			{
				return LocalisedString.Replace((numJanitors <= 0) ? _noJanitorsMessageLocalised.Translation : MessageLocalised.Translation, "{[ITEM]}", item.LocalisedName);
			}
			if (numJanitors > 0)
			{
				return MessageLocalised.Translation;
			}
			return _noJanitorsMessageLocalised.Translation;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _outMessage;
			return result;
		}
	}
}
