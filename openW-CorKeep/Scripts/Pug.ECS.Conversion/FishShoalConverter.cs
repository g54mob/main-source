using Pug.Conversion;

public class FishShoalConverter : SingleAuthoringComponentConverter<FishShoalAuthoring>
{
	protected override void Convert(FishShoalAuthoring authoring)
	{
		EnsureHasComponent<FishShoalCD>();
	}
}
