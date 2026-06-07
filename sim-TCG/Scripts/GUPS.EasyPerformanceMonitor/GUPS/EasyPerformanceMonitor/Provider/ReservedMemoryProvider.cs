using UnityEngine.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class ReservedMemoryProvider : APerformanceProvider
	{
		public const string CName = "Reserved Memory";

		public override string Name => "Reserved Memory";

		public override bool IsSupported => true;

		public override string Unit => "B";

		protected override float GetNextValue()
		{
			return Profiler.GetTotalReservedMemoryLong();
		}
	}
}
