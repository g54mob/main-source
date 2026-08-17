using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_GoldCount_AddPassiveSlots : CharacterSkillCard_Base
{
	protected override int[] bonusTresholds => new int[3] { 2500, 7500, 15000 };

	public SubSkillCard_GoldCount_AddPassiveSlots(ArcanaType type)
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
		CharacterController linkedCharacter = LinkedCharacter;
		int maxAccessoryBonus = linkedCharacter._maxAccessoryBonus + 1;
		linkedCharacter._maxAccessoryBonus = maxAccessoryBonus;
	}
}
