using Pug.Conversion;

public class CastItemConverter : SingleAuthoringComponentConverter<CastItemAuthoring>
{
	protected override void Convert(CastItemAuthoring authoring)
	{
		AddComponentData(new CastItemCD
		{
			castTime = authoring.castTime,
			useType = authoring.useType,
			achievement = authoring.achievement,
			castCompleteEffect = authoring.castCompleteEffect
		});
		if (authoring.allowHoldToRepeat)
		{
			SetProperty("CastItem/allowHoldToRepeat");
		}
	}
}
