using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_EnemiesCount_AddArmor : CharacterSkillCard_Base
{
	protected override int[] bonusTresholds => new int[3] { 1000, 5000, 10000 };

	public SubSkillCard_EnemiesCount_AddArmor(ArcanaType type)
		: base(type)
	{
	}

	public override void Update()
	{
		base.Update();
		Update_CountEnemies();
	}

	protected override void OnEnemiesCountReached()
	{
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 1f;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
	}
}
