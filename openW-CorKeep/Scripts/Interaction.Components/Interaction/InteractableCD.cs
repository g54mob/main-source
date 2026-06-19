using Unity.Entities;

namespace Interaction
{
	public struct InteractableCD : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
		public BlobAssetReference<InteractableData> interactableData;

		public BlobAssetReference<InteractablePointOffsetsData> interactablePointOffsetsData;
	}
}
