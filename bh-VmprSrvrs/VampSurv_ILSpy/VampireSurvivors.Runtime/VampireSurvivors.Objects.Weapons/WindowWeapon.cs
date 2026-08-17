namespace VampireSurvivors.Objects.Weapons;

public class WindowWeapon : Weapon
{
	public override float PAmount()
	{
		return 1f;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
