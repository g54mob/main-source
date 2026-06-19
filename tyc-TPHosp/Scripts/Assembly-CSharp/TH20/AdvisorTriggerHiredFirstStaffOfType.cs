using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerHiredFirstStaffOfType : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerHiredFirstStaffOfTypeDefinition _definition;

		[SerializeField]
		private string _cachedWorkPlace;

		[SerializeField]
		private StaffDefinition _cachedStaffType;

		public AdvisorTriggerHiredFirstStaffOfType(AdvisorTriggerHiredFirstStaffOfTypeDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Job allJob in Level.StaffWorkScheduler.AllJobs)
			{
				if (!allJob.Available())
				{
					continue;
				}
				JobRoom jobRoom = allJob as JobRoom;
				JobService jobService = allJob as JobService;
				if (jobRoom == null && jobService == null)
				{
					continue;
				}
				StaffDefinition definition = allJob.StaffRequired().Definition;
				StaffDefinition.Type type = definition._type;
				if (Level.CharacterManager.GetStaffOfTypeCount(type) <= 0)
				{
					if (jobRoom != null)
					{
						_cachedWorkPlace = jobRoom.Room.Definition.GetLocalisedName();
					}
					else
					{
						_cachedWorkPlace = jobService.RoomItemDefinition.GetLocalisedName();
					}
					_cachedStaffType = definition;
					return Advisor.PriorityLevel.VeryHigh;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = LocalisedString.Replace(_definition.MessageLocalised.Translation, new SubPair[2]
			{
				new SubPair("{[ROOM]}", _cachedWorkPlace),
				new SubPair("{[STAFF]}", GameStringUtils.GetStaffTypeTextLoc(_cachedStaffType._type))
			});
			result.Icon = _cachedStaffType._icon;
			return result;
		}
	}
}
