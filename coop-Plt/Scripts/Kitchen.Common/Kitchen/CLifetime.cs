using Unity.Entities;

namespace Kitchen
{
	public struct CLifetime : IComponentData
	{
		public float RemainingLife;

		public CLifetime(float duration)
		{
			RemainingLife = duration;
		}
	}
}
