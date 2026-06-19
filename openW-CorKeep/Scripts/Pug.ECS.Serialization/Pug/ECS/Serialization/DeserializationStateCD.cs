using Unity.Entities;

namespace Pug.ECS.Serialization
{
	public struct DeserializationStateCD : IComponentData, IQueryTypeParameter
	{
		public DeserializationStates state;
	}
}
