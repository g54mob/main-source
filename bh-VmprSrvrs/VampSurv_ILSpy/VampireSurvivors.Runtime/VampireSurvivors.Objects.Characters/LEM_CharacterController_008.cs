namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_008 : LEM_CharacterController_Base
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		SvMult_Gala = 8f;
		GiveSurvarocchi();
	}
}
