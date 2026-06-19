using Unity.Entities;
using Unity.NetCode;

public struct UIInputActionDataRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public NetworkTick tick;

	public UIInputActionData actionData;
}
