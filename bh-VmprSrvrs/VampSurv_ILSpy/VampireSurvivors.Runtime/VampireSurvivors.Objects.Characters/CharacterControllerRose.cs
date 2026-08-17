using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerRose : CharacterController
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		base._spriteTrail.Reset();
		SpriteTrail spriteTrail = base._spriteTrail;
		spriteTrail._MaxHistory = 0;
		spriteTrail.InitialiseGhosts(expandExisting: true);
	}
}
