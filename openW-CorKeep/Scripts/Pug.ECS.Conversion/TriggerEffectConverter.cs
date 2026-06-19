using Pug.Conversion;

public class TriggerEffectConverter : SingleAuthoringComponentConverter<TriggerEffectAuthoring>
{
	protected override void Convert(TriggerEffectAuthoring authoring)
	{
		AddComponentData(default(TriggerEffectCD));
	}
}
