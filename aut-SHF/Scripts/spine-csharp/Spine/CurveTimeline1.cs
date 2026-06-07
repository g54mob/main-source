namespace Spine
{
	public abstract class CurveTimeline1 : CurveTimeline
	{
		public const int ENTRIES = 2;

		internal const int VALUE = 1;

		public override int FrameEntries => 0;

		public CurveTimeline1(int frameCount, int bezierCount, string propertyId)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float value)
		{
		}

		public float GetCurveValue(float time)
		{
			return 0f;
		}

		public float GetRelativeValue(float time, float alpha, MixBlend blend, float current, float setup)
		{
			return 0f;
		}

		public float GetAbsoluteValue(float time, float alpha, MixBlend blend, float current, float setup)
		{
			return 0f;
		}

		public float GetAbsoluteValue(float time, float alpha, MixBlend blend, float current, float setup, float value)
		{
			return 0f;
		}

		public float GetScaleValue(float time, float alpha, MixBlend blend, MixDirection direction, float current, float setup)
		{
			return 0f;
		}
	}
}
