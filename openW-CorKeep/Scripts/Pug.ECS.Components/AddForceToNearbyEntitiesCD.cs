using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct AddForceToNearbyEntitiesCD : IComponentData, IQueryTypeParameter
{
	public enum State
	{
		Initialize = 0,
		Inactive = 1,
		Active = 2
	}

	[GhostField]
	public State state;

	[GhostField]
	public TickTimer stateTimer;

	public float radiusSq;

	public float force;

	public BlobAssetReference<BlobCurve> activeForceMultiplierCurve;

	public bool checkLineOfSight;

	public float forceDuringActivation;

	public float activationDelay;

	public float activeDuration;

	public float inactiveDuration;
}
