using System;
using CTS.BBT.AI;

namespace CTS
{
	public class StationNeedFill : SimpleStation<StationNeedFillData>
	{
		public static Func<StationNeedFill, EAgentStatistics, bool> IsStatistic { get; } = (StationNeedFill furn, EAgentStatistics stat) => furn.Data.Stat == stat;

		public static Func<StationNeedFill, Agent, EAgentStatistics, bool> IsStatisticAndValidForAgent { get; } = delegate(StationNeedFill furn, Agent agent, EAgentStatistics stat)
		{
			if (furn.Data.Stat != stat)
			{
				return false;
			}
			return (!(agent is Worker { AssignationBypassNeeds: false } worker) || furn.IsInRoomAssignation(worker.RoomAssignations)) && furn.RoomObject.CurrentRoom.NavArea.IsInMask(agent.Movement.AreaMask);
		};
	}
}
