using UnityEngine.Profiling;

namespace Pathfinding.Jobs
{
	internal static class JobDependencyAnalyzerAssociated
	{
		internal static CustomSampler getDependenciesSampler = CustomSampler.Create("GetDependencies");

		internal static CustomSampler iteratingSlotsSampler = CustomSampler.Create("IteratingSlots");

		internal static CustomSampler initSampler = CustomSampler.Create("Init");

		internal static CustomSampler combineSampler = CustomSampler.Create("Combining");

		internal static int[] tempJobDependencyHashes = new int[16];

		internal static int jobCounter = 1;
	}
}
