using Unity.Entities;

public struct BreedStateCD : IComponentData, IQueryTypeParameter
{
	public struct PossibleChildVariation
	{
		public int Variation;

		public float AccumulatedProbability;
	}

	public int mealsToTrigger;

	public float minDistanceToBreed;

	public ObjectID babyType;

	public Entity partnerEntity;

	public Entity mangerEntity;

	public bool HasEatenEnough(MealsEatenCD mealsEatenCD)
	{
		return mealsEatenCD.Value >= mealsToTrigger;
	}
}
