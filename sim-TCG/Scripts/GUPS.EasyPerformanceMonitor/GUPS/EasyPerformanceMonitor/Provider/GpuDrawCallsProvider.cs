using Unity.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class GpuDrawCallsProvider : APerformanceProvider
	{
		public const string CName = "Gpu Draws";

		private ProfilerRecorder drawCallsCountRecorder;

		public override string Name => "Gpu Draws";

		public override bool IsSupported => true;

		public override string Unit => "";

		protected override void Awake()
		{
			base.Awake();
			drawCallsCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count");
		}

		protected override float GetNextValue()
		{
			return drawCallsCountRecorder.LastValue;
		}
	}
}
