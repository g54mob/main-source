using UnityEngine;

[CreateAssetMenu(menuName = "Ferry/Spawn Position Providers/Active Spawn Position Provider")]
public class ActiveSpawnPositionProvider : SpawnPositionProviderBase
{
	[Range(0f, 1f)]
	[Tooltip("The range is a percentage of the distance between the reachable and destruction radii (0 = destructionRadius)")]
	public float DistanceRange;

	[Range(0f, 90f)]
	[Tooltip("The range in degrees of the angle at which the spawn position can be relative to the current in negative an positive direction")]
	public float AngleRange;

	private float _destructionRadius;

	private float _reachableRadius;

	private Vector3 _currentDirection;

	public override void Initialize(GameplaySettings settings, Vector3 currentDirection)
	{
		_destructionRadius = settings.DestructionRadius;
		_reachableRadius = settings.MapRadius;
		_currentDirection = currentDirection.normalized;
	}

	public override Vector3 ReturnInitialSpawnPosition(bool outsideConstructionRadius)
	{
		return ReturnSpawnPosition();
	}

	public override Vector3 ReturnSpawnPosition()
	{
		float num = Mathf.Lerp(_destructionRadius, _reachableRadius, DistanceRange);
		return Quaternion.AngleAxis(Random.Range(0f - AngleRange, AngleRange), Vector3.up) * -_currentDirection * num;
	}
}
