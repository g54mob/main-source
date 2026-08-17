namespace VampireSurvivors.Objects.Weapons;

public class DivineBloodlineWeapon : Weapon
{
	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Cleanup()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Cleanup();
		}
	}
}
