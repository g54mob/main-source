using Unity.Entities;

namespace Pug.ECS.Hybrid
{
	public struct GraphicalObjectPrefabEntityCD : IComponentData, IQueryTypeParameter
	{
		public Entity Value;
	}
}
