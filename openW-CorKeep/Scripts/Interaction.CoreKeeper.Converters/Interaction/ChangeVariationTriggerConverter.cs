using Pug.Conversion;

namespace Interaction
{
	public class ChangeVariationTriggerConverter : SingleAuthoringComponentConverter<ChangeVariationTriggerAuthoring>
	{
		protected override void Convert(ChangeVariationTriggerAuthoring authoring)
		{
			((Converter)this).EnsureHasComponent<ChangeVariationTriggerCD>();
			((Converter)this).EnsureHasBuffer<TriggerUseInteractionBuffer>();
		}
	}
}
