using Pug.Conversion;

public class PlayerGuidConverter : SingleAuthoringComponentConverter<CreatePlayerGuidAuthoring>
{
	protected override void Convert(CreatePlayerGuidAuthoring authoring)
	{
		EnsureHasComponent<PlayerGuidCD>();
		EnsureHasComponent<CreateNewGuidCD>();
	}
}
