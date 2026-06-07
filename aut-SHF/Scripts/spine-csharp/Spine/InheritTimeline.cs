namespace Spine
{
	public class InheritTimeline : Timeline, IBoneTimeline
	{
		public const int ENTRIES = 2;

		public const int INHERIT = 1;

		private readonly int boneIndex;

		public int BoneIndex => 0;

		public override int FrameEntries => 0;

		public InheritTimeline(int frameCount, int boneIndex)
			: base(0, (string[])null)
		{
		}

		public void SetFrame(int frame, float time, Inherit inherit)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
		}
	}
}
