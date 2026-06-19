using Unity.Entities;

namespace Pug.ECS.Hybrid
{
	public struct EntityMonoBehaviourCD : IComponentData, IQueryTypeParameter
	{
		public UnityObjectRef<EntityMonoBehaviour> entityMonoBehaviour;
	}
}
