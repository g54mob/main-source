using System.Collections.Generic;

namespace ModApi.Levels.Requirements
{
	public interface ILevelRequirement
	{
		List<ILevelRequirement> Dependencies { get; set; }

		string DisplayValue { get; }

		ILevel Level { get; }

		string Name { get; set; }

		LevelRequirementStatus Status { get; set; }

		LevelRequirementVisibilityType VisibilityType { get; set; }

		void AddDependency(ILevelRequirement dependency);

		void FlightUpdate();
	}
}
