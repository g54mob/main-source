using Pug.Conversion;

public class OverrideLegendaryForSlotRequirementsConverter : SingleAuthoringComponentConverter<OverrideLegendaryForSlotRequirementsAuthoring>
{
	protected override void Convert(OverrideLegendaryForSlotRequirementsAuthoring authoring)
	{
		EnsureHasComponent<OverrideLegendaryForSlotRequirementsCD>();
	}
}
