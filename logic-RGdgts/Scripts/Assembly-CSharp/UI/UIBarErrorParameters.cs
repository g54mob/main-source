namespace UI
{
	public struct UIBarErrorParameters
	{
		private float barDescentTime;

		private float barStaticTime;

		private UIBarErrorParameters(float barDescentTime, float barStaticTime)
		{
			this.barDescentTime = 0f;
			this.barStaticTime = 0f;
		}
	}
}
