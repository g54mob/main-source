using Pug.Conversion;

public class ChangeVariationAfterTimeConverter : SingleAuthoringComponentConverter<ChangeVariationAfterTimeAuthoring>
{
	protected override void Convert(ChangeVariationAfterTimeAuthoring authoring)
	{
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		AddComponentData(new ChangeVariationAfterTimeCD
		{
			requiredVariation = authoring.requiredVariation,
			variationToChangeTo = authoring.targetVariation,
			changeTimer = new TickTimer(authoring.timeSeconds, simulationTickRate)
		});
	}
}
