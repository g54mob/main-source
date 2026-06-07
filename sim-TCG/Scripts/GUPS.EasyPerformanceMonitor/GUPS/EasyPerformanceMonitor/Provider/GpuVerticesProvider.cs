using Unity.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class GpuVerticesProvider : APerformanceProvider
	{
		public const string CName = "Verts";

		private ProfilerRecorder verticesCountRecorder;

		public override string Name => "Verts";

		public override bool IsSupported => true;

		public override string Unit => "";

		protected override void Awake()
		{
			base.Awake();
			verticesCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertices Count");
		}

		protected override float GetNextValue()
		{
			return verticesCountRecorder.LastValue;
		}
	}
}
