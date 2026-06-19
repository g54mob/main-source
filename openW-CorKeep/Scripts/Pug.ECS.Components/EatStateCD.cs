using Pug.UnityExtensions;
using Unity.Entities;

public struct EatStateCD : IComponentData, IQueryTypeParameter
{
	public enum ObjectToEatType
	{
		Entity = 0,
		HeldEntity = 1,
		ContainedEntity = 2
	}

	public float duration;

	public float eatPostDuration;

	public int internalState;

	public ThreadSafeTimerSimple timer;

	public Entity entityToEatFrom;

	public ObjectID objectIdToEat;

	public ObjectToEatType objectToEatType;

	public float sqDistanceToEat;

	public int maxFoodUntilFull;
}
