namespace VampireSurvivors.Objects.Characters;

public class TP_Stella_Character : TP_Character
{
	public override bool DrainWeaponsImmunity => true;

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}
}
