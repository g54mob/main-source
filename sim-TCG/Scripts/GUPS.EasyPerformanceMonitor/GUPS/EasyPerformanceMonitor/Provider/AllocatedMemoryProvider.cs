using UnityEngine.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class AllocatedMemoryProvider : APerformanceProvider
	{
		public const string CName = "Allocated Memory";

		public override string Name => "Allocated Memory";

		public override bool IsSupported => true;

		public override string Unit => "B";

		protected override float GetNextValue()
		{
			return Profiler.GetTotalAllocatedMemoryLong();
		}
	}
}
