using Pug.Conversion;

public class PlayerCustomizationConverter : SingleAuthoringComponentConverter<PlayerCustomizationAuthoring>
{
	protected override void Convert(PlayerCustomizationAuthoring authoring)
	{
		AddComponentData(new PlayerCustomizationCD
		{
			customization = PlayerCustomizationNetcode.ConvertFromAddress(authoring.customization),
			triggerCount = authoring.triggerCount
		});
	}
}
