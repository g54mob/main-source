using Unity.Entities;

[InternalBufferCapacity(0)]
public struct EventTerminalSequenceBuffer : IBufferElementData
{
	public EventTerminalAction action;

	public ConnectionAndDirection target;

	public float duration;
}
