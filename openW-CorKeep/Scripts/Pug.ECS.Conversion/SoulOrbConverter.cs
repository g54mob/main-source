using Pug.Conversion;

public class SoulOrbConverter : SingleAuthoringComponentConverter<SoulOrbAuthoring>
{
	protected override void Convert(SoulOrbAuthoring authoring)
	{
		AddComponentData(new SoulOrbCD
		{
			givesSoul = authoring.givesSoul
		});
	}
}
