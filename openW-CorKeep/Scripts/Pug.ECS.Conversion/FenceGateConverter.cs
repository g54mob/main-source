using Pug.Conversion;

public class FenceGateConverter : SingleAuthoringComponentConverter<FenceGateAuthoring>
{
	protected override void Convert(FenceGateAuthoring authoring)
	{
		EnsureHasComponent<GateCD>();
		AddComponentData(new ColliderVariationCD
		{
			activeVariation = -1
		});
	}
}
