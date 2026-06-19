using Pug.Conversion;

public class MealsEatenConverter : SingleAuthoringComponentConverter<MealsEatenAuthoring>
{
	protected override void Convert(MealsEatenAuthoring authoring)
	{
		EnsureHasComponent<MealsEatenCD>();
	}
}
