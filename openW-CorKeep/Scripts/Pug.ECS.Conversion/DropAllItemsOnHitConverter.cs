using Pug.Conversion;

public class DropAllItemsOnHitConverter : SingleAuthoringComponentConverter<DropAllItemsOnHitAuthoring>
{
	protected override void Convert(DropAllItemsOnHitAuthoring authoring)
	{
		AddComponentData(new DropAllItemsOnHitCD
		{
			dropOffset = authoring.dropOffset
		});
	}
}
