using Pug.Conversion;

public class RecipeConverter : SingleAuthoringComponentConverter<RecipeAuthoring>
{
	protected override void Convert(RecipeAuthoring authoring)
	{
		AddComponentData(new ParchmentRecipeCD
		{
			objectToCraft = authoring.objectToCraft,
			requiresNearbyObject = authoring.requiresNearbyObject
		});
	}
}
