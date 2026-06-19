using Interaction;
using Pug.Conversion;

public class PlayerGraveConverter : SingleAuthoringComponentConverter<PlayerGraveAuthoring>
{
	protected override void Convert(PlayerGraveAuthoring authoring)
	{
		EnsureHasComponent<ClaimedByPlayerGuidCD>();
		EnsureHasBuffer<InventoryBuffer>();
		AddToBuffer(new InventoryBuffer
		{
			extraInventorySizeSlot = -1
		});
		EnsureHasBuffer<ContainedObjectsBuffer>();
		EnsureHasComponent<GhostAlwaysRelevantWhenClaimedCD>();
		EnsureHasComponent<InitialMoveInventoryFromCD>();
		EnsureHasComponent<PlayerGraveCD>();
		AddComponentData(new MapMarkerCD
		{
			mapMarkerType = MapMarkerType.PlayerGrave
		});
		EnsureHasBuffer<TriggerUseInteractionBuffer>();
	}
}
