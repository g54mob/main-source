namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_005 : LEM_CharacterController_Base
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		SvMult_Foil = 4f;
		SvMult_Gala = 4f;
		GiveSurvarocchi();
	}
}
