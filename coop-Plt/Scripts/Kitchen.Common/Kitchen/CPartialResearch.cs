using Unity.Entities;

namespace Kitchen
{
	public struct CPartialResearch : IComponentData
	{
		public int Upgrade;

		public int ResearchProvided;
	}
}
