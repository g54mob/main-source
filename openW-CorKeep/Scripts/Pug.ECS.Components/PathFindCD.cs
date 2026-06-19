using Unity.Entities;
using Unity.Mathematics;

public struct PathFindCD : IComponentData, IQueryTypeParameter
{
	public enum PathFindAlgorithm
	{
		BFS = 0,
		AStar = 1
	}

	public const float MIN_COOLDOWN = 0.2f;

	public const float MAX_COOLDOWN = 0.3f;

	public Entity startEntity;

	public uint belongsToLayer;

	public Entity targetEntity;

	public int2 targetPosition;

	public Entity lastCalculatedEntity;

	public int2 lastCalculatedPosition;

	public float timer;

	public float pathValidTime;

	public int2 searchRadius;

	public bool blockedByCreatures;

	public bool isFlying;

	public readonly bool HasTarget()
	{
		if (!(targetEntity != Entity.Null))
		{
			return math.any(targetPosition != 0);
		}
		return true;
	}

	public readonly bool HasCalculatedPathForTarget()
	{
		if (lastCalculatedEntity == targetEntity)
		{
			return math.all(lastCalculatedPosition == targetPosition);
		}
		return false;
	}

	public readonly bool ShouldRefreshPath()
	{
		if (timer <= 0f)
		{
			return HasTarget();
		}
		return false;
	}

	public void UpdateTimers(float deltaTime)
	{
		timer -= deltaTime;
		pathValidTime -= deltaTime;
	}

	public void MarkRefreshed(ref Random rng)
	{
		timer = rng.NextFloat(0.2f, 0.3f);
		lastCalculatedEntity = targetEntity;
		lastCalculatedPosition = targetPosition;
	}
}
