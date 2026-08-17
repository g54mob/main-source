using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_GoldCount_Thorns : CharacterSkillCard_Base
{
	protected override int[] bonusTresholds => new int[3] { 1000, 2000, 3000 };

	public SubSkillCard_GoldCount_Thorns(ArcanaType type)
		: base(type)
	{
	}

	public override void Update()
	{
		base.Update();
		Update_CountGold();
	}

	protected override void OnGoldCountReached()
	{
		LinkedCharacter.HasThorns = true;
		CharacterController linkedCharacter = LinkedCharacter;
		PlayerModifierStats playerStats = linkedCharacter._playerStats;
		float num = playerStats._003CThorns_003Ek__BackingField + 0.5f;
		playerStats._003CThorns_003Ek__BackingField = num;
	}
}
