using Pug.Conversion;

public class IndirectProjectileConverter : SingleAuthoringComponentConverter<IndirectProjectileAuthoring>
{
	protected override void Convert(IndirectProjectileAuthoring authoring)
	{
		AddComponentData(new IndirectProjectileCD
		{
			delayTime = authoring.delayTime,
			seeking = authoring.seeking,
			speed = authoring.speed
		});
	}
}
