namespace Animancer
{
	public static class HybridAnimancerComponentExtensions
	{
		public static void Update(this HybridAnimancerComponent animancer, float deltaTime)
		{
			animancer.Evaluate(deltaTime);
		}
	}
}
