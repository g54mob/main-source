using System;
using System.Collections.Generic;
using FixMath;

namespace Motorways
{
	[Serializable]
	public class ScheduleChunk
	{
		public float startDay;

		public float duration;

		public bool buildingsAreOrdered;

		public Fix64 spawnVariability = Fix64Consts.OneHalf;

		public List<PlannedBuilding> plannedBuildings;
	}
}
