using Unity.Entities;
using Unity.NetCode;

namespace Interaction
{
	public struct InteractorCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		[GhostField]
		public Entity currentClosestInteractable;

		public bool interactTriggered;

		public readonly bool CanConsumeInteract()
		{
			return interactTriggered;
		}

		public bool TryConsumeInteract()
		{
			if (interactTriggered)
			{
				interactTriggered = false;
				return true;
			}
			return false;
		}
	}
}
