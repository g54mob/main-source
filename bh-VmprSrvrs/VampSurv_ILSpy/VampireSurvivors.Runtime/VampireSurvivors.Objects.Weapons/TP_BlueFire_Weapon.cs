namespace VampireSurvivors.Objects.Weapons;

public class TP_BlueFire_Weapon : Weapon
{
	private bool _isManualFire;

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void ResetFiringTimer()
	{
		if (!_isManualFire)
		{
			base.ResetFiringTimer();
		}
		else if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
