using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
public struct UIActionBuffer : IBufferElementData
{
	public NetworkTick tick;

	public UIInputActionData actionData;
}
