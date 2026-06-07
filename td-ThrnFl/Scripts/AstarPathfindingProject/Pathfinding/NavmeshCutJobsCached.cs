using Unity.Burst;

namespace Pathfinding
{
	internal static class NavmeshCutJobsCached
	{
		public unsafe static readonly NavmeshCutJobs.CalculateContourDelegate CalculateContourBurst = BurstCompiler.CompileFunctionPointer<NavmeshCutJobs.CalculateContourDelegate>(NavmeshCutJobs.CalculateContour).Invoke;
	}
}
