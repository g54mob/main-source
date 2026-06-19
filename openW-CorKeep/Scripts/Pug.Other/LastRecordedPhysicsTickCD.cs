using Unity.Entities;
using Unity.NetCode;

public struct LastRecordedPhysicsTickCD : IComponentData, IQueryTypeParameter
{
	public bool isNewTick;

	public NetworkTick lastRecordedTick;
}
