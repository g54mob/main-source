using Unity.Profiling;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class CpuFrameTimeProvider : APerformanceProvider
	{
		public const string CName = "CPU";

		private ProfilerRecorder recorderCpu;

		private float lastValue;

		public override string Name => "CPU";

		public override bool IsSupported => true;

		public override string Unit => "ms";

		protected override void Awake()
		{
			base.Awake();
			recorderCpu = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread");
		}

		private void FixedUpdate()
		{
			lastValue = (float)recorderCpu.LastValue * 1E-06f;
		}

		protected override float GetNextValue()
		{
			return lastValue;
		}
	}
}
