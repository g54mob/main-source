using NSMedieval.Extensions;

namespace NSMedieval.Goap
{
	public class GoalPriorityData
	{
		private string goalId;

		private float basePriority;

		private float priorityModifier;

		private float jobPriority;

		private float statsPriorityModifier;

		private float fixedPriority;

		private Goal goal;

		public string GoalId => goalId;

		public float BasePriority
		{
			get
			{
				return basePriority;
			}
			internal set
			{
				basePriority = value;
			}
		}

		public float PriorityModifier
		{
			get
			{
				return priorityModifier;
			}
			set
			{
				priorityModifier = value;
			}
		}

		public float JobPriority
		{
			get
			{
				return jobPriority;
			}
			set
			{
				jobPriority = value;
			}
		}

		public float StatsPriorityModifier
		{
			get
			{
				return statsPriorityModifier;
			}
			set
			{
				statsPriorityModifier = value;
			}
		}

		public float FixedPriority
		{
			get
			{
				return fixedPriority;
			}
			set
			{
				fixedPriority = value;
			}
		}

		public Goal Goal => goal;

		public float FinalPriority
		{
			get
			{
				if (!fixedPriority.IsCloseToZero())
				{
					return fixedPriority;
				}
				return statsPriorityModifier + basePriority + priorityModifier + jobPriority;
			}
		}

		public GoalPriorityData(Goal goal, float basePriority)
		{
			goalId = goal.Id;
			this.goal = goal;
			this.basePriority = basePriority;
			priorityModifier = 0f;
			jobPriority = 0.5f;
		}

		public void Dispose()
		{
			goal = null;
		}
	}
}
