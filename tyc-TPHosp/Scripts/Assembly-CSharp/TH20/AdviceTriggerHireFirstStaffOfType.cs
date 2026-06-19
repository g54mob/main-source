using System.Linq;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerHireFirstStaffOfType : AdviceTrigger
	{
		private string _cachedWorkPlace;

		private StaffDefinition _cachedStaffType;

		public override Advisor.PriorityLevel GetMessagePriority()
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
				StaffDefinition.Type staffType = definition._type;
				if (Level.CharacterManager.StaffMembers.Count((Staff staff) => staff.Definition._type == staffType) <= 0)
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
			result.Message = LocalisedString.Replace(MessageLocalised.Translation, new SubPair[2]
			{
				new SubPair("{[ROOM]}", _cachedWorkPlace),
				new SubPair("{[STAFF]}", GameStringUtils.GetStaffTypeTextLoc(_cachedStaffType._type))
			});
			result.Icon = _cachedStaffType._icon;
			return result;
		}
	}
}
