using System.Collections.Generic;
using FixMath;
using UnityEngine;

namespace Motorways
{
	public class CitySchedulePlanner : MonoBehaviour
	{
		public const int DaysInSchedule = 70;

		public List<ScheduleGroup> scheduleGroups = new List<ScheduleGroup>();

		public List<GroupDemandOscillation> demandOscillationData = new List<GroupDemandOscillation>();

		public List<ScheduleChunk> scheduleChunks = new List<ScheduleChunk>
		{
			new ScheduleChunk()
		};

		public ScheduleGroup GetScheduleGroup(int groupIndex)
		{
			return scheduleGroups.Find((ScheduleGroup group) => group.index == groupIndex);
		}

		public Fix64 GetOscillationForDemand(int groupIndex, Fix64 timeInDays)
		{
			if (!Diagnostics.Verify(demandOscillationData != null && demandOscillationData.Count > 0, "We have no demand oscillation for this city {0}! Defaulting to none.", base.name))
			{
				return Fix64.One;
			}
			GroupDemandOscillation groupDemandOscillation = null;
			foreach (GroupDemandOscillation demandOscillationDatum in demandOscillationData)
			{
				if (demandOscillationDatum.index == groupIndex)
				{
					groupDemandOscillation = demandOscillationDatum;
				}
			}
			if (Diagnostics.Verify(groupDemandOscillation != null, "Missing demand oscillation for group {0}. Defaulting to none", groupIndex))
			{
				return groupDemandOscillation.GetDemandAtDay(timeInDays);
			}
			return Fix64.One;
		}

		public int GetDemandOscillationPeriod(int groupIndex)
		{
			if (!Diagnostics.Verify(demandOscillationData != null && demandOscillationData.Count > 0, "We have no demand oscillation for this city {0}! Defaulting to no oscillation", base.name))
			{
				return 1;
			}
			GroupDemandOscillation groupDemandOscillation = demandOscillationData.Find((GroupDemandOscillation group) => group.index == groupIndex);
			if (Diagnostics.Verify(groupDemandOscillation != null, "We have no demand oscillation for group: {0}! Defaulting to none", groupIndex))
			{
				return groupDemandOscillation.periodInDays;
			}
			return 1;
		}
	}
}
