using UnityEngine.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class UsedMonoMemoryProvider : APerformanceProvider
	{
		public const string CName = "Used Mono Memory";

		public override string Name => "Used Mono Memory";

		public override bool IsSupported => true;

		public override string Unit => "B";

		protected override float GetNextValue()
		{
			return Profiler.GetMonoUsedSizeLong();
		}
	}
}
