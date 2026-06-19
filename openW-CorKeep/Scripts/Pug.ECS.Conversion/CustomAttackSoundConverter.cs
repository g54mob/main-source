using Pug.Conversion;

public class CustomAttackSoundConverter : SingleAuthoringComponentConverter<CustomAttackSoundAuthoring>
{
	protected override void Convert(CustomAttackSoundAuthoring authoring)
	{
		AddComponentData(new CustomAttackSoundCD
		{
			attackSoundId = authoring.attackSoundId.value,
			impactSoundId = authoring.impactSoundId.value,
			windupSoundId = authoring.windupSound.value,
			windupCancelSoundId = authoring.windupCancelSound.value,
			strongAttackSoundId = authoring.strongAttackSound.value
		});
	}
}
