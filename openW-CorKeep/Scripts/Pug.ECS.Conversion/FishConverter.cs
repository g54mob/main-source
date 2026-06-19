using Pug.Conversion;

public class FishConverter : SingleAuthoringComponentConverter<FishAuthoring>
{
	protected override void Convert(FishAuthoring authoring)
	{
		EnsureHasComponent<FishCD>();
	}
}
