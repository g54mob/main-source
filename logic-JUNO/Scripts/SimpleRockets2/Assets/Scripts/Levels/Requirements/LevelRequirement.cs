using System.Collections.Generic;
using ModApi.Levels;
using ModApi.Levels.Requirements;

namespace Assets.Scripts.Levels.Requirements
{
	public abstract class LevelRequirement : ILevelRequirement
	{
		public List<ILevelRequirement> Dependencies { get; set; }

		public bool DependenciesCurrentlySatisfied { get; private set; }

		public string DisplayValue { get; set; }

		public ILevel Level { get; }

		public string Name { get; set; }

		public LevelRequirementStatus Status { get; set; }

		public LevelRequirementVisibilityType VisibilityType { get; set; }

		public LevelRequirement(ILevel level, string name = null, LevelRequirementVisibilityType visibilityType = LevelRequirementVisibilityType.Visible)
		{
			Level = level;
			Name = name;
			VisibilityType = visibilityType;
		}

		public void AddDependency(ILevelRequirement dependency)
		{
			if (Dependencies == null)
			{
				Dependencies = new List<ILevelRequirement>();
			}
			Dependencies.Add(dependency);
		}

		public void FlightUpdate()
		{
			if (Status != LevelRequirementStatus.Fail)
			{
				DependenciesCurrentlySatisfied = true;
				if (Dependencies != null)
				{
					for (int i = 0; i < Dependencies.Count; i++)
					{
						if (Dependencies[i].Status != LevelRequirementStatus.Pass)
						{
							Status = LevelRequirementStatus.Incomplete;
							DependenciesCurrentlySatisfied = false;
							return;
						}
					}
				}
			}
			OnFlightUpdate();
		}

		protected virtual void OnFlightUpdate()
		{
		}
	}
}
