namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_006 : LEM_CharacterController_Base
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		SvMult_AnyRare = 4f;
		GiveSurvarocchi();
	}
}
