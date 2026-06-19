using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMaintenanceCheck : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerMaintenanceCheckDefinition _definition;

		[SerializeField]
		private string _outMessage;

		private Vector3? _interestPoint;

		public AdvisorTriggerMaintenanceCheck(AdvisorTriggerMaintenanceCheckDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
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
				if (allJob is JobMaintenance jobMaintenance && !jobMaintenance.Item.IsFunctional() && jobMaintenance.Item.Definition.MaintenanceDescription == _definition.MaintenanceType)
				{
					num2++;
					if (_definition.ShowInstantMessage)
					{
						_outMessage = BuildMessage(jobMaintenance.Item, num);
						return Advisor.PriorityLevel.VeryHigh;
					}
				}
			}
			if (num <= 0)
			{
				if ((float)num2 >= _definition.JobsPerJanitorLowPri)
				{
					_outMessage = BuildMessage(null, num);
					return Advisor.PriorityLevel.VeryHigh;
				}
				return Advisor.PriorityLevel.DontShow;
			}
			float num3 = (float)num2 / (float)num;
			if (num3 < _definition.JobsPerJanitorLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			_outMessage = BuildMessage(null, num);
			if (num3 < _definition.JobsPerJanitorMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 < _definition.JobsPerJanitorHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _outMessage;
			result.CameraFocus = _interestPoint;
			return result;
		}

		private string BuildMessage(RoomItem item, int numJanitors)
		{
			if (item != null)
			{
				_interestPoint = item.WorldPosition;
			}
			else
			{
				_interestPoint = null;
			}
			if (item != null && _definition.FormatStringWithBrokenItemName)
			{
				return LocalisedString.Replace((numJanitors <= 0) ? _definition.NoJanitorsMessageLocalised.Translation : _definition.MessageLocalised.Translation, "{[ITEM]}", item.LocalisedName);
			}
			if (numJanitors > 0)
			{
				return _definition.MessageLocalised.Translation;
			}
			return _definition.NoJanitorsMessageLocalised.Translation;
		}
	}
}
