using Pug.Conversion;

public class TableItemLightSourceConverter : SingleAuthoringComponentConverter<TableItemLightSourceAuthoring>
{
	protected override void Convert(TableItemLightSourceAuthoring authoring)
	{
		AddComponentData(new TableItemLightSourceCD
		{
			Condition = authoring.Condition
		});
	}
}
