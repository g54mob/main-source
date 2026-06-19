using Pug.Conversion;

namespace Interaction
{
	public class ToggleInteractionOnVariationConverter : SingleAuthoringComponentConverter<ToggleInteractionOnVariationAuthoring>
	{
		protected override void Convert(ToggleInteractionOnVariationAuthoring authoring)
		{
			((Converter)this).AddComponentData<ToggleInteractionOnVariationCD>(new ToggleInteractionOnVariationCD
			{
				toggleType = authoring.toggleType,
				variation = authoring.variation
			});
		}
	}
}
