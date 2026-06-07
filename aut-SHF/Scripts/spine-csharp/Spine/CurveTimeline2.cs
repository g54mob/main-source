namespace Spine
{
	public abstract class CurveTimeline2 : CurveTimeline
	{
		public const int ENTRIES = 3;

		internal const int VALUE1 = 1;

		internal const int VALUE2 = 2;

		public override int FrameEntries => 0;

		public CurveTimeline2(int frameCount, int bezierCount, string propertyId1, string propertyId2)
			: base(0, 0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, float value1, float value2)
		{
		}
	}
}
