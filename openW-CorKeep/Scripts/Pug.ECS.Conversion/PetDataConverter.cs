using Pug.Conversion;

public class PetDataConverter : SingleAuthoringComponentConverter<PetDataAuthoring>
{
	protected override void Convert(PetDataAuthoring authoring)
	{
		EnsureHasBuffer<PetTalentBuffer>();
		EnsureHasComponent<PetSkinCD>();
	}
}
