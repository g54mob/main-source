using Pug.Conversion;

namespace Interaction
{
	public class DisableImmuneZoneConverter : SingleAuthoringComponentConverter<DisableImmuneZoneAuthoring>
	{
		protected override void Convert(DisableImmuneZoneAuthoring authoring)
		{
			((Converter)this).EnsureHasComponent<DisableImmuneZoneCD>();
			((Converter)this).EnsureHasBuffer<TriggerUseInteractionBuffer>();
		}
	}
}
