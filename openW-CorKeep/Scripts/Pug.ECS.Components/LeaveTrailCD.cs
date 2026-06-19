using Unity.Entities;

public struct LeaveTrailCD : IComponentData, IQueryTypeParameter
{
	public bool leaveTrail;

	public int trails;

	public ObjectID trailObjectID;
}
