using MoreMountains.Tools;

namespace MoreMountains.Feedbacks
{
	public struct TimeScaleProperties
	{
		public float TimeScale;

		public float Duration;

		public bool TimeScaleLerp;

		public float LerpSpeed;

		public bool Infinite;

		public MMTimeScaleLerpModes TimeScaleLerpMode;

		public MMTweenType TimeScaleLerpCurve;

		public float TimeScaleLerpDuration;

		public bool TimeScaleLerpOnUnfreeze;

		public MMTweenType TimeScaleLerpCurveOnUnfreeze;

		public float TimeScaleLerpDurationOnUnfreeze;

		public override string ToString()
		{
			return $"REQUESTED ts={TimeScale} time={Duration} lerp={TimeScaleLerp} speed={LerpSpeed} keep={Infinite}";
		}
	}
}
