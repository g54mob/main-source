using Pug.Conversion;

public class JewelryConverter : SingleAuthoringComponentConverter<JewelryAuthoring>
{
	protected override void Convert(JewelryAuthoring authoring)
	{
		if (authoring.polishedVersion != ObjectID.None)
		{
			AddComponentData(new JewelryCanBePolishedCD
			{
				polishedVersion = authoring.polishedVersion
			});
		}
	}
}
