using Pug.Conversion;

public class EquipmentSkinConverter : SingleAuthoringComponentConverter<EquipmentSkinAuthoring>
{
	protected override void Convert(EquipmentSkinAuthoring authoring)
	{
		AddComponentData(new EquipmentSkinCD
		{
			skin = authoring.skinRef.address
		});
	}
}
