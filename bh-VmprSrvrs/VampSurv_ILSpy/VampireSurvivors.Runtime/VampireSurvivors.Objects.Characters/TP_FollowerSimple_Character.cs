using VampireSurvivors.App.Tools;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class TP_FollowerSimple_Character : TP_Character
{
	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		HealthBar healthBar = RenderingExtensions.SetScale(((CharacterController)this)._healthBar, 0.00125f);
	}
}
