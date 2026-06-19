using Pug.Conversion;

public class BreedStateConverter : SingleAuthoringComponentConverter<BreedStateAuthoring>
{
	protected override void Convert(BreedStateAuthoring authoring)
	{
		AddComponentData(new BreedStateCD
		{
			mealsToTrigger = authoring.mealsToTrigger,
			minDistanceToBreed = authoring.minDistanceToBreed,
			babyType = authoring.babyType
		});
		float num = 0f;
		foreach (BreedStateAuthoring.VariationWithWeight mutationWeight in authoring.mutationWeights)
		{
			num += mutationWeight.weight;
		}
		float num2 = authoring.mutationChance / num;
		float num3 = 0f;
		BreedStateCD.PossibleChildVariation[] array = new BreedStateCD.PossibleChildVariation[authoring.mutationWeights.Count];
		for (int i = 0; i < authoring.mutationWeights.Count; i++)
		{
			num3 += authoring.mutationWeights[i].weight * num2;
			array[i] = new BreedStateCD.PossibleChildVariation
			{
				Variation = authoring.mutationWeights[i].variation,
				AccumulatedProbability = num3
			};
		}
		SetPropertyList("Breed/PossibleChildVariations", array);
		EnsureHasComponent<MealsEatenCD>();
		EnsureHasComponent<BreedToggleCD>();
	}
}
