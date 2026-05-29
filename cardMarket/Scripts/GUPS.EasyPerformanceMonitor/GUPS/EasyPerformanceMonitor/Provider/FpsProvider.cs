using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public class FpsProvider : APerformanceProvider
	{
		public const string CName = "FPS";

		private float lastValue;

		public override string Name => "FPS";

		public override bool IsSupported => true;

		public override string Unit => "fps";

		protected override void Update()
		{
			base.Update();
			lastValue = 1f / Time.unscaledDeltaTime;
		}

		protected override float GetNextValue()
		{
			return lastValue;
		}
	}
}
