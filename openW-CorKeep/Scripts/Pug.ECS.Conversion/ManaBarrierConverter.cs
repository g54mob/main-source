using Pug.Conversion;

public class ManaBarrierConverter : SingleAuthoringComponentConverter<ManaBarrierAuthoring>
{
	protected override void Convert(ManaBarrierAuthoring authoring)
	{
		AddComponentData(default(ManaBarrierCD));
	}
}
