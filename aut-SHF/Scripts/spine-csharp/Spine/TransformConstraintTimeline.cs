namespace Spine
{
	public class TransformConstraintTimeline : CurveTimeline
	{
		public const int ENTRIES = 7;

		private const int ROTATE = 1;

		private const int X = 2;

		private const int Y = 3;

		private const int SCALEX = 4;

		private const int SCALEY = 5;

		private const int SHEARY = 6;

		private readonly int constraintIndex;

		public override int FrameEntries => 0;

		public int TransformConstraintIndex => 0;

		public TransformConstraintTimeline(int frameCount, int bezierCount, int transformConstraintIndex)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float mixRotate, float mixX, float mixY, float mixScaleX, float mixScaleY, float mixShearY)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}

		public void GetCurveValue(out float rotate, out float x, out float y, out float scaleX, out float scaleY, out float shearY, float time)
		{
			rotate = default(float);
			x = default(float);
			y = default(float);
			scaleX = default(float);
			scaleY = default(float);
			shearY = default(float);
		}
	}
}
