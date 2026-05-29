using Unity.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class GpuTrianglesProvider : APerformanceProvider
	{
		public const string CName = "Tris";

		private ProfilerRecorder triangleCountRecorder;

		public override string Name => "Tris";

		public override bool IsSupported => true;

		public override string Unit => "";

		protected override void Awake()
		{
			base.Awake();
			triangleCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count");
		}

		protected override float GetNextValue()
		{
			return triangleCountRecorder.LastValue;
		}
	}
}
