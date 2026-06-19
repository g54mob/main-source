using Pug.Conversion;

public class CookedFoodConverter : SingleAuthoringComponentConverter<CookedFoodAuthoring>
{
	protected override void Convert(CookedFoodAuthoring authoring)
	{
		base.PropertiesBuilder.SetProperty(base.ObjectIndex, "isCookedFood");
		AddComponentData(new CookedFoodCD
		{
			rareVersion = authoring.rareVersion,
			epicVersion = authoring.epicVersion,
			ingredient1BrightestColor = authoring.ingredient1BrightestColor,
			ingredient1BrightColor = authoring.ingredient1BrightColor,
			ingredient1DarkColor = authoring.ingredient1DarkColor,
			ingredient1DarkestColor = authoring.ingredient1DarkestColor,
			ingredient2BrightestColor = authoring.ingredient2BrightestColor,
			ingredient2BrightColor = authoring.ingredient2BrightColor,
			ingredient2DarkColor = authoring.ingredient2DarkColor,
			ingredient2DarkestColor = authoring.ingredient2DarkestColor
		});
	}
}
