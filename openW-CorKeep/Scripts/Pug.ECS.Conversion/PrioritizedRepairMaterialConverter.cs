using Pug.Conversion;

public class PrioritizedRepairMaterialConverter : SingleAuthoringComponentConverter<PrioritizedRepairMaterialAuthoring>
{
	protected override void Convert(PrioritizedRepairMaterialAuthoring authoring)
	{
		EnsureHasComponent<PrioritizedRepairMaterialCD>();
	}
}
