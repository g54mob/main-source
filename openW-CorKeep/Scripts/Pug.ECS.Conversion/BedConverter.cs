using Pug.Conversion;

public class BedConverter : SingleAuthoringComponentConverter<BedAuthoring>
{
	protected override void Convert(BedAuthoring authoring)
	{
		EnsureHasComponent<BedCD>();
		EnsureHasComponent<ClaimedByPlayerGuidCD>();
		EnsureHasComponent<ClaimedByCharacterGuidCD>();
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<DetectRoomCD>();
		EnsureHasBuffer<RoomObjectBuffer>();
		EnsureHasBuffer<RoomEmptyPositions>();
	}
}
