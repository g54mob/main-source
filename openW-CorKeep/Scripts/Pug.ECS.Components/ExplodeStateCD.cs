using Pug.UnityExtensions;
using Unity.Entities;

public struct ExplodeStateCD : IComponentData, IQueryTypeParameter
{
	public float distanceToExplode;

	public float anticipationDuration;

	public int tileDamage;

	public int damage;

	public ObjectID explosionID;

	public int explosionVariation;

	public float minHealthRatioToExplode;

	public int internalState;

	public ThreadSafeTimerSimple internalTimer;

	public Entity explosionEntity;

	public bool explodeEvenIfKilledByPlayerAtTheSameTime;

	public bool dropLootOnDestroy;
}
