using Pug.Conversion;

public class ConsumesManaConverter : SingleAuthoringComponentConverter<ConsumesManaAuthoring>
{
	protected override void Convert(ConsumesManaAuthoring authoring)
	{
		int manaCost = authoring.ComputeManaCost();
		AddComponentData(new ConsumesManaCD
		{
			manaCost = manaCost
		});
	}
}
