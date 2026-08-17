namespace VampireSurvivors.Objects.Weapons;

public class FireExplosionWeapon_Tohil : Weapon
{
	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
