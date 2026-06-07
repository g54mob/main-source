namespace Febucci.TextAnimatorCore
{
	public struct DirectEffectContext
	{
		public float intensity01;

		public float deltaTime;

		public float timeSinceStart;

		public readonly bool isUpPositive;

		public DirectEffectContext(float intensity01, float deltaTime, float timeSinceStart, bool isUpPositive)
		{
			this.intensity01 = intensity01;
			this.deltaTime = deltaTime;
			this.timeSinceStart = timeSinceStart;
			this.isUpPositive = isUpPositive;
		}
	}
}
