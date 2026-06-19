using Pug.Conversion;

public class PetCandyConverter : SingleAuthoringComponentConverter<PetCandyAuthoring>
{
	protected override void Convert(PetCandyAuthoring authoring)
	{
		AddComponentData(new PetCandyCD
		{
			xp = authoring.xp
		});
	}
}
