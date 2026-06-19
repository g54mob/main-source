using Pug.Conversion;

public class VendingMachineConverter : SingleAuthoringComponentConverter<VendingMachineAuthoring>
{
	protected override void Convert(VendingMachineAuthoring authoring)
	{
		AddComponentData(new VendingMachineCD
		{
			sizeX = authoring.sizeX,
			sizeY = authoring.sizeY
		});
		EnsureHasBuffer<VendingMachineItemBuffer>();
		foreach (ObjectData item in authoring.items)
		{
			AddToBuffer(new VendingMachineItemBuffer
			{
				objectID = item.objectID
			});
		}
	}
}
