using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnRevive_RapidFire : CharacterSkillCard_Base
{
	public SubSkillCard_OnRevive_RapidFire(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		base.OnOwnerRevived(percentage, instantRevival);
		CharacterController linkedCharacter = LinkedCharacter;
		linkedCharacter._classSupport.AddActiveRapidFire(-0.9f, 0.3f, 30000f);
	}
}
