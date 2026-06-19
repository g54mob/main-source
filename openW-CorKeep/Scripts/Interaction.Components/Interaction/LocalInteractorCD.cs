using Unity.Entities;
using Unity.NetCode;

namespace Interaction
{
	[GhostComponent(PrefabType = GhostPrefabType.PredictedClient)]
	public struct LocalInteractorCD : IComponentData, IQueryTypeParameter
	{
		public Entity lastClosestInteractable;
	}
}
