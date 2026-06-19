using Pug.Conversion;

public class WeaponSkillGainedMultiplierConverter : SingleAuthoringComponentConverter<WeaponSkillGainedMultiplierAuthoring>
{
	protected override void Convert(WeaponSkillGainedMultiplierAuthoring authoring)
	{
		AddComponentData(new WeaponSkillMultiplierCD
		{
			skillMultiplier = authoring.skillMultiplier
		});
	}
}
