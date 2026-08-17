namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_001 : LEM_CharacterController_Base
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		((CharacterController)this)._003CSkillCards_Mult_003Ek__BackingField = 4f;
		GiveSurvarocchi();
	}
}
