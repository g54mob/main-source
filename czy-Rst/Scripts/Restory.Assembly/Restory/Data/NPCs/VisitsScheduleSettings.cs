using Restory.Data.Visits;
using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.NPCs
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/VisitsScheduleSettings", fileName = "VisitsScheduleSettings")]
	public class VisitsScheduleSettings : ScriptableObject
	{
		private static class Style
		{
			public const string VisitLimitsPerDayGroup = "Visit Limits Per Day";

			public const string TimeBetweenVisitsGroup = "Time Between Visits";

			public const string VisitsOrderGroup = "Visits Order";
		}

		[SerializeField]
		private int maxMorningVisitsPerDay = 3;

		[SerializeField]
		private int maxEveningVisitsPerDay = 3;

		[SerializeField]
		private int maxTotalVisitsPerDay = 10;

		[SerializeField]
		private NpcVisitsOrder morningSetupVisitsOrder = new NpcVisitsOrder(new NpcVisitDayQueueParameters[5]
		{
			new NpcVisitDayQueueParameters
			{
				Time = VisitTimeInterval.Morning,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Urgent
				}
			},
			new NpcVisitDayQueueParameters
			{
				AlreadyExistsInDayQueue = true,
				VisitType = new WorkOrderClaimingNpcVisit()
			},
			new NpcVisitDayQueueParameters
			{
				Time = VisitTimeInterval.Morning,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Common
				}
			},
			new NpcVisitDayQueueParameters
			{
				Time = VisitTimeInterval.AnyTime,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Urgent
				}
			},
			new NpcVisitDayQueueParameters
			{
				Time = VisitTimeInterval.AnyTime,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Common
				}
			}
		});

		[SerializeField]
		private NpcVisitsOrder eveningSetupVisitsOrder = new NpcVisitsOrder(new NpcVisitDayQueueParameters[6]
		{
			new NpcVisitDayQueueParameters
			{
				AlreadyExistsInDayQueue = true,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Urgent
				}
			},
			new NpcVisitDayQueueParameters
			{
				AlreadyExistsInDayQueue = true,
				VisitType = new WorkOrderClaimingNpcVisit()
			},
			new NpcVisitDayQueueParameters
			{
				Time = VisitTimeInterval.Evening,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Urgent
				}
			},
			new NpcVisitDayQueueParameters
			{
				Time = VisitTimeInterval.Evening,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Common
				}
			},
			new NpcVisitDayQueueParameters
			{
				AlreadyExistsInDayQueue = true,
				VisitType = new StoryNpcVisit
				{
					VisitType = StoryVisitType.Common
				}
			},
			new NpcVisitDayQueueParameters
			{
				AlreadyExistsInDayQueue = true,
				VisitType = new RandomNpcVisit()
			}
		});

		[SerializeField]
		private TimeOfDay minTimeBetweenVisits = new TimeOfDay(0, 30, 0);

		[SerializeField]
		private TimeOfDay maxTimeBetweenVisits = new TimeOfDay(2, 0, 0);

		public int MaxMorningVisitsPerDay => maxMorningVisitsPerDay;

		public int MaxEveningVisitsPerDay => maxEveningVisitsPerDay;

		public int MaxTotalVisitsPerDay => maxTotalVisitsPerDay;

		public NpcVisitsOrder MorningSetupVisitsOrder => morningSetupVisitsOrder;

		public NpcVisitsOrder EveningSetupVisitsOrder => eveningSetupVisitsOrder;

		public TimeOfDay MinTimeBetweenVisits => minTimeBetweenVisits;

		public TimeOfDay MaxTimeBetweenVisits => maxTimeBetweenVisits;
	}
}
