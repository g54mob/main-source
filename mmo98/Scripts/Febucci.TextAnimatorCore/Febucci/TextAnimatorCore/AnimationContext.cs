namespace Febucci.TextAnimatorCore
{
	public struct AnimationContext
	{
		public readonly float timeSinceStart;

		public readonly float deltaTime;

		public AnimationContext(float timeSinceStart, float deltaTime)
		{
			this.timeSinceStart = timeSinceStart;
			this.deltaTime = deltaTime;
		}
	}
}
