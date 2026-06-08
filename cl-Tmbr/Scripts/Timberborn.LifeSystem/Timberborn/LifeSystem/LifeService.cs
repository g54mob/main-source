using Timberborn.BlueprintSystem;
using Timberborn.SingletonSystem;
using Timberborn.TimeSystem;
using UnityEngine;

namespace Timberborn.LifeSystem
{
	public class LifeService : ILoadableSingleton
	{
		private int _averageLifespan;

		private int _daysOfChildhood;

		private readonly IDayNightCycle _dayNightCycle;

		private readonly ISpecService _specService;

		public int AverageLifespan => _averageLifespan;

		private int DaysOfAdulthood => _averageLifespan - _daysOfChildhood;

		public LifeService(IDayNightCycle dayNightCycle, ISpecService specService)
		{
			_dayNightCycle = dayNightCycle;
			_specService = specService;
		}

		public void Load()
		{
			LifeServiceSpec singleSpec = _specService.GetSingleSpec<LifeServiceSpec>();
			_averageLifespan = singleSpec.AverageLifespan;
			_daysOfChildhood = singleSpec.DaysOfChildhood;
		}

		public float ChildhoodProgressToLifeProgress(float childhoodProgress)
		{
			return childhoodProgress * (float)_daysOfChildhood / (float)_averageLifespan;
		}

		public float AdulthoodProgressToLifeProgress(float adulthoodProgress)
		{
			return (adulthoodProgress * (float)DaysOfAdulthood + (float)_daysOfChildhood) / (float)_averageLifespan;
		}

		public int CalculateDayOfBirth(float lifeProgress)
		{
			return _dayNightCycle.DayNumber - Mathf.RoundToInt(lifeProgress * (float)_averageLifespan);
		}

		public float CalculateGrowthProgress(float deltaTimeInHours)
		{
			int num = _daysOfChildhood * 24;
			return deltaTimeInHours / (float)num;
		}
	}
}
