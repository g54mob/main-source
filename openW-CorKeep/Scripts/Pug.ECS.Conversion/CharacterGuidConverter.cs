using Pug.Conversion;

public class CharacterGuidConverter : SingleAuthoringComponentConverter<CreateCharacterGuidAuthoring>
{
	protected override void Convert(CreateCharacterGuidAuthoring authoring)
	{
		EnsureHasComponent<CharacterGuidCD>();
		EnsureHasComponent<CreateNewGuidCD>();
	}
}
