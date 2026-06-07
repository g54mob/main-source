using System;

namespace SimulationScripts.BibiteScripts
{
	[Flags]
	public enum TargetType
	{
		None = 0,
		Bibite = 1,
		Plant = 2,
		Meat = 4,
		Egg = 8
	}
}
