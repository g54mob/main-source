using Unity.Entities;

namespace Interaction
{
	public struct NextInteractorCD : IComponentData, IQueryTypeParameter
	{
		public Entity nextClosestInteractable;
	}
}
