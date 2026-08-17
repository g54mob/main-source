using VampireSurvivors.App.Tools;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class Character_Follower_Simple : CharacterController
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		HealthBar healthBar = RenderingExtensions.SetScale(base._healthBar, 0.00125f);
	}
}
