namespace LitMotion
{
	public static class LSequence
	{
		public static MotionSequenceBuilder Create()
		{
			return new MotionSequenceBuilder(MotionSequenceBuilderSource.Rent());
		}
	}
}
