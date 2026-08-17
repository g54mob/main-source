namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerPantalone : CharacterController
{
	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		base._gFeverMul = 1.5f;
	}
}
