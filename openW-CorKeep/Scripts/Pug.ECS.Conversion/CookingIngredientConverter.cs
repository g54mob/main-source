using Pug.Conversion;

public class CookingIngredientConverter : SingleAuthoringComponentConverter<CookingIngredientAuthoring>
{
	protected override void Convert(CookingIngredientAuthoring authoring)
	{
		AddComponentData(new CookingIngredientCD
		{
			brightestColor = authoring.brightestColor,
			brightColor = authoring.brightColor,
			darkColor = authoring.darkColor,
			darkestColor = authoring.darkestColor,
			turnsIntoFood = authoring.turnsIntoFood,
			ingredientType = authoring.ingredientType
		});
	}
}
