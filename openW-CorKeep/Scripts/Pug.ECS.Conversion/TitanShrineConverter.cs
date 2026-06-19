using Pug.Conversion;

public class TitanShrineConverter : SingleAuthoringComponentConverter<TitanShrineAuthoring>
{
	protected override void Convert(TitanShrineAuthoring authoring)
	{
		AddComponentData(new TitanShrineCD
		{
			titanObjectID = authoring.TitanObjectID
		});
	}
}
