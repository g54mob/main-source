using Pug.Conversion;

public class AncientElectricityConnectionConverter : SingleAuthoringComponentConverter<AncientElectricityConnectionAuthoring>
{
	protected override void Convert(AncientElectricityConnectionAuthoring authoring)
	{
		AddComponentData(new AncientElectricityConnectionCD
		{
			electricityAmount = authoring.electricityAmount,
			sourceEnergy = authoring.sourceEnergy,
			blocksElectricity = authoring.blocksElectricity
		});
	}
}
