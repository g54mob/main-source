namespace UniHumanoid
{
	public class ChannelCurve
	{
		public float[] Keys { get; private set; }

		public ChannelCurve(int frameCount)
		{
			Keys = new float[frameCount];
		}

		public void SetKey(int frame, float value)
		{
			Keys[frame] = value;
		}
	}
}
