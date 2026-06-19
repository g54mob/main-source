using Unity.Entities;

[InternalBufferCapacity(1)]
public struct TrackedNotesBuffer : IBufferElementData
{
	public Entity playerEntity;

	public int notes;

	public int prevNotes;
}
