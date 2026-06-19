using Unity.Entities;

namespace PugWorldGen
{
	public struct SpawnAreaEntityRefCD : IComponentData, IQueryTypeParameter
	{
		public Entity Value;
	}
}
