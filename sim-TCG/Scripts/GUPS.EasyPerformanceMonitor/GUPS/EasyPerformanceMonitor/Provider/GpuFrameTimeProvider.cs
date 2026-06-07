using GUPS.EasyPerformanceMonitor.Platform;
using Unity.Profiling;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class GpuFrameTimeProvider : APerformanceProvider
	{
		public const string CName = "GPU";

		private EPlatform platform;

		private ProfilerRecorder recorderGpu;

		private float fallBackValue;

		private float lastValue;

		public override string Name => "GPU";

		public override bool IsSupported => true;

		public override string Unit => "ms";

		protected override void Awake()
		{
			base.Awake();
			platform = PlatformHelper.GetCurrentPlatform();
			recorderGpu = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Camera.Render", 1, ProfilerRecorderOptions.SumAllSamplesInFrame | ProfilerRecorderOptions.GpuRecorder);
		}

		protected override void Update()
		{
			base.Update();
			fallBackValue = Time.unscaledDeltaTime * 1000f;
		}

		private void FixedUpdate()
		{
			lastValue = (float)recorderGpu.LastValue * 1E-06f;
			if (lastValue == 0f)
			{
				lastValue = fallBackValue;
			}
		}

		protected override float GetNextValue()
		{
			return lastValue;
		}
	}
}
