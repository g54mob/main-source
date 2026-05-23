namespace Spine
{
	public abstract class Timeline
	{
		private readonly string[] propertyIds;

		internal readonly float[] frames;

		public string[] PropertyIds => null;

		public float[] Frames => null;

		public virtual int FrameEntries => 0;

		public virtual int FrameCount => 0;

		public float Duration => 0f;

		public Timeline(int frameCount, params string[] propertyIds)
		{
		}

		public abstract void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction);

		internal static int Search(float[] frames, float time)
		{
			return 0;
		}

		internal static int Search(float[] frames, float time, int step)
		{
			return 0;
		}
	}
}
