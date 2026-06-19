using EnvironmentEvents.Authoring;
using EnvironmentEvents.Components;
using Pug.Conversion;

namespace EnvironmentEvents.Converters
{
	public class TriggerEnvironmentEventOnDeathConverter : SingleAuthoringComponentConverter<TriggerEnvironmentEventOnDeathAuthoring>
	{
		protected override void Convert(TriggerEnvironmentEventOnDeathAuthoring authoring)
		{
			((Converter)this).EnsureHasComponent<TriggerEnvironmentEventOnDeathCD>(true);
			((Converter)this).AddComponentData<EnvironmentEventOnDeathCD>(new EnvironmentEventOnDeathCD
			{
				environmentEvent = authoring.environmentEvent
			});
		}
	}
}
