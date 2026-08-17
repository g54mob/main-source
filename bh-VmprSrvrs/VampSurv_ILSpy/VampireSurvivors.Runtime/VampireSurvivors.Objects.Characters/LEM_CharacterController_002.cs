namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_002 : LEM_CharacterController_Base
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		((CharacterController)this)._maxAccessoryBonus = 100;
	}
}
