using Unity.Entities;

namespace Kitchen
{
	public struct CCustomerSpawnDefinition : IComponentData
	{
		public float Probability;

		public CCustomerSpawnDefinition(float p)
		{
			Probability = p;
		}
	}
}
