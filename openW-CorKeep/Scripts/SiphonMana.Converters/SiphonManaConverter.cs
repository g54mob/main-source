using Pug.Conversion;
using SiphonMana.Authoring;
using SiphonMana.Components;

public class SiphonManaConverter : SingleAuthoringComponentConverter<SiphonManaAuthoring>
{
	protected override void Convert(SiphonManaAuthoring authoring)
	{
		((Converter)this).EnsureHasComponent<SiphonManaActiveTag>(false);
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		((Converter)this).AddComponentData<SiphonManaCD>(new SiphonManaCD
		{
			maxManaPerSiphonPercentage = authoring.maxManaSiphonedPerSecond * authoring.manaSiphonCooldownSeconds,
			siphonRadiusSq = authoring.siphonRadius * authoring.siphonRadius,
			maxTransferDistanceSq = authoring.maxTransferDistance * authoring.maxTransferDistance,
			siphonCooldownTimer = new TickTimer(authoring.manaSiphonCooldownSeconds, simulationTickRate)
		});
		((Converter)this).EnsureHasBuffer<SiphonManaTargetBufferElement>();
		for (int i = 0; i < 1; i++)
		{
			((Converter)this).AddToBuffer<SiphonManaTargetBufferElement>(default(SiphonManaTargetBufferElement));
		}
	}
}
