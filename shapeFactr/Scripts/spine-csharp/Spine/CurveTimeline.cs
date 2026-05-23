namespace Spine
{
	public abstract class CurveTimeline : Timeline
	{
		public const int LINEAR = 0;

		public const int STEPPED = 1;

		public const int BEZIER = 2;

		public const int BEZIER_SIZE = 18;

		internal float[] curves;

		public CurveTimeline(int frameCount, int bezierCount, params string[] propertyIds)
			: base(0, (string[])null)
		{
		}

		public void SetLinear(int frame)
		{
		}

		public void SetStepped(int frame)
		{
		}

		public float GetCurveType(int frame)
		{
			return 0f;
		}

		public void Shrink(int bezierCount)
		{
		}

		public void SetBezier(int bezier, int frame, int value, float time1, float value1, float cx1, float cy1, float cx2, float cy2, float time2, float value2)
		{
		}

		public float GetBezierValue(float time, int frameIndex, int valueOffset, int i)
		{
			return 0f;
		}
	}
}
