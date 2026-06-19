using Unity.Entities;
using Unity.NetCode;

public struct MimicPlayerInstrumentNotesCD : IComponentData, IQueryTypeParameter
{
	public float hearRange;

	public SFXTableIDField sfx;

	public int keyOffset;

	[GhostField]
	public bool playerHoldingInstrumentExists;

	[GhostField]
	public bool isPlayingNotes;

	[GhostField]
	public float pitch;
}
