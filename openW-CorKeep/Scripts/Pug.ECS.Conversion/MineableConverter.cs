using Pug.Conversion;

public class MineableConverter : SingleAuthoringComponentConverter<MineableAuthoring>
{
	protected override void Convert(MineableAuthoring authoring)
	{
		AddComponentData(new MineableCD
		{
			playFailedEffectOnZeroDamage = authoring.playFailedEffectOnZeroDamage
		});
	}
}
