namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_007 : LEM_CharacterController_Base
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		SvMult_AnyRare = 1f;
		SvMult_Gala = 0f;
		SvMult_Holo = 0f;
		SvMult_Inve = 100f;
		GiveSurvarocchi();
	}
}
